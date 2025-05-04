using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Lab_4.Models
{
    public class CalculatorViewModel
    {
        [Required(ErrorMessage = "Number1 is required.")]
        public int Number1 { get; set; }

        [StringLength(10, ErrorMessage = "Number2 cannot be longer than 10 characters.")]
        public string Number2 { get; set; }
        public string? SelectedOperation { get; set; }
        public List<SelectListItem> Operations { get; set; }
        public double? Result { get; set; }

        public CalculatorViewModel()
        {
            Operations =
            [
                new SelectListItem { Value = "Add", Text = "Addition" },
                new SelectListItem { Value = "Subtract", Text = "Subtraction" },
                new SelectListItem { Value = "Multiply", Text = "Multiplication" },
                new SelectListItem { Value = "Divide", Text = "Division" }
            ];
        }

    }
}