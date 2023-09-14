
# Domain Module Owners

This view shows how first level domain modules are assigned to development teams and business organizational units.  

---



## Development Teams and Domain Modules they maintain

```mermaid
  flowchart TB
    subgraph 0["Supporting team"]
      1(Payments)
      class 1 DomainPerspective
    end
    subgraph 2["Inventory team"]
      3(Products Delivery)
      class 3 DomainPerspective
    end
    subgraph 4["Core team"]
      5(Sales)
      class 5 DomainPerspective
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Business Organizational Units and Domain Modules they own

```mermaid
  flowchart TB
    subgraph 0["Sales department"]
      1(Payments)
      class 1 DomainPerspective
      2(Sales)
      class 2 DomainPerspective
    end
    subgraph 3["Inventory department"]
      4(Products Delivery)
      class 4 DomainPerspective
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

## Next steps


### Zoom-in


#### Domain perspective


##### Domain Modules

[Contacts](Contacts/Contacts.md)  
[Payments](Payments/Payments.md)  
[Products delivery](ProductsDelivery/ProductsDelivery.md)  
[Risk management](RiskManagement/RiskManagement.md)  
[Sales](Sales/Sales.md)  

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

[Domain Modules](DomainModules.md)  

#### People perspective

[Business Organizational Units](../../People/BusinessOrganizationalUnits/BusinessOrganizationalUnits.md)  
[Development Teams](../../People/DevelopmentTeams/DevelopmentTeams.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)