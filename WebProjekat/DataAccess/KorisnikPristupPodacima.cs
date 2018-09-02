using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebProjekat.Models;
using WebProjekat.Util;

namespace WebProjekat.DataAccess
{
    public class KorisnikPristupPodacima
    {
        public static Korisnik GetKorisnik(int id)
        {
            try
            {
                Korisnik korisnik = new Korisnik();

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM [dbo].[korisnik] WHERE [id] = @Id";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            korisnik = CitajRed.Korisnik(reader);

                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                return korisnik;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        public static Korisnik AzurirajKorisnika(Korisnik korisnik, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE
                            [dbo].[korisnik]
                        SET
                            [korisnicko_ime] = @KorisnickoIme,
                            [lozinka] = @Lozinka,
                            [ime] = @Ime,
                            [email] = @Email,
                            [prezime] = @Prezime,
                            [jmbg] = @Jmbg,
                            [kontakt_telefon] = @KontaktTelefon,                 
                            [pol] = @Pol,
                            [uloga] = @Uloga
                        WHERE
                            [id_korisnik] = @Id
                    ";
                    command.Parameters.Add("@KorisnickoIme", SqlDbType.VarChar);
                    command.Parameters["@KorisnickoIme"].Value = korisnik.KorisnickoIme;

                    command.Parameters.Add("@Lozinka", SqlDbType.VarChar);
                    command.Parameters["@Lozinka"].Value = korisnik.Lozinka;

                    command.Parameters.Add("@Ime", SqlDbType.VarChar);
                    command.Parameters["@Ime"].Value = korisnik.Ime;

                    command.Parameters.Add("@Email", SqlDbType.VarChar);
                    command.Parameters["@Email"].Value = korisnik.Email;

                    command.Parameters.Add("@Prezime", SqlDbType.VarChar);
                    command.Parameters["@Prezime"].Value = korisnik.Prezime;

                    command.Parameters.Add("@Jmbg", SqlDbType.Int);
                    command.Parameters["@Jmbg"].Value = korisnik.JMBG;

                    command.Parameters.Add("@KontaktTelefon", SqlDbType.VarChar);
                    command.Parameters["@KontaktTelefon"].Value = korisnik.KontaktTelefon;

                    command.Parameters.Add("@Pol", SqlDbType.VarChar);
                    command.Parameters["@Pol"].Value = korisnik.Pol;

                    if (korisnik.Lozinka == "")
                    {
                        return null;
                    }
                    connection.Open();
                    command.ExecuteNonQuery();

                    return GetKorisnik(id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}