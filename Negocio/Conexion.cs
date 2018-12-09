using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALCmisofertas;

namespace Negocio
{
    public class Conexion
    {

        public static EntitiesMO _entities;

        public static EntitiesMO Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = new EntitiesMO();
                }
                return _entities;
            }
        }

        public Conexion() { }

    }
}
