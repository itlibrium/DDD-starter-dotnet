
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
    subgraph 0["Sales / Orders"]
      1([Order])
      class 1 DomainPerspective
      2([Order Factory])
      class 2 DomainPerspective
      3([Order Repository])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Wholesale Ordering / Order Modification"]
      5([Add to Order])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Wholesale Ordering / Order Placement"]
      7([Place Order])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Wholesale Ordering / Order Pricing"]
      9([Confirm Offer])
      class 9 DomainPerspective
      10([Get Offer])
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Orders"]
      12(Order Id)
      class 12 DomainPerspective
    end
    0-->|depends on|11
    4-->|depends on|11
    6-->|depends on|11
    8-->|depends on|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Order Id)
    class 0 DomainPerspective
    1([Add to Order])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Place Order])
    class 2 DomainPerspective
    0-->|is used in|2
    3([Confirm Offer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([Get Offer])
    class 4 DomainPerspective
    0-->|is used in|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Source code

[OrderId.cs](../../../../../../../Sources/Sales/Sales.DeepModel/Orders/OrderId.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Process Steps

[Add to Order](../WholesaleOrdering/OrderModification/AddToOrder.md)  
[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)