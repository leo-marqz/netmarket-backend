using APPLICATION.Persistence.Contracts;
using DOMAIN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    
    public class BrandsController : BaseApiController
    {
        private readonly IGenericRepository<Brand> repository;

        public BrandsController(IGenericRepository<Brand> genericRepository)
        {
            this.repository = genericRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Brand>>> GetBrands()
        {
            try
            {
                var brands = await this.repository.getAllAsync();

                return Ok(brands);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public  async Task<ActionResult<Brand>> GetBrand(int id)
        {   
            try
            {
                var brand = await this.repository.getByIdAsync(id);

                if (brand == null)
                {
                    return NotFound();
                }

                return Ok(brand);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
