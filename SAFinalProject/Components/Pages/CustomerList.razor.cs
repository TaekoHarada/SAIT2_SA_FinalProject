using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;
using static System.Reflection.Metadata.BlobBuilder;

namespace SAFinalProject.Components.Pages
{
    public partial class CustomerList : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        private CustomerDBAccesor customerDBAccessor = new CustomerDBAccesor();
        public List<Customer> customers = new List<Customer>();

        // for searching
        private string LastName { get; set; } = "";
        private string FirstName { get; set; } = "";

        protected override void OnInitialized()
        {
            customers = customerDBAccessor.SelectCustomersByName(LastName, FirstName);
        }

        private void SearchCustomer()
        {
            customers = customerDBAccessor.SelectCustomersByName(LastName, FirstName);
        }
    
        private void EditCustomer(Customer customer)
        {
            NavigationManager.NavigateTo($"/editcustomer/{customer.CustomerId}");
        }

        private void AddCustomer()
        {
			NavigationManager.NavigateTo($"/addcustomer");
 
		}

	}


}
