using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using System.Text.Json;
using OKR.Common.Domain;
using System.Xml.Linq;
using Product.Services.EventHandlers.Commands.ProductCommand;

namespace Product.Services.EventHandlers.EventHandler.ProductEventHandler
{
    public class ProductCreateEventHandler : IRequestHandler<ProductCreateCommand, BaseResult<string>>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private readonly ILogger<ProductCreateEventHandler> _logger;

        public ProductCreateEventHandler(IProductService productService, ICategoryService categoryService, ILogger<ProductCreateEventHandler> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creando producto - {Request}", JsonSerializer.Serialize(request));
            try
            {
                var product = MapToProduct(request);

                var category = _categoryService.GetById(request.CategoryId);

                if (category is null)                
                    throw new ApplicationErrorExceptions("No existe una categoria con ese id.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);
                
                product.Category = category;

                _productService.Create(product);

                category.Products.Add(product);

                _categoryService.Update(category);

            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al crear el producto.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }

        private OKR.Common.Domain.Product MapToProduct(ProductCreateCommand request)
        {
            return new OKR.Common.Domain.Product
            {
                Name = request.Name,
                Description = request.Description,
                Brand = request.Brand,
                FabricationDate = request.FabricationDate,
                ExpirationDate = request.ExpirationDate

            };
        }
    }
}