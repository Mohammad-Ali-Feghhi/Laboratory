
# .NET Architecture Testing

## 1. Discover Existing Architecture

Identify whether the project uses:

- N-Layer Architecture
- Clean Architecture
- Modular Monolith
- Repository Pattern
- Unit of Work
- CQRS
- MediatR
- Domain Services
- Application Services
- Dependency Injection

Do not impose a new architecture without justification.

## 2. Dependency Rules

Where applicable, verify:

- Domain does not depend on UI.
- Domain does not depend on infrastructure.
- Application depends on appropriate abstractions.
- Infrastructure implements required interfaces.
- Dependency direction is consistent.

## 3. Layer Responsibilities

Inspect whether:

- Controllers contain excessive business logic.
- Forms contain persistence logic.
- Repositories contain unrelated responsibilities.
- Services have too many responsibilities.
- Dependencies are injected appropriately.

## 4. Architecture Tests

Use architecture-testing libraries only when compatible with the target framework.

Potential checks:

- Forbidden project references
- Dependency direction
- Namespace conventions
- Module boundaries
- Layer separation

Do not introduce architectural rules that contradict the existing project design.

## 5. Reporting

For every violation, provide:

- File
- Class or namespace
- Violated rule
- Impact
- Recommended correction

Do not refactor production code without approval.
