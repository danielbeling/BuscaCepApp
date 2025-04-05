using BuscaCepApp.Models;
using BuscaCepApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuscaCepApp.Controllers
{
    public class CepController : Controller
    {
        private readonly ViaCepService _viaCepService;

        public CepController(ViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string cep)
        {
            var resultado = await _viaCepService.BuscarCep(cep);

            if (resultado == null)
            {
                ModelState.AddModelError("", "CEP não encontrado.");
                return View("Index");
            }

            return View("Resultado", resultado);
        }
    }

}
