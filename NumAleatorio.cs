using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloEj1
{
    public class NumAleatorio
    {
        private Random aleatorio; 

        public NumAleatorio()
        {
            aleatorio = new Random(); // Inicializa Random una vez
        }

        public List<Class1> CrearListaOrigen(int NumPanel)
        {
            List<Class1> listaClass1 = new List<Class1>();

            for (int i = 0; i < NumPanel; i++)
            {
                Class1 generador = new Class1
                {
                    Valor = aleatorio.Next(1000, 5000) // Genera valor aleatorio entre 1000 y 5000
                };
                listaClass1.Add(generador);
            }

            return listaClass1;
        }
    }

    public class NumExperimento
    {
        public NumExperimento() { }

        public double SimMC(int idExp, int numPanel)
        {
            NumAleatorio generador = new NumAleatorio();
            List<double> resultados = new List<double>();

            for (int i = 0; i < idExp; i++)
            {
                List<Class1> listaPaneles = generador.CrearListaOrigen(numPanel);
                List<int> tiempos = listaPaneles.Select(p => p.Valor).OrderBy(t => t).ToList();
                int tiempoFallo = tiempos[3];

                resultados.Add(tiempoFallo);
            }

            // Promedio de los tiempos de fallo
            return resultados.Average();
        }
    }
}

