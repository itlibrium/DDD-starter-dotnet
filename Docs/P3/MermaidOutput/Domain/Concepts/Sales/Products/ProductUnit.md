
# Product Unit

***Ddd Value Object***  

This view contains details information about Product Unit building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Orders"]
      1([Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Discounts"]
      3([Product Discount])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing / Price Lists"]
      5([Base Price])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Products"]
      7([Product Amount])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Products"]
      9(Product Unit)
      class 9 DomainPerspective
    end
    subgraph 10["Sales / Products"]
      11([Amount Unit])
      class 11 DomainPerspective
      12([Product Id])
      class 12 DomainPerspective
    end
    0-->|depends on|8
    2-->|depends on|8
    4-->|depends on|8
    6-->|depends on|8
    8-->|depends on|10
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

[Amount Unit](AmountUnit.md)  
[Product Id](ProductId.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Products](Products.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)