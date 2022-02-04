using System;
using System.Web.Mvc;
using PlaceHolderProject.Repositories.Users;

namespace PlaceHolderProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _repository.GetAll();

            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = _repository.GetById(id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                _repository.Insert(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _repository.GetById(id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                _repository.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _repository.GetById(id);
            return PartialView(user);
        }

        // POST: User/DeleteConfirm/5
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                _repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
