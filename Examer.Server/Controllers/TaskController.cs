using Examer.Server.Data;
using Examer.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public readonly IBaseRepository<Problem> _taskRepository;
        public TaskController(IBaseRepository<Problem> taskRep)
        {
            _taskRepository = taskRep;
        }


        [HttpPost]
        public IActionResult Create(Problem model)
        {
            try
            {
                _taskRepository.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine("/nnnnnnnnnnnnnnnnnnnnnn" + ex.ToString());
                return NoContent();
            }
        }

        [HttpPatch]
        public IActionResult Update(Problem model)
        {
            try
            {
                var project = _taskRepository.GetAll().Where(x => x.Id == model.Id).FirstOrDefault();
                if (project != null)
                {
                    project.Name = model.Name;
                    project.text = model.text;
                    project.Answer = model.Answer;
                    project.AnswerPhoto = model.AnswerPhoto;
                    _taskRepository.UpdateAsync(project);
                    return Ok();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public Problem Get(int id)
        {
            try
            {
                var project = _taskRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
                return project;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("all/{token}")]
        public IEnumerable<Problem> GetAll(string token)
        {
            return _taskRepository.GetAll().Where(x => x.token == token);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAsync(int id)
        {
            var project = _taskRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
            if (project != null)
            {
               _taskRepository.RemoveAsync(project);
                return Ok();
            }
            return NoContent();
        }


        [HttpDelete("all/{token}")]
        public async void DeleteAllAsync(string token)
        {
            var project =  _taskRepository.GetAll().Where(x => x.token == token);
            if(project != null)
            {
                _taskRepository.RemoveAllAsync(project);
            }
        }
    }
}
