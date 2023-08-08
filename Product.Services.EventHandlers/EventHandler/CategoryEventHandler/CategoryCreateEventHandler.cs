using ApplicationErrorException;
using MediatR;
using Microsoft.Extensions.Logging;
using OKR.Common.Results;
using OKR.Common.Services.Interfaces;
using Product.Services.EventHandlers.Commands.ProductCategoryCommand;
using Product.Services.EventHandlers.Commands.ProductCommand;
using Product.Services.EventHandlers.EventHandler.ProductEventHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.EventHandler.CategoryEventHandler
{
    public class CategoryCreateEventHandler : IRequestHandler<CategoryCreateCommand, BaseResult<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryCreateEventHandler> _logger;

        public CategoryCreateEventHandler(ICategoryService categoryService, ILogger<CategoryCreateEventHandler> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creando categoria - {Request}", JsonSerializer.Serialize(request));
            try
            {
                var product = MapToCategory(request);
                _categoryService.Create(product);

            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al crear la categoria.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }
            return new BaseResult<string> { Success = true };
        }

        private OKR.Common.Domain.Category MapToCategory(CategoryCreateCommand request)
        {
            return new OKR.Common.Domain.Category
            {
                Name = request.Name,
                Description = request.Description
            };
        }
    }
}
