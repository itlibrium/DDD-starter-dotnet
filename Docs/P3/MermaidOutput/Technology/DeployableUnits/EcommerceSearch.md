
# ecommerce-search

***Deployable Unit***  

This view contains details information about ecommerce-search deployable unit, including:
- related domain modules
- related development teams  

---



## Domain Perspective


### Related domain modules

```mermaid
  flowchart TB
    0(ecommerce-search)
    class 0 TechnologyPerspective
    1([Search])
    class 1 DomainPerspective
    1-->|is deployed in|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Tier, CSharp Projects and their Layers

```mermaid
  flowchart TB
    subgraph 0["Application Tier"]
      subgraph 1["ecommerce-search"]
        subgraph 2["Api Layer"]
          3([MyCompany.ECommerce.Search.Api])
          class 3 TechnologyPerspective
        end
        subgraph 4["Infrastructure Layer"]
          5([MyCompany.ECommerce.Search.Infrastructure])
          class 5 TechnologyPerspective
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
    0(ecommerce-search)
    class 0 TechnologyPerspective
    subgraph 1["Elastic"]
      2([Search])
      class 2 TechnologyPerspective
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
    0(ecommerce-search)
    class 0 TechnologyPerspective
    1([Supporting team])
    class 1 PeoplePerspective
    1-->|maintains|0
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next use cases


### Zoom-in


#### Domain perspective


##### Domain Modules

[Search](../../Domain/Modules/Search/Search-module.md)  

#### People perspective


##### Development Teams

[Supporting team](../../People/DevelopmentTeams/SupportingTeam.md)  

### Zoom-out


#### Technology perspective

[Deployable Units](DeployableUnits.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)