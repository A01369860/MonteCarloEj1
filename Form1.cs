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
                MessageBox.Show("Los n�meros tienen que ser MAYOR que cero, NO VAC�OS.");
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
            MessageBox.Show($"La vida �til esperada del sat�lite es: {vidaUtilEsperada:F2} horas");
        }

        public void llenarGrid(List<Class1> lista)
        {
            // Paso 0: Indicas el numero de columnas
            string numeroColumna1 = "1";
            string numeroColumna2 = "2";

            // Paso 1: Determinas la cantidad de columnas
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(numeroColumna1, "Id");

            // Paso 2: Recorres el grid para cada fila y llenar de valores aleatorios
            for (int i = 0; i < lista.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[Int32.Parse(numeroColumna1) - 1].Value = (lista[i].IdExp).ToString();
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
