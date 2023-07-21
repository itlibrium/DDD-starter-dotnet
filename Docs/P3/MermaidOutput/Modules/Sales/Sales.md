
# Sales

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
    3([ExchangeRates])
    class 3 DomainPerspective
    0-->|contains|3
    4([Integrations])
    class 4 DomainPerspective
    0-->|contains|4
    5([Orders])
    class 5 DomainPerspective
    0-->|contains|5
    6([Pricing])
    class 6 DomainPerspective
    0-->|contains|6
    7([Products])
    class 7 DomainPerspective
    0-->|contains|7
    8([SalesChannels])
    class 8 DomainPerspective
    0-->|contains|8
    9([Time])
    class 9 DomainPerspective
    0-->|contains|9
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
    0-->|contains|1
    2([Wholesale ordering])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

Module doesn't contain direct building blocks.  

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


##### Domain modules

[Clients](Clients/Clients.md)  
[Commons](Commons/Commons.md)  
[ExchangeRates](ExchangeRates/ExchangeRates.md)  
[Integrations](Integrations/Integrations.md)  
[Orders](Orders/Orders.md)  
[Pricing](Pricing/Pricing.md)  
[Products](Products/Products.md)  
[SalesChannels](SalesChannels/SalesChannels.md)  
[Time](Time/Time.md)  

##### Processes

[Online ordering](../../Processes/Sale/Online ordering/Online ordering.md)  
[Wholesale ordering](../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)  

#### Technology perspective


##### Deployable units

[ecommerce-monolith](../../DeployableUnits/ecommerce-monolith.md)  

#### People perspective


##### Business organizational units

[Sales department](../../BusinessOrganizationalUnits/Sales department.md)  

##### Development teams

[Core team](../../Teams/Core team.md)  

### Zoom-out


#### Domain perspective


##### Cross elements

[Domain Modules](../../Modules.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)