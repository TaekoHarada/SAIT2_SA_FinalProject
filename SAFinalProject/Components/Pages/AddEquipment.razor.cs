using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class AddEquipment : ComponentBase
	{
		private Equipment equipment=new Equipment();

		private List<Category> categories;
		// To show message
		private bool isSaved = false;


		[Inject] NavigationManager NavigationManager { get; set; }

		private EquipmentDBAccesor equipmentDBAccesor = new EquipmentDBAccesor();
		private CategoryDBAccesor categoryDBAccesor = new CategoryDBAccesor();

		protected override void OnInitialized()
		{
			categories = categoryDBAccesor.SelectAllCategories();

		}


		private async Task AddEquipmentHandler()
		{
			if (equipment != null)
			{
				equipment.DailyRentalCost = Convert.ToDouble(equipment.StringDailyRentalCost);
				await equipmentDBAccesor.InsertEquipment(equipment);
				isSaved = true;
			}
		}

		private void ReturnPageHandler()
		{
			NavigationManager.NavigateTo("/equipmentList");
		}

	}
}
