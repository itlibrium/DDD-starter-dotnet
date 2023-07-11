
# [*Domain building block*] BasePrices

This view contains details information about BasePrices building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["PriceLists"]
      1(BasePrices)
      class 1 DomainPerspective
    end
    subgraph 2["Products"]
      3([ProductAmount])
      class 3 DomainPerspective
    end
    subgraph 4["PriceLists"]
      5([BasePrice])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

BasePrices is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] PriceLists](../../../../Modules/Sales/Pricing/PriceLists/PriceLists.md)

### Change perspective

- [[*Domain building block*] ProductAmount](../../Products/ProductAmount.md)
- [[*Domain building block*] BasePrice](BasePrice.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)