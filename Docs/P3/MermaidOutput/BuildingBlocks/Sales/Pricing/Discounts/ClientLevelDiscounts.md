
# [*Domain building block*] ClientLevelDiscounts

This view contains details information about ClientLevelDiscounts building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(ClientLevelDiscounts)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([PercentageDiscount])
      class 3 DomainPerspective
      4([PercentageDiscount])
      class 4 DomainPerspective
      5([ProductDiscount])
      class 5 DomainPerspective
    end
    subgraph 6["Pricing"]
      7([Offer])
      class 7 DomainPerspective
      8([Quote])
      class 8 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ClientLevelDiscounts is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Discounts](../../../../Modules/Sales/Pricing/Discounts/Discounts.md)

### Change perspective

- [[*Domain building block*] Offer](../Offer.md)
- [[*Domain building block*] ProductDiscount](ProductDiscount.md)
- [[*Domain building block*] Quote](../Quote.md)
- [[*Domain building block*] PercentageDiscount](PercentageDiscount.md)
- [[*Domain building block*] PercentageDiscount](PercentageDiscount.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)