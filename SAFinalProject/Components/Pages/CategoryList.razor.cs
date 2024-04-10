using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;

namespace SAFinalProject.Components.Pages
{
	public partial class CategoryList : ComponentBase
	{
		[Inject] NavigationManager NavigationManager { get; set; }

		private CategoryDBAccesor categoryDBAccesor = new CategoryDBAccesor();
		public List<Category> categories = new List<Category>();


		protected override void OnInitialized()
		{
			categories = categoryDBAccesor.SelectAllCategories();
		}

		private void AddCategoryHandler()
		{
			NavigationManager.NavigateTo("/addCategory");
		}
		private void EditCategoryHandler(Category category)
		{
			NavigationManager.NavigateTo($"/editCategory/{category.CategoryId}");

		}
		private void DeleteCategoryHandler(Category category) {
			categoryDBAccesor.DeleteCategory(category.CategoryId);
			OnInitialized();
		}
	}
}
