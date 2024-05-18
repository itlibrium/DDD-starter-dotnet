
# Order Price Agreement

***Ddd Value Object***  

This view contains details information about Order Price Agreement building block, including:
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
    subgraph 2["Sales.Orders"]
      3(Order Price Agreement)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Commons"]
      5([Money])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Orders"]
      7([Price Agreement Type])
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

[Money](../Commons/Money.md)  
[Price Agreement Type](PriceAgreementType.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)