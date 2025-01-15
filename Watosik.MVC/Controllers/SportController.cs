using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watosik.Application.Queries.GetTeacherQuery;
using Watosik.Application.Teachers;
using Watosik.MVC.Models;

public class SportController : Controller
{
    private readonly IMediator _mediator;

    public SportController(IMediator mediator)
    {
        _mediator = mediator;
    }
    public IActionResult Sport()
    {
        return View();
    }
    public IActionResult Rygory()
    {
        return View();
    }
    public IActionResult Wytyczne()
    {
        return View();
    }
    public IActionResult Trener_AI()
    {
        return View();
    }

    [HttpGet]
    public PartialViewResult LoadPartial(string category)
    {
        switch (category)
        {
            case "Nabor2023Wojskowe":
                return PartialView("Partial/_Nabor2023Wojskowe");
            case "Nabor2022Wojskowe":
                return PartialView("Partial/_Nabor2022Wojskowe");
            case "Nabor2023Cywilne":
                return PartialView("Partial/_Nabor2023Cywilne");
            case "Nabor2022Cywilne":
                return PartialView("Partial/_Nabor2022Cywilne");
            case "Biegi":
                return PartialView("Partial/_Biegi");
            case "OSF":
                return PartialView("Partial/_OSF");
            case "LTP":
                return PartialView("Partial/_LTP");
            case "BTSBTZ":
                return PartialView("Partial/_BTSBTZ");
            case "CwiczeniaSilowe":
                return PartialView("Partial/_CwiczeniaSilowe");
            case "CwiczeniaWolne":
                return PartialView("Partial/_CwiczeniaWolne");
            case "WalkaWrecz":
                return PartialView("Partial/_WalkaWrecz");
            default:
                return PartialView("Partial/_Default");
        }
    }

    public IActionResult Konsultacje( )
    {
        var teachers = TeacherData.Teachers;
        return View(teachers);
    }

    [HttpGet]
    public async Task<IActionResult> GetTeachers(string searchTerm)
    {
        var query = new GetTeachersQuery { SearchTerm = searchTerm };
        var teachers = await _mediator.Send(query);
        return PartialView("_TeacherTable", teachers);
    }

}
