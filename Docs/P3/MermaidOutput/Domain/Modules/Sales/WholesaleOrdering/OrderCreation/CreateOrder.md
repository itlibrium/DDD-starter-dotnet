﻿
# Create Order

***Use Case***  

This view contains details information about Create Order use case, including:
- related process
- related domain module
- related deployable unit
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Process

```mermaid
  flowchart TB
    0(Create Order)
    class 0 DomainPerspective
    1([Wholesale Ordering])
    class 1 DomainPerspective
    0-->|is part of|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Used Building Blocks

```mermaid
  flowchart TB
    0(Create Order)
    class 0 DomainPerspective
    1([Client Id])
    class 1 DomainPerspective
    0-->|uses|1
    2([Order])
    class 2 DomainPerspective
    0-->|uses|2
    3([Order Factory])
    class 3 DomainPerspective
    0-->|uses|3
    4([Order Header])
    class 4 DomainPerspective
    0-->|uses|4
    5([Order Repository])
    class 5 DomainPerspective
    0-->|uses|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

```mermaid
  flowchart TB
    0(Create Order)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Source code

No source code files were found.  

## People Perspective

```mermaid
  flowchart TB
    0(Create Order)
    class 0 DomainPerspective
    1([Wholesale Client])
    class 1 PeoplePerspective
    1-->|uses|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Aggregates

[Order](../../Orders/Order.md)  

##### Ddd Entities

[Order Header](../../Orders/OrderHeader.md)  

##### Ddd Factories

[Order Factory](../../Orders/OrderFactory.md)  

##### Ddd Repositories

[Order Repository](../../Orders/OrderRepository.md)  

##### Ddd Value Objects

[Client Id](../../Clients/ClientId.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Wholesale ordering | Order creation](OrderCreation-module.md)  

##### Processes

[Wholesale Ordering](../../../../Processes/WholesaleOrdering.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)