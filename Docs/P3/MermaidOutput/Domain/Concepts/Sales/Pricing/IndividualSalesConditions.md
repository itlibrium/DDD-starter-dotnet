
# Individual Sales Conditions

***Ddd Domain Service***  

This view contains details information about Individual Sales Conditions building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1(Individual Sales Conditions)
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Discounts"]
      3([Client Level Discounts])
      class 3 DomainPerspective
      4([Product Level Discounts])
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Pricing"]
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

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Client Level Discounts](Discounts/ClientLevelDiscounts.md)  
[Product Level Discounts](Discounts/ProductLevelDiscounts.md)  

##### Ddd Value Objects

[Offer](Offer.md)  
[Quote](Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)