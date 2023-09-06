
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
      9([Price Modifier])
      class 9 DomainPerspective
      10([Quote])
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Pricing / Discounts"]
      12([Discount])
      class 12 DomainPerspective
      13([Discount])
      class 13 DomainPerspective
      14([Percentage Discount])
      class 14 DomainPerspective
      15([Percentage Discount])
      class 15 DomainPerspective
      16([Value Discount])
      class 16 DomainPerspective
      17([Value Discount])
      class 17 DomainPerspective
    end
    subgraph 18["Sales / Pricing / Price Lists"]
      19([Base Price])
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
    2-->|depends on|20
    5-->|depends on|20
    7-->|depends on|20
    11-->|depends on|20
    18-->|depends on|20
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