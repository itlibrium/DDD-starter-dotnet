
# Company

***Ddd Entity***  

This view contains details information about Company building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Contacts.Companies"]
      1([Address])
      class 1 DomainPerspective
      2([Company Group])
      class 2 DomainPerspective
      3([Company Tag])
      class 3 DomainPerspective
    end
    subgraph 4["Contacts.Companies"]
      5(Company)
      class 5 DomainPerspective
    end
    subgraph 6["Contacts.Companies"]
      7([Address])
      class 7 DomainPerspective
      8([Company Group])
      class 8 DomainPerspective
      9([Company Tag])
      class 9 DomainPerspective
      10([Phone])
      class 10 DomainPerspective
    end
    0-->|depends on|4
    4-->|depends on|6
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

[Address](Address.md)  
[Company Group](CompanyGroup.md)  
[Company Tag](CompanyTag.md)  
[Phone](Phone.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Contacts | Companies](Companies-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)