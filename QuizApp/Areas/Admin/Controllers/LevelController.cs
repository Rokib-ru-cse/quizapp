using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Level.GetAll());
        }

        [HttpPost]
        public IActionResult Add(Level level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Level.Add(level);
            _unitOfWork.Save();
            return Ok("Level created successfully");
        }
        [HttpPut]
        public IActionResult Update(Level level)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Values are not correct");
            }
            _unitOfWork.Level.Update(level);
            _unitOfWork.Save();
            return Ok("Level updated successfully");
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var level = _unitOfWork.Level.GetT(x => x.Id == id);
            if (level == null)
            {
                return NotFound();
            }
            return Ok(level);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteLevel(long id = 0)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var level = _unitOfWork.Level.GetT(x => x.Id == id);
            if (level == null)
            {
                return NotFound();
            }
            _unitOfWork.Level.Delete(level);
            _unitOfWork.Save();
            return Ok(level);
        }

    }
}
