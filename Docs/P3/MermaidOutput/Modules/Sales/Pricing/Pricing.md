
# Pricing

This view contains details information about Pricing domain module, including:
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
    1(Pricing)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([Discounts])
    class 2 DomainPerspective
    1-->|contains|2
    3([PriceLists])
    class 3 DomainPerspective
    1-->|contains|3
    4([SpecialOffers])
    class 4 DomainPerspective
    1-->|contains|4
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Pricing)
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
    0(Pricing)
    class 0 DomainPerspective
    1([Calculate Prices])
    class 1 DomainPerspective
    0-->|contains|1
    2([Individual Sales Conditions])
    class 2 DomainPerspective
    0-->|contains|2
    3([Offer])
    class 3 DomainPerspective
    0-->|contains|3
    4([Offer Modifier])
    class 4 DomainPerspective
    0-->|contains|4
    5([Offer Modifier 2])
    class 5 DomainPerspective
    0-->|contains|5
    6([Offer Modifiers])
    class 6 DomainPerspective
    0-->|contains|6
    7([Offer Request])
    class 7 DomainPerspective
    0-->|contains|7
    8([Price List Sql Repository])
    class 8 DomainPerspective
    0-->|contains|8
    9([Price Modifier])
    class 9 DomainPerspective
    0-->|contains|9
    10([Quote])
    class 10 DomainPerspective
    0-->|contains|10
    11([Quote Modifier])
    class 11 DomainPerspective
    0-->|contains|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Pricing)
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
    0(Pricing)
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

[Calculate Prices](Calculate Prices.md)  
[Individual Sales Conditions](Individual Sales Conditions.md)  
[Offer Modifier](Offer Modifier.md)  
[Offer Modifier 2](Offer Modifier 2.md)  
[Price Modifier](Price Modifier.md)  
[Quote Modifier](Quote Modifier.md)  

##### Ddd factories

[Offer Modifiers](Offer Modifiers.md)  

##### Ddd repositories

[Price List Sql Repository](Price List Sql Repository.md)  

##### Ddd value objects

[Offer](Offer.md)  
[Offer Request](Offer Request.md)  
[Quote](Quote.md)  

##### Domain modules

[Discounts](Discounts/Discounts.md)  
[PriceLists](PriceLists/PriceLists.md)  
[SpecialOffers](SpecialOffers/SpecialOffers.md)  

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