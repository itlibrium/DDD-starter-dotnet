
# Price Changes Policies

***Ddd Factory***  

This view contains details information about Price Changes Policies building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.WholesaleOrdering.OrderPricing"]
      1([Confirm Offer])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.Orders.PriceChanges"]
      3(Price Changes Policies)
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Clients"]
      5([Client Id])
      class 5 DomainPerspective
      6([Client Repository])
      class 6 DomainPerspective
      7([Client Status])
      class 7 DomainPerspective
    end
    subgraph 8["Sales.Orders.PriceChanges"]
      9([Allow Any Price Changes])
      class 9 DomainPerspective
      10([Allow Price Changes if Total Price Is Lower])
      class 10 DomainPerspective
      11([Price Changes Policy])
      class 11 DomainPerspective
    end
    0-->|depends on|2
    2-->|depends on|4
    2-->|depends on|8
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Price Changes Policies)
    class 0 DomainPerspective
    1([Confirm Offer])
    class 1 DomainPerspective
    0-->|is used in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Source code

No source code files were found.  

## Next use cases


### Zoom-in


#### Domain perspective


##### Ddd Domain Services

[Allow Any Price Changes](AllowAnyPriceChanges.md)  
[Allow Price Changes if Total Price Is Lower](AllowPriceChangesIfTotalPriceIsLower.md)  
[Price Changes Policy](PriceChangesPolicy.md)  

##### Ddd Repositories

[Client Repository](../../Clients/ClientRepository.md)  

##### Ddd Value Objects

[Client Id](../../Clients/ClientId.md)  
[Client Status](../../Clients/ClientStatus.md)  

##### Use Cases

[Confirm Offer](../../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders | Price changes](PriceChanges-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)