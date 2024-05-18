
# Quote

***Ddd Value Object***  

This view contains details information about Quote building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Orders"]
      1([Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Orders.PriceChanges"]
      3([Allow Any Price Changes])
      class 3 DomainPerspective
      4([Allow Price Changes if Total Price Is Lower])
      class 4 DomainPerspective
      5([Price Changes Policy])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Pricing"]
      7([Calculate Prices])
      class 7 DomainPerspective
      8([Individual Sales Conditions])
      class 8 DomainPerspective
      9([Offer])
      class 9 DomainPerspective
      10([Quote Modifier])
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Pricing.Discounts"]
      12([Client Level Discounts])
      class 12 DomainPerspective
      13([Product Level Discounts])
      class 13 DomainPerspective
    end
    subgraph 14["Sales.WholesaleOrdering.ProductPricing"]
      15([Create Order])
      class 15 DomainPerspective
    end
    subgraph 16["Sales.Pricing"]
      17(Quote)
      class 17 DomainPerspective
    end
    subgraph 18["Sales.Commons"]
      19([Money])
      class 19 DomainPerspective
    end
    subgraph 20["Sales.Pricing"]
      21([Quote Modifier])
      class 21 DomainPerspective
    end
    subgraph 22["Sales.Products"]
      23([Product Amount])
      class 23 DomainPerspective
    end
    0-->|depends on|16
    2-->|depends on|16
    6-->|depends on|16
    11-->|depends on|16
    14-->|depends on|16
    16-->|depends on|18
    16-->|depends on|20
    16-->|depends on|22
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Quote)
    class 0 DomainPerspective
    1([Create Order])
    class 1 DomainPerspective
    0-->|is used in|1
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

[Quote Modifier](QuoteModifier.md)  

##### Ddd Value Objects

[Money](../Commons/Money.md)  
[Product Amount](../Products/ProductAmount.md)  

##### Use Cases

[Create Order](../WholesaleOrdering/ProductPricing/CreateOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)