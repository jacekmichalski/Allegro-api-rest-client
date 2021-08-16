﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroOffer;
using AllegroApi.Domain.Validator.QueryValidator;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Service.AllegroOffer;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class GetAllOffersHandler : IRequestHandler<GetAllOffersQuery, List<Offer>>
    {
        private readonly IOfferService _offerService;

        public GetAllOffersHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<List<Offer>> Handle(GetAllOffersQuery request, CancellationToken
            cancellationToken)
        {
            var validator = new GetAllOffersQueryValidator();
            var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ", validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            var result = await _offerService.GetOffersAsync(request.Authorization,request.PublicationStatus);

            return result;
        }
    }
}