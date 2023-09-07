
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
    1([Payments])
    class 1 DomainPerspective
    1-->|is deployed in|0
    2([Products Delivery])
    class 2 DomainPerspective
    2-->|is deployed in|0
    3([Sales])
    class 3 DomainPerspective
    3-->|is deployed in|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective

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
          6([MyCompany.ECommerce.Sales.DeepModel])
          class 6 TechnologyPerspective
        end
        subgraph 7["Undefined Layer"]
          8([MyCompany.ECommerce.Contacts])
          class 8 TechnologyPerspective
          9([MyCompany.ECommerce.TechnicalStuff])
          class 9 TechnologyPerspective
          10([MyCompany.ECommerce.TechnicalStuff.Api])
          class 10 TechnologyPerspective
          11([MyCompany.ECommerce.TechnicalStuff.Crud])
          class 11 TechnologyPerspective
          12([MyCompany.ECommerce.TechnicalStuff.Crud.Api])
          class 12 TechnologyPerspective
          13([MyCompany.ECommerce.TechnicalStuff.Crud.Ef])
          class 13 TechnologyPerspective
          14([MyCompany.ECommerce.TechnicalStuff.Ef])
          class 14 TechnologyPerspective
          15([MyCompany.ECommerce.TechnicalStuff.Json])
          class 15 TechnologyPerspective
          16([MyCompany.ECommerce.TechnicalStuff.Kafka])
          class 16 TechnologyPerspective
          17([MyCompany.ECommerce.TechnicalStuff.Marten])
          class 17 TechnologyPerspective
          18([MyCompany.ECommerce.TechnicalStuff.Metadata])
          class 18 TechnologyPerspective
          19([MyCompany.ECommerce.TechnicalStuff.Outbox])
          class 19 TechnologyPerspective
          20([MyCompany.ECommerce.TechnicalStuff.Outbox.Kafka])
          class 20 TechnologyPerspective
          21([MyCompany.ECommerce.TechnicalStuff.Outbox.Postgres])
          class 21 TechnologyPerspective
          22([MyCompany.ECommerce.TechnicalStuff.Outbox.Quartz])
          class 22 TechnologyPerspective
          23([MyCompany.ECommerce.TechnicalStuff.Persistence])
          class 23 TechnologyPerspective
          24([MyCompany.ECommerce.TechnicalStuff.Persistence.RepoDb])
          class 24 TechnologyPerspective
          25([MyCompany.ECommerce.TechnicalStuff.Postgres])
          class 25 TechnologyPerspective
          26([MyCompany.ECommerce.TechnicalStuff.ProcessModel])
          class 26 TechnologyPerspective
          27([MyCompany.ECommerce.TechnicalStuff.Transactions])
          class 27 TechnologyPerspective
        end
        subgraph 28["Use Cases Layer"]
          29([MyCompany.ECommerce.Payments.ProcessModel])
          class 29 TechnologyPerspective
          30([MyCompany.ECommerce.ProductsDelivery.ProcessModel])
          class 30 TechnologyPerspective
          31([MyCompany.ECommerce.RiskManagement.ProcessModel])
          class 31 TechnologyPerspective
          32([MyCompany.ECommerce.Sales.ProcessModel])
          class 32 TechnologyPerspective
        end
      end
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


### Zoom-in


#### Domain perspective


##### Domain Modules

[Payments](../../Domain/Concepts/Payments/Payments.md)  
[Products delivery](../../Domain/Concepts/ProductsDelivery/ProductsDelivery.md)  
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