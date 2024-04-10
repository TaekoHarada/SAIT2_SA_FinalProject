
namespace SAFinalProject.Models
{
	public class Equipment
	{
		public string EquipmentId { get; set; }	
		public string CategoryId { get; set; }
		public string EquipmentName { get; set; }
		public string Description { get; set; }
		public double DailyRentalCost { get; set; }
		public string StringDailyRentalCost { get; set;}
		public Equipment() { }
	}
}
