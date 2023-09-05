
# ConfirmOffer

***Process Step***  

This view contains details information about ConfirmOffer business processes step, including:
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
    0(ConfirmOffer)
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
    0(ConfirmOffer)
    class 0 DomainPerspective
    1([Calculate Prices])
    class 1 DomainPerspective
    0-->|uses|1
    2([Client Id])
    class 2 DomainPerspective
    0-->|uses|2
    3([Clock])
    class 3 DomainPerspective
    0-->|uses|3
    4([Offer])
    class 4 DomainPerspective
    0-->|uses|4
    5([Order])
    class 5 DomainPerspective
    0-->|uses|5
    6([Order Id])
    class 6 DomainPerspective
    0-->|uses|6
    7([Order Repository])
    class 7 DomainPerspective
    0-->|uses|7
    8([Price Changes Policies])
    class 8 DomainPerspective
    0-->|uses|8
    9([Price Changes Policy])
    class 9 DomainPerspective
    0-->|uses|9
    10([Quote])
    class 10 DomainPerspective
    0-->|uses|10
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

```mermaid
  flowchart TB
    0(ConfirmOffer)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## People Perspective

```mermaid
  flowchart TB
    0(ConfirmOffer)
    class 0 DomainPerspective
    1([WholesaleClient])
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
[Clock](../../Time/Clock.md)  
[Price Changes Policy](../../Orders/PriceChanges/PriceChangesPolicy.md)  

##### Ddd Factories

[Price Changes Policies](../../Orders/PriceChanges/PriceChangesPolicies.md)  

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

[Order Pricing](OrderPricing.md)  

##### Processes

[Wholesale Ordering](../../../../Processes/Sale/Wholesale ordering/WholesaleOrdering.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)