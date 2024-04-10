using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class ReportSalesByCustomer : ComponentBase
	{
		[Inject] NavigationManager NavigationManager { get; set; }

		private RentalEquipmentDBAccesor rentalEquipmentDBAccesor = new RentalEquipmentDBAccesor();

		public List<SalesByCustomer> salesByCustomerList = new List<SalesByCustomer>();

		protected override void OnInitialized()
		{
			salesByCustomerList = rentalEquipmentDBAccesor.SelectSalesByCustomer();
		}

	}
}
