﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroDeliveryMethods;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.Sale;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.Sale
{
    
    public class DeliveryMethodsHandler: IRequestHandler<DeliveryMethodsQuery, ListOfDeliveryMethods>
    {
        private readonly ISaleService _sellerService;

        public DeliveryMethodsHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }


        public async Task<ListOfDeliveryMethods> Handle(DeliveryMethodsQuery request, CancellationToken 
        cancellationToken)
        {
            var validator = new DeliveryMethodsQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _sellerService.GetDeliveryMethodsAsync(request.Authorization);

            return result;
        }
    }
}