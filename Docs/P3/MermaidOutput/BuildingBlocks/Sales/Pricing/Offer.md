
# [*Domain building block*] Offer

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
      6([BasePrices])
      class 6 DomainPerspective
    end
    subgraph 7["Pricing"]
      8([OfferModifier])
      class 8 DomainPerspective
      9([Quote])
      class 9 DomainPerspective
      10([QuoteModifier])
      class 10 DomainPerspective
    end
    subgraph 11["Products"]
      12([ProductAmount])
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


### Zoom-out

- [[*Domain module*] Pricing](../../../Modules/Sales/Pricing/Pricing.md)

### Change perspective

- [[*Domain building block*] QuoteModifier](QuoteModifier.md)
- [[*Domain building block*] BasePrices](PriceLists/BasePrices.md)
- [[*Domain building block*] OfferModifier](OfferModifier.md)
- [[*Domain building block*] ProductAmount](../Products/ProductAmount.md)
- [[*Domain building block*] Money](../Commons/Money.md)
- [[*Domain building block*] Quote](Quote.md)
- [[*Domain building block*] Percentage](../Commons/Percentage.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)