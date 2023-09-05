
# RequestDelivery

***Process Step***  

This view contains details information about RequestDelivery business processes step, including:
- related process
- next process steps
- related domain module
- related deployable unit
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Process

```mermaid
  flowchart TB
    0(RequestDelivery)
    class 0 DomainPerspective
    1([Products Delivery])
    class 1 DomainPerspective
    0-->|is part of|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Used Building Blocks

No building blocks were found. Maybe this process step is not implemented yet?  

## Technology Perspective

No related deployable unit was found.  

## People Perspective

No engaged people were found.  

## Next steps


### Zoom-out


#### Domain perspective


##### Domain Modules

[Requesting](Requesting.md)  

##### Processes

[Products Delivery](../../../Processes/Sale/Products delivery/ProductsDelivery.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)