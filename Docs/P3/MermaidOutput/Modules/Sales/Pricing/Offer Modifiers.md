
# Offer Modifiers

This view contains details information about Offer Modifiers building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(Offer Modifiers)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([Discounts Repository])
      class 3 DomainPerspective
    end
    subgraph 4["Pricing"]
      5([Offer Request])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Offer Modifiers is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd repositories

[Discounts Repository](Discounts/Discounts Repository.md)  

##### Ddd value objects

[Offer Request](Offer Request.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)