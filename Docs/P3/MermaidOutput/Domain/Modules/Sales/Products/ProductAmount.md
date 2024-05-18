
# Product Amount

***Ddd Value Object***  

This view contains details information about Product Amount building block, including:
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
    subgraph 4["Sales.Orders"]
      5([Order])
      class 5 DomainPerspective
      6([Order Factory])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.Pricing"]
      8([Calculate Prices])
      class 8 DomainPerspective
      9([Offer])
      class 9 DomainPerspective
      10([Offer Modifiers])
      class 10 DomainPerspective
      11([Offer Request])
      class 11 DomainPerspective
      12([Quote])
      class 12 DomainPerspective
    end
    subgraph 13["Sales.Pricing.Discounts"]
      14([Client Level Discounts])
      class 14 DomainPerspective
      15([Discounts Repository])
      class 15 DomainPerspective
      16([Product Level Discounts])
      class 16 DomainPerspective
    end
    subgraph 17["Sales.Pricing.PriceLists"]
      18([Base Prices])
      class 18 DomainPerspective
      19([Price List Repository])
      class 19 DomainPerspective
    end
    subgraph 20["Sales.WholesaleOrdering.OrderModification"]
      21([Add to Order])
      class 21 DomainPerspective
    end
    subgraph 22["Sales.WholesaleOrdering.OrderPricing"]
      23([Confirm Offer])
      class 23 DomainPerspective
      24([Get Offer])
      class 24 DomainPerspective
    end
    subgraph 25["Sales.WholesaleOrdering.ProductPricing"]
      26([Create Order])
      class 26 DomainPerspective
    end
    subgraph 27["Sales.Products"]
      28(Product Amount)
      class 28 DomainPerspective
    end
    subgraph 29["Sales.Products"]
      30([Amount])
      class 30 DomainPerspective
      31([Amount Unit])
      class 31 DomainPerspective
      32([Product Id])
      class 32 DomainPerspective
      33([Product Unit])
      class 33 DomainPerspective
    end
    0-->|depends on|27
    2-->|depends on|27
    4-->|depends on|27
    7-->|depends on|27
    13-->|depends on|27
    17-->|depends on|27
    20-->|depends on|27
    22-->|depends on|27
    25-->|depends on|27
    27-->|depends on|29
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Product Amount)
    class 0 DomainPerspective
    1([Price Cart])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Place Order])
    class 2 DomainPerspective
    0-->|is used in|2
    3([Add to Order])
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


##### Ddd Value Objects

[Amount](Amount.md)  
[Amount Unit](AmountUnit.md)  
[Product Id](ProductId.md)  
[Product Unit](ProductUnit.md)  

##### Use Cases

[Add to Order](../WholesaleOrdering/OrderModification/AddToOrder.md)  
[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Products](Products-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)