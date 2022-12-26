using CatalogService.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Entities.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string SubCategoryId { get; set; }
        public List<FeatureDTO> Features { get; set; }
        public List<string> PhotoUrl { get; set; }

       
    }
}
