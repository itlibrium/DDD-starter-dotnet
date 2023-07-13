
# [*Domain building block*] PriceChangesPolicies

This view contains details information about PriceChangesPolicies building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["PriceChanges"]
      1(PriceChangesPolicies)
      class 1 DomainPerspective
    end
    subgraph 2["Clients"]
      3([ClientId])
      class 3 DomainPerspective
      4([ClientRepository])
      class 4 DomainPerspective
    end
    subgraph 5["PriceChanges"]
      6([AllowAnyPriceChanges])
      class 6 DomainPerspective
      7([AllowPriceChangesIfTotalPriceIsLower])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(PriceChangesPolicies)
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

### Change perspective

- [[*Domain building block*] ClientRepository](../../Clients/ClientRepository.md)
- [[*Domain building block*] AllowAnyPriceChanges](AllowAnyPriceChanges.md)
- [[*Domain building block*] ClientId](../../Clients/ClientId.md)
- [[*Domain building block*] AllowPriceChangesIfTotalPriceIsLower](AllowPriceChangesIfTotalPriceIsLower.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)