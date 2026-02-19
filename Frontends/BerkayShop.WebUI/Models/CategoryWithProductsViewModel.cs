using BerkayShop.DtoLayer.CatalogDtos.CategoryDtos;
using BerkayShop.DtoLayer.CatalogDtos.ProductDtos;

namespace BerkayShop.WebUI.Models
{
    public class CategoryWithProductsViewModel
    {
            public List<ResultCategoryDto> Categories { get; set; }
            public List<ResultProductDto> Products { get; set; }
    }
}
