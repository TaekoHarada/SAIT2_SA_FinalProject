namespace SAFinalProject.Models
{
	public class RentalInformation
	{
		public string RentalId { get; set; }
		public DateTime CurrentDate { get; set; }

		public string CustomerId { get; set; }
		public double TotalCost {  get; set; }
		public int TotalRentalStatus { get; set; }
		public RentalInformation() { }
	}
}
