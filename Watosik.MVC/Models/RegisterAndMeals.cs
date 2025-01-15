using Microsoft.AspNetCore.Mvc;
using Watosik.Application.DataTransferObjects;

namespace Watosik.MVC.Models
{
    public class RegisterAndMeals
    {
        public IEnumerable<register_mealsDTO> Register { get; }
        public IEnumerable<mealDto> Meals { get; }

        public RegisterAndMeals(IEnumerable<register_mealsDTO> register, IEnumerable<mealDto> meals)
        {
            this.Register = register;
            this.Meals = meals;
        }
    }
}
