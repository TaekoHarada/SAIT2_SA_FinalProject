using Microsoft.AspNetCore.Components;
using SAFinalProject.Models;
using SAFinalProject.Database;
using static System.Reflection.Metadata.BlobBuilder;

namespace SAFinalProject.Components.Pages
{
    public partial class EquipmentList : ComponentBase
    {
        [Inject] NavigationManager NavigationManager { get; set; }

        private EquipmentDBAccesor equipmentDBAccessor = new EquipmentDBAccesor();
        public List<Equipment> equipments = new List<Equipment>();

        // for searching
        private string Name { get; set; } = "";

        protected override void OnInitialized()
        {
			equipments = equipmentDBAccessor.SelectAllEquipments();
        }

        private void SearchEquipmentHandler()
        {
			equipments = equipmentDBAccessor.SelectEquipmentsByName(Name);
        }
    
        private void EditEquipmentHandler(Equipment equipment)
        {
            NavigationManager.NavigateTo($"/editequipment/{equipment.EquipmentId}");
        }
		private void DeleteEquipmentHandler(Equipment equipment)
		{
			equipmentDBAccessor.DeleteEquipment(equipment.EquipmentId);
            OnInitialized();
		}

		private void AddEquipment()
        {
			NavigationManager.NavigateTo("/addequipment");
 
		}

	}


}
