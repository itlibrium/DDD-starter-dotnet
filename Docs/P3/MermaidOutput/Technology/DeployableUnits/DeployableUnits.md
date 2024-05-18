
# Deployable Units

This view contains all deployable units for MyCompany e-commerce product.  

---



## Deployable units and their tires

```mermaid
  flowchart TB
    subgraph 0["Application"]
      1(ecommerce-search)
      class 1 TechnologyPerspective
      2(ecommerce-monolith)
      class 2 TechnologyPerspective
    end
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next use cases


### Zoom-in


#### Technology perspective


##### Deployable Units

[ecommerce-monolith](EcommerceMonolith.md)  
[ecommerce-search](EcommerceSearch.md)  

### Zoom-out


#### Multi perspectives

[Main page](../../README.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)