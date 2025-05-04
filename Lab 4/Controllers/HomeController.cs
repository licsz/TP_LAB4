using Lab_4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;



namespace Lab_4.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            var model = new CalculatorViewModel();
            ViewBag.PredefinedValue = 10; // Задать значение
            return View(model);
        }
        [HttpGet]
        public IActionResult Result(string number1, string number2, string operation, string result)
        {
            ViewData["number1"] = number1;
            ViewData["number2"] = number2;
            ViewData["operation"] = operation;
            ViewData["result"] = result;
            return View();
        }
        [HttpPost]
        public ActionResult Index(CalculatorViewModel model, string action)
        {

                if (ModelState.IsValid)
                {
                    double number2;
                    if (!double.TryParse(model.Number2, out number2))
                    {
                        ModelState.AddModelError("Number2", "Number2 must be an integer.");
                    }
                switch (model.SelectedOperation)
                    {
                        case "Add":
                            model.Result = model.Number1 + number2;
                            break;
                        case "Subtract":
                            model.Result = model.Number1 - number2;
                            break;
                        case "Multiply":
                            model.Result = model.Number1 * number2;
                            break;
                        case "Divide":
                            if (number2 != 0)
                            {
                                model.Result = model.Number1 / number2;
                            }
                            else
                            {
                                ModelState.AddModelError("", "Division by zero is not allowed.");
                            }
                            break;
                    }
                if (model.Result.HasValue)
                {
                    var queryString = new Dictionary<string, string>
                        {
                            { "number1", model.Number1.ToString() },
                            { "number2", model.Number2 },
                            { "operation", model.SelectedOperation },
                            { "result", model.Result.ToString() }
                        };



                }
            }

            if (action == "Clear")
            {
                ModelState.Clear();
                model.Number1 = 0;
                model.Number2 = "0";
                model.SelectedOperation = null;
                model.Result = null;
            }

            ViewBag.PredefinedValue = 10; // Задать значение
            return View(model);
        }
    }
}