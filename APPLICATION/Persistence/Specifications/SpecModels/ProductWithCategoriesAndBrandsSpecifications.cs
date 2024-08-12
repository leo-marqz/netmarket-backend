using DOMAIN.Models;

namespace APPLICATION.Persistence.Specifications.SpecModels
{
    public class ProductWithCategoriesAndBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductWithCategoriesAndBrandsSpecifications(ProductParamsSpecifications productParams) 
            : base(x => (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
                        (!productParams.Category.HasValue || x.CategoryId == productParams.Category) &&
                        (!productParams.Brand.HasValue || x.BrandId == productParams.Brand)   
            )
        {
            addInclude(x => x.Category);
            addInclude(x => x.Brand);

            applyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            setOrderBy(productParams.Sort);
        }


        public ProductWithCategoriesAndBrandsSpecifications(int id) : base(x => x.Id == id)
        {
            addInclude(x => x.Category);
            addInclude(x => x.Brand);
        }

        public ProductWithCategoriesAndBrandsSpecifications(string name) : base(x => x.Name == name)
        {
            addInclude(x => x.Category);
            addInclude(x => x.Brand);
        }

        private void setOrderBy(string sort)
        {
            switch (sort)
            {
                case "price_asc":
                    AddOrderBy(x => x.Price);
                    break;
                case "price_desc":
                    AddOrderByDescending(x => x.Price);
                    break;
                case "name_desc":
                    AddOrderByDescending(x => x.Name);
                    break;
                case "name_asc":
                    AddOrderBy(x => x.Name);
                    break;
                case "id_desc":
                    AddOrderByDescending(x => x.Id);
                    break;
                default:
                    AddOrderBy(x => x.Id);
                    break;
            }
        }
    }
}
