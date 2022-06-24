using UltimusTest.Domain.Constants;
using UltimusTest.Domain.Enumerators;
using UltimusTest.Domain.Interfaces.Services;
using UltimusTest.Domain.Helper;

namespace UltimusTest.Domain.Services
{
    public class FoodOrderService : IFoodOrderService
    {
        public string Execute(string orderCSV)
        {
            return TransformOrderIntoDishes(orderCSV);
        }



        public string TransformOrderIntoDishes(string orderCSV)
        {
            var orderList = SanitizeData(orderCSV);
            return SelectDishes(orderList);

        }

        private List<string> SanitizeData(string orderCSV)
        {
            return orderCSV.ToLower()
                        .Replace(" ", "")
                        .Split(',')
                        .ToList();

        }

        private string SelectDishes(List<string> orderList)
        {
            var output = string.Empty;
            switch (orderList.First())
            {
                case Menu.MORNING:
                    orderList.Remove(Menu.MORNING);
                    orderList.Sort();
                    output =  GetDishes(orderList, typeof(MorningMenuEnum));
                    break;
                case Menu.NIGHT:
                    orderList.Remove(Menu.NIGHT);
                    orderList.Sort();
                    output = GetDishes(orderList, typeof(NightMenuEnum));
                    break;
                default:
                    throw new Exception("Invalid Menu Parameter");
                    break;
            }
            return output;
        }

        private string GetDishes(List<string> orderList, Type menuEnumType)
        {
            var disheDescription = new List<string>();
            foreach (var item in orderList)
            {
                var itemInt = int.Parse(item);
                if (Enum.IsDefined(menuEnumType, itemInt))
                {
                    var description = GetDisheDescription(itemInt, menuEnumType);
                    var repeatedItemQuantity = CheckQuantity(orderList, item);

                    if(repeatedItemQuantity > 1 && menuEnumType == typeof(MorningMenuEnum) &&  item == RepeatableDishes.COFFEE)
                    {
                        description = description + $"(x{repeatedItemQuantity})";
                    }
                    else if (repeatedItemQuantity > 1 && menuEnumType == typeof(NightMenuEnum) && item == RepeatableDishes.POTATO)
                    {
                        description = description + $"(x{repeatedItemQuantity})";
                    }
                    else if (repeatedItemQuantity > 1)
                    {
                        disheDescription.Add(description);
                        disheDescription.Add("error");
                        break;
                    }

                    disheDescription.Add(description);
                }
                else
                {
                    disheDescription.Add("error");
                    break;
                }

            }

            return String.Join(", ", disheDescription.Distinct().ToList());
        }

        private string GetDisheDescription(int index, Type menuEnumType)
        {
            var description = string.Empty;
            if (menuEnumType == typeof(MorningMenuEnum))
            {
                description = ((MorningMenuEnum)index).GetDescription();
            }
            else if (menuEnumType == typeof(NightMenuEnum))
            {
                description = ((NightMenuEnum)index).GetDescription();
            }

            return description;
        }

        private int CheckQuantity(List<string> orderList, string item)
        {
            return orderList.GroupBy(x => x).Where(g => g.Count() > 1 && g.Key.Equals(item)).Select(y => y.Count()).FirstOrDefault();

        }


    }
}
