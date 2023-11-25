
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

No related deployable units were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Domain Modules

[Payments](../../Domain/Concepts/Payments/Payments.md)  
[Search](../../Domain/Concepts/Search/Search.md)  

### Zoom-out


#### Domain perspective

[Domain Module Owners](../../Domain/Concepts/DomainModuleOwners.md)  

#### People perspective

[Development Teams](DevelopmentTeams.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)