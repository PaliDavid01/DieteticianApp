using Models.Models;

namespace Models.DTOs
{
    public class BaseMaterialDTO : BaseMaterial
    {
        public IEnumerable<AllergenMaterialView> allergenMaterialViews { get; set; }
    }
}
