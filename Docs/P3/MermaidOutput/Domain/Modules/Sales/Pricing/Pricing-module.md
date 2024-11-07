﻿
# Pricing

***Domain Module***  

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
    3([Price Lists])
    class 3 DomainPerspective
    1-->|contains|3
    4([Special Offers])
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
    0(Pricing)
    class 0 DomainPerspective
    1([Aggregated Modifier])
    class 1 DomainPerspective
    0-->|contains|1
    2([Calculate Prices])
    class 2 DomainPerspective
    0-->|contains|2
    3([Individual Sales Conditions])
    class 3 DomainPerspective
    0-->|contains|3
    4([Offer])
    class 4 DomainPerspective
    0-->|contains|4
    5([Offer Modifier])
    class 5 DomainPerspective
    0-->|contains|5
    6([Offer Modifier 2])
    class 6 DomainPerspective
    0-->|contains|6
    7([Offer Modifiers])
    class 7 DomainPerspective
    0-->|contains|7
    8([Offer Request])
    class 8 DomainPerspective
    0-->|contains|8
    9([Quote])
    class 9 DomainPerspective
    0-->|contains|9
    10([Quote Modifier])
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
    0(Pricing)
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


##### Ddd Domain Services

[Aggregated Modifier](AggregatedModifier.md)  
[Calculate Prices](CalculatePrices.md)  
[Individual Sales Conditions](IndividualSalesConditions.md)  
[Offer Modifier](OfferModifier.md)  
[Offer Modifier 2](OfferModifier2.md)  
[Quote Modifier](QuoteModifier.md)  

##### Ddd Factories

[Offer Modifiers](OfferModifiers.md)  

##### Ddd Value Objects

[Offer](Offer.md)  
[Offer Request](OfferRequest.md)  
[Quote](Quote.md)  

##### Domain Modules

[Sales | Pricing | Discounts](Discounts/Discounts-module.md)  
[Sales | Pricing | Price lists](PriceLists/PriceLists-module.md)  
[Sales | Pricing | Special offers](SpecialOffers/SpecialOffers-module.md)  

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