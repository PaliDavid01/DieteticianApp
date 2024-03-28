using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class MaterialGroupLogic : CRUDLogic<MaterialGroup>, IMaterialGroupLogic
    {
        public MaterialGroupLogic(IMaterialGroupRepository repository) : base(repository)
        {
        }
    }
}

