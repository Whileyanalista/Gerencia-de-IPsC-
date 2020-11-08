using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Gerencia_de_IPs.Dao
{
    public class Conexao
    {
        string conectar = "Data Source = C:\\Systema_IPs\\Systemas_Dados.s3db";
        protected SQLiteConnection conexao = null;

        public void Abrirconexao()
        {
            try
            {
                conexao = new SQLiteConnection(conectar);
                conexao.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void FecharConexao()
        {
            try
            {
                conexao = new SQLiteConnection(conectar);
                conexao.Clone();
            }
            catch (Exception erro)
            {

                throw erro;
            }            
        }

        public void CriarBaseDados()
        {
            this.Abrirconexao();

            try
            {
                String comando = "CREATE TABLE [cadips] (" +
                    "[id_ips] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "[pc] VARCHAR(20)  NULL," +
                    "[ip] VARCHAR(20)  NULL," +
                    "[memoria] VARCHAR(20)  NULL," +
                    "[processador] VARCHAR(20)  NULL," +
                    "[windos] VARCHAR(30)  NULL," +
                    "[ant_viros] VARCHAR(30)  NULL," +
                    "[tag] INTEGER NULL" +
                    ");" +

                    "CREATE TABLE [CadIPsImp] (" +
                    "[id_impressora] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                    "[ip_impressora] VARCHAR(20)  NULL," +
                    "[modelo] VARCHAR(40)  NULL," +
                    "[tag] INTEGER NULL" +
                    ");"; 


                SQLiteCommand sQLiteCommand = new SQLiteCommand(comando, conexao);

                int erro = sQLiteCommand.ExecuteNonQuery();

                if(erro > 0)
                {

                }
            }
            catch (Exception error)
            {
               
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
