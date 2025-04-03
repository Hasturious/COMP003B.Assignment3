using COMP003B.Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment3.Controllers
{
    public class EventController : Controller
    {
        [HttpGet("event/register/{eventCode}")]
        public IActionResult Register(string eventCode)
        {
            EventRegistration model = new EventRegistration(); //creates an instance of the EventRegi model
            model.EventCode = eventCode; //prefills the event code

            return View();
        }

        [HttpGet("event/register")]
        public IActionResult Register()
        {
            EventRegistration model = new EventRegistration();
            return View(new EventRegistration()); //should return blank
        }

        [HttpPost("register")]
        public IActionResult RegisterPost([FromForm] EventRegistration model)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", model);
            }

            return RedirectToAction("Success", model);
        }

        [HttpGet("success")]
        public IActionResult Success(EventRegistration model)
        {
            return View(model);
        }
    }
}
