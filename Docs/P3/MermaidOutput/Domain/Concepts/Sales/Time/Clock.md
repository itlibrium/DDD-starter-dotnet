
# Clock

***Ddd Domain Service***  

This view contains details information about Clock building block, including:
- dependencies
- modules
- related processes  

---



## Domain Perspective


### Dependencies

```mermaid
  flowchart TB
    subgraph 0["Sales / Online Ordering / Order Placement"]
      1([Place Order])
      class 1 DomainPerspective
    end
    subgraph 2["Sales / Wholesale Ordering / Order Placement"]
      3([Place Order])
      class 3 DomainPerspective
    end
    subgraph 4["Sales / Wholesale Ordering / Order Pricing"]
      5([Confirm Offer])
      class 5 DomainPerspective
    end
    subgraph 6["Sales / Time"]
      7(Clock)
      class 7 DomainPerspective
    end
    0-->|depends on|6
    2-->|depends on|6
    4-->|depends on|6
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related process steps

```mermaid
  flowchart TB
    0(Clock)
    class 0 DomainPerspective
    1([Place Order])
    class 1 DomainPerspective
    0-->|is used in|1
    2([Place Order])
    class 2 DomainPerspective
    0-->|is used in|2
    3([Confirm Offer])
    class 3 DomainPerspective
    0-->|is used in|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Source code

[Clock.cs](../../../../../../../Sources/Sales/Sales.DeepModel/Time/Clock.cs)  

## Next steps


### Zoom-in


#### Domain perspective


##### Process Steps

[Confirm Offer](../WholesaleOrdering/OrderPricing/ConfirmOffer.md)  
[Place Order](../OnlineOrdering/OrderPlacement/PlaceOrder.md)  
[Place Order](../WholesaleOrdering/OrderPlacement/PlaceOrder.md)  

### Zoom-out


#### Domain perspective


##### Domain Modules

[Sales | Time](Time.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)