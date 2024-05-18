
# Client Id

***Ddd Value Object***  

This view contains details information about Client Id building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Clients"]
      1([Client Repository])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.OnlineOrdering.CartPricing"]
      3([Price Cart])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.OnlineOrdering.OrderPlacement"]
      5([Place Order])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Orders"]
      7([Order Factory])
      class 7 DomainPerspective
    end
    subgraph 8["Sales.Orders.PriceChanges"]
      9([Price Changes Policies])
      class 9 DomainPerspective
    end
    subgraph 10["Sales.Pricing"]
      11([Calculate Prices])
      class 11 DomainPerspective
      12([Offer Modifiers])
      class 12 DomainPerspective
      13([Offer Request])
      class 13 DomainPerspective
    end
    subgraph 14["Sales.Pricing.Discounts"]
      15([Discounts Repository])
      class 15 DomainPerspective
    end
    subgraph 16["Sales.Pricing.PriceLists"]
      17([Price List Repository])
      class 17 DomainPerspective
    end
    subgraph 18["Sales.WholesaleOrdering.OrderCreation"]
      19([Create Order])
      class 19 DomainPerspective
    end
    subgraph 20["Sales.WholesaleOrdering.OrderPricing"]
      21([Confirm Offer])
      class 21 DomainPerspective
      22([Get Offer])
      class 22 DomainPerspective
    end
    subgraph 23["Sales.WholesaleOrdering.ProductPricing"]
      24([Create Order])
      class 24 DomainPerspective
    end
    subgraph 25["Sales.Clients"]
      26(Client Id)
      class 26 DomainPerspective
    end
    0-->|depends on|25
    2-->|depends on|25
    4-->|depends on|25
    6-->|depends on|25
    8-->|depends on|25
    10-->|depends on|25
    14-->|depends on|25
    16-->|depends on|25
    18-->|depends on|25
    20-->|depends on|25
    23-->|depends on|25
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Client Id)
    class 0 DomainPerspective
    1([Price Cart])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Place Order])
    class 2 DomainPerspective
    0-->|is used in|2
    3([Create Order])
    class 3 DomainPerspective
    0-->|is used in|3
    4([Confirm Offer])
    class 4 DomainPerspective
    0-->|is used in|4
    5([Get Offer])
    class 5 DomainPerspective
    0-->|is used in|5
    6([Create Order])
    class 6 DomainPerspective
    0-->|is used in|6
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
[Create Order](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Create Order](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Clients](Clients-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)