//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Devolucion_Producto
    {
        public int ID_Dev { get; set; }
        public int ID_Producto { get; set; }
        public int ID_Prov { get; set; }
        public int Cantidad { get; set; }
        public System.DateTime Fecha_Dev { get; set; }
        public string Motivo_Dev { get; set; }
        public decimal Total_Dev { get; set; }
    
        public virtual Productos Productos { get; set; }
        public virtual Proveedor Proveedor { get; set; }
    }
}
