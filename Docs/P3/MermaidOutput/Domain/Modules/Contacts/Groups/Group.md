
# Group

***Ddd Entity***  

This view contains details information about Group building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Contacts.Companies"]
      1([Company Group])
      class 1 DomainPerspective
    end
    subgraph 2["Contacts.Groups"]
      3([Group Tag])
      class 3 DomainPerspective
    end
    subgraph 4["Contacts.Groups"]
      5(Group)
      class 5 DomainPerspective
    end
    subgraph 6["Contacts.Companies"]
      7([Company Group])
      class 7 DomainPerspective
    end
    subgraph 8["Contacts.Groups"]
      9([Group Tag])
      class 9 DomainPerspective
    end
    0-->|depends on|4
    2-->|depends on|4
    4-->|depends on|6
    4-->|depends on|8
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


### Zoom-in


#### Domain perspective


##### Ddd Entities

[Company Group](../Companies/CompanyGroup.md)  
[Group Tag](GroupTag.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Contacts | Groups](Groups-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)