
# Percentage Discount

***Ddd Value Object***  

This view contains details information about Percentage Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing / Discounts"]
      1([Client Level Discounts])
      class 1 DomainPerspective
      2([Discount])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Pricing / Discounts"]
      4(Percentage Discount)
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Commons"]
      6([Money])
      class 6 DomainPerspective
      7([Percentage])
      class 7 DomainPerspective
    end
    0-->|depends on|3
    3-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Technology Perspective


### Source code

[PercentageDiscount.cs](../../../../../../../../Sources/Sales/Sales.DeepModel/Pricing/Discounts/PercentageDiscount.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Money](../../Commons/Money.md)  
[Percentage](../../Commons/Percentage.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)