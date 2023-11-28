
# Client Repository

***Ddd Repository***  

This view contains details information about Client Repository building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Orders / Price Changes"]
      1([Price Changes Policies])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Clients"]
      3(Client Repository)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Clients"]
      5([Client Id])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Technology Perspective


### Source code

[ClientRepository.cs](../../../../../../../Sources/Sales/Sales.DeepModel/Clients/ClientRepository.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Client Id](ClientId.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Clients](Clients.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)