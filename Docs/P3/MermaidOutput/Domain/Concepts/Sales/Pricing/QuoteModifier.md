
# Quote Modifier

***Ddd Domain Service***  

This view contains details information about Quote Modifier building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1([Offer])
      class 1 DomainPerspective
      2([Quote])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Pricing"]
      4(Quote Modifier)
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Pricing"]
      6([Quote])
      class 6 DomainPerspective
    end
    0-->|depends on|3
    3-->|depends on|5
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

[Quote](Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)