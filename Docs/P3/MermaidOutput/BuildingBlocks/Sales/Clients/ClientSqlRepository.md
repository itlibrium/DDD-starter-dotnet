
# [*Domain building block*] ClientSqlRepository

This view contains details information about ClientSqlRepository building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Clients"]
      1(ClientSqlRepository)
      class 1 DomainPerspective
    end
    subgraph 2["Clients"]
      3([ClientId])
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ClientSqlRepository is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Clients](../../../Modules/Sales/Clients/Clients.md)

### Change perspective

- [[*Domain building block*] ClientId](ClientId.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)