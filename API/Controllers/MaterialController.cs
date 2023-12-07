using AutoMapper;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models.Storage;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MaterialController: ControllerBase
    {
        private readonly IMaterialLogic _logic;
        private readonly IMapper _mapper;
        public MaterialController(IMaterialLogic logic, IMapper mapper)
        {
            this._logic = logic;
            this._mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Material> GetAll()
        {
            return this._logic.GetAll();
        }

        [HttpPost]
        public void Create([FromBody] MaterialPostDTO material) 
        {
            var item = _mapper.Map<Material>(material);
            _logic.Create(item);
        }

        [HttpPut]
        public void Update([FromBody] Material material) 
        {
            _logic.Update(material);
        }
        [HttpDelete]
        public void Delete(string id) 
        {
            _logic.Delete(id);
        }
    }
}
