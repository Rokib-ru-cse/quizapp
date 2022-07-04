using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuizController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Quiz.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Quiz.Add(quiz);
            _unitOfWork.Save();
            return Ok("Quiz Created successfully");

        }
        [HttpPut]
        public IActionResult Update(Quiz quiz)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Quiz.Update(quiz);
            _unitOfWork.Save();
            return Ok("Quiz updated successfully");
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.GetT(x => x.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            return Ok(quiz);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteQuiz(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var quiz = _unitOfWork.Quiz.GetT(x => x.Id == id);
            if (quiz == null)
            {
                return NotFound();
            }
            _unitOfWork.Quiz.Delete(quiz);
            _unitOfWork.Save();
            return Ok(quiz);
        }
    }
}
