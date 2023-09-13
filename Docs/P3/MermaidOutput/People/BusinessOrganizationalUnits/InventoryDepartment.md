
# Inventory department

***Business Organizational Unit***  

This view contains details information about Inventory department, including:
- related domain modules  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    0(Inventory department)
    class 0 PeoplePerspective
    1([Products Delivery])
    class 1 DomainPerspective
    0-->|owns|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Domain Modules

[Products delivery](../../Domain/Concepts/ProductsDelivery/ProductsDelivery.md)  

### Zoom-out


#### People perspective

[Business Organizational Units](BusinessOrganizationalUnits.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)