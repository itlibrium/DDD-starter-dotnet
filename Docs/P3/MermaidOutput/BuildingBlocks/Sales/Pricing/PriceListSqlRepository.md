
# [*Domain building block*] PriceListSqlRepository

This view contains details information about PriceListSqlRepository building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(PriceListSqlRepository)
      class 1 DomainPerspective
    end
    subgraph 2["Products"]
      3([ProductAmount])
      class 3 DomainPerspective
    end
    subgraph 4["Clients"]
      5([ClientId])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

PriceListSqlRepository is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] ClientId](../Clients/ClientId.md)
- [[*Domain building block*] ProductAmount](../Products/ProductAmount.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)