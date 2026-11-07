
# Java Project Analysis Reference

## 1. Purpose

This reference defines the analysis procedure for software projects built with the Java ecosystem.

It applies to:

- Java SE
- Java EE / Jakarta EE
- Spring Framework
- Spring Boot
- Spring MVC
- Spring WebFlux
- Spring Data JPA
- Hibernate ORM
- Jakarta Persistence (JPA)
- JDBC
- Maven
- Gradle
- Servlet Applications
- REST APIs
- Microservices
- Java Console Applications
- Java Desktop Applications

The purpose is to understand the actual Java implementation, framework versions, architecture, dependencies, persistence layer, security mechanisms, and technical risks.

This reference is for analysis and documentation. It does not authorize source-code modifications.

---

## 2. Technology and Version Detection

Inspect the repository to identify the actual Java technologies and versions.

### 2.1 Important Project Files

Inspect relevant files:

- `pom.xml`
- `build.gradle`
- `build.gradle.kts`
- `settings.gradle`
- `settings.gradle.kts`
- `gradle.properties`
- `gradle-wrapper.properties`
- `mvnw`
- `mvnw.cmd`
- `gradlew`
- `gradlew.bat`
- `application.properties`
- `application.yml`
- `application.yaml`
- `persistence.xml`
- `web.xml`
- `module-info.java`
- `Dockerfile`
- `docker-compose.yml`

Also inspect parent POMs and shared Gradle configuration when present.

### 2.2 Java Version

Identify:

- Java source compatibility.
- Java target compatibility.
- Java toolchain version.
- Maven compiler configuration.
- Gradle Java toolchain configuration.
- JDK version requirements.
- Runtime version requirements.

Examples:

Maven:

```xml
<properties>
    <maven.compiler.source>17</maven.compiler.source>
    <maven.compiler.target>17</maven.compiler.target>
</properties>
```

Gradle:

```groovy
java {
    toolchain {
        languageVersion = JavaLanguageVersion.of(17)
    }
}
```

Do not assume that the installed JDK is the same as the version required by the project.

If multiple Java version declarations exist, identify conflicts and explain which configuration appears authoritative.

### 2.3 Spring Boot Version

For Spring Boot projects, inspect:

- Spring Boot parent POM.
- Spring Boot dependency management.
- Spring Boot Gradle plugin.
- Version properties.
- Version catalog declarations.

Example:

```xml
<parent>
    <groupId>org.springframework.boot</groupId>
    <artifactId>spring-boot-starter-parent</artifactId>
    <version>3.4.0</version>
</parent>
```

Record:

- Spring Boot version.
- Spring Framework version, if identifiable.
- Hibernate version, if identifiable.
- Spring Data version, if identifiable.
- Jakarta EE or Java EE generation.
- Whether dependency versions are managed by Spring Boot.

Do not assume that every dependency version is directly declared in the project's build file.

### 2.4 Build System

Identify:

- Maven.
- Gradle.
- Gradle Kotlin DSL.
- Other build systems.

Record wrapper availability and version.

Do not execute build commands unless explicitly authorized.

---

## 3. Project Structure

Inspect the repository and identify the actual project structure.

For conventional Java applications, inspect:

- `src/main/java`
- `src/main/resources`
- `src/test/java`
- `src/test/resources`

For multi-module projects, inspect:

- Parent POM.
- Maven modules.
- Gradle settings.
- Included projects.
- Inter-module dependencies.

Create an inventory:

| Module | Type | Main Responsibility | Dependencies |
|---|---|---|---|

Identify:

- Application entry points.
- Web modules.
- Service modules.
- Domain or model modules.
- Persistence modules.
- Shared libraries.
- Integration modules.
- Test modules.

Do not assume a project follows a particular architecture merely because its packages use names such as `domain`, `service`, or `repository`.

---

## 4. Application Architecture

Identify the architecture implemented by the actual source code.

Possible styles:

- Monolithic Architecture.
- Layered Architecture.
- N-Tier Architecture.
- Clean Architecture.
- Hexagonal Architecture.
- Modular Monolith.
- Microservices.
- MVC.
- Event-Driven Architecture.
- Hybrid Architecture.

For every identified layer, document:

1. Responsibility.
2. Main packages.
3. Important classes.
4. Dependencies.
5. Communication with other layers.
6. Separation of concerns.

### 4.1 Common Spring Application Layers

Check whether the following responsibilities are separated.

**Controller Layer**

Typical annotations:

- `@Controller`
- `@RestController`
- `@RequestMapping`
- `@GetMapping`
- `@PostMapping`
- `@PutMapping`
- `@DeleteMapping`

Responsibilities:

- HTTP request handling.
- Request parameter processing.
- Response generation.
- Delegating work to application services.

**Service Layer**

Typical annotation:

- `@Service`

Responsibilities:

- Application use cases.
- Business operations.
- Transaction orchestration.
- Coordination between repositories and external services.

**Repository Layer**

Typical annotations and interfaces:

- `@Repository`
- `JpaRepository`
- `CrudRepository`
- `PagingAndSortingRepository`

Responsibilities:

- Data access.
- Query execution.
- Persistence operations.

**Domain and Model Layer**

Possible components:

- Entities.
- Value Objects.
- Domain Services.
- Enums.
- Domain Events.
- Business Rules.

**Configuration and Infrastructure**

Possible components:

- `@Configuration`
- `@Bean`
- Security Configuration.
- Database Configuration.
- External API Clients.
- Messaging Configuration.

These are common conventions, not mandatory requirements.

### 4.2 Architecture Findings

Identify:

- Business logic inside controllers.
- Direct repository access from controllers.
- Large service classes.
- Duplicate business logic.
- Tight coupling.
- Circular dependencies.
- Incorrect dependency direction.
- Excessive static utility usage.
- Unnecessary abstractions.
- Inconsistent transaction boundaries.

For each finding, provide exact package, file, class, and method references where possible.

---

## 5. Spring Boot Application Analysis

For Spring Boot applications, inspect startup, configuration, component scanning, and application lifecycle.

### 5.1 Application Entry Point

Inspect the class containing:

```java
@SpringBootApplication
public class Application {
    public static void main(String[] args) {
        SpringApplication.run(Application.class, args);
    }
}
```

Identify:

- Main application class.
- Component scanning boundaries.
- Configuration classes.
- Application startup behavior.
- Additional startup components.

Check whether packages containing application components are within the component scan scope.

Do not assume that a class is registered as a Spring bean only because it exists in the source tree.

### 5.2 Dependency Injection

Inspect:

- Constructor Injection.
- Setter Injection.
- Field Injection.
- `@Autowired`
- `@Qualifier`
- `@Primary`
- `@Bean`
- `@Component`
- `@Service`
- `@Repository`
- `@Configuration`

Prefer constructor injection as the general maintainability baseline.

Check:

- Missing bean definitions.
- Ambiguous bean candidates.
- Circular dependencies.
- Excessive dependencies in constructors.
- Field injection usage.
- Incorrect bean scopes.
- Unnecessary manual object creation.
- Static access to Spring-managed components.

Do not report every use of `@Autowired` as a defect. Evaluate the actual injection style and context.

### 5.3 Bean Lifecycle and Scopes

Identify relevant scopes:

- Singleton.
- Prototype.
- Request.
- Session.
- Application.

Inspect:

- `@Scope`
- `@PostConstruct`
- `@PreDestroy`
- `InitializingBean`
- `DisposableBean`

Check whether stateful objects are registered with scopes that could cause concurrency or lifecycle problems.

---

## 6. Spring MVC and REST API Analysis

Inspect controllers and endpoint mappings.

### 6.1 Endpoint Inventory

Identify:

- Controller classes.
- Base request mappings.
- HTTP methods.
- Route paths.
- Request parameters.
- Path variables.
- Request body models.
- Response types.
- HTTP status codes.
- Validation annotations.
- Authentication and authorization requirements.

Common annotations:

- `@RestController`
- `@RequestMapping`
- `@GetMapping`
- `@PostMapping`
- `@PutMapping`
- `@PatchMapping`
- `@DeleteMapping`
- `@RequestParam`
- `@PathVariable`
- `@RequestBody`
- `@ResponseStatus`
- `@ResponseEntity`

Create an endpoint inventory:

| Controller | Method | HTTP Method | Path | Request | Response |
|---|---|---|---|---|---|

Use actual mappings. Do not invent routes from method names.

### 6.2 Request and Response Models

Inspect:

- DTOs.
- Request classes.
- Response classes.
- Records.
- JavaBeans.
- Entity exposure in API responses.
- Serialization annotations.

Check:

- Whether persistence entities are exposed directly.
- Whether request and response models are separated.
- Whether sensitive fields are returned.
- Whether validation is applied.
- Whether API responses are consistent.

Do not require DTOs for every endpoint automatically. Consider the complexity and security implications.

### 6.3 Exception Handling

Inspect:

- `@ControllerAdvice`
- `@RestControllerAdvice`
- `@ExceptionHandler`
- Custom exceptions.
- Error response models.
- Validation exception handling.

Check:

- Consistent error responses.
- Appropriate HTTP status codes.
- Exposure of internal stack traces.
- Logging of unexpected errors.
- Duplicate exception handling logic.

For detailed API analysis, use:

`references/api-analysis.md`

---

## 7. Hibernate and JPA Analysis

Identify the actual persistence implementation.

Possible technologies:

- Jakarta Persistence.
- Java Persistence API (JPA).
- Hibernate ORM.
- Spring Data JPA.
- JDBC.
- MyBatis.
- Other ORM frameworks.

Do not treat JPA and Hibernate as the same thing:

- JPA is a persistence specification.
- Hibernate is an ORM implementation.
- Spring Data JPA provides repository abstractions built on top of JPA.

### 7.1 Entity Detection

Inspect classes annotated with:

- `@Entity`
- `@MappedSuperclass`
- `@Embeddable`

Identify:

- Primary keys.
- Generated identifiers.
- Columns.
- Unique constraints.
- Nullability.
- Index annotations.
- Inheritance mappings.
- Embedded objects.
- Lifecycle callbacks.

Inspect:

- `@Id`
- `@GeneratedValue`
- `@Column`
- `@Table`
- `@Version`
- `@Embedded`
- `@EmbeddedId`
- `@AttributeOverride`

Record the actual mapping strategy.

### 7.2 Entity Relationships

Inspect:

- `@OneToOne`
- `@OneToMany`
- `@ManyToOne`
- `@ManyToMany`
- `@JoinColumn`
- `@JoinTable`
- `mappedBy`

For each relationship, identify:

- Owning side.
- Inverse side.
- Join columns.
- Fetch strategy.
- Cascade configuration.
- Optionality.
- Orphan removal.
- Bidirectional navigation.

Check for:

- Incorrect ownership.
- Missing or inconsistent mappings.
- Unnecessary bidirectional relationships.
- Unexpected cascading.
- Large object graphs.
- JSON serialization recursion risks.

Do not assume that a Java relationship annotation proves the database foreign key exists. Inspect migrations or database definitions when available.

### 7.3 Fetch Strategies

Inspect:

- `FetchType.LAZY`
- `FetchType.EAGER`
- Entity graphs.
- Join fetch queries.
- DTO projections.

Identify potential:

- N+1 query patterns.
- Unnecessary eager loading.
- Lazy initialization exceptions.
- Excessive joins.
- Unexpected collection loading.
- Large object graph retrieval.

Do not assume that every lazy relationship is automatically efficient.

### 7.4 Persistence Context

Inspect:

- EntityManager usage.
- Hibernate Session usage.
- Persistence context boundaries.
- Flush behavior.
- Dirty checking.
- Transaction boundaries.

Identify:

- Entities loaded outside transaction boundaries.
- Unnecessary flush operations.
- Long-running persistence contexts.
- Detached entity update risks.
- Excessive entity tracking.
- Bulk operations that may leave the persistence context inconsistent.

### 7.5 JPQL, Criteria API, and Native SQL

Inspect:

- `@Query`
- JPQL.
- Native SQL.
- Criteria API.
- Specifications.
- Derived query methods.

Check:

- Query complexity.
- Parameter binding.
- Pagination.
- Sorting.
- Projection.
- Duplicate queries.
- Potentially expensive joins.
- Queries that retrieve more data than needed.

Never claim a query is slow without execution evidence or database measurements.

---

## 8. Transaction Management

Inspect:

- `@Transactional`
- Transaction managers.
- Propagation.
- Isolation.
- Read-only transactions.
- Rollback configuration.
- Programmatic transactions.

Check:

- Whether transaction boundaries match business operations.
- Whether transactions are unnecessarily long.
- Whether external API calls occur inside database transactions.
- Whether rollback behavior is appropriate.
- Whether transaction annotations are applied to methods invoked through Spring proxies.
- Whether self-invocation could prevent expected proxy-based transaction behavior.

Review propagation options where relevant:

- `REQUIRED`
- `REQUIRES_NEW`
- `SUPPORTS`
- `NOT_SUPPORTED`
- `MANDATORY`
- `NEVER`
- `NESTED`

Do not report a transaction issue without considering the actual transaction manager and call path.

---

## 9. Database Detection

The default database assumption for the Java ecosystem in this project context is Oracle Database.

This is a discovery default, not proof that the actual project uses Oracle.

Inspect:

- JDBC URLs.
- JDBC drivers.
- Spring datasource configuration.
- Hibernate dialect.
- JPA configuration.
- Migration scripts.
- SQL syntax.
- Database container configuration.

Possible databases:

- Oracle Database.
- PostgreSQL.
- MySQL.
- MariaDB.
- SQL Server.
- H2.
- SQLite.
- Other JDBC-compatible databases.

### 9.1 Oracle Evidence

Look for:

- `ojdbc` dependencies.
- Oracle JDBC driver classes.
- `jdbc:oracle:thin:`.
- Oracle Hibernate dialect configuration.
- Oracle-specific SQL.
- Oracle sequences.
- Oracle migration scripts.

### 9.2 Report the Actual Database

Record:

- Database engine.
- JDBC driver.
- Driver version, if available.
- Hibernate dialect.
- Database version, if known.
- Evidence supporting identification.
- Whether multiple database configurations exist.

If the repository uses PostgreSQL, MySQL, SQL Server, or another engine, report the actual database instead of assuming Oracle.

For deeper Oracle analysis, use:

`references/oracle-analysis.md`

For SQL Server analysis, use:

`references/sqlserver-analysis.md`

Never print connection credentials or secret values in the report.

---

## 10. Spring Security Analysis

Identify the authentication and authorization implementation.

Possible mechanisms:

- Spring Security.
- Form Login.
- HTTP Basic.
- JWT Bearer Authentication.
- OAuth 2.0.
- OpenID Connect.
- Session-based authentication.
- Custom authentication providers.

Inspect:

- Security configuration classes.
- `SecurityFilterChain`
- Authentication providers.
- UserDetailsService.
- PasswordEncoder.
- JWT filters.
- Authentication converters.
- Authorization rules.
- Method-level security.
- CORS and CSRF configuration.

Common annotations:

- `@EnableWebSecurity`
- `@EnableMethodSecurity`
- `@PreAuthorize`
- `@PostAuthorize`
- `@Secured`
- `@RolesAllowed`

Check:

- Public and protected endpoints.
- Role and authority rules.
- Password hashing.
- Token validation.
- Token expiration.
- Refresh-token handling.
- Session management.
- CSRF configuration.
- CORS configuration.
- Security headers.
- Sensitive information exposure.

Do not assume an endpoint is public only because no method-level annotation is visible. Inspect the global filter chain and authorization rules.

For detailed security analysis, use:

`references/security-analysis.md`

---

## 11. Validation and Business Rules

Inspect:

- Jakarta Bean Validation.
- `@Valid`
- `@Validated`
- `@NotNull`
- `@NotBlank`
- `@Size`
- `@Email`
- `@Min`
- `@Max`
- Custom constraints.
- Validator implementations.

Check:

- Request validation.
- Service-level business validation.
- Domain invariants.
- Duplicate validation logic.
- Missing validation for important business operations.
- Inconsistent error responses.

Distinguish:

- Structural input validation.
- Business-rule validation.
- Database constraints.

Do not assume that passing Bean Validation means the business operation is valid.

---

## 12. Configuration and Secrets

Inspect:

- `application.properties`
- `application.yml`
- Profile-specific configuration files.
- Environment variables.
- Spring profiles.
- External configuration.
- Secret management integration.
- `@ConfigurationProperties`
- `@Value`

Identify:

- Active profile configuration.
- Configuration duplication.
- Hardcoded credentials.
- Connection strings.
- External service endpoints.
- Missing required configuration.
- Unsafe default values.
- Environment-specific differences.

Do not expose secret values in the report.

If a secret is detected, report its file path and configuration key, but redact its value.

Do not attempt to validate credentials by connecting to databases or external services.

---

## 13. Logging and Observability

Inspect:

- SLF4J.
- Logback.
- Log4j2.
- Java Util Logging.
- Spring Boot Actuator.
- Micrometer.
- OpenTelemetry.
- Distributed tracing integrations.

Check:

- Logging configuration.
- Log levels.
- Structured logging.
- Exception logging.
- Correlation IDs.
- Request tracing.
- Sensitive data in logs.
- Health endpoints.
- Metrics exposure.
- Actuator endpoint security.

Do not assume that adding Spring Boot Actuator automatically provides secure and useful observability.

---

## 14. Asynchronous Processing and Messaging

Identify whether the application uses:

- `@Async`
- `CompletableFuture`
- ExecutorService.
- Scheduled tasks.
- `@Scheduled`
- Spring Events.
- ApplicationEventPublisher.
- Kafka.
- RabbitMQ.
- JMS.
- Other messaging systems.

Check:

- Thread pool configuration.
- Executor lifecycle.
- Error handling in asynchronous tasks.
- Transaction behavior.
- Message acknowledgment.
- Retry configuration.
- Dead-letter handling.
- Idempotency.
- Duplicate message processing risks.

Do not infer distributed messaging guarantees from the presence of a messaging dependency alone.

---

## 15. Performance Analysis

Inspect potential performance concerns in:

- JPA queries.
- Hibernate fetch strategies.
- Database access.
- Object mapping.
- Serialization.
- Large collections.
- Excessive object creation.
- Blocking I/O.
- Thread pool usage.
- Caching.
- Repeated remote calls.
- Large API responses.
- Connection pool configuration.

For Spring Boot applications, inspect:

- HikariCP or other connection pools.
- Spring Cache.
- Redis integration.
- Pagination.
- Batch processing.
- HTTP client configuration.
- Web server thread settings.

Identify potential risks and the evidence supporting them.

Static code inspection cannot establish actual latency, throughput, CPU usage, memory consumption, or database execution time.

For detailed performance analysis, use:

`references/performance-analysis.md`

---

## 16. Dependencies and Build Configuration

Inspect:

- Maven dependencies.
- Gradle dependencies.
- Parent POMs.
- Dependency management.
- BOM imports.
- Gradle version catalogs.
- Plugins.
- Wrapper versions.
- Dependency exclusions.

Identify:

- Main framework dependencies.
- Persistence dependencies.
- Security dependencies.
- Web dependencies.
- Database drivers.
- Logging dependencies.
- Testing dependencies.
- Duplicate dependencies.
- Version conflicts.
- Potentially unused libraries.
- Legacy dependencies.

Do not update or remove dependencies.

Do not claim a dependency is vulnerable without reliable vulnerability evidence.

If vulnerability checking is requested, identify the source and date of verification.

---

## 17. Testing Structure

Identify testing frameworks and test types.

Possible tools:

- JUnit 4.
- JUnit 5.
- TestNG.
- Mockito.
- AssertJ.
- Spring Boot Test.
- MockMvc.
- WebTestClient.
- Testcontainers.
- H2.
- WireMock.

Inspect:

- Unit tests.
- Service tests.
- Repository tests.
- Controller tests.
- Integration tests.
- Security tests.
- Database tests.
- Test configuration.
- Test data setup.
- Mocking patterns.

Check whether tests cover important business rules and integration boundaries.

Do not execute tests as part of this read-only analysis unless explicitly authorized.

For detailed test planning and engineering, use the separate `test-engineering` Skill.

---

## 18. Technical Debt and Risk Identification

Identify potential technical debt such as:

- Large service classes.
- Controllers containing business logic.
- Duplicate code.
- Tight coupling.
- Circular dependencies.
- Incorrect transaction boundaries.
- Poor entity relationship design.
- N+1 query risks.
- Missing validation.
- Weak exception handling.
- Hardcoded configuration.
- Inconsistent dependency injection.
- Legacy dependencies.
- Missing tests around critical business operations.
- Unclear module responsibilities.

Prioritize findings:

- P0: Critical issue requiring immediate attention.
- P1: High-priority issue with significant impact.
- P2: Medium-priority reliability or maintainability concern.
- P3: Low-priority improvement.

Do not assign P0 or P1 based only on coding style or personal preference.

Every significant finding must include:

1. Description.
2. Evidence.
3. File path.
4. Package, class, or method name.
5. Potential impact.
6. Confidence level.
7. Recommended investigation or next step.

---

## 19. Evidence and Confidence

Use these classifications in the final Persian report:

- تأییدشده: Directly supported by source code or configuration.
- استنباط‌شده: Strongly inferred from multiple pieces of evidence.
- نیازمند تأیید توسعه‌دهنده: Requires business or environment knowledge.
- قابل بررسی: A potential issue requiring additional investigation.

Whenever possible, reference:

- Exact file paths.
- Package names.
- Class names.
- Method names.
- Configuration keys.
- Annotation names.
- Line numbers.

Never present an assumption as a confirmed implementation detail.

---

## 20. Read-Only Analysis Rules

During this analysis:

- Do not modify source code.
- Do not create or delete project files.
- Do not install or update Maven or Gradle dependencies.
- Do not change build configuration.
- Do not modify database schemas.
- Do not execute database migrations.
- Do not connect to production databases.
- Do not execute destructive SQL.
- Do not change Git branches or commits.
- Do not modify CI/CD pipelines.
- Do not run load tests or penetration tests.
- Do not expose secret values.

Read files and inspect repository structure only, unless the user explicitly authorizes an additional action.

---

## 21. Expected Analysis Output

Provide a Persian report with these sections:

1. معرفی کلی پروژه Java
2. نسخه Java و JDK موردنیاز
3. نسخه Spring Boot و Spring Framework
4. سیستم Build و نسخه آن
5. ساختار ماژول‌ها و پکیج‌ها
6. معماری و لایه‌بندی
7. Dependency Injection و مدیریت Beanها
8. تحلیل Controllerها و APIها
9. تحلیل Entityها و روابط JPA
10. تحلیل Hibernate و روش دسترسی به داده
11. دیتابیس شناسایی‌شده و شواهد آن
12. مدیریت Transaction
13. احراز هویت و مجوزها
14. اعتبارسنجی و مدیریت خطا
15. تنظیمات و مدیریت Secrets
16. Logging و Observability
17. پردازش غیرهم‌زمان و Messaging
18. ملاحظات Performance
19. وابستگی‌ها و کتابخانه‌ها
20. ساختار تست‌ها
21. بدهی فنی و ریسک‌ها
22. موارد نیازمند تأیید توسعه‌دهنده
23. پیشنهادهای اولویت‌بندی‌شده

For every important technical conclusion, include its evidence.

Keep the report factual, specific, and actionable.

Do not generate or update project documentation until the user approves the proposed documentation changes.
