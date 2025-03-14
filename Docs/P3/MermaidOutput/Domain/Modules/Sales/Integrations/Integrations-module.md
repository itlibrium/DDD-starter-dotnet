﻿
# Integrations

***Domain Module***  

This view contains details information about Integrations domain module, including:
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
    1(Integrations)
    class 1 DomainPerspective
    0---1
    1-->|is part of|0
    1---0
    2([Payments])
    class 2 DomainPerspective
    1-->|contains|2
    3([Products Delivery])
    class 3 DomainPerspective
    1-->|contains|3
    4([Risk Management])
    class 4 DomainPerspective
    1-->|contains|4
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
    0(Integrations)
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


##### Domain Modules

[Sales | Integrations | Payments](Payments/Payments-module.md)  
[Sales | Integrations | Products delivery](ProductsDelivery/ProductsDelivery-module.md)  
[Sales | Integrations | Risk management](RiskManagement/RiskManagement-module.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../../Technology/DeployableUnits/EcommerceMonolith.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales](../Sales-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)