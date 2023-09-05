
# Business Processes

This view contains all business processes with their sub-processes.  

---



## Risk Management

```mermaid
  flowchart TB
    0(Risk Management)
    class 0 DomainPerspective
    1(Risk Score Calculation)
    class 1 DomainPerspective
    0-->|contains|1
    2(Risk Score Publication)
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
    2(Online Ordering)
    class 2 DomainPerspective
    0-->|contains|2
    3(Payment)
    class 3 DomainPerspective
    0-->|contains|3
    4(Products Delivery)
    class 4 DomainPerspective
    0-->|contains|4
    5(Wholesale Ordering)
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

[Fulfillment](Sale/Fulfillment/Fulfillment.md)  
[Online Ordering](Sale/Online ordering/OnlineOrdering.md)  
[Payment](Sale/Payment/Payment.md)  
[Products Delivery](Sale/Products delivery/ProductsDelivery.md)  
[Risk Management](Risk management/RiskManagement.md)  
[Risk Score Calculation](Risk management/Risk score calculation/RiskScoreCalculation.md)  
[Risk Score Publication](Risk management/Risk score publication/RiskScorePublication.md)  
[Sale](Sale/Sale.md)  
[Wholesale Ordering](Sale/Wholesale ordering/WholesaleOrdering.md)  

### Zoom-out


#### Multi perspectives

[Main page](../../README.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)