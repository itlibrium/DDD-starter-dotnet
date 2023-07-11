
# [*Domain building block*] Repository

This view contains details information about Repository building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Orders"]
      1(Repository)
      class 1 DomainPerspective
    end
    subgraph 2["Orders"]
      3([OrderId])
      class 3 DomainPerspective
      4([Order])
      class 4 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Repository)
    class 0 DomainPerspective
    1([PlaceOrder])
    class 1 DomainPerspective
    0-->|is used in|1
    2([GetOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([PlaceOrder])
    class 3 DomainPerspective
    0-->|is used in|3
    4([CreateOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    5([AddToOrder])
    class 5 DomainPerspective
    0-->|is used in|5
    6([ConfirmOffer])
    class 6 DomainPerspective
    0-->|is used in|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Orders](../../../Modules/Sales/Orders/Orders.md)

### Change perspective

- [[*Domain building block*] OrderId](OrderId.md)
- [[*Domain building block*] Order](Order.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)