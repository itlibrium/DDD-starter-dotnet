
# Every Second Box for Half Price

***Ddd Domain Service***  

This view contains details information about Every Second Box for Half Price building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing"]
      1([Offer Modifiers])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing.SpecialOffers"]
      3(Every Second Box for Half Price)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Pricing"]
      5([Offer])
      class 5 DomainPerspective
      6([Offer Modifier])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.Pricing.SpecialOffers"]
      8([Special Offer])
      class 8 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|7
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
[Special Offer](SpecialOffer.md)  

##### Ddd Value Objects

[Offer](../Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Special offers](SpecialOffers-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)