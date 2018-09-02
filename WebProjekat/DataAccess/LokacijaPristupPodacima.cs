using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebProjekat.Util;

namespace WebProjekat.DataAccess
{
    public class LokacijaPristupPodacima
    {
        public static List<Lokacija> GetLokacije()
        {
            try
            {
                List<Lokacija> lokacije = new List<Lokacija>();

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT * FROM [dbo].[Lokacija]";

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lokacije.Add(CitajRed.Lokacija(reader));
                        }
                    }
                }
                return lokacije;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Lokacija GetLokacija(int id)
        {
            try
            {
                Lokacija lokacija = new Lokacija();

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT
                            *
                        FROM
                            [dbo].[Lokacija]
                        WHERE
                            [id_lokacija] = @Id
                    ";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lokacija = CitajRed.Lokacija(reader);
                            lokacija.Adresa = AdresaPristupPodacima.GetAdresa((int)reader["id_adresa"]);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                return lokacija;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}