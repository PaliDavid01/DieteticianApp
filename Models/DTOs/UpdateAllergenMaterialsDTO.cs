using Models.Models;

namespace Models.DTOs
{
    public class UpdateAllergenMaterialsDTO
    {
        public int MaterialId { get; set; }
        public List<AllergenMaterial> AllergenMaterials { get; set; }
    }
}
