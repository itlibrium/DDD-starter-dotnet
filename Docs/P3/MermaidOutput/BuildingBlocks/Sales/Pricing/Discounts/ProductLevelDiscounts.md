
# [*Domain building block*] ProductLevelDiscounts

This view contains details information about ProductLevelDiscounts building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(ProductLevelDiscounts)
      class 1 DomainPerspective
    end
    subgraph 2["Pricing"]
      3([Quote])
      class 3 DomainPerspective
      4([Offer])
      class 4 DomainPerspective
    end
    subgraph 5["Discounts"]
      6([ProductDiscount])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ProductLevelDiscounts is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Discounts](../../../../Modules/Sales/Pricing/Discounts/Discounts.md)

### Change perspective

- [[*Domain building block*] Quote](../Quote.md)
- [[*Domain building block*] ProductDiscount](ProductDiscount.md)
- [[*Domain building block*] Offer](../Offer.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)