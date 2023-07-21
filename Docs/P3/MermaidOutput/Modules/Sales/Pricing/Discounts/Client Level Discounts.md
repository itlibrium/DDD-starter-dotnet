
# Client Level Discounts

This view contains details information about Client Level Discounts building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(Client Level Discounts)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([Percentage Discount])
      class 3 DomainPerspective
      4([Percentage Discount])
      class 4 DomainPerspective
      5([Product Discount])
      class 5 DomainPerspective
    end
    subgraph 6["Pricing"]
      7([Offer])
      class 7 DomainPerspective
      8([Quote])
      class 8 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

Client Level Discounts is not used directly in any process step.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd domain services

[Percentage Discount](Percentage Discount.md)  

##### Ddd value objects

[Offer](../Offer.md)  
[Percentage Discount](Percentage Discount.md)  
[Product Discount](Product Discount.md)  
[Quote](../Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)