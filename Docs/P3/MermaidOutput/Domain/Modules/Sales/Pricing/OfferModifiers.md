
# Offer Modifiers

***Ddd Factory***  

This view contains details information about Offer Modifiers building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing"]
      1([Calculate Prices])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing"]
      3(Offer Modifiers)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Clients"]
      5([Client Id])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Pricing"]
      7([Offer Modifier])
      class 7 DomainPerspective
      8([Offer Request])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing.Discounts"]
      10([Discounts Repository])
      class 10 DomainPerspective
      11([Product Level Discounts])
      class 11 DomainPerspective
    end
    subgraph 12["Sales.Pricing.SpecialOffers"]
      13([Every Second Box for Half Price])
      class 13 DomainPerspective
      14([Three for Two])
      class 14 DomainPerspective
    end
    subgraph 15["Sales.Products"]
      16([Product Amount])
      class 16 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
    2-->|depends on|9
    2-->|depends on|12
    2-->|depends on|15
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

No related processes were found.  

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Every Second Box for Half Price](SpecialOffers/EverySecondBoxForHalfPrice.md)  
[Offer Modifier](OfferModifier.md)  
[Product Level Discounts](Discounts/ProductLevelDiscounts.md)  
[Three for Two](SpecialOffers/ThreeForTwo.md)  

##### Ddd Repositories

[Discounts Repository](Discounts/DiscountsRepository.md)  

##### Ddd Value Objects

[Client Id](../Clients/ClientId.md)  
[Offer Request](OfferRequest.md)  
[Product Amount](../Products/ProductAmount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)