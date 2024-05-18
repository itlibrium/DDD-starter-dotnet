
# Value Discount

***Ddd Value Object***  

This view contains details information about Value Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing.Discounts"]
      1([Discount])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing.Discounts"]
      3(Value Discount)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Commons"]
      5([Currency])
      class 5 DomainPerspective
      6([Money])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
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

[Currency](../../Commons/Currency.md)  
[Money](../../Commons/Money.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Discounts](Discounts-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)