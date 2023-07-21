
# Events Sourcing

This view contains details information about Events Sourcing building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Orders"]
      1(Events Sourcing)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
    end
    subgraph 4["Orders"]
      5([Order])
      class 5 DomainPerspective
      6([Order Id])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Events Sourcing is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd aggregates

[Order](Order.md)  

##### Ddd value objects

[Money](../Commons/Money.md)  
[Order Id](Order Id.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)