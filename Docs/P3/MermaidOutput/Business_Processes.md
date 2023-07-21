
# Business processes

This view contains all business processes with their sub-processes.  

---



## Risk management

```mermaid
  flowchart TB
    0(Risk management)
    class 0 DomainPerspective
    1(Risk score calculation)
    class 1 DomainPerspective
    0-->|contains|1
    2(Risk score publication)
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Sale

```mermaid
  flowchart TB
    0(Sale)
    class 0 DomainPerspective
    1(Fulfillment)
    class 1 DomainPerspective
    0-->|contains|1
    2(Online ordering)
    class 2 DomainPerspective
    0-->|contains|2
    3(Payment)
    class 3 DomainPerspective
    0-->|contains|3
    4(Products delivery)
    class 4 DomainPerspective
    0-->|contains|4
    5(Wholesale ordering)
    class 5 DomainPerspective
    0-->|contains|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Processes

[Fulfillment](Processes/Sale/Fulfillment/Fulfillment.md)  
[Online ordering](Processes/Sale/Online ordering/Online ordering.md)  
[Payment](Processes/Sale/Payment/Payment.md)  
[Products delivery](Processes/Sale/Products delivery/Products delivery.md)  
[Risk management](Processes/Risk management/Risk management.md)  
[Risk score calculation](Processes/Risk management/Risk score calculation/Risk score calculation.md)  
[Risk score publication](Processes/Risk management/Risk score publication/Risk score publication.md)  
[Sale](Processes/Sale/Sale.md)  
[Wholesale ordering](Processes/Sale/Wholesale ordering/Wholesale ordering.md)  

### Zoom-out


#### Multi perspectives


##### Cross elements

[Main page](README.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)