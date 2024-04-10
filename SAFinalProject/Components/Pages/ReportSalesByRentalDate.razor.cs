using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class ReportSalesByRentalDate : ComponentBase
	{
		[Inject] NavigationManager NavigationManager { get; set; }

		private RentalEquipmentDBAccesor rentalEquipmentDBAccesor = new RentalEquipmentDBAccesor();

		public List<SalesByRentalDate> salesByRentalDateList = new List<SalesByRentalDate>();

		protected override void OnInitialized()
		{
			salesByRentalDateList = rentalEquipmentDBAccesor.SelectSalesByRentalDate();
		}

	}
}
