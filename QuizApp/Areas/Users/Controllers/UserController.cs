using Microsoft.AspNetCore.Mvc;

namespace QuizApp.Areas.Users.Controllers
{
    [Area("User")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUnitOfWork _unitOfWork;
        //public UserController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok(_unitOfWork.User.GetAll());
        //}

        //[HttpPost]
        //public IActionResult Add(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Values are not correct");
        //    }
        //    _unitOfWork.User.Add(user);
        //    _unitOfWork.Save();
        //    return Ok("User created successfully");
        //}

        //[HttpPut]
        //public IActionResult Update(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Values are not correct");
        //    }
        //    _unitOfWork.User.Update(user);
        //    _unitOfWork.Save();
        //    return Ok("User updated successfully");
        //}


        //[HttpGet("{id}")]
        //public IActionResult Get(long id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var user = _unitOfWork.User.GetT(x => x.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(user);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteUser(long id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var user = _unitOfWork.User.GetT(x => x.Id == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.User.Delete(user);
        //    _unitOfWork.Save();
        //    return Ok(user);
        //}
    }
}
