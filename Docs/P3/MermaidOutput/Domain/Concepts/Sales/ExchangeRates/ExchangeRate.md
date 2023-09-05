
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
    subgraph 0["Sales / Exchange Rates"]
      1(Exchange Rate)
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Commons"]
      3([Currency])
      class 3 DomainPerspective
      4([Money])
      class 4 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Currency](../Commons/Currency.md)  
[Money](../Commons/Money.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Exchange Rates](ExchangeRates.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)