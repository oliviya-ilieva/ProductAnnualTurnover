
using Microsoft.AspNetCore.Mvc;
using ProductAnnualTurnover.Data.Dtos;
using ProductAnnualTurnover.Data.Repositories.Contracts;
using ProductAnnualTurnover.Entities;

namespace ProductAnnualTurnover.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductTurnoverController : ControllerBase
    {
         private readonly IUnitOfWork _unitOfWork;
         
         public ProductTurnoverController(IUnitOfWork unitOfWork)
         {
            _unitOfWork = unitOfWork;
            
         }
         [HttpPost] 
         public async Task<IActionResult> CreateProductTurnover(ProductTurnover productTurnover)
         {
            var product = await this._unitOfWork.ProductRepository.GetProductAsync(productTurnover.EAN);
            if (product == null)
            {
                return NotFound("There is not such product.");
            }
            var createdProductTurnover = await
             this._unitOfWork.ProductTurnoverRepository.CreateProductTurnoverAsync(productTurnover);
            

            var result = new ProductTurnoverBreakdown
            {
                GrossTurnover = createdProductTurnover.GrossTurnover,
                NetTurnover = (1 - product.Category.VatTaxation) * createdProductTurnover.GrossTurnover,
                VAT = product.Category.VatTaxation * createdProductTurnover.GrossTurnover
            }; 

             return Ok(result);

         } 
    }
}
