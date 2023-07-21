
# Individual Sales Conditions

This view contains details information about Individual Sales Conditions building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(Individual Sales Conditions)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([Client Level Discounts])
      class 3 DomainPerspective
      4([Product Level Discounts])
      class 4 DomainPerspective
    end
    subgraph 5["Pricing"]
      6([Offer])
      class 6 DomainPerspective
      7([Quote])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Individual Sales Conditions is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Client Level Discounts](Discounts/Client Level Discounts.md)  
[Product Level Discounts](Discounts/Product Level Discounts.md)  

##### Ddd value objects

[Offer](Offer.md)  
[Quote](Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)