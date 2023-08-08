using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Domain;
using OKR.Common.Results;
using OKR.Common.Services;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ApplicationErrorException.ErrorDictionary;

namespace Product.Services.EventHandlers.EventHandler.ProductEventHandler
{
    public class ProductUpdateEventHandler : IRequestHandler<ProductUpdateCommand, BaseResult<string>>
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        private readonly ILogger<ProductUpdateEventHandler> _logger;

        public ProductUpdateEventHandler(IProductService productService, ICategoryService categoryService, ILogger<ProductUpdateEventHandler> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Actualizando producto - {Request}", JsonSerializer.Serialize(request));
            try
            {
                var product = _productService.GetById(request.Id);
                if (product is null)
                    throw new ApplicationErrorExceptions("No se encontro un producto con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                product.Name = request.Name;
                product.Description = request.Description;
                product.Brand = request.Brand;
                product.FabricationDate = request.FabricationDate;
                product.ExpirationDate = request.ExpirationDate;

                var categoryPreviousId = product.Category.Id;

                var category = _categoryService.GetById(request.CategoryId);

                if (category is null)
                    throw new ApplicationErrorExceptions("No existe una categoria con ese id.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

                product.Category = category;

                _productService.Update(product);

                UpdatePreviousCategory(categoryPreviousId, product);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al actualizar el producto.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }

        private void UpdatePreviousCategory(int categoryPreviousId, OKR.Common.Domain.Product product)
        {
            try
            {
                var categoryPrevious = _categoryService.GetById(categoryPreviousId);
                
                if (categoryPrevious is null)
                    throw new ApplicationErrorExceptions("No existe una categoria con ese id.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

                categoryPrevious.Products.Remove(product);

                _categoryService.Update(categoryPrevious);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message);

                throw new ApplicationErrorExceptions("Hubo un error al actualizar la categoria anterior.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
        }

    }
}
