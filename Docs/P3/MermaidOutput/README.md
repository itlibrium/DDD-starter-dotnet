
# P3 Model documentation for MyCompany e-commerce


---



## System Landscape

```mermaid
  flowchart TB
    0(MyCompany e-commerce system)
    subgraph 1["Actors"]
      2([Retail Client])
      3([Wholesale Client])
    end
    1-->|uses|0
    subgraph 4["External Systems"]
      5([Forex])
    end
    4<-->|are integrated with|0
    subgraph 6["Development Teams"]
      7([Core team])
      8([Inventory team])
      9([Supporting team])
    end
    0---6
    6-->|develops & maintains|0
    6---0
    subgraph 10["Business Units"]
      11([Inventory department])
      12([Sales department])
    end
    0---10
    10-->|owns|0
    10---0
    linkStyle 2,4,5,7 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective

[Business Processes](Domain/Processes/BusinessProcesses.md)  
[Domain Glossary](Domain/Glossary/Domain_Glossary.md)  
[Domain Modules](Domain/Concepts/DomainModules.md)  

#### Technology perspective

[Deployable Units](Technology/DeployableUnits/DeployableUnits.md)  

#### People perspective

[Business Organizational Units](People/BusinessOrganizationalUnits/BusinessOrganizationalUnits.md)  
[Development Teams](People/DevelopmentTeams/DevelopmentTeams.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)