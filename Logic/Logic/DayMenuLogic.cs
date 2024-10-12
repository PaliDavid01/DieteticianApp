using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class DayMenuLogic : CRUDLogic<DayMenu>, IDayMenuLogic
    {
        public DayMenuLogic(IDayMenuRepository repository) : base(repository)
        {
        }
    }
}
