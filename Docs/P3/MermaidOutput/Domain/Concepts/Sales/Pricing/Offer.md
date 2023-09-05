
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
    subgraph 0["Sales / Online Ordering / Cart Pricing"]
      1([PriceCart])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Discounts"]
      3([Client Level Discounts])
      class 3 DomainPerspective
      4([Product Level Discounts])
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Online Ordering / Order Placement"]
      6([PlaceOrder])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Wholesale Ordering / Order Pricing"]
      8([ConfirmOffer])
      class 8 DomainPerspective
      9([GetOffer])
      class 9 DomainPerspective
    end
    subgraph 10["Sales / Orders"]
      11([Order])
      class 11 DomainPerspective
      12([Order Factory])
      class 12 DomainPerspective
    end
    subgraph 13["Sales / Pricing"]
      14([Individual Sales Conditions])
      class 14 DomainPerspective
      15([Offer Modifier])
      class 15 DomainPerspective
      16([Offer Modifier 2])
      class 16 DomainPerspective
    end
    subgraph 17["Sales / Pricing / Special Offers"]
      18([Every Second Box for Half Price])
      class 18 DomainPerspective
      19([Special Offer])
      class 19 DomainPerspective
      20([Three for Two])
      class 20 DomainPerspective
    end
    subgraph 21["Sales / Pricing"]
      22(Offer)
      class 22 DomainPerspective
    end
    subgraph 23["Sales / Commons"]
      24([Currency])
      class 24 DomainPerspective
      25([Money])
      class 25 DomainPerspective
      26([Percentage])
      class 26 DomainPerspective
    end
    subgraph 27["Sales / Pricing / Price Lists"]
      28([Base Prices])
      class 28 DomainPerspective
    end
    subgraph 29["Sales / Pricing"]
      30([Offer Modifier])
      class 30 DomainPerspective
      31([Quote])
      class 31 DomainPerspective
      32([Quote Modifier])
      class 32 DomainPerspective
    end
    subgraph 33["Sales / Products"]
      34([Product Amount])
      class 34 DomainPerspective
    end
    0-->|depends on|21
    2-->|depends on|21
    5-->|depends on|21
    7-->|depends on|21
    10-->|depends on|21
    13-->|depends on|21
    17-->|depends on|21
    21-->|depends on|23
    21-->|depends on|27
    21-->|depends on|29
    21-->|depends on|33
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Offer)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([GetOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([PlaceOrder])
    class 3 DomainPerspective
    0-->|is used in|3
    4([PriceCart])
    class 4 DomainPerspective
    0-->|is used in|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


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

##### Process Steps

[ConfirmOffer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[GetOffer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[PlaceOrder](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[PriceCart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)