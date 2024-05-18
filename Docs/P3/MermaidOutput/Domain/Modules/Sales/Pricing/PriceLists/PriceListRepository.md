
# Price List Repository

***Ddd Repository***  

This view contains details information about Price List Repository building block, including:
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
    subgraph 2["Sales.Pricing.PriceLists"]
      3(Price List Repository)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Clients"]
      5([Client Id])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Commons"]
      7([Money])
      class 7 DomainPerspective
    end
    subgraph 8["Sales.Pricing.PriceLists"]
      9([Base Prices])
      class 9 DomainPerspective
    end
    subgraph 10["Sales.Products"]
      11([Product Amount])
      class 11 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
    2-->|depends on|8
    2-->|depends on|10
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

[Base Prices](BasePrices.md)  
[Client Id](../../Clients/ClientId.md)  
[Money](../../Commons/Money.md)  
[Product Amount](../../Products/ProductAmount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Price lists](PriceLists-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)