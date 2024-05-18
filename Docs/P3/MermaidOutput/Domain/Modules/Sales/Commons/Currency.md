
# Currency

***Ddd Value Object***  

This view contains details information about Currency building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Commons"]
      1([Money])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.ExchangeRates"]
      3([Exchange Rate])
      class 3 DomainPerspective
      4([Exchange Rate Provider])
      class 4 DomainPerspective
    end
    subgraph 5["Sales.OnlineOrdering.CartPricing"]
      6([Price Cart])
      class 6 DomainPerspective
    end
    subgraph 7["Sales.OnlineOrdering.OrderPlacement"]
      8([Place Order])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Pricing"]
      10([Calculate Prices])
      class 10 DomainPerspective
      11([Offer])
      class 11 DomainPerspective
    end
    subgraph 12["Sales.Pricing.Discounts"]
      13([Value Discount])
      class 13 DomainPerspective
    end
    subgraph 14["Sales.WholesaleOrdering.OrderPricing"]
      15([Confirm Offer])
      class 15 DomainPerspective
      16([Get Offer])
      class 16 DomainPerspective
    end
    subgraph 17["Sales.WholesaleOrdering.ProductPricing"]
      18([Create Order])
      class 18 DomainPerspective
    end
    subgraph 19["Sales.Commons"]
      20(Currency)
      class 20 DomainPerspective
    end
    0-->|depends on|19
    2-->|depends on|19
    5-->|depends on|19
    7-->|depends on|19
    9-->|depends on|19
    12-->|depends on|19
    14-->|depends on|19
    17-->|depends on|19
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Currency)
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

[Sales | Commons](Commons-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)