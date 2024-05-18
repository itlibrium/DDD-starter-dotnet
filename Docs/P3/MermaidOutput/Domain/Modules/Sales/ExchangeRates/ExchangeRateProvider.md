
# Exchange Rate Provider

***External System Integration***  

This view contains details information about Exchange Rate Provider building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Pricing"]
      1([Calculate Prices])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.ExchangeRates"]
      3(Exchange Rate Provider)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Commons"]
      5([Currency])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.ExchangeRates"]
      7([Exchange Rate])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
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

[Currency](../Commons/Currency.md)  
[Exchange Rate](ExchangeRate.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Exchange rates](ExchangeRates-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)