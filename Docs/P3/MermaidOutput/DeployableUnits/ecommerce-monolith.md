
# [*Deployable unit*] ecommerce-monolith

This view contains details information about ecommerce-monolith deployable unit, including:
- related domain modules
- related development teams  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    subgraph 0["Application"]
      1(ecommerce-monolith)
      class 1 TechnologyPerspective
      2([Contacts])
      class 2 DomainPerspective
      2-->|is deployed in|1
      3([Payments])
      class 3 DomainPerspective
      3-->|is deployed in|1
      4([ProductsDelivery])
      class 4 DomainPerspective
      4-->|is deployed in|1
      5([RiskManagement])
      class 5 DomainPerspective
      5-->|is deployed in|1
      6([Sales])
      class 6 DomainPerspective
      6-->|is deployed in|1
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## People Perspective


### Related development teams

```mermaid
  flowchart TB
    0(ecommerce-monolith)
    class 0 TechnologyPerspective
    1([Core team])
    class 1 PeoplePerspective
    1-->|maintains|0
    2([Inventory team])
    class 2 PeoplePerspective
    2-->|maintains|0
    3([Supporting team])
    class 3 PeoplePerspective
    3-->|maintains|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [Deployable units](../Deployable_Units.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)