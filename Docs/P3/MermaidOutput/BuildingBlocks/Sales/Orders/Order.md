
# [*Domain building block*] Order

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
    subgraph 2["PriceChanges"]
      3([PriceChangesPolicy])
      class 3 DomainPerspective
    end
    subgraph 4["Pricing"]
      5([Quote])
      class 5 DomainPerspective
      6([Offer])
      class 6 DomainPerspective
    end
    subgraph 7["Products"]
      8([ProductAmount])
      class 8 DomainPerspective
      9([ProductUnit])
      class 9 DomainPerspective
    end
    subgraph 10["Orders"]
      11([OrderId])
      class 11 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    0-->|depends on|7
    0-->|depends on|10
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Order)
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
    4([PlaceOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    5([CreateOrder])
    class 5 DomainPerspective
    0-->|is used in|5
    6([AddToOrder])
    class 6 DomainPerspective
    0-->|is used in|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [[*Domain module*] Orders](../../../Modules/Sales/Orders/Orders.md)

### Change perspective

- [[*Domain building block*] ProductUnit](../Products/ProductUnit.md)
- [[*Domain building block*] Quote](../Pricing/Quote.md)
- [[*Domain building block*] OrderId](OrderId.md)
- [[*Domain building block*] Offer](../Pricing/Offer.md)
- [[*Domain building block*] ProductAmount](../Products/ProductAmount.md)
- [[*Domain building block*] PriceChangesPolicy](PriceChanges/PriceChangesPolicy.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)