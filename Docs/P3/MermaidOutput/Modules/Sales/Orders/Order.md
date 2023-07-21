
# Order

This view contains details information about Order building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Orders"]
      1(Order)
      class 1 DomainPerspective
    end
    subgraph 2["Orders"]
      3([Order Id])
      class 3 DomainPerspective
    end
    subgraph 4["PriceChanges"]
      5([Price Changes Policy])
      class 5 DomainPerspective
    end
    subgraph 6["Pricing"]
      7([Offer])
      class 7 DomainPerspective
      8([Quote])
      class 8 DomainPerspective
    end
    subgraph 9["Products"]
      10([Product Amount])
      class 10 DomainPerspective
      11([Product Unit])
      class 11 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    0-->|depends on|6
    0-->|depends on|9
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Order)
    class 0 DomainPerspective
    1([AddToOrder])
    class 1 DomainPerspective
    0-->|is used in|1
    2([ConfirmOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([CreateOrder])
    class 3 DomainPerspective
    0-->|is used in|3
    4([GetOffer])
    class 4 DomainPerspective
    0-->|is used in|4
    5([PlaceOrder])
    class 5 DomainPerspective
    0-->|is used in|5
    6([PlaceOrder])
    class 6 DomainPerspective
    0-->|is used in|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Price Changes Policy](PriceChanges/Price Changes Policy.md)  

##### Ddd value objects

[Offer](../Pricing/Offer.md)  
[Order Id](Order Id.md)  
[Product Amount](../Products/Product Amount.md)  
[Product Unit](../Products/Product Unit.md)  
[Quote](../Pricing/Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)