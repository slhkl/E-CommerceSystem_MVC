using Business.Business;
using Data.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace E_CommerceSystem.Validation
{
    public class CustomerValidator
    {
        public static void ValidateCustomerForAdd(CustomerBusiness customerBusiness, CustomerDto customer, ModelStateDictionary modelState)
        {
            if (customerBusiness.Get(customer.CustomerID, true) != null)
                modelState.AddModelError("customerId", "Customer Id is taken");

            if (string.IsNullOrEmpty(customer.CustomerID))
                modelState.AddModelError("customerId", "Customer Id can't be empty");

            if (string.IsNullOrEmpty(customer.Address))
                modelState.AddModelError("address", "Address can't be empty");

            if (string.IsNullOrEmpty(customer.Name))
                modelState.AddModelError("name", "Name can't be empty");

            if (string.IsNullOrEmpty(customer.Password))
                modelState.AddModelError("password", "Password can't be empty");

            if (string.IsNullOrEmpty(customer.Email))
                modelState.AddModelError("email", "Email can't be empty");

            if (customer.PhoneNumber.ToString().Length != 10)
                modelState.AddModelError("phoneNumber", "Phone Number must be 10 characters");

            if (!customer.PhoneNumber.ToString().StartsWith("5"))
                modelState.AddModelError("phoneNumber", "Please enter x 5XXXXXXXXX format");
        }
    }
}
