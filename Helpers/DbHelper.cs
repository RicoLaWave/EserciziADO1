using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EserciziADO.Helpers
{
    public static class DbHelper
    {
        private static SqlConnection connection;
        private static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = ConfigurationManager.AppSettings.Get("connectionString");
                connection = new SqlConnection(connectionString);
            }
            return connection;
        }

        public static int UpdatePersona(Lavoratore l)
        {
            int result = 0;

            string updateQuery = "UPDATE Lavoratori" +
                "(Nome, Cognome, DataDiNascita, Retribuzione, DataDiAssunzione, Tipo)" +
                " VALUES " +
                "(@Nome, @Cognome, @DataDiNascita, @Retribuzione, @DataDiAssunzione, @Tipo)"+
                "WHERE Id = @Persona_ID";

            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = updateQuery
            };
            return result;
        }
        
        public static void InsertPersona(Lavoratore l)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = GetConnection(),
                CommandType = CommandType.Text,
                CommandText = "INSERT INTO Lavoratori" +
                "(Id, Nome, Cognome, DataDiNascita, Retribuzione, DataDiAssunzione, Tipo)" +
                "VALUES" +
                "(@Id, @Nome, @Cognome, @DataDiNascita, @Retribuzione, @DataDiAssunzione, @Tipo)"
            };
            
            SqlParameter id_parameter = new SqlParameter("@Id", SqlDbType.UniqueIdentifier);
            id_parameter.Value = l.Persona_ID;

            SqlParameter nome_parameter = new SqlParameter("@Nome", SqlDbType.NVarChar, 255);
            nome_parameter.Value = l.Nome;

            //Creo la query;
            //Equivalente al SqlParameter;
            cmd.Parameters.Add(id_parameter);
            cmd.Parameters.Add(nome_parameter);
            cmd.Parameters.Add("@Cognome", SqlDbType.NVarChar, 255).Value = l.Cognome;
            cmd.Parameters.Add("@DataDiNascita", SqlDbType.DateTime).Value = l.DataDiNascita;
            cmd.Parameters.Add("@Retribuzione", SqlDbType.Float).Value = l.Retribuzione;
            cmd.Parameters.Add("@DataDiAssunzione", SqlDbType.DateTime).Value = l.DataDiAssunzione;
            cmd.Parameters.Add("@Tipo", SqlDbType.Int).Value = l.Tipo;

            //Visualizzo le righe che vado ad impattare;
            GetConnection().Open();
            int result = cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            Console.WriteLine("{0} rows affected!", result);
        }
        public static DataSet GetPersone()
        {
            DataSet result = new DataSet();

            string selectQuery = "SELECT Id, Nome, Cognome, DataDiNascita, "+
                                   "Retribuzione, DataDiAssunzione, Tipo FROM Lavoratori";
            SqlCommand cmd = new SqlCommand(selectQuery, GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);

            return result;
        }


    }
}
