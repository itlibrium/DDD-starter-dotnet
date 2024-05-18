
# Sales Channel

***Ddd Value Object***  

This view contains details information about Sales Channel building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.OnlineOrdering.CartPricing"]
      1([Price Cart])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.OnlineOrdering.OrderPlacement"]
      3([Place Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Pricing"]
      5([Calculate Prices])
      class 5 DomainPerspective
      6([Offer Request])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.WholesaleOrdering.OrderPricing"]
      8([Confirm Offer])
      class 8 DomainPerspective
      9([Get Offer])
      class 9 DomainPerspective
    end
    subgraph 10["Sales.WholesaleOrdering.ProductPricing"]
      11([Create Order])
      class 11 DomainPerspective
    end
    subgraph 12["Sales.SalesChannels"]
      13(Sales Channel)
      class 13 DomainPerspective
    end
    0-->|depends on|12
    2-->|depends on|12
    4-->|depends on|12
    7-->|depends on|12
    10-->|depends on|12
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Sales Channel)
    class 0 DomainPerspective
    1([Price Cart])
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
    5([Create Order])
    class 5 DomainPerspective
    0-->|is used in|5
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


##### Use Cases

[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Sales channels](SalesChannels-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)