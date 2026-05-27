using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Script.Serialization;
using SahalarBurada.Models;

namespace SahalarBurada.Services
{
    public static class DatabaseServisi
    {
        private const string ConnectionString = "Data Source=SahalarBuradaDatabase.db;Version=3;";
        private static readonly JavaScriptSerializer Jss = new JavaScriptSerializer();

        public static void InitializeDatabase()
        {
            using (var conn = new SQLiteConnection(ConnectionString))
            {
                conn.Open();

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
                    KayitTarihi TEXT
                );";
                using (var cmd = new SQLiteCommand(createOrganizers, conn)) cmd.ExecuteNonQuery();

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
                    Telefon TEXT
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
                    OlusturmaTarihi TEXT
                );";
                using (var cmd = new SQLiteCommand(createReservations, conn)) cmd.ExecuteNonQuery();
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
                string sql = "INSERT INTO organizers (Id, IsletmeAdi, Ad, Soyad, Eposta, SifreHash, KayitTarihi) VALUES (@Id, @IsletmeAdi, @Ad, @Soyad, @Eposta, @SifreHash, @KayitTarihi)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", o.Id);
                    cmd.Parameters.AddWithValue("@IsletmeAdi", o.IsletmeAdi);
                    cmd.Parameters.AddWithValue("@Ad", o.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", o.Soyad);
                    cmd.Parameters.AddWithValue("@Eposta", o.Eposta);
                    cmd.Parameters.AddWithValue("@SifreHash", o.SifreHash);
                    cmd.Parameters.AddWithValue("@KayitTarihi", o.KayitTarihi.ToString("o"));
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
                                KayitTarihi = DateTime.Parse(reader["KayitTarihi"].ToString())
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
                    (Id, OrganizatorId, Ad, Sehir, Ilce, Adres, FiyatSaat, MusaitGunler, MusaitSaatler, Aciklama, EklenmeTarihi, Telefon) 
                    VALUES (@Id, @OrganizatorId, @Ad, @Sehir, @Ilce, @Adres, @FiyatSaat, @MusaitGunler, @MusaitSaatler, @Aciklama, @EklenmeTarihi, @Telefon)";
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
                            Telefon = reader["Telefon"] != DBNull.Value ? reader["Telefon"].ToString() : ""
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
                    (Id, SahaId, SahaAdi, KullaniciId, MisafirAd, MisafirTelefon, Tarih, Saat, ToplamFiyat, OlusturmaTarihi) 
                    VALUES (@Id, @SahaId, @SahaAdi, @KullaniciId, @MisafirAd, @MisafirTelefon, @Tarih, @Saat, @ToplamFiyat, @OlusturmaTarihi)";
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
                            OlusturmaTarihi = DateTime.Parse(reader["OlusturmaTarihi"].ToString())
                        };
                        list.Add(r);
                    }
                }
            }
            return list;
        }
    }
}
