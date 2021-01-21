using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirstFormulaOneDB.Models
{
    public class DriverChampionshipResult
    {    
        [Key]
        [Column(Order = 0)]        
        public long DriverId { get; set; }

        [Key]
        [Column(Order = 1)]
        public long ChampionshipId { get; set; }

        [DisplayName("Место")]
        [Range(1, Constants.MAX_NUM_OF_DRIVERS_IN_CHAMPIONSHIP)]
        public int Place { get; set; }

        [DisplayName("Очки")]
        [Range(0, Constants.MAX_NUM_OF_POINTS_PER_CHAMPIONSHIP)]
        public int Points { get; set; }

        [DisplayName("Победы")]
        [Range(0, Constants.MAX_NUM_OF_GRAND_PRIXES_IN_CHAMPIONSHIP)]
        public int Wins { get; set; }

        [Required]
        [DisplayName("Команда")]
        [EnumDataType(typeof(Enums.Team))]
        public Enums.Team Team { get; set; }


        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

        [ForeignKey("ChampionshipId")]
        public virtual Championship Championship { get; set; }
    }
}