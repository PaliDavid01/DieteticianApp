using Logic.Interfaces.GenericInterfaces;
using Models.Models;

namespace Logic.Interfaces
{
    public interface IBaseMaterialLogic : ICRUDLogic<BaseMaterial>
    {
        void LoadFromExcel();
    }
}
