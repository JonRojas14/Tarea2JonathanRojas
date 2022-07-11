using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2JonathanRojas.Data;
using Tarea2JonathanRojas.Models;


namespace Tarea2JonathanRojas.Controllers
{
    public class SPEController1 : Controller
    {
        private readonly ApplicationDbContext _context; //Invocar clase ApplicationDbContext para acceder a la base de datos

        public SPEController1(ApplicationDbContext context)
        {
            _context = context; //contructor que recibe como parametro la clase dbcontext
        }

        //Get Index
        public IActionResult Index()
        {
            IEnumerable<ServPorEdif> listServiciosEdfi = _context.Spe; //crea una lista del modelo Servicios por Edificio (SPE)
            return View(listServiciosEdfi); //retorna la vista
        }

        //Get Create
        public IActionResult Create()
        {
            var vm = new ServPorEdif();

            vm.ServEdifName = _context.Edificio.Select(x => new SelectListItem() { Value = x.Nombre, Text = x.Nombre }).ToList();
            vm.ServEdifTipo = _context.Servicio.Select(x => new SelectListItem() { Value = x.Tipo, Text = x.Tipo }).ToList();
            vm.ServEdifEmpresa = _context.Servicio.Select(x => new SelectListItem() { Value = x.Empresa, Text = x.Empresa }).ToList();

            return View(vm); //retorna la vista Create, muestra el formulario para crear registros de edificios

        }

        //Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServPorEdif Spe)
        {
            
                _context.Spe.Add(Spe); //agrega un objeto 
            _context.SaveChanges(); //guarda los cambios

            return RedirectToAction("Index"); //redirecciona al index donde estan los registros de los registros

            return View(Spe);
        }

        //Get Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var servicio = _context.Spe.Find(id);

            if (servicio == null)
            {
                return NotFound();
            }

            return View(servicio);

        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ServPorEdif servicio2)
        {

            if (ModelState.IsValid)
            {
                _context.Spe.Update(servicio2);
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

            var ServicoEdificio = _context.Spe.Find(id);

            if (ServicoEdificio == null)
            {
                return NotFound();
            }

            return View(ServicoEdificio);

        }

        //Post Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteServicio(int? id)
        {

            var servicioedificio = _context.Spe.Find(id);

            if (servicioedificio == null)
            {
                return NotFound();
            }

            _context.Spe.Remove(servicioedificio);
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

    }
}
