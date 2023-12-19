
# Orders

***Domain Module***  

This view contains details information about Orders domain module, including:
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
    1(Orders)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([Price Changes])
    class 2 DomainPerspective
    1-->|contains|2
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Orders)
    class 0 DomainPerspective
    1([Online ordering])
    class 1 DomainPerspective
    0-->|takes part in|1
    2([Wholesale ordering])
    class 2 DomainPerspective
    0-->|takes part in|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(Orders)
    class 0 DomainPerspective
    1([Order])
    class 1 DomainPerspective
    0-->|contains|1
    2([Order Factory])
    class 2 DomainPerspective
    0-->|contains|2
    3([Order Id])
    class 3 DomainPerspective
    0-->|contains|3
    4([Order Price Agreement])
    class 4 DomainPerspective
    0-->|contains|4
    5([Order Repository])
    class 5 DomainPerspective
    0-->|contains|5
    6([Price Agreement Type])
    class 6 DomainPerspective
    0-->|contains|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Orders)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Source code

- [Orders](../../../../../../../Sources/Sales/Sales.DeepModel/Orders)
- [Orders](../../../../../../../Sources/Sales/Sales.IntegrationTests/Orders)
- [Orders](../../../../../../../Sources/Sales/Sales.Adapters/Orders)

## People Perspective


### Engaged people

```mermaid
  flowchart TB
    0(Orders)
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


##### Ddd Aggregates

[Order](Order.md)  

##### Ddd Factories

[Order Factory](OrderFactory.md)  

##### Ddd Repositories

[Order Repository](OrderRepository.md)  

##### Ddd Value Objects

[Order Id](OrderId.md)  
[Order Price Agreement](OrderPriceAgreement.md)  
[Price Agreement Type](PriceAgreementType.md)  

##### Domain Modules

[Sales | Orders | Price changes](PriceChanges/PriceChanges.md)  

##### Processes

[Online ordering](../../../Processes/OnlineOrdering.md)  
[Wholesale ordering](../../../Processes/WholesaleOrdering.md)  

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