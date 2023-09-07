
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
      1([Price Cart])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Online Ordering / Order Placement"]
      3([Place Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Orders"]
      5([Order])
      class 5 DomainPerspective
      6([Order Factory])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Pricing"]
      8([Individual Sales Conditions])
      class 8 DomainPerspective
      9([Offer Modifier])
      class 9 DomainPerspective
      10([Offer Modifier 2])
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Pricing / Discounts"]
      12([Client Level Discounts])
      class 12 DomainPerspective
      13([Product Level Discounts])
      class 13 DomainPerspective
    end
    subgraph 14["Sales / Pricing / Special Offers"]
      15([Every Second Box for Half Price])
      class 15 DomainPerspective
      16([Special Offer])
      class 16 DomainPerspective
      17([Three for Two])
      class 17 DomainPerspective
    end
    subgraph 18["Sales / Wholesale Ordering / Order Pricing"]
      19([Confirm Offer])
      class 19 DomainPerspective
      20([Get Offer])
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
    subgraph 27["Sales / Pricing"]
      28([Offer Modifier])
      class 28 DomainPerspective
      29([Quote])
      class 29 DomainPerspective
      30([Quote Modifier])
      class 30 DomainPerspective
    end
    subgraph 31["Sales / Pricing / Price Lists"]
      32([Base Prices])
      class 32 DomainPerspective
    end
    subgraph 33["Sales / Products"]
      34([Product Amount])
      class 34 DomainPerspective
    end
    0-->|depends on|21
    2-->|depends on|21
    4-->|depends on|21
    7-->|depends on|21
    11-->|depends on|21
    14-->|depends on|21
    18-->|depends on|21
    21-->|depends on|23
    21-->|depends on|27
    21-->|depends on|31
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

[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)