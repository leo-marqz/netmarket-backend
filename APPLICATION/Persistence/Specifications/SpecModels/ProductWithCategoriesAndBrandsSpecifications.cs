

using DOMAIN.Models;

namespace APPLICATION.Persistence.Specifications.SpecModels
{
    public class ProductWithCategoriesAndBrandsSpecifications : BaseSpecification<Product>
    {
        public ProductWithCategoriesAndBrandsSpecifications()
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }

        public ProductWithCategoriesAndBrandsSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }

        public ProductWithCategoriesAndBrandsSpecifications(string name) : base(x => x.Name == name)
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Brand);
        }
    }
}
