
# [*Domain module*] PriceLists

This view contains details information about PriceLists domain module, including:
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
    0(PriceLists)
    class 0 DomainPerspective
    1([Pricing])
    class 1 DomainPerspective
    0-->|is part of|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(PriceLists)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(PriceLists)
    class 0 DomainPerspective
    1([BasePrice])
    class 1 DomainPerspective
    0-->|contains|1
    2([BasePrices])
    class 2 DomainPerspective
    0-->|contains|2
    3([PriceListRepository])
    class 3 DomainPerspective
    0-->|contains|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(PriceLists)
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
    0(PriceLists)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [Business processes](../../../../Business_Processes.md)

### Change perspective

- [[*Deployable unit*] ecommerce-monolith](../../../../DeployableUnits/ecommerce-monolith.md)
- [[*Domain building block*] PriceListRepository](../../../../BuildingBlocks/Sales/Pricing/PriceLists/PriceListRepository.md)
- [[*Domain building block*] BasePrices](../../../../BuildingBlocks/Sales/Pricing/PriceLists/BasePrices.md)
- [[*Domain building block*] BasePrice](../../../../BuildingBlocks/Sales/Pricing/PriceLists/BasePrice.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)