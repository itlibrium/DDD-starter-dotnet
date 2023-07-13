
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
    subgraph 2["Clients"]
      3([ClientId])
      class 3 DomainPerspective
    end
    subgraph 4["PriceLists"]
      5([PriceListRepository])
      class 5 DomainPerspective
    end
    subgraph 6["Pricing"]
      7([OfferModifiers])
      class 7 DomainPerspective
      8([OfferRequest])
      class 8 DomainPerspective
    end
    subgraph 9["Products"]
      10([ProductAmount])
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
    0(CalculatePrices)
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


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] OfferRequest](OfferRequest.md)
- [[*Domain building block*] ProductAmount](../Products/ProductAmount.md)
- [[*Domain building block*] PriceListRepository](PriceLists/PriceListRepository.md)
- [[*Domain building block*] OfferModifiers](OfferModifiers.md)
- [[*Domain building block*] ClientId](../Clients/ClientId.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)