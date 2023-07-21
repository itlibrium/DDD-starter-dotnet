
# Calculate Prices

This view contains details information about Calculate Prices building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(Calculate Prices)
      class 1 DomainPerspective
    end
    subgraph 2["Clients"]
      3([Client Id])
      class 3 DomainPerspective
    end
    subgraph 4["PriceLists"]
      5([Price List Repository])
      class 5 DomainPerspective
    end
    subgraph 6["Pricing"]
      7([Offer Modifiers])
      class 7 DomainPerspective
      8([Offer Request])
      class 8 DomainPerspective
    end
    subgraph 9["Products"]
      10([Product Amount])
      class 10 DomainPerspective
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
    0(Calculate Prices)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([CreateOrder])
    class 2 DomainPerspective
    0-->|is used in|2
    3([GetOffer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([PlaceOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    5([PriceCart])
    class 5 DomainPerspective
    0-->|is used in|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd factories

[Offer Modifiers](Offer Modifiers.md)  

##### Ddd repositories

[Price List Repository](PriceLists/Price List Repository.md)  

##### Ddd value objects

[Client Id](../Clients/Client Id.md)  
[Offer Request](Offer Request.md)  
[Product Amount](../Products/Product Amount.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)