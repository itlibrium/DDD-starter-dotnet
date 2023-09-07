
# Price Agreement Type

***Ddd Value Object***  

This view contains details information about Price Agreement Type building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Orders"]
      1([Order])
      class 1 DomainPerspective
      2([Order Price Agreement])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Orders"]
      4(Price Agreement Type)
      class 4 DomainPerspective
    end
    0-->|depends on|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)