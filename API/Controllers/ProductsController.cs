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
        private readonly IGenericRepository<Product> _repository;
        private IMapper _mapper;

        public ProductsController(IGenericRepository<Product> genericRepository, IMapper mapper)
        {
            _repository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts([FromQuery] ProductParamsSpecifications productParams)
        {
            ISpecification<Product> specification = new ProductWithCategoriesAndBrandsSpecifications(productParams);
            IReadOnlyList<Product> products = await _repository.getAllWithSpecificationsAsync(specification);

            ISpecification<Product> specCount = new ProductWithPaginationSpecification(productParams);
            int totalProducts = await _repository.countAsync(specCount);

            var getPages = Math.Ceiling( Convert.ToDecimal(totalProducts) / Convert.ToDecimal(productParams.PageSize) );
            var totalPages = Convert.ToInt32(getPages);

            List<ProductDto> data = _mapper
                .Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products)
                .ToList();

            return Ok(new Pagination<IReadOnlyList<ProductDto>>()
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

            var product = await _repository.getByIdWithSpecificationAsync(specification);

            if(product == null)
            {
                return NotFound( new CodeErrorResponse(404));
            }

            var data = _mapper.Map<Product, ProductDto>( product );

            return Ok(data);
        }

    }
}
