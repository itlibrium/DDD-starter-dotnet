
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
    subgraph 0["Sales / Exchange Rates"]
      1([Exchange Rate])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Orders"]
      3([Order Factory])
      class 3 DomainPerspective
      4([Order Price Agreement])
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Orders / Price Changes"]
      6([Allow Price Changes if Total Price Is Lower])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Pricing"]
      8([Offer])
      class 8 DomainPerspective
      9([Quote])
      class 9 DomainPerspective
    end
    subgraph 10["Sales / Pricing / Discounts"]
      11([Discount])
      class 11 DomainPerspective
      12([Percentage Discount])
      class 12 DomainPerspective
      13([Value Discount])
      class 13 DomainPerspective
    end
    subgraph 14["Sales / Pricing / Price Lists"]
      15([Base Price])
      class 15 DomainPerspective
    end
    subgraph 16["Sales / Commons"]
      17(Money)
      class 17 DomainPerspective
    end
    subgraph 18["Sales / Commons"]
      19([Currency])
      class 19 DomainPerspective
      20([Percentage])
      class 20 DomainPerspective
    end
    0-->|depends on|16
    2-->|depends on|16
    5-->|depends on|16
    7-->|depends on|16
    10-->|depends on|16
    14-->|depends on|16
    16-->|depends on|18
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

[Currency](Currency.md)  
[Percentage](Percentage.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Commons](Commons.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)