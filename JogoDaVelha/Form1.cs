using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form1 : Form
    {
        //Criar array para saber qual setor está vazio
        bool[] vazio = { true, true, true, true, true, true, true, true, true, true };
        byte[] tipo = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            
        }

        private void picSetor1_Click(object sender, EventArgs e)
        {
            preencher(1, picSetor1);
        }

        private void picSetor2_Click(object sender, EventArgs e)
        {
            preencher(2, picSetor2);
        }

        private void picSetor3_Click(object sender, EventArgs e)
        {
            preencher(3, picSetor3);
        }

        private void picSetor4_Click(object sender, EventArgs e)
        {
            preencher(4, picSetor4);
        }

        private void picSetor5_Click(object sender, EventArgs e)
        {
            preencher(5, picSetor5);
        }

        private void picSetor6_Click(object sender, EventArgs e)
        {
            preencher(6, picSetor6);
        }

        private void picSetor7_Click(object sender, EventArgs e)
        {
            preencher(7, picSetor7);
        }

        private void picSetor8_Click(object sender, EventArgs e)
        {
            preencher(8, picSetor8);
        }

        private void picSetor9_Click(object sender, EventArgs e)
        {
            preencher(9, picSetor9);
        }

        private void preencher(int setor, PictureBox imagem)
        {
            if (vazio[setor])
            {
                vazio[setor] = false;

                if (lblJogador.Text == "Jogador 1 - X")
                {
                    imagem.Image = Properties.Resources.xis;
                    //Acessa a imagem adicionada no Resource
                    tipo[setor] = 1;
                    checkVencedor();
                    lblJogador.Text = "Jogador 2 - O";
                    lblJogador.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    imagem.Image = Properties.Resources.bola;
                    //Acessa a imagem adicionada no Resource
                    tipo[setor] = 2;
                    checkVencedor();
                    lblJogador.Text = "Jogador 1 - X";
                    lblJogador.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void checkVencedor()
        {
            string[] conjuntos = {
            tipo[1].ToString() + tipo[2].ToString() + tipo[3].ToString(),
            tipo[4].ToString() + tipo[5].ToString() + tipo[6].ToString(),
            tipo[7].ToString() + tipo[8].ToString() + tipo[9].ToString(),
            tipo[1].ToString() + tipo[4].ToString() + tipo[7].ToString(),
            tipo[2].ToString() + tipo[5].ToString() + tipo[8].ToString(),
            tipo[3].ToString() + tipo[6].ToString() + tipo[9].ToString(),
            tipo[1].ToString() + tipo[5].ToString() + tipo[9].ToString(),
            tipo[3].ToString() + tipo[5].ToString() + tipo[7].ToString()
            };

            for (int i = 0; i < conjuntos.Length; i++)
            {
                if (conjuntos[i] == "111")
                {
                    txtPlacar1.Text = (Int16.Parse(txtPlacar1.Text) + 1).ToString();
                    MessageBox.Show("Parabéns! O Jogador 1 venceu essa!", "Vencedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetarSetores();
                }

                if (conjuntos[i] == "222")
                {
                    txtPlacar2.Text = (Int16.Parse(txtPlacar2.Text) + 1).ToString();
                    MessageBox.Show("Parabéns! O Jogador 2 venceu essa!", "Vencedor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetarSetores();
                }
            }
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            resetarSetores();
        }

        private void resetarSetores()
        {
            picSetor1.Image = null;
            picSetor2.Image = null;
            picSetor3.Image = null;
            picSetor4.Image = null;
            picSetor5.Image = null;
            picSetor6.Image = null;
            picSetor7.Image = null;
            picSetor8.Image = null;
            picSetor9.Image = null;

            for (int i = 0; i < vazio.Length; i++)
            {
                vazio[i] = true;
                tipo[i] = 0;
            }
        }

        private void btnResetarPLacar_Click(object sender, EventArgs e)
        {
            var msg = MessageBox.Show("Quer reiniciar o placar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //Retorna DialogResult.No se o usuário pressionou "não" ou DialogResult.Yes para "sim"

            if (msg == DialogResult.Yes)
            {
                txtPlacar1.Text = "0";
                txtPlacar2.Text = "0";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var escolha = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (escolha == DialogResult.No)
            {
                e.Cancel = true;
            }
            
        }

        private void lblCreditos_Click(object sender, EventArgs e)
        {
            AboutBox1 sobre = new AboutBox1();
            sobre.ShowDialog();
            //O ShowDialog() mostra e mantém a janela sobre as outras
            //até que seja pressionado o botão OK ou fechar
        }
    }
}
