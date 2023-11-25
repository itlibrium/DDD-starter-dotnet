
# P3 Model documentation for MyCompany e-commerce


---



## System Landscape

```mermaid
  flowchart TB
    0(MyCompany e-commerce system)
    subgraph 1["Actors"]
    end
    1-->|uses|0
    subgraph 2["External Systems"]
    end
    2<-->|are integrated with|0
    subgraph 3["Development Teams"]
      4([Core team])
      5([Inventory team])
      6([Supporting team])
    end
    0---3
    3-->|develops & maintains|0
    3---0
    subgraph 7["Business Units"]
      8([Inventory department])
      9([Sales department])
    end
    0---7
    7-->|owns|0
    7---0
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
[Domain Module Owners](Domain/Concepts/DomainModuleOwners.md)  
[Domain Modules](Domain/Concepts/DomainModules.md)  

#### Technology perspective

[Deployable Units](Technology/DeployableUnits/DeployableUnits.md)  

#### People perspective

[Business Organizational Units](People/BusinessOrganizationalUnits/BusinessOrganizationalUnits.md)  
[Development Teams](People/DevelopmentTeams/DevelopmentTeams.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)