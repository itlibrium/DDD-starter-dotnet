
# Supporting team

***Development Team***  

This view contains details information about Supporting team team, including:
- related domain modules
- related deployable units  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    0(Supporting team)
    class 0 PeoplePerspective
    1([Payments])
    class 1 DomainPerspective
    0-->|develops & maintains|1
    2([Search])
    class 2 DomainPerspective
    0-->|develops & maintains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Supporting team)
    class 0 PeoplePerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|maintains|1
    2([ecommerce-search])
    class 2 TechnologyPerspective
    0-->|maintains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next use cases


### Zoom-in


#### Domain perspective


##### Domain Modules

[Payments](../../Domain/Modules/Payments/Payments-module.md)  
[Search](../../Domain/Modules/Search/Search-module.md)  

#### Technology perspective


##### Deployable Units

[ecommerce-monolith](../../Technology/DeployableUnits/EcommerceMonolith.md)  
[ecommerce-search](../../Technology/DeployableUnits/EcommerceSearch.md)  

### Zoom-out


#### Domain perspective

[Domain Module Owners](../../Domain/Modules/ModuleOwners.md)  

#### People perspective

[Development Teams](DevelopmentTeams.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)