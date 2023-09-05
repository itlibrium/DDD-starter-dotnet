
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
    subgraph 0["Sales / Wholesale Ordering / Order Modification"]
      1([AddToOrder])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Orders"]
      3([Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing / Price Lists"]
      5([Base Prices])
      class 5 DomainPerspective
      6([Price List Repository])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Pricing"]
      8([Calculate Prices])
      class 8 DomainPerspective
      9([Offer])
      class 9 DomainPerspective
      10([Quote])
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
    4-->|depends on|11
    7-->|depends on|11
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
    1([AddToOrder])
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

[AddToOrder](../WholesaleOrdering/OrderModification/AddToOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Products](Products.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)