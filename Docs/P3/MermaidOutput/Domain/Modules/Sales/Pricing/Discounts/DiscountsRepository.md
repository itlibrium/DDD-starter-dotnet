
# Discounts Repository

***Ddd Repository***  

This view contains details information about Discounts Repository building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing"]
      1([Offer Modifiers])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing.Discounts"]
      3(Discounts Repository)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Clients"]
      5([Client Id])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Pricing.Discounts"]
      7([Client Level Discounts])
      class 7 DomainPerspective
      8([Product Level Discounts])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Products"]
      10([Product Amount])
      class 10 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
    2-->|depends on|9
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

[Client Level Discounts](ClientLevelDiscounts.md)  
[Product Level Discounts](ProductLevelDiscounts.md)  

##### Ddd Value Objects

[Client Id](../../Clients/ClientId.md)  
[Product Amount](../../Products/ProductAmount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Discounts](Discounts-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)