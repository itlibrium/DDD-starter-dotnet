# *DDD* starter for *.net*

## About

**This repository allows to quickly start a *DDD* oriented project in *C#*** selecting a combination of *DDD*-related technologies which is right for your needs. *Hexagonal Architecture*, *BDD*, *CQRS*, *Event Sourcing* - to not overengineer your project you often need only part of them. Here we show you **various implementation options** with **guidelines** which should help you make a smart choice and start coding.

### What *DDD starter* is?

It's a **place to learn** how to implement *DDD*, *CQRS*, *Event Sourcing*, *Hexagonal Architecture*, *BDD*, etc.

It's a **comparison of different implementations styles** that can be used to solve the same requirement.

It's a **set of ready made solutions** that you can adapt in your own projects.

### What *DDD starter* is not?

It's **not a complete study of some domain**. 

It's **not an ilustration of domain exploration** or **modeling process**.

It's **not a complete comparison** of all possible implementation styles.

### The goal

The main goal of this project is to show different implementation options for a *DDD* project and share some best practices for each of them. Which approach is the best and should be chosen? It all depends! ;) Depends on what? Probably on some drivers from the context you operate in. So we also give you here some tips about how the available options match different drivers. We hope it will allow you to quickly make a good choice and get some productivity boost.


### **IMPORTANT DISCLAIMER** 
**Remember that DDD is not about implementation!** It is *"just"* a lightweight technique of creating a model for your software using exactly the same language as your business. This model can be more or less complex depending on the business itself. **There is no point in using a pneumatic drill where a simple hammer will do the job** (even if the pneumatic drill is very shiny). **Do not even try to use all most advanced DDD technologies (like Event Sourcing) without a proper reflection**.

### Our approach

#### Limiting the domain to a minimum

It is impractical to present the process of domain exploration and modeling as well as various approaches to implementation at once. That's why we decided to limit the domain to an absolute minimum so that we could present implementation techniques of particular patterns.

This limitation will mainly concern the number of domain concepts and to a lesser degree their complexity as this is necessary for meaningful use of the presented patterns.

#### Simplicity

The code is read much more often than it is modified. The implementation should therefore primarily be optimized for readability. In addition, the code is usually read by someone other than its author, so it is worth to ensure that the learning curve is as flat as possible.

We will try to make all presented solutions as easy as possible. The different options will of course vary in complexity. This will be an additional illustration of trade-offs between brevity and simplicity: what is gaining and what is lost by choosing more generic / automatic / magical solutions.

Simplicity, however, does not mean simplifications that we will try to avoid at all costs. Simplified solutions are usually not suitable for use in a real projects. They also require additional knowledge to distinguish what is essential from what is merely a simplification.

#### Minimum technical dependencies

Discussed patterns are not strictly related to any technology, therefore the project will not be written from the perspective of a specific set of technologies or cloud provider.

The only limitation is the choice of .net platform and C # language.

Chosen libraries and technologies are optimal choices from the perspective of  authors' experience. All of them can be easily replaced with analogical solutions while maintaining the essence of the implemented patterns.

## Project development

This project is under development so we encourage you to follow:

1. This site - give us a Star
2. Our blog: https://itlibrium.com/tag/DDD-starter
3. Twitter: [ITLIBRIUM](https://twitter.com/itlibrium), [Marcin](https://twitter.com/technites_pl), [Szymon](https://twitter.com/szjanikowski)

## Table of contents

### Screaming architecture

To create this solution we used an architectural approach called *screaming architecture*. This means that the structure of the solution "screams" about the business domain and architectural choices. Bounded Contexts are mapped to solution folders, application architecture layers are in separate projects, namespaces hierarchy follows business divisions.

**Documentation:**

1. [Projects and namespaces conventions](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Projects-and-Namespaces.md)

**Blog:**

1. [How to use c# projects and *namespaces* in a DDD project](https://itlibrium.com/en/how-to-use-c-projects-and-namespaces-in-a-ddd-project/)

### Hexagonal Architecture

Hexagonal Architecture is used in a part of `Sales` Bounded Context.

This architecture style is best for Deep Model with high business complexity. It's a very rare situation when it's the best choice for the architecture of the whole system. When used for CRUD part of the system it only adds unnecessary, accidental complexity. That's why we used it only in a part of the system. The rest of `Sales` and whole `Contacts` Bounded Context is rather simple with only CRUD operations. For these parts simple single layer architecture was chosen.

**Code:**

1. [`Sales` Bounded Context](https://github.com/itlibrium/DDD-starter-dotnet/tree/master/Sources/Sales)

**Blog:**

1. [[PL] Architektura wspierająca podejście *Domain First*](https://itlibrium.com/architektura-wspierajaca-podejscie-domain-first/)

### DDD Building Blocks

#### Aggregate

**Code:**

1. Complex aggregate: [`Order`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/Order.cs)
2. Aggregate's private Value Object: [`PriceAgreement`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/Order.PriceAgreement.cs)
3. Aggregate's events: [`Order.Events`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/Order.Events.cs)
4. Aggregate's snapshot: [`Order.Snapshot`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/Order.Snapshot.cs)

**Blog:**

1. [[PL] Identyfikowanie obiektów domenowych](https://itlibrium.com/identyfikowanie-obiektow-domenowych/)

#### Value Object

**Code:**

1. Identifiers eg: [`OrderId`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/OrderId.cs), [`ProductId`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Products/ProductId.cs)
2. Simple quantities (often with operators facilitating calculations) eg: [`Amount`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Products/Amount.cs), [`ProductAmount`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Products/ProductAmount.cs), [`Money`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Commons/Money.cs)
3. Complex quantities (often used by Policies) eg: [`Offer`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/Offer.cs), [`Quote`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/Quote.cs)
4. Other domain concepts (often used for communication between other Building Blocks) eg: [`OfferRequest`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/OfferRequest.cs), [`BasePrice`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/PriceLists/BasePrice.cs)

**Blog:**

1. [[PL] Jak zaimplementować Vlue Object z DDD w C#](https://itlibrium.com/value-object-w-csharp/)

#### Policy

**Code:**

1. Calculations eg: [`OfferModifier`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/OfferModifier.cs), [`ClientLevelDiscount`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/Discounts/ClientLevelDiscounts.cs), [`SpecialOffer`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/SpecialOffers/SpecialOffer.cs)
2. Adjusting Aggregate's rules eg: [`PriceChangesPolicy`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/PriceChanges/PriceChangesPolicy.cs), [`AllowPriceChangesIfTotalPriceIsLower`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/PriceChanges/AllowPriceChangesIfTotalPriceIsLower.cs)

**Blog:**

1. [[PL] Jak zaimplementować Polityki z DDD w C#](https://itlibrium.com/polityki-z-ddd-w-csharp/)

#### Factory

**Code:**

1. Creating Aggregates and Value Object: factory methods on each type
2. Choosing Policy for given conditions: [`PriceChangesPolicies`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/PriceChanges/PriceChangesPolicies.cs), [`OfferModifiers`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/OfferModifiers.cs)

#### Domain Service

**Code:**

1. Domain sub-processes: [`CalculatePrices`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Pricing/CalculatePrices.cs)

### Emitting Events from Aggregates

**Code:**

1. List inside Aggregate: [`Order.NewEvents`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel/Orders/Order.Events.cs)

Alternatives that won't be implemented:

1. static event publisher - hard to test Aggregates
2. passing event publisher to aggregate
   1. through constructor - hard to restore Aggregates
   2. through method argument - technical language in business behaviors
3. returning events from Aggregate's methods - harder implementation if method can return not only single Event; Events have to be passed as arguments to Repository methods which in less intuitive than passing Aggregate itself

### Testing domain model

**Code:**

1. [Tests for `Money` Value Object](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.DeepModel.Tests/Commons/MoneyTests.cs)

**Tools:**

1. [BDD toolkit](https://github.com/itlibrium/BDD-toolkit-dotnet) - our another open source project

### Combining *DDD* and *CRUD*

Even in a single Bounded Context we often find parts with different complexity. Some part of the Bounded Context may require Deep Model and techniques like Hexagonal Architecture and DDD Building Blocks. At the same time, another part may need CRUD model where single or two-layered architecture (using frameworks and libraries as much as possible) is the best fit. 

Using completely separate styles - Hexagonal Architecture for the Deep part and single/two layered architecture for CRUD part - is possible only if there are no use cases where we need to operate on both models. It's only a mater of time when such a use case occurs. What then? Which architecture style should be used?

The solution we propose is to use flexible Hexagonal Architecture, but avoid usage of OOP and Tactical DDD patterns for the CRUD parts. Check out the Sales Bounded Context where we show it in action. You can also check the Contacts Bounded Context where we show sample CRUD model implementation which is kept as simple as possible.

**Code:**

1. CRUD Bounded Context with single layer architecture eg: [`Contacts`](https://github.com/itlibrium/DDD-starter-dotnet/tree/master/Sources/Contacts)
2. Bounded Context with Deep Model and CRUD Model eg: 
   1. Separation rules (Aggregate) and simple data (Anemic Entity / Data Structure) eg:  - [`OrderHeader`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Crud.Contracts/Orders/OrderHeader.cs)
   2. Saving both Deep Model and CRUD Model in Command Handler (single transaction) eg: , [`CreateOrderHandler`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.UseCases/Wholesale/CreateOrder/CreateOrderHandler.cs)
   3. Reading CRUD Model in Command Handler eg: , [`GetOfferHandler`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.UseCases/Wholesale/GetOffer/GetOfferHandler.cs), [`SalesCrudOperations`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Crud.Contracts/SalesCrudOperations.cs)
   4. Managing CRUD Model without Command Handler eg: [`WholesalesOrdersHeaderController`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.RestApi/Wholesales/WholesalesOrdersHeaderController.cs), [`WholesalesOrdersHeaderNotesController`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.RestApi/Wholesales/WholesalesOrdersHeaderNotesController.cs), [`SalesCrudOperations`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Crud.Contracts/SalesCrudOperations.cs)

### Persistence of Aggregates

Domain model can be persisted in a several ways using SQL and noSQL databases. Here we compare various approaches by providing an example implementation for each of them.

**Code:**

1. SQL
   1. Tables from snapshot: [`OrderSqlRepository.TablesFromSnapshot`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Adapters.Sql/Orders/OrderSqlRepository.TablesFromSnapshot.cs)
   2. Tables from events: [`OrderSqlRepository.TablesFromEvents`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Adapters.Sql/Orders/OrderSqlRepository.TablesFromEvents.cs)
   3. Document from snapshot: [`OrderSqlRepository.DocumentFromSnapshot`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Adapters.Sql/Orders/OrderSqlRepository.DocumentFromSnapshot.cs)
   4. Document from events: [`OrderSqlRepository.DocumentFromEvents`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Adapters.Sql/Orders/OrderSqlRepository.DocumentFromEvents.cs)
   5. Event Sourcing - coming soon
2. Transactions: [`TransactionDecorator`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Transactions/TransactionDecorator.cs)

**Blog:**

1. [[PL] 4 sposoby persystencji agregatow DDD](https://itlibrium.com/4-sposoby-persystencji-agregatow-ddd/)

### Publishing Events

**Code:**

1. In a single transaction with domain model using *Outbox Pattern*
   1. Base abstractions: [`TransactionalOutbox`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Messages/TransactionalOutbox.cs), [`TransactionalOutboxes`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Messages/TransactionalOutboxes.cs)
   2. Integration with Use Case lifetime: [`TransactionalMessageSendingDecorator`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Messages/TransactionalMessageSendingDecorator.cs)
   3. Particular Outbox as a Port in Use Cases layer: [`OrderEventsOutbox`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.UseCases/OrderEventsOutbox.cs)
   4. Publishing Outbox to Event Broker: coming soon
   5. Kafka:
      1. Base abstractions [`KafkaTransactionalOutbox`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.Kafka.Outbox/KafkaTransactionalOutbox.cs), [`KafkaOutboxWriter`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.Kafka.Outbox/KafkaOutboxWriter.cs)
      2. Adapters: [`KafkaOrderEventsOutbox`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.Adapters.Kafka/Orders/KafkaOrderEventsOutbox.cs)
2. Post Commit
   1. Base abstractions: [`NonTransactionalOutbox`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Messages/NonTransactionalOutbox.cs), [`NonTransactionalOutboxes`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Messages/NonTransactionalOutboxes.cs)
   2. Integration with *Use Case* lifetime: [`NonTransactionalMessageSendingDecorator`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.UseCases/Messages/NonTransactionalMessageSendingDecorator.cs)
   3. Particular Outbox as a Port in Use Cases layer: coming soon
   4. Kafka:
      1. Base abstractions [`KafkaNonTransactionalOutbox`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/TechnicalStuff/TechnicalStuff.Kafka.Outbox/KafkaNonTransactionalOutbox.cs)
      2. Adapters: coming soon
3. Pre Commit - In our  opinion it's not very useful approach in real world scenarios.

### Testing integration with infrastructure

**Code:**

1. Integration tests for DDD Repository and SQL database: [`OrderSqlRepositoryTests`](https://github.com/itlibrium/DDD-starter-dotnet/blob/master/Sources/Sales/Sales.IntegrationTests/Orders/OrderSqlRepositoryTests.cs)

### Startup

We prefer to put all the startup code in a separate project. This project *know* about everything but *does* only initialization including:

- parsing and merging configuration
- registering all components in dependency injection container
- composing framework components like `middlewares`

In our opinion it's a better approach compared to putting startup code into the project with API code. It's especially useful in a modular monolith because each of the modules can have its own, separate API and use its own set of dependencies.

**Code:**

1. [Startup project](https://github.com/itlibrium/DDD-starter-dotnet/tree/master/Sources/Startup)

### What's next?

If you thought of something we can implement in this repo to make it even more useful for your projects let us know! We are looking forward for your feedback and ideas for new example implementations. 

Good luck with implementing DDD in your projects!

## License

The project is under [MIT license](https://opensource.org/licenses/MIT).