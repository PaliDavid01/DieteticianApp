using Logic.Interfaces.GenericInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.GenericController
{
    public class CRUDController<T> : ControllerBase where T : class
    {
        private readonly ICRUDLogic<T> _logic;

        public CRUDController(ICRUDLogic<T> logic)
        {
            _logic = logic;
        }
        [HttpPost("Create")]
        public void Create(T entity)
        {
            _logic.Create(entity);
        }
        [HttpPost("CreateAsyn")]
        public Task CreateAsync(T entity)
        {
            return _logic.CreateAsync(entity);
        }
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _logic.Delete(id);
        }
        [HttpDelete("DeleteAsyn")]
        public Task DeleteAsync(T entity)
        {
            return _logic.DeleteAsync(entity);
        }
        [HttpDelete("DeleteByIdAsyn/{id}")]
        public Task DeleteByIdAsync(int id)
        {
            return _logic.DeleteByIdAsync(id);
        }
        [HttpGet("ReadAllAsyn")]
        public Task<IEnumerable<T>> ReadAllAsync()
        {
            return _logic.ReadAllAsync();
        }
        [HttpGet("ReadAll")]
        public IEnumerable<T> ReadAll()
        {
            return _logic.ReadAll();
        }
        [HttpGet("ReadByIdAsyn/{id}")]
        public Task<T> GetByIdAsync(int id)
        {
            return _logic.ReadByIdAsync(id);
        }
        [HttpPut("Update")]
        public void Update(T entity)
        {
            _logic.Update(entity);
        }
        [HttpPut("UpdateAsyn")]
        public Task UpdateAsync(T entity)
        {
            return _logic.UpdateAsync(entity);
        }





    }
}
