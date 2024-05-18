
# Client Status

***Ddd Value Object***  

This view contains details information about Client Status building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Clients"]
      1([Client Repository])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Orders.PriceChanges"]
      3([Price Changes Policies])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Clients"]
      5(Client Status)
      class 5 DomainPerspective
    end
    0-->|depends on|4
    2-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

No related processes were found.  

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Clients](Clients-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)