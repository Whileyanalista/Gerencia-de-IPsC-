using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gerencia_de_IPs.GatSat;
using Gerencia_de_IPs.Bll;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Management;
using System.Threading;
using System.Net.NetworkInformation;

namespace Gerencia_de_IPs
{
    public partial class FormTelaPrincipal : Form
    {
        public FormTelaPrincipal()
        {
            InitializeComponent();

            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Ociosa";
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        CadIPs cadIPs = new CadIPs();
        CadIPsImp cadIPsImp = new CadIPsImp();
        IPsBll ipsBll = new IPsBll();

        private void limparCampos()
        {
           textBoxPC.Text = "";
           textBoxIP.Text = "";
           textBoxMemoria.Text = "";
           textBoxProcessador.Text = "";
           textBoxWin.Text = "";
           textBoxAntVirus.Text = "";
           textBoxTAG.Text = "";

        }

        private void salvarIPs(CadIPs cadIPs)
        {
            cadIPs.pc = textBoxPC.Text;
            cadIPs.ip = textBoxIP.Text;
            cadIPs.memoria = textBoxMemoria.Text;
            cadIPs.processador = textBoxProcessador.Text;
            cadIPs.windos = textBoxWin.Text;
            cadIPs.ant_viros = textBoxAntVirus.Text;
            cadIPs.tag = Convert.ToInt32(textBoxTAG.Text);

            ipsBll.salvarIPs(cadIPs);
        }

        private void salvarIPsImp(CadIPsImp cadIPsImp)
        {
            cadIPsImp.ip_impressora = textBoxIpImp.Text;
            cadIPsImp.modelo = textBoxMoImp.Text;           
            cadIPsImp.tag = Convert.ToInt32(textBoxTagImp.Text);

            ipsBll.salvarIPsImp(cadIPsImp);
        }


        private void alterarIPs(CadIPs cadIPs)
        {
            cadIPs.pc = textBoxPC.Text;
            cadIPs.ip = textBoxIP.Text;
            cadIPs.memoria = textBoxMemoria.Text;
            cadIPs.processador = textBoxProcessador.Text;
            cadIPs.windos = textBoxWin.Text;
            cadIPs.ant_viros = textBoxAntVirus.Text;
            cadIPs.tag = Convert.ToInt32(textBoxTAG.Text);

            ipsBll.alterarIPs(cadIPs);
        }

        private void alterarIPsImp(CadIPsImp cadIPsImp)
        {
            cadIPsImp.ip_impressora = textBoxIpImp.Text;
            cadIPsImp.modelo = textBoxMoImp.Text;
            cadIPsImp.tag = Convert.ToInt32(textBoxTagImp.Text);

            ipsBll.alterarIPsImp(cadIPsImp);
        }

        private void deletarIPs(CadIPs cadIPs)
        {
            ipsBll.deletarIPs(cadIPs);
            listarIPs();
        }

        private void deletarIPsImp(CadIPsImp cadIPsImp)
        {
            ipsBll.deletarIPsImp(cadIPsImp);
            listarIPsImpr();
        }

        private void pesquIp(CadIPs cadIPs)
        {
            dataGridViewListaCadIPs.DataSource = ipsBll.pesquIp(cadIPs);
            cadIPs.ip = textBoxIP.Text;
        }

        private void pesquPc(CadIPs cadIPs)
        {
            dataGridViewListaCadIPs.DataSource = ipsBll.pesquPc(cadIPs);

            cadIPs.pc = textBoxPC.Text;
        }



        private void listarIPs()
        {
            dataGridViewListaCadIPs.DataSource = ipsBll.listarIPs();

            dataGridViewListaCadIPs.Columns["id_ips"].Visible = false;

            dataGridViewListaCadIPs.Columns["pc"].HeaderText = "NOME";
            dataGridViewListaCadIPs.Columns["ip"].HeaderText = "IP";
            dataGridViewListaCadIPs.Columns["memoria"].HeaderText = "MEMORIA";
            dataGridViewListaCadIPs.Columns["processador"].HeaderText = "PROCESSAROD";
            dataGridViewListaCadIPs.Columns["windos"].HeaderText = "WINDOS";
            dataGridViewListaCadIPs.Columns["ant_viros"].HeaderText = "ANTIVIROS";
            dataGridViewListaCadIPs.Columns["tag"].HeaderText = "TAGE";            
            
            dataGridViewListaCadIPs.Columns["tag"].Width = 100;

            //DESIGNE DO TITULO
            dataGridViewListaCadIPs.EnableHeadersVisualStyles = false;
            dataGridViewListaCadIPs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewListaCadIPs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 63, 130);
            dataGridViewListaCadIPs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //PARAMETROS PARA DESIGN DA TABELA           
            dataGridViewListaCadIPs.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewListaCadIPs.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//COR DOS CAMPOS 
            //dataGridViewListaCadIPs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;//LINHAS VERTICAS
            dataGridViewListaCadIPs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(211, 231, 145);//COR DE SELEÇAO 
            dataGridViewListaCadIPs.DefaultCellStyle.SelectionForeColor = Color.Black;// COR DO CAMPO AO SELECIONAR
            dataGridViewListaCadIPs.BackgroundColor = Color.White;//COR DA TABELA VASIA

        }

        private void listarIPsImpr()
        {
            dataGridViewListaCadIPsImp.DataSource = ipsBll.listarIPsImpr();

            dataGridViewListaCadIPsImp.Columns["id_impressora"].Visible = false;

            dataGridViewListaCadIPsImp.Columns["ip_impressora"].HeaderText = "IP";
            dataGridViewListaCadIPsImp.Columns["modelo"].HeaderText = "MODELO";
            dataGridViewListaCadIPsImp.Columns["tag"].HeaderText = "TAGE";

            dataGridViewListaCadIPsImp.Columns["tag"].Width = 70;

            //DESIGNE DO TITULO
            dataGridViewListaCadIPsImp.EnableHeadersVisualStyles = false;
            dataGridViewListaCadIPsImp.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewListaCadIPsImp.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(22, 63, 130);
            dataGridViewListaCadIPsImp.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            //PARAMETROS PARA DESIGN DA TABELA           
            dataGridViewListaCadIPsImp.BorderStyle = BorderStyle.FixedSingle;
            dataGridViewListaCadIPsImp.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);//COR DOS CAMPOS 
            //dataGridViewListaCadIPsImp.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;//LINHAS VERTICAS
            dataGridViewListaCadIPsImp.DefaultCellStyle.SelectionBackColor = Color.FromArgb(211, 231, 145);//COR DE SELEÇAO 
            dataGridViewListaCadIPsImp.DefaultCellStyle.SelectionForeColor = Color.Black;// COR DO CAMPO AO SELECIONAR
            dataGridViewListaCadIPsImp.BackgroundColor = Color.White;//COR DA TABELA VASIA
        }

        private void dataGridViewListaCadIPs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewListaCadIPs.CurrentRow != null)
            {
                textBoxPC.Text = dataGridViewListaCadIPs.CurrentRow.Cells[1].Value.ToString();
                textBoxIP.Text = dataGridViewListaCadIPs.CurrentRow.Cells[2].Value.ToString();
                textBoxMemoria.Text = dataGridViewListaCadIPs.CurrentRow.Cells[3].Value.ToString();
                textBoxProcessador.Text = dataGridViewListaCadIPs.CurrentRow.Cells[4].Value.ToString();
                textBoxWin.Text = dataGridViewListaCadIPs.CurrentRow.Cells[5].Value.ToString();
                textBoxAntVirus.Text = dataGridViewListaCadIPs.CurrentRow.Cells[6].Value.ToString();
                textBoxTAG.Text = dataGridViewListaCadIPs.CurrentRow.Cells[7].Value.ToString();

                alterarIPs(cadIPs);
            }
            else
            {
                MessageBox.Show("NAO A DADOS", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarIPs();
            }
        }

        private void dataGridViewListaCadIPsImp_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewListaCadIPsImp.CurrentRow != null)
            {
                textBoxIpImp.Text = dataGridViewListaCadIPsImp.CurrentRow.Cells[1].Value.ToString();
                textBoxMoImp.Text = dataGridViewListaCadIPsImp.CurrentRow.Cells[2].Value.ToString();
                textBoxTagImp.Text = dataGridViewListaCadIPsImp.CurrentRow.Cells[3].Value.ToString();               

                alterarIPsImp(cadIPsImp);
            }
            else
            {
                MessageBox.Show("NAO A DADOS", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarIPs();
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if(textBoxPC.Text == "")
            {
                labelPC.ForeColor = Color.Red;
                textBoxPC.Focus();
            }
            else if (textBoxIP.Text == "")
            {
                labelIP.ForeColor = Color.Red;
                textBoxIP.Focus();
            }
            else if (textBoxMemoria.Text == "")
            {
                labelMemoria.ForeColor = Color.Red;
                textBoxMemoria.Focus();
            }
            else if (textBoxProcessador.Text == "")
            {
                labelProcessador.ForeColor = Color.Red;
                textBoxProcessador.Focus();
            }
            else if (textBoxWin.Text == "")
            {
                labelWin.ForeColor = Color.Red;
                textBoxWin.Focus();
            }
            else if (textBoxAntVirus.Text == "")
            {
                labelAntVirus.ForeColor = Color.Red;
                textBoxAntVirus.Focus();
            }
            else if (textBoxTAG.Text == "")
            {
                labelTAG.ForeColor = Color.Red;
                textBoxTAG.Focus();
            }
            else
            {
                if (cadIPs.id_ips == 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Gostaria de cadastrar estes dados", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        salvarIPs(cadIPs);
                        listarIPs();
                        limparCampos();
                    }
                }
                else if (DialogResult.Yes == MessageBox.Show("Gostaria de alterar estes dados", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    salvarIPs(cadIPs);
                    listarIPs();
                    limparCampos();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Gostaria de deletar estes dados", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                deletarIPs(cadIPs);
                listarIPs();
                limparCampos();
            }
            
        }

        private void FormTelaPrincipal_Load(object sender, EventArgs e)
        {
            listarIPs();
            listarIPsImpr();
        }

        Thread myThread = null;

        public void scan(string subnet)
        {
            Ping myPing;
            PingReply reply;
            IPAddress addr;
            IPHostEntry host;

            progressBar1.Maximum = 254;
            progressBar1.Value = 0;
            listVAddr.Items.Clear();
            

            for (int i = 1; i < 255; i++)
            {                
                string subnetn = "." + i.ToString();

                myPing = new Ping();
                reply = myPing.Send(subnet + subnetn, 900);

                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Scaniando:" + subnet + subnetn;                

                if (reply.Status == IPStatus.Success)
                {
                    try
                    {
                        addr = IPAddress.Parse(subnet + subnetn);
                        host = Dns.GetHostEntry(addr);

                        listVAddr.Items.Add(new ListViewItem(new String[] { subnet + subnetn, host.HostName, "OK" }));

                        for (int F = 0; F < dataGridViewListaCadIPs.Rows.Count; F++)
                        {
                            if (dataGridViewListaCadIPs.Rows[F].Cells[2].Value.ToString() != addr.ToString())
                            {
                                dataGridViewListaCadIPs.Rows[F].Cells[2].Style.ForeColor = Color.Red;

                            }
                        }
                    }
                    catch
                    {

                    }
                }
                progressBar1.Value += 1;
            }
            cmdScan.Enabled = true;
            cmdStop.Enabled = false;
            txtIP.Enabled = true;
            lblStatus.Text = "Completo!";
            int count = listVAddr.Items.Count;

            MessageBox.Show("Scaneamento concluída!\nFound " + count.ToString() + " hosts.", "Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cmdScan_Click(object sender, EventArgs e)
        {
            if (txtIP.Text == "" || txtIP.Text == "3 dig. Ex:10.0.0...")
            {
                txtIP.ForeColor = Color.Red;
                txtIP.Focus();
                MessageBox.Show("favor Preencha o campo de iP", "Informaçao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtIP.Text == string.Empty)
                {
                    MessageBox.Show("Nenhum endereço IP Digitado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    myThread = new Thread(() => scan(txtIP.Text));
                    myThread.Start();                    

                    if (myThread.IsAlive == true)
                    {
                        cmdStop.Enabled = true;
                        cmdScan.Enabled = false;
                        txtIP.Enabled = false;
                    }
                }
            }            
        }

        

        private void cmdStop_Click(object sender, EventArgs e)
        {
            myThread.Suspend();
            cmdScan.Enabled = true;
            cmdStop.Enabled = false;
            txtIP.Enabled = true;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            lblStatus.Text = "Ociosa";
        }

        private void txtIP_Leave(object sender, EventArgs e)
        {
            //INFORMAÇOES PARA O USUARIO 
            if (txtIP.Text == "")
            {
                txtIP.Text = "3 dig. Ex:10.0.0...";
                txtIP.ForeColor = Color.Black;
            }
        }

        private void txtIP_Click(object sender, EventArgs e)
        {
            //INFORMAÇOES PARA O USUARIO 
            if (txtIP.Text == "3 dig. Ex:10.0.0...")
            {
                txtIP.Clear();
                txtIP.ForeColor = Color.Black;
            }
        }
        
        private void textBoxIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            pesquIp(cadIPs);
        }

        private void textBoxIP_TextChanged(object sender, EventArgs e)
        {
            pesquIp(cadIPs);
        }

        private void textBoxIP_KeyUp(object sender, KeyEventArgs e)
        {
            pesquIp(cadIPs);
        }

        private void textBoxPC_TextChanged(object sender, EventArgs e)
        {
            pesquPc(cadIPs);
        }

        private void textBoxPC_KeyUp(object sender, KeyEventArgs e)
        {
            pesquPc(cadIPs);
        }

        private void textBoxPC_KeyPress(object sender, KeyPressEventArgs e)
        {
            pesquPc(cadIPs);
        }

        private void textBoxIpImp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxIpImp_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBoxIpImp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxHnImp_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHnImp_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBoxHnImp_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBoxIpImp.Text == "")
            {
                labeltextIpImpr.ForeColor = Color.Red;
                textBoxIpImp.Focus();
            }
            else if (textBoxMoImp.Text == "")
            {
                labeltextHnImp.ForeColor = Color.Red;
                textBoxMoImp.Focus();
            }
            else
            {
                if (cadIPsImp.id_impressora == 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Gostaria de cadastrar estes dados", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        salvarIPsImp(cadIPsImp);
                        listarIPsImpr();
                    }
                }
                else if (DialogResult.Yes == MessageBox.Show("Gostaria de alterar estes dados", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    salvarIPsImp(cadIPsImp);
                    listarIPsImpr();
                }
            }           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            deletarIPsImp(cadIPsImp);
        }
        
    }
}
