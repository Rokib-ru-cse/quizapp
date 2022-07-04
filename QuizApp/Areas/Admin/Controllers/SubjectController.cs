using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Subject.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Subject.Add(subject);
            _unitOfWork.Save();
            return Ok("Subject Create Successfully");
        }
        [HttpPut]
        public IActionResult Update(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Subject.Update(subject);
            _unitOfWork.Save();
            return Ok("Subject updated successfully");
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var subject = _unitOfWork.Subject.GetT(x => x.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var subject = _unitOfWork.Subject.GetT(x => x.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            _unitOfWork.Subject.Delete(subject);
            _unitOfWork.Save();
            return Ok(subject);
        }

    }
}
