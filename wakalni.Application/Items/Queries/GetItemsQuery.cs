using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using wakalni.Application.Items.Models;

namespace wakalni.Application.Items.Queries
{
    public class GetItemsQuery : IRequest<ItemsDetailModel>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
