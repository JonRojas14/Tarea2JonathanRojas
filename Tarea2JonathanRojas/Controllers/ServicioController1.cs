using Microsoft.AspNetCore.Mvc;
using Tarea2JonathanRojas.Data;
using Tarea2JonathanRojas.Models;


namespace Tarea2JonathanRojas.Controllers
{
    public class ServicioController1 : Controller
    {
        private readonly ApplicationDbContext _context; //Invocar clase ApplicationDbContext para acceder a la base de datos

        public ServicioController1(ApplicationDbContext context)
        {
            _context = context; //contructor que recibe como parametro la clase dbcontext
        }

        //Get Index
        public IActionResult Index()
        {
            IEnumerable<Servicio> listServicios = _context.Servicio; //crea una lista del modelo Servicio
            return View(listServicios); //retorna la vista
        }

        //Get Create
        public IActionResult Create()
        {
            return View(); //retorna la vista Create, muestra el formulario para crear registros de edificios

        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Servicio servicio)
        {

            if (ModelState.IsValid) // valida el modelo es decir toma en cuenta si un campo es requerido, entre otros.
            {
                _context.Servicio.Add(servicio); //agrega un objeto 
                _context.SaveChanges(); //guarda los cambios

                return RedirectToAction("Index"); //redirecciona al index donde estan los registros de los servicios
            }

            return View();

        }

        //Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var servicio = _context.Servicio.Find(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);

        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Servicio servicio)
        {

            if (ModelState.IsValid)
            {
                _context.Servicio.Update(servicio);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }

        //Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var edificio = _context.Servicio.Find(id);

            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);

        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteServicio(int? id)
        {

            var servicio = _context.Servicio.Find(id);

            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicio.Remove(servicio);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}
