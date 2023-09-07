
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
    subgraph 0["Sales / Pricing / Special Offers"]
      1(Special Offer)
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing"]
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

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Offer Modifier](../OfferModifier.md)  

##### Ddd Value Objects

[Offer](../Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Special offers](SpecialOffers.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)