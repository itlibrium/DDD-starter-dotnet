
# [*Domain building block*] CalculatePrices

This view contains details information about CalculatePrices building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Pricing"]
      1(CalculatePrices)
      class 1 DomainPerspective
    end
    subgraph 2["Products"]
      3([ProductAmount])
      class 3 DomainPerspective
    end
    subgraph 4["Clients"]
      5([ClientId])
      class 5 DomainPerspective
    end
    subgraph 6["PriceLists"]
      7([PriceListRepository])
      class 7 DomainPerspective
    end
    subgraph 8["Pricing"]
      9([OfferModifiers])
      class 9 DomainPerspective
      10([OfferRequest])
      class 10 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    0-->|depends on|6
    0-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(CalculatePrices)
    class 0 DomainPerspective
    1([CreateOrder])
    class 1 DomainPerspective
    0-->|is used in|1
    2([PriceCart])
    class 2 DomainPerspective
    0-->|is used in|2
    3([ConfirmOffer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([GetOffer])
    class 4 DomainPerspective
    0-->|is used in|4
    5([PlaceOrder])
    class 5 DomainPerspective
    0-->|is used in|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] PriceListRepository](PriceLists/PriceListRepository.md)
- [[*Domain building block*] OfferModifiers](OfferModifiers.md)
- [[*Domain building block*] ClientId](../Clients/ClientId.md)
- [[*Domain building block*] OfferRequest](OfferRequest.md)
- [[*Domain building block*] ProductAmount](../Products/ProductAmount.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)