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
    
    public partial class regiones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public regiones()
        {
            this.cotizaciones = new HashSet<cotizaciones>();
        }
    
        public int id { get; set; }
        public string codigo_reg { get; set; }
        public string index { get; set; }
        public string nombre { get; set; }
        public int costo_viaje { get; set; }
        public int taza_imprevisto { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotizaciones> cotizaciones { get; set; }
    }
}
