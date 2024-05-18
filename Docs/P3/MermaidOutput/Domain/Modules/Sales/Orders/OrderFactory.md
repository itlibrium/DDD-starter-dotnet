
# Order Factory

***Ddd Factory***  

This view contains details information about Order Factory building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.OnlineOrdering.OrderPlacement"]
      1([Place Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.WholesaleOrdering.OrderCreation"]
      3([Create Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Orders"]
      5(Order Factory)
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Clients"]
      7([Client Id])
      class 7 DomainPerspective
    end
    subgraph 8["Sales.Commons"]
      9([Money])
      class 9 DomainPerspective
    end
    subgraph 10["Sales.Orders"]
      11([Order])
      class 11 DomainPerspective
      12([Order Id])
      class 12 DomainPerspective
    end
    subgraph 13["Sales.Pricing"]
      14([Offer])
      class 14 DomainPerspective
    end
    subgraph 15["Sales.Products"]
      16([Product Amount])
      class 16 DomainPerspective
    end
    0-->|depends on|4
    2-->|depends on|4
    4-->|depends on|6
    4-->|depends on|8
    4-->|depends on|10
    4-->|depends on|13
    4-->|depends on|15
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Order Factory)
    class 0 DomainPerspective
    1([Place Order])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Create Order])
    class 2 DomainPerspective
    0-->|is used in|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Aggregates

[Order](Order.md)  

##### Ddd Value Objects

[Client Id](../Clients/ClientId.md)  
[Money](../Commons/Money.md)  
[Offer](../Pricing/Offer.md)  
[Order Id](OrderId.md)  
[Product Amount](../Products/ProductAmount.md)  

##### Use Cases

[Create Order](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)