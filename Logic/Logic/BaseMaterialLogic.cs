using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class BaseMaterialLogic : CRUDLogic<BaseMaterial>, IBaseMaterialLogic
    {
        public BaseMaterialLogic(IBaseMaterialRepository repository) : base(repository)
        {
        }
    }
}
