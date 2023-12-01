
# Sales

***Domain Module***  

This view contains details information about Sales domain module, including:
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
    0(Sales)
    class 0 DomainPerspective
    1([Clients])
    class 1 DomainPerspective
    0-->|contains|1
    2([Commons])
    class 2 DomainPerspective
    0-->|contains|2
    3([Exchange Rates])
    class 3 DomainPerspective
    0-->|contains|3
    4([Fulfillment])
    class 4 DomainPerspective
    0-->|contains|4
    5([Online Ordering])
    class 5 DomainPerspective
    0-->|contains|5
    6([Orders])
    class 6 DomainPerspective
    0-->|contains|6
    7([Pricing])
    class 7 DomainPerspective
    0-->|contains|7
    8([Products])
    class 8 DomainPerspective
    0-->|contains|8
    9([Sales Channels])
    class 9 DomainPerspective
    0-->|contains|9
    10([Time])
    class 10 DomainPerspective
    0-->|contains|10
    11([Wholesale Ordering])
    class 11 DomainPerspective
    0-->|contains|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Sales)
    class 0 DomainPerspective
    1([Online ordering])
    class 1 DomainPerspective
    0-->|takes part in|1
    2([Order fulfillment])
    class 2 DomainPerspective
    0-->|takes part in|2
    3([Wholesale ordering])
    class 3 DomainPerspective
    0-->|takes part in|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

No direct building blocks were found.  

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Sales)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Source code

- [Sales](../../../../../../Sources/Sales/Sales.ProcessModel)
- [Sales](../../../../../../Sources/Sales/Sales.RestApi/OnlineOrdering)
- [Sales](../../../../../../Sources/Sales/Sales.Adapters/Clients)
- [Sales](../../../../../../Sources/Sales/Sales.DeepModel/Clients)

## People Perspective


### Engaged people

```mermaid
  flowchart TB
    0(Sales)
    class 0 DomainPerspective
    1([Core team])
    class 1 PeoplePerspective
    1-->|develops & maintains|0
    2([Sales department])
    class 2 PeoplePerspective
    2-->|owns|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Domain Modules

[Sales | Clients](Clients/Clients.md)  
[Sales | Commons](Commons/Commons.md)  
[Sales | Exchange rates](ExchangeRates/ExchangeRates.md)  
[Sales | Fulfillment](Fulfillment/Fulfillment.md)  
[Sales | Online ordering](OnlineOrdering/OnlineOrdering.md)  
[Sales | Orders](Orders/Orders.md)  
[Sales | Pricing](Pricing/Pricing.md)  
[Sales | Products](Products/Products.md)  
[Sales | Sales channels](SalesChannels/SalesChannels.md)  
[Sales | Time](Time/Time.md)  
[Sales | Wholesale ordering](WholesaleOrdering/WholesaleOrdering.md)  

##### Processes

[Online ordering](../../Processes/OnlineOrdering.md)  
[Order fulfillment](../../Processes/OrderFulfillment.md)  
[Wholesale ordering](../../Processes/WholesaleOrdering.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../Technology/DeployableUnits/EcommerceMonolith.md)  

#### People perspective


##### Business Organizational Units

[Sales department](../../../People/BusinessOrganizationalUnits/SalesDepartment.md)  

##### Development Teams

[Core team](../../../People/DevelopmentTeams/CoreTeam.md)  

### Zoom-out


#### Domain perspective

[Domain Modules](../DomainModules.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)