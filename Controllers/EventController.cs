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

            return View(model);
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

            return RedirectToAction("Success", new
            {
                fullName = model.FullName,
                email = model.Email,
                eventCode = model.EventCode,
                tickets = model.Tickets,
                referralCode = model.ReferralCode ?? "" // Avoid null issues
            });
        }

        [HttpGet("success")]
        public IActionResult Success(string fullName, string email, string eventCode, int tickets, string referralCode = "") //What a load of arguments
        {
            EventRegistration model = new EventRegistration
            {
                FullName = fullName,
                Email = email,
                EventCode = eventCode,
                Tickets = tickets,
                ReferralCode = referralCode
            };

            return View(model);
        }

    }
}
