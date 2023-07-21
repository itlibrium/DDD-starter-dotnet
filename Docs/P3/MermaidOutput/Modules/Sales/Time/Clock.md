
# Clock

This view contains details information about Clock building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

Clock has no dependencies.  

### Related process steps

```mermaid
  flowchart TB
    0(Clock)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([PlaceOrder])
    class 2 DomainPerspective
    0-->|is used in|2
    3([PlaceOrder])
    class 3 DomainPerspective
    0-->|is used in|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out


#### Domain perspective


##### Domain modules

[Time](Time.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)