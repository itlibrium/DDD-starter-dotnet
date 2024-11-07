﻿
# Payments

***Domain Module***  

This view contains details information about Payments domain module, including:
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
    0([Integrations])
    class 0 DomainPerspective
    1(Payments)
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

No direct building blocks were found.  

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Payments)
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


#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Integrations](../Integrations-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)