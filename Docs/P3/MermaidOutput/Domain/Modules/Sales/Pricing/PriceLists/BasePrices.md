
# Base Prices

***Ddd Value Object***  

This view contains details information about Base Prices building block, including:
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
      2([Offer])
      class 2 DomainPerspective
    end
    subgraph 3["Sales.Pricing.PriceLists"]
      4([Price List Repository])
      class 4 DomainPerspective
    end
    subgraph 5["Sales.Pricing.PriceLists"]
      6(Base Prices)
      class 6 DomainPerspective
    end
    subgraph 7["Sales.Commons"]
      8([Money])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing.PriceLists"]
      10([Base Price])
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Products"]
      12([Product Amount])
      class 12 DomainPerspective
      13([Product Unit])
      class 13 DomainPerspective
    end
    0-->|depends on|5
    3-->|depends on|5
    5-->|depends on|7
    5-->|depends on|9
    5-->|depends on|11
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


##### Ddd Value Objects

[Base Price](BasePrice.md)  
[Money](../../Commons/Money.md)  
[Product Amount](../../Products/ProductAmount.md)  
[Product Unit](../../Products/ProductUnit.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Price lists](PriceLists-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)