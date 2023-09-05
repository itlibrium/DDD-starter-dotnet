
# Products Delivery

***Process***  

This view contains details information about Products Delivery business process, including:
- other related processes
- process steps
- related domain modules
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related processes and steps

```mermaid
  flowchart TB
    0([Sale])
    class 0 DomainPerspective
    1(Products Delivery)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([RequestDelivery])
    class 2 DomainPerspective
    1-->|contains|2
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related domain modules

```mermaid
  flowchart TB
    0(Products Delivery)
    class 0 DomainPerspective
    1([Requesting])
    class 1 DomainPerspective
    0-->|belongs to|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

No related deployable units were found.  

## People Perspective


### Engaged people

No engaged people were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Process Steps

[RequestDelivery](../../../Concepts/ProductsDelivery/Requesting/RequestDelivery.md)  

### Zoom-out


#### Domain perspective

[Business Processes](../../BusinessProcesses.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)