
# Offer Modifier

***Ddd Domain Service***  

This view contains details information about Offer Modifier building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing"]
      1([Aggregated Modifier])
      class 1 DomainPerspective
      2([Calculate Prices])
      class 2 DomainPerspective
      3([Offer])
      class 3 DomainPerspective
      4([Offer Modifiers])
      class 4 DomainPerspective
    end
    subgraph 5["Sales.Pricing.SpecialOffers"]
      6([Every Second Box for Half Price])
      class 6 DomainPerspective
      7([Special Offer])
      class 7 DomainPerspective
      8([Three for Two])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing"]
      10(Offer Modifier)
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Pricing"]
      12([Offer])
      class 12 DomainPerspective
    end
    0-->|depends on|9
    5-->|depends on|9
    9-->|depends on|11
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

[Offer](Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)