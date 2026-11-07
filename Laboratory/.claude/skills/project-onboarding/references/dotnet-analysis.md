
# .NET Project Analysis Reference

## 1. Purpose

This reference defines the analysis procedure for software projects built with the .NET ecosystem.

It applies to:

- .NET Framework
- .NET Core
- Modern .NET (.NET 5+)
- C#
- ASP.NET Core
- ASP.NET MVC
- ASP.NET Web API
- Entity Framework
- Entity Framework Core
- ADO.NET
- WCF
- Windows Forms
- WPF
- Blazor
- .NET Worker Services
- Console Applications
- Class Libraries

The purpose is to understand the actual implementation, architecture, dependencies, data access patterns, and technical risks of a .NET repository.

This reference is for analysis and documentation. It does not authorize source-code modifications.

---

## 2. Technology and Version Detection

Inspect the repository to identify the actual .NET technologies and versions.

### 2.1 Project Files

Inspect relevant files:

- `*.sln`
- `*.csproj`
- `*.vbproj`
- `global.json`
- `Directory.Build.props`
- `Directory.Build.targets`
- `Directory.Packages.props`
- `packages.config`
- `NuGet.config`
- `app.config`
- `web.config`
- `appsettings.json`
- `appsettings.*.json`

### 2.2 Target Framework

Identify the target framework from project configuration.

Examples:

```xml
<TargetFramework>net8.0</TargetFramework>
```

```xml
<TargetFrameworks>net8.0;net9.0</TargetFrameworks>
```

```xml
<TargetFramework>net48</TargetFramework>
```

Record:

- Target framework.
- Framework version.
- Whether the project targets one or multiple frameworks.
- SDK version requirements.
- Whether the installed or configured SDK is compatible, if this can be verified without changing the environment.

Do not infer the target framework only from the installed .NET SDK.

### 2.3 Language Version

Inspect:

- `<LangVersion>`
- `<Nullable>`
- `<ImplicitUsings>`

If `LangVersion` is not explicitly defined, identify the likely default from the target framework and SDK. Mark it as inferred rather than confirmed.

### 2.4 Project Type

Classify each project:

- Web Application
- Web API
- MVC Application
- Razor Pages
- Class Library
- Console Application
- Worker Service
- Windows Forms
- WPF
- Test Project
- Other

Do not classify a project solely from its directory name.

---

## 3. Solution and Project Structure

Inspect the solution and all relevant project files.

Create an inventory containing:

| Project | Project Type | Target Framework | Main Responsibility |
|---|---|---|---|

Identify:

- Entry-point projects.
- Business or domain projects.
- Data-access projects.
- Shared libraries.
- API projects.
- UI projects.
- Test projects.
- Infrastructure projects.
- External integration projects.

### 3.1 Project References

Inspect `<ProjectReference>` entries.

Determine:

- Which projects depend on other projects.
- Whether dependency directions are consistent.
- Whether circular project dependencies exist.
- Whether UI projects directly access infrastructure or database implementations.
- Whether domain or business logic projects depend on presentation-layer concerns.

Do not assume that a project named `Domain` or `Core` follows Clean Architecture.

Verify its actual dependencies and responsibilities.

### 3.2 Folder Structure

Inspect important directories and classify their responsibilities.

Possible examples:

- Controllers
- Models
- DTOs
- Entities
- Services
- Interfaces
- Repositories
- Data
- Context
- Configurations
- Middleware
- Filters
- Validators
- Mappings
- Helpers
- Extensions
- Migrations
- Tests

Only report directories and components that actually exist.

---

## 4. Application Architecture

Identify the architecture implemented by the code, not the architecture suggested by project names.

Possible architectural styles:

- Monolithic Architecture
- Layered Architecture
- N-Tier Architecture
- Clean Architecture
- Onion Architecture
- Hexagonal Architecture
- Modular Monolith
- Microservices
- MVC
- Minimal API
- Hybrid Architecture

For each identified layer, document:

1. Its responsibility.
2. Its main classes.
3. Its dependencies.
4. How it communicates with other layers.
5. Whether its responsibilities are clearly separated.

### 4.1 Common Layer Responsibilities

Check whether the following responsibilities are separated:

**Presentation Layer**
- HTTP endpoints.
- Controllers.
- Razor Pages.
- UI.
- Request and response handling.

**Application Layer**
- Use cases.
- Application services.
- Commands and queries.
- DTO orchestration.
- Application-level validation.

**Domain Layer**
- Business entities.
- Value objects.
- Domain rules.
- Domain services.
- Domain events.

**Infrastructure Layer**
- Database access.
- External services.
- File storage.
- Email and messaging providers.
- Third-party integrations.

These are reference responsibilities, not mandatory layers. Do not report a missing layer as a defect unless the project requirements or actual complexity justify it.

### 4.2 Architecture Findings

Identify:

- Responsibilities mixed in a single class.
- Business rules inside controllers or UI forms.
- Direct database access from presentation components.
- Excessive coupling.
- Unnecessary abstractions.
- Circular dependencies.
- Duplicate implementations.
- Inconsistent patterns.

For every finding, provide file paths and class or method names where possible.

---

## 5. ASP.NET Core Analysis

For ASP.NET Core projects, inspect the application startup and request pipeline.

### 5.1 Startup and Hosting

Inspect:

- `Program.cs`
- `Startup.cs`, if present.
- Hosting configuration.
- Environment-specific configuration.

Determine:

- Application entry point.
- Service registration location.
- Middleware configuration.
- Endpoint mapping.
- Environment-dependent behavior.

### 5.2 Dependency Injection

Inspect registrations such as:

```csharp
builder.Services.AddScoped<IMyService, MyService>();
builder.Services.AddTransient<IMyHelper, MyHelper>();
builder.Services.AddSingleton<IMyCache, MyCache>();
```

Document:

- Registered interfaces and implementations.
- Service lifetimes.
- Registration conventions.
- Duplicate registrations.
- Missing or suspicious registrations.
- Singleton services that depend on scoped services.
- Services that maintain mutable state despite singleton lifetime.

Do not label a lifetime incorrect without understanding the service's dependencies and state.

### 5.3 Middleware Pipeline

Inspect middleware ordering and behavior.

Common middleware:

- Exception handling.
- HTTPS redirection.
- HSTS.
- Static files.
- Routing.
- CORS.
- Authentication.
- Authorization.
- Session.
- Response compression.
- Rate limiting.

Check:

- Whether middleware is registered.
- Whether ordering is appropriate.
- Whether required middleware is missing.
- Whether custom middleware performs unexpected operations.

A middleware's presence does not prove that it is correctly configured.

### 5.4 Controllers and Endpoints

Inspect:

- Controllers.
- Actions.
- Minimal API route mappings.
- HTTP methods.
- Route templates.
- Request models.
- Response models.
- Status codes.
- Validation.
- Authorization attributes.

Record:

- Main API areas.
- Endpoint naming conventions.
- Duplicate routes.
- Inconsistent response structures.
- Direct business logic inside controllers.
- Unnecessary synchronous operations in asynchronous request paths.

Do not assume that every controller action must return the same response format.

---

## 6. Entity Framework and Data Access

Identify the actual data-access technology.

Possible technologies:

- Entity Framework 6
- Entity Framework Core
- ADO.NET
- Dapper
- Stored Procedures
- Raw SQL
- Multiple approaches used together

### 6.1 DbContext Analysis

If EF Core or EF6 is used, inspect:

- DbContext classes.
- DbSet properties.
- Entity configurations.
- Relationships.
- Fluent API configurations.
- Data annotations.
- Global query filters.
- Value conversions.
- Interceptors.
- SaveChanges overrides.

Document:

- Context responsibilities.
- Entity registration.
- Database configuration.
- Relationship configuration.
- Transaction behavior, if visible.

### 6.2 Entity and Relationship Analysis

Inspect entities and their relationships.

Identify:

- Primary keys.
- Foreign keys.
- One-to-one relationships.
- One-to-many relationships.
- Many-to-many relationships.
- Navigation properties.
- Required and optional relationships.
- Cascade delete behavior.
- Soft-delete implementation.
- Audit fields.

Do not infer database constraints solely from C# properties if migrations or database definitions are available.

### 6.3 Query Analysis

Inspect LINQ queries and database operations.

Look for potential concerns:

- N+1 query patterns.
- Unnecessary `Include`.
- Excessive eager loading.
- Unnecessary materialization with `ToList`.
- Filtering after materialization instead of in SQL.
- Repeated database calls.
- Missing pagination in potentially large result sets.
- Unnecessary tracking for read-only queries.
- Large data retrieval.
- Synchronous database operations in asynchronous application paths.
- Client-side evaluation risks.
- Complex queries that are difficult to maintain.

For every concern, identify the relevant query and explain why it may be problematic.

Do not claim that a query is slow without execution evidence or database measurements.

### 6.4 Asynchronous Data Access

Inspect use of:

- `async`
- `await`
- `ToListAsync`
- `FirstOrDefaultAsync`
- `SaveChangesAsync`
- `ExecuteReaderAsync`
- Other asynchronous database APIs

Check:

- Whether asynchronous methods are used consistently in I/O-bound paths.
- Whether async methods are unnecessarily wrapped in `Task.Run`.
- Whether `.Result` or `.Wait()` is used in request-handling paths.
- Whether cancellation tokens are supported where appropriate.

Do not recommend asynchronous code for CPU-bound work without a specific reason.

---

## 7. Database Detection

The default database assumption for the .NET ecosystem in this project context is SQL Server.

However, this is only a discovery default, not evidence about the actual repository.

Inspect:

- Connection string names and providers.
- EF provider packages.
- Database context configuration.
- SQL scripts.
- Migrations.
- Database-specific SQL syntax.
- Provider-specific code.

Possible databases include:

- SQL Server
- PostgreSQL
- MySQL
- SQLite
- Oracle
- Other supported providers

### 7.1 SQL Server Evidence

Look for:

- `Microsoft.EntityFrameworkCore.SqlServer`
- `UseSqlServer`
- `System.Data.SqlClient`
- `Microsoft.Data.SqlClient`
- SQL Server connection string patterns.
- T-SQL scripts.
- SQL Server-specific migrations.

### 7.2 Report the Actual Database

Report:

- Detected database engine.
- Provider and version, if available.
- Evidence supporting the identification.
- Whether multiple database providers are configured.
- Whether database information is incomplete.

If the repository uses Oracle or PostgreSQL instead of SQL Server, report the actual provider.

Never change database assumptions to match the default.

For deeper SQL Server analysis, use:

`references/sqlserver-analysis.md`

For Oracle analysis, use:

`references/oracle-analysis.md`

---

## 8. Repository and Data Access Patterns

Identify whether the project uses:

- Repository Pattern.
- Unit of Work.
- Generic Repository.
- Specification Pattern.
- Direct DbContext access.
- Query Objects.
- CQRS.
- MediatR.
- ADO.NET Data Access Layer.

For each pattern:

1. Identify actual implementation.
2. Identify the classes involved.
3. Explain how it is used.
4. Identify duplication or unnecessary abstraction.
5. Determine whether it is consistently applied.

Do not recommend adding Repository Pattern automatically when EF Core already provides the required data-access abstractions.

Do not treat every class named `Repository` as a correctly implemented Repository Pattern.

---

## 9. Authentication and Authorization

Inspect authentication and authorization implementation.

Possible mechanisms:

- ASP.NET Core Identity.
- JWT Bearer Authentication.
- Cookie Authentication.
- OAuth 2.0.
- OpenID Connect.
- Custom authentication.
- Windows Authentication.

Check:

- Authentication registration.
- Authorization policies.
- Roles and claims.
- `[Authorize]` attributes.
- Anonymous endpoints.
- Token validation settings.
- Password hashing approach.
- Refresh-token handling.
- Cookie configuration.
- Identity configuration.

Identify:

- Endpoints without visible authorization controls.
- Inconsistent authorization rules.
- Hardcoded secrets.
- Weak configuration patterns.
- Sensitive information returned in responses.
- Potential privilege escalation paths.

Do not conclude that an endpoint is publicly accessible only because an attribute is absent. Check global authorization policies and middleware configuration.

For detailed security analysis, use:

`references/security-analysis.md`

---

## 10. Validation and Error Handling

Inspect:

- Data Annotations.
- FluentValidation.
- Custom validators.
- ModelState validation.
- Domain validation.
- Exception middleware.
- Exception filters.
- Result patterns.
- Logging of exceptions.

Check:

- Whether input validation is applied.
- Whether business rules are validated in appropriate locations.
- Whether exceptions are handled consistently.
- Whether internal exception details are exposed to clients.
- Whether errors are logged with useful context.
- Whether duplicate validation logic exists.

Distinguish input validation from business-rule validation.

Do not assume that successful model binding means all business rules are satisfied.

---

## 11. Configuration and Secrets

Inspect:

- `appsettings.json`
- `appsettings.Development.json`
- `appsettings.Production.json`
- Environment variables usage.
- User Secrets configuration.
- Azure Key Vault integration, if present.
- `web.config`
- `app.config`
- `launchSettings.json`

Check:

- Configuration separation by environment.
- Connection string handling.
- Secret management.
- Hardcoded credentials.
- Configuration duplication.
- Missing required settings.
- Unsafe fallback values.

Do not print actual secret values in reports.

If a secret is detected, report its file path and key name, but redact its value.

Do not attempt to validate credentials by connecting to external services or databases.

---

## 12. Logging and Observability

Inspect:

- `ILogger<T>`
- Serilog.
- NLog.
- log4net.
- Application Insights.
- OpenTelemetry.
- Custom logging implementations.

Determine:

- Logging providers.
- Log levels.
- Structured logging usage.
- Exception logging.
- Correlation identifiers.
- Request logging.
- Sensitive data exposure risks.
- Logging configuration by environment.

Do not assume that installing a logging package means useful observability is implemented.

---

## 13. Performance Analysis

Inspect code for potential performance concerns.

Areas to review:

- Database query patterns.
- Object allocations.
- Large collections.
- Repeated serialization.
- Synchronous I/O.
- Expensive loops.
- Unnecessary reflection.
- Repeated service initialization.
- Caching strategy.
- Large HTTP responses.
- File and stream handling.
- Memory-intensive operations.

For ASP.NET Core, also inspect:

- Response compression.
- Pagination.
- Rate limiting.
- Output caching.
- Distributed caching.
- Static file handling.

Classify findings as:

- Confirmed from code.
- Potential risk requiring runtime verification.
- Not enough evidence.

Static code inspection cannot establish actual response time, CPU usage, memory consumption, or throughput.

For detailed performance analysis, use:

`references/performance-analysis.md`

---

## 14. Dependencies and NuGet Packages

Inspect:

- `PackageReference`
- `packages.config`
- Central package management.
- `Directory.Packages.props`
- NuGet package versions.
- Project references.

Identify:

- Main dependencies.
- Framework-specific packages.
- Database providers.
- Authentication packages.
- Logging packages.
- Mapping and validation libraries.
- Testing packages.
- Packages that appear unused.
- Duplicate or overlapping packages.
- Version inconsistencies.

Do not remove packages or update versions.

Do not claim a package is vulnerable without checking reliable vulnerability information.

If package vulnerability checking is requested, report the source and date of verification.

---

## 15. Testing Structure

Identify testing frameworks and test projects.

Possible tools:

- xUnit.
- NUnit.
- MSTest.
- Moq.
- NSubstitute.
- FakeItEasy.
- FluentAssertions.
- WebApplicationFactory.
- Testcontainers.

Inspect:

- Test project references.
- Unit tests.
- Integration tests.
- API tests.
- Database tests.
- Test configuration.
- Test data setup.
- Mocking patterns.

Record the apparent testing coverage and important missing areas.

Do not execute tests as part of this read-only analysis unless explicitly authorized.

For detailed test planning and engineering, use the separate `test-engineering` Skill.

---

## 16. Technical Debt and Risk Identification

Identify potential technical debt such as:

- Large or overly complex classes.
- Methods with too many responsibilities.
- Duplicate business logic.
- Inconsistent naming.
- Tight coupling.
- Hidden dependencies.
- Incomplete error handling.
- Missing validation.
- Inconsistent async usage.
- Unclear transaction boundaries.
- Legacy technology dependencies.
- Missing tests around critical business rules.
- Fragile configuration.

Prioritize findings:

- P0: Critical issue requiring immediate attention.
- P1: High-priority issue with significant impact.
- P2: Medium-priority maintainability or reliability concern.
- P3: Low-priority improvement.

Do not assign P0 or P1 based only on stylistic preferences.

Every significant finding must include:

1. Description.
2. Evidence.
3. File path.
4. Class or method name.
5. Potential impact.
6. Confidence level.
7. Recommended investigation or next step.

---

## 17. Evidence and Confidence

Use these classifications in the final Persian report:

- تأییدشده: Directly supported by source code or configuration.
- استنباط‌شده: Strongly inferred from multiple pieces of evidence.
- نیازمند تأیید توسعه‌دهنده: Requires business or environment knowledge.
- قابل بررسی: A potential issue requiring additional investigation.

Never present an assumption as a confirmed implementation detail.

Whenever possible, reference exact file paths, class names, method names, configuration keys, and line numbers.

---

## 18. Read-Only Analysis Rules

During this analysis:

- Do not modify source code.
- Do not create or delete project files.
- Do not install or update NuGet packages.
- Do not change project configuration.
- Do not modify database schemas.
- Do not run migrations.
- Do not connect to production databases.
- Do not execute destructive SQL.
- Do not change Git branches or commits.
- Do not modify CI/CD pipelines.
- Do not run load tests or penetration tests.
- Do not expose secret values.

Read files and inspect repository structure only, unless the user explicitly authorizes an additional action.

---

## 19. Expected Analysis Output

Provide a Persian report with the following sections:

1. معرفی کلی پروژه .NET
2. نسخه .NET و زبان C#
3. فهرست پروژه‌های Solution
4. معماری و لایه‌بندی
5. تکنولوژی‌ها و کتابخانه‌های اصلی
6. روش دسترسی به داده
7. دیتابیس شناسایی‌شده و شواهد آن
8. تحلیل Entityها و روابط
9. تحلیل APIها و Controllerها
10. تحلیل Dependency Injection و Middleware
11. احراز هویت و مجوزها
12. اعتبارسنجی و مدیریت خطا
13. تنظیمات و مدیریت Secrets
14. Logging و Observability
15. ملاحظات Performance
16. ساختار تست‌ها
17. بدهی فنی و ریسک‌ها
18. موارد نیازمند تأیید توسعه‌دهنده
19. پیشنهادهای اولویت‌بندی‌شده

For every important technical conclusion, include its evidence.

Keep the report factual, specific, and actionable.

Do not generate or update project documentation until the user approves the proposed documentation changes.
