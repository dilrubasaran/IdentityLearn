using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace identity_singup.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string? AreaName {get; set;}
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Icon { get; set; }
        public int SortNumber { get; set; }
        public string? Description { get; set; }
        public string Role { get; set; }

        // Todo: bu şuan menunun seçılme durumundan bahsediyor aktif  pasif durumu değil
        public bool IsActive { get; set; }


        // Navigation properties for parent-child relationship
        public MenuItem Parent { get; set; }
        public List<MenuItem> Children { get; set; } = new List<MenuItem>();

         
        //Menu seçilimi 
        [NotMapped]
        public bool IsSelected { get; set; }

        // Alt menü öğeleri (veritabanında saklanmaz)
        [NotMapped]
        public List<MenuItem> SubMenuItems { get; set; } = new List<MenuItem>();
    }
}