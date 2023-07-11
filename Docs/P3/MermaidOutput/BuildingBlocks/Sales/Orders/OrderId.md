
# [*Domain building block*] OrderId

This view contains details information about OrderId building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

OrderId has no dependencies.  

### Related process steps

```mermaid
  flowchart TB
    0(OrderId)
    class 0 DomainPerspective
    1([GetOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([PlaceOrder])
    class 2 DomainPerspective
    0-->|is used in|2
    3([AddToOrder])
    class 3 DomainPerspective
    0-->|is used in|3
    4([ConfirmOffer])
    class 4 DomainPerspective
    0-->|is used in|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Orders](../../../Modules/Sales/Orders/Orders.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)