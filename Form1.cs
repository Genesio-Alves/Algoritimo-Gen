using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algoritmo_genettttico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            chart1.Series["Series1"].Points.Clear();
                

            Populacao Pop = new Populacao()
            {
                NumPop = int.Parse(txtNumPop.Text),
                MaxGeracoes = int.Parse(txtMaxGer.Text)
            };

            int i;

            Individuo[] IndiInicial = new Individuo[Pop.NumPop];
            Individuo[] IndiIntermediario = new Individuo[2];
            IndiIntermediario[0] = new Individuo();
            IndiIntermediario[1] = new Individuo();
            Individuo[] IndiFinal = new Individuo[Pop.NumPop];
            Estatistica[] Estatic = new Estatistica[Pop.MaxGeracoes];

            for (i = 0; i < Pop.NumPop; i++)
            {
                IndiFinal[i] = new Individuo();
            }

            for (i = 0; i < Pop.MaxGeracoes; i++)
            {
                Estatic[i] = new Estatistica();
            }

            int t = 0;
            int Geracao = 0;
            Pop.InicializaPopulacao(Pop.NumPop, IndiInicial);
            Pop.ValorFuncaoObjetivo(Pop.NumPop, IndiInicial);
            Pop.Ordenafuncao(Pop.NumPop, IndiInicial);
            Pop.OrdenamentoLinear(Pop.NumPop, IndiInicial);

            while (Geracao < Pop.MaxGeracoes)
            {

                while (t < Pop.NumPop)
                {
                    IndiIntermediario[0].genes = Pop.Selecao(Pop.NumPop, IndiInicial);
                    IndiIntermediario[1].genes = Pop.Selecao(Pop.NumPop, IndiInicial);

                    if (radioButton1.Checked)
                        {
                            IndiFinal[t].genes = Pop.CrossoverIndividuo1(IndiIntermediario[0], IndiIntermediario[1]);
                        }

                        if (radioButton2.Checked)
                        {
                                IndiFinal[t].genes = Pop.CrossoverIndividuo2(IndiIntermediario[0], IndiIntermediario[1]);
                            }

                            if (radioButton3.Checked)
                                {
                                    Pop.MutacaoIndividuo1(IndiFinal[t]);
                                }

                                if (radioButton4.Checked)
                                    {
                                        Pop.MutacaoIndividuo2(IndiFinal[t]);
                                    }



                                   
                    t += 1;
                }
               
                Pop.ValorFuncaoObjetivo(Pop.NumPop, IndiFinal);
                Pop.Ordenafuncao(Pop.NumPop, IndiFinal);
                Pop.OrdenamentoLinear(Pop.NumPop, IndiFinal);


                Estatic[Geracao].AptidaoMelhorIndividuo = IndiFinal[0].funcao;
                Estatic[Geracao].MelhorIndividuo = IndiFinal[0].genes;


                Geracao += 1;
                for (i = 0; i < Pop.NumPop; i++)
                {
                    IndiInicial[i].genes = IndiFinal[i].genes;
                    IndiInicial[i].aptidao = IndiFinal[i].aptidao;
                    IndiInicial[i].funcao = IndiFinal[i].funcao;

                }
            }


            for (i=0; i<Pop.MaxGeracoes; i++)
            {
                listBox1.Items.Add(Estatic[i].AptidaoMelhorIndividuo);
            }




            this.chart2.Series["Series1"].Points.Clear();

            for (i = 0; i < Pop.MaxGeracoes; i++)
            {
                this.chart1.Series["Series1"].Points.AddXY(i, Estatic[i].AptidaoMelhorIndividuo);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
