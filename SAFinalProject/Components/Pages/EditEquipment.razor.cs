using System.Net;
using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;


namespace SAFinalProject.Components.Pages
{
	public partial class EditEquipment : ComponentBase
	{
		private Equipment equipment;
		private List<Category> categories;
		// To show message
		private bool isSaved = false;

		[Parameter]
		public string EquipmentId { get; set; }

		[Inject] NavigationManager NavigationManager { get; set; }

		private EquipmentDBAccesor equipmentDBAccesor = new EquipmentDBAccesor();
		private CategoryDBAccesor categoryDBAccesor=new CategoryDBAccesor();

		protected override void OnInitialized()
		{
			equipment = equipmentDBAccesor.SelectEquipmentById(EquipmentId);
			equipment.StringDailyRentalCost = equipment.DailyRentalCost.ToString();
			categories = categoryDBAccesor.SelectAllCategories();
		}

		private async Task UpdateEquipmentHandler()
		{
			if (equipment != null)
			{
				equipment.DailyRentalCost = Convert.ToDouble(equipment.StringDailyRentalCost);
				await equipmentDBAccesor.UpdateEquipment(equipment);
				isSaved = true;
			}
		}

		private void ReturnPageHandler()
		{
			NavigationManager.NavigateTo("/equipmentList");
		}
	}
}
