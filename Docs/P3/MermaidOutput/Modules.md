
# Domain Modules

This view shows domain model modularization.  
First level modules can be treated as separate sub-models or DDD Bounded Contexts.  
All modules can be divided into sub-modules to reflect hierarchical structure of the domain.  

---



## Modules hierarchy


## Contacts

```mermaid
  flowchart TB
    0(Contacts)
    class 0 DomainPerspective
    1(Companies)
    class 1 DomainPerspective
    0-->|contains|1
    2(Groups)
    class 2 DomainPerspective
    0-->|contains|2
    3(Tags)
    class 3 DomainPerspective
    0-->|contains|3
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Sales

```mermaid
  flowchart TB
    0(Sales)
    class 0 DomainPerspective
    1(Clients)
    class 1 DomainPerspective
    0-->|contains|1
    2(Commons)
    class 2 DomainPerspective
    0-->|contains|2
    3(ExchangeRates)
    class 3 DomainPerspective
    0-->|contains|3
    4(Integrations)
    class 4 DomainPerspective
    0-->|contains|4
    5(RiskManagement)
    class 5 DomainPerspective
    4-->|contains|5
    6(Orders)
    class 6 DomainPerspective
    0-->|contains|6
    7(PriceChanges)
    class 7 DomainPerspective
    6-->|contains|7
    8(Pricing)
    class 8 DomainPerspective
    0-->|contains|8
    9(Discounts)
    class 9 DomainPerspective
    8-->|contains|9
    10(PriceLists)
    class 10 DomainPerspective
    8-->|contains|10
    11(SpecialOffers)
    class 11 DomainPerspective
    8-->|contains|11
    12(Products)
    class 12 DomainPerspective
    0-->|contains|12
    13(SalesChannels)
    class 13 DomainPerspective
    0-->|contains|13
    14(Time)
    class 14 DomainPerspective
    0-->|contains|14
    classDef DomainPerspective stroke:#009900
    classDef TechnologyPerspective stroke:#1F41EB
    classDef PeoplePerspective stroke:#FFF014
```

## Next steps


### Zoom-in


#### Domain perspective


##### Domain modules

[Clients](Modules/Sales/Clients/Clients.md)  
[Commons](Modules/Sales/Commons/Commons.md)  
[Companies](Modules/Contacts/Companies/Companies.md)  
[Contacts](Modules/Contacts/Contacts.md)  
[Discounts](Modules/Sales/Pricing/Discounts/Discounts.md)  
[ExchangeRates](Modules/Sales/ExchangeRates/ExchangeRates.md)  
[Groups](Modules/Contacts/Groups/Groups.md)  
[Integrations](Modules/Sales/Integrations/Integrations.md)  
[Orders](Modules/Sales/Orders/Orders.md)  
[PriceChanges](Modules/Sales/Orders/PriceChanges/PriceChanges.md)  
[PriceLists](Modules/Sales/Pricing/PriceLists/PriceLists.md)  
[Pricing](Modules/Sales/Pricing/Pricing.md)  
[Products](Modules/Sales/Products/Products.md)  
[RiskManagement](Modules/Sales/Integrations/RiskManagement/RiskManagement.md)  
[Sales](Modules/Sales/Sales.md)  
[SalesChannels](Modules/Sales/SalesChannels/SalesChannels.md)  
[SpecialOffers](Modules/Sales/Pricing/SpecialOffers/SpecialOffers.md)  
[Tags](Modules/Contacts/Tags/Tags.md)  
[Time](Modules/Sales/Time/Time.md)  

### Zoom-out


#### Multi perspectives


##### Cross elements

[Main page](README.md)  

---

[P3 Model](https://github.com/P3-model/P3-model) documentation generated from source code using [.net tooling](https://github.com/P3-model/P3-model-dotnet)