
# Products Delivery

***Domain Module***  

This view contains details information about Products Delivery domain module, including:
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
    0(Products Delivery)
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
    0(Products Delivery)
    class 0 DomainPerspective
    1([Products delivery])
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
    0(Products Delivery)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Source code

- [ProductsDelivery](../../../../../../Sources/ProductsDelivery/ProductsDelivery.Adapters.Out)
- [ProductsDelivery](../../../../../../Sources/ProductsDelivery/ProductsDelivery.ProcessModel)
- [ProductsDelivery](../../../../../../Sources/ProductsDelivery/ProductsDelivery.Adapters.Api)
- [ProductsDelivery](../../../../../../Sources/ProductsDelivery/ProductsDelivery.DeepModel)

## People Perspective


### Engaged people

```mermaid
  flowchart TB
    0(Products Delivery)
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


### Zoom-in


#### Domain perspective


##### Domain Modules

[Products delivery | Requesting](Requesting/Requesting.md)  

##### Processes

[Products delivery](../../Processes/ProductsDelivery.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../../Technology/DeployableUnits/EcommerceMonolith.md)  

#### People perspective


##### Business Organizational Units

[Inventory department](../../../People/BusinessOrganizationalUnits/InventoryDepartment.md)  

##### Development Teams

[Inventory team](../../../People/DevelopmentTeams/InventoryTeam.md)  

### Zoom-out


#### Domain perspective

[Domain Modules](../DomainModules.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)