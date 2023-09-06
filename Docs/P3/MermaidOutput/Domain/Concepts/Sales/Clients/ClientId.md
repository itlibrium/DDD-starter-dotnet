
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
    subgraph 0["Sales / Clients"]
      1([Client Repository])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Online Ordering / Cart Pricing"]
      3([Price Cart])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Online Ordering / Order Placement"]
      5([Place Order])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Orders"]
      7([Order Factory])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Orders / Price Changes"]
      9([Price Changes Policies])
      class 9 DomainPerspective
    end
    subgraph 10["Sales / Pricing"]
      11([Calculate Prices])
      class 11 DomainPerspective
      12([Offer Request])
      class 12 DomainPerspective
    end
    subgraph 13["Sales / Pricing / Discounts"]
      14([Discounts Repository])
      class 14 DomainPerspective
    end
    subgraph 15["Sales / Pricing / Price Lists"]
      16([Price List Repository])
      class 16 DomainPerspective
    end
    subgraph 17["Sales / Wholesale Ordering / Order Creation"]
      18([Create Order])
      class 18 DomainPerspective
    end
    subgraph 19["Sales / Wholesale Ordering / Order Pricing"]
      20([Confirm Offer])
      class 20 DomainPerspective
      21([Get Offer])
      class 21 DomainPerspective
    end
    subgraph 22["Sales / Wholesale Ordering / Product Pricing"]
      23([Create Order])
      class 23 DomainPerspective
    end
    subgraph 24["Sales / Clients"]
      25(Client Id)
      class 25 DomainPerspective
    end
    0-->|depends on|24
    2-->|depends on|24
    4-->|depends on|24
    6-->|depends on|24
    8-->|depends on|24
    10-->|depends on|24
    13-->|depends on|24
    15-->|depends on|24
    17-->|depends on|24
    19-->|depends on|24
    22-->|depends on|24
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

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

## Next steps


### Zoom-in


#### Domain perspective


##### Process Steps

[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Create Order](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[Create Order](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Get Offer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Price Cart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Clients](Clients.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)