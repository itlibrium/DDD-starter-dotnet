
# [*Domain building block*] OfferModifier2

This view contains details information about OfferModifier2 building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(OfferModifier2)
      class 1 DomainPerspective
    end
    subgraph 2["Pricing"]
      3([Offer])
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

OfferModifier2 is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] Offer](Offer.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)