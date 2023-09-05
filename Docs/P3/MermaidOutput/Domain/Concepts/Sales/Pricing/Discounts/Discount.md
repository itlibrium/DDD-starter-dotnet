
# Discount

***Ddd Domain Service***  

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
      1([Discount])
      class 1 DomainPerspective
      2([Product Discount])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Pricing / Discounts"]
      4(Discount)
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Commons"]
      6([Money])
      class 6 DomainPerspective
      7([Percentage])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Pricing / Discounts"]
      9([Discount])
      class 9 DomainPerspective
      10([Percentage Discount])
      class 10 DomainPerspective
      11([Percentage Discount])
      class 11 DomainPerspective
      12([Value Discount])
      class 12 DomainPerspective
      13([Value Discount])
      class 13 DomainPerspective
    end
    0-->|depends on|3
    3-->|depends on|5
    3-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Percentage Discount](PercentageDiscount.md)  
[Value Discount](ValueDiscount.md)  

##### Ddd Value Objects

[Discount](Discount.md)  
[Money](../../Commons/Money.md)  
[Percentage](../../Commons/Percentage.md)  
[Percentage Discount](PercentageDiscount.md)  
[Value Discount](ValueDiscount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)