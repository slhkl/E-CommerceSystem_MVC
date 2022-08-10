using Business.Business;
using Business.Session;
using Data.Dto;
using E_CommerceSystem.Validation;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    public class SessionController : Controller
    {
        private ILoginService _loginService;
        private CustomerBusiness _customerBusiness;

        public SessionController(ILoginService loginService)
        {
            _loginService = loginService;
            _customerBusiness = new CustomerBusiness();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            if (_loginService.Login(loginDto))
                if (HttpContext.Session.GetString("SessionType") == "Manager")
                    return RedirectToAction("Index", "Product");
                else
                    return RedirectToAction("Index", "Shop");
            else
                return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Logout")]
        public IActionResult Logout()
        {
            _loginService.LogOut();
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("Register")]
        public IActionResult PageContentForRegister()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        public IActionResult Register(CustomerDto customer)
        {
            CustomerValidator.ValidateCustomerForAdd(_customerBusiness, customer, ModelState);

            if (ModelState.IsValid)
            {
                _customerBusiness.Add(customer);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
