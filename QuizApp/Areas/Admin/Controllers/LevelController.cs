using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LevelController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LevelController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_unitOfWork.Level.GetAll());
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            Level level = _unitOfWork.Level.GetT(x => x.Id == id);
            LevelViewModel model = LevelViewModelFactory.Details(level);
            return View("LevelEditor", model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("LevelEditor", LevelViewModelFactory.Create(new Level()));
        }
        [HttpPost]
        public IActionResult Create(Level level)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Level.Add(level);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(level);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            Level level = _unitOfWork.Level.GetT(x => x.Id == id);
            LevelViewModel model = LevelViewModelFactory.Edit(level);
            return View("LevelEditor", model);

        }
        [HttpPost]
        public IActionResult Edit([FromForm] Level level)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Level.Update(level);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(level);
        }
        public IActionResult Delete(long id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var level = _unitOfWork.Level.GetT(x => x.Id == id);
            if (level == null)
            {
                return RedirectToAction("Index");
            }
            _unitOfWork.Level.Delete(level);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
