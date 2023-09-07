
# Offer Modifier 2

***Ddd Domain Service***  

This view contains details information about Offer Modifier 2 building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1(Offer Modifier 2)
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing"]
      3([Offer])
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Offer](Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)