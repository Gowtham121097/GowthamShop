using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
   public class Product : BaseEntity
    {
        // public string Id { get; set; }    //Commented out after Inherting BaseEntity class since it has an ID already

        [StringLength(20)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }

        [Range(0,1000)]
        public decimal Price { get; set; }

        //public Product() {  //Commenting out since Base entity will take care of ID and ID Generation
        //    this.Id = Guid.NewGuid().ToString();
        //}



    }
}
