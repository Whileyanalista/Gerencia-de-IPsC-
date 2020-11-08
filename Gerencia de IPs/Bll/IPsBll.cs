using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gerencia_de_IPs.Dao;
using Gerencia_de_IPs.GatSat;

namespace Gerencia_de_IPs.Bll
{
    
    public class IPsBll
    {
        IPsDao ipsDao = new IPsDao();
        

        public void salvarIPs(CadIPs cadIPs)
        {
            try
            {
                ipsDao.salvarIPs(cadIPs);

                if (cadIPs.id_ips != 0)
                {
                    System.Windows.Forms.MessageBox.Show("Dados alterados com sucesso : ", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Dados salvos com sucesso : ", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados: " + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }
        }



        public void salvarIPsImp(CadIPsImp cadIPsImp)
        {
            try
            {
                ipsDao.salvarIPsImp(cadIPsImp);

                if (cadIPsImp.id_impressora != 0)
                {
                    System.Windows.Forms.MessageBox.Show("Dados alterados com sucesso : ", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Dados salvos com sucesso : ", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados: " + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }

        }


        public void alterarIPs(CadIPs cadIPs)
        {
            try
            {
                ipsDao.fkIps(cadIPs);
            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados: " + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }

        }

        public void alterarIPsImp(CadIPsImp cadIPsImp)
        {
            try
            {
                ipsDao.fkIpsImp(cadIPsImp);
            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados: " + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }

        }


        public void fkIps(CadIPs cadIPs)
        {
            try
            {
                ipsDao.fkIps(cadIPs);
            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados: " + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }
        }

        public void deletarIPs(CadIPs cadIPs)
        {
            try
            {
                ipsDao.deletarIPs(cadIPs);

                System.Windows.Forms.MessageBox.Show("Dados deletar com sucesso : ", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados:" + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }
        }

        public void deletarIPsImp(CadIPsImp cadIPsImp)
        {
            try
            {
                ipsDao.deletarIPsImp(cadIPsImp);

                System.Windows.Forms.MessageBox.Show("Dados deletar com sucesso : ", "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                System.Windows.Forms.MessageBox.Show("ERRO de conexao com a base de dados:" + erro, "Alerta", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Stop);

                throw erro;
            }
        }

        public DataTable listarIPs()
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable = ipsDao.listarIPs();

                return dataTable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable listarIPsImpr()
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable = ipsDao.listarIPsImpr();

                return dataTable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        
        public DataTable pesquIp(CadIPs cadIPs)
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable = ipsDao.pesquIp(cadIPs);

                return dataTable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable pesquIpImp(CadIPsImp  cadIPsImp)
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable = ipsDao.pesquIpImp(cadIPsImp);

                return dataTable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable pesquPc(CadIPs cadIPs)
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable = ipsDao.pesquPc(cadIPs);

                return dataTable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DataTable pesquTagImp(CadIPsImp cadIPsImp)
        {
            try
            {
                DataTable dataTable = new DataTable();

                dataTable = ipsDao.pesquTagImp(cadIPsImp);

                return dataTable;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
