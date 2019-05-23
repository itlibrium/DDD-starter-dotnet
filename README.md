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
Here you can find links to more elaborate descriptions of different sections of the project.

1. *Screaming architecture*
   1. [How to use .net projects to reflect architectural boundaries](./Projects-and-Namespaces.md)
   2. [How to use *namespaces* to reflect *Ubiquitous Language*](./Projects-and-Namespaces.md)
2. *Hexagonal Architecture* - *coming soon*
3. *DDD Building Blocks* - *coming soon*
4. Testing domain model - *coming soon*
5. Joining *DDD* and *CRUD* - *coming soon*
6. Persistence of *Aggregates* - *coming soon*
7. Emitting *Events* from *Aggregates* - *coming soon*
8. Publishing *Events* to the *Bus* - *coming soon*
9. Startup project - *coming soon*

Here are only things already implemented or planned for the near future. We are looking forward for your feedback so we can develop this project in the way that best fits your needs.

## License

The project is under [MIT license](https://opensource.org/licenses/MIT).