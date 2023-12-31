//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventario.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HistorialProducto
    {
        public int HistorialProductoID { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public decimal Monto { get; set; }
        [Required]
        public System.DateTime Fecha { get; set; }
        [Required]
        public string Accion { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int ProductoID { get; set; }
        [Required]
        public string UnidadDeMedida { get; set; }
        

        public virtual Producto Producto { get; set; }
    }
}
