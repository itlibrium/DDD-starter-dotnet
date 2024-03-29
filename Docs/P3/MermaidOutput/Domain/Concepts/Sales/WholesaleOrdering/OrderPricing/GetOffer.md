﻿
# Get Offer

***Process Step***  

This view contains details information about Get Offer business processes step, including:
- related process
- next process steps
- related domain module
- related deployable unit
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Process

```mermaid
  flowchart TB
    0(Get Offer)
    class 0 DomainPerspective
    1([Wholesale ordering])
    class 1 DomainPerspective
    0-->|is part of|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Used Building Blocks

```mermaid
  flowchart TB
    0(Get Offer)
    class 0 DomainPerspective
    1([Calculate Prices])
    class 1 DomainPerspective
    0-->|uses|1
    2([Client Id])
    class 2 DomainPerspective
    0-->|uses|2
    3([Offer])
    class 3 DomainPerspective
    0-->|uses|3
    4([Order])
    class 4 DomainPerspective
    0-->|uses|4
    5([Order Id])
    class 5 DomainPerspective
    0-->|uses|5
    6([Order Repository])
    class 6 DomainPerspective
    0-->|uses|6
    7([Quote])
    class 7 DomainPerspective
    0-->|uses|7
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

```mermaid
  flowchart TB
    0(Get Offer)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Source code

[GetOfferHandler.cs](../../../../../../../../Sources/Sales/Sales.ProcessModel/WholesaleOrdering/OrderPricing/GetOfferHandler.cs)  

## People Perspective

```mermaid
  flowchart TB
    0(Get Offer)
    class 0 DomainPerspective
    1([Wholesale Client])
    class 1 PeoplePerspective
    1-->|uses|0
    2([Core team])
    class 2 PeoplePerspective
    2-->|develops & maintains|0
    3([Sales department])
    class 3 PeoplePerspective
    3-->|owns|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Aggregates

[Order](../../Orders/Order.md)  

##### Ddd Domain Services

[Calculate Prices](../../Pricing/CalculatePrices.md)  

##### Ddd Repositories

[Order Repository](../../Orders/OrderRepository.md)  

##### Ddd Value Objects

[Client Id](../../Clients/ClientId.md)  
[Offer](../../Pricing/Offer.md)  
[Order Id](../../Orders/OrderId.md)  
[Quote](../../Pricing/Quote.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

#### People perspective


##### Business Organizational Units

[Sales department](../../../../../People/BusinessOrganizationalUnits/SalesDepartment.md)  

##### Development Teams

[Core team](../../../../../People/DevelopmentTeams/CoreTeam.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Wholesale ordering | Order pricing](OrderPricing.md)  

##### Processes

[Wholesale ordering](../../../../Processes/WholesaleOrdering.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)