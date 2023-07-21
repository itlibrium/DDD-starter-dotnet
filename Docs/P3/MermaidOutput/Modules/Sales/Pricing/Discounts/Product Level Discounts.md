
# Product Level Discounts

This view contains details information about Product Level Discounts building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Product Level Discounts)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([Product Discount])
      class 3 DomainPerspective
    end
    subgraph 4["Pricing"]
      5([Offer])
      class 5 DomainPerspective
      6([Quote])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Product Level Discounts is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd value objects

[Offer](../Offer.md)  
[Product Discount](Product Discount.md)  
[Quote](../Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)