
# [*Domain building block*] ProductAmount

This view contains details information about ProductAmount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Products"]
      1(ProductAmount)
      class 1 DomainPerspective
    end
    subgraph 2["Products"]
      3([ProductUnit])
      class 3 DomainPerspective
      4([ProductId])
      class 4 DomainPerspective
      5([Amount])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(ProductAmount)
    class 0 DomainPerspective
    1([AddToOrder])
    class 1 DomainPerspective
    0-->|is used in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Products](../../../Modules/Sales/Products/Products.md)

### Change perspective

- [[*Domain building block*] ProductId](ProductId.md)
- [[*Domain building block*] ProductUnit](ProductUnit.md)
- [[*Domain building block*] Amount](Amount.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)