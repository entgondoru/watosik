using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watosik.Application.DataTransferObjects
{
    public class mealDto
    {
        public required int meal_id { get; set; }
        public string meal_name { get; set; }
        public string allergens { get; set; }
        public int weight_g { get; set; }
        public int energy_kcal { get; set; }
        public double protein_g { get; set; }
        public double fat_g { get; set; }
        public double carbohydrates { get; set; }
        public string allergenic_ingredients { get; set; }
    }
}

