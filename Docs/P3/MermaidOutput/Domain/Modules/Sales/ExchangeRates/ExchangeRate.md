
# Exchange Rate

***Ddd Value Object***  

This view contains details information about Exchange Rate building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.ExchangeRates"]
      1([Exchange Rate Provider])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing"]
      3([Calculate Prices])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.ExchangeRates"]
      5(Exchange Rate)
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Commons"]
      7([Currency])
      class 7 DomainPerspective
      8([Money])
      class 8 DomainPerspective
    end
    0-->|depends on|4
    2-->|depends on|4
    4-->|depends on|6
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
[Money](../Commons/Money.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Exchange rates](ExchangeRates-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)