//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _vistalibre.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class cotizaciones_complementarios
    {
        public int id { get; set; }
        public int monto { get; set; }
        public string detalle { get; set; }
        public Nullable<int> cotizacion_id { get; set; }
    
        public virtual cotizaciones cotizaciones { get; set; }
    }
}
