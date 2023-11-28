
# Order Repository

***Ddd Repository***  

This view contains details information about Order Repository building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Online Ordering / Order Placement"]
      1([Place Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Wholesale Ordering / Order Creation"]
      3([Create Order])
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
      12(Order Repository)
      class 12 DomainPerspective
    end
    subgraph 13["Sales / Orders"]
      14([Order])
      class 14 DomainPerspective
      15([Order Id])
      class 15 DomainPerspective
    end
    0-->|depends on|11
    2-->|depends on|11
    4-->|depends on|11
    6-->|depends on|11
    8-->|depends on|11
    11-->|depends on|13
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Order Repository)
    class 0 DomainPerspective
    1([Place Order])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Create Order])
    class 2 DomainPerspective
    0-->|is used in|2
    3([Add to Order])
    class 3 DomainPerspective
    0-->|is used in|3
    4([Place Order])
    class 4 DomainPerspective
    0-->|is used in|4
    5([Confirm Offer])
    class 5 DomainPerspective
    0-->|is used in|5
    6([Get Offer])
    class 6 DomainPerspective
    0-->|is used in|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Source code

[Order.Repository.cs](../../../../../../../Sources/Sales/Sales.DeepModel/Orders/Order.Repository.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Aggregates

[Order](Order.md)  

##### Ddd Value Objects

[Order Id](OrderId.md)  

##### Process Steps

[Add to Order](../WholesaleOrdering/OrderModification/AddToOrder.md)  
[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Place Order](../WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)