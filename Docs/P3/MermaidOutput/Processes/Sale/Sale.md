
# Sale

This view contains details information about Sale business process, including:
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
    0(Sale)
    class 0 DomainPerspective
    1([Fulfillment])
    class 1 DomainPerspective
    0-->|contains|1
    2([Online ordering])
    class 2 DomainPerspective
    0-->|contains|2
    3([Payment])
    class 3 DomainPerspective
    0-->|contains|3
    4([Products delivery])
    class 4 DomainPerspective
    0-->|contains|4
    5([Wholesale ordering])
    class 5 DomainPerspective
    0-->|contains|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related modules

```mermaid
  flowchart TB
    0(Sale)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Sale)
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
      2([WholesaleClient])
      class 2 PeoplePerspective
      1---2
    end
    3(Sale)
    class 3 DomainPerspective
    0-->|uses|3
    subgraph 4["Teams"]
      direction TB
    end
    3---4
    4-->|develops & maintains|3
    4---3
    subgraph 5["Business"]
      direction TB
    end
    3---5
    5-->|owns|3
    5---3
    linkStyle 0,2,4,5,7 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Processes

[Fulfillment](Fulfillment/Fulfillment.md)  
[Online ordering](Online ordering/Online ordering.md)  
[Payment](Payment/Payment.md)  
[Products delivery](Products delivery/Products delivery.md)  
[Wholesale ordering](Wholesale ordering/Wholesale ordering.md)  

### Zoom-out


#### Domain perspective


##### Cross elements

[Business processes](../../Business_Processes.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)