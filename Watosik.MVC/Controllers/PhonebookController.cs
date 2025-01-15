using Microsoft.AspNetCore.Mvc;
using Watosik.Application;
using MediatR;
using Watosik.Application.Queries.GetAllPhoneBookContacts;

public class PhonebookController : Controller
{
    private readonly IMediator _mediator;

    public PhonebookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Phonebook()
    {
        var contacts = await _mediator.Send(new GetAllPhoneBookContactsQuery());
        return View(contacts);
    }
}
