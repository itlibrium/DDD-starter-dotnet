﻿
# Domain Module Owners

This view shows how top level domain modules are assigned to development teams and business organizational units.  

---



## Development Teams and top level Domain Modules they maintain

```mermaid
  flowchart TB
    subgraph 0["Supporting team"]
      1(Payments)
      class 1 DomainPerspective
      2(Search)
      class 2 DomainPerspective
    end
    subgraph 3["Inventory team"]
      4(Products Delivery)
      class 4 DomainPerspective
    end
    subgraph 5["Core team"]
      6(Sales)
      class 6 DomainPerspective
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Business Organizational Units and top level Domain Modules they own

```mermaid
  flowchart TB
    subgraph 0["Sales department"]
      1(Payments)
      class 1 DomainPerspective
      2(Sales)
      class 2 DomainPerspective
      3(Search)
      class 3 DomainPerspective
    end
    subgraph 4["Inventory department"]
      5(Products Delivery)
      class 5 DomainPerspective
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Business Organizational Units and related Development Teams

```mermaid
  flowchart TB
    subgraph 0["Sales department"]
      1(Supporting team)
      class 1 PeoplePerspective
      2(Core team)
      class 2 PeoplePerspective
    end
    subgraph 3["Inventory department"]
      4(Inventory team)
      class 4 PeoplePerspective
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next use cases


### Zoom-in


#### Domain perspective


##### Domain Modules

[Contacts](Contacts/Contacts-module.md)  
[Payments](Payments/Payments-module.md)  
[Products delivery](ProductsDelivery/ProductsDelivery-module.md)  
[Risk management](RiskManagement/RiskManagement-module.md)  
[Sales](Sales/Sales-module.md)  
[Search](Search/Search-module.md)  

#### People perspective


##### Business Organizational Units

[Inventory department](../../People/BusinessOrganizationalUnits/InventoryDepartment.md)  
[Sales department](../../People/BusinessOrganizationalUnits/SalesDepartment.md)  

##### Development Teams

[Core team](../../People/DevelopmentTeams/CoreTeam.md)  
[Inventory team](../../People/DevelopmentTeams/InventoryTeam.md)  
[Supporting team](../../People/DevelopmentTeams/SupportingTeam.md)  

### Zoom-out


#### Multi perspectives

[Main page](../../README.md)  

#### Domain perspective

[Domain Modules](Modules.md)  

#### People perspective

[Business Organizational Units](../../People/BusinessOrganizationalUnits/BusinessOrganizationalUnits.md)  
[Development Teams](../../People/DevelopmentTeams/DevelopmentTeams.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)