using EducationalSoft.Business.Repositories;
using EducationalSoft.Model.Entities;
using System.Net;
using System.Web.Mvc;

namespace EducationalSoft.Ui.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        //GET: Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Registration(User user)
        {
            if(!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            var hasLoggedIn = _authRepository.Register(user, user.Password);
            return RedirectToAction("Index", "Home");
        }
    }
}