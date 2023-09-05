
# Allow Price Changes if Total Price Is Lower

***Ddd Domain Service***  

This view contains details information about Allow Price Changes if Total Price Is Lower building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Orders / Price Changes"]
      1([Price Changes Policies])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Orders / Price Changes"]
      3(Allow Price Changes if Total Price Is Lower)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Commons"]
      5([Money])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Pricing"]
      7([Quote])
      class 7 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|6
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

[Money](../../Commons/Money.md)  
[Quote](../../Pricing/Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Price Changes](PriceChanges.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)