
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
    subgraph 0["Sales / Pricing / Discounts"]
      1([Product Discount])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Discounts"]
      3(Discount)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Commons"]
      5([Money])
      class 5 DomainPerspective
      6([Percentage])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Pricing / Discounts"]
      8([Percentage Discount])
      class 8 DomainPerspective
      9([Value Discount])
      class 9 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|7
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

[Money](../../Commons/Money.md)  
[Percentage](../../Commons/Percentage.md)  
[Percentage Discount](PercentageDiscount.md)  
[Value Discount](ValueDiscount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)