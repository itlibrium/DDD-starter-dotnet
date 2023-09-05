
# Risk Management

***Process***  

This view contains details information about Risk Management business process, including:
- other related processes
- process steps
- related domain modules
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related processes and steps

```mermaid
  flowchart TB
    0(Risk Management)
    class 0 DomainPerspective
    1([Risk Score Calculation])
    class 1 DomainPerspective
    0-->|contains|1
    2([Risk Score Publication])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related domain modules

```mermaid
  flowchart TB
    0(Risk Management)
    class 0 DomainPerspective
    1([Publication])
    class 1 DomainPerspective
    0-->|belongs to|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

No related deployable units were found.  

## People Perspective


### Engaged people

No engaged people were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Processes

[Risk Score Calculation](Risk score calculation/RiskScoreCalculation.md)  
[Risk Score Publication](Risk score publication/RiskScorePublication.md)  

### Zoom-out


#### Domain perspective

[Business Processes](../BusinessProcesses.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)