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
    
    public partial class COMPORTAMIENTO_BI
    {
        public decimal IDBI { get; set; }
        public decimal ID_OFERTA { get; set; }
        public string RUT_CONSUMIDOR { get; set; }
        public decimal CANT_ACCESOS { get; set; }
    
        public virtual OFERTA OFERTA { get; set; }
        public virtual CONSUMIDOR CONSUMIDOR { get; set; }
    }
}
