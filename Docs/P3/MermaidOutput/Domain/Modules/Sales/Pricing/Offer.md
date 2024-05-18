
# Offer

***Ddd Value Object***  

This view contains details information about Offer building block, including:
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
    subgraph 4["Sales.Orders"]
      5([Order])
      class 5 DomainPerspective
      6([Order Factory])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.Pricing"]
      8([Aggregated Modifier])
      class 8 DomainPerspective
      9([Calculate Prices])
      class 9 DomainPerspective
      10([Individual Sales Conditions])
      class 10 DomainPerspective
      11([Offer Modifier])
      class 11 DomainPerspective
      12([Offer Modifier 2])
      class 12 DomainPerspective
    end
    subgraph 13["Sales.Pricing.Discounts"]
      14([Client Level Discounts])
      class 14 DomainPerspective
      15([Product Level Discounts])
      class 15 DomainPerspective
    end
    subgraph 16["Sales.Pricing.SpecialOffers"]
      17([Every Second Box for Half Price])
      class 17 DomainPerspective
      18([Special Offer])
      class 18 DomainPerspective
      19([Three for Two])
      class 19 DomainPerspective
    end
    subgraph 20["Sales.WholesaleOrdering.OrderPricing"]
      21([Confirm Offer])
      class 21 DomainPerspective
      22([Get Offer])
      class 22 DomainPerspective
    end
    subgraph 23["Sales.Pricing"]
      24(Offer)
      class 24 DomainPerspective
    end
    subgraph 25["Sales.Commons"]
      26([Currency])
      class 26 DomainPerspective
      27([Money])
      class 27 DomainPerspective
      28([Percentage])
      class 28 DomainPerspective
    end
    subgraph 29["Sales.Pricing"]
      30([Offer Modifier])
      class 30 DomainPerspective
      31([Quote])
      class 31 DomainPerspective
      32([Quote Modifier])
      class 32 DomainPerspective
    end
    subgraph 33["Sales.Pricing.PriceLists"]
      34([Base Prices])
      class 34 DomainPerspective
    end
    subgraph 35["Sales.Products"]
      36([Product Amount])
      class 36 DomainPerspective
    end
    0-->|depends on|23
    2-->|depends on|23
    4-->|depends on|23
    7-->|depends on|23
    13-->|depends on|23
    16-->|depends on|23
    20-->|depends on|23
    23-->|depends on|25
    23-->|depends on|29
    23-->|depends on|33
    23-->|depends on|35
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Offer)
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
[Quote Modifier](QuoteModifier.md)  

##### Ddd Value Objects

[Base Prices](PriceLists/BasePrices.md)  
[Currency](../Commons/Currency.md)  
[Money](../Commons/Money.md)  
[Percentage](../Commons/Percentage.md)  
[Product Amount](../Products/ProductAmount.md)  
[Quote](Quote.md)  

##### Use Cases

[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)