using MediatR;
using OKR.Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.EventHandlers.Commands.ProductCategoryCommand
{
    public class CategoryDeleteCommand : IRequest<BaseResult<string>>
    {
        public CategoryDeleteCommand(int categoryId)
        {
            Id = categoryId;
        }
        public int Id { get; set; }

    }
}
