
# Value Discount

***Ddd Domain Service***  

This view contains details information about Value Discount building block, including:
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
      2([Discount])
      class 2 DomainPerspective
      3([Value Discount])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing / Discounts"]
      5(Value Discount)
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Commons"]
      7([Money])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Pricing / Discounts"]
      9([Value Discount])
      class 9 DomainPerspective
    end
    0-->|depends on|4
    4-->|depends on|6
    4-->|depends on|8
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
[Value Discount](ValueDiscount.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)