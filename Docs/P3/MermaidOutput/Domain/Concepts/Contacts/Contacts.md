
# Contacts

***Domain Module***  

This view contains details information about Contacts domain module, including:
- other related modules
- related processes
- related building blocks
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related modules

```mermaid
  flowchart TB
    0(Contacts)
    class 0 DomainPerspective
    1([Companies])
    class 1 DomainPerspective
    0-->|contains|1
    2([Database])
    class 2 DomainPerspective
    0-->|contains|2
    3([Groups])
    class 3 DomainPerspective
    0-->|contains|3
    4([Tags])
    class 4 DomainPerspective
    0-->|contains|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

No related processes were found.  

### Direct building blocks

No direct building blocks were found.  

## Technology Perspective


### Related deployable units

No related deployable units were found.  

## People Perspective


### Engaged people

No engaged people were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Domain Modules

[Companies](Companies/Companies.md)  
[Database](Database/Database.md)  
[Groups](Groups/Groups.md)  
[Tags](Tags/Tags.md)  

### Zoom-out


#### Domain perspective

[Domain Modules](../DomainModules.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)