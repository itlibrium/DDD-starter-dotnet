
# Money

***Ddd Value Object***  

This view contains details information about Money building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.ExchangeRates"]
      1([Exchange Rate])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Orders"]
      3([Order])
      class 3 DomainPerspective
      4([Order Factory])
      class 4 DomainPerspective
      5([Order Price Agreement])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Orders.PriceChanges"]
      7([Allow Price Changes if Total Price Is Lower])
      class 7 DomainPerspective
    end
    subgraph 8["Sales.Pricing"]
      9([Offer])
      class 9 DomainPerspective
      10([Quote])
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Pricing.Discounts"]
      12([Discount])
      class 12 DomainPerspective
      13([Percentage Discount])
      class 13 DomainPerspective
      14([Value Discount])
      class 14 DomainPerspective
    end
    subgraph 15["Sales.Pricing.PriceLists"]
      16([Base Price])
      class 16 DomainPerspective
      17([Base Prices])
      class 17 DomainPerspective
      18([Price List Repository])
      class 18 DomainPerspective
    end
    subgraph 19["Sales.Commons"]
      20(Money)
      class 20 DomainPerspective
    end
    subgraph 21["Sales.Commons"]
      22([Currency])
      class 22 DomainPerspective
      23([Percentage])
      class 23 DomainPerspective
    end
    0-->|depends on|19
    2-->|depends on|19
    6-->|depends on|19
    8-->|depends on|19
    11-->|depends on|19
    15-->|depends on|19
    19-->|depends on|21
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

No related processes were found.  

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Currency](Currency.md)  
[Percentage](Percentage.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Commons](Commons-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)