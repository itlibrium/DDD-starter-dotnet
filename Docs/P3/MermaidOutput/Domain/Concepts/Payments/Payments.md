
# Payments

***Domain Module***  

This view contains details information about Payments domain module, including:
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
    0(Payments)
    class 0 DomainPerspective
    1([Requesting])
    class 1 DomainPerspective
    0-->|contains|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Payments)
    class 0 DomainPerspective
    1([Payment])
    class 1 DomainPerspective
    0-->|takes part in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

No direct building blocks were found.  

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Payments)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Source code

- [Payments](../../../../../../Sources/Payments/Payments.DeepModel)
- [Payments](../../../../../../Sources/Payments/Payments.ProcessModel)
- [Payments](../../../../../../Sources/Payments/Payments.Adapters.Api)
- [Payments](../../../../../../Sources/Payments/Payments.Adapters.Out)

## People Perspective


### Engaged people

```mermaid
  flowchart TB
    0(Payments)
    class 0 DomainPerspective
    1([Supporting team])
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


### Zoom-in


#### Domain perspective


##### Domain Modules

[Payments | Requesting](Requesting/Requesting.md)  

##### Processes

[Payment](../../Processes/Payment.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../Technology/DeployableUnits/EcommerceMonolith.md)  

#### People perspective


##### Business Organizational Units

[Sales department](../../../People/BusinessOrganizationalUnits/SalesDepartment.md)  

##### Development Teams

[Supporting team](../../../People/DevelopmentTeams/SupportingTeam.md)  

### Zoom-out


#### Domain perspective

[Domain Modules](../DomainModules.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)