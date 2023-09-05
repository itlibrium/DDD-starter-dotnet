
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
    subgraph 0["Sales / Orders"]
      1(Order Price Agreement)
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Commons"]
      3([Money])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Orders"]
      5([Price Agreement Type])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
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

[Money](../Commons/Money.md)  
[Price Agreement Type](PriceAgreementType.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)