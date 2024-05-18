
# Order

***Ddd Aggregate***  

This view contains details information about Order building block, including:
- dependencies
- modules
- related processes  

---



## User defined description

*An order is a request for products.* It is placed by a customer and contains a list of products with their amounts. The order is placed when the customer confirms the prices of the products.  

## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.OnlineOrdering.OrderPlacement"]
      1([Place Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Orders"]
      3([Order Factory])
      class 3 DomainPerspective
      4([Order Repository])
      class 4 DomainPerspective
    end
    subgraph 5["Sales.WholesaleOrdering.OrderCreation"]
      6([Create Order])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.WholesaleOrdering.OrderModification"]
      8([Add to Order])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.WholesaleOrdering.OrderPlacement"]
      10([Place Order])
      class 10 DomainPerspective
    end
    subgraph 11["Sales.WholesaleOrdering.OrderPricing"]
      12([Confirm Offer])
      class 12 DomainPerspective
    end
    subgraph 13["Sales.Orders"]
      14(Order)
      class 14 DomainPerspective
    end
    subgraph 15["Sales.Commons"]
      16([Money])
      class 16 DomainPerspective
    end
    subgraph 17["Sales.Orders"]
      18([Order Id])
      class 18 DomainPerspective
      19([Order Price Agreement])
      class 19 DomainPerspective
      20([Price Agreement Type])
      class 20 DomainPerspective
    end
    subgraph 21["Sales.Orders.PriceChanges"]
      22([Price Changes Policy])
      class 22 DomainPerspective
    end
    subgraph 23["Sales.Pricing"]
      24([Offer])
      class 24 DomainPerspective
      25([Quote])
      class 25 DomainPerspective
    end
    subgraph 26["Sales.Products"]
      27([Product Amount])
      class 27 DomainPerspective
      28([Product Unit])
      class 28 DomainPerspective
    end
    0-->|depends on|13
    2-->|depends on|13
    5-->|depends on|13
    7-->|depends on|13
    9-->|depends on|13
    11-->|depends on|13
    13-->|depends on|15
    13-->|depends on|17
    13-->|depends on|21
    13-->|depends on|23
    13-->|depends on|26
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Order)
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


##### Ddd Domain Services

[Price Changes Policy](PriceChanges/PriceChangesPolicy.md)  

##### Ddd Value Objects

[Money](../Commons/Money.md)  
[Offer](../Pricing/Offer.md)  
[Order Id](OrderId.md)  
[Order Price Agreement](OrderPriceAgreement.md)  
[Price Agreement Type](PriceAgreementType.md)  
[Product Amount](../Products/ProductAmount.md)  
[Product Unit](../Products/ProductUnit.md)  
[Quote](../Pricing/Quote.md)  

##### Use Cases

[Add to Order](../WholesaleOrdering/OrderModification/AddToOrder.md)  
[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Place Order](../WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)