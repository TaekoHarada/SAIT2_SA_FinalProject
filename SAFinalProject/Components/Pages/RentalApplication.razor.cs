using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;
using System.Xml.Linq;


namespace SAFinalProject.Components.Pages
{
	public partial class RentalApplication : ComponentBase
	{

		[Parameter]
		public string CustomerId { get; set; }

		private RentalInformation rentalInformation;

		private string EquipmentName { get; set; } = "";

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

		private void SearchEquipmentHandler()
		{
			equipments = equipmentDBAccessor.SelectEquipmentsByName(EquipmentName);
		}

		private async Task RentalEquipmentHandler(Equipment rentalEquipment)
		{
			// If 'RentalId' is not exist on RentalInformation table, Insert a new row.
			RentalInformation selectedRentalInformation = rentalInformationDBAccesor.SelectRentalInformationById(rentalInformation.RentalId);

			if (selectedRentalInformation.CustomerId == null)
			{
				rentalInformation.CurrentDate = DateTime.Now;
				rentalInformation.CustomerId = CustomerId;
				rentalInformation.TotalCost = 0.0;
				rentalInformation.TotalRentalStatus = 0;

				await rentalInformationDBAccesor.InsertRentalInformation(rentalInformation);
			}

			// Insert to RentalEquipment table
			RentalEquipment newRentalEquipment = new RentalEquipment(
				rentalEquipmentId: Guid.NewGuid().ToString(),
				rentalId: rentalInformation.RentalId,
				equipmentId: rentalEquipment.EquipmentId,
				equipmentName: rentalEquipment.EquipmentName,
				rentalDate: DateTime.Now,
				rentalCost: rentalEquipment.DailyRentalCost,
				rentalStatus: 0
			);

			await rentalEquipmentDBAccesor.InsertRentalEquipment(newRentalEquipment);

			// Update the total cost of RentalInformation table
			RentalInformation updateRentalInformation = rentalInformationDBAccesor.SelectRentalInformationById(rentalInformation.RentalId);
			updateRentalInformation.TotalCost += rentalEquipment.DailyRentalCost;
			await rentalInformationDBAccesor.UpdateRentalInformation(updateRentalInformation);

			// Show a new rental list
			rentalEquipments = rentalEquipmentDBAccesor.SelectRentalEquipmentsByRentalId(rentalInformation.RentalId);

		}

		private async Task DeleteEquipmentHandler(RentalEquipment rentalEquipment)
		{
			await rentalEquipmentDBAccesor.DeleteRentalEquipment(rentalEquipment.RentalEquipmentId);

			// re-render
			rentalEquipments = rentalEquipmentDBAccesor.SelectRentalEquipmentsByRentalId(rentalInformation.RentalId);
		}

		private void ReturnPageHandler()
		{
			NavigationManager.NavigateTo("/rentalApplicationCustomerList");
		}


	}
}
