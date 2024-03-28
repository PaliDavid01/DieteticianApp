using API.Controllers.GenericController;
using AutoMapper;
using Logic.Interfaces;
using Logic.Interfaces.GenericInterfaces;
using Logic.Logic;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Models;
using Models.Storage;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController : CRUDController<BaseMaterial>
    {
        public MaterialController(IBaseMaterialLogic logic) : base(logic)
        {
        }
    }
}
