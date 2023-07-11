
# [*Domain building block*] ExchangeRate

This view contains details information about ExchangeRate building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["ExchangeRates"]
      1(ExchangeRate)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
    end
    0-->|depends on|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ExchangeRate is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] ExchangeRates](../../../Modules/Sales/ExchangeRates/ExchangeRates.md)

### Change perspective

- [[*Domain building block*] Money](../Commons/Money.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)