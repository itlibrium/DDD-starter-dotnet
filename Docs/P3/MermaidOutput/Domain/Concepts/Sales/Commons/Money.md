
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
    subgraph 0["Sales / Pricing / Discounts"]
      1([Discount])
      class 1 DomainPerspective
      2([Discount])
      class 2 DomainPerspective
      3([Percentage Discount])
      class 3 DomainPerspective
      4([Percentage Discount])
      class 4 DomainPerspective
      5([Value Discount])
      class 5 DomainPerspective
      6([Value Discount])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Exchange Rates"]
      8([Exchange Rate])
      class 8 DomainPerspective
    end
    subgraph 9["Sales / Orders"]
      10([Order Factory])
      class 10 DomainPerspective
      11([Order Price Agreement])
      class 11 DomainPerspective
    end
    subgraph 12["Sales / Orders / Price Changes"]
      13([Allow Price Changes if Total Price Is Lower])
      class 13 DomainPerspective
    end
    subgraph 14["Sales / Pricing / Price Lists"]
      15([Base Price])
      class 15 DomainPerspective
    end
    subgraph 16["Sales / Pricing"]
      17([Offer])
      class 17 DomainPerspective
      18([Price Modifier])
      class 18 DomainPerspective
      19([Quote])
      class 19 DomainPerspective
    end
    subgraph 20["Sales / Commons"]
      21(Money)
      class 21 DomainPerspective
    end
    subgraph 22["Sales / Commons"]
      23([Currency])
      class 23 DomainPerspective
      24([Percentage])
      class 24 DomainPerspective
    end
    0-->|depends on|20
    7-->|depends on|20
    9-->|depends on|20
    12-->|depends on|20
    14-->|depends on|20
    16-->|depends on|20
    20-->|depends on|22
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

[Commons](Commons.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)