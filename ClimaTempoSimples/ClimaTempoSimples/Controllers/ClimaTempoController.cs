using System.Web.Mvc;
using ClimaTempoSimples.Services;
using ClimaTempoSimples.ViewModel;

namespace ClimaTempoSimples.Controllers
{
    public class ClimaTempoController : Controller
    {
        private readonly IClimaTempoService _climaTempoService = new ClimaTempoService();

        public ActionResult Index()
        {
            var previsoes = new PrevisoesViewModel();

            previsoes.ClimasMaisQuentes = _climaTempoService.ListarCidadesMaisQuentes();
            previsoes.ClimasMaisFrios = _climaTempoService.ListarCidadesMaisFrias();
            ViewBag.Cidades = new SelectList(_climaTempoService.ListarCidades(), "Id", "Nome");

            return View(previsoes);
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet, ActionName("buscarprevisoesporcidade")]
        public JsonResult BuscarPrevisoesPorCidade(int cidadeId)
        {
            var previsoes = Json(_climaTempoService.ListarPrevisoesPorCidade(cidadeId),JsonRequestBehavior.AllowGet);

            return Json(previsoes, JsonRequestBehavior.AllowGet);

        }

    }
}
