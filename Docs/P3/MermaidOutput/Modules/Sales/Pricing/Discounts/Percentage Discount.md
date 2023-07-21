
# Percentage Discount

This view contains details information about Percentage Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Percentage Discount)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
      4([Percentage])
      class 4 DomainPerspective
    end
    subgraph 5["Discounts"]
      6([Percentage Discount])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Percentage Discount is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Percentage Discount](Percentage Discount.md)  

##### Ddd value objects

[Money](../../Commons/Money.md)  
[Percentage](../../Commons/Percentage.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)