using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerencia_de_IPs.Dao;

namespace Gerencia_de_IPs
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Directory.Exists("C:\\Systema_IPs") == false)
            {
                Directory.CreateDirectory("C:\\Systema_IPs");
            }
            if (File.Exists("C:\\Systema_IPs\\Systemas_Dados.s3db") == false)
            {
                new Conexao().CriarBaseDados();
                System.Windows.Forms.MessageBox.Show("       BASE DE DADOS CRIADO Systemas_Dados.s3db");

            }
            if (File.Exists("C:\\Systema_IPs\\Systemas_Dados.s3db") == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormTelaPrincipal());
            }
                
        }
    }
}
