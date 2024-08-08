using API.DTOs;
using API.DTOs.Products;
using API.Handlers;
using APPLICATION.Persistence.Contracts;
using APPLICATION.Persistence.Specifications;
using APPLICATION.Persistence.Specifications.SpecModels;
using AutoMapper;
using DOMAIN.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{

    public class ProductsController : BaseApiController
    {
        /// <summary>
        /// IProductRepository repository
        /// </summary>
        private readonly IGenericRepository<Product> repository;
        private IMapper mapper;

        public ProductsController(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            this.repository = genericRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<HttpApiResponse<ProductDto>>> GetProducts([FromQuery] ProductParamsSpecifications productParams)
        {
            ISpecification<Product> specification = new ProductWithCategoriesAndBrandsSpecifications(productParams);
            IReadOnlyList<Product> products = await this.repository.getAllWithSpecificationsAsync(specification);

            ISpecification<Product> specCount = new ProductWithPaginationSpecification(productParams);
            int totalProducts = await this.repository.countAsync(specCount);

            var getPages = Math.Ceiling( Convert.ToDecimal(totalProducts) / Convert.ToDecimal(productParams.PageSize) );
            var totalPages = Convert.ToInt32(getPages);

            List<ProductDto> data = this.mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products)
                .ToList();

            return Ok(new HttpApiResponse<IReadOnlyList<ProductDto>>()
            {
                Count = totalProducts,
                Data = data,
                PageIndex = productParams.PageIndex,
                TotalPages = totalPages,
                PageSize = productParams.PageSize,
            });
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            ISpecification<Product> specification = new ProductWithCategoriesAndBrandsSpecifications(id: id);

            var product = await this.repository.getByIdWithSpecificationAsync(specification);

            if(product == null)
            {
                return NotFound( new CodeErrorResponse(404));
            }

            var data = this.mapper.Map<Product, ProductDto>( product );

            return Ok(data);
        }

    }
}
