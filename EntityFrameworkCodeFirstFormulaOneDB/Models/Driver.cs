using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirstFormulaOneDB.Models
{
    public class Driver
    {
        [Key]        
        public long DriverId { get; set; }

        [Required]
        [DisplayName("Имя")]
        [RegularExpression(@"^[А-ЯЁ][а-яё]{0,20}$", ErrorMessage = "Введено некорректное имя")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Фамилия")]        
        [RegularExpression(@"^[А-ЯЁа-яё][а-яё']{0,30}$", ErrorMessage = "Введена некорректная фамилия")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Страна")]
        [EnumDataType(typeof(Enums.Country))]
        public Enums.Country Country { get; set; }        


        public virtual ICollection<DriverChampionshipResult> DriverChampionshipResults { get; set; }
    }
}