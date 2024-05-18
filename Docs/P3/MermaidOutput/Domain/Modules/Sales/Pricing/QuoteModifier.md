
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
    subgraph 0["Sales.Pricing"]
      1([Individual Sales Conditions])
      class 1 DomainPerspective
      2([Offer])
      class 2 DomainPerspective
      3([Quote])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Pricing.Discounts"]
      5([Client Level Discounts])
      class 5 DomainPerspective
      6([Product Level Discounts])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.Pricing"]
      8(Quote Modifier)
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing"]
      10([Quote])
      class 10 DomainPerspective
    end
    0-->|depends on|7
    4-->|depends on|7
    7-->|depends on|9
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

No related processes were found.  

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Quote](Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)