
# Calculate Prices

***Ddd Domain Service***  

This view contains details information about Calculate Prices building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.OnlineOrdering.CartPricing"]
      1([Price Cart])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.OnlineOrdering.OrderPlacement"]
      3([Place Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.WholesaleOrdering.OrderPricing"]
      5([Confirm Offer])
      class 5 DomainPerspective
      6([Get Offer])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.WholesaleOrdering.ProductPricing"]
      8([Create Order])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing"]
      10(Calculate Prices)
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Clients"]
      12([Client Id])
      class 12 DomainPerspective
    end
    subgraph 13["Sales.Commons"]
      14([Currency])
      class 14 DomainPerspective
    end
    subgraph 15["Sales.ExchangeRates"]
      16([Exchange Rate])
      class 16 DomainPerspective
      17([Exchange Rate Provider])
      class 17 DomainPerspective
    end
    subgraph 18["Sales.Pricing"]
      19([Offer])
      class 19 DomainPerspective
      20([Offer Modifier])
      class 20 DomainPerspective
      21([Offer Modifiers])
      class 21 DomainPerspective
      22([Offer Request])
      class 22 DomainPerspective
      23([Quote])
      class 23 DomainPerspective
    end
    subgraph 24["Sales.Pricing.PriceLists"]
      25([Base Prices])
      class 25 DomainPerspective
      26([Price List Repository])
      class 26 DomainPerspective
    end
    subgraph 27["Sales.Products"]
      28([Product Amount])
      class 28 DomainPerspective
    end
    subgraph 29["Sales.SalesChannels"]
      30([Sales Channel])
      class 30 DomainPerspective
    end
    0-->|depends on|9
    2-->|depends on|9
    4-->|depends on|9
    7-->|depends on|9
    9-->|depends on|11
    9-->|depends on|13
    9-->|depends on|15
    9-->|depends on|18
    9-->|depends on|24
    9-->|depends on|27
    9-->|depends on|29
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Calculate Prices)
    class 0 DomainPerspective
    1([Price Cart])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Place Order])
    class 2 DomainPerspective
    0-->|is used in|2
    3([Confirm Offer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([Get Offer])
    class 4 DomainPerspective
    0-->|is used in|4
    5([Create Order])
    class 5 DomainPerspective
    0-->|is used in|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Offer Modifier](OfferModifier.md)  

##### Ddd Factories

[Offer Modifiers](OfferModifiers.md)  

##### Ddd Repositories

[Price List Repository](PriceLists/PriceListRepository.md)  

##### Ddd Value Objects

[Base Prices](PriceLists/BasePrices.md)  
[Client Id](../Clients/ClientId.md)  
[Currency](../Commons/Currency.md)  
[Exchange Rate](../ExchangeRates/ExchangeRate.md)  
[Offer](Offer.md)  
[Offer Request](OfferRequest.md)  
[Product Amount](../Products/ProductAmount.md)  
[Quote](Quote.md)  
[Sales Channel](../SalesChannels/SalesChannel.md)  

##### External System Integrations

[Exchange Rate Provider](../ExchangeRates/ExchangeRateProvider.md)  

##### Use Cases

[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)