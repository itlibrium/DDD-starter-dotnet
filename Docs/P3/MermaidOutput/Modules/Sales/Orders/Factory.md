
# Factory

This view contains details information about Factory building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Orders"]
      1(Factory)
      class 1 DomainPerspective
    end
    subgraph 2["Clients"]
      3([Client Id])
      class 3 DomainPerspective
    end
    subgraph 4["Commons"]
      5([Money])
      class 5 DomainPerspective
    end
    subgraph 6["Orders"]
      7([Order Id])
      class 7 DomainPerspective
    end
    subgraph 8["Pricing"]
      9([Offer])
      class 9 DomainPerspective
    end
    0-->|depends on|2
    0-->|depends on|4
    0-->|depends on|6
    0-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Factory)
    class 0 DomainPerspective
    1([CreateOrder])
    class 1 DomainPerspective
    0-->|is used in|1
    2([PlaceOrder])
    class 2 DomainPerspective
    0-->|is used in|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd value objects

[Client Id](../Clients/Client Id.md)  
[Money](../Commons/Money.md)  
[Offer](../Pricing/Offer.md)  
[Order Id](Order Id.md)  

### Zoom-out


#### Domain perspective


##### Domain modules

[Orders](Orders.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)