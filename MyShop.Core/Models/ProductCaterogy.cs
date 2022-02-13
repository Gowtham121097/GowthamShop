using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class ProductCaterogy: BaseEntity
    {
        //public string Id { get; set; } //Commented out after Inherting BaseEntity class since it has an ID already
        public string Category { get; set; }

        //public ProductCaterogy()  //Commenting out since Base entity will take care of ID and ID Generation
        //{
        //    this.Id = Guid.NewGuid().ToString();
        //}
    }
}
