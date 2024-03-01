
using Microsoft.AspNetCore.Mvc;
using Examer.Server.Data;
using Examer.Server.Models;

namespace Examer.Server.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase 
    {
        private readonly IBaseRepository<Project> _examRep;

        public ExamController(IBaseRepository<Project> examRep)
        {
            _examRep = examRep;
        }


        [HttpPost]
        public IActionResult Create(Project model)
        {
            try
            {
                _examRep.CreateAsync(model);
            }catch (Exception ex) {
                return NoContent();
            }
            return Ok();
        }

        [HttpPatch]
        public IActionResult Update(Project model)
        {
            try
            {
                var project = _examRep.GetAll().Where(x => x.token == model.token).FirstOrDefault();
                if (project != null)
                {
                    project.Name = model.Name;
                    _examRep.UpdateAsync(project);
                    return Ok();
                }
                return NoContent();
            }
            catch(Exception ex) {
                return NoContent();
            }         
        }

        [HttpGet("{token}")]
        public Project Get(string token)
        {
            try
            {
                var project = _examRep.GetAll().Where(x => x.token == token).FirstOrDefault();
                return project;
            }catch  (Exception ex)
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public IEnumerable<Project> GetAll()
        {
            return _examRep.GetAll();   
        }

        [HttpDelete("{token}")]
        public IActionResult Delete(string token)
        {
            var project = _examRep.GetAll().Where(x => x.token == token).FirstOrDefault();
            if(project != null)
            {
                _examRep.RemoveAsync(project);
                return Ok();
            }
            return NoContent();
        }
    }
}
