
# Product Id

***Ddd Value Object***  

This view contains details information about Product Id building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Products"]
      1([Product Amount])
      class 1 DomainPerspective
      2([Product Unit])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Products"]
      4(Product Id)
      class 4 DomainPerspective
    end
    0-->|depends on|3
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

[Sales | Products](Products.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)