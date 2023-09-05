
# Percentage Discount

***Ddd Domain Service***  

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
      3([Discount])
      class 3 DomainPerspective
      4([Percentage Discount])
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Pricing / Discounts"]
      6(Percentage Discount)
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Commons"]
      8([Money])
      class 8 DomainPerspective
      9([Percentage])
      class 9 DomainPerspective
    end
    subgraph 10["Sales / Pricing / Discounts"]
      11([Percentage Discount])
      class 11 DomainPerspective
    end
    0-->|depends on|5
    5-->|depends on|7
    5-->|depends on|10
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

### Zoom-out


#### Domain perspective


##### Domain Modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)