
# Orders

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
    2([PriceChanges])
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
    0-->|contains|1
    2([Wholesale ordering])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(Orders)
    class 0 DomainPerspective
    1([Document])
    class 1 DomainPerspective
    0-->|contains|1
    2([EF])
    class 2 DomainPerspective
    0-->|contains|2
    3([Events Sourcing])
    class 3 DomainPerspective
    0-->|contains|3
    4([Factory])
    class 4 DomainPerspective
    0-->|contains|4
    5([Order])
    class 5 DomainPerspective
    0-->|contains|5
    6([Order Id])
    class 6 DomainPerspective
    0-->|contains|6
    7([Price Agreement])
    class 7 DomainPerspective
    0-->|contains|7
    8([Raw])
    class 8 DomainPerspective
    0-->|contains|8
    9([Repository])
    class 9 DomainPerspective
    0-->|contains|9
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


##### Ddd aggregates

[Order](Order.md)  

##### Ddd factories

[Factory](Factory.md)  

##### Ddd repositories

[Document](Document.md)  
[EF](EF.md)  
[Events Sourcing](Events Sourcing.md)  
[Raw](Raw.md)  
[Repository](Repository.md)  

##### Ddd value objects

[Order Id](Order Id.md)  
[Price Agreement](Price Agreement.md)  

##### Domain modules

[PriceChanges](PriceChanges/PriceChanges.md)  

##### Processes

[Online ordering](../../../Processes/Sale/Online ordering/Online ordering.md)  
[Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)  

#### Technology perspective


##### Deployable units

[ecommerce-monolith](../../../DeployableUnits/ecommerce-monolith.md)  

#### People perspective


##### Business organizational units

[Sales department](../../../BusinessOrganizationalUnits/Sales department.md)  

##### Development teams

[Core team](../../../Teams/Core team.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Sales](../Sales.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)