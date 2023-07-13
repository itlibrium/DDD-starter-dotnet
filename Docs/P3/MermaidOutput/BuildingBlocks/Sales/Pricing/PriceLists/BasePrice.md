
# [*Domain building block*] BasePrice

This view contains details information about BasePrice building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["PriceLists"]
      1(BasePrice)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
    end
    subgraph 4["Products"]
      5([ProductUnit])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

BasePrice is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] PriceLists](../../../../Modules/Sales/Pricing/PriceLists/PriceLists.md)

### Change perspective

- [[*Domain building block*] Money](../../Commons/Money.md)
- [[*Domain building block*] ProductUnit](../../Products/ProductUnit.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)