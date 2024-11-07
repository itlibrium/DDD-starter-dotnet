
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
    1([Online Ordering])
    class 1 DomainPerspective
    0-->|takes part in|1
    2([Wholesale Ordering])
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
    1([Invoicing Details])
    class 1 DomainPerspective
    0-->|contains|1
    2([Order])
    class 2 DomainPerspective
    0-->|contains|2
    3([Order Factory])
    class 3 DomainPerspective
    0-->|contains|3
    4([Order Header])
    class 4 DomainPerspective
    0-->|contains|4
    5([Order Id])
    class 5 DomainPerspective
    0-->|contains|5
    6([Order Item Details])
    class 6 DomainPerspective
    0-->|contains|6
    7([Order Note])
    class 7 DomainPerspective
    0-->|contains|7
    8([Order Price Agreement])
    class 8 DomainPerspective
    0-->|contains|8
    9([Order Repository])
    class 9 DomainPerspective
    0-->|contains|9
    10([Price Agreement Type])
    class 10 DomainPerspective
    0-->|contains|10
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

No source code files were found.  

## People Perspective


### Engaged people

No engaged people were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Aggregates

[Order](Order.md)  

##### Ddd Entities

[Order Header](OrderHeader.md)  
[Order Note](OrderNote.md)  

##### Ddd Factories

[Order Factory](OrderFactory.md)  

##### Ddd Repositories

[Order Repository](OrderRepository.md)  

##### Ddd Value Objects

[Invoicing Details](InvoicingDetails.md)  
[Order Id](OrderId.md)  
[Order Item Details](OrderItemDetails.md)  
[Order Price Agreement](OrderPriceAgreement.md)  
[Price Agreement Type](PriceAgreementType.md)  

##### Domain Modules

[Sales | Orders | Price changes](PriceChanges/PriceChanges-module.md)  

##### Processes

[Online Ordering](../../../Processes/OnlineOrdering.md)  
[Wholesale Ordering](../../../Processes/WholesaleOrdering.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales](../Sales-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)