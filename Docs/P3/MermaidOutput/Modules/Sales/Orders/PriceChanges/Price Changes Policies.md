
# Price Changes Policies

This view contains details information about Price Changes Policies building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["PriceChanges"]
      1(Price Changes Policies)
      class 1 DomainPerspective
    end
    subgraph 2["Clients"]
      3([Client Id])
      class 3 DomainPerspective
      4([Client Repository])
      class 4 DomainPerspective
    end
    subgraph 5["PriceChanges"]
      6([Allow Any Price Changes])
      class 6 DomainPerspective
      7([Allow Price Changes if Total Price Is Lower])
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
    0(Price Changes Policies)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Allow Any Price Changes](Allow Any Price Changes.md)  
[Allow Price Changes if Total Price Is Lower](Allow Price Changes if Total Price Is Lower.md)  

##### Ddd repositories

[Client Repository](../../Clients/Client Repository.md)  

##### Ddd value objects

[Client Id](../../Clients/Client Id.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[PriceChanges](PriceChanges.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)