\# Architecture Analysis Reference



\## 1. Purpose and Scope



This reference defines a technology-independent approach for analyzing software architecture in existing repositories.



The analysis must identify the actual architecture implemented by the system, not the architecture that developers intended to implement.



This reference applies to:



\- .NET applications

\- Java and Spring applications

\- Web applications

\- Backend services

\- Desktop applications

\- Modular monoliths

\- Microservices

\- Distributed systems

\- Hybrid architectures

\- Other software technology stacks



The analysis must be evidence-based, read-only, and focused on the actual implementation.



Technology-specific details must be delegated to the relevant references:



\- `dotnet-analysis.md`

\- `java-analysis.md`

\- `sqlserver-analysis.md`

\- `oracle-analysis.md`

\- `api-analysis.md`

\- `security-analysis.md`

\- `performance-analysis.md`



Do not duplicate their detailed technical analysis.



\---



\## 2. Architecture Analysis Principles



Follow these principles throughout the analysis:



1\. Never determine architecture based only on folder or project names.

2\. Verify architectural responsibilities through source code, dependencies, configuration, and execution flow.

3\. Distinguish intended architecture from implemented architecture.

4\. Identify architectural violations explicitly.

5\. Do not assume that using interfaces means the project follows Clean Architecture.

6\. Do not assume that multiple projects mean the application is microservices-based.

7\. Do not assume that separate databases mean services are independent.

8\. Do not assume that a project uses Domain-Driven Design because it contains a Domain folder.

9\. Do not invent missing components, services, or dependencies.

10\. Mark unavailable architectural information as unknown.



For every important finding, provide:



\- Finding

\- Evidence

\- Affected component

\- Architectural impact

\- Severity

\- Confidence level

\- Recommended investigation or improvement



\### Evidence Classification



Use these labels:



\- Verified: directly confirmed by source code or configuration.

\- Inferred: supported by multiple observations but not directly confirmed.

\- Requires Developer Confirmation: depends on business or deployment knowledge.

\- Not Available: cannot be established from the available repository.



\### Confidence Levels



\- High

\- Medium

\- Low



\---



\## 3. Repository and System Context



Identify the overall system structure.



Inspect:



\- Repository structure

\- Solution or workspace files

\- Application entry points

\- Build configuration

\- Runtime configuration

\- Deployment configuration

\- Infrastructure definitions

\- Documentation

\- External service references



Determine:



1\. What is the primary application?

2\. What are its supporting applications?

3\. Which components are independently executable?

4\. Which components are libraries?

5\. Which components are shared?

6\. Which components are external dependencies?

7\. What are the system's apparent boundaries?



Do not assume every project in a repository belongs to the same runtime application.



\### Expected Output



Create a system context summary containing:



\- System name

\- Main applications

\- Supporting components

\- External systems

\- Main integration points

\- Unknown boundaries



\---



\## 4. Architecture Style Detection



Determine which architectural styles are actually implemented.



Consider the following patterns:



\### 4.1 Layered Architecture



Investigate:



\- Presentation Layer

\- Application Layer

\- Business Layer

\- Domain Layer

\- Infrastructure Layer

\- Data Access Layer



Determine whether responsibilities are separated and whether dependencies follow the intended direction.



\### 4.2 N-Tier Architecture



Identify:



\- Physical or logical tiers

\- Deployment boundaries

\- Communication between tiers

\- Database placement

\- Network boundaries



Distinguish logical layers from independently deployed tiers.



\### 4.3 Clean Architecture



Investigate:



\- Domain independence

\- Application use cases

\- Infrastructure implementations

\- Presentation responsibilities

\- Dependency inversion

\- Direction of project references



Do not classify a project as Clean Architecture merely because it contains projects named Domain, Application, Infrastructure, and Presentation.



\### 4.4 Onion Architecture



Investigate:



\- Core domain

\- Application services

\- Domain services

\- Infrastructure implementations

\- Dependency direction toward the core



\### 4.5 Hexagonal Architecture



Investigate:



\- Ports

\- Adapters

\- External interfaces

\- Persistence adapters

\- Messaging adapters

\- Inbound and outbound communication



\### 4.6 Modular Monolith



Investigate:



\- Module boundaries

\- Module responsibilities

\- Internal communication

\- Shared infrastructure

\- Shared database usage

\- Cross-module dependencies



Determine whether modules are genuinely isolated or only separated by folders.



\### 4.7 Microservices Architecture



Investigate:



\- Independently deployable services

\- Service ownership

\- Service-to-service communication

\- Data ownership

\- Independent configuration

\- Independent scaling

\- Failure isolation

\- Deployment boundaries



A repository containing multiple APIs does not automatically represent microservices.



\### 4.8 Event-Driven Architecture



Investigate:



\- Events

\- Event producers

\- Event consumers

\- Message brokers

\- Event contracts

\- Asynchronous communication

\- Event delivery guarantees



\### 4.9 CQRS



Investigate:



\- Command responsibilities

\- Query responsibilities

\- Separate read and write models

\- Command handlers

\- Query handlers

\- Consistency behavior



Do not classify ordinary service methods as CQRS without evidence of responsibility separation.



\### 4.10 Event Sourcing



Investigate:



\- Event store

\- Aggregate event streams

\- Event replay

\- State reconstruction

\- Event versioning



Do not confuse application logging or audit tables with Event Sourcing.



\### 4.11 Other Architecture Styles



Where relevant, investigate:



\- MVC

\- MVP

\- MVVM

\- SOA

\- Serverless

\- Client-Server

\- Distributed Monolith

\- Hybrid Architecture



\### Expected Output



Provide:



\- Primary architecture style

\- Secondary architectural patterns

\- Evidence supporting each classification

\- Implemented deviations

\- Confidence level



If the architecture is hybrid, describe the combination instead of forcing a single classification.



\---



\## 5. Runtime Topology and Deployment Units



Analyze how the system appears to execute and deploy.



Inspect available evidence:



\- Executable projects

\- Application entry points

\- Dockerfiles

\- Docker Compose files

\- Kubernetes manifests

\- Deployment scripts

\- CI/CD configuration

\- Reverse proxy configuration

\- Service definitions

\- Environment-specific configuration



Determine:



1\. How many independently executable applications exist?

2\. Which components run inside the same process?

3\. Which components are independently deployed?

4\. Which components communicate over a network?

5\. Which components share runtime resources?

6\. Which infrastructure dependencies are required?



Distinguish:



\- Logical components

\- Runtime processes

\- Deployment units

\- Containers

\- Physical infrastructure



Do not infer production topology from local development configuration alone.



If deployment files are missing, explicitly state that production topology cannot be fully verified.



\---



\## 6. Module and Component Inventory



Identify the main architectural components.



For each component, record:



\- Name

\- Type

\- Responsibility

\- Main interfaces

\- Dependencies

\- Consumers

\- Data ownership

\- Runtime role

\- Evidence



Possible component types:



\- Application

\- Module

\- Service

\- Controller

\- Handler

\- Repository

\- Domain Component

\- Infrastructure Adapter

\- Integration Component

\- Background Worker

\- Scheduled Job

\- Messaging Consumer

\- Shared Library



Determine whether each component has a clear and focused responsibility.



Identify:



\- Components with excessive responsibilities

\- Duplicate responsibilities

\- Unused components

\- Components with unclear ownership

\- Components that depend on implementation details of unrelated modules



\---



\## 7. Dependency Direction and Dependency Graph



Analyze dependencies between projects, modules, and components.



Inspect:



\- Project references

\- Package dependencies

\- Import statements

\- Constructor injection

\- Interface implementations

\- Service registrations

\- Cross-module calls

\- Shared libraries



Determine:



1\. Which components depend on which components?

2\. Are dependencies directed toward stable abstractions?

3\. Do high-level modules depend on low-level implementation details?

4\. Are there circular dependencies?

5\. Are there unnecessary dependencies?

6\. Are shared components becoming dependency bottlenecks?



\### Dependency Problems



Look for:



\- Circular dependencies

\- Bidirectional coupling

\- Excessive coupling

\- Hidden dependencies

\- Dependency leakage

\- Shared-kernel overuse

\- Direct database access across module boundaries

\- Infrastructure dependencies inside domain logic



\### Expected Output



Provide a dependency summary and, where evidence permits, a Mermaid dependency diagram.



Use this diagram format:



```mermaid

flowchart TD

&#x20;   A\[Presentation] --> B\[Application]

&#x20;   B --> C\[Domain]

&#x20;   D\[Infrastructure] --> B

```



The example is illustrative only.



Generate diagrams from actual repository evidence. Never copy the example as if it describes the analyzed project.



\---



\## 8. Layer Boundaries and Architectural Violations



Identify actual responsibility boundaries.



Check whether:



\- Presentation contains business rules.

\- Controllers directly implement complex business operations.

\- Domain logic depends on infrastructure.

\- Application services access external systems directly without appropriate abstraction.

\- Data Access contains business decisions.

\- Database-specific logic leaks into unrelated modules.

\- Shared libraries contain application-specific behavior.

\- Modules bypass each other's public interfaces.



For every violation, report:



\- Source component

\- Target component

\- Dependency or responsibility violation

\- Evidence

\- Impact

\- Severity

\- Suggested direction of improvement



Do not recommend introducing additional layers unless a concrete problem justifies them.



\---



\## 9. Request, Command, Query, Event, and Data Flows



Trace important execution paths.



Where applicable, investigate:



\### Request Flow



Follow a request through:



\- Client

\- API Gateway or Reverse Proxy

\- Middleware

\- Controller or Endpoint

\- Application Service

\- Domain Logic

\- Repository

\- Database

\- Response



\### Command Flow



Identify:



\- Command creation

\- Validation

\- Handler execution

\- Business operation

\- Persistence

\- Result handling



\### Query Flow



Identify:



\- Query creation

\- Query execution

\- Read model

\- Data retrieval

\- Mapping

\- Response



\### Event Flow



Identify:



\- Event creation

\- Publication

\- Broker or transport

\- Consumer

\- Processing

\- Persistence

\- Failure handling



\### Data Flow



Identify:



\- Data source

\- Transformations

\- Validation

\- Persistence

\- Data ownership

\- External data exchange



\### Expected Output



For important flows, provide:



\- Flow name

\- Entry point

\- Main components

\- Data or message exchanged

\- Exit point

\- Failure points

\- Evidence



Use Mermaid sequence diagrams when the actual execution path is sufficiently understood.



Do not assume a complete execution flow from class names alone.



\---



\## 10. Domain Model and Business Boundaries



Analyze domain boundaries only when the code provides sufficient evidence.



Investigate:



\- Business entities

\- Value Objects

\- Aggregates

\- Domain Services

\- Domain Events

\- Business invariants

\- Bounded Contexts

\- Ubiquitous Language

\- Domain ownership



Determine:



1\. Which modules represent distinct business capabilities?

2\. Which entities belong to which business areas?

3\. Are business rules concentrated in appropriate locations?

4\. Are domain models independent from persistence concerns?

5\. Are business boundaries reflected in technical boundaries?



Do not assume that every entity represents a Domain-Driven Design Aggregate.



Do not invent Bounded Contexts from database table names alone.



If business boundaries cannot be established from code, mark them as requiring developer confirmation.



\---



\## 11. Integration Architecture



Identify all meaningful integration points.



Consider:



\### Synchronous Integration



\- HTTP/REST

\- gRPC

\- SOAP

\- Direct library calls

\- Database access

\- External APIs



\### Asynchronous Integration



\- Message Brokers

\- Queues

\- Topics

\- Publish/Subscribe

\- Event Consumers

\- Background Processing



\### Other Integration Methods



\- File Exchange

\- Shared Storage

\- Database Links

\- Scheduled Data Transfer

\- External Identity Providers



For each integration, identify:



\- Source component

\- Target component

\- Protocol or mechanism

\- Data exchanged

\- Authentication mechanism, if visible

\- Timeout behavior, if visible

\- Error handling

\- Retry behavior

\- Evidence



Distinguish synchronous dependencies from asynchronous dependencies.



Identify integrations that introduce strong coupling or single points of failure.



\---



\## 12. Data Ownership and Transaction Boundaries



Analyze how data is owned and shared across components.



Investigate:



\- Database ownership

\- Schema ownership

\- Shared database usage

\- Shared tables

\- Database-per-service patterns

\- Cross-module queries

\- Cross-service transactions

\- Distributed transactions

\- Eventual consistency



Determine:



1\. Which component owns each important data set?

2\. Can multiple services modify the same tables?

3\. Are module boundaries enforced at the database level?

4\. Are transactions limited to a single application boundary?

5\. Are distributed consistency mechanisms required?

6\. Is data duplication intentional?



Do not claim database-per-service architecture unless the evidence supports independent data ownership.



Database-specific analysis must be delegated to the relevant database reference.



\---



\## 13. Cross-Cutting Architectural Concerns



Identify how cross-cutting concerns are implemented.



Consider:



\### Authentication and Authorization



\- Authentication boundaries

\- Identity propagation

\- Authorization responsibilities

\- Service-to-service identity



Detailed security analysis belongs to `security-analysis.md`.



\### Configuration



\- Configuration ownership

\- Environment-specific settings

\- Configuration distribution

\- Secret management boundaries



\### Logging and Error Handling



\- Centralized logging

\- Correlation identifiers

\- Exception boundaries

\- Error propagation

\- Consistent error contracts



\### Validation



\- Input validation

\- Business validation

\- Cross-module validation

\- Validation ownership



\### Caching



\- Cache placement

\- Cache ownership

\- Cache invalidation

\- Distributed caching



\### Other Concerns



\- Localization

\- Serialization

\- Scheduling

\- Background jobs

\- File storage

\- Audit logging



Determine whether cross-cutting concerns are consistently implemented or duplicated across modules.



\---



\## 14. Scalability and Availability Architecture



Evaluate architectural support for scalability and availability.



Investigate:



\- Stateless application components

\- Stateful services

\- Horizontal scaling

\- Vertical scaling assumptions

\- Shared session state

\- Distributed cache

\- Database bottlenecks

\- Load balancing

\- Replication

\- Read/write separation

\- Single points of failure

\- Deployment redundancy



Separate three categories:



1\. Verified capability: directly supported by implementation or deployment configuration.

2\. Potential capability: architecture appears compatible but is not verified in deployment.

3\. Limitation: implementation creates a known scalability or availability constraint.



Do not claim that a system is highly available or horizontally scalable without supporting evidence.



Detailed performance analysis belongs to `performance-analysis.md`.



\---



\## 15. Resilience and Fault Tolerance



Inspect architectural mechanisms for handling failures.



Consider:



\- Timeouts

\- Retries

\- Exponential Backoff

\- Circuit Breakers

\- Bulkheads

\- Fallback Strategies

\- Idempotency

\- Dead Letter Queues

\- Outbox Pattern

\- Inbox Pattern

\- Health Checks

\- Graceful Shutdown

\- Cancellation Propagation

\- Message Deduplication



For each mechanism, determine:



\- Whether it exists

\- Where it is implemented

\- Which failures it addresses

\- Whether it is consistently applied

\- Whether it introduces additional risks



Do not assume that retry logic automatically improves reliability.



Identify potential retry storms, duplicate processing, message loss, and inconsistent state.



\---



\## 16. Security Boundaries and Trust Zones



Analyze security from an architectural perspective.



Identify:



\- Public-facing components

\- Internal services

\- External systems

\- Trust boundaries

\- Network boundaries

\- Identity boundaries

\- Data access boundaries

\- Secret distribution mechanisms



Investigate:



\- Authentication propagation

\- Service-to-service authorization

\- Network exposure

\- Administrative interfaces

\- Internal API exposure

\- Sensitive data movement



Do not expose credentials or secret values in reports.



Detailed security review belongs to `security-analysis.md`.



\---



\## 17. Observability and Operations



Evaluate whether the architecture supports operational visibility.



Investigate:



\- Application logs

\- Centralized logging

\- Metrics

\- Distributed tracing

\- Correlation IDs

\- Health endpoints

\- Readiness checks

\- Liveness checks

\- Audit trails

\- Monitoring integrations

\- Alerting configuration



Determine whether operators can identify:



\- Which component failed

\- Where a request failed

\- Which dependency caused the failure

\- Whether the system is degraded

\- Whether background jobs are healthy



Distinguish implementation evidence from actual operational availability.



\---



\## 18. Architecture Documentation and Decision Records



Inspect existing architectural documentation.



Look for:



\- Architecture diagrams

\- System context diagrams

\- Container diagrams

\- Component diagrams

\- Sequence diagrams

\- Deployment diagrams

\- Architecture Decision Records (ADR)

\- Technical specifications

\- Integration documents

\- Operational documentation



Evaluate:



1\. Is the documented architecture consistent with the source code?

2\. Are major decisions documented?

3\. Are trade-offs explained?

4\. Are important constraints recorded?

5\. Are diagrams outdated?

6\. Are deployment and integration details missing?



Do not treat documentation as proof of implementation without verifying the source code.



\---



\## 19. Architecture Smells and Technical Debt



Look for architectural warning signs.



Examples:



\- Distributed Monolith

\- God Object

\- God Service

\- Anemic Domain Model

\- Fat Controllers

\- Circular Dependencies

\- Shared Database Coupling

\- Excessive Shared Libraries

\- Leaky Abstractions

\- Infrastructure Leakage

\- Cross-Module Database Access

\- Inconsistent Error Handling

\- Missing Integration Boundaries

\- Unclear Data Ownership

\- Excessive Synchronous Dependencies

\- Hidden Runtime Dependencies

\- Inconsistent Transaction Boundaries

\- Unnecessary Architectural Complexity

\- Premature Microservices Decomposition



For each finding, report:



\- Finding ID

\- Description

\- Evidence

\- Affected components

\- Root cause, if established

\- Business or technical impact

\- Severity

\- Confidence

\- Recommended next step



Do not classify a design choice as a defect merely because another architectural style exists.



Recommendations must consider the system's actual size, complexity, operational capacity, and business requirements.



\---



\## 20. Architecture Risk Prioritization



Use these priority levels:



\### P0 - Critical



Architectural issues that create an immediate and severe risk, such as:



\- Critical trust boundary failures

\- Severe data ownership violations

\- System-wide failure caused by a critical dependency

\- Architecture that makes essential business operations unreliable



\### P1 - High



Issues that significantly affect:



\- Maintainability

\- Reliability

\- Security boundaries

\- Deployment independence

\- Data consistency

\- System evolution



\### P2 - Medium



Issues that create measurable technical friction but do not currently threaten essential operations.



\### P3 - Low



Minor inconsistencies, documentation gaps, or opportunities for future improvement.



Do not assign severity without explaining the impact.



\---



\## 21. Read-Only Analysis Restrictions



This reference is for architectural inspection, not implementation.



Unless explicitly authorized by the user:



\- Do not modify source code.

\- Do not modify project configuration.

\- Do not change dependency versions.

\- Do not install packages.

\- Do not modify database schemas.

\- Do not run migrations.

\- Do not change deployment configuration.

\- Do not start, stop, or restart production services.

\- Do not access production infrastructure.

\- Do not execute load tests.

\- Do not perform penetration testing.

\- Do not change Git branches, commits, or history.

\- Do not trigger CI/CD pipelines.

\- Do not deploy applications.

\- Do not generate or modify architecture documentation without the required approval.



Static inspection of repository files is permitted within the available environment and permissions.



If runtime inspection, external infrastructure access, or database access is required, explain why and request permission before proceeding.



\---



\## 22. Expected Architecture Report



Produce a structured report in Persian.



Preserve technical identifiers, class names, project names, file paths, protocol names, and architectural terminology in English.



Use this structure:



\# گزارش تحلیل معماری پروژه



\## 1. خلاصه معماری



\- نوع معماری اصلی

\- الگوهای معماری مکمل

\- وضعیت کلی معماری

\- مهم‌ترین نقاط قوت

\- مهم‌ترین ریسک‌ها



\## 2. ساختار سیستم



\- Applications

\- Modules

\- Components

\- External Systems

\- Runtime Units



\## 3. معماری پیاده‌سازی‌شده



\- Architecture Style

\- Layer Responsibilities

\- Dependency Direction

\- Boundary Enforcement



\## 4. نمودارهای معماری



در صورت وجود شواهد کافی:



\- System Context Diagram

\- Component Diagram

\- Dependency Diagram

\- Request Flow Diagram

\- Integration Diagram



تمام نمودارها باید بر اساس شواهد واقعی Repository ساخته شوند.



\## 5. تحلیل وابستگی‌ها



\- Dependency Graph

\- Circular Dependencies

\- Coupling

\- Cohesion

\- Boundary Violations



\## 6. جریان‌های اصلی سیستم



\- Request Flow

\- Command Flow

\- Query Flow

\- Event Flow

\- Data Flow



\## 7. تحلیل یکپارچگی



\- Internal Integrations

\- External Integrations

\- Synchronous Communication

\- Asynchronous Communication



\## 8. مالکیت داده و تراکنش‌ها



\- Data Ownership

\- Shared Database

\- Transaction Boundaries

\- Consistency Model



\## 9. مقیاس‌پذیری و تاب‌آوری



\- Scalability

\- Availability

\- Resilience

\- Single Points of Failure



\## 10. Observability و عملیات



\- Logging

\- Metrics

\- Tracing

\- Health Checks

\- Monitoring



\## 11. نقاط قوت معماری



هر مورد همراه با شواهد.



\## 12. مشکلات و بدهی‌های معماری



برای هر مورد:



\- شناسه

\- شرح

\- شواهد

\- اثر

\- شدت

\- میزان اطمینان

\- پیشنهاد اصلاح



\## 13. اولویت‌بندی ریسک‌ها



به تفکیک P0، P1، P2 و P3.



\## 14. اطلاعات نیازمند تأیید توسعه‌دهنده



مواردی که از Repository قابل اثبات نیستند.



\## 15. پیشنهادهای بهبود



پیشنهادها باید مرحله‌ای، متناسب با اندازه و نیاز پروژه و دارای توجیه فنی باشند.



\---



\## 23. Final Quality Requirements



Before finalizing the architecture analysis, verify:



\- \[ ] Architecture classification is supported by evidence.

\- \[ ] Intended architecture is distinguished from implemented architecture.

\- \[ ] Logical layers are not confused with deployment tiers.

\- \[ ] Multiple projects are not automatically classified as microservices.

\- \[ ] Dependency directions have been investigated.

\- \[ ] Circular dependencies have been checked where possible.

\- \[ ] Important request and data flows have been traced.

\- \[ ] Integration boundaries have been identified.

\- \[ ] Data ownership has been investigated.

\- \[ ] Security boundaries have been considered.

\- \[ ] Scalability claims are evidence-based.

\- \[ ] Resilience mechanisms have been checked.

\- \[ ] Architectural risks have clear impact descriptions.

\- \[ ] Unknown information is explicitly identified.

\- \[ ] Diagrams represent actual repository evidence.

\- \[ ] No source code or configuration has been modified.

\- \[ ] The final report is written in Persian.



If evidence is insufficient, state the limitation instead of making assumptions.

