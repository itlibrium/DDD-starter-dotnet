
# [*Business process*] Sale

This view contains details information about Sale business process, including:
- other related processes
- process steps
- related domain modules
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related processes and steps

```mermaid
  flowchart TB
    0(Sale)
    class 0 DomainPerspective
    1([Fulfillment])
    class 1 DomainPerspective
    0-->|contains|1
    2([Online ordering])
    class 2 DomainPerspective
    0-->|contains|2
    3([Payment])
    class 3 DomainPerspective
    0-->|contains|3
    4([Products delivery])
    class 4 DomainPerspective
    0-->|contains|4
    5([Wholesale ordering])
    class 5 DomainPerspective
    0-->|contains|5
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related modules

```mermaid
  flowchart TB
    0(Sale)
    class 0 DomainPerspective
    1([Payments])
    class 1 DomainPerspective
    0-->|belongs to|1
    2([ProductsDelivery])
    class 2 DomainPerspective
    0-->|belongs to|2
    3([Sales])
    class 3 DomainPerspective
    0-->|belongs to|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Sale)
    class 0 DomainPerspective
    1([ecommerce-monolith])
    class 1 TechnologyPerspective
    0-->|is deployed in|1
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## People Perspective


### Engaged people

```mermaid
  flowchart LR
    subgraph 0["Actors"]
      direction TB
      1([RetailClient])
      class 1 PeoplePerspective
      2([WholesaleClient])
      class 2 PeoplePerspective
      1---2
    end
    3(Sale)
    class 3 DomainPerspective
    0-->|uses|3
    subgraph 4["Teams"]
      direction TB
      5([Core team])
      class 5 PeoplePerspective
      6([Inventory team])
      class 6 PeoplePerspective
      5---6
      7([Supporting team])
      class 7 PeoplePerspective
      6---7
    end
    4---3
    4-->|develops & maintains|3
    3---4
    subgraph 8["Business"]
      direction TB
      9([Inventory department])
      class 9 PeoplePerspective
      10([Sales department])
      class 10 PeoplePerspective
      9---10
    end
    8---3
    8-->|owns|3
    3---8
    linkStyle 0,2,3,4,6,7,8,10 stroke:none
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in

  - [[*Business process*] Fulfillment](Fulfillment/Fulfillment.md)
  - [[*Business process*] Online ordering](Online ordering/Online ordering.md)
  - [[*Business process*] Payment](Payment/Payment.md)
  - [[*Business process*] Products delivery](Products delivery/Products delivery.md)
  - [[*Business process*] Wholesale ordering](Wholesale ordering/Wholesale ordering.md)

### Zoom-out

- [Business processes](../../Business_Processes.md)

### Change perspective

- [[*Business organizational unit*] Inventory department](../../BusinessOrganizationalUnits/Inventory department.md)
- [[*Business organizational unit*] Sales department](../../BusinessOrganizationalUnits/Sales department.md)
- [[*Deployable unit*] ecommerce-monolith](../../DeployableUnits/ecommerce-monolith.md)
- [[*Development team*] Core team](../../Teams/Core team.md)
- [[*Development team*] Supporting team](../../Teams/Supporting team.md)
- [[*Development team*] Inventory team](../../Teams/Inventory team.md)
- [[*Business process*] Products delivery](Products delivery/Products delivery.md)
- [[*Business process*] Payment](Payment/Payment.md)
- [[*Business process*] Online ordering](Online ordering/Online ordering.md)
- [[*Business process*] Fulfillment](Fulfillment/Fulfillment.md)
- [[*Business process*] Wholesale ordering](Wholesale ordering/Wholesale ordering.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)