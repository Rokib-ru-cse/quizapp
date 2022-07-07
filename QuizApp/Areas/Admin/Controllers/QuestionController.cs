using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public QuestionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_unitOfWork.Question.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Question.Add(question);
            _unitOfWork.Save();
            return Ok("Question created successfully");
        }

        [HttpPut]
        public IActionResult Update(Question question)
        {
            if (!ModelState.IsValid)
            {
                return Ok("Values are not correct");
            }
            _unitOfWork.Question.Update(question);
            _unitOfWork.Save();
            return Ok("Question Updated Successfully");
        }


        //[HttpGet("{id}")]
        //public IActionResult Get(long id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var question = _unitOfWork.Question.GetT(x => x.Id == id);
        //    if (question == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(question);
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var question = _unitOfWork.Question.GetT(x => x.Id == id);
            if (question == null)
            {
                return NotFound();
            }
            _unitOfWork.Question.Delete(question);
            _unitOfWork.Save();
            return Ok(question);
        }


    }
}
