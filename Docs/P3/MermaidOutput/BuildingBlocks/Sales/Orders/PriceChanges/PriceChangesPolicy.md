
# [*Domain building block*] PriceChangesPolicy

This view contains details information about PriceChangesPolicy building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

PriceChangesPolicy has no dependencies.  

### Related process steps

```mermaid
  flowchart TB
    0(PriceChangesPolicy)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] PriceChanges](../../../../Modules/Sales/Orders/PriceChanges/PriceChanges.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)