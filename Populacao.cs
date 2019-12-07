﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmo_genettttico
{
    class Populacao
    {
        public int NumPop;
        public int MaxGeracoes;
        public string TipoMutacao;
        public string TipoCrossover;

        int i;
        int j;
        Random rdn = new Random();

        public void InicializaPopulacao(int N, Individuo[] individuo)
        {

            for (i = 0; i < N; i++)

            {
                individuo[i] = new Individuo();
                individuo[i].genes = rdn.Next(0, 1000);

            }

        }
        public void ValorFuncaoObjetivo(int N, Individuo[] individuo)
        {
            double[] x = new double[N];
            for (i = 0; i < N; i++)
            {
                x[i] = -1 + (3 * individuo[i].genes / 1000);
            }

            for (i = 0; i < N; i++)
            {
                individuo[i].funcao = x[i] * Math.Sin(10 * Math.PI * x[i]) + 1;
            }

        }
        public double Selecao(int N, Individuo[] individuo)
        {
            double soma = 0;
            double rand;
            double aleatorio = rdn.NextDouble();
            double total_parcial = 0;
            int t = 0;
            for (i = 0; i < N; i++)
            {
                soma += individuo[i].aptidao;
            }

            rand = (aleatorio * soma);
            for (i = 0; i < N; i++)
            {
                total_parcial += individuo[i].aptidao;
                if (total_parcial >= rand)
                {
                    break;

                }
                t += 1;
            }
            return individuo[t].genes;
        }

        public double CrossoverIndividuo1(Individuo individuo1, Individuo individuo2)
        {
            return (individuo1.genes + individuo2.genes) / 2;
        }

        public double CrossoverIndividuo2(Individuo individuo1, Individuo individuo2)
        {
            return (Math.Sqrt(individuo1.genes * individuo2.genes));
        }




        public void MutacaoIndividuo1(Individuo individuo)
        {
            double rand = rdn.NextDouble();
            if (rand < 0.05)
            {
                individuo.genes = rdn.Next(0, 1000);
            }

        }

        public void MutacaoIndividuo2(Individuo individuo)
        {
            double rand = rdn.NextDouble();
            if (rand < 0.05)
            {
                if (rand < 0.025)
                {
                    individuo.genes = individuo.genes * 1.004;
                }

                if (rand > 0.025)
                {
                    individuo.genes = individuo.genes * 0.996;
                }

            }
        }




        public void Ordenafuncao(int N, Individuo[] individuo)
        {
            double repos = 0;
            double repos2 = 0;

            for (i = 0; i < N; i++)
            {
                for (j = i + 1; j < N; j++)
                {
                    if (individuo[i].funcao < individuo[j].funcao)
                    {

                        repos = individuo[i].funcao;
                        individuo[i].funcao = individuo[j].funcao;
                        individuo[j].funcao = repos;

                        repos2 = individuo[i].genes;
                        individuo[i].genes = individuo[j].genes;
                        individuo[j].genes = repos2;


                    }

                }
            }


        }



        public void OrdenamentoLinear(int N, Individuo[] individuo)
        {
            for (i = 0; i < N; i++)
            {
                individuo[i].aptidao = -1 + (3 * ((N - i) - 1) / (N - 1));
            }

        }
      



    }
}




    

