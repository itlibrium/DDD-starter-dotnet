
# [*Domain building block*] ProductDiscount

This view contains details information about ProductDiscount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Discounts"]
      1(ProductDiscount)
      class 1 DomainPerspective
    end
    subgraph 2["Discounts"]
      3([Discount])
      class 3 DomainPerspective
      4([Discount])
      class 4 DomainPerspective
    end
    subgraph 5["Products"]
      6([ProductUnit])
      class 6 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

ProductDiscount is not used in any process step.  

## Next steps


### Zoom-out

- [[*Domain module*] Discounts](../../../../Modules/Sales/Pricing/Discounts/Discounts.md)

### Change perspective

- [[*Domain building block*] Discount](Discount.md)
- [[*Domain building block*] Discount](Discount.md)
- [[*Domain building block*] ProductUnit](../../Products/ProductUnit.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)