
# Percentage

***Ddd Value Object***  

This view contains details information about Percentage building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Commons"]
      1([Money])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing"]
      3([Offer])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Pricing / Discounts"]
      5([Discount])
      class 5 DomainPerspective
      6([Discount])
      class 6 DomainPerspective
      7([Percentage Discount])
      class 7 DomainPerspective
      8([Percentage Discount])
      class 8 DomainPerspective
    end
    subgraph 9["Sales / Commons"]
      10(Percentage)
      class 10 DomainPerspective
    end
    0-->|depends on|9
    2-->|depends on|9
    4-->|depends on|9
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-out


#### Domain perspective


##### Domain Modules

[Commons](Commons.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)