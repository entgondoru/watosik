using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watosik.Application.Queries.GetAllDocuments;
using Watosik.Application.Queries.GetAllRegisterMeals;
using Watosik.MVC.Models;

public class CanteenController : Controller
{
    private readonly IMediator _mediator;

    public CanteenController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Canteen()
    {
        var registerMeals = await _mediator.Send(new GetAllRegisterMealsQuery());
        var meals = await _mediator.Send(new GetAllmealsQuery());

        var model = new RegisterAndMeals(registerMeals, meals);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GetMealsByCanteenAndDate(int canteenId, DateTime date)
    {
        var registerMeals = await _mediator.Send(new GetAllRegisterMealsQuery());

        var filteredMeals = registerMeals
            .Where(m => m.date.Date == date.Date)
            .Select(m => new
            {
                breakfast = canteenId == 1 ? m.sw1_breakfast :
                            canteenId == 2 ? m.sw2_breakfast :
                            canteenId == 3 ? m.sw3_breakfast : null,
                dinner = canteenId == 1 ? m.sw1_dinner :
                         canteenId == 2 ? m.sw2_dinner :
                         canteenId == 3 ? m.sw3_dinner : null,
                supper = canteenId == 1 ? m.sw1_supper :
                         canteenId == 2 ? m.sw2_supper :
                         canteenId == 3 ? m.sw3_supper : null
            });

        return Json(filteredMeals);
    }
}
