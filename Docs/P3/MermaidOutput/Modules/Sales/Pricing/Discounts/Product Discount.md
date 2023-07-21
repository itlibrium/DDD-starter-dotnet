
# Product Discount

This view contains details information about Product Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Product Discount)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([Discount])
      class 3 DomainPerspective
      4([Discount])
      class 4 DomainPerspective
    end
    subgraph 5["Products"]
      6([Product Unit])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Product Discount is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Discount](Discount.md)  

##### Ddd value objects

[Discount](Discount.md)  
[Product Unit](../../Products/Product Unit.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)