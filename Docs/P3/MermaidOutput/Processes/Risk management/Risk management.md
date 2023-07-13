
# [*Business process*] Risk management

This view contains details information about Risk management business process, including:
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
    0(Risk management)
    class 0 DomainPerspective
    1([Risk score calculation])
    class 1 DomainPerspective
    0-->|contains|1
    2([Risk score publication])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related modules

```mermaid
  flowchart TB
    0(Risk management)
    class 0 DomainPerspective
    1([RiskManagement])
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
    0(Risk management)
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
    end
    1(Risk management)
    class 1 DomainPerspective
    0-->|uses|1
    subgraph 2["Teams"]
      direction TB
      3([Core team])
      class 3 PeoplePerspective
    end
    2---1
    2-->|develops & maintains|1
    1---2
    subgraph 4["Business"]
      direction TB
      5([Sales department])
      class 5 PeoplePerspective
    end
    4---1
    4-->|owns|1
    1---4
    linkStyle 1,3,4,6 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in

  - [[*Business process*] Risk score calculation](Risk score calculation/Risk score calculation.md)
  - [[*Business process*] Risk score publication](Risk score publication/Risk score publication.md)

### Zoom-out

- [Business processes](../../Business_Processes.md)

### Change perspective

- [[*Business organizational unit*] Sales department](../../BusinessOrganizationalUnits/Sales department.md)
- [[*Deployable unit*] ecommerce-monolith](../../DeployableUnits/ecommerce-monolith.md)
- [[*Development team*] Core team](../../Teams/Core team.md)
- [[*Business process*] Risk score publication](Risk score publication/Risk score publication.md)
- [[*Business process*] Risk score calculation](Risk score calculation/Risk score calculation.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)