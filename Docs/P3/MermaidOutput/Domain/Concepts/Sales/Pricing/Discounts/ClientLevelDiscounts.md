
# Client Level Discounts

***Ddd Domain Service***  

This view contains details information about Client Level Discounts building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1([Individual Sales Conditions])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Discounts"]
      3(Client Level Discounts)
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing / Discounts"]
      5([Percentage Discount])
      class 5 DomainPerspective
      6([Percentage Discount])
      class 6 DomainPerspective
      7([Product Discount])
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Pricing"]
      9([Offer])
      class 9 DomainPerspective
      10([Quote])
      class 10 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|8
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

[Percentage Discount](PercentageDiscount.md)  

##### Ddd Value Objects

[Offer](../Offer.md)  
[Percentage Discount](PercentageDiscount.md)  
[Product Discount](ProductDiscount.md)  
[Quote](../Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Discounts](Discounts.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)