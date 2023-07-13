
# [*Domain building block*] PercentageDiscount

This view contains details information about PercentageDiscount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(PercentageDiscount)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
      4([Percentage])
      class 4 DomainPerspective
    end
    subgraph 5["Discounts"]
      6([PercentageDiscount])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

PercentageDiscount is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Discounts](../../../../Modules/Sales/Pricing/Discounts/Discounts.md)

### Change perspective

- [[*Domain building block*] Money](../../Commons/Money.md)
- [[*Domain building block*] Percentage](../../Commons/Percentage.md)
- [[*Domain building block*] PercentageDiscount](PercentageDiscount.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)