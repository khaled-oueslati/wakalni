using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace wakalni.Application.Items.Queries
{
    public class GetItemQueryValidator : AbstractValidator<GetItemsQuery>
    {
        public GetItemQueryValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(x => x.PageSize).InclusiveBetween(1,500);
        }
    }
}
