﻿
# Wholesale Ordering

***Process***  

This view contains details information about Wholesale Ordering business process, including:
- use cases
- related domain modules
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related use cases

```mermaid
  flowchart TB
    0(Wholesale Ordering)
    class 0 DomainPerspective
    1([Add to Order])
    class 1 DomainPerspective
    0-->|contains|1
    2([Confirm Offer])
    class 2 DomainPerspective
    0-->|contains|2
    3([Create Order])
    class 3 DomainPerspective
    0-->|contains|3
    4([Create Order])
    class 4 DomainPerspective
    0-->|contains|4
    5([Get Offer])
    class 5 DomainPerspective
    0-->|contains|5
    6([Place Order])
    class 6 DomainPerspective
    0-->|contains|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related top level domain modules

```mermaid
  flowchart TB
    0(Wholesale Ordering)
    class 0 DomainPerspective
    1([Sales])
    class 1 DomainPerspective
    0-->|belongs to|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Wholesale Ordering)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
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
      1([Wholesale Client])
      class 1 PeoplePerspective
    end
    2(Wholesale Ordering)
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

## Next use cases


### Zoom-in


#### Domain perspective


##### Use Cases

[Add to Order](../Modules/Sales/WholesaleOrdering/OrderModification/AddToOrder.md)  
[Confirm Offer](../Modules/Sales/WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../Modules/Sales/WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Create Order](../Modules/Sales/WholesaleOrdering/ProductPricing/CreateOrder.md)  
[Get Offer](../Modules/Sales/WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../Modules/Sales/WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../Technology/DeployableUnits/EcommerceMonolith.md)  

### Zoom-out


#### Domain perspective

[Business Processes](BusinessProcesses.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)