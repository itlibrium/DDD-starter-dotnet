
# [*Domain building block*] ProductUnit

This view contains details information about ProductUnit building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Products"]
      1(ProductUnit)
      class 1 DomainPerspective
    end
    subgraph 2["Products"]
      3([ProductId])
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ProductUnit is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Products](../../../Modules/Sales/Products/Products.md)

### Change perspective

- [[*Domain building block*] ProductId](ProductId.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)