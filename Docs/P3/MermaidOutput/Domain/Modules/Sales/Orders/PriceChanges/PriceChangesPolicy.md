
# Price Changes Policy

***Ddd Domain Service***  

This view contains details information about Price Changes Policy building block, including:
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
      3([Price Changes Policies])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.WholesaleOrdering.OrderPricing"]
      5([Confirm Offer])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Orders.PriceChanges"]
      7(Price Changes Policy)
      class 7 DomainPerspective
    end
    subgraph 8["Sales.Pricing"]
      9([Quote])
      class 9 DomainPerspective
    end
    0-->|depends on|6
    2-->|depends on|6
    4-->|depends on|6
    6-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Price Changes Policy)
    class 0 DomainPerspective
    1([Confirm Offer])
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


##### Ddd Value Objects

[Quote](../../Pricing/Quote.md)  

##### Use Cases

[Confirm Offer](../../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders | Price changes](PriceChanges-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)