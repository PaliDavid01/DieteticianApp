using API.Controllers.GenericController;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitaminController : CRUDController<Vitamin>
    {
        public VitaminController(IVitaminLogic logic) : base(logic)
        {
        }
    }
}
