
# [*Domain building block*] Discount

This view contains details information about Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Discount)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Percentage])
      class 3 DomainPerspective
      4([Money])
      class 4 DomainPerspective
    end
    subgraph 5["Discounts"]
      6([Discount])
      class 6 DomainPerspective
      7([ValueDiscount])
      class 7 DomainPerspective
      8([ValueDiscount])
      class 8 DomainPerspective
      9([PercentageDiscount])
      class 9 DomainPerspective
      10([PercentageDiscount])
      class 10 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Discount is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Discounts](../../../../Modules/Sales/Pricing/Discounts/Discounts.md)

### Change perspective

- [[*Domain building block*] Percentage](../../Commons/Percentage.md)
- [[*Domain building block*] PercentageDiscount](PercentageDiscount.md)
- [[*Domain building block*] PercentageDiscount](PercentageDiscount.md)
- [[*Domain building block*] ValueDiscount](ValueDiscount.md)
- [[*Domain building block*] ValueDiscount](ValueDiscount.md)
- [[*Domain building block*] Discount](Discount.md)
- [[*Domain building block*] Money](../../Commons/Money.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)