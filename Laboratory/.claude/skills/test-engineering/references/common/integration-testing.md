
# Integration Testing

## 1. Purpose

Integration tests verify that multiple components work correctly together.

Use them when correctness depends on:
- Framework configuration
- Dependency injection
- ORM behavior
- Database provider behavior
- HTTP communication
- Authentication middleware
- Serialization
- Messaging
- Transaction management

## 2. Environment Verification

Before running integration tests:

1. Identify the required services.
2. Identify their versions.
3. Verify that the environment is available.
4. Confirm that the database is isolated from production.
5. Verify test credentials.
6. Confirm cleanup procedures.

Never assume Docker or a database server is installed.

## 3. Database Integration Tests

For .NET:
- Use SQL Server for provider-specific testing.

For Java:
- Use Oracle Database for provider-specific testing.

An in-memory database is not a complete replacement for either database.

## 4. Testcontainers

Consider Testcontainers only after verifying:

- Docker availability
- Operating system compatibility
- Database image availability
- Database version compatibility
- Licensing requirements
- CI environment support

Do not assume every project can use Testcontainers.

## 5. External Services

For remote APIs and messaging systems:

- Use controlled mocks or fakes for isolated component tests.
- Use isolated services for real integration tests.
- Test timeouts and failure handling where relevant.
- Do not expose production credentials.

## 6. Database Safety

Never:
- Connect to production databases.
- Execute destructive scripts without approval.
- Delete shared test data.
- Change schemas without approval.

Use isolated test environments and unique test records.

## 7. Reporting

Classify every test suite as:

- Passed
- Failed
- Skipped
- Blocked
- Not Run

Always report actual execution results.
