using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EserciziADO.Helpers;

namespace EserciziADO
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDb();
            DataSet ds = DbHelper.GetPersone();
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
            }
            Console.ReadLine();

            ds = DbHelper.GetPersone();
            Console.WriteLine("Estrazione dopo l'update");
            //PrintDataSet(ds);
        }

        private static void InitDb()
        {
            List<Lavoratore> listaL = new List<Lavoratore>
            {
                new Lavoratore
                {
                    Nome = "Roberto",
                    Cognome = "Spagliccia",
                    DataDiNascita = new DateTime(1983, 7, 3),
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(2014, 3, 17),
                    Retribuzione = 3500
                },
                 new Lavoratore
                {
                    Nome = "Federico",
                    Cognome = "Sacco",
                    DataDiNascita = new DateTime(2000, 11, 16),
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(2019, 11, 8),
                    Retribuzione = 1500
                },
                  new Lavoratore
                {
                    Nome = "Daniele",
                    Cognome = "Pittau",
                    DataDiNascita = new DateTime(1996, 8, 11),
                    Tipo = TipoLavoratore.Dipendente,
                    DataDiAssunzione = new DateTime(2018, 6, 17),
                    Retribuzione = 500
                },
            };
            foreach (var l in listaL)
            {
                DbHelper.InsertPersona(l);
            }

            Guid guid = new Guid("354bbfce-9933-4bff-99dd-0afd96ebe708");

            Lavoratore lav = new Lavoratore
            {
                Persona_ID = guid,
                Nome = "Roberto",
                Cognome = "Baggio",
                DataDiNascita = new DateTime(1983, 7, 3),
                Tipo = TipoLavoratore.Dipendente,
                DataDiAssunzione = new DateTime(2014, 5, 6),
                Retribuzione = 3500000000
            };
            DbHelper.UpdatePersona(lav);

           
            
    }
        
    }
}
