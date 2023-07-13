
# [*Domain building block*] IndividualSalesConditions

This view contains details information about IndividualSalesConditions building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(IndividualSalesConditions)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([ClientLevelDiscounts])
      class 3 DomainPerspective
      4([ProductLevelDiscounts])
      class 4 DomainPerspective
    end
    subgraph 5["Pricing"]
      6([Offer])
      class 6 DomainPerspective
      7([Quote])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

IndividualSalesConditions is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] Offer](Offer.md)
- [[*Domain building block*] ClientLevelDiscounts](Discounts/ClientLevelDiscounts.md)
- [[*Domain building block*] Quote](Quote.md)
- [[*Domain building block*] ProductLevelDiscounts](Discounts/ProductLevelDiscounts.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)