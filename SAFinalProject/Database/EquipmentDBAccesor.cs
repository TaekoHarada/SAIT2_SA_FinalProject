using System.Net;
using System.Runtime.CompilerServices;
using Dapper;
using SAFinalProject.Models;

namespace SAFinalProject.Database
{
	public class EquipmentDBAccesor : DBAccessor
	{
		public List<Equipment> SelectAllEquipments()
		{
			List<Equipment> equipments = new List<Equipment>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM Equipment";

				equipments = connection.Query<Equipment>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return equipments;
		}

		public List<Equipment> SelectEquipmentsByName(string name)
		{
			List<Equipment> equipments = new List<Equipment>();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM Equipment WHERE EquipmentName LIKE '{name}%'";

				equipments = connection.Query<Equipment>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return equipments;
		}

		public Equipment SelectEquipmentById(string equipmentId)
		{
			Equipment equipment = new Equipment();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM Equipment WHERE EquipmentId='{equipmentId}'";

				equipment = connection.QuerySingle<Equipment>(sql);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}
			return equipment;
		}


		public Task UpdateEquipment(Equipment equipment)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "UPDATE Equipment SET EquipmentId=@EquipmentId, CategoryId=@CategoryId, EquipmentName=@EquipmentName, Description=@Description, DailyRentalCost=@DailyRentalCost WHERE EquipmentId=@EquipmentId";

				rowNum = connection.Execute(sql, equipment);
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

		public Task InsertEquipment(Equipment equipment)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "Insert INTO Equipment (EquipmentId, CategoryId, EquipmentName, Description, DailyRentalCost) VALUES (@EquipmentId, @CategoryId, @EquipmentName, @Description, @DailyRentalCost)";

				rowNum = connection.Execute(sql, equipment);
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

		public Task DeleteEquipment(string equipmentId)
		{
			try
			{
				connection.Open();

				string sql = $"DELETE FROM Equipment WHERE EquipmentId = '{equipmentId}'";

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
