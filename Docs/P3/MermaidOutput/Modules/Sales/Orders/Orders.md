
# [*Domain module*] Orders

This view contains details information about Orders domain module, including:
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
    0(Orders)
    class 0 DomainPerspective
    1([Sales])
    class 1 DomainPerspective
    0-->|is part of|1
    2([PriceChanges])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Orders)
    class 0 DomainPerspective
    1([Wholesale ordering])
    class 1 DomainPerspective
    0-->|contains|1
    2([Online ordering])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(Orders)
    class 0 DomainPerspective
    1([PriceAgreement])
    class 1 DomainPerspective
    0-->|contains|1
    2([Order])
    class 2 DomainPerspective
    0-->|contains|2
    3([EventsSourcing])
    class 3 DomainPerspective
    0-->|contains|3
    4([Document])
    class 4 DomainPerspective
    0-->|contains|4
    5([Raw])
    class 5 DomainPerspective
    0-->|contains|5
    6([Factory])
    class 6 DomainPerspective
    0-->|contains|6
    7([Repository])
    class 7 DomainPerspective
    0-->|contains|7
    8([OrderId])
    class 8 DomainPerspective
    0-->|contains|8
    9([EF])
    class 9 DomainPerspective
    0-->|contains|9
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Orders)
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
    0(Orders)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [Business processes](../../../Business_Processes.md)

### Change perspective

- [[*Deployable unit*] ecommerce-monolith](../../../DeployableUnits/ecommerce-monolith.md)
- [[*Domain building block*] Factory](../../../BuildingBlocks/Sales/Orders/Factory.md)
- [[*Domain building block*] EF](../../../BuildingBlocks/Sales/Orders/EF.md)
- [[*Domain building block*] PriceAgreement](../../../BuildingBlocks/Sales/Orders/PriceAgreement.md)
- [[*Domain building block*] Document](../../../BuildingBlocks/Sales/Orders/Document.md)
- [[*Domain building block*] EventsSourcing](../../../BuildingBlocks/Sales/Orders/EventsSourcing.md)
- [[*Domain building block*] Raw](../../../BuildingBlocks/Sales/Orders/Raw.md)
- [[*Domain building block*] OrderId](../../../BuildingBlocks/Sales/Orders/OrderId.md)
- [[*Domain building block*] Order](../../../BuildingBlocks/Sales/Orders/Order.md)
- [[*Domain building block*] Repository](../../../BuildingBlocks/Sales/Orders/Repository.md)
- [[*Business process*] Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)
- [[*Business process*] Online ordering](../../../Processes/Sale/Online ordering/Online ordering.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)