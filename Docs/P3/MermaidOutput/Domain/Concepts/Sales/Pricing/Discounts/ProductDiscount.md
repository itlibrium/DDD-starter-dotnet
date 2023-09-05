
# Product Discount

***Ddd Value Object***  

This view contains details information about Product Discount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing / Discounts"]
      1([Client Level Discounts])
      class 1 DomainPerspective
      2([Product Level Discounts])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Pricing / Discounts"]
      4(Product Discount)
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Pricing / Discounts"]
      6([Discount])
      class 6 DomainPerspective
      7([Discount])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Products"]
      9([Product Unit])
      class 9 DomainPerspective
    end
    0-->|depends on|3
    3-->|depends on|5
    3-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Discount](Discount.md)  

##### Ddd Value Objects

[Discount](Discount.md)  
[Product Unit](../../Products/ProductUnit.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)