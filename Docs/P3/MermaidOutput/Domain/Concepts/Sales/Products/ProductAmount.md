
# Product Amount

***Ddd Value Object***  

This view contains details information about Product Amount building block, including:
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
    subgraph 2["Sales / Pricing"]
      3([Calculate Prices])
      class 3 DomainPerspective
      4([Offer])
      class 4 DomainPerspective
      5([Quote])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Pricing / Price Lists"]
      7([Base Prices])
      class 7 DomainPerspective
      8([Price List Repository])
      class 8 DomainPerspective
    end
    subgraph 9["Sales / Wholesale Ordering / Order Modification"]
      10([Add to Order])
      class 10 DomainPerspective
    end
    subgraph 11["Sales / Products"]
      12(Product Amount)
      class 12 DomainPerspective
    end
    subgraph 13["Sales / Products"]
      14([Amount])
      class 14 DomainPerspective
      15([Amount Unit])
      class 15 DomainPerspective
      16([Product Id])
      class 16 DomainPerspective
      17([Product Unit])
      class 17 DomainPerspective
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

### Related process steps

```mermaid
  flowchart TB
    0(Product Amount)
    class 0 DomainPerspective
    1([Add to Order])
    class 1 DomainPerspective
    0-->|is used in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Amount](Amount.md)  
[Amount Unit](AmountUnit.md)  
[Product Id](ProductId.md)  
[Product Unit](ProductUnit.md)  

##### Process Steps

[Add to Order](../WholesaleOrdering/OrderModification/AddToOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Products](Products.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)