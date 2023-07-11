
# [*Domain building block*] AllowPriceChangesIfTotalPriceIsLower

This view contains details information about AllowPriceChangesIfTotalPriceIsLower building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["PriceChanges"]
      1(AllowPriceChangesIfTotalPriceIsLower)
      class 1 DomainPerspective
    end
    subgraph 2["Pricing"]
      3([Quote])
      class 3 DomainPerspective
    end
    subgraph 4["Commons"]
      5([Money])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

AllowPriceChangesIfTotalPriceIsLower is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] PriceChanges](../../../../Modules/Sales/Orders/PriceChanges/PriceChanges.md)

### Change perspective

- [[*Domain building block*] Quote](../../Pricing/Quote.md)
- [[*Domain building block*] Money](../../Commons/Money.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)