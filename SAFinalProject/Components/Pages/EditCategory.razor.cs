using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class EditCategory : ComponentBase
	{
		private Category category;

		// To show message
		private bool isSaved = false;

		[Parameter]
		public string CategoryId { get; set; }

		[Inject] NavigationManager NavigationManager { get; set; }

		private CategoryDBAccesor categoryDBAccesor = new CategoryDBAccesor();

		protected override void OnInitialized()
		{
			category = categoryDBAccesor.SelectCategoryById(CategoryId);
		}

		private async Task UpdateCategoryHandler()
		{
			if (category != null)
			{
				await categoryDBAccesor.UpdateCategory(category);
				isSaved = true;
			}
		}

		private void ReturnPageHandler()
		{
			NavigationManager.NavigateTo("/categoryList");
		}


	}
}
