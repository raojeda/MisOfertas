//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALCmisofertas
{
    using System;
    using System.Collections.Generic;
    
    public partial class EVALUACION
    {
        public EVALUACION()
        {
            this.VALORACION = new HashSet<VALORACION>();
        }
    
        public decimal ID { get; set; }
        public System.DateTime FECHA_COMPRA { get; set; }
        public byte[] IMAGEN { get; set; }
        public string COMENTARIO { get; set; }
    
        public virtual ICollection<VALORACION> VALORACION { get; set; }
    }
}