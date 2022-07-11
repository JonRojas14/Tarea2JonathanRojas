using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tarea2JonathanRojas.Models
{
    public class Edificio
    {
        //este modelo representa la tabla Edificio en la base de datos

        //propiedades con data annotations 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre del edificio")]
        public string Nombre { set; get; }

        [Required(ErrorMessage = "Debe incluir la capacidad maxima de personas del edificio")]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de adquisicion o alquiler del edificio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de compra o alquiler")]
        public DateTime FechaAdquisicion { get; set; }

        [Required(ErrorMessage = "Debe incluir la provincia donde se encuentra el edificio")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "Debe incluir el canton donde se encuentra el edificio")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "Debe incluir el distrito donde se encuentra el edificio")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "Debe indicar si el edificio es alquilado o comprado")]
        public string Tipo { get; set; }

    }
}
