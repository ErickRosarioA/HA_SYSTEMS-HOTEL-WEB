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

    public partial class FACTURA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FACTURA()
        {
            this.CUENTA_POR_COBRAR = new HashSet<CUENTA_POR_COBRAR>();
        }
    
        public int Codigo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Code_Factura { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Cliente { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public Nullable<int> Habitacion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Motivo { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public Nullable<int> Hospedaje_fk { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public Nullable<int> Total { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        public Nullable<System.DateTime> Fecha_Creacion { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(11, ErrorMessage = "No cumple con requisisto de cedula",
             MinimumLength = 11)]
        public string Cedula_Cliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CUENTA_POR_COBRAR> CUENTA_POR_COBRAR { get; set; }
        public virtual HOSPEDAJE HOSPEDAJE { get; set; }
    }
}
