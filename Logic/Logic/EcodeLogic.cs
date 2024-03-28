using Logic.Interfaces;
using Logic.Logic.GenericLogic;
using Models.Models;
using Repository.Interfaces;

namespace Logic.Logic
{
    public class EcodeLogic : CRUDLogic<Ecode>, IEcodeLogic
    {
        public EcodeLogic(IEcodeRepository repository) : base(repository)
        {
        }
    }
}
