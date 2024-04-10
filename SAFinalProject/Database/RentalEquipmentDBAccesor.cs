using System.Collections.Generic;
using System.Net;
using Dapper;
using SAFinalProject.Models;

namespace SAFinalProject.Database
{
	public class RentalEquipmentDBAccesor : DBAccessor
	{
		public List<RentalEquipment> SelectRentalEquipmentsByRentalId(string rentalId)
		{
			List<RentalEquipment> rentalEquipments = new List<RentalEquipment>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM RentalEquipment WHERE RentalId=@RentalId";

				rentalEquipments = connection.Query<RentalEquipment>(sql, new { RentalId = rentalId }).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return rentalEquipments;
		}

		public Task InsertRentalEquipment(RentalEquipment rentalEquipment)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "Insert INTO RentalEquipment (RentalEquipmentId, RentalId, EquipmentId, EquipmentName, RentalDate, RentalCost, RentalStatus) VALUES (@RentalEquipmentId, @RentalId, @EquipmentId, @EquipmentName, @RentalDate, @RentalCost, @RentalStatus)";

				rowNum = connection.Execute(sql, rentalEquipment);
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

		public Task DeleteRentalEquipment(string rentalEquipmentId)
		{
			try
			{
				connection.Open();

				string sql = $"DELETE FROM RentalEquipment WHERE RentalEquipmentId = '{rentalEquipmentId}'";

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

		public Task UpdateStatus(RentalEquipment rentalEquipment, int rentalStatus)
		{
			int rowNum = 0;
			string sql = "";
			try
			{
				connection.Open();

				if (rentalStatus == 1)
				{
					sql = "UPDATE rentalEquipment SET RentalStatus=1 WHERE RentalEquipmentId=@RentalEquipmentId";
				}
				else if (rentalStatus == 2)
				{
					sql = "UPDATE rentalEquipment SET RentalStatus=2, ReturnDate=NOW() WHERE RentalEquipmentId=@RentalEquipmentId";
				}

				rowNum = connection.Execute(sql, rentalEquipment);
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

		public List<SalesByRentalDate> SelectSalesByRentalDate()
		{
			List<SalesByRentalDate> salesByRentalDateList = new List<SalesByRentalDate>();

			try
			{
				connection.Open();

				string sql = "SELECT DATE(RentalDate) AS RentalDate, SUM(RentalCost) AS Cost FROM rentalequipment GROUP BY  DATE(RentalDate)";

				salesByRentalDateList = connection.Query<SalesByRentalDate>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return salesByRentalDateList;
		}
		public List<SalesByCustomer> SelectSalesByCustomer()
		{
			List<SalesByCustomer> salesByCustomerList = new List<SalesByCustomer>();

			try
			{
				connection.Open();

				string sql = "SELECT customer.CustomerId AS CustomerId, customer.LastName AS LastName, customer.FirstName AS FirstName, SUM(rentalequipment.RentalCost) AS Cost FROM customer JOIN rentalInformation ON customer.CustomerID=rentalInformation.CustomerID JOIN rentalequipment ON rentalinformation.RentalId=rentalequipment.RentalId GROUP BY CustomerId";

				salesByCustomerList = connection.Query<SalesByCustomer>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return salesByCustomerList;
		}
	}
}
