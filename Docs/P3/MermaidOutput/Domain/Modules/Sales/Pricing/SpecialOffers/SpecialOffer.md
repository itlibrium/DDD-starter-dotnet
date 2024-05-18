
# Special Offer

***Ddd Domain Service***  

This view contains details information about Special Offer building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing.SpecialOffers"]
      1([Every Second Box for Half Price])
      class 1 DomainPerspective
      2([Three for Two])
      class 2 DomainPerspective
    end
    subgraph 3["Sales.Pricing.SpecialOffers"]
      4(Special Offer)
      class 4 DomainPerspective
    end
    subgraph 5["Sales.Pricing"]
      6([Offer])
      class 6 DomainPerspective
      7([Offer Modifier])
      class 7 DomainPerspective
    end
    0-->|depends on|3
    3-->|depends on|5
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


##### Ddd Domain Services

[Offer Modifier](../OfferModifier.md)  

##### Ddd Value Objects

[Offer](../Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Special offers](SpecialOffers-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)