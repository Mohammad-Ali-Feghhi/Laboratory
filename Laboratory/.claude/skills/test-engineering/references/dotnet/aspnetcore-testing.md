
# ASP.NET Core Testing

## 1. Scope

Applies to:

- ASP.NET Core MVC
- Web API
- Minimal API
- Razor Pages
- Blazor Server

## 2. Unit Testing

Test:

- Controllers
- Application services
- Request handlers
- Validation
- Business rules
- Response mapping
- Error handling

Prefer testing business logic below controllers when appropriate.

## 3. Integration Testing

Consider:

Microsoft.AspNetCore.Mvc.Testing

WebApplicationFactory<TEntryPoint>

Verify:

- Routing
- Model binding
- Middleware
- Dependency injection
- Configuration
- Serialization
- Validation responses
- Exception handling
- Authentication
- Authorization

Verify framework compatibility before recommending packages.

## 4. Database Integration

Use SQL Server for database-specific integration tests.

Do not assume EF Core InMemory reproduces SQL Server behavior.

Use an isolated SQL Server test database when provider-specific behavior matters.

## 5. HTTP Testing

Test outbound HTTP dependencies using controlled handlers or mock HTTP servers.

Consider:

- Successful responses
- HTTP errors
- Timeouts
- Cancellation
- Retry behavior
- Invalid response content

## 6. Security Testing

Test:

- Anonymous access
- Authenticated access
- Forbidden access
- Roles
- Claims
- Policies
- Resource ownership

Use synthetic identities and test-only tokens.

Never use production credentials.
