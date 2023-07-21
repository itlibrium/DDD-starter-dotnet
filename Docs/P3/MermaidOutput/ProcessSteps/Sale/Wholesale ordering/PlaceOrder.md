
# PlaceOrder

This view contains details information about PlaceOrder business processes step, including:
- related process
- next process steps
- related domain module
- related deployable unit
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Module & Process

```mermaid
  flowchart TB
    0(PlaceOrder)
    class 0 DomainPerspective
    1([Wholesale ordering])
    class 1 DomainPerspective
    0-->|is part of process|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Used Building Blocks

```mermaid
  flowchart TB
    0(PlaceOrder)
    class 0 DomainPerspective
    1([Clock])
    class 1 DomainPerspective
    0-->|uses|1
    2([Order])
    class 2 DomainPerspective
    0-->|uses|2
    3([Order Id])
    class 3 DomainPerspective
    0-->|uses|3
    4([Repository])
    class 4 DomainPerspective
    0-->|uses|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

```mermaid
  flowchart TB
    0(PlaceOrder)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## People Perspective

```mermaid
  flowchart TB
    0(PlaceOrder)
    class 0 DomainPerspective
    1([WholesaleClient])
    class 1 PeoplePerspective
    1-->|uses|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Processes

[Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)  

### Zoom-out


#### Domain perspective


##### Processes

[Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)