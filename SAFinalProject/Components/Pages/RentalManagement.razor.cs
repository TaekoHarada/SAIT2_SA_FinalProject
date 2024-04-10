using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class RentalManagement : ComponentBase
	{
		[Parameter]
		public string CustomerId { get; set; }

		private RentalInformation rentalInformation;


		[Inject] NavigationManager NavigationManager { get; set; }

		private Customer customer;

		public List<Equipment> equipments = new List<Equipment>();
		public List<RentalEquipment> rentalEquipments = new List<RentalEquipment>();

		private CustomerDBAccesor customerDBAccessor = new CustomerDBAccesor();
		private EquipmentDBAccesor equipmentDBAccessor = new EquipmentDBAccesor();
		private RentalInformationDBAccesor rentalInformationDBAccesor = new RentalInformationDBAccesor();
		private RentalEquipmentDBAccesor rentalEquipmentDBAccesor = new RentalEquipmentDBAccesor();

		protected override void OnInitialized()
		{
			customer = customerDBAccessor.SelectCustomersById(CustomerId);
			equipments = equipmentDBAccessor.SelectAllEquipments();

			rentalInformation = new RentalInformation
			{
				RentalId = Guid.NewGuid().ToString(),
			};

			// select RentalId from RentalInformation by CustomerID
			string existRentalId = rentalInformationDBAccesor.SelectRentalInformationByCustomerId(CustomerId).RentalId;
			if (existRentalId != null)
			{
				rentalInformation.RentalId = existRentalId;
			}
			// select rental equipment list
			rentalEquipments = rentalEquipmentDBAccesor.SelectRentalEquipmentsByRentalId(rentalInformation.RentalId);

		}


		private async Task ConfirmEquipmentHandler(RentalEquipment rentalEquipment)
		{
			await rentalEquipmentDBAccesor.UpdateStatus(rentalEquipment, 1);

			// re-render
			rentalEquipments = rentalEquipmentDBAccesor.SelectRentalEquipmentsByRentalId(rentalInformation.RentalId);

		}

		private async Task ReturnEquipmentHandler(RentalEquipment rentalEquipment)
		{
			await rentalEquipmentDBAccesor.UpdateStatus(rentalEquipment, 2);

			// re-render
			rentalEquipments = rentalEquipmentDBAccesor.SelectRentalEquipmentsByRentalId(rentalInformation.RentalId);

		}

		private void ReturnPageHandler()
		{
			NavigationManager.NavigateTo("/rentalManagementCustomerList");
		}


	}
}
