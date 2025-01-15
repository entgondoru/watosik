using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Watosik.Application.Queries;
using Watosik.Application.Queries.CalculatePoints;

namespace Watosik.MVC.Controllers
{
    public class CompetitionController : Controller
    {
        private readonly IMediator _mediator;

        public CompetitionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CalculatePointsQuery query)
        {
            var result = await _mediator.Send(query);
            return View("Result", result);
        }
    }
}
