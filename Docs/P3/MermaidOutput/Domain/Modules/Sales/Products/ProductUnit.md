
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
    subgraph 0["Sales.Orders"]
      1([Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Pricing.Discounts"]
      3([Client Level Discounts])
      class 3 DomainPerspective
      4([Product Discount])
      class 4 DomainPerspective
      5([Product Level Discounts])
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Pricing.PriceLists"]
      7([Base Price])
      class 7 DomainPerspective
      8([Base Prices])
      class 8 DomainPerspective
    end
    subgraph 9["Sales.Products"]
      10([Product Amount])
      class 10 DomainPerspective
    end
    subgraph 11["Sales.Products"]
      12(Product Unit)
      class 12 DomainPerspective
    end
    subgraph 13["Sales.Products"]
      14([Amount Unit])
      class 14 DomainPerspective
      15([Product Id])
      class 15 DomainPerspective
    end
    0-->|depends on|11
    2-->|depends on|11
    6-->|depends on|11
    9-->|depends on|11
    11-->|depends on|13
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


##### Ddd Value Objects

[Amount Unit](AmountUnit.md)  
[Product Id](ProductId.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Products](Products-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)