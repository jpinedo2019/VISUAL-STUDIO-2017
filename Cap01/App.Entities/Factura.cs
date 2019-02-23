using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities
{
    public class Factura:Documento
    {
        private const decimal IGV_Valor = 0.18m;

        public decimal IGV { get; set; }
        public decimal SubTotal { get; set; }
        public string RUC { get; set; }


        public override void Calcular()
        {
            SubTotal = Total /(1+ IGV_Valor);
            IGV = Total - SubTotal;

            base.Calcular();
        }
    }
}
