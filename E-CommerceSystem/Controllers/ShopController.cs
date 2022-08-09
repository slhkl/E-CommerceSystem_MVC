using Business.Business;
using Data.Dto;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceSystem.Controllers
{
    public class ShopController : Controller
    {
        ProductBusiness _productBusiness;
        CategoryBusiness _categoryBusiness;
        CartBusiness _cartBusiness;

        public ShopController()
        {
            _productBusiness = new ProductBusiness();
            _categoryBusiness = new CategoryBusiness();
            _cartBusiness = new CartBusiness();
        }

        public IActionResult Index()
        {
            var tupleModel = new Tuple<List<CategoryDto>, List<ProductDtoForShop>>(_categoryBusiness.GetDto(), _productBusiness.GetDtoForShop());
            return View(tupleModel);
        }

        [HttpGet, ActionName("SingleProduct")]
        public IActionResult PageContentForSingleProduct(int id)
        {
            return View(_productBusiness.GetDtoForShop(id));
        }

        [HttpGet, ActionName("Cart")]
        public IActionResult PageContentForCart()
        {
            var cart = _cartBusiness.GetDto("0");
            if (cart == null)
                return RedirectToAction("Index");
            return View(cart);
        }

        [HttpGet, ActionName("AddToCart")]
        public IActionResult AddProductToCart(int id)
        {
            //todo session eklenince düzeltilecek.
            _cartBusiness.Add(_productBusiness.GetDtoForShop(id), "0");
            return RedirectToAction("Cart");
        }
        [HttpGet, ActionName("DeleteFromDatabase")]
        public IActionResult DeleteProductFromDatabase(int id)
        {
            _cartBusiness.Delete(id, "0");
            return RedirectToAction("Cart");
        }

    }
}
