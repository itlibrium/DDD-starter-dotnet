
# PriceChanges

This view contains details information about PriceChanges domain module, including:
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
    0([Orders])
    class 0 DomainPerspective
    1(PriceChanges)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(PriceChanges)
    class 0 DomainPerspective
    1([Wholesale ordering])
    class 1 DomainPerspective
    0-->|contains|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(PriceChanges)
    class 0 DomainPerspective
    1([Allow Any Price Changes])
    class 1 DomainPerspective
    0-->|contains|1
    2([Allow Price Changes if Total Price Is Lower])
    class 2 DomainPerspective
    0-->|contains|2
    3([Price Changes Policies])
    class 3 DomainPerspective
    0-->|contains|3
    4([Price Changes Policy])
    class 4 DomainPerspective
    0-->|contains|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(PriceChanges)
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
    0(PriceChanges)
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


##### Ddd domain services

[Allow Any Price Changes](Allow Any Price Changes.md)  
[Allow Price Changes if Total Price Is Lower](Allow Price Changes if Total Price Is Lower.md)  
[Price Changes Policy](Price Changes Policy.md)  

##### Ddd factories

[Price Changes Policies](Price Changes Policies.md)  

##### Processes

[Wholesale ordering](../../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)  

#### Technology perspective


##### Deployable units

[ecommerce-monolith](../../../../DeployableUnits/ecommerce-monolith.md)  

#### People perspective


##### Business organizational units

[Sales department](../../../../BusinessOrganizationalUnits/Sales department.md)  

##### Development teams

[Core team](../../../../Teams/Core team.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Orders](../Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)