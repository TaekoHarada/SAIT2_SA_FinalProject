namespace SAFinalProject.Models
{
	public class RentalEquipment
	{
		public string RentalEquipmentId { get; set; }
		public string RentalId { get; set; }
		public string EquipmentId { get; set; }
		public string EquipmentName { get; set; }
		public DateTime RentalDate { get; set; }
		public DateTime ReturnDate { get; set; }
		public double RentalCost { get; set; }
		public int RentalStatus { get; set; }

		public RentalEquipment() { }
		public RentalEquipment(
			string rentalEquipmentId,
			string rentalId,
			string equipmentId,
			string equipmentName,
			DateTime rentalDate,
			double rentalCost,
			int rentalStatus)
		{
			RentalEquipmentId = rentalEquipmentId;
			RentalId = rentalId;
			EquipmentId = equipmentId;
			EquipmentName = equipmentName;
			RentalDate = rentalDate;
			RentalCost = rentalCost;
			RentalStatus = rentalStatus;
		}

	}
}
