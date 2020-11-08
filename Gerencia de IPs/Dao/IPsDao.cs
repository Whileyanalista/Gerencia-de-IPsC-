using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Gerencia_de_IPs.Dao;
using Gerencia_de_IPs.GatSat;
using System.Data;

namespace Gerencia_de_IPs.Dao
{
    public class IPsDao: Conexao
    {
        SQLiteCommand comando = null;

        CadIPs cadIPs = new CadIPs();

        private void limparVariaves(CadIPs cadIPs)
        {
            cadIPs.id_ips = 0;
            cadIPs.ip = "";
            cadIPs.memoria = "";
            cadIPs.processador = "";
            cadIPs.windos = "";
            cadIPs.ant_viros = "";
        }

        public void salvarIPs(CadIPs cadIPs)
        {
            try
            {
                Abrirconexao();

                if (cadIPs.id_ips != 0)
                {
                    comando = new SQLiteCommand("update cadips set pc = @pc, ip = @ip, memoria = @memoria, processador = @processador, windos = @windos, ant_viros = @ant_viros, tag = @tag where id_ips = @id_ips", conexao);

                    comando.Parameters.AddWithValue("@pc", cadIPs.pc);
                    comando.Parameters.AddWithValue("@ip", cadIPs.ip);
                    comando.Parameters.AddWithValue("@memoria", cadIPs.memoria);
                    comando.Parameters.AddWithValue("@processador", cadIPs.processador);
                    comando.Parameters.AddWithValue("@windos", cadIPs.windos);
                    comando.Parameters.AddWithValue("@ant_viros", cadIPs.ant_viros);
                    comando.Parameters.AddWithValue("@tag", cadIPs.tag);
                    comando.Parameters.AddWithValue("@id_ips", cadIPs.id_ips);
                    

                }
                else if (cadIPs.id_ips == 0)
                {
                    comando = new SQLiteCommand("insert into cadips values( null, @pc, @ip, @memoria, @processador, @windos, @ant_viros, @tag)", conexao);

                    comando.Parameters.AddWithValue("@pc", cadIPs.pc);
                    comando.Parameters.AddWithValue("@ip", cadIPs.ip);
                    comando.Parameters.AddWithValue("@memoria", cadIPs.memoria);
                    comando.Parameters.AddWithValue("@processador", cadIPs.processador);
                    comando.Parameters.AddWithValue("@windos", cadIPs.windos);
                    comando.Parameters.AddWithValue("@ant_viros", cadIPs.ant_viros);
                    comando.Parameters.AddWithValue("@tag", cadIPs.tag);

                   
                }

                comando.ExecuteNonQuery();
                limparVariaves(cadIPs);

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void salvarIPsImp(CadIPsImp cadIPsImp)
        {
            try
            {
                Abrirconexao();

                if (cadIPsImp.id_impressora != 0)
                {
                    comando = new SQLiteCommand("update cadIPsImp set ip_impressora = @ip_impressora, modelo = @modelo, tag = @tag where id_impressora = @id_impressora", conexao);

                    comando.Parameters.AddWithValue("@ip_impressora", cadIPsImp.ip_impressora);
                    comando.Parameters.AddWithValue("@modelo", cadIPsImp.modelo);
                    comando.Parameters.AddWithValue("@tag", cadIPsImp.tag);
                    comando.Parameters.AddWithValue("@id_impressora", cadIPsImp.id_impressora);

                }
                else if (cadIPsImp.id_impressora == 0)
                {
                    comando = new SQLiteCommand("insert into cadIPsImp values( null, @ip_impressora, @modelo, @tag)", conexao);

                    comando.Parameters.AddWithValue("@ip_impressora", cadIPsImp.ip_impressora);
                    comando.Parameters.AddWithValue("@modelo",  cadIPsImp.modelo);
                    comando.Parameters.AddWithValue("@tag", cadIPsImp.tag);
                }

                comando.ExecuteNonQuery();
                limparVariaves(cadIPs);

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public void deletarIPs(CadIPs cadIPs)
        {
            try
            {
                Abrirconexao();

                comando = new SQLiteCommand("delete from cadips where id_ips = @id_ips", conexao);

                comando.Parameters.AddWithValue("@id_ips", cadIPs.id_ips);



                comando.ExecuteNonQuery();
                limparVariaves(cadIPs);

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public void deletarIPsImp(CadIPsImp cadIPsImp)
        {
            try
            {
                Abrirconexao();

                comando = new SQLiteCommand("delete from CadIPsImp where id_impressora = @id_impressora", conexao);

                comando.Parameters.AddWithValue("@id_impressora", cadIPsImp.id_impressora);

                comando.ExecuteNonQuery();
                limparVariaves(cadIPs);

            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public void fkIps(CadIPs cadIPs)
        {
            try
            {
                Abrirconexao();

                comando = new SQLiteCommand("select * from cadips where ip = @ip and pc = @pc", conexao);

                comando.Parameters.AddWithValue("@ip", cadIPs.ip);
                comando.Parameters.AddWithValue("@pc", cadIPs.pc);

                SQLiteDataReader fkIps;

                fkIps = comando.ExecuteReader();

                if (fkIps.Read())
                {
                    cadIPs.id_ips = fkIps.GetInt32(0);
                    fkIps.Close();
                    //System.Windows.Forms.MessageBox.Show("fkIps GERADO" + cadIPs.id_ips);
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public void fkIpsImp(CadIPsImp cadIPsImp)
        {
            try
            {
                Abrirconexao();

                comando = new SQLiteCommand("select * from cadIPsImp where ip_impressora = @ip_impressora and modelo = @modelo and tag = @tag", conexao);

                comando.Parameters.AddWithValue("@ip_impressora", cadIPsImp.ip_impressora);
                comando.Parameters.AddWithValue("@modelo", cadIPsImp.modelo);
                comando.Parameters.AddWithValue("@tag", cadIPsImp.tag);

                SQLiteDataReader fkIpsImp;

                fkIpsImp = comando.ExecuteReader();

                if (fkIpsImp.Read())
                {
                    cadIPsImp.id_impressora = fkIpsImp.GetInt32(0);
                    fkIpsImp.Close();
                    //System.Windows.Forms.MessageBox.Show("fkIps GERADO" + cadIPsImp.id_impressora);
                }
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }

        public DataTable listarIPs()
        {
            try
            {
                Abrirconexao();

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter();
                comando = new SQLiteCommand("select * from cadips ", conexao);

                sQLiteDataAdapter.SelectCommand = comando;
                sQLiteDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public DataTable listarIPsImpr()
        {
            try
            {
                Abrirconexao();

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter();
                comando = new SQLiteCommand("select * from cadIPsImp ", conexao);

                sQLiteDataAdapter.SelectCommand = comando;
                sQLiteDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public DataTable pesquIp (CadIPs cadIPs)
        {
            try
            {
                Abrirconexao();

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter();

                    //PARAMETROS QUE POSSIBILITA O SELECT COM LIKE NO BANCO
                    comando = new SQLiteCommand("select * from cadips WHERE ip LIKE @ip", conexao);
                    comando.Parameters.AddWithValue("@ip",  "%" + cadIPs.ip + "%");
                    sQLiteDataAdapter = new SQLiteDataAdapter(comando);
                    dataTable = new DataTable();
                    sQLiteDataAdapter.Fill(dataTable);                   
                
                return dataTable;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
                     

        }


        public DataTable pesquIpImp(CadIPsImp cadIPsImp)
        {
            try
            {
                Abrirconexao();

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter();

                //PARAMETROS QUE POSSIBILITA O SELECT COM LIKE NO BANCO
                comando = new SQLiteCommand("select * from cadIPsImp WHERE ip_impressora LIKE @ip_impressora", conexao);
                comando.Parameters.AddWithValue("@ip", "%" + cadIPsImp.ip_impressora + "%");
                sQLiteDataAdapter = new SQLiteDataAdapter(comando);
                dataTable = new DataTable();
                sQLiteDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }
        }


        public DataTable pesquPc(CadIPs cadIPs)
        {
            try
            {
                Abrirconexao();

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter();

                //PARAMETROS QUE POSSIBILITA O SELECT COM LIKE NO BANCO
                comando = new SQLiteCommand("select * from cadips WHERE pc LIKE @pc", conexao);
                comando.Parameters.AddWithValue("@pc", "%" + cadIPs.pc + "%");
                sQLiteDataAdapter = new SQLiteDataAdapter(comando);
                dataTable = new DataTable();
                sQLiteDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }


        }


        public DataTable pesquTagImp(CadIPsImp cadIPsImp)
        {
            try
            {
                Abrirconexao();

                DataTable dataTable = new DataTable();
                SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter();

                //PARAMETROS QUE POSSIBILITA O SELECT COM LIKE NO BANCO
                comando = new SQLiteCommand("select * from cadIPsImp WHERE tag LIKE @tag", conexao);
                comando.Parameters.AddWithValue("@pc", "%" + cadIPsImp.tag + "%");
                sQLiteDataAdapter = new SQLiteDataAdapter(comando);
                dataTable = new DataTable();
                sQLiteDataAdapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception erro)
            {

                throw erro;
            }
            finally
            {
                FecharConexao();
            }


        }


    }
}
