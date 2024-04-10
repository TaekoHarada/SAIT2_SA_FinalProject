using Dapper;
using SAFinalProject.Models;

namespace SAFinalProject.Database
{
	public class RentalInformationDBAccesor : DBAccessor
	{

		public RentalInformation SelectRentalInformationById(string RentalId)
		{
			RentalInformation rentalInformation = new RentalInformation();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM RentalInformation WHERE RentalId='{RentalId}'";

				rentalInformation = connection.QuerySingle<RentalInformation>(sql);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}
			return rentalInformation;
		}

		public RentalInformation SelectRentalInformationByCustomerId(string CustomerId)
		{
			RentalInformation rentalInformation = new RentalInformation();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM RentalInformation WHERE CustomerId='{CustomerId}'";

				rentalInformation = connection.QuerySingle<RentalInformation>(sql);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}
			return rentalInformation;
		}

		public Task InsertRentalInformation(RentalInformation rentalInformation)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "Insert INTO RentalInformation (RentalId, CurrentDate, CustomerId, TotalCost, TotalRentalStatus) VALUES (@RentalId, @CurrentDate, @CustomerId, @TotalCost, @TotalRentalStatus)";

				rowNum = connection.Execute(sql, rentalInformation);
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

		public Task UpdateRentalInformation(RentalInformation rentalInformation)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "UPDATE RentalInformation SET TotalCost=@TotalCost, TotalRentalStatus=@TotalRentalStatus";

				rowNum = connection.Execute(sql, rentalInformation);
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
