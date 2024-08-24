using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Data.ValueObject;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentRepository _repository;
        public StudentController(IStudentRepository repository) 
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentVO>>> FindAll()
        {
            var students = await _repository.FindAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentVO>> FindById(long id)
        {
            var student = await _repository.FindById(id);
            if (student == null) return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<StudentVO>> Create(StudentVO vo) 
        {
            if (vo == null) return BadRequest();
            var student = await _repository.Create(vo);
            return Ok(student);
        }
        [HttpPut]
        public async Task<ActionResult<StudentVO>> Update(StudentVO vo)
        {
            if (vo == null) return BadRequest();
            var student = await _repository.Update(vo);
            return Ok(student);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
