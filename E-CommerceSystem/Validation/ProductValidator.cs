using Business.Business;
using Data.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_CommerceSystem.Validation
{
    public class ProductValidator
    {
        public static void ValidateProductForAdd(ProductBusiness productBusiness, ProductDtoForAdd product, ModelStateDictionary modelState)
        {
            if (product.ProductId <= 0 || productBusiness.Get(product.ProductId) != null)
                modelState.AddModelError("productId", "Product Id should be special and over 0");

            if (String.IsNullOrEmpty(product.ProductName))
                modelState.AddModelError("productName", "Product Name can't to be empty");

            if (product.ProductFile == null)
                modelState.AddModelError("productFile", "Choose a picture");

            if (product.ProductStock < 0)
                modelState.AddModelError("productStock", "Product stock cant be under 0");

            //if (productBusiness.Get(cate) == null)
            //    modelState.AddModelError("categoryId", "There isn't a category please check category id");
        }
    }
}
