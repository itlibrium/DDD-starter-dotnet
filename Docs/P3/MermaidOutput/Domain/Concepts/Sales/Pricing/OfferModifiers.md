
# Offer Modifiers

***Ddd Factory***  

This view contains details information about Offer Modifiers building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1([Calculate Prices])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing"]
      3(Offer Modifiers)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing"]
      5([Offer Request])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Pricing / Discounts"]
      7([Discounts Repository])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Repositories

[Discounts Repository](Discounts/DiscountsRepository.md)  

##### Ddd Value Objects

[Offer Request](OfferRequest.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)