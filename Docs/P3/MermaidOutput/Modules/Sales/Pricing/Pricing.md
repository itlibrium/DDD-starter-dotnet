
# [*Domain module*] Pricing

This view contains details information about Pricing domain module, including:
- other related modules
- related processes
- related building blocks
- related deployable units
- engaged people: actors, development teams, business stakeholders  

---



## Domain Perspective


### Related modules

```mermaid
  flowchart TB
    0(Pricing)
    class 0 DomainPerspective
    1([Sales])
    class 1 DomainPerspective
    0-->|is part of|1
    2([PriceLists])
    class 2 DomainPerspective
    0-->|contains|2
    3([Discounts])
    class 3 DomainPerspective
    0-->|contains|3
    4([SpecialOffers])
    class 4 DomainPerspective
    0-->|contains|4
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Related processes

```mermaid
  flowchart TB
    0(Pricing)
    class 0 DomainPerspective
    1([Wholesale ordering])
    class 1 DomainPerspective
    0-->|contains|1
    2([Online ordering])
    class 2 DomainPerspective
    0-->|contains|2
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

### Direct building blocks

```mermaid
  flowchart TB
    0(Pricing)
    class 0 DomainPerspective
    1([OfferModifier])
    class 1 DomainPerspective
    0-->|contains|1
    2([PriceModifier])
    class 2 DomainPerspective
    0-->|contains|2
    3([QuoteModifier])
    class 3 DomainPerspective
    0-->|contains|3
    4([Quote])
    class 4 DomainPerspective
    0-->|contains|4
    5([CalculatePrices])
    class 5 DomainPerspective
    0-->|contains|5
    6([PriceListSqlRepository])
    class 6 DomainPerspective
    0-->|contains|6
    7([OfferModifiers])
    class 7 DomainPerspective
    0-->|contains|7
    8([IndividualSalesConditions])
    class 8 DomainPerspective
    0-->|contains|8
    9([Offer])
    class 9 DomainPerspective
    0-->|contains|9
    10([OfferRequest])
    class 10 DomainPerspective
    0-->|contains|10
    11([OfferModifier2])
    class 11 DomainPerspective
    0-->|contains|11
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Technology Perspective


### Related deployable units

```mermaid
  flowchart TB
    0(Pricing)
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
  flowchart TB
    0(Pricing)
    class 0 DomainPerspective
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-out

- [Business processes](../../../Business_Processes.md)

### Change perspective

- [[*Deployable unit*] ecommerce-monolith](../../../DeployableUnits/ecommerce-monolith.md)
- [[*Domain building block*] CalculatePrices](../../../BuildingBlocks/Sales/Pricing/CalculatePrices.md)
- [[*Domain building block*] OfferModifier2](../../../BuildingBlocks/Sales/Pricing/OfferModifier2.md)
- [[*Domain building block*] OfferModifiers](../../../BuildingBlocks/Sales/Pricing/OfferModifiers.md)
- [[*Domain building block*] QuoteModifier](../../../BuildingBlocks/Sales/Pricing/QuoteModifier.md)
- [[*Domain building block*] PriceListSqlRepository](../../../BuildingBlocks/Sales/Pricing/PriceListSqlRepository.md)
- [[*Domain building block*] Quote](../../../BuildingBlocks/Sales/Pricing/Quote.md)
- [[*Domain building block*] OfferModifier](../../../BuildingBlocks/Sales/Pricing/OfferModifier.md)
- [[*Domain building block*] PriceModifier](../../../BuildingBlocks/Sales/Pricing/PriceModifier.md)
- [[*Domain building block*] Offer](../../../BuildingBlocks/Sales/Pricing/Offer.md)
- [[*Domain building block*] OfferRequest](../../../BuildingBlocks/Sales/Pricing/OfferRequest.md)
- [[*Domain building block*] IndividualSalesConditions](../../../BuildingBlocks/Sales/Pricing/IndividualSalesConditions.md)
- [[*Business process*] Wholesale ordering](../../../Processes/Sale/Wholesale ordering/Wholesale ordering.md)
- [[*Business process*] Online ordering](../../../Processes/Sale/Online ordering/Online ordering.md)

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)