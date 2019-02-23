using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Evento
{
    public class Listeners
    {
        private Action<object> mostrarDatos;

        public Listeners(Action<object> mostrarDatos)
        {
            this.mostrarDatos = mostrarDatos;
        }

        public delegate void DespuesCalcular(object obj);
        
        
    }
}
