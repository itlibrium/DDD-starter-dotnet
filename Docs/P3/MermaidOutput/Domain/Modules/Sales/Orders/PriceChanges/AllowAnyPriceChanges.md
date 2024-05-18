
# Allow Any Price Changes

***Ddd Domain Service***  

This view contains details information about Allow Any Price Changes building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.Orders.PriceChanges"]
      1([Price Changes Policies])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Orders.PriceChanges"]
      3(Allow Any Price Changes)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Pricing"]
      5([Quote])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
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

[Quote](../../Pricing/Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders | Price changes](PriceChanges-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)