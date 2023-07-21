
# Offer

This view contains details information about Offer building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(Offer)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
      4([Percentage])
      class 4 DomainPerspective
    end
    subgraph 5["PriceLists"]
      6([Base Prices])
      class 6 DomainPerspective
    end
    subgraph 7["Pricing"]
      8([Offer Modifier])
      class 8 DomainPerspective
      9([Quote])
      class 9 DomainPerspective
      10([Quote Modifier])
      class 10 DomainPerspective
    end
    subgraph 11["Products"]
      12([Product Amount])
      class 12 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    0-->|depends on|7
    0-->|depends on|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Offer)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([GetOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([PlaceOrder])
    class 3 DomainPerspective
    0-->|is used in|3
    4([PriceCart])
    class 4 DomainPerspective
    0-->|is used in|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Offer Modifier](Offer Modifier.md)  
[Quote Modifier](Quote Modifier.md)  

##### Ddd value objects

[Base Prices](PriceLists/Base Prices.md)  
[Money](../Commons/Money.md)  
[Percentage](../Commons/Percentage.md)  
[Product Amount](../Products/Product Amount.md)  
[Quote](Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)