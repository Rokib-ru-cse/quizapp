using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ResultController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Result.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Result.Add(result);
            _unitOfWork.Save();
            return Ok("Result create successfully");
        }

        [HttpPut]
        public IActionResult Update(Result result)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Result.Update(result);
            _unitOfWork.Save();
            return Ok("Result updated successfully");
        }


        [HttpGet("{id}")]
        public IActionResult Get(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var result = _unitOfWork.Result.GetT(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteResult(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var result = _unitOfWork.Result.GetT(x => x.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            _unitOfWork.Result.Delete(result);
            _unitOfWork.Save();
            return Ok(result);
        }
    }
}
