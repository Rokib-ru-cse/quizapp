using Microsoft.AspNetCore.Mvc;
using QuizApp.DataAccessLayer.Infrastructure.IRepository;
using QuizApp.Models;
using QuizApp.Models.ViewModels;

namespace QuizApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_unitOfWork.Subject.GetAll());
        }

        [HttpGet]
        public IActionResult Details(long id)
        {
            Subject subject = _unitOfWork.Subject.GetT(x => x.Id == id);
            SubjectViewModel model = SubjectViewModelFactory.Details(subject);
            return View("SubjectEditor", model);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("SubjectEditor", SubjectViewModelFactory.Create(new Subject()));
        }
        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Add(subject);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(subject);
        }
        [HttpGet]
        public IActionResult Edit(long id)
        {
            Subject subject = _unitOfWork.Subject.GetT(x => x.Id == id);
            SubjectViewModel model = SubjectViewModelFactory.Edit(subject);
            return View("SubjectEditor", model);

        }
        [HttpPost]
        public IActionResult Edit([FromForm] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Subject.Update(subject);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(subject);
        }
        public IActionResult Delete(long id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var subject = _unitOfWork.Subject.GetT(x => x.Id == id);
            if (subject == null)
            {
                return RedirectToAction("Index");
            }
            _unitOfWork.Subject.Delete(subject);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
