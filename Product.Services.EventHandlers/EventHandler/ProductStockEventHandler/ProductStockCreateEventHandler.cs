using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductStockCommand;
using Product.Services.EventHandlers.EventHandler.ProductStockEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.EventHandler.ProductStockEventHandler
{
    public class ProductStockCreateEventHandler : IRequestHandler<ProductStockCreateCommand, BaseResult<string>>
    {
        private readonly IProductService _productService;
        private readonly IProductStockService _productStockService;

        private readonly ILogger<ProductStockCreateEventHandler> _logger;

        public ProductStockCreateEventHandler(IProductService productService, IProductStockService productStockService, ILogger<ProductStockCreateEventHandler> logger)
        {
            _productService = productService;
            _productStockService = productStockService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(ProductStockCreateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creando producto - {Request}", JsonSerializer.Serialize(request));
            try
            {

                var productStock = MapToProduct(request);

                var product = _productService.GetById(request.ProductId);

                if (product is null)
                    throw new ApplicationErrorExceptions("No existe un producto con ese id.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

                productStock.Product = product;

                _productStockService.Create(productStock);

                product.ProductStock = productStock;

                _productService.Update(product);

            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al crear el producto stock.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }

        private OKR.Common.Domain.ProductStock MapToProduct(ProductStockCreateCommand request)
        {
            return new OKR.Common.Domain.ProductStock
            {
                ProductId = request.ProductId,
                SellingPrice = request.SellingPrice,
                Quantity = request.Quantity,
                Discount = request.Discount,
                LastUpdated = request.LastUpdated,
                Currency = request.Currency

            };
        }
    }
}
