using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Script.Serialization;
using SahalarBurada.Models;
using SahalarBurada.Helpers;

namespace SahalarBurada.Services
{
    public static class DatabaseServisi
    {
        private const string ConnectionString = "Data Source=SahalarBuradaDatabase.db;Version=3;Busy Timeout=5000;";
        private static readonly JavaScriptSerializer Jss = new JavaScriptSerializer();

        public static void InitializeDatabase()
        {
            SQLiteConnection.ClearAllPools();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

                var tableExists = false;
                using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='organizers';", conn))
                {
                    tableExists = cmd.ExecuteScalar() != null;
                }

                var needsReset = !tableExists;
                if (tableExists)
                {
                    var hasDemoOrg = false;
                    using (var cmd = new SQLiteCommand("SELECT COUNT(*) FROM organizers WHERE Eposta = 'orgdemo@mail.com';", conn))
                    {
                        hasDemoOrg = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }

                    var has500Reservations = false;
                    using (var cmd = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='reservations';", conn))
                    {
                        if (cmd.ExecuteScalar() != null)
                        {
                            using (var cmdRes = new SQLiteCommand("SELECT COUNT(*) FROM reservations;", conn))
                            {
                                var totalCount = Convert.ToInt32(cmdRes.ExecuteScalar());
                                using (var cmdDist = new SQLiteCommand("SELECT COUNT(DISTINCT (SahaId || '_' || Tarih || '_' || Saat)) FROM reservations;", conn))
                                {
                                    var distinctCount = Convert.ToInt32(cmdDist.ExecuteScalar());
                                    has500Reservations = totalCount >= 500 && totalCount == distinctCount;
                                }
                            }
                        }
                    }

                    needsReset = !hasDemoOrg || !has500Reservations;
                }

                if (needsReset)
                {
                    using (var cmd = new SQLiteCommand("DROP TABLE IF EXISTS reservations;", conn)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand("DROP TABLE IF EXISTS fields;", conn)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand("DROP TABLE IF EXISTS organizers;", conn)) cmd.ExecuteNonQuery();
                    using (var cmd = new SQLiteCommand("DROP TABLE IF EXISTS users;", conn)) cmd.ExecuteNonQuery();
                }

                var createUsers = @"CREATE TABLE IF NOT EXISTS users (
                    Id TEXT PRIMARY KEY,
                    Ad TEXT,
                    Soyad TEXT,
                    Eposta TEXT,
                    SifreHash TEXT,
                    KayitTarihi TEXT,
                    Telefon TEXT
                );";
                using (var cmd = new SQLiteCommand(createUsers, conn)) cmd.ExecuteNonQuery();

                var createOrganizers = @"CREATE TABLE IF NOT EXISTS organizers (
                    Id TEXT PRIMARY KEY,
                    IsletmeAdi TEXT,
                    Ad TEXT,
                    Soyad TEXT,
                    Eposta TEXT,
                    SifreHash TEXT,
                    KayitTarihi TEXT,
                    Telefon TEXT
                );";
                using (var cmd = new SQLiteCommand(createOrganizers, conn)) cmd.ExecuteNonQuery();

                // Schema migration: Alter table to add Telefon column dynamically to organizers if it doesn't exist
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE organizers ADD COLUMN Telefon TEXT;", conn))
                        cmd.ExecuteNonQuery();
                }
                catch (SQLiteException)
                {
                    // Column already exists, ignore safely
                }

                var createFields = @"CREATE TABLE IF NOT EXISTS fields (
                    Id TEXT PRIMARY KEY,
                    OrganizatorId TEXT,
                    Ad TEXT,
                    Sehir TEXT,
                    Ilce TEXT,
                    Adres TEXT,
                    FiyatSaat REAL,
                    MusaitGunler TEXT,
                    MusaitSaatler TEXT,
                    Aciklama TEXT,
                    EklenmeTarihi TEXT,
                    Telefon TEXT,
                    Kapasite INTEGER DEFAULT 14
                );";
                using (var cmd = new SQLiteCommand(createFields, conn)) cmd.ExecuteNonQuery();

                // Schema migration: Alter table to add Telefon column dynamically to fields if it doesn't exist
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE fields ADD COLUMN Telefon TEXT;", conn))
                        cmd.ExecuteNonQuery();
                }
                catch (SQLiteException)
                {
                    // Column already exists, ignore safely
                }

                // Schema migration: Alter table to add Kapasite column dynamically to fields if it doesn't exist
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE fields ADD COLUMN Kapasite INTEGER DEFAULT 14;", conn))
                        cmd.ExecuteNonQuery();
                }
                catch (SQLiteException)
                {
                    // Column already exists, ignore safely
                }

                // Schema migration: Alter table to add Telefon column dynamically to users if it doesn't exist
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE users ADD COLUMN Telefon TEXT;", conn))
                        cmd.ExecuteNonQuery();
                }
                catch (SQLiteException)
                {
                    // Column already exists, ignore safely
                }

                var createReservations = @"CREATE TABLE IF NOT EXISTS reservations (
                    Id TEXT PRIMARY KEY,
                    SahaId TEXT,
                    SahaAdi TEXT,
                    KullaniciId TEXT,
                    MisafirAd TEXT,
                    MisafirTelefon TEXT,
                    Tarih TEXT,
                    Saat TEXT,
                    ToplamFiyat REAL,
                    OlusturmaTarihi TEXT,
                    KisiSayisi INTEGER DEFAULT 1
                );";
                using (var cmd = new SQLiteCommand(createReservations, conn)) cmd.ExecuteNonQuery();

                // Schema migration: Alter table to add KisiSayisi column dynamically to reservations if it doesn't exist
                try
                {
                    using (var cmd = new SQLiteCommand("ALTER TABLE reservations ADD COLUMN KisiSayisi INTEGER DEFAULT 1;", conn))
                        cmd.ExecuteNonQuery();
                }
                catch (SQLiteException)
                {
                    // Column already exists, ignore safely
                }

                if (needsReset)
                {
                    SeedData(conn);
                }
            }
        }

        // --- Users (Kiracılar) ---
        public static void InsertUser(Kullanici k)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "INSERT INTO users (Id, Ad, Soyad, Eposta, SifreHash, KayitTarihi, Telefon) VALUES (@Id, @Ad, @Soyad, @Eposta, @SifreHash, @KayitTarihi, @Telefon)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", k.Id);
                    cmd.Parameters.AddWithValue("@Ad", k.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", k.Soyad);
                    cmd.Parameters.AddWithValue("@Eposta", k.Eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", k.SifreHash);
                    cmd.Parameters.AddWithValue("@KayitTarihi", k.KayitTarihi.ToString("o"));
                    cmd.Parameters.AddWithValue("@Telefon", k.Telefon ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Kullanici GetUserByEmail(string eposta)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE Eposta = @Eposta COLLATE NOCASE";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Kullanici
                            {
                                Id = reader["Id"].ToString(),
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                Eposta = reader["Eposta"].ToString(),
                                SifreHash = reader["SifreHash"].ToString(),
                                KayitTarihi = DateTime.Parse(reader["KayitTarihi"].ToString()),
                                Telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static Kullanici GetUserById(string id)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM users WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Kullanici
                            {
                                Id = reader["Id"].ToString(),
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                Eposta = reader["Eposta"].ToString(),
                                SifreHash = reader["SifreHash"].ToString(),
                                KayitTarihi = DateTime.Parse(reader["KayitTarihi"].ToString()),
                                Telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool CheckUserExists(string eposta)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE Eposta = @Eposta COLLATE NOCASE";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // --- Organizers (Organizatörler) ---
        public static void InsertOrganizer(Organizator o)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "INSERT INTO organizers (Id, IsletmeAdi, Ad, Soyad, Eposta, SifreHash, KayitTarihi, Telefon) VALUES (@Id, @IsletmeAdi, @Ad, @Soyad, @Eposta, @SifreHash, @KayitTarihi, @Telefon)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", o.Id);
                    cmd.Parameters.AddWithValue("@IsletmeAdi", o.IsletmeAdi);
                    cmd.Parameters.AddWithValue("@Ad", o.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", o.Soyad);
                    cmd.Parameters.AddWithValue("@Eposta", o.Eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", o.SifreHash);
                    cmd.Parameters.AddWithValue("@KayitTarihi", o.KayitTarihi.ToString("o"));
                    cmd.Parameters.AddWithValue("@Telefon", o.Telefon ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Organizator GetOrganizerByEmail(string eposta)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM organizers WHERE Eposta = @Eposta COLLATE NOCASE";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Organizator
                            {
                                Id = reader["Id"].ToString(),
                                IsletmeAdi = reader["IsletmeAdi"].ToString(),
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                Eposta = reader["Eposta"].ToString(),
                                SifreHash = reader["SifreHash"].ToString(),
                                KayitTarihi = DateTime.Parse(reader["KayitTarihi"].ToString()),
                                Telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : ""
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool CheckOrganizerExists(string eposta)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM organizers WHERE Eposta = @Eposta COLLATE NOCASE";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                }
            }
        }

        // --- Fields (Sahalar) ---
        public static void InsertField(HaliSaha s)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO fields 
                    (Id, OrganizatorId, Ad, Sehir, Ilce, Adres, FiyatSaat, MusaitGunler, MusaitSaatler, Aciklama, EklenmeTarihi, Telefon, Kapasite) 
                    VALUES (@Id, @OrganizatorId, @Ad, @Sehir, @Ilce, @Adres, @FiyatSaat, @MusaitGunler, @MusaitSaatler, @Aciklama, @EklenmeTarihi, @Telefon, @Kapasite)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.Parameters.AddWithValue("@OrganizatorId", s.OrganizatorId);
                    cmd.Parameters.AddWithValue("@Ad", s.Ad);
                    cmd.Parameters.AddWithValue("@Sehir", s.Sehir);
                    cmd.Parameters.AddWithValue("@Ilce", s.Ilce);
                    cmd.Parameters.AddWithValue("@Adres", s.Adres);
                    cmd.Parameters.AddWithValue("@FiyatSaat", s.FiyatSaat);
                    cmd.Parameters.AddWithValue("@MusaitGunler", Jss.Serialize(s.MüsaitGunler ?? new List<string>()));
                    cmd.Parameters.AddWithValue("@MusaitSaatler", Jss.Serialize(s.MüsaitSaatler ?? new List<string>()));
                    cmd.Parameters.AddWithValue("@Aciklama", s.Aciklama);
                    cmd.Parameters.AddWithValue("@EklenmeTarihi", s.EklenmeTarihi.ToString("o"));
                    cmd.Parameters.AddWithValue("@Telefon", s.Telefon ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Kapasite", s.Kapasite);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<HaliSaha> GetAllFields()
        {
            var list = new List<HaliSaha>();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM fields";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var s = new HaliSaha
                        {
                            Id = reader["Id"].ToString(),
                            OrganizatorId = reader["OrganizatorId"].ToString(),
                            Ad = reader["Ad"].ToString(),
                            Sehir = reader["Sehir"].ToString(),
                            Ilce = reader["Ilce"].ToString(),
                            Adres = reader["Adres"].ToString(),
                            FiyatSaat = Convert.ToDouble(reader["FiyatSaat"]),
                            MüsaitGunler = Jss.Deserialize<List<string>>(reader["MusaitGunler"].ToString()),
                            MüsaitSaatler = Jss.Deserialize<List<string>>(reader["MusaitSaatler"].ToString()),
                            Aciklama = reader["Aciklama"].ToString(),
                            EklenmeTarihi = DateTime.Parse(reader["EklenmeTarihi"].ToString()),
                            Telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : "",
                            Kapasite = reader["Kapasite"] != DBNull.Value ? Convert.ToInt32(reader["Kapasite"]) : 14
                        };
                        list.Add(s);
                    }
                }
            }
            return list;
        }

        public static void DeleteField(string id)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmdField = new SQLiteCommand("DELETE FROM fields WHERE Id = @Id", conn);
                cmdField.Parameters.AddWithValue("@Id", id);
                cmdField.ExecuteNonQuery();

                var cmdRes = new SQLiteCommand("DELETE FROM reservations WHERE SahaId = @Id", conn);
                cmdRes.Parameters.AddWithValue("@Id", id);
                cmdRes.ExecuteNonQuery();
            }
        }

        // --- Reservations (Rezervasyonlar) ---
        public static void CleanOldReservations()
        {
            var list = GetAllReservations();
            var today = DateTime.Today;
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                foreach (var r in list)
                {
                    if (r.Tarih.ToLocalTime().Date < today)
                    {
                        var cmd = new SQLiteCommand("DELETE FROM reservations WHERE Id = @Id", conn);
                        cmd.Parameters.AddWithValue("@Id", r.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void DeleteReservation(string id)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                var cmd = new SQLiteCommand("DELETE FROM reservations WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static void InsertReservation(Rezervasyon r)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO reservations 
                    (Id, SahaId, SahaAdi, KullaniciId, MisafirAd, MisafirTelefon, Tarih, Saat, ToplamFiyat, OlusturmaTarihi, KisiSayisi) 
                    VALUES (@Id, @SahaId, @SahaAdi, @KullaniciId, @MisafirAd, @MisafirTelefon, @Tarih, @Saat, @ToplamFiyat, @OlusturmaTarihi, @KisiSayisi)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", r.Id);
                    cmd.Parameters.AddWithValue("@SahaId", r.SahaId);
                    cmd.Parameters.AddWithValue("@SahaAdi", r.SahaAdi);
                    cmd.Parameters.AddWithValue("@KullaniciId", r.KullaniciId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MisafirAd", r.MisafirAd ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MisafirTelefon", r.MisafirTelefon ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tarih", r.Tarih.ToString("o"));
                    cmd.Parameters.AddWithValue("@Saat", r.Saat);
                    cmd.Parameters.AddWithValue("@ToplamFiyat", r.ToplamFiyat);
                    cmd.Parameters.AddWithValue("@OlusturmaTarihi", r.OlusturmaTarihi.ToString("o"));
                    cmd.Parameters.AddWithValue("@KisiSayisi", r.KisiSayisi);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Rezervasyon> GetAllReservations()
        {
            var list = new List<Rezervasyon>();
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM reservations";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var r = new Rezervasyon
                        {
                            Id = reader["Id"].ToString(),
                            SahaId = reader["SahaId"].ToString(),
                            SahaAdi = reader["SahaAdi"].ToString(),
                            KullaniciId = reader["KullaniciId"] != DBNull.Value ? reader["KullaniciId"].ToString() : null,
                            MisafirAd = reader["MisafirAd"] != DBNull.Value ? reader["MisafirAd"].ToString() : null,
                            MisafirTelefon = reader["MisafirTelefon"] != DBNull.Value ? reader["MisafirTelefon"].ToString() : null,
                            Tarih = DateTime.Parse(reader["Tarih"].ToString()),
                            Saat = reader["Saat"].ToString(),
                            ToplamFiyat = Convert.ToDouble(reader["ToplamFiyat"]),
                            OlusturmaTarihi = DateTime.Parse(reader["OlusturmaTarihi"].ToString()),
                            KisiSayisi = reader["KisiSayisi"] != DBNull.Value ? Convert.ToInt32(reader["KisiSayisi"]) : 1
                        };
                        list.Add(r);
                    }
                }
            }
            return list;
        }

        public static void UpdateUser(Kullanici k)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "UPDATE users SET Ad = @Ad, Soyad = @Soyad, Eposta = @Eposta, SifreHash = @SifreHash, Telefon = @Telefon WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", k.Id);
                    cmd.Parameters.AddWithValue("@Ad", k.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", k.Soyad);
                    cmd.Parameters.AddWithValue("@Eposta", k.Eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", k.SifreHash);
                    cmd.Parameters.AddWithValue("@Telefon", k.Telefon ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateOrganizer(Organizator o)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = "UPDATE organizers SET IsletmeAdi = @IsletmeAdi, Ad = @Ad, Soyad = @Soyad, Eposta = @Eposta, SifreHash = @SifreHash, Telefon = @Telefon WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", o.Id);
                    cmd.Parameters.AddWithValue("@IsletmeAdi", o.IsletmeAdi);
                    cmd.Parameters.AddWithValue("@Ad", o.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", o.Soyad);
                    cmd.Parameters.AddWithValue("@Eposta", o.Eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", o.SifreHash);
                    cmd.Parameters.AddWithValue("@Telefon", o.Telefon ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateField(HaliSaha s)
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();
                string sql = @"UPDATE fields SET 
                    Ad = @Ad, Sehir = @Sehir, Ilce = @Ilce, Adres = @Adres, 
                    FiyatSaat = @FiyatSaat, MusaitGunler = @MusaitGunler, 
                    MusaitSaatler = @MusaitSaatler, Aciklama = @Aciklama, 
                    Telefon = @Telefon, Kapasite = @Kapasite 
                    WHERE Id = @Id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", s.Id);
                    cmd.Parameters.AddWithValue("@Ad", s.Ad);
                    cmd.Parameters.AddWithValue("@Sehir", s.Sehir);
                    cmd.Parameters.AddWithValue("@Ilce", s.Ilce);
                    cmd.Parameters.AddWithValue("@Adres", s.Adres);
                    cmd.Parameters.AddWithValue("@FiyatSaat", s.FiyatSaat);
                    cmd.Parameters.AddWithValue("@MusaitGunler", Jss.Serialize(s.MüsaitGunler ?? new List<string>()));
                    cmd.Parameters.AddWithValue("@MusaitSaatler", Jss.Serialize(s.MüsaitSaatler ?? new List<string>()));
                    cmd.Parameters.AddWithValue("@Aciklama", s.Aciklama);
                    cmd.Parameters.AddWithValue("@Telefon", s.Telefon ?? "");
                    cmd.Parameters.AddWithValue("@Kapasite", s.Kapasite);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void SeedData(SQLiteConnection conn)
        {
            string[] firstNames = { "Ahmet", "Mehmet", "Hasan", "Hüseyin", "Ali", "Mustafa", "Murat", "Serkan", "Volkan", "Burak", "Emre", "Kaan", "Can", "Hakan", "Gökhan", "Süleyman", "Osman", "Ömer", "Fatih", "Yusuf", "Selim", "Cem", "Deniz", "Ege", "Alper", "Yiğit", "Mert", "Oğuz", "Talat", "Zafer" };
            string[] lastNames = { "Yılmaz", "Kaya", "Demir", "Şahin", "Çelik", "Yıldız", "Öztürk", "Arslan", "Aydın", "Koç", "Güler", "Bulut", "Yalçın", "Güneş", "Aslan", "Karataş", "Yıldırım", "Özdemir", "Ozturk", "Kılıç", "Erdoğan", "Şen", "Acar", "Özcan", "Özkan", "Toprak", "Çetin", "Peker", "Avcı", "Sarı" };

            // Seed 150 Users
            string insertUserSql = "INSERT INTO users (Id, Ad, Soyad, Eposta, SifreHash, KayitTarihi, Telefon) VALUES (@Id, @Ad, @Soyad, @Eposta, @SifreHash, @KayitTarihi, @Telefon)";
            
            // First user is the demo user
            using (var cmd = new SQLiteCommand(insertUserSql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", "u_demo");
                cmd.Parameters.AddWithValue("@Ad", "Can");
                cmd.Parameters.AddWithValue("@Soyad", "Turhan");
                cmd.Parameters.AddWithValue("@Eposta", "userdemo@mail.com");
                cmd.Parameters.AddWithValue("@SifreHash", SifreHelper.Hash("123456"));
                cmd.Parameters.AddWithValue("@KayitTarihi", DateTime.Now.ToString("o"));
                cmd.Parameters.AddWithValue("@Telefon", "05412601098");
                cmd.ExecuteNonQuery();
            }

            for (int i = 2; i <= 150; i++)
            {
                string ad = firstNames[i % firstNames.Length] + " " + (i / firstNames.Length + 1);
                string soyad = lastNames[i % lastNames.Length];
                string eposta = "user" + i + "@mail.com";
                string telefon = "054" + (1000000 + i).ToString();

                using (var cmd = new SQLiteCommand(insertUserSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", "u_" + i);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@Soyad", soyad);
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", SifreHelper.Hash("123456"));
                    cmd.Parameters.AddWithValue("@KayitTarihi", DateTime.Now.ToString("o"));
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.ExecuteNonQuery();
                }
            }

            // Seed 15 Organizers
            string insertOrgSql = "INSERT INTO organizers (Id, IsletmeAdi, Ad, Soyad, Eposta, SifreHash, KayitTarihi, Telefon) VALUES (@Id, @IsletmeAdi, @Ad, @Soyad, @Eposta, @SifreHash, @KayitTarihi, @Telefon)";
            
            // First organizer is the demo organizer
            using (var cmd = new SQLiteCommand(insertOrgSql, conn))
            {
                cmd.Parameters.AddWithValue("@Id", "o_demo");
                cmd.Parameters.AddWithValue("@IsletmeAdi", "Olimpiyat Halı Saha");
                cmd.Parameters.AddWithValue("@Ad", "Ali");
                cmd.Parameters.AddWithValue("@Soyad", "Yılmaz");
                cmd.Parameters.AddWithValue("@Eposta", "orgdemo@mail.com");
                cmd.Parameters.AddWithValue("@SifreHash", SifreHelper.Hash("123456"));
                cmd.Parameters.AddWithValue("@KayitTarihi", DateTime.Now.ToString("o"));
                cmd.Parameters.AddWithValue("@Telefon", "05321234567");
                cmd.ExecuteNonQuery();
            }

            string[] isletmeNames = {
                "Şampiyon Spor Kompleksi", "Arena Halı Saha", "Kanal Boyu Tesisleri",
                "Kadıköy Spor Parkı", "Bornova Futbol Arenası", "Çankaya Gençlik Tesisleri",
                "Alsancak Halı Saha", "Kartal Halı Tesisleri", "Beşiktaş Spor Kompleksi",
                "Karşıyaka Arena", "Göztepe Spor Vadisi", "Maltepe Spor Tesisleri",
                "Üsküdar Çim Saha", "Fatih Spor Kompleksi"
            };

            for (int j = 2; j <= 15; j++)
            {
                string isletme = isletmeNames[(j - 2) % isletmeNames.Length];
                if (j - 2 >= isletmeNames.Length) isletme += " " + (j / isletmeNames.Length + 1);
                string ad = firstNames[(j + 5) % firstNames.Length];
                string soyad = lastNames[(j + 5) % lastNames.Length];
                string eposta = "org" + j + "@mail.com";
                string telefon = "053" + (2000000 + j).ToString();

                using (var cmd = new SQLiteCommand(insertOrgSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", "o_" + j);
                    cmd.Parameters.AddWithValue("@IsletmeAdi", isletme);
                    cmd.Parameters.AddWithValue("@Ad", ad);
                    cmd.Parameters.AddWithValue("@Soyad", soyad);
                    cmd.Parameters.AddWithValue("@Eposta", eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", SifreHelper.Hash("123456"));
                    cmd.Parameters.AddWithValue("@KayitTarihi", DateTime.Now.ToString("o"));
                    cmd.Parameters.AddWithValue("@Telefon", telefon);
                    cmd.ExecuteNonQuery();
                }
            }

            // Seed 20 Fields (Sahalar)
            var tumGunler = new List<string> { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" };
            var tumSaatler = new List<string>
            {
                "00:00-01:00", "01:00-02:00", "02:00-03:00", "03:00-04:00",
                "04:00-05:00", "05:00-06:00", "06:00-07:00", "07:00-08:00",
                "08:00-09:00", "09:00-10:00", "10:00-11:00", "11:00-12:00",
                "12:00-13:00", "13:00-14:00", "14:00-15:00", "15:00-16:00",
                "16:00-17:00", "17:00-18:00", "18:00-19:00", "19:00-20:00",
                "20:00-21:00", "21:00-22:00", "22:00-23:00", "23:00-00:00"
            };

            string insertFieldSql = @"INSERT INTO fields 
                (Id, OrganizatorId, Ad, Sehir, Ilce, Adres, FiyatSaat, MusaitGunler, MusaitSaatler, Aciklama, EklenmeTarihi, Telefon, Kapasite) 
                VALUES (@Id, @OrganizatorId, @Ad, @Sehir, @Ilce, @Adres, @FiyatSaat, @MusaitGunler, @MusaitSaatler, @Aciklama, @EklenmeTarihi, @Telefon, @Kapasite)";

            var fields = new[]
            {
                new { Id = "f1", OrganizatorId = "o_demo", Ad = "Olimpiyat Merkez Saha", Sehir = "İstanbul", Ilce = "Kadıköy", Adres = "Olimpiyat Merkez Spor Tesisleri No:1", FiyatSaat = 1200.0, Telefon = "05321234567", Kapasite = 14, Aciklama = "Profesyonel zeminli, aydınlatmalı açık saha keyfi." },
                new { Id = "f2", OrganizatorId = "o_demo", Ad = "Olimpiyat Kapalı Saha", Sehir = "İstanbul", Ilce = "Kadıköy", Adres = "Olimpiyat Merkez Spor Tesisleri No:2", FiyatSaat = 1400.0, Telefon = "05321234567", Kapasite = 14, Aciklama = "Kış aylarında sıcak ve konforlu kapalı saha deneyimi." },
                
                new { Id = "f3", OrganizatorId = "o_2", Ad = "Şampiyon Arena A", Sehir = "İstanbul", Ilce = "Kadıköy", Adres = "Şampiyon Kompleksi Spor Sok. No:5", FiyatSaat = 1100.0, Telefon = "05332000002", Kapasite = 14, Aciklama = "Tribünlü ve kaliteli suni çime sahip modern saha." },
                new { Id = "f4", OrganizatorId = "o_2", Ad = "Şampiyon Kapalı B", Sehir = "İstanbul", Ilce = "Kadıköy", Adres = "Şampiyon Kompleksi Spor Sok. No:6", FiyatSaat = 1300.0, Telefon = "05332000002", Kapasite = 14, Aciklama = "Rüzgar ve yağmur geçirmeyen özel çadır korumalı saha." },
                
                new { Id = "f5", OrganizatorId = "o_3", Ad = "Arena Bornova", Sehir = "İzmir", Ilce = "Bornova", Adres = "Bornova Spor Caddesi No:10", FiyatSaat = 1000.0, Telefon = "05342000003", Kapasite = 14, Aciklama = "İzmir'in en gözde, soyunma odaları yenilenmiş harika sahası." },
                new { Id = "f6", OrganizatorId = "o_3", Ad = "Arena Alsancak", Sehir = "İzmir", Ilce = "Konak", Adres = "Alsancak Kordon Boyu No:15", FiyatSaat = 1200.0, Telefon = "05342000003", Kapasite = 14, Aciklama = "Alsancak sahilinde harika manzaralı açık saha." },
                
                new { Id = "f7", OrganizatorId = "o_4", Ad = "Kanal Boyu Açık Saha", Sehir = "Ankara", Ilce = "Çankaya", Adres = "Kanal Boyu Cad. No:24", FiyatSaat = 1500.0, Telefon = "05352000004", Kapasite = 14, Aciklama = "Ankara merkezde, geniş otoparklı modern spor tesisi." },
                new { Id = "f8", OrganizatorId = "o_4", Ad = "Kanal Boyu Çim Saha", Sehir = "Ankara", Ilce = "Çankaya", Adres = "Kanal Boyu Cad. No:25", FiyatSaat = 1700.0, Telefon = "05352000004", Kapasite = 22, Aciklama = "11'e 11 maçlar için ideal doğal çim zemin." },
                
                new { Id = "f9", OrganizatorId = "o_5", Ad = "Kadıköy Yıldız Saha", Sehir = "İstanbul", Ilce = "Kadıköy", Adres = "Kadıköy Sahil Parkı içi", FiyatSaat = 1500.0, Telefon = "05362000005", Kapasite = 14, Aciklama = "Harika deniz manzaralı, kaliteli zemin kaplamalı açık saha." },
                new { Id = "f10", OrganizatorId = "o_5", Ad = "Kadıköy Kapalı Arenası", Sehir = "İstanbul", Ilce = "Kadıköy", Adres = "Kadıköy Sahil Parkı içi", FiyatSaat = 1700.0, Telefon = "05362000005", Kapasite = 14, Aciklama = "Özel aydınlatmalı, havalandırma sistemli kapalı tesis." },
                
                new { Id = "f11", OrganizatorId = "o_6", Ad = "Bornova Olimpik Saha", Sehir = "İzmir", Ilce = "Bornova", Adres = "Bornova Gençlik Parkı Yanı", FiyatSaat = 900.0, Telefon = "05372000006", Kapasite = 14, Aciklama = "Öğrencilere indirimli, cana yakın personeli olan tesis." },
                new { Id = "f12", OrganizatorId = "o_7", Ad = "Çankaya Prestij Arenası", Sehir = "Ankara", Ilce = "Çankaya", Adres = "Tunalı Hilmi Cad. No:120", FiyatSaat = 1800.0, Telefon = "05382000007", Kapasite = 14, Aciklama = "Başkentin merkezinde, lüks kafe alanı ve geniş soyunma odaları." },
                new { Id = "f13", OrganizatorId = "o_8", Ad = "Alsancak Liman Saha", Sehir = "İzmir", Ilce = "Konak", Adres = "Alsancak Kordon Boyu", FiyatSaat = 1200.0, Telefon = "05392000008", Kapasite = 14, Aciklama = "Merkezi konumda, metroya 2 dakika yürüme mesafesinde." },
                new { Id = "f14", OrganizatorId = "o_9", Ad = "Kartal Sahil Parkı Sahası", Sehir = "İstanbul", Ilce = "Kartal", Adres = "Kartal Sahil Yolu No:200", FiyatSaat = 1000.0, Telefon = "05302000009", Kapasite = 14, Aciklama = "Geniş tribünlü ve kafeteryalı lüks açık saha." },
                new { Id = "f15", OrganizatorId = "o_10", Ad = "Beşiktaş Kaptan Arena", Sehir = "İstanbul", Ilce = "Beşiktaş", Adres = "Beşiktaş Barbaros Bulvarı No:80", FiyatSaat = 2000.0, Telefon = "05312000010", Kapasite = 14, Aciklama = "İstanbul'un merkezinde üst seviye hizmet and mükemmel zemin." },
                new { Id = "f16", OrganizatorId = "o_11", Ad = "Bornova Suni Çim Saha", Sehir = "İzmir", Ilce = "Bornova", Adres = "Bornova Gençlik Parkı Yanı No:5", FiyatSaat = 950.0, Telefon = "05322000011", Kapasite = 14, Aciklama = "Esnek zemin yapısı ile diz ve ayak bileği dostu suni çim." },
                new { Id = "f17", OrganizatorId = "o_12", Ad = "Alsancak Çadır Saha", Sehir = "İzmir", Ilce = "Konak", Adres = "Alsancak Kordon Boyu No:7", FiyatSaat = 1350.0, Telefon = "05332000012", Kapasite = 14, Aciklama = "Her mevsimde kesintisiz futbol keyfi sunan kapalı çadır saha." },
                new { Id = "f18", OrganizatorId = "o_13", Ad = "Kartal Kapalı Kompleksi", Sehir = "İstanbul", Ilce = "Kartal", Adres = "Kartal Sahil Yolu No:205", FiyatSaat = 1200.0, Telefon = "05342000013", Kapasite = 14, Aciklama = "Yüksek tavanlı, ferah ve geniş kapalı futbol sahası." },
                new { Id = "f19", OrganizatorId = "o_14", Ad = "Beşiktaş Yıldız Parkı Saha", Sehir = "İstanbul", Ilce = "Beşiktaş", Adres = "Beşiktaş Barbaros Bulvarı No:85", FiyatSaat = 2100.0, Telefon = "05352000014", Kapasite = 14, Aciklama = "Özel çim zeminli, aydınlatmalı premium halı saha." },
                new { Id = "f20", OrganizatorId = "o_15", Ad = "TRCUP", Sehir = "Çanakkale", Ilce = "Merkez", Adres = "Atatürk Cad. No:4", FiyatSaat = 3000.0, Telefon = "05362000015", Kapasite = 20, Aciklama = "Turnuvalar ve özel organizasyonlar için tasarlanmış birinci sınıf saha." }
            };

            foreach (var f in fields)
            {
                using (var cmd = new SQLiteCommand(insertFieldSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", f.Id);
                    cmd.Parameters.AddWithValue("@OrganizatorId", f.OrganizatorId);
                    cmd.Parameters.AddWithValue("@Ad", f.Ad);
                    cmd.Parameters.AddWithValue("@Sehir", f.Sehir);
                    cmd.Parameters.AddWithValue("@Ilce", f.Ilce);
                    cmd.Parameters.AddWithValue("@Adres", f.Adres);
                    cmd.Parameters.AddWithValue("@FiyatSaat", f.FiyatSaat);
                    cmd.Parameters.AddWithValue("@MusaitGunler", Jss.Serialize(tumGunler));
                    cmd.Parameters.AddWithValue("@MusaitSaatler", Jss.Serialize(tumSaatler));
                    cmd.Parameters.AddWithValue("@Aciklama", f.Aciklama);
                    cmd.Parameters.AddWithValue("@EklenmeTarihi", DateTime.Now.ToString("o"));
                    cmd.Parameters.AddWithValue("@Telefon", f.Telefon);
                    cmd.Parameters.AddWithValue("@Kapasite", f.Kapasite);
                    cmd.ExecuteNonQuery();
                }
            }

            string[] fieldNames = {
                "Olimpiyat Merkez Saha", "Olimpiyat Kapalı Saha", "Şampiyon Arena A", "Şampiyon Kapalı B",
                "Arena Bornova", "Arena Alsancak", "Kanal Boyu Açık Saha", "Kanal Boyu Çim Saha",
                "Kadıköy Yıldız Saha", "Kadıköy Kapalı Arenası", "Bornova Olimpik Saha", "Çankaya Prestij Arenası",
                "Alsancak Liman Saha", "Kartal Sahil Parkı Sahası", "Beşiktaş Kaptan Arena", "Bornova Suni Çim Saha",
                "Alsancak Çadır Saha", "Kartal Kapalı Kompleksi", "Beşiktaş Yıldız Parkı Saha", "TRCUP"
            };
            double[] fieldPrices = {
                1200.0, 1400.0, 1100.0, 1300.0, 1000.0, 1200.0, 1500.0, 1700.0,
                1500.0, 1700.0, 900.0, 1800.0, 1200.0, 1000.0, 2000.0, 950.0,
                1350.0, 1200.0, 2100.0, 3000.0
            };

            // Seed Mock Reservations
            string insertResSql = @"INSERT INTO reservations 
                (Id, SahaId, SahaAdi, KullaniciId, MisafirAd, MisafirTelefon, Tarih, Saat, ToplamFiyat, OlusturmaTarihi, KisiSayisi) 
                VALUES (@Id, @SahaId, @SahaAdi, @KullaniciId, @MisafirAd, @MisafirTelefon, @Tarih, @Saat, @ToplamFiyat, @OlusturmaTarihi, @KisiSayisi)";

            // Track booked slots: "SahaId_Tarih(yyyyMMdd)_Saat"
            var bookedSlots = new HashSet<string>();

            // 1. Seed 300 Registered User Reservations
            for (int r = 1; r <= 300; r++)
            {
                int fieldIndex = 0;
                int mod = r % 5;
                if (mod == 0) fieldIndex = 0; // f1 (Olimpiyat Merkez Saha)
                else if (mod == 1) fieldIndex = 1; // f2 (Olimpiyat Kapalı Saha)
                else fieldIndex = 2 + ((r / 5) % 18); // f3 to f20 distributed evenly

                string sahaId = "f" + (fieldIndex + 1);
                string sahaAdi = fieldNames[fieldIndex];
                double fiyat = fieldPrices[fieldIndex];

                // Distribute u_demo using coprime step 13, others to u_2 to u_150
                string kullaniciId = (r % 13 == 0) ? "u_demo" : "u_" + ((r % 149) + 2);

                // Find a free slot deterministically
                DateTime tarih = DateTime.Today;
                string saat = "";
                int baseDateIndex = r % 10;
                int baseHourIndex = r % tumSaatler.Count;

                for (int attempt = 0; attempt < 500; attempt++)
                {
                    int dateOffset = ((baseDateIndex + attempt) % 10) - 5;
                    int hourIndex = (baseHourIndex + (attempt / 10)) % tumSaatler.Count;

                    DateTime dateCandidate = DateTime.Today.AddDays(dateOffset);
                    string saatCandidate = tumSaatler[hourIndex];
                    string key = sahaId + "_" + dateCandidate.ToString("yyyyMMdd") + "_" + saatCandidate;

                    if (!bookedSlots.Contains(key))
                    {
                        bookedSlots.Add(key);
                        tarih = dateCandidate;
                        saat = saatCandidate;
                        break;
                    }
                }

                using (var cmd = new SQLiteCommand(insertResSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", "r_reg_" + r);
                    cmd.Parameters.AddWithValue("@SahaId", sahaId);
                    cmd.Parameters.AddWithValue("@SahaAdi", sahaAdi);
                    cmd.Parameters.AddWithValue("@KullaniciId", kullaniciId);
                    cmd.Parameters.AddWithValue("@MisafirAd", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MisafirTelefon", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Tarih", tarih.ToString("o"));
                    cmd.Parameters.AddWithValue("@Saat", saat);
                    cmd.Parameters.AddWithValue("@ToplamFiyat", fiyat);
                    cmd.Parameters.AddWithValue("@OlusturmaTarihi", DateTime.Now.ToString("o"));
                    cmd.Parameters.AddWithValue("@KisiSayisi", 14);
                    cmd.ExecuteNonQuery();
                }
            }

            // 2. Seed 200 Unregistered Guest Reservations
            for (int g = 1; g <= 200; g++)
            {
                int fieldIndex = 0;
                int mod = g % 5;
                if (mod == 0) fieldIndex = 0; // f1 (Olimpiyat Merkez Saha)
                else if (mod == 1) fieldIndex = 1; // f2 (Olimpiyat Kapalı Saha)
                else fieldIndex = 2 + ((g / 5) % 18); // f3 to f20 distributed evenly

                string sahaId = "f" + (fieldIndex + 1);
                string sahaAdi = fieldNames[fieldIndex];
                double fiyat = fieldPrices[fieldIndex];

                string misafirAd = firstNames[g % firstNames.Length] + " " + lastNames[g % lastNames.Length];
                string misafirTel = "055" + (3000000 + g).ToString();

                // Find a free slot deterministically
                DateTime tarih = DateTime.Today;
                string saat = "";
                int baseDateIndex = g % 10;
                int baseHourIndex = g % tumSaatler.Count;

                for (int attempt = 0; attempt < 500; attempt++)
                {
                    int dateOffset = ((baseDateIndex + attempt) % 10) - 5;
                    int hourIndex = (baseHourIndex + (attempt / 10)) % tumSaatler.Count;

                    DateTime dateCandidate = DateTime.Today.AddDays(dateOffset);
                    string saatCandidate = tumSaatler[hourIndex];
                    string key = sahaId + "_" + dateCandidate.ToString("yyyyMMdd") + "_" + saatCandidate;

                    if (!bookedSlots.Contains(key))
                    {
                        bookedSlots.Add(key);
                        tarih = dateCandidate;
                        saat = saatCandidate;
                        break;
                    }
                }

                using (var cmd = new SQLiteCommand(insertResSql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", "r_gst_" + g);
                    cmd.Parameters.AddWithValue("@SahaId", sahaId);
                    cmd.Parameters.AddWithValue("@SahaAdi", sahaAdi);
                    cmd.Parameters.AddWithValue("@KullaniciId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@MisafirAd", misafirAd);
                    cmd.Parameters.AddWithValue("@MisafirTelefon", misafirTel);
                    cmd.Parameters.AddWithValue("@Tarih", tarih.ToString("o"));
                    cmd.Parameters.AddWithValue("@Saat", saat);
                    cmd.Parameters.AddWithValue("@ToplamFiyat", fiyat);
                    cmd.Parameters.AddWithValue("@OlusturmaTarihi", DateTime.Now.ToString("o"));
                    cmd.Parameters.AddWithValue("@KisiSayisi", 14);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
