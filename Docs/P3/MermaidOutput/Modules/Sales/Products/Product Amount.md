
# Product Amount

This view contains details information about Product Amount building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Products"]
      1(Product Amount)
      class 1 DomainPerspective
    end
    subgraph 2["Products"]
      3([Amount])
      class 3 DomainPerspective
      4([Product Id])
      class 4 DomainPerspective
      5([Product Unit])
      class 5 DomainPerspective
    end
    0-->|depends on|2
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


##### Ddd value objects

[Amount](Amount.md)  
[Product Id](Product Id.md)  
[Product Unit](Product Unit.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Products](Products.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)