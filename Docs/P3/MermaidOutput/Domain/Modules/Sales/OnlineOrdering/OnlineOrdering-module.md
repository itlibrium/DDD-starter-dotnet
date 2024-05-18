
# Online Ordering

***Domain Module***  

This view contains details information about Online Ordering domain module, including:
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
    1(Online Ordering)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([Cart Pricing])
    class 2 DomainPerspective
    1-->|contains|2
    3([Order Placement])
    class 3 DomainPerspective
    1-->|contains|3
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Online Ordering)
    class 0 DomainPerspective
    1([Online Ordering])
    class 1 DomainPerspective
    0-->|takes part in|1
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
    0(Online Ordering)
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

```mermaid
  flowchart TB
    0(Online Ordering)
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

## Next use cases


### Zoom-in


#### Domain perspective


##### Domain Modules

[Sales | Online ordering | Cart pricing](CartPricing/CartPricing-module.md)  
[Sales | Online ordering | Order placement](OrderPlacement/OrderPlacement-module.md)  

##### Processes

[Online Ordering](../../../Processes/OnlineOrdering.md)  

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

[Sales](../Sales-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)