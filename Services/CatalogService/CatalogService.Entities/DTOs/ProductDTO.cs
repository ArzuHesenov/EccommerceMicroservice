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
        public record ProductAddDTO(string Name,decimal Price,string Description,string SubCategoryId,List<FeatureDTO> Features);
        public record ProductGetById(string Name,decimal Price,string Description,string SubCategoryName,List<FeatureDTO> Features);
    }
}
