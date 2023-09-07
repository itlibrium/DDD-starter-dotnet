
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
    subgraph 0["Sales / Pricing"]
      1([Offer])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Price Lists"]
      3(Base Prices)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing / Price Lists"]
      5([Base Price])
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

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Base Price](BasePrice.md)  
[Product Amount](../../Products/ProductAmount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Price lists](PriceLists.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)