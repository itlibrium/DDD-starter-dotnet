﻿
# [*Business process*] Online ordering

This view contains details information about Online ordering business process, including:
- other related processes
- process steps
- related domain modules
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related processes and steps

```mermaid
  flowchart TB
    0(Online ordering)
    class 0 DomainPerspective
    1([Sale])
    class 1 DomainPerspective
    1---0
    1-->|is part of|0
    0---1
    2([PlaceOrder])
    class 2 DomainPerspective
    0-->|contains|2
    3([PriceCart])
    class 3 DomainPerspective
    0-->|contains|3
    linkStyle 0,2 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related modules

```mermaid
  flowchart TB
    0(Online ordering)
    class 0 DomainPerspective
    1([Sales])
    class 1 DomainPerspective
    0-->|belongs to|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Online ordering)
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
  flowchart LR
    subgraph 0["Actors"]
      direction TB
      1([RetailClient])
      class 1 PeoplePerspective
    end
    2(Online ordering)
    class 2 DomainPerspective
    0-->|uses|2
    subgraph 3["Teams"]
      direction TB
      4([Core team])
      class 4 PeoplePerspective
    end
    3---2
    3-->|develops & maintains|2
    2---3
    subgraph 5["Business"]
      direction TB
      6([Sales department])
      class 6 PeoplePerspective
    end
    5---2
    5-->|owns|2
    2---5
    linkStyle 1,3,4,6 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in

- [[*Process Step*] PlaceOrder](../../../ProcessSteps/Sale/Online ordering/PlaceOrder.md)
- [[*Process Step*] PriceCart](../../../ProcessSteps/Sale/Online ordering/PriceCart.md)

### Zoom-out

- [Business processes](../../../Business_Processes.md)

### Change perspective

- [[*Business organizational unit*] Sales department](../../../BusinessOrganizationalUnits/Sales department.md)
- [[*Deployable unit*] ecommerce-monolith](../../../DeployableUnits/ecommerce-monolith.md)
- [[*Development team*] Core team](../../../Teams/Core team.md)
- [[*Process Step*] PlaceOrder](../../../ProcessSteps/Sale/Online ordering/PlaceOrder.md)
- [[*Process Step*] PriceCart](../../../ProcessSteps/Sale/Online ordering/PriceCart.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)