//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ha_Systems_Proyect.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HOSPEDAJE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOSPEDAJE()
        {
            this.FACTURA = new HashSet<FACTURA>();
        }
    
        public int Id_hospedaje { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Cliente_id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Habitacion_id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public System.DateTime Fecha_inicio { get; set; }
        public Nullable<System.DateTime> Fecha_fin { get; set; }
    
        public virtual CLIENTE CLIENTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FACTURA> FACTURA { get; set; }
        public virtual HABITACION HABITACION { get; set; }
    }
}
