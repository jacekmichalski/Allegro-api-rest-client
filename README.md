# Allegro api rest client

Połączenie:
- FluentResults
- FluentValidation
- MediatR
- Autofac

Pobieranie szczegółów oferty:

            var allegroApi = new AllegroRestClient();

            try
            {
                var result = await allegroApi.Query(new GetOfferByIdQuery()
                {
                    OfferId = "10862116958",
                    Authorization = "authcode"
                });
                
                Console.WriteLine(result.Name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

Authorization => token do Bearer

PS: NIE MA NAPISANYCH TESTÓW


