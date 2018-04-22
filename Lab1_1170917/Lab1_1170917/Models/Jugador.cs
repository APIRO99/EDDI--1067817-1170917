using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab1_1170917.Models
{
    public class Jugador
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar nombre")]
        [StringLength(10, ErrorMessage = "Máxico 10 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar apellido")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar Posición")]
        [Display(Name = "Posición dentro del campo")]
        public string Posición { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingresar Salario")]
        [Display(Name = "Salario")]
        [Range(1000, 100000, ErrorMessage = "El salario debe ser entre $1000 y $100000")]
        public decimal Salario { get; set; }

        public string Club { get; set; }
    }
}