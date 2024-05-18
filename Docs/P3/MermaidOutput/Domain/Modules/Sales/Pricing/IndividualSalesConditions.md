
# Individual Sales Conditions

***Ddd Domain Service***  

This view contains details information about Individual Sales Conditions building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing"]
      1(Individual Sales Conditions)
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing"]
      3([Offer])
      class 3 DomainPerspective
      4([Quote])
      class 4 DomainPerspective
      5([Quote Modifier])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Pricing.Discounts"]
      7([Client Level Discounts])
      class 7 DomainPerspective
      8([Product Level Discounts])
      class 8 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|6
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

[Client Level Discounts](Discounts/ClientLevelDiscounts.md)  
[Product Level Discounts](Discounts/ProductLevelDiscounts.md)  
[Quote Modifier](QuoteModifier.md)  

##### Ddd Value Objects

[Offer](Offer.md)  
[Quote](Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)