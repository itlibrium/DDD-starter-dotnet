
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
    subgraph 0["Sales / Pricing"]
      1([Calculate Prices])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Price Lists"]
      3(Price List Repository)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Clients"]
      5([Client Id])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Products"]
      7([Product Amount])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Technology Perspective


### Source code

[PriceListRepository.cs](../../../../../../../../Sources/Sales/Sales.DeepModel/Pricing/PriceLists/PriceListRepository.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Client Id](../../Clients/ClientId.md)  
[Product Amount](../../Products/ProductAmount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Price lists](PriceLists.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)