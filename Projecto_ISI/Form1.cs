﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Projecto_ISI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                richTextBox1.Text = sr.ReadToEnd();
                //string texto = richTextBox1.Text;
                segmenta_2();
                sr.Close();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void segmenta_2()
        {
            string texto = richTextBox1.Text;
            string[] linhas = texto.Split(new[] { "�" }, StringSplitOptions.RemoveEmptyEntries);
            string[] campos = texto.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            //string[] digits = Regex.Split(texto, @"\§");

            int numLinhas = 0;
            int numCampos = 0;
            foreach (var linha in linhas) 
            {
                //richTextBox2.Text += "Linha: " + linha + "\n";
                numLinhas++;

                foreach (var campo in campos)
                {
                    numCampos++;
                }
            }

            richTextBox2.Text = "Numero de Linhas: " + numLinhas + "\n" + "Numero de Campos: " + numCampos;

            /*
             * private void button2_Click(object sender, EventArgs e)
            {
                List<Refeicao> refeicoes = new List<Refeicao>();

                string maisrefeicoes = File.ReadAllText(@"C:\Users\Moreira\Documents\ISI\Projecto_ISI\calorias_restaurantes_3.json");

                List<Refeicao> mais_refeicoes = JsonConvert.DeserializeObject<List<Refeicao>>(maisrefeicoes);

                var text_ref = String.Join("\n", mais_refeicoes);
                richTextBox1.Text = text_ref;
            }*/
        }
    }
}
