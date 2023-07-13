﻿
# [*Development team*] Supporting team

This view contains details information about Supporting team team, including:
- related domain modules
- related deployable units  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    0(Supporting team)
    class 0 PeoplePerspective
    1([Payments])
    class 1 DomainPerspective
    0-->|develops & maintains|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Supporting team)
    class 0 PeoplePerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|maintains|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [Development teams](../Development_Teams.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)