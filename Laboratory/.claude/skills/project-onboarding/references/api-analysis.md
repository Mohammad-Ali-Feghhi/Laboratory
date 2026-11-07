\# API Analysis Reference



\## 1. Purpose and Scope



This reference defines a technology-independent methodology for analyzing APIs in existing software repositories.



The objective is to understand the actual API implementation, evaluate its design quality, identify contract inconsistencies, and detect integration risks.



This reference applies to:



\- REST APIs

\- HTTP APIs

\- ASP.NET Core Web API

\- Spring Boot REST API

\- SOAP Services

\- gRPC Services

\- GraphQL APIs

\- Internal APIs

\- External API Integrations

\- Webhooks

\- API Gateways



The analysis must be based on repository evidence.



Technology-specific implementation details must be delegated to:



\- `dotnet-analysis.md`

\- `java-analysis.md`

\- `architecture-analysis.md`

\- `security-analysis.md`

\- `performance-analysis.md`



Do not duplicate their detailed analysis.



\---



\## 2. API Discovery and Inventory



Identify all API-related components.



Inspect:



\- Controllers

\- Endpoints

\- Route definitions

\- Request handlers

\- API interfaces

\- DTOs

\- Request models

\- Response models

\- API configuration

\- API documentation

\- OpenAPI specifications

\- Swagger configuration

\- API Gateway configuration

\- External service clients

\- Webhook handlers

\- SOAP contracts

\- gRPC service definitions

\- GraphQL schemas



Determine:



1\. How many APIs exist?

2\. Which applications expose APIs?

3\. Which APIs are public?

4\. Which APIs are internal?

5\. Which APIs consume external services?

6\. Which API technologies and protocols are used?

7\. Are there multiple API versions?

8\. Are there undocumented endpoints?



Do not assume that every Controller or Service is an externally accessible API.



\### Expected Output



Create an API inventory containing:



\- API name

\- Application or service

\- Protocol

\- Endpoint count, when determinable

\- Exposure type

\- Authentication requirement, when visible

\- API version

\- Documentation status



\---



\## 3. API Protocol and Style Detection



Identify the actual communication style.



\### 3.1 REST



Investigate:



\- Resource-oriented URLs

\- HTTP methods

\- Resource representations

\- HTTP status codes

\- Stateless communication

\- Resource relationships

\- Consistent endpoint naming



Determine whether the implementation follows REST principles or merely exposes HTTP endpoints.



Do not automatically classify every JSON-based HTTP API as fully RESTful.



\### 3.2 HTTP APIs



Investigate:



\- Request and response formats

\- HTTP methods

\- Headers

\- Status codes

\- Content negotiation

\- Authentication headers

\- Caching headers



\### 3.3 SOAP



Investigate:



\- WSDL contracts

\- XML schemas

\- SOAP actions

\- Message structure

\- Fault handling

\- WS-Security, if present



\### 3.4 gRPC



Investigate:



\- Protocol Buffer definitions

\- Service contracts

\- Unary calls

\- Server streaming

\- Client streaming

\- Bidirectional streaming

\- Error status handling



\### 3.5 GraphQL



Investigate:



\- Schema definitions

\- Queries

\- Mutations

\- Subscriptions

\- Resolvers

\- Authorization boundaries

\- Query complexity controls



\### 3.6 Webhooks



Investigate:



\- Event definitions

\- Callback endpoints

\- Signature verification

\- Retry behavior

\- Delivery guarantees

\- Idempotency

\- Event versioning



\### Expected Output



Report the API styles actually found and the evidence supporting each classification.



\---



\## 4. Endpoint and Route Analysis



Build a complete endpoint inventory where possible.



For each endpoint, identify:



\- HTTP method

\- Route

\- Controller or handler

\- Action or method name

\- Input parameters

\- Request DTO

\- Response DTO

\- Authentication requirement

\- Authorization requirement

\- Main business operation

\- Data access dependencies

\- Expected status codes



Investigate:



\### HTTP Methods



Check whether methods are used consistently:



\- GET

\- POST

\- PUT

\- PATCH

\- DELETE

\- OPTIONS

\- HEAD



Identify cases where HTTP methods do not match the operation's semantics.



Examples:



\- GET endpoints modifying data

\- DELETE endpoints performing unrelated operations

\- POST used for operations that should be idempotent without justification

\- PUT and PATCH used inconsistently



\### Route Design



Investigate:



\- Resource naming

\- Naming consistency

\- Nested resources

\- Route parameters

\- Query parameters

\- Route constraints

\- Version prefixes

\- Duplicate routes

\- Ambiguous routes



Avoid assuming a route is incorrect solely because another naming convention is preferred.



\---



\## 5. API Contract Analysis



Analyze the contract between API providers and consumers.



Inspect:



\- Request schemas

\- Response schemas

\- DTO definitions

\- Required fields

\- Optional fields

\- Data types

\- Nullability

\- Enum values

\- Date and time formats

\- Numeric precision

\- Serialization behavior

\- Naming conventions



Determine:



1\. Are request and response contracts consistent?

2\. Are DTOs separated from internal database entities?

3\. Are sensitive internal fields exposed?

4\. Are nullable fields handled consistently?

5\. Are data formats predictable?

6\. Are enum values stable?

7\. Are contracts documented?



Identify potential contract-breaking changes.



\### Entity Exposure



Investigate whether database entities are returned directly from API endpoints.



Potential risks include:



\- Internal fields being exposed

\- Sensitive properties leaking

\- Uncontrolled response changes when database entities change

\- Serialization cycles

\- Tight coupling between API and database models



Do not classify direct entity exposure as automatically critical. Explain the actual risk and impact.



\---



\## 6. Request and Response Design



Evaluate request and response consistency.



\### Request Design



Investigate:



\- Request DTOs

\- Query parameters

\- Route parameters

\- Request headers

\- Request body structure

\- Content-Type handling

\- Input validation

\- Optional parameters

\- Default values



\### Response Design



Investigate:



\- Response DTOs

\- Consistent response structure

\- Success responses

\- Error responses

\- Metadata

\- Pagination information

\- Correlation identifiers

\- Null handling



Determine whether API responses are predictable across endpoints.



Identify inconsistent response structures and unexplained differences.



\---



\## 7. HTTP Status Code Analysis



Check whether HTTP status codes correctly represent operation results.



Consider:



\### Success



\- 200 OK

\- 201 Created

\- 202 Accepted

\- 204 No Content



\### Client Errors



\- 400 Bad Request

\- 401 Unauthorized

\- 403 Forbidden

\- 404 Not Found

\- 405 Method Not Allowed

\- 409 Conflict

\- 410 Gone

\- 413 Content Too Large

\- 415 Unsupported Media Type

\- 422 Unprocessable Content

\- 429 Too Many Requests



\### Server Errors



\- 500 Internal Server Error

\- 501 Not Implemented

\- 502 Bad Gateway

\- 503 Service Unavailable

\- 504 Gateway Timeout



Investigate:



\- Whether successful creation returns an appropriate status.

\- Whether missing resources return 404.

\- Whether authentication failures return 401.

\- Whether authorization failures return 403.

\- Whether validation errors are represented consistently.

\- Whether unexpected server exceptions are hidden from clients.



Do not require every status code to be implemented. Evaluate only relevant scenarios.



\---



\## 8. Validation and Input Handling



Analyze how API inputs are validated.



Inspect:



\- Required field validation

\- Length restrictions

\- Numeric ranges

\- Format validation

\- Enum validation

\- Business validation

\- Cross-field validation

\- Nested object validation

\- Collection validation

\- File upload validation



Determine:



1\. Is validation performed before business processing?

2\. Are validation rules consistent?

3\. Are business rules incorrectly implemented only at the API layer?

4\. Can invalid data reach the persistence layer?

5\. Are validation messages useful and safe?



Distinguish:



\- Structural validation

\- Business validation

\- Authorization checks



Detailed security analysis belongs to `security-analysis.md`.



\---



\## 9. Error Handling and Error Contracts



Analyze API error handling.



Inspect:



\- Global exception handlers

\- Middleware

\- Filters

\- Controller-level try/catch blocks

\- Framework exception handling

\- Error response models

\- Validation error responses

\- Logging behavior



Investigate:



\- Whether error responses are consistent.

\- Whether internal stack traces are exposed.

\- Whether sensitive information appears in error messages.

\- Whether exceptions are swallowed.

\- Whether incorrect success responses are returned after failures.

\- Whether error details are useful for debugging without exposing internals.



\### Problem Details



Where applicable, inspect support for:



\- RFC 9457 Problem Details

\- Standardized error codes

\- Error correlation identifiers

\- Validation error collections



Do not require Problem Details if another consistent and well-designed error contract is used.



\---



\## 10. Authentication and Authorization Integration



Analyze how API endpoints enforce access control.



Investigate:



\- Authentication mechanisms

\- JWT Bearer authentication

\- Cookie authentication

\- OAuth 2.0

\- OpenID Connect

\- API keys

\- Basic authentication

\- Mutual TLS

\- Role-based authorization

\- Policy-based authorization

\- Resource-based authorization

\- Endpoint-level access restrictions



Determine:



1\. Which endpoints require authentication?

2\. Which endpoints are anonymous?

3\. Are authorization rules applied consistently?

4\. Are administrative operations protected?

5\. Are resource ownership checks present where required?

6\. Are internal APIs exposed unintentionally?



Never expose credentials, tokens, signing keys, or secret values.



Detailed analysis belongs to `security-analysis.md`.



\---



\## 11. Pagination, Filtering, Sorting, and Search



Analyze endpoints that return collections.



Investigate:



\### Pagination



\- Page number

\- Page size

\- Offset

\- Limit

\- Cursor-based pagination

\- Default page size

\- Maximum page size

\- Total count

\- Next-page information



\### Filtering



\- Filter parameters

\- Filter combinations

\- Allowed filter fields

\- Validation of filter values



\### Sorting



\- Sort fields

\- Sort direction

\- Default sorting

\- Allowed sort fields

\- Stable sorting



\### Search



\- Search parameters

\- Search semantics

\- Case sensitivity

\- Search scope

\- Query complexity



Identify:



\- Unbounded collection responses

\- Missing page-size limits

\- Unstable pagination

\- Unsafe dynamic sorting

\- Inconsistent filtering behavior



Do not assume an endpoint needs pagination if the collection is naturally small and bounded.



\---



\## 12. Idempotency and Concurrency



Analyze how APIs handle repeated requests and concurrent operations.



Investigate:



\- Idempotent HTTP methods

\- Idempotency keys

\- Duplicate request prevention

\- Request deduplication

\- Optimistic concurrency

\- ETags

\- If-Match headers

\- Version fields

\- Conflict responses

\- Race conditions



Determine whether retrying a request can create duplicate business operations.



Pay particular attention to:



\- Payments

\- Orders

\- Registration

\- External integrations

\- Background job submission

\- State-changing operations



Do not assume a POST request is safely retryable without evidence.



\---



\## 13. API Versioning and Compatibility



Inspect:



\- URL-based versioning

\- Header-based versioning

\- Query parameter versioning

\- Media type versioning

\- Versioned DTOs

\- Versioned schemas

\- Deprecation policies

\- Compatibility handling



Determine:



1\. Is versioning implemented?

2\. Are multiple versions active?

3\. Are breaking changes controlled?

4\. Are deprecated endpoints documented?

5\. Are old clients likely to remain compatible?



Do not require versioning for every small internal API.



Evaluate versioning according to actual consumer requirements.



\---



\## 14. API Documentation and OpenAPI



Inspect:



\- Swagger

\- OpenAPI

\- WSDL

\- Protobuf

\- GraphQL Schema

\- API reference documents

\- Postman collections

\- Example requests and responses



Evaluate:



\- Endpoint coverage

\- Schema accuracy

\- Authentication documentation

\- Error response documentation

\- Required and optional parameters

\- Example payloads

\- API version information

\- Documentation consistency with implementation



Identify undocumented or outdated endpoints.



Do not assume generated documentation is accurate without comparing it with the implementation.



\---



\## 15. External API Consumption



Analyze outgoing API integrations.



Inspect:



\- HTTP clients

\- SDKs

\- Service clients

\- Base URLs

\- Request construction

\- Response parsing

\- Authentication configuration

\- Timeout configuration

\- Retry policies

\- Error handling



For each external integration, identify:



\- Provider

\- Consumer component

\- Purpose

\- Protocol

\- Authentication method, if visible

\- Timeout behavior

\- Retry behavior

\- Error handling

\- Data exchanged

\- Dependency criticality



Never expose API keys, tokens, passwords, or private endpoints containing sensitive information.



Do not execute external requests unless explicitly authorized.



\---



\## 16. File Upload and Download Endpoints



Where applicable, inspect:



\### Upload



\- Allowed file types

\- Maximum file size

\- Content-Type validation

\- File naming

\- Storage destination

\- File metadata

\- Validation

\- Authorization

\- Duplicate handling



\### Download



\- Authorization

\- Resource ownership

\- Content-Disposition

\- Content-Type

\- Streaming

\- Range requests

\- File access restrictions



Detailed security risks belong to `security-analysis.md`.



\---



\## 17. API Performance and Reliability



Identify API-level performance and reliability risks.



Investigate:



\- Synchronous blocking operations

\- Excessive database calls

\- N+1 query patterns

\- Large response payloads

\- Missing pagination

\- Expensive serialization

\- Unnecessary external calls

\- Missing cancellation propagation

\- Timeout configuration

\- Retry behavior

\- Rate limiting

\- Caching



Distinguish static code findings from measured runtime performance.



Do not claim an endpoint is slow without profiling or measurable evidence.



Detailed performance analysis belongs to `performance-analysis.md`.



\---



\## 18. API Security Risks



At the API boundary, identify potential risks such as:



\- Broken Object Level Authorization (BOLA)

\- Broken Function Level Authorization (BFLA)

\- Missing authentication

\- Excessive data exposure

\- Mass assignment

\- Unsafe deserialization

\- Injection risks

\- Weak input validation

\- Unrestricted resource consumption

\- Missing rate limiting

\- CORS misconfiguration

\- Information disclosure



Use OWASP API Security Top 10 as a review reference where applicable.



Do not perform penetration testing or send malicious requests without explicit permission.



Detailed security analysis belongs to `security-analysis.md`.



\---



\## 19. API Design and Maintenance Issues



Look for:



\- Inconsistent endpoint naming

\- Duplicate endpoints

\- Fat Controllers

\- Business logic inside Controllers

\- Inconsistent DTO conventions

\- Direct database entity exposure

\- Inconsistent status codes

\- Inconsistent error contracts

\- Unbounded collection endpoints

\- Missing API documentation

\- Excessive coupling to internal implementation

\- Unclear endpoint ownership

\- Unnecessary API complexity



For every finding, provide:



\- Finding ID

\- Description

\- Evidence

\- Affected endpoint or component

\- Technical impact

\- Business impact, if established

\- Severity

\- Confidence

\- Recommended improvement



Do not recommend redesigning an API solely to follow a preferred style.



\---



\## 20. Risk Prioritization



Use these priorities:



\### P0 - Critical



Issues that create immediate and severe risk, such as:



\- Critical unauthorized access to sensitive operations

\- Severe data exposure

\- Critical API functionality that can be abused to compromise the system



\### P1 - High



Issues with significant effects on:



\- Authorization

\- Data integrity

\- API reliability

\- Contract compatibility

\- Critical integrations



\### P2 - Medium



Issues that create measurable maintainability, performance, or consistency problems.



\### P3 - Low



Minor design inconsistencies, documentation gaps, and improvement opportunities.



For every priority, explain the actual impact and evidence.



\---



\## 21. Read-Only Analysis Restrictions



This reference is for API inspection only.



Unless explicitly authorized:



\- Do not modify source code.

\- Do not change API contracts.

\- Do not modify routes.

\- Do not change authentication configuration.

\- Do not install packages.

\- Do not generate migrations.

\- Do not modify database schemas.

\- Do not send requests to production APIs.

\- Do not execute external API calls.

\- Do not perform penetration testing.

\- Do not run load or stress tests.

\- Do not modify API documentation files.

\- Do not change Git branches, commits, or history.

\- Do not trigger CI/CD pipelines.

\- Do not deploy applications.



Static inspection of source code and existing API specifications is permitted within available permissions.



If runtime verification is necessary, explain what needs to be tested and request permission.



\---



\## 22. Expected API Analysis Report



Produce the final report in Persian.



Preserve technical identifiers, route names, HTTP methods, DTO names, class names, file paths, protocols, and standards in English.



Use this structure:



\# گزارش تحلیل API پروژه



\## 1. خلاصه وضعیت API



\- تعداد APIها

\- پروتکل‌های مورد استفاده

\- وضعیت طراحی

\- مهم‌ترین نقاط قوت

\- مهم‌ترین ریسک‌ها



\## 2. فهرست APIها



برای هر API:



\- نام

\- سرویس یا پروژه

\- نوع ارتباط

\- نوع دسترسی

\- نسخه

\- وضعیت مستندات



\## 3. فهرست Endpointها



برای هر Endpoint:



\- HTTP Method

\- Route

\- Controller یا Handler

\- Request DTO

\- Response DTO

\- Authentication

\- Authorization

\- عملیات اصلی



\## 4. تحلیل طراحی API



\- Route Design

\- HTTP Methods

\- REST Principles

\- Request/Response Contracts

\- DTO Design



\## 5. اعتبارسنجی و مدیریت خطا



\- Input Validation

\- Business Validation

\- HTTP Status Codes

\- Exception Handling

\- Error Contracts



\## 6. امنیت API



\- Authentication

\- Authorization

\- Access Control

\- Input Risks

\- Data Exposure



\## 7. Pagination و Search



\- Pagination

\- Filtering

\- Sorting

\- Search

\- Collection Limits



\## 8. Versioning و Compatibility



\- API Versions

\- Breaking Changes

\- Deprecation

\- Backward Compatibility



\## 9. مستندسازی API



\- Swagger/OpenAPI

\- Endpoint Coverage

\- Contract Accuracy

\- Documentation Gaps



\## 10. یکپارچگی‌های خارجی



\- External Providers

\- HTTP Clients

\- Authentication

\- Timeout

\- Retry

\- Failure Handling



\## 11. عملکرد و قابلیت اطمینان



\- Performance Risks

\- Reliability Risks

\- Idempotency

\- Concurrency

\- Rate Limiting



\## 12. مشکلات و بدهی‌های API



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



\## 14. موارد نیازمند تأیید توسعه‌دهنده



مواردی که از Repository قابل اثبات نیستند.



\## 15. پیشنهادهای بهبود



پیشنهادها باید اولویت‌بندی‌شده، قابل اجرا و متناسب با نیاز واقعی پروژه باشند.



\---



\## 23. Final Quality Checklist



Before finalizing the analysis, verify:



\- \[ ] All discoverable API entry points have been investigated.

\- \[ ] API protocols and styles are classified based on evidence.

\- \[ ] Endpoint inventory is as complete as repository evidence allows.

\- \[ ] HTTP methods and status codes have been reviewed.

\- \[ ] Request and response contracts have been examined.

\- \[ ] DTO and entity exposure risks have been considered.

\- \[ ] Validation and error handling have been reviewed.

\- \[ ] Authentication and authorization boundaries have been examined.

\- \[ ] Pagination and collection limits have been checked.

\- \[ ] Idempotency and concurrency risks have been considered.

\- \[ ] Versioning and compatibility have been investigated.

\- \[ ] API documentation has been compared with implementation.

\- \[ ] External integrations have been identified.

\- \[ ] Performance claims are supported by evidence.

\- \[ ] Security findings are clearly separated from unverified assumptions.

\- \[ ] Risks have clear severity and impact.

\- \[ ] Unknown information is explicitly identified.

\- \[ ] No source code or configuration has been modified.

\- \[ ] The final report is written in Persian.



If evidence is insufficient, state the limitation instead of making assumptions.

