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
    public class VozacPristupPodacima
    {

        public static Vozac GetVozac(int id)
        {
            try
            {
                Vozac vozac = new Vozac();

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText ="SELECT * FROM [dbo].[Vozac] WHERE [id_vozac] = @Id";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            vozac = CitajRed.Vozac(reader);
                            vozac.Lokacija = LokacijaPristupPodacima.GetLokacija((int)reader["trenutna_lokacija"]);

                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                return vozac;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        
        public static Lokacija AzurirajLokaciju(Lokacija lokacija, int id)
        {
            try
            {
                List<Lokacija> lokacije = LokacijaPristupPodacima.GetLokacije();
                bool locationExists = false;
                foreach(Lokacija l in lokacije)
                {
                    if(l.Id == lokacija.Id)
                    {
                        locationExists = true;
                        break;
                    }
                }
                if (!locationExists)
                    return null;

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {

                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        UPDATE
                            [dbo].[Vozac]
                        SET
                            [trenutna_lokacija] = @LokacijaId
                        WHERE
                            [id_vozac] = @Id
                    ";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;

                    command.Parameters.Add("@LokacijaId", SqlDbType.Int);
                    command.Parameters["@LokacijaId"].Value = lokacija.Id;
                    connection.Open();
                    command.ExecuteNonQuery();

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