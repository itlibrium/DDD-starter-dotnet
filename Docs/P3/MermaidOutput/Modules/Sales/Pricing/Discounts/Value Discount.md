
# Value Discount

This view contains details information about Value Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Value Discount)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
    end
    subgraph 4["Discounts"]
      5([Value Discount])
      class 5 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Value Discount is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Value Discount](Value Discount.md)  

##### Ddd value objects

[Money](../../Commons/Money.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)