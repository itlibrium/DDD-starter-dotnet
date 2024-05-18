
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
    subgraph 0["Sales.Pricing"]
      1([Individual Sales Conditions])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing.Discounts"]
      3([Discounts Repository])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Pricing.Discounts"]
      5(Client Level Discounts)
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Pricing"]
      7([Offer])
      class 7 DomainPerspective
      8([Quote])
      class 8 DomainPerspective
      9([Quote Modifier])
      class 9 DomainPerspective
    end
    subgraph 10["Sales.Pricing.Discounts"]
      11([Discount])
      class 11 DomainPerspective
      12([Percentage Discount])
      class 12 DomainPerspective
      13([Product Discount])
      class 13 DomainPerspective
    end
    subgraph 14["Sales.Products"]
      15([Product Amount])
      class 15 DomainPerspective
      16([Product Unit])
      class 16 DomainPerspective
    end
    0-->|depends on|4
    2-->|depends on|4
    4-->|depends on|6
    4-->|depends on|10
    4-->|depends on|14
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

No related processes were found.  

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Quote Modifier](../QuoteModifier.md)  

##### Ddd Value Objects

[Discount](Discount.md)  
[Offer](../Offer.md)  
[Percentage Discount](PercentageDiscount.md)  
[Product Amount](../../Products/ProductAmount.md)  
[Product Discount](ProductDiscount.md)  
[Product Unit](../../Products/ProductUnit.md)  
[Quote](../Quote.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing | Discounts](Discounts-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)