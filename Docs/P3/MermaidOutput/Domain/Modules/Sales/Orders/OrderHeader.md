
# Order Header

***Ddd Entity***  

This view contains details information about Order Header building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales.OnlineOrdering.OrderPlacement"]
      1([Place Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales.WholesaleOrdering.OrderCreation"]
      3([Create Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales.Orders"]
      5(Order Header)
      class 5 DomainPerspective
    end
    subgraph 6["Sales.Orders"]
      7([Invoicing Details])
      class 7 DomainPerspective
      8([Order Note])
      class 8 DomainPerspective
    end
    0-->|depends on|4
    2-->|depends on|4
    4-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related use cases

```mermaid
  flowchart TB
    0(Order Header)
    class 0 DomainPerspective
    1([Place Order])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Create Order])
    class 2 DomainPerspective
    0-->|is used in|2
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


##### Ddd Entities

[Order Note](OrderNote.md)  

##### Ddd Value Objects

[Invoicing Details](InvoicingDetails.md)  

##### Use Cases

[Create Order](../WholesaleOrdering/OrderCreation/CreateOrder.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Orders](Orders-module.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)