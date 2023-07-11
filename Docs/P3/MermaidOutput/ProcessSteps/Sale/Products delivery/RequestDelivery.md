
# [*Process Step*] RequestDelivery

This view contains details information about RequestDelivery business processes step, including:
- related process
- next process steps
- related domain module
- related deployable unit
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Module & Process

```mermaid
  flowchart TB
    0(RequestDelivery)
    class 0 DomainPerspective
    1([Products delivery])
    class 1 DomainPerspective
    0-->|is part of process|1
    2([Requesting])
    class 2 DomainPerspective
    0-->|belongs to module|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Used Building Blocks

No building blocks are used. Maybe this process step is not implemented yet?  

## Technology Perspective

```mermaid
  flowchart TB
    0(RequestDelivery)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## People Perspective

```mermaid
  flowchart TB
    0(RequestDelivery)
    class 0 DomainPerspective
    1([Inventory team])
    class 1 PeoplePerspective
    1-->|develops & maintains|0
    2([Inventory department])
    class 2 PeoplePerspective
    2-->|owns|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Business process*] Products delivery](../../../Processes/Sale/Products delivery/Products delivery.md)

### Change perspective

- [[*Deployable unit*] ecommerce-monolith](../../../DeployableUnits/ecommerce-monolith.md)
- [[*Business organizational unit*] Inventory department](../../../BusinessOrganizationalUnits/Inventory department.md)
- [[*Development team*] Inventory team](../../../Teams/Inventory team.md)
- [[*Domain module*] Requesting](../../../Modules/ProductsDelivery/Requesting/Requesting.md)
- [[*Business process*] Products delivery](../../../Processes/Sale/Products delivery/Products delivery.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)