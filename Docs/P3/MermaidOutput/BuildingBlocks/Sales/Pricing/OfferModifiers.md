
# [*Domain building block*] OfferModifiers

This view contains details information about OfferModifiers building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(OfferModifiers)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([DiscountsRepository])
      class 3 DomainPerspective
    end
    subgraph 4["Pricing"]
      5([OfferRequest])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

OfferModifiers is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] OfferRequest](OfferRequest.md)
- [[*Domain building block*] DiscountsRepository](Discounts/DiscountsRepository.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)