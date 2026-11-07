
# .NET Data Access Testing — SQL Server

## 1. Supported Technologies

Identify whether the project uses:

- Entity Framework 6
- Entity Framework Core
- Dapper
- ADO.NET
- Raw SQL
- Stored Procedures
- Multiple data access technologies

Identify exact versions and SQL Server provider.

## 2. Entity Framework 6

Separate business logic tests from persistence tests.

Do not assume mocked DbContext or DbSet reproduces:

- SQL translation
- Change tracking
- Lazy loading
- Relationships
- Constraints
- Transactions
- SQL Server behavior

For real provider behavior, use an isolated SQL Server test database.

Third-party EF6 in-memory providers such as Effort.EF6 have compatibility limitations.

Verify compatibility with the exact EF6 and provider versions before recommending them.

## 3. Entity Framework Core

EF Core InMemory is not a relational database.

It does not fully reproduce SQL Server behavior.

SQLite in-memory can provide some relational behavior, but it is still not SQL Server.

For SQL Server-specific tests, consider:

- SQL Server LocalDB
- Dedicated SQL Server test database
- Compatible Testcontainers setup

Check OS, Docker, edition, and CI compatibility first.

## 4. Dapper and ADO.NET

Test:

- Parameterized queries
- SQL parameter types
- Mapping
- Null handling
- Timeout
- Cancellation
- Transaction handling
- Stored procedure contracts

Use real SQL Server integration tests for SQL syntax and provider behavior.

## 5. SQL Server Scenarios

Where applicable, test:

- Primary keys
- Foreign keys
- Unique constraints
- Nullability
- Default constraints
- Check constraints
- Stored procedures
- Functions
- Views
- Triggers
- Transactions
- Rollback
- Isolation levels
- Locking
- Deadlocks
- Timeouts
- Identity generation
- SQL Server data types

## 6. Repository Pattern

Do not assume every repository requires extensive mocking.

Inspect:

- Repository responsibilities
- Unit of Work implementation
- DbContext lifecycle
- Transaction boundaries
- Query composition
- Error handling

Test repository contracts against SQL Server when persistence semantics matter.

## 7. Database Safety

Never connect to production.

Never execute destructive scripts without approval.

Use isolated test databases and reliable cleanup.
