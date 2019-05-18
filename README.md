# DDD starter for .net

## About

At the end of the day your model have to be implemented somehow. Here you can find a set of samples how it can be done in C#. Implementation certainly isn't the most important thing in *DDD* but is necessary to ship the solution in production.

### What *DDD starter* is?

It's a **place to learn** how to implement *DDD*, *CQRS*, *Event Sourcing*, *Hexagonal Architecture*, *BDD*, etc.

It's a **comparison of different implementations styles** that can be used to solve the same requirement.

It's a **set of ready made solutions** that you can adapt in your own projects.

### What *DDD starter* is not?

It's **not a complete study of some domain**. 

It's **not an ilustration of domain exploration** or **modeling process**.

It's **not a complete comparison** of all possible implementation styles.

### The goal

The main goal of this project is to show different implementation approaches and distill best practices in each of them. Which approach will be optimal in a particular case depends of course on the context.

### Our approach

#### Limiting the domain to a minimum

It is impractical to present the process of domain exploration and modeling as well as various approaches to implementation at once. That's why we decided to limit the domain to an absolute minimum so that we could present implementation techniques of particular patterns.

This limitation will mainly concern the number of domain concepts and to a lesser degree their complexity as this is necessary for meaningful use of the presented patterns.

Everyone interested in domain exploration techniques such as *Event Storming* or a complete implementation of some domain we refer to other projects for example: https://github.com/ddd-by-examples.

#### Simplicity

The code is read much more often than it is modified. The implementation should therefore primarily be optimized for readability. In addition, the code is usually read by someone other than its author, so it is worth to ensure that the learning curve is as flat as possible.

We will try to make all presented solutions as easy as possible. The different variants will of course vary in complexity. This will be an additional illustration of trade-offs between brevity and simplicity: what is gaining and what is lost by choosing more generic / automatic / magical solutions.

Simplicity, however, does not mean simplifications that we will try to avoid at all costs. Simplified solutions are usually not suitable for use in a real projects. They also require additional knowledge to distinguish what is essential from what is merely a simplification.

#### Minimum technical dependencies

Discussed patterns are not strictly related to any technology, therefore the project will not be written from the perspective of a specific set of technologies or cloud provider.

The only limitation is the choice of .net platform and C # language.

Chosen libraries and technologies are optimal choices from the perspective of the authors' experience. In other contexts other choices may be better.

All used libraries and technologies can be easily replaced with analogical solutions while maintaining the essence of the implemented patterns.

## Project development

This project is under development so we encourage you to follow:

1. This site - give us a Star
2. Our blog: https://itlibrium.com/tag/DDD-starter
3. Twitter: [ITLIBRIUM](https://twitter.com/itlibrium), [Marcin](https://twitter.com/technites_pl), [Szymon](https://twitter.com/szjanikowski)

## Table of contents

1. *Screaming architecture*
   1. [How to use .net projects to reflect architectural boundaries](./Projects.md)
   2. [How to use *namespaces* to reflect *Ubiquitous Language*](./Namespaces.md)
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