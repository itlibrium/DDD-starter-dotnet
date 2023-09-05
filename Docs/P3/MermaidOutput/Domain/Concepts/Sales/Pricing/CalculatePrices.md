
# Calculate Prices

***Ddd Domain Service***  

This view contains details information about Calculate Prices building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Online Ordering / Cart Pricing"]
      1([PriceCart])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Online Ordering / Order Placement"]
      3([PlaceOrder])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Wholesale Ordering / Order Pricing"]
      5([ConfirmOffer])
      class 5 DomainPerspective
      6([GetOffer])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Wholesale Ordering / Product Pricing"]
      8([CreateOrder])
      class 8 DomainPerspective
    end
    subgraph 9["Sales / Pricing"]
      10(Calculate Prices)
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Clients"]
      12([Client Id])
      class 12 DomainPerspective
    end
    subgraph 13["Sales / Commons"]
      14([Currency])
      class 14 DomainPerspective
    end
    subgraph 15["Sales / Pricing / Price Lists"]
      16([Price List Repository])
      class 16 DomainPerspective
    end
    subgraph 17["Sales / Pricing"]
      18([Offer Modifiers])
      class 18 DomainPerspective
      19([Offer Request])
      class 19 DomainPerspective
    end
    subgraph 20["Sales / Products"]
      21([Product Amount])
      class 21 DomainPerspective
    end
    subgraph 22["Sales / Sales Channels"]
      23([Sales Channel])
      class 23 DomainPerspective
    end
    0-->|depends on|9
    2-->|depends on|9
    4-->|depends on|9
    7-->|depends on|9
    9-->|depends on|11
    9-->|depends on|13
    9-->|depends on|15
    9-->|depends on|17
    9-->|depends on|20
    9-->|depends on|22
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Calculate Prices)
    class 0 DomainPerspective
    1([ConfirmOffer])
    class 1 DomainPerspective
    0-->|is used in|1
    2([CreateOrder])
    class 2 DomainPerspective
    0-->|is used in|2
    3([GetOffer])
    class 3 DomainPerspective
    0-->|is used in|3
    4([PlaceOrder])
    class 4 DomainPerspective
    0-->|is used in|4
    5([PriceCart])
    class 5 DomainPerspective
    0-->|is used in|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Factories

[Offer Modifiers](OfferModifiers.md)  

##### Ddd Repositories

[Price List Repository](PriceLists/PriceListRepository.md)  

##### Ddd Value Objects

[Client Id](../Clients/ClientId.md)  
[Currency](../Commons/Currency.md)  
[Offer Request](OfferRequest.md)  
[Product Amount](../Products/ProductAmount.md)  
[Sales Channel](../SalesChannels/SalesChannel.md)  

##### Process Steps

[ConfirmOffer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[CreateOrder](../WholesaleOrdering/ProductPricing/CreateOrder.md)  
[GetOffer](../WholesaleOrdering/OrderPricing/GetOffer.md)  
[PlaceOrder](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[PriceCart](../OnlineOrdering/CartPricing/PriceCart.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)