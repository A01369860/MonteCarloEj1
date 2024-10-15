using System;
using System.Collections.Generic;

namespace MonteCarloEj1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // paso 0: Condicion de vacio
            if (textBox1.Text.Equals("") ||
                textBox2.Text.Equals("") )
            {
                MessageBox.Show("Los números tienen que ser MAYOR que cero, NO VACÍOS.");
                return;
            }

            // Paso 1: Inicializacion de parametros
            int IdExp = Convert.ToInt32(textBox1.Text);
            int NumPanel = Convert.ToInt32(textBox2.Text);

            // Paso 2: Llamar algoritmo
            NumExperimento generador1 = new NumExperimento();

            // Paso 3
            double vidaUtilEsperada = generador1.SimMC(IdExp, NumPanel);

            // Mostrar el resultado en el formulario
            MessageBox.Show($"La vida útil esperada del satélite es: {vidaUtilEsperada:F2} horas");
        }

        public void llenarGrid(List<Class1> lista)
        {
            // Llenar el DataGridView con los resultados de cada experimento
            foreach (var resultado in resultado)
            {
                var fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);

                // Llenar las celdas con los tiempos de vida útil de los paneles
                for (int i = 0; i < resultado.paneles.Count; i++)
                {
                    fila.Cells[i].Value = resultado.paneles[i];
                }

                // Llenar la última celda con el tiempo de fallo
                fila.Cells[resultado.paneles.Count].Value = resultado.tiempoFallo;

                dataGridView1.Rows.Add(fila);
            }


        }

        public void DescargaExcel(DataGridView data)
        {
            // Paso 0: Instalar complemento de Excel
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indiceColumna = 0;

            // Paso 1: Construyes columnas y los nombres de las "cabeceras"
            foreach (DataGridViewColumn columna in data.Columns)
            {
                indiceColumna++;
                exportarExcel.Cells[1, indiceColumna] = columna.HeaderText;
            }

            // Paso 2: Construyes filas y llenas valores
            int indiceFilas = 0;

            foreach (DataGridViewRow fila in data.Rows)
            {
                indiceFilas++;
                indiceColumna = 0;
                foreach (DataGridViewColumn columna in data.Columns)
                {
                    indiceColumna++;
                    exportarExcel.Cells[indiceFilas + 1, indiceColumna] = fila.Cells[columna.Name].Value;
                }
            }

            // Paso 3: Visibilidad
            exportarExcel.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DescargaExcel(dataGridView1);
        }
    }
}
    }
}
