using Models.Models;

namespace Models.DTOs
{
    public class UpdateAllergenWeekMenuDataDTO
    {
        public int WeekMWeekMenuGenerateDataId { get; set; }
        public List<WeekMenuGenerateDataAllergen> AllergenWeekMenuDatas { get; set; }
    }
}
