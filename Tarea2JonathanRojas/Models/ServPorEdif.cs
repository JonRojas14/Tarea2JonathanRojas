using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tarea2JonathanRojas.Models
{
    public class ServPorEdif
    {
        //este modelo representa la tabla Edificio en la base de datos

        //propiedades con data annotations 
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre del Edificio")]
        public string NombreEdificio { get; set; }

        [Required]
        [Display(Name = "Tipo de Servicio")]
        public string Servicios { get; set; }

        [Required]
        [Display(Name = "Empresa")]
        public string EmpresaServicio { get; set; }

        [Required(ErrorMessage = "Debe incluir la fecha de corte o pago del servicio")]
       
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de corte")]
        public DateTime? FechaAdquisicion { get; set; }

        // SelectListItem contiene una lista de opciones similar a un select en     HTML, contiene la clave(value) y el texto (text), IEnumerable es una clase que convierte los datos a una lista de selectlistitem
        [NotMapped]
        public IEnumerable<SelectListItem> ServEdifName { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ServEdifTipo { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ServEdifEmpresa { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ServEdifFecha { get; set; }  

    }
}
