
# Order Id

***Ddd Value Object***  

This view contains details information about Order Id building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Wholesale Ordering / Order Modification"]
      1([AddToOrder])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Wholesale Ordering / Order Placement"]
      3([PlaceOrder])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Wholesale Ordering / Order Pricing"]
      5([ConfirmOffer])
      class 5 DomainPerspective
      6([GetOffer])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Orders"]
      8([Order])
      class 8 DomainPerspective
      9([Order Factory])
      class 9 DomainPerspective
      10([Order Repository])
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Orders"]
      12(Order Id)
      class 12 DomainPerspective
    end
    0-->|depends on|11
    2-->|depends on|11
    4-->|depends on|11
    7-->|depends on|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Order Id)
    class 0 DomainPerspective
    1([AddToOrder])
    class 1 DomainPerspective
    0-->|is used in|1
    2([ConfirmOffer])
    class 2 DomainPerspective
    0-->|is used in|2
    3([GetOffer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([PlaceOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Process Steps

[AddToOrder](../WholesaleOrdering/OrderModification/AddToOrder.md)  
[ConfirmOffer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[GetOffer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[PlaceOrder](../WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)