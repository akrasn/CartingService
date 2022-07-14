using CartingService.Api.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartingService.Api.Web.Service
{
    public interface IMessageService
    {
        void UpdateProduct(UpdateProduct updateProduct);
    }
}
