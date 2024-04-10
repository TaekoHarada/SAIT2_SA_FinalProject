
namespace SAFinalProject.Models
{
	public class Customer
	{
		public string CustomerId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public Customer() { }
		public Customer(string customerId,
			string lastName,
			string firstName,
			string phone,
			string email)
		{
			CustomerId = customerId;
			LastName = lastName;
			FirstName = firstName;
			Phone = phone;
			Email = email;

		}
	}
}
