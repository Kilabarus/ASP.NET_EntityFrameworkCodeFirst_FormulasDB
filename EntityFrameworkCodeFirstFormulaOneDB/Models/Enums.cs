using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntityFrameworkCodeFirstFormulaOneDB.Models
{
    public static class Enums
    {
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return attributes[0].Description;
            }                
            else
            {
                return value.ToString();
            }              
        }

        public enum Country
        {
            [Description("Россия")]
            Russia,
            [Description("Великобритания")]
            UK,
            [Description("Монако")]
            Monaco,
            [Description("Нидерланды")]
            Netherlands,
            [Description("Франция")]
            France,
            [Description("Дания")]
            Denmark
        }

        public enum Team
        {
            [Display(Name = "Скудерия Феррари")]
            [Description("Скудерия Феррари")]
            Ferrari,
            [Display(Name = "Мерседес")]
            [Description("Мерседес")]
            Mercedes,
            [Display(Name = "Ред Булл")]
            [Description("Ред Булл")]
            RedBull,
            [Display(Name = "Альфа Таури")]
            [Description("Альфа Таури")]
            AlphaTauri,
            [Display(Name = "Уильямс")]
            [Description("Уильямс")]
            Williams,
            [Display(Name = "ХААС")]
            [Description("ХААС")]
            HAAS,
            [Display(Name = "Рейсинг Поинт")]
            [Description("Рейсинг Поинт")]
            RacingPoint
        }

        public enum RacingSeries
        {
            [Description("Формула-1")]
            F1,
            [Description("Формула-2")]
            F2,
            [Description("Индикар")]
            IndyCar
        }
    }
}