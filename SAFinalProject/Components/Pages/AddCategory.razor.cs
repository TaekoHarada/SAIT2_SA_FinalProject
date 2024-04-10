using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;


namespace SAFinalProject.Components.Pages
{
	public partial class AddCategory : ComponentBase
	{
		
		private Category category = new Category();

		// To show message
		private bool isSaved = false;


		[Inject] NavigationManager NavigationManager { get; set; }

		private CategoryDBAccesor categoryDBAccesor = new CategoryDBAccesor();

		protected override void OnInitialized()
		{

		}
		private async Task AddCategoryHandler()
		{
			if (category != null)
			{
				await categoryDBAccesor.InsertCategory(category);
				isSaved = true;
			}
		}

		private void ReturnPageHandler()
		{
			NavigationManager.NavigateTo("/categoryList");
		}

	}
}
