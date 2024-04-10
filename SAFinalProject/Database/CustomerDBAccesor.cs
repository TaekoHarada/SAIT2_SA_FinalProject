using System.Net;
using System.Runtime.CompilerServices;
using Dapper;
using SAFinalProject.Models;

namespace SAFinalProject.Database
{
	public class CustomerDBAccesor : DBAccessor
	{
		public List<Customer> SelectAllCustomers()
		{
			List<Customer> customers = new List<Customer>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM customer";

				customers = connection.Query<Customer>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return customers;
		}

		public List<Customer> SelectCustomersByName(string lastName, string firstName)
		{
			List<Customer> customers = new List<Customer>();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM customer WHERE lastName LIKE '{lastName}%' AND firstName LIKE '{firstName}%'";

				customers = connection.Query<Customer>(sql).ToList();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}

			return customers;
		}

		public Customer SelectCustomersById(string customerId)
		{
			Customer customer = new Customer();

			try
			{
				connection.Open();

				string sql = $"SELECT * FROM customer WHERE CustomerId='{customerId}'";

				customer = connection.QuerySingle<Customer>(sql);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error:" + ex.Message);
			}
			finally
			{
				connection.Close();
			}
			return customer;
		}


		public Task UpdateCustomer(Customer customer)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "UPDATE customer SET CustomerId=@CustomerId, LastName=@LastName, FirstName=@FirstName, Phone=@Phone, Email=@Email WHERE CustomerId=@CustomerId";

				 rowNum = connection.Execute(sql, customer);
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

		public Task InsertCustomer(Customer customer)
		{
			int rowNum = 0;
			try
			{
				connection.Open();

				string sql = "Insert INTO customer (CustomerId, LastName, FirstName, Phone, Email) VALUES (@CustomerId, @LastName, @FirstName, @Phone, @Email)";

				rowNum = connection.Execute(sql, customer);
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
