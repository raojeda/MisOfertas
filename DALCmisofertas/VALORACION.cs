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
    
    public partial class VALORACION
    {
        public decimal ID { get; set; }
        public string ESCALA { get; set; }
        public decimal EVALUACION_ID { get; set; }
        public string CONSUMIDOR_RUN { get; set; }
        public decimal OFERTA_ID { get; set; }
    
        public virtual CONSUMIDOR CONSUMIDOR { get; set; }
        public virtual EVALUACION EVALUACION { get; set; }
        public virtual OFERTA OFERTA { get; set; }
    }
}
