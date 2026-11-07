
# SQL Server Database Analysis Reference

## 1. Purpose

This reference defines the analysis procedure for databases running on Microsoft SQL Server.

It applies to:

- SQL Server
- SQL Server Express
- SQL Server Developer Edition
- SQL Server Standard Edition
- SQL Server Enterprise Edition
- SQL Server LocalDB
- Azure SQL Database
- SQL Server databases accessed through Entity Framework
- SQL Server databases accessed through ADO.NET
- SQL Server databases accessed through Dapper
- SQL Server databases accessed through JDBC

The purpose is to understand the database structure, schema design, relationships, constraints, indexes, queries, stored procedures, security configuration, and potential performance risks.

This reference is for read-only analysis and documentation. It does not authorize database modifications.

---

## 2. Database Identification

Identify whether the repository actually uses Microsoft SQL Server.

Inspect:

- Connection strings.
- Database provider configuration.
- ORM provider packages.
- SQL scripts.
- Migration files.
- Database project files.
- Docker Compose files.
- Deployment configuration.
- Environment-specific settings.

### 2.1 Common SQL Server Evidence

Look for:

- `Microsoft.EntityFrameworkCore.SqlServer`
- `UseSqlServer`
- `Microsoft.Data.SqlClient`
- `System.Data.SqlClient`
- `SqlConnection`
- `SqlCommand`
- `SqlDataReader`
- JDBC SQL Server drivers.
- SQL Server connection string patterns.
- T-SQL syntax.
- SQL Server-specific migration operations.

### 2.2 Database Environment

Identify, when available:

- Database engine.
- SQL Server version.
- Edition.
- Hosting model.
- Database name.
- Schema names.
- Environment configuration.

Possible hosting models:

- Local SQL Server.
- SQL Server Express.
- LocalDB.
- Docker container.
- Dedicated server.
- Virtual machine.
- Azure SQL Database.

Do not assume the hosting model from the connection string name alone.

### 2.3 Connection Strings

Inspect configuration locations such as:

- `appsettings.json`
- `appsettings.Development.json`
- `appsettings.Production.json`
- `web.config`
- `app.config`
- Environment variables.
- User Secrets.
- Docker Compose configuration.

Common SQL Server connection string properties:

- `Server`
- `Data Source`
- `Initial Catalog`
- `Database`
- `Integrated Security`
- `Trusted_Connection`
- `User ID`
- `Password`
- `Encrypt`
- `TrustServerCertificate`
- `MultipleActiveResultSets`

Never print actual passwords, usernames, tokens, or secret values in the report.

Redact sensitive connection string values.

---

## 3. Database Schema and Object Inventory

Identify the available database schema information.

Possible sources:

- `.sql` files.
- EF Core migrations.
- EF6 migrations.
- SSDT database projects.
- DACPAC-related files.
- Database initialization scripts.
- Backup-derived schema exports.
- Existing database documentation.
- Authorized read-only schema inspection, if separately permitted.

Create an object inventory.

| Object Type | Object Name | Schema | Purpose |
|---|---|---|---|
| Table | ExampleTable | dbo | Example description |
| View | ExampleView | dbo | Example description |
| Procedure | ExampleProcedure | dbo | Example description |

Identify:

- Tables.
- Views.
- Stored Procedures.
- Functions.
- Triggers.
- Schemas.
- Sequences.
- Synonyms.
- User-defined types.
- Constraints.
- Indexes.

Only report objects supported by available evidence.

If the repository contains no database schema or migration files, state that the complete database structure cannot be confirmed.

---

## 4. Table Analysis

For each important table, inspect:

- Table name.
- Schema.
- Column names.
- Data types.
- Maximum lengths.
- Precision and scale.
- Nullability.
- Default constraints.
- Identity properties.
- Computed columns.
- Collation, if relevant.
- Primary key.
- Foreign keys.
- Unique constraints.
- Check constraints.

Create a table inventory:

| Table | Primary Key | Important Columns | Relationships | Notes |
|---|---|---|---|---|

### 4.1 Data Type Review

Inspect whether SQL Server data types are appropriate for their intended values.

Examples:

- `INT`
- `BIGINT`
- `SMALLINT`
- `TINYINT`
- `BIT`
- `DECIMAL`
- `NUMERIC`
- `FLOAT`
- `REAL`
- `CHAR`
- `VARCHAR`
- `NCHAR`
- `NVARCHAR`
- `DATE`
- `TIME`
- `DATETIME`
- `DATETIME2`
- `DATETIMEOFFSET`
- `UNIQUEIDENTIFIER`
- `VARBINARY`

Potential concerns:

- Unnecessarily large data types.
- Insufficient string length.
- Incorrect decimal precision.
- Floating-point types used for financial values.
- Unicode text stored in non-Unicode columns when multilingual data is required.
- Inconsistent date and time handling.
- Nullable columns without a clear business reason.

Do not recommend a data type change without understanding the business domain and existing data.

### 4.2 Identity and Key Strategy

Inspect:

- `IDENTITY`.
- Primary key definitions.
- Composite keys.
- Natural keys.
- Surrogate keys.
- `UNIQUEIDENTIFIER`.
- Sequences.

Check:

- Whether primary keys are defined.
- Whether key strategies are consistent.
- Whether composite keys are justified.
- Whether foreign keys reference compatible data types.

Do not assume that every table must use an integer identity column.

---

## 5. Relationships and Referential Integrity

Inspect:

- Foreign keys.
- Primary keys.
- Unique constraints.
- Composite relationships.
- Self-referencing relationships.
- Many-to-many junction tables.

Identify:

- One-to-one relationships.
- One-to-many relationships.
- Many-to-many relationships.
- Optional relationships.
- Required relationships.
- Referential actions.

### 5.1 Referential Actions

Inspect:

- `ON DELETE CASCADE`
- `ON DELETE SET NULL`
- `ON DELETE SET DEFAULT`
- `ON UPDATE CASCADE`
- `NO ACTION`

Check whether cascade behavior is appropriate for the business domain.

Potential concerns:

- Missing foreign keys.
- Orphan records.
- Inconsistent relationship definitions.
- Excessive cascade chains.
- Relationships represented only in application code.
- Foreign keys without supporting indexes where workload justifies them.

Do not claim that a relationship is missing merely because a corresponding EF navigation property exists or is absent.

### 5.2 Soft Delete

Inspect patterns such as:

- `IsDeleted`
- `Deleted`
- `DeletedAt`
- `IsActive`
- Status-based deletion.
- Global query filters.

Check:

- Whether soft-delete behavior is consistent.
- Whether related records are handled correctly.
- Whether unique constraints account for soft-deleted records.
- Whether reporting queries include or exclude deleted records appropriately.

Do not assume that `IsActive = 0` means soft deletion.

---

## 6. Index Analysis

Inspect index definitions when available.

Identify:

- Clustered indexes.
- Nonclustered indexes.
- Unique indexes.
- Composite indexes.
- Filtered indexes.
- Included columns.
- Primary key indexes.
- Columnstore indexes.
- Full-text indexes.

### 6.1 Index Structure

For each important index, document:

- Table.
- Index name.
- Index type.
- Key columns.
- Column order.
- Included columns.
- Uniqueness.
- Filter predicate.

Example:

```sql
CREATE NONCLUSTERED INDEX IX_Orders_CustomerId_OrderDate
ON dbo.Orders (CustomerId, OrderDate DESC)
INCLUDE (TotalAmount, Status);
```

### 6.2 Index Review

Inspect potential concerns:

- Missing indexes on frequently filtered or joined columns.
- Duplicate indexes.
- Overlapping indexes.
- Excessive indexes on write-heavy tables.
- Incorrect composite index column order.
- Large included-column lists.
- Indexes that appear unused based only on schema inspection.

Important limitations:

- Schema inspection alone cannot prove that an index is missing.
- Index usage requires workload and usage statistics.
- Index fragmentation requires runtime or maintenance information.
- An index that looks redundant may serve a different workload.

Do not create, rebuild, reorganize, or drop indexes.

---

## 7. Views, Stored Procedures, and Functions

Identify:

- Views.
- Indexed views.
- Stored Procedures.
- Scalar functions.
- Inline table-valued functions.
- Multi-statement table-valued functions.
- Triggers.

### 7.1 Stored Procedure Analysis

For each important procedure, inspect:

- Input parameters.
- Output parameters.
- Return values.
- Referenced tables.
- Joins.
- Filtering conditions.
- Transactions.
- Error handling.
- Dynamic SQL.
- Temporary tables.
- Table variables.
- Result sets.

Check for:

- Dynamic SQL injection risks.
- Missing parameterization.
- Excessive procedural complexity.
- Repeated queries.
- Unnecessary cursors.
- Unclear transaction boundaries.
- Inconsistent error handling.
- Unexpected result-set behavior.

Do not execute stored procedures during read-only analysis.

### 7.2 Function Analysis

Inspect:

- Function type.
- Input parameters.
- Return type.
- Referenced objects.
- Deterministic behavior where applicable.
- Usage in queries.

Identify potential performance concerns, especially when functions are applied to large sets of rows.

Do not assume that every scalar function causes poor performance. Evaluate actual usage and SQL Server version behavior.

### 7.3 View Analysis

Inspect:

- View definition.
- Referenced tables.
- Joins.
- Aggregations.
- Filters.
- Nested views.
- Security-related options.

Identify complex view dependencies and possible duplication of business logic.

---

## 8. Query and T-SQL Analysis

Inspect SQL scripts, inline SQL, stored procedures, and ORM-generated query definitions when available.

Review:

- SELECT statements.
- INSERT statements.
- UPDATE statements.
- DELETE statements.
- JOIN operations.
- GROUP BY.
- ORDER BY.
- HAVING.
- Subqueries.
- CTEs.
- Window functions.
- Temporary tables.
- Table variables.
- Dynamic SQL.

### 8.1 Query Design Concerns

Look for:

- `SELECT *` in stable application interfaces.
- Unnecessary columns.
- Missing filtering.
- Non-sargable predicates.
- Functions applied to indexed filter columns.
- Implicit conversions.
- Unnecessary DISTINCT.
- Repeated correlated subqueries.
- Excessive nested queries.
- Large unbounded result sets.
- Missing pagination where appropriate.
- Incorrect join conditions.
- Unnecessary sorting.

Do not classify a query as slow based on syntax alone.

### 8.2 Parameterization

Check whether SQL statements use parameters rather than string concatenation.

Example:

```sql
SELECT *
FROM dbo.Users
WHERE Email = @Email;
```

Potential risks:

- Concatenating untrusted input into SQL.
- Dynamic SQL without safe parameterization.
- Incorrect parameter types.
- Inconsistent parameter lengths.
- Unnecessary implicit conversions.

Distinguish SQL injection risk from ordinary query inefficiency.

### 8.3 Pagination

Inspect pagination patterns:

- `OFFSET ... FETCH`.
- Keyset pagination.
- `ROW_NUMBER()`.
- ORM-generated pagination.

Check:

- Stable ordering.
- Appropriate filtering.
- Large offset concerns.
- Whether total-count queries are necessary.

Do not require pagination for small, bounded lookup tables without justification.

---

## 9. Performance and Execution Plans

Static analysis can identify possible performance risks, but actual performance requires runtime evidence.

When authorized execution-plan files or captured plans are available, inspect:

- Actual execution plan.
- Estimated execution plan.
- Table scans.
- Index seeks.
- Key lookups.
- Sort operations.
- Hash matches.
- Nested loops.
- Memory grants.
- Spills to tempdb.
- Cardinality estimates.
- Parallelism.
- Warnings.

### 9.1 Query Performance Evidence

Look for available evidence:

- Query Store reports.
- Actual execution plans.
- Estimated execution plans.
- Query duration logs.
- Logical reads.
- CPU time.
- Wait statistics.
- Database monitoring reports.

Do not invent execution metrics.

### 9.2 Common Performance Risks

Potential areas:

- Large table scans.
- Missing or unsuitable indexes.
- Excessive key lookups.
- Parameter-sensitive plans.
- Implicit conversions.
- Expensive sorts.
- Large memory grants.
- Tempdb pressure.
- Lock contention.
- Long-running transactions.
- Excessive round trips.
- N+1 application queries.

Mark every finding as either:

- Confirmed by runtime evidence.
- Potential risk from static inspection.
- Requires measurement.

Never present a static suspicion as a measured performance problem.

---

## 10. Transactions, Locking, and Concurrency

Inspect transaction behavior in SQL scripts and application code.

Review:

- `BEGIN TRANSACTION`
- `COMMIT`
- `ROLLBACK`
- `TRY...CATCH`
- `XACT_STATE()`
- Isolation levels.
- Explicit locking hints.
- Deadlock handling.
- Optimistic concurrency.
- Row versioning.

### 10.1 Isolation Levels

Identify relevant levels:

- READ UNCOMMITTED.
- READ COMMITTED.
- REPEATABLE READ.
- SERIALIZABLE.
- SNAPSHOT.

Check whether isolation behavior is configured explicitly or inherited from database settings.

### 10.2 Locking Concerns

Inspect potential risks:

- Long-running transactions.
- Excessive lock duration.
- Unnecessary locking hints.
- Deadlock-prone access patterns.
- Large update operations.
- Concurrent modification conflicts.

Do not claim a deadlock exists without deadlock graphs, logs, or other runtime evidence.

### 10.3 Row Versioning

Inspect:

- `rowversion`.
- Snapshot isolation configuration.
- Read committed snapshot configuration.

Distinguish the SQL Server `rowversion` data type from a date/time value.

---

## 11. Security Analysis

Inspect database-related security configuration when evidence is available.

Review:

- SQL authentication.
- Windows authentication.
- Database users.
- Server logins.
- Roles.
- Object permissions.
- Schema permissions.
- Stored procedure permissions.
- Encryption configuration.
- Dynamic SQL.
- Sensitive columns.

Potential risks:

- Credentials committed to source control.
- Excessive permissions.
- Use of `sysadmin` or `db_owner` where unnecessary.
- Unsafe dynamic SQL.
- Sensitive data stored without appropriate protection.
- Overly broad access to database objects.
- Unencrypted connection configuration where secure transport is required.

Do not expose credentials or sensitive data.

Do not attempt to authenticate to the database or change permissions.

For broader application security, use:

`references/security-analysis.md`

---

## 12. Backup, Recovery, and Maintenance

Inspect available documentation and configuration related to:

- Full backups.
- Differential backups.
- Transaction log backups.
- Recovery models.
- Backup retention.
- Restore procedures.
- Integrity checks.
- Index maintenance.
- Statistics updates.
- Database maintenance plans.

Possible recovery models:

- SIMPLE.
- FULL.
- BULK_LOGGED.

Check whether backup and recovery procedures are documented.

Do not assume that backup configuration exists because a SQL Server instance supports backups.

Do not run:

- BACKUP DATABASE.
- RESTORE DATABASE.
- DBCC CHECKDB.
- Index rebuilds.
- Index reorganizations.
- Statistics updates.
- Database maintenance jobs.

These operations require separate authorization and appropriate operational planning.

---

## 13. SQL Server Features and Database Configuration

Identify the use of relevant SQL Server features:

- Identity columns.
- Sequences.
- Computed columns.
- Temporal tables.
- Partitioning.
- Full-Text Search.
- Change Data Capture (CDC).
- Change Tracking.
- Service Broker.
- Row-Level Security.
- Dynamic Data Masking.
- Always Encrypted.
- Transparent Data Encryption (TDE).
- SQL Server Agent.
- Query Store.

For each identified feature, document:

- Where it is used.
- Its apparent purpose.
- Available configuration evidence.
- Potential dependencies.

Do not assume a feature is enabled merely because the server version supports it.

---

## 14. Database Design and Normalization

Evaluate database design at a practical level.

Inspect:

- Repeated data.
- Denormalized structures.
- Table responsibilities.
- Entity boundaries.
- Relationship consistency.
- Naming conventions.
- Audit columns.
- Lookup/reference tables.
- Status columns.
- Historical data requirements.

Consider:

- First Normal Form (1NF).
- Second Normal Form (2NF).
- Third Normal Form (3NF).
- Intentional denormalization.

Identify potential anomalies:

- Update anomalies.
- Insert anomalies.
- Delete anomalies.
- Unnecessary duplication.
- Inconsistent reference data.

Do not recommend normalization changes without considering reporting requirements, workload, and business rules.

---

## 15. Data Integrity and Constraints

Inspect:

- Primary key constraints.
- Foreign key constraints.
- Unique constraints.
- Check constraints.
- Default constraints.
- NOT NULL constraints.
- Triggers used for integrity enforcement.

Check whether critical business rules are enforced only in application code or also protected at the database level where appropriate.

Distinguish:

- Database-enforced integrity.
- Application-enforced validation.
- Business rules requiring human confirmation.

Do not assume that missing database constraints automatically indicate a defect. Some rules may intentionally be enforced at another layer.

---

## 16. Migration and Schema Versioning

Identify the database schema management approach.

Possible approaches:

- EF Core Migrations.
- EF6 Migrations.
- DbUp.
- FluentMigrator.
- Flyway.
- Liquibase.
- SSDT.
- DACPAC.
- Manual SQL scripts.

Inspect:

- Migration history files.
- Naming conventions.
- Migration ordering.
- Schema snapshots.
- Seed data.
- Rollback scripts.
- Deployment scripts.

Check:

- Whether schema changes are version-controlled.
- Whether migrations appear consistent.
- Whether scripts are repeatable or environment-dependent.
- Whether destructive operations are present.
- Whether migration history appears incomplete.

Do not apply, generate, modify, or rollback migrations.

---

## 17. SQL Server Integration with Application Code

Inspect how the application accesses SQL Server.

Possible approaches:

- Entity Framework Core.
- Entity Framework 6.
- ADO.NET.
- Dapper.
- JDBC.
- Stored Procedure calls.
- Raw SQL.
- Multiple access methods.

Identify:

- Database context classes.
- Connection management.
- Transaction management.
- Parameter handling.
- Query execution.
- Stored Procedure invocation.
- Mapping of database results.
- Error handling.

Check:

- Connection lifetime and disposal.
- Async database operations.
- Parameterized queries.
- Transaction boundaries.
- Repeated database round trips.
- Data access duplication.

Do not assume the application uses EF Core just because it references a SQL Server provider package.

---

## 18. Technical Debt and Risk Prioritization

Identify possible database technical debt:

- Missing constraints.
- Inconsistent naming.
- Duplicate indexes.
- Unclear relationships.
- Oversized columns.
- Inappropriate data types.
- Complex stored procedures.
- Unparameterized dynamic SQL.
- Unversioned schema changes.
- Missing backup documentation.
- Unclear transaction behavior.
- Potentially expensive queries.
- Weak access control.

Prioritize findings:

- P0: Critical risk requiring immediate attention.
- P1: High-priority integrity, security, or reliability concern.
- P2: Medium-priority maintainability or performance concern.
- P3: Low-priority improvement.

Do not assign P0 or P1 based only on stylistic preferences.

Every significant finding must include:

1. Description.
2. Evidence.
3. Database object or application file.
4. Potential impact.
5. Confidence level.
6. Recommended investigation.

---

## 19. Evidence and Confidence

Use these classifications in the final Persian report:

- تأییدشده: Directly supported by schema, SQL, configuration, or runtime evidence.
- استنباط‌شده: Strongly inferred from multiple pieces of evidence.
- نیازمند تأیید توسعه‌دهنده: Requires business or environment knowledge.
- قابل بررسی: Potential issue requiring additional investigation.

For performance findings, also distinguish:

- Static inspection.
- Execution-plan evidence.
- Runtime measurements.

Whenever possible, reference:

- SQL file paths.
- Schema names.
- Table names.
- Column names.
- Constraint names.
- Index names.
- Procedure names.
- Query fragments.
- Migration files.

Never invent database objects, metrics, or configuration.

---

## 20. Read-Only Analysis Rules

During this analysis:

- Do not modify database schema.
- Do not execute INSERT, UPDATE, DELETE, or MERGE.
- Do not execute migrations.
- Do not create or drop tables.
- Do not create, alter, or drop indexes.
- Do not modify stored procedures or functions.
- Do not change database permissions.
- Do not connect to production databases.
- Do not expose credentials.
- Do not run maintenance operations.
- Do not perform backup or restore operations.
- Do not run destructive or resource-intensive queries.
- Do not change application source code.

If live database inspection is necessary, request explicit authorization and use a read-only account with an agreed scope.

Read available repository files and documentation only unless additional access is explicitly authorized.

---

## 21. Expected Analysis Output

Provide a Persian report with the following sections:

1. معرفی دیتابیس و نسخه SQL Server
2. شواهد شناسایی دیتابیس
3. روش اتصال برنامه به دیتابیس
4. فهرست Schemaها و اشیای دیتابیس
5. ساختار جداول و ستون‌های مهم
6. Primary Key و Foreign Key
7. روابط و Referential Integrity
8. بررسی Data Types و Nullability
9. Indexها و ساختار آن‌ها
10. Viewها و Stored Procedureها
11. تحلیل Queryها و T-SQL
12. ملاحظات Performance
13. Transaction و Concurrency
14. امنیت و سطح دسترسی
15. Backup و Recovery
16. قابلیت‌های ویژه SQL Server
17. Normalization و Data Integrity
18. Migration و Schema Versioning
19. بدهی فنی و ریسک‌ها
20. موارد نیازمند بررسی بیشتر
21. پیشنهادهای اولویت‌بندی‌شده

For every important technical conclusion, include its evidence.

Keep the report factual, specific, and actionable.

Do not generate or update project documentation until the user approves the proposed documentation changes.
