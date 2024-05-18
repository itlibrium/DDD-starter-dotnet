
# Product Level Discounts

***Ddd Domain Service***  

This view contains details information about Product Level Discounts building block, including:
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
      2([Offer Modifiers])
      class 2 DomainPerspective
    end
    subgraph 3["Sales.Pricing.Discounts"]
      4([Discounts Repository])
      class 4 DomainPerspective
    end
    subgraph 5["Sales.Pricing.Discounts"]
      6(Product Level Discounts)
      class 6 DomainPerspective
    end
    subgraph 7["Sales.Pricing"]
      8([Offer])
      class 8 DomainPerspective
      9([Quote])
      class 9 DomainPerspective
      10([Quote Modifier])
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Pricing.Discounts"]
      12([Discount])
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
    0-->|depends on|5
    3-->|depends on|5
    5-->|depends on|7
    5-->|depends on|11
    5-->|depends on|14
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