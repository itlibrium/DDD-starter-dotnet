
# Special Offer

This view contains details information about Special Offer building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["SpecialOffers"]
      1(Special Offer)
      class 1 DomainPerspective
    end
    subgraph 2["Pricing"]
      3([Offer])
      class 3 DomainPerspective
      4([Offer Modifier])
      class 4 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Special Offer is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Offer Modifier](../Offer Modifier.md)  

##### Ddd value objects

[Offer](../Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[SpecialOffers](SpecialOffers.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)