
# [*Process Step*] GetOffer

This view contains details information about GetOffer business processes step, including:
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
    0(GetOffer)
    class 0 DomainPerspective
    1([Wholesale ordering])
    class 1 DomainPerspective
    0-->|is part of process|1
    2([OrderPricing])
    class 2 DomainPerspective
    0-->|belongs to module|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Used Building Blocks

```mermaid
  flowchart TB
    0(GetOffer)
    class 0 DomainPerspective
    1([Repository])
    class 1 DomainPerspective
    0-->|uses|1
    2([OrderId])
    class 2 DomainPerspective
    0-->|uses|2
    3([Order])
    class 3 DomainPerspective
    0-->|uses|3
    4([Quote])
    class 4 DomainPerspective
    0-->|uses|4
    5([Offer])
    class 5 DomainPerspective
    0-->|uses|5
    6([ClientId])
    class 6 DomainPerspective
    0-->|uses|6
    7([CalculatePrices])
    class 7 DomainPerspective
    0-->|uses|7
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

```mermaid
  flowchart TB
    0(GetOffer)
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
    0(GetOffer)
    class 0 DomainPerspective
    1([WholesaleClient])
    class 1 PeoplePerspective
    1-->|uses|0
    2([Core team])
    class 2 PeoplePerspective
    2-->|develops & maintains|0
    3([Sales department])
    class 3 PeoplePerspective
    3-->|owns|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Business process*] Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)

### Change perspective

- [[*Deployable unit*] ecommerce-monolith](../../../DeployableUnits/ecommerce-monolith.md)
- [[*Business organizational unit*] Sales department](../../../BusinessOrganizationalUnits/Sales department.md)
- [[*Development team*] Core team](../../../Teams/Core team.md)
- [[*Domain module*] OrderPricing](../../../Modules/Sales/WholesaleOrdering/OrderPricing/OrderPricing.md)
- [[*Business process*] Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)