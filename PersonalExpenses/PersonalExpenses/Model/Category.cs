using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Model
{
    public static class Category
    {
        public static List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            categories.Add(Resources.AppResources.MealCategory);
            categories.Add(Resources.AppResources.TransportCategory);
            categories.Add(Resources.AppResources.HealthCategory);
            categories.Add(Resources.AppResources.SavingsCategory);
            categories.Add(Resources.AppResources.MiscellaneousCategory);
            categories.Add(Resources.AppResources.HomeCateogry);
            categories.Add(Resources.AppResources.OtherCategory);
            return categories;
        }
    }
}
