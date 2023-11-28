
# Offer Request

***Ddd Value Object***  

This view contains details information about Offer Request building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Pricing"]
      1([Calculate Prices])
      class 1 DomainPerspective
      2([Offer Modifiers])
      class 2 DomainPerspective
    end
    subgraph 3["Sales / Pricing"]
      4(Offer Request)
      class 4 DomainPerspective
    end
    subgraph 5["Sales / Clients"]
      6([Client Id])
      class 6 DomainPerspective
    end
    subgraph 7["Sales / Sales Channels"]
      8([Sales Channel])
      class 8 DomainPerspective
    end
    0-->|depends on|3
    3-->|depends on|5
    3-->|depends on|7
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

No related processes were found.  

## Technology Perspective


### Source code

[OfferRequest.cs](../../../../../../../Sources/Sales/Sales.DeepModel/Pricing/OfferRequest.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Ddd Value Objects

[Client Id](../Clients/ClientId.md)  
[Sales Channel](../SalesChannels/SalesChannel.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Pricing](Pricing.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)