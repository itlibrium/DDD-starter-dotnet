
# Sale

***Process***  

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
    2([Online Ordering])
    class 2 DomainPerspective
    0-->|contains|2
    3([Payment])
    class 3 DomainPerspective
    0-->|contains|3
    4([Products Delivery])
    class 4 DomainPerspective
    0-->|contains|4
    5([Wholesale Ordering])
    class 5 DomainPerspective
    0-->|contains|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related domain modules

```mermaid
  flowchart TB
    0(Sale)
    class 0 DomainPerspective
    1([Cart Pricing])
    class 1 DomainPerspective
    0-->|belongs to|1
    2([Fulfillment])
    class 2 DomainPerspective
    0-->|belongs to|2
    3([Order Creation])
    class 3 DomainPerspective
    0-->|belongs to|3
    4([Order Modification])
    class 4 DomainPerspective
    0-->|belongs to|4
    5([Order Placement])
    class 5 DomainPerspective
    0-->|belongs to|5
    6([Order Placement])
    class 6 DomainPerspective
    0-->|belongs to|6
    7([Order Pricing])
    class 7 DomainPerspective
    0-->|belongs to|7
    8([Product Pricing])
    class 8 DomainPerspective
    0-->|belongs to|8
    9([Requesting])
    class 9 DomainPerspective
    0-->|belongs to|9
    10([Requesting])
    class 10 DomainPerspective
    0-->|belongs to|10
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
      1([Retail Client])
      class 1 PeoplePerspective
      2([Wholesale Client])
      class 2 PeoplePerspective
      1---2
    end
    3(Sale)
    class 3 DomainPerspective
    0-->|uses|3
    subgraph 4["Teams"]
      direction TB
      5([no teams found])
    end
    3---4
    4-->|develops & maintains|3
    4---3
    subgraph 6["Business"]
      direction TB
      7([no units found])
    end
    3---6
    6-->|owns|3
    6---3
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
[Online Ordering](Online ordering/OnlineOrdering.md)  
[Payment](Payment/Payment.md)  
[Products Delivery](Products delivery/ProductsDelivery.md)  
[Wholesale Ordering](Wholesale ordering/WholesaleOrdering.md)  

### Zoom-out


#### Domain perspective

[Business Processes](../BusinessProcesses.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)