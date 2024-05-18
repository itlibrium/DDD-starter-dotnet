
# Phone

***Ddd Entity***  

This view contains details information about Phone building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Contacts.Companies"]
      1([Company])
      class 1 DomainPerspective
    end
    subgraph 2["Contacts.Companies"]
      3(Phone)
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

No related processes were found.  

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-out


#### Domain perspective


##### Domain Modules

[Contacts | Companies](Companies-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)