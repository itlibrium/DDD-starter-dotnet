
# Offer Modifier

***Ddd Domain Service***  

This view contains details information about Offer Modifier building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1([Offer])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Pricing / Special Offers"]
      3([Every Second Box for Half Price])
      class 3 DomainPerspective
      4([Special Offer])
      class 4 DomainPerspective
      5([Three for Two])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Pricing"]
      7(Offer Modifier)
      class 7 DomainPerspective
    end
    subgraph 8["Sales / Pricing"]
      9([Offer])
      class 9 DomainPerspective
    end
    0-->|depends on|6
    2-->|depends on|6
    6-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Offer](Offer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)