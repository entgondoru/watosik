using MediatR;
using Microsoft.AspNetCore.Mvc;
using Watosik.Application.Queries.GetAllDocuments;

public class LegislationController : Controller
{
    private readonly IMediator _mediator;
    public LegislationController(IMediator mediator) 
    {
        _mediator = mediator;
    }
    public async Task<IActionResult> Legislation()
    {
        var documents = await _mediator.Send(new GetAllDocumentsQuery());
        return View(documents);
    }
}
