using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirstFormulaOneDB.Models
{
    public class Championship
    {    
        [Key]
        public long ChampionshipId { get; set; }

        [DisplayName("Год проведения")]
        [Range(1950, Constants.CURRENT_YEAR)]
        public int Year { get; set; }

        [DisplayName("Гоночная серия")]
        [EnumDataType(typeof(Enums.RacingSeries))]
        public Enums.RacingSeries RacingSeries { get; set; }

        [Required]
        [DisplayName("Название чемпионата")]
        [RegularExpression(@"^[0-9А-ЯЁ][0-9А-Яа-яё -]{10,80}$", ErrorMessage = "Введено некорректное название чемпионата")]
        public string Title { get; set; }

        public virtual ICollection<DriverChampionshipResult> DriverChampionshipResults { get; set; }
    }
}