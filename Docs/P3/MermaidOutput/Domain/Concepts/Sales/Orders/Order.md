
# Order

***Ddd Aggregate***  

This view contains details information about Order building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Wholesale Ordering / Order Creation"]
      1([CreateOrder])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Wholesale Ordering / Order Modification"]
      3([AddToOrder])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Online Ordering / Order Placement"]
      5([PlaceOrder])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Wholesale Ordering / Order Placement"]
      7([PlaceOrder])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Wholesale Ordering / Order Pricing"]
      9([ConfirmOffer])
      class 9 DomainPerspective
      10([GetOffer])
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Orders"]
      12([Order Repository])
      class 12 DomainPerspective
    end
    subgraph 13["Sales / Orders"]
      14(Order)
      class 14 DomainPerspective
    end
    subgraph 15["Sales / Orders"]
      16([Order Id])
      class 16 DomainPerspective
      17([Price Agreement Type])
      class 17 DomainPerspective
    end
    subgraph 18["Sales / Orders / Price Changes"]
      19([Price Changes Policy])
      class 19 DomainPerspective
    end
    subgraph 20["Sales / Pricing"]
      21([Offer])
      class 21 DomainPerspective
      22([Quote])
      class 22 DomainPerspective
    end
    subgraph 23["Sales / Products"]
      24([Product Amount])
      class 24 DomainPerspective
      25([Product Unit])
      class 25 DomainPerspective
    end
    0-->|depends on|13
    2-->|depends on|13
    4-->|depends on|13
    6-->|depends on|13
    8-->|depends on|13
    11-->|depends on|13
    13-->|depends on|15
    13-->|depends on|18
    13-->|depends on|20
    13-->|depends on|23
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


##### Ddd Domain Services

[Price Changes Policy](PriceChanges/PriceChangesPolicy.md)  

##### Ddd Value Objects

[Offer](../Pricing/Offer.md)  
[Order Id](OrderId.md)  
[Price Agreement Type](PriceAgreementType.md)  
[Product Amount](../Products/ProductAmount.md)  
[Product Unit](../Products/ProductUnit.md)  
[Quote](../Pricing/Quote.md)  

##### Process Steps

[AddToOrder](../WholesaleOrdering/OrderModification/AddToOrder.md)  
[ConfirmOffer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[CreateOrder](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[GetOffer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[PlaceOrder](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[PlaceOrder](../WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)