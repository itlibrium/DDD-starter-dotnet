
# [*Domain building block*] Raw

This view contains details information about Raw building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Orders"]
      1(Raw)
      class 1 DomainPerspective
    end
    subgraph 2["Orders"]
      3([OrderId])
      class 3 DomainPerspective
      4([Order])
      class 4 DomainPerspective
    end
    subgraph 5["Commons"]
      6([Money])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Raw is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Orders](../../../Modules/Sales/Orders/Orders.md)

### Change perspective

- [[*Domain building block*] OrderId](OrderId.md)
- [[*Domain building block*] Order](Order.md)
- [[*Domain building block*] Money](../Commons/Money.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)