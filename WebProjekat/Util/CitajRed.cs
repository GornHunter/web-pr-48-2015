using Projekat.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebProjekat.Models;

namespace WebProjekat.Util
{
    public class CitajRed
    {
        // Citanje reda iz baze pomocu klase SqlDataReader
        public static Lokacija Lokacija(SqlDataReader reader)
        {
            // Pojednostavljeno kreiranje objekta sa parametrima u C#
            Lokacija lokacija = new Lokacija
            {
                // Set-ovanje svih property-ja u objekat koje izvlacimo iz reader-a
                Id = (int)reader["id_lokacija"],
                X = (decimal)reader["x_koordinata"],
                Y = (decimal)reader["y_koordinata"],

            };
            return lokacija;
        }

        public static Adresa Adresa(SqlDataReader reader)
        {
            Adresa adresa = new Adresa
            {
                Id = (int)reader["id_adresa"],
                Ulica = (string)reader["ulica"],
                Broj = (string)reader["broj"],
                Mesto = (string)reader["mesto"],
                PozivniBroj = (decimal)reader["pozivni_broj"],
            };
            return adresa;
        }

        public static Korisnik Korisnik(SqlDataReader reader)
        {
            Korisnik korisnik = new Korisnik
            {
                Id = (int)reader["id_vozac"],
                KorisnickoIme = (string)reader["korisnicko_ime"],
                Lozinka = (string)reader["lozinka"],
                Ime = (string)reader["ime"],
                Prezime = (string)reader["prezime"],
                JMBG = (decimal)reader["jmbg"],
                Email = (string)reader["email"],
                KontaktTelefon = (string)reader["kontakt_telefon"],
                Pol = (Enums.Pol)((int)reader["pol"])
            };
            return korisnik;
        }

        public static Dispecer Dispecer(SqlDataReader reader)
        {
            Dispecer dispecer = new Dispecer
            {
                Id = (int)reader["id_vozac"],
                KorisnickoIme = (string)reader["korisnicko_ime"],
                Lozinka = (string)reader["lozinka"],
                Ime = (string)reader["ime"],
                Prezime = (string)reader["prezime"],
                JMBG = (decimal)reader["jmbg"],
                Email = (string)reader["email"],
                KontaktTelefon = (string)reader["kontakt_telefon"],
                Pol = (Enums.Pol)((int)reader["pol"])
            };
            return dispecer;
        }

        public static Vozac Vozac(SqlDataReader reader)
        {
            Vozac vozac = new Vozac
            {
                Id = (int)reader["id_vozac"],
                KorisnickoIme = (string)reader["korisnicko_ime"],
                Lozinka = (string)reader["lozinka"],
                Ime = (string)reader["ime"],
                Prezime = (string)reader["prezime"],
                JMBG = (decimal)reader["jmbg"],
                Email = (string)reader["email"],
                KontaktTelefon = (string)reader["kontakt_telefon"],
                Pol = (Enums.Pol)((int)reader["pol"])
            };
            return vozac;
        }

        public static Automobil Automobil(SqlDataReader reader)
        {
            Automobil automobil = new Automobil
            {
                Id = (int)reader["id_automobil"],
                BrojRegistarskeOznake = (string)reader["broj_registarske_oznake"],
                GodisteAutomobila = (int)reader["godiste_automobila"],
                BrojTaksiVozila = (int)reader["broj_taksi_vozila"],
                TipAutomobila = (Enums.TipAutomobila)((int)reader["tip_automobila"])
            };
            return automobil;
        }

        public static Voznja Voznja(SqlDataReader reader)
        {
            Voznja voznja = new Voznja();
            voznja.Id = (int)reader["id_voznja"];
            voznja.DatumIVreme = (DateTime)reader["datum_vreme_porudzbine"];
            voznja.Iznos = (decimal)reader["iznos"];
            voznja.StatusVoznje = (Enums.StatusVoznje)((int)reader["status_voznje"]);
            voznja.ZeljeniTipAutomobila = (Enums.TipAutomobila)((int)reader["zeljeni_tip_automobila"]);
            return voznja;
        }

        public static Komentar Komentar(SqlDataReader reader)
        {
            Komentar komentar = new Komentar();
            komentar.Id = (int)reader["id_komentar"];
            komentar.DatumObjave = (DateTime)reader["datum_objave"];
            komentar.Ocena = (int)reader["ocena"];
            return komentar;
        }
    }
}