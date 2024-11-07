
# Confirm Offer

***Use Case***  

This view contains details information about Confirm Offer use case, including:
- related process
- related domain module
- related deployable unit
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Process

```mermaid
  flowchart TB
    0(Confirm Offer)
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
    0(Confirm Offer)
    class 0 DomainPerspective
    1([Calculate Prices])
    class 1 DomainPerspective
    0-->|uses|1
    2([Client Id])
    class 2 DomainPerspective
    0-->|uses|2
    3([Currency])
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
    10([Product Amount])
    class 10 DomainPerspective
    0-->|uses|10
    11([Sales Channel])
    class 11 DomainPerspective
    0-->|uses|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

```mermaid
  flowchart TB
    0(Confirm Offer)
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
    0(Confirm Offer)
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

##### Ddd Domain Services

[Calculate Prices](../../Pricing/CalculatePrices.md)  
[Price Changes Policy](../../Orders/PriceChanges/PriceChangesPolicy.md)  

##### Ddd Factories

[Price Changes Policies](../../Orders/PriceChanges/PriceChangesPolicies.md)  

##### Ddd Repositories

[Order Repository](../../Orders/OrderRepository.md)  

##### Ddd Value Objects

[Client Id](../../Clients/ClientId.md)  
[Currency](../../Commons/Currency.md)  
[Offer](../../Pricing/Offer.md)  
[Order Id](../../Orders/OrderId.md)  
[Product Amount](../../Products/ProductAmount.md)  
[Sales Channel](../../SalesChannels/SalesChannel.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Wholesale ordering | Order pricing](OrderPricing-module.md)  

##### Processes

[Wholesale Ordering](../../../../Processes/WholesaleOrdering.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)