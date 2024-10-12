using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class AgeCategoryLogic : CRUDLogic<AgeCategory>, IAgeCategoryLogic
    {
        public AgeCategoryLogic(IAgeCategoryRepository repository) : base(repository)
        {
        }
    }
}
