
# [*Domain building block*] ClientId

This view contains details information about ClientId building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

ClientId has no dependencies.  

### Related process steps

```mermaid
  flowchart TB
    0(ClientId)
    class 0 DomainPerspective
    1([PriceCart])
    class 1 DomainPerspective
    0-->|is used in|1
    2([ConfirmOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([GetOffer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([PlaceOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    5([CreateOrder])
    class 5 DomainPerspective
    0-->|is used in|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Clients](../../../Modules/Sales/Clients/Clients.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)