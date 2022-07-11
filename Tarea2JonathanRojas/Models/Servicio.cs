using System.ComponentModel.DataAnnotations;

namespace Tarea2JonathanRojas.Models
{
    public class Servicio
    {
        //este modelo representa la tabla Edificio en la base de datos

        //propiedades con data annotations 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre del servicio")]
        [Display(Name = "Nombre del Servicio")]
        public string NombreServicio { set; get; }

        [Required(ErrorMessage = "Debe incluir el nombre el tipo de servicio")]
        public string Tipo { set; get; }

        [Required(ErrorMessage = "Debe incluir la unidad de medida del servicio")]
        public string Unidad { get; set; }

        [Required(ErrorMessage = "Debe incluir el nombre de la empresa que brinda el servicio")]
        public string Empresa { set; get; }
    }
}
