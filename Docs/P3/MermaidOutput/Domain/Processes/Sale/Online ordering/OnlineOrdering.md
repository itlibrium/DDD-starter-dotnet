
# Online Ordering

***Process***  

This view contains details information about Online Ordering business process, including:
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
    1(Online Ordering)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([PlaceOrder])
    class 2 DomainPerspective
    1-->|contains|2
    3([PriceCart])
    class 3 DomainPerspective
    1-->|contains|3
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related domain modules

```mermaid
  flowchart TB
    0(Online Ordering)
    class 0 DomainPerspective
    1([Cart Pricing])
    class 1 DomainPerspective
    0-->|belongs to|1
    2([Order Placement])
    class 2 DomainPerspective
    0-->|belongs to|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

No related deployable units were found.  

## People Perspective


### Engaged people

```mermaid
  flowchart LR
    subgraph 0["Actors"]
      direction TB
      1([RetailClient])
      class 1 PeoplePerspective
    end
    2(Online Ordering)
    class 2 DomainPerspective
    0-->|uses|2
    subgraph 3["Teams"]
      direction TB
      4([no teams found])
    end
    2---3
    3-->|develops & maintains|2
    3---2
    subgraph 5["Business"]
      direction TB
      6([no units found])
    end
    2---5
    5-->|owns|2
    5---2
    linkStyle 1,3,4,6 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Process Steps

[PlaceOrder](../../../Concepts/Sales/OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[PriceCart](../../../Concepts/Sales/OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective

[Business Processes](../../BusinessProcesses.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)