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
    public class CategoryDeleteEventHandler : IRequestHandler<CategoryDeleteCommand, BaseResult<string>>
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryDeleteEventHandler> _logger;

        public CategoryDeleteEventHandler(ICategoryService categoryService, ILogger<CategoryDeleteEventHandler> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        public async Task<BaseResult<string>> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Eliminando categoria - {Request}", JsonSerializer.Serialize(request));
            try
            {

                var category = _categoryService.GetById(request.Id);

                if (category is null)
                    throw new ApplicationErrorExceptions("No se encontro una categoria con ese id.", (int)ErrorDictionary.GeneralCodes.DataNotFound);

                if(category.Products.Any())
                    throw new ApplicationErrorExceptions("No se puede eliminar la categoria que tiene asignado productos.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);


                _categoryService.Delete(category);
            }
            catch (ApplicationErrorExceptions ex)
            {
                _logger.LogError(ex.Message, JsonSerializer.Serialize(request));

                throw new ApplicationErrorExceptions("Hubo un error al eliminar la categoria.", (int)ErrorDictionary.GeneralCodes.UnexpectedError);

            }

            return new BaseResult<string> { Success = true };

        }
    }
}
