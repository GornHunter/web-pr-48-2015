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
    public class AdresaPristupPodacima
    {
        public static Adresa GetAdresa(int id)
        {
            try
            {
                Adresa adresa = new Adresa();

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT
                            *
                        FROM
                            [dbo].[Adresa]
                        WHERE
                            [id_adresa] = @Id
                    ";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            adresa = CitajRed.Adresa(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                return adresa;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
    }
}