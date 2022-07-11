using Microsoft.AspNetCore.Mvc;
using Tarea2JonathanRojas.Data;
using Tarea2JonathanRojas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tarea2JonathanRojas.Controllers
{
    public class EdificioController1 : Controller
    {
        private readonly ApplicationDbContext _context; //Invocar clase ApplicationDbContext para acceder a la base de datos

        public EdificioController1(ApplicationDbContext context)
        {
            _context = context; //contructor que recibe como parametro la clase dbcontext
        }

        //Get Index
        public IActionResult Index() 
        {
            IEnumerable<Edificio> listEdificios = _context.Edificio; //crea una lista del modelo Edificio
            return View(listEdificios); //retorna la vista 
        }

        //Get Create
        public IActionResult Create() //metodo Get Create
        {
            return View(); //retorna la vista Create, muestra el formulario para crear registros de edificios
           
        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Edificio edificio)
        {

            if (ModelState.IsValid) // valida el modelo es decir toma en cuenta si un campo es requerido, entre otros.
            {
                    _context.Edificio.Add(edificio); //agrega un objeto 
                    _context.SaveChanges(); //guarda los cambios

                    return RedirectToAction("Index"); //redirecciona al index donde estan los registros de los edificios
            
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


            //obtener el edificio
            var edificio = _context.Edificio.Find(id);

            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);

        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Edificio edificio)
        {

            if (ModelState.IsValid)
            {
                _context.Edificio.Update(edificio);
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

            var edificio = _context.Edificio.Find(id);

            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);

        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEdificio(int? id)
        {

            var edificio = _context.Edificio.Find(id);

            if (edificio == null)
            {
                return NotFound();
            }

            _context.Edificio.Remove(edificio);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}
