using Microsoft.AspNetCore.Mvc;

public class PhonebookController : Controller
{
    public IActionResult Phonebook()
    {
        return View();
    }
}
