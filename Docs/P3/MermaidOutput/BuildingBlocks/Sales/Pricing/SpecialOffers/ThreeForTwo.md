
# [*Domain building block*] ThreeForTwo

This view contains details information about ThreeForTwo building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["SpecialOffers"]
      1(ThreeForTwo)
      class 1 DomainPerspective
    end
    subgraph 2["Pricing"]
      3([Offer])
      class 3 DomainPerspective
      4([OfferModifier])
      class 4 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ThreeForTwo is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] SpecialOffers](../../../../Modules/Sales/Pricing/SpecialOffers/SpecialOffers.md)

### Change perspective

- [[*Domain building block*] OfferModifier](../OfferModifier.md)
- [[*Domain building block*] Offer](../Offer.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)