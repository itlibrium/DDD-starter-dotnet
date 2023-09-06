
# Requesting

***Domain Module***  

This view contains details information about Requesting domain module, including:
- other related modules
- related processes
- related building blocks
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related modules

```mermaid
  flowchart TB
    0([Products Delivery])
    class 0 DomainPerspective
    1(Requesting)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Requesting)
    class 0 DomainPerspective
    1([Products Delivery])
    class 1 DomainPerspective
    0-->|takes part in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(Requesting)
    class 0 DomainPerspective
    1([Request Delivery])
    class 1 DomainPerspective
    0-->|contains|1
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


##### Processes

[Products Delivery](../../../Processes/Sale/Products delivery/ProductsDelivery.md)  

##### Process Steps

[Request Delivery](RequestDelivery.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Products Delivery](../ProductsDelivery.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)