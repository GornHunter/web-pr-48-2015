using Projekat.Models;
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
    public class VoznjaPristupPodacima
    {

        public static List<Voznja> IzlistajVoznjePoDispeceru(int idDisp)
        {
            try
            {
                List<Voznja> voznje = new List<Voznja>();
                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT
                            *
                        FROM
                            [dbo].[voznja]
                        WHERE
                            [id_dispecer] = @IdDisp
                    ";

                    command.Parameters.Add("@IdDisp", SqlDbType.Int);
                    command.Parameters["@IdDisp"].Value = idDisp;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Voznja voznja = CitajRed.Voznja(reader);
                            voznja.PolaznaLokacija = LokacijaPristupPodacima.GetLokacija((int)reader["polazna_lokacija_id"]);
                            voznja.OdredisnaLokacija = LokacijaPristupPodacima.GetLokacija((int)reader["odredisna_lokacija_id"]);
                            voznja.Vozac = VozacPristupPodacima.GetVozac((int)reader["id_vozac"]);
                            voznja.Komentar = KomentarPristupPodacima.GetKomentar((int)reader["id_komentar"]);

                            voznje.Add(voznja);
                        }
                    }
                }
                return voznje;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static List<Voznja> IzlistajVoznjePoVozacu(int idVozac)
        {
            try
            {
                List<Voznja> voznje = new List<Voznja>();
                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT
                            *
                        FROM
                            [dbo].[voznja]
                        WHERE
                            [id_vozac] = @IdVozac
                    ";

                    command.Parameters.Add("@IdVozac", SqlDbType.Int);
                    command.Parameters["@IdVozac"].Value = idVozac;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Voznja voznja = CitajRed.Voznja(reader);
                            voznja.PolaznaLokacija = LokacijaPristupPodacima.GetLokacija((int)reader["polazna_lokacija_id"]);
                            voznja.OdredisnaLokacija = LokacijaPristupPodacima.GetLokacija((int)reader["odredisna_lokacija_id"]);
                            voznja.Komentar = KomentarPristupPodacima.GetKomentar((int)reader["id_komentar"]);

                            voznje.Add(voznja);
                        }
                    }
                }
                return voznje;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Voznja GetVoznja(int id)
        {
            try
            {
                Voznja voznja = new Voznja();

                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        SELECT
                            *
                        FROM
                            [dbo].[voznja]
                        WHERE
                            [id_voznja] = @Id
                    ";

                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["@Id"].Value = id;
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            voznja = CitajRed.Voznja(reader);
                            voznja.PolaznaLokacija = LokacijaPristupPodacima.GetLokacija((int)reader["polazna_lokacija_id"]);
                            voznja.OdredisnaLokacija = LokacijaPristupPodacima.GetLokacija((int)reader["odredisna_lokacija_id"]);
                            voznja.Vozac = VozacPristupPodacima.GetVozac((int)reader["id_vozac"]);
                            voznja.Dispecer = Dispeceri.GetDispecer((int)reader["id_dispecer"]);
                            voznja.Komentar = KomentarPristupPodacima.GetKomentar((int)reader["id_komentar"]);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }

                return voznja;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Voznja KreirajVoznju(Voznja voznja)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = @"
                        INSERT INTO [dbo].[Voznja] 
                         (
                            [datum_vreme_porudzbine],
                            [polazna_lokacija_id],
                            [zeljeni_tip_automobila],
                            [odredisna_lokacija_id],
                            [id_dispecer],
                            [id_vozac],
                            [status_voznje],
                            [iznos]
                                          
                        )
                        VALUES
                        (
                            GETDATE(),
                            @PolaznaLokacijaId,
                            @TipAutomobila,
                            @OdredisnaLokacijaId,
                            @IdDispecer,
                            @IdVozac,
                            @StatusVoznje,
                            @Iznos
                        )
                    ";

                    command.Parameters.Add("@PolaznaLokacijaId", SqlDbType.Int);
                    command.Parameters["@PolaznaLokacijaId"].Value = voznja.PolaznaLokacija.Id;

                    command.Parameters.Add("@TipAutomobila", SqlDbType.Int);
                    command.Parameters["@TipAutomobila"].Value = (int)voznja.ZeljeniTipAutomobila;

                    command.Parameters.Add("@OdredisnaLokacijaId", SqlDbType.Int);
                    command.Parameters["@OdredisnaLokacijaId"].Value = voznja.OdredisnaLokacija.Id;

                    command.Parameters.Add("@IdDispecer", SqlDbType.Int);
                    command.Parameters["@IdDispecer"].Value = voznja.Dispecer.Id;

                    command.Parameters.Add("@IdVozac", SqlDbType.Int);
                    command.Parameters["@IdVozac"].Value = voznja.Vozac.Id;

                    command.Parameters.Add("@StatusVoznje", SqlDbType.Int);
                    command.Parameters["@StatusVoznje"].Value = 0;

                    command.Parameters.Add("@Iznos", SqlDbType.Decimal);
                    command.Parameters["@Iznos"].Value = voznja.Iznos;

                    connection.Open();
                    command.ExecuteNonQuery();                 
                }
                return voznja;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Voznja AzurirajLokacijuVoznje(Voznja voznja, int id)
        {
            using (SqlConnection connection = new SqlConnection(KonekcijaNaBazu.Konekcija))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                        UPDATE
                            [dbo].[voznja]
                        SET
                            [status_voznje] = @StatusVoznje,
                            [komentar] = @Komentar
                        WHERE
                            [id_voznja] = @Id
                    ";

                command.Parameters.Add("@StatusVoznje", SqlDbType.Int);
                command.Parameters["@StatusVoznje"].Value = (int)voznja.StatusVoznje;

                command.Parameters.Add("@Komentar", SqlDbType.VarChar);
                command.Parameters["@Komentar"].Value = voznja.Komentar.Id;

                connection.Open();
                command.ExecuteNonQuery();

                return GetVoznja(id);
            }
        }
    }
}