using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonteCarloEj1
{
    public class Class1
{

    public int IdExp { get; set; }
    public int NumPanel { get; set; }
    public int Valor { get; set; }

        public Class1()
    {
    }
    public Class1(Class1 class1)
    {
        IdExp = class1.IdExp;
        NumPanel = class1.NumPanel;
        Valor = class1.Valor;

    }
}
}