
# Online ordering

This view contains details information about Online ordering business process, including:
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
    0(Online ordering)
    class 0 DomainPerspective
    1([Sale])
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([PlaceOrder])
    class 2 DomainPerspective
    0-->|contains|2
    3([PriceCart])
    class 3 DomainPerspective
    0-->|contains|3
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related modules

```mermaid
  flowchart TB
    0(Online ordering)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Online ordering)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## People Perspective


### Engaged people

```mermaid
  flowchart LR
    subgraph 0["Actors"]
      direction TB
      1([RetailClient])
      class 1 PeoplePerspective
    end
    2(Online ordering)
    class 2 DomainPerspective
    0-->|uses|2
    subgraph 3["Teams"]
      direction TB
    end
    2---3
    3-->|develops & maintains|2
    3---2
    subgraph 4["Business"]
      direction TB
    end
    2---4
    4-->|owns|2
    4---2
    linkStyle 1,3,4,6 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Process steps

[PlaceOrder](../../../ProcessSteps/Sale/Online ordering/PlaceOrder.md)  
[PriceCart](../../../ProcessSteps/Sale/Online ordering/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Cross elements

[Business processes](../../../Business_Processes.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)