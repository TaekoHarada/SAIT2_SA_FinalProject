using System.Net;
using System.Runtime.CompilerServices;
using Dapper;
using SAFinalProject.Models;

namespace SAFinalProject.Database
{
	public class CategoryDBAccesor : DBAccessor
	{
		public List<Category> SelectAllCategories()
		{
			List<Category> categories = new List<Category>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM Category";

				categories = connection.Query<Category>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return categories;
		}

		public Category SelectCategoryById(string categoryId)
		{
			Category category = new Category();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM Category WHERE categoryId='{categoryId}'";

				category = connection.QuerySingle<Category>(sql);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}
			return category;
		}


		public Task UpdateCategory(Category category)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "UPDATE Category SET CategoryId=@CategoryId, CategoryName=@CategoryName WHERE CategoryId=@CategoryId";

				rowNum = connection.Execute(sql, category);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return Task.CompletedTask;
		}

		public Task InsertCategory(Category category)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "Insert INTO Category (CategoryId, CategoryName) VALUES (@CategoryId, @CategoryName)";

				rowNum = connection.Execute(sql, category);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return Task.CompletedTask;

		}

		public Task DeleteCategory(string categoryId)
		{
			try
			{
				connection.Open();

				string sql = $"DELETE FROM category WHERE CategoryId = '{categoryId}'";

				connection.Execute(sql);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return Task.CompletedTask;
		}



	}
}
