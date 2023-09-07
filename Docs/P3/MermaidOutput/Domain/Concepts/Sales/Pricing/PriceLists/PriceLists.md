
# Price Lists

***Domain Module***  

This view contains details information about Price Lists domain module, including:
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
    0([Pricing])
    class 0 DomainPerspective
    1(Price Lists)
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

No related processes were found.  

### Direct building blocks

```mermaid
  flowchart TB
    0(Price Lists)
    class 0 DomainPerspective
    1([Base Price])
    class 1 DomainPerspective
    0-->|contains|1
    2([Base Prices])
    class 2 DomainPerspective
    0-->|contains|2
    3([Price List Repository])
    class 3 DomainPerspective
    0-->|contains|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Price Lists)
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
    0(Price Lists)
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


##### Ddd Repositories

[Price List Repository](PriceListRepository.md)  

##### Ddd Value Objects

[Base Price](BasePrice.md)  
[Base Prices](BasePrices.md)  

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

[Sales | Pricing](../Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)