
# Sales department

***Business Organizational Unit***  

This view contains details information about Sales department, including:
- related domain modules  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    0(Sales department)
    class 0 PeoplePerspective
    1([Payments])
    class 1 DomainPerspective
    0-->|owns|1
    2([Sales])
    class 2 DomainPerspective
    0-->|owns|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Domain Modules

[Payments](../../Domain/Concepts/Payments/Payments.md)  
[Sales](../../Domain/Concepts/Sales/Sales.md)  

### Zoom-out


#### Domain perspective

[Domain Module Owners](../../Domain/Concepts/DomainModuleOwners.md)  

#### People perspective

[Business Organizational Units](BusinessOrganizationalUnits.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)