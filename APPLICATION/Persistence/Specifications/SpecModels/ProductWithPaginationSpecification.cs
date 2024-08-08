using DOMAIN.Models;

namespace APPLICATION.Persistence.Specifications.SpecModels
{
    public class ProductWithPaginationSpecification : BaseSpecification<Product>
    {
        public ProductWithPaginationSpecification(ProductParamsSpecifications productParams)
            
            : base(x => (!productParams.Category.HasValue || x.CategoryId == productParams.Category) &&
                        (!productParams.Brand.HasValue || x.BrandId == productParams.Brand)
            )
        {

        }
    }
}
