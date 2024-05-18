
# Discount

***Ddd Value Object***  

This view contains details information about Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing.Discounts"]
      1([Client Level Discounts])
      class 1 DomainPerspective
      2([Product Discount])
      class 2 DomainPerspective
      3([Product Level Discounts])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Pricing.Discounts"]
      5(Discount)
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Commons"]
      7([Money])
      class 7 DomainPerspective
      8([Percentage])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing.Discounts"]
      10([Percentage Discount])
      class 10 DomainPerspective
      11([Value Discount])
      class 11 DomainPerspective
    end
    0-->|depends on|4
    4-->|depends on|6
    4-->|depends on|9
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

[Money](../../Commons/Money.md)  
[Percentage](../../Commons/Percentage.md)  
[Percentage Discount](PercentageDiscount.md)  
[Value Discount](ValueDiscount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Discounts](Discounts-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)