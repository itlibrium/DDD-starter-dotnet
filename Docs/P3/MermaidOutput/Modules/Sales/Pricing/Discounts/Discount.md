
# Discount

This view contains details information about Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Discount)
      class 1 DomainPerspective
    end
    subgraph 2["Commons"]
      3([Money])
      class 3 DomainPerspective
      4([Percentage])
      class 4 DomainPerspective
    end
    subgraph 5["Discounts"]
      6([Discount])
      class 6 DomainPerspective
      7([Percentage Discount])
      class 7 DomainPerspective
      8([Percentage Discount])
      class 8 DomainPerspective
      9([Value Discount])
      class 9 DomainPerspective
      10([Value Discount])
      class 10 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Discount is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Discount](Discount.md)  
[Percentage Discount](Percentage Discount.md)  
[Value Discount](Value Discount.md)  

##### Ddd value objects

[Money](../../Commons/Money.md)  
[Percentage](../../Commons/Percentage.md)  
[Percentage Discount](Percentage Discount.md)  
[Value Discount](Value Discount.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)