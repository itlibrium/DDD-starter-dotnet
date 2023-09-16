
# Wholesale Ordering

***Domain Module***  

This view contains details information about Wholesale Ordering domain module, including:
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
    0([Sales])
    class 0 DomainPerspective
    1(Wholesale Ordering)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([Order Creation])
    class 2 DomainPerspective
    1-->|contains|2
    3([Order Modification])
    class 3 DomainPerspective
    1-->|contains|3
    4([Order Placement])
    class 4 DomainPerspective
    1-->|contains|4
    5([Order Pricing])
    class 5 DomainPerspective
    1-->|contains|5
    6([Product Pricing])
    class 6 DomainPerspective
    1-->|contains|6
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

No related processes were found.  

### Direct building blocks

No direct building blocks were found.  

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
  flowchart TB
    0(Wholesale Ordering)
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

[Sales | Wholesale ordering | Order creation](OrderCreation/OrderCreation.md)  
[Sales | Wholesale ordering | Order modification](OrderModification/OrderModification.md)  
[Sales | Wholesale ordering | Order placement](OrderPlacement/OrderPlacement.md)  
[Sales | Wholesale ordering | Order pricing](OrderPricing/OrderPricing.md)  
[Sales | Wholesale ordering | Product pricing](ProductPricing/ProductPricing.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

#### People perspective


##### Business Organizational Units

[Sales department](../../../../People/BusinessOrganizationalUnits/SalesDepartment.md)  

##### Development Teams

[Core team](../../../../People/DevelopmentTeams/CoreTeam.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales](../Sales.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)