using AutoMapper;
using BLL.Service;
using CartingService.Api.BLL.Models;
using CartingService.Api.Web.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartingService.Api.Web.Service
{
    public class MessageService : IMessageService
    {
        private ICartService cartService;
        private readonly IMapper mapper;

        public MessageService(IMapper mapper, ICartService cartService)
        {
            this.mapper = mapper;
            this.cartService = cartService;
        }
        public void UpdateProduct(UpdateProduct updateProduct)
        {
            cartService.UpdateProduct(updateProduct);
        }
    }
}
