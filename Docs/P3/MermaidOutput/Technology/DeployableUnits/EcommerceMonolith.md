
# ecommerce-monolith

***Deployable Unit***  

This view contains details information about ecommerce-monolith deployable unit, including:
- related domain modules
- related development teams  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    0(ecommerce-monolith)
    class 0 TechnologyPerspective
    1([Contacts])
    class 1 DomainPerspective
    1-->|is deployed in|0
    2([Payments])
    class 2 DomainPerspective
    2-->|is deployed in|0
    3([Products Delivery])
    class 3 DomainPerspective
    3-->|is deployed in|0
    4([Risk Management])
    class 4 DomainPerspective
    4-->|is deployed in|0
    5([Sales])
    class 5 DomainPerspective
    5-->|is deployed in|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Tier, CSharp Projects and their Layers

```mermaid
  flowchart TB
    subgraph 0["Application Tier"]
      subgraph 1["ecommerce-monolith"]
        subgraph 2["Adapters Layer"]
          3([MyCompany.ECommerce.Sales.Adapters])
          class 3 TechnologyPerspective
          4([MyCompany.ECommerce.Sales.RestApi])
          class 4 TechnologyPerspective
        end
        subgraph 5["Entities Layer"]
          6([MyCompany.ECommerce.Payments.DeepModel])
          class 6 TechnologyPerspective
          7([MyCompany.ECommerce.ProductsDelivery.DeepModel])
          class 7 TechnologyPerspective
          8([MyCompany.ECommerce.RiskManagement.DeepModel])
          class 8 TechnologyPerspective
          9([MyCompany.ECommerce.Sales.DeepModel])
          class 9 TechnologyPerspective
        end
        subgraph 10["Use Cases Layer"]
          11([MyCompany.ECommerce.Payments.ProcessModel])
          class 11 TechnologyPerspective
          12([MyCompany.ECommerce.ProductsDelivery.ProcessModel])
          class 12 TechnologyPerspective
          13([MyCompany.ECommerce.RiskManagement.ProcessModel])
          class 13 TechnologyPerspective
          14([MyCompany.ECommerce.Sales.ProcessModel])
          class 14 TechnologyPerspective
        end
        subgraph 15["Undefined Layer"]
          16([MyCompany.ECommerce.Contacts])
          class 16 TechnologyPerspective
        end
      end
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Infrastructure

```mermaid
  flowchart TB
    0(ecommerce-monolith)
    class 0 TechnologyPerspective
    subgraph 1["Postgres"]
      2([Contacts])
      class 2 TechnologyPerspective
      3([Main])
      class 3 TechnologyPerspective
    end
    0-->|uses|1
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


### Zoom-in


#### Domain perspective


##### Domain Modules

[Contacts](../../Domain/Concepts/Contacts/Contacts.md)  
[Payments](../../Domain/Concepts/Payments/Payments.md)  
[Products delivery](../../Domain/Concepts/ProductsDelivery/ProductsDelivery.md)  
[Risk management](../../Domain/Concepts/RiskManagement/RiskManagement.md)  
[Sales](../../Domain/Concepts/Sales/Sales.md)  

#### People perspective


##### Development Teams

[Core team](../../People/DevelopmentTeams/CoreTeam.md)  
[Inventory team](../../People/DevelopmentTeams/InventoryTeam.md)  
[Supporting team](../../People/DevelopmentTeams/SupportingTeam.md)  

### Zoom-out


#### Technology perspective

[Deployable Units](DeployableUnits.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)