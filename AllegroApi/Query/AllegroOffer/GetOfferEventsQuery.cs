﻿using AllegroApi.Domain.AllegroOffer.Event;
using MediatR;

namespace AllegroApi.Query.AllegroOffer
{
    /// <summary>
    /// Dziennik zdarzeń w ofertach sprzedawcy
    /// </summary>
    public class OfferEventsQuery : AuthorizationToken, IRequest<OfferEvents>
    {
        /// <summary>
        /// from - podaj id eventu, by uzyskać wszystkie eventy które nastąpiły później 
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// limit - podaj liczbę eventów, które chcesz uzyskać w odpowiedzi (domyślnie 100, max. 1000);
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// type - podaj typ eventów, które chcesz uzyskać w odpowiedzi
        /// </summary>
        public OfferEventType Type { get; set; } = OfferEventType.None;

        public enum OfferEventType
        {
            OfferActivated,
            OfferChanged,
            OfferStockChanged,
            OfferPriceChanged,
            OfferEnded,
            OfferArchived,
            OfferBidPlaced,
            OfferBidCanceled,
            None
        }
    }
}