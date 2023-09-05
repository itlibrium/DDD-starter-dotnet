
# Quote

***Ddd Value Object***  

This view contains details information about Quote building block, including:
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
    subgraph 5["Sales / Wholesale Ordering / Order Pricing"]
      6([ConfirmOffer])
      class 6 DomainPerspective
      7([GetOffer])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Orders"]
      9([Order])
      class 9 DomainPerspective
    end
    subgraph 10["Sales / Orders / Price Changes"]
      11([Allow Price Changes if Total Price Is Lower])
      class 11 DomainPerspective
    end
    subgraph 12["Sales / Pricing"]
      13([Individual Sales Conditions])
      class 13 DomainPerspective
      14([Offer])
      class 14 DomainPerspective
      15([Quote Modifier])
      class 15 DomainPerspective
    end
    subgraph 16["Sales / Wholesale Ordering / Product Pricing"]
      17([CreateOrder])
      class 17 DomainPerspective
    end
    subgraph 18["Sales / Pricing"]
      19(Quote)
      class 19 DomainPerspective
    end
    subgraph 20["Sales / Commons"]
      21([Money])
      class 21 DomainPerspective
    end
    subgraph 22["Sales / Pricing"]
      23([Quote Modifier])
      class 23 DomainPerspective
    end
    subgraph 24["Sales / Products"]
      25([Product Amount])
      class 25 DomainPerspective
    end
    0-->|depends on|18
    2-->|depends on|18
    5-->|depends on|18
    8-->|depends on|18
    10-->|depends on|18
    12-->|depends on|18
    16-->|depends on|18
    18-->|depends on|20
    18-->|depends on|22
    18-->|depends on|24
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Quote)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([CreateOrder])
    class 2 DomainPerspective
    0-->|is used in|2
    3([GetOffer])
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

[Quote Modifier](QuoteModifier.md)  

##### Ddd Value Objects

[Money](../Commons/Money.md)  
[Product Amount](../Products/ProductAmount.md)  

##### Process Steps

[ConfirmOffer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[CreateOrder](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[GetOffer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[PriceCart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)