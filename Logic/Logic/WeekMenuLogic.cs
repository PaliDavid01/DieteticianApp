using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class WeekMenuLogic : CRUDLogic<WeekMenu>, IWeekMenuLogic
    {
        public WeekMenuLogic(IWeekMenuRepository repository) : base(repository)
        {
        }
    }
}
