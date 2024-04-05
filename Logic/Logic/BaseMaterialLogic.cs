using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class BaseMaterialLogic : CRUDLogic<BaseMaterial>, IBaseMaterialLogic
    {
        IBaseMaterialRepository _repository;
        public BaseMaterialLogic(IBaseMaterialRepository repository) : base(repository)
        {
            _repository = repository;
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
