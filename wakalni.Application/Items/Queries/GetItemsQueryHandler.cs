using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using wakalni.Application.Items.Models;
using wakalni.services;

namespace wakalni.Application.Items.Queries
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, ItemsDetailModel>
    {
        private readonly ItemService itemService;
        private readonly IMapper mapper;

        public GetItemsQueryHandler(ItemService itemService, IMapper mapper)
        {
            this.itemService = itemService;
            this.mapper = mapper;
        }
        public async Task<ItemsDetailModel> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await itemService.GetItems(request.PageNumber, request.PageSize);
            var itemsDTO = mapper.Map<IEnumerable<ItemDTO>>(items);
            return new ItemsDetailModel
            {
                Items = itemsDTO,
                NextPage = request.PageNumber+1,
                totalNumber = itemsDTO.Count()
            };
        }
    }
}
