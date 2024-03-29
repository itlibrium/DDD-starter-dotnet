﻿
# Amount

***Ddd Value Object***  

This view contains details information about Amount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Products"]
      1([Product Amount])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Products"]
      3(Amount)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Products"]
      5([Amount Unit])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Technology Perspective


### Source code

[Amount.cs](../../../../../../../Sources/Sales/Sales.DeepModel/Products/Amount.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Amount Unit](AmountUnit.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Products](Products.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)