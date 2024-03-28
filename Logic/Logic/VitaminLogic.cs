using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class VitaminLogic : CRUDLogic<Vitamin>, IVitaminLogic
    {
        public VitaminLogic(IVitaminRepository repository) : base(repository)
        {
        }
    }
}
