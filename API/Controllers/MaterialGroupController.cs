using API.Controllers.GenericController;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialGroupController : CRUDController<MaterialGroup>
    {
        public MaterialGroupController(IMaterialGroupLogic logic) : base(logic)
        {
        }
    }
}
