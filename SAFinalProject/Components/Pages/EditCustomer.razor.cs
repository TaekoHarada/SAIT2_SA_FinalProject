using System.Net;
using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class EditCustomer : ComponentBase
	{
		private Customer customer;
		// To show message
		private bool isSaved = false;

		[Parameter]
		public string CustomerId { get; set; }

		[Inject] NavigationManager NavigationManager { get; set; }

		private CustomerDBAccesor customerDBAccessor = new CustomerDBAccesor();

		protected override void OnInitialized()
		{
			customer = customerDBAccessor.SelectCustomersById(CustomerId);
		}


		private async Task UpdateCustomerHandler()
		{
			if (customer != null)
			{
				await customerDBAccessor.UpdateCustomer(customer);
				isSaved = true;
			}
		}

		private void ReturnPageHandler() 
		{
			NavigationManager.NavigateTo("/customerList");
		}

	}
}
