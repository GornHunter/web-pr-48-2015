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
    public class KomentarPristupPodacima
    {
        public static Komentar GetKomentar(int id)
        {
            try
            {
                Komentar komentar = new Komentar();
                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = " SELECT * FROM [dbo].[komentar] WHERE [id_komentar] = @Id";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            komentar = CitajRed.Komentar(reader);
                        }
                    }
                }
                return komentar;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}