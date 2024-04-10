using System.Net;
using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class AddCustomer : ComponentBase
	{
		private Customer customer;
		// To show message
		private bool isSaved = false;

		[Inject] NavigationManager NavigationManager { get; set; }

		private CustomerDBAccesor customerDBAccessor = new CustomerDBAccesor();

		protected override void OnInitialized()
		{
			customer = new Customer
			{
				CustomerId = Guid.NewGuid().ToString(),
			};
		}


		private async Task AddCustomerHandler()
		{
			if (customer != null)
			{
				await customerDBAccessor.InsertCustomer(customer);
				isSaved = true;
			}
		}

		private void ReturnPageHandler() 
		{
			NavigationManager.NavigateTo("/customerList");
		}

	}
}
