using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.DTOs;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class BaseMaterialLogic : CRUDLogic<BaseMaterial>, IBaseMaterialLogic
    {
        IBaseMaterialRepository _repository;
        IAllergenMaterialLogic _allergenMaterialLogic;


        public BaseMaterialLogic(IBaseMaterialRepository repository, IAllergenMaterialLogic allergenMaterialLogic, IMaterialGroupRepository materialGroupRepository) : base(repository)
        {
            _repository = repository;
            _allergenMaterialLogic = allergenMaterialLogic;
        }

        public async Task<IEnumerable<BaseMaterial>> GetBaseMaterialsExtended()
        {
            var baseMaterials = await _repository.ReadAllAsync();
            var dtos = new List<BaseMaterialDTO>();
            foreach (var baseMaterial in baseMaterials)
            {
                var allergens = await _allergenMaterialLogic.GetAllergensByMaterialId(baseMaterial.MaterialId);
                baseMaterial.IsAllergen = allergens.Count() > 0;
            }
            return baseMaterials;

        }

        public void LoadFromExcel()
        {
            Random random = new Random();

            using var reader = new StreamReader(@"D:\cikktorzs.csv");
            List<List<string>> data = new List<List<string>>();
            while (!reader.EndOfStream)
            {

                var line = reader.ReadLine();
                var values = line.Split(';');
                if (values[0].Length >= 9)
                {
                    _repository.Create(new BaseMaterial
                    {
                        MaterialName = values[1],
                        Vatrate = int.Parse(values[2]),
                        MaterialCode = "xxxxx",
                        MaterialGroupId = random.Next(1, 15),
                        Quantity = 0,
                    });
                }
            }
            ;
        }
    }
}
