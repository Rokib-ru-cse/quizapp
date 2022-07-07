using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private UserManager<IdentityUser> _userManger;
        public UserController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManger)
        {
            _unitOfWork = unitOfWork;
            _userManger = userManger;
        }
        public IActionResult Index() => View(_userManger.Users.ToList());

        public IActionResult Create()
        {
            var levels = new SelectList(_unitOfWork.Level.GetAll()
            .ToDictionary(us => us.Id, us => us.Name), "Key", "Value");
            ViewBag.Levels = levels;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUser = new IdentityUser { UserName = user.UserName, Email = user.Email };
                IdentityResult result = await _userManger.CreateAsync(newUser, user.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }


        public async Task<IActionResult> Edit(string id)
        {
            IdentityUser user = await _userManger.FindByIdAsync(id);
            UserViewModel userView = new(user);
            return View(userView);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser identityUser = await _userManger.FindByIdAsync(user.Id);
                identityUser.UserName = user.UserName;
                identityUser.Email = user.Email;
                IdentityResult result = await _userManger.UpdateAsync(identityUser);
                if (result.Succeeded && !String.IsNullOrEmpty(user.Password))
                {
                    await _userManger.RemovePasswordAsync(identityUser);
                    result = await _userManger.AddPasswordAsync(identityUser, user.Password);

                }
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(user);
        }

    }
}
