using Microsoft.AspNetCore.Mvc;

public class LegislationController : Controller
{
    public IActionResult Legislation()
    {
        return View();
    }
}
