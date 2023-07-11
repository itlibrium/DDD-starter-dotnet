
# [*Domain module*] RiskManagement

This view contains details information about RiskManagement domain module, including:
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
    0(RiskManagement)
    class 0 DomainPerspective
    1([Publication])
    class 1 DomainPerspective
    0-->|contains|1
    2([Calculation])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(RiskManagement)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

Module doesn't contain direct building blocks.  

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(RiskManagement)
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
    0(RiskManagement)
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


### Zoom-out

- [Business processes](../../Business_Processes.md)

### Change perspective

- [[*Deployable unit*] ecommerce-monolith](../../DeployableUnits/ecommerce-monolith.md)
- [[*Business organizational unit*] Sales department](../../BusinessOrganizationalUnits/Sales department.md)
- [[*Development team*] Core team](../../Teams/Core team.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)