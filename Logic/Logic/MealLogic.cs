using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class MealLogic : CRUDLogic<Meal>, IMealLogic
    {
        public MealLogic(IMealRepository repository) : base(repository)
        {
        }
    }
}
