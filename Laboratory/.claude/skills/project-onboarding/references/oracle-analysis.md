
# Oracle Database Analysis Reference

## 1. Purpose

This reference defines the analysis procedure for databases running on Oracle Database.

It applies to:

- Oracle Database
- Oracle Database Express Edition (XE)
- Oracle Database Free
- Oracle Database Standard Edition
- Oracle Database Enterprise Edition
- Oracle Cloud Infrastructure (OCI) Oracle Database services
- Oracle Autonomous Database
- Oracle Database accessed through JDBC
- Oracle Database accessed through Hibernate/JPA
- Oracle Database accessed through Spring Data JPA
- Oracle Database accessed through .NET providers

The purpose is to understand the database architecture, schemas, tables, relationships, indexes, PL/SQL objects, queries, security, and potential performance risks.

This reference is for read-only analysis and documentation. It does not authorize database modifications.

---

## 2. Database Identification

Identify whether the repository actually uses Oracle Database.

Inspect:

- JDBC connection URLs.
- Database connection strings.
- Oracle JDBC dependencies.
- Oracle .NET provider packages.
- Hibernate dialect configuration.
- JPA configuration.
- SQL scripts.
- PL/SQL source files.
- Migration files.
- Docker Compose configuration.
- Deployment configuration.

### 2.1 Common Oracle Evidence

Look for:

- `ojdbc8`
- `ojdbc11`
- `ojdbc17`
- `oracle.jdbc.OracleDriver`
- `jdbc:oracle:thin:`
- `Oracle.ManagedDataAccess`
- `Oracle.EntityFrameworkCore`
- `UseOracle`
- Oracle Hibernate dialect declarations.
- Oracle-specific SQL syntax.
- PL/SQL blocks.

### 2.2 Database Environment

Identify, when available:

- Oracle Database version.
- Edition.
- Hosting model.
- Container Database (CDB) configuration.
- Pluggable Database (PDB) configuration.
- Service name.
- Schema names.
- Environment-specific settings.

Possible hosting models:

- Local Oracle installation.
- Oracle Database Free.
- Oracle Database XE.
- Docker container.
- Dedicated server.
- Virtual machine.
- Oracle Cloud Infrastructure.
- Autonomous Database.

Do not infer the exact database edition or version from a JDBC driver version.

### 2.3 Connection Configuration

Inspect:

- JDBC URLs.
- Application properties.
- Application YAML files.
- Environment variables.
- External configuration.
- .NET configuration files.
- User Secrets.
- Docker configuration.

Common Oracle connection URL patterns:

```text
jdbc:oracle:thin:@//hostname:1521/service_name
```

```text
jdbc:oracle:thin:@hostname:1521:SID
```

Identify:

- Host.
- Port.
- Service name or SID.
- Connection mode.
- Driver configuration.

Never print passwords, tokens, or secret values in reports.

Redact sensitive connection information.

---

## 3. Oracle Database Architecture

Understand the distinction between the main Oracle database concepts.

### 3.1 Database, Instance, and Schema

Document the concepts relevant to the project:

**Database**
- Physical database files and logical database structure.

**Instance**
- Memory structures and background processes used to manage database operations.

**Schema**
- Logical collection of objects owned by a database user.

Do not treat a schema as a separate physical database.

### 3.2 CDB and PDB

For multitenant environments, identify:

- Container Database (CDB).
- Pluggable Databases (PDB).
- Application connection target.
- Relevant container configuration.

Do not assume a project uses a multitenant architecture without evidence.

### 3.3 Tablespaces

When schema or database metadata is available, identify:

- Tablespaces.
- Data files.
- Temporary tablespaces.
- Undo tablespaces.
- Default tablespace assignments.
- Quotas, if visible.

Do not assume tablespace configuration from application connection strings.

---

## 4. Schema and Object Inventory

Identify available Oracle schema information.

Possible sources:

- `.sql` files.
- `.pks` files.
- `.pkb` files.
- `.pls` files.
- Migration scripts.
- Flyway migrations.
- Liquibase changelogs.
- Database exports.
- Existing database documentation.
- Authorized read-only schema inspection, if separately permitted.

Create an object inventory:

| Object Type | Object Name | Schema | Purpose |
|---|---|---|---|
| TABLE | ExampleTable | APP_SCHEMA | Example description |
| VIEW | ExampleView | APP_SCHEMA | Example description |
| PACKAGE | ExamplePackage | APP_SCHEMA | Example description |

Identify:

- Tables.
- Views.
- Materialized Views.
- Sequences.
- Synonyms.
- Indexes.
- Constraints.
- Procedures.
- Functions.
- Packages.
- Package Bodies.
- Triggers.
- Database Links.
- Types.
- Directories.
- Jobs.
- Scheduler objects.

Only report objects supported by available evidence.

If no schema definitions are available, state that the complete database structure cannot be confirmed.

---

## 5. Table and Column Analysis

For each important table, inspect:

- Table name.
- Owner/schema.
- Column names.
- Data types.
- Data lengths.
- Precision.
- Scale.
- Nullability.
- Default values.
- Virtual columns.
- Identity columns.
- Comments.
- Partitioning information, if available.

Create a table inventory:

| Table | Primary Key | Important Columns | Relationships | Notes |
|---|---|---|---|---|

### 5.1 Oracle Data Types

Identify relevant Oracle types:

- `NUMBER`
- `VARCHAR2`
- `NVARCHAR2`
- `CHAR`
- `NCHAR`
- `DATE`
- `TIMESTAMP`
- `TIMESTAMP WITH TIME ZONE`
- `TIMESTAMP WITH LOCAL TIME ZONE`
- `CLOB`
- `NCLOB`
- `BLOB`
- `RAW`
- `LONG RAW`
- `BINARY_FLOAT`
- `BINARY_DOUBLE`
- `XMLTYPE`
- `JSON` where supported by the database version.

Check:

- Incorrect precision or scale.
- Insufficient character length.
- Unicode requirements.
- Date/time handling.
- Large object storage.
- Numeric values used for identifiers.
- Inconsistent type usage across related columns.

Important Oracle considerations:

- Oracle `DATE` stores both date and time components.
- `VARCHAR2` is not equivalent to SQL Server `NVARCHAR`.
- `NUMBER(p,s)` precision and scale must be considered.
- Empty string handling differs from many other database engines.

Do not recommend type changes without understanding application requirements and existing data.

### 5.2 Identity and Key Strategy

Inspect:

- Primary keys.
- Composite keys.
- Natural keys.
- Surrogate keys.
- Identity columns.
- Sequences.
- Sequence-based ID generation.
- Hibernate ID generation strategies.

Check whether identifier generation is consistent between the application and database.

Do not assume that every Oracle primary key uses a sequence.

---

## 6. Relationships and Referential Integrity

Inspect:

- Primary key constraints.
- Foreign key constraints.
- Unique constraints.
- Check constraints.
- Self-referencing relationships.
- Many-to-many junction tables.

Identify:

- One-to-one relationships.
- One-to-many relationships.
- Many-to-many relationships.
- Required relationships.
- Optional relationships.
- Referential actions.

### 6.1 Constraint Analysis

Review:

- `PRIMARY KEY`
- `FOREIGN KEY`
- `UNIQUE`
- `CHECK`
- `NOT NULL`

Check:

- Whether important relationships are enforced.
- Whether related columns use compatible data types.
- Whether foreign keys are indexed where workload justifies it.
- Whether constraints are disabled or not validated, if metadata is available.
- Whether business rules exist only in application code.

Do not claim that an ORM relationship proves a physical foreign key exists.

### 6.2 Delete Behavior

Inspect:

- `ON DELETE CASCADE`
- `ON DELETE SET NULL`
- Application-managed deletion.
- Soft-delete patterns.

Check whether delete behavior is consistent with business rules.

Do not assume Oracle supports the same referential actions as SQL Server.

---

## 7. Index Analysis

Identify:

- B-tree indexes.
- Unique indexes.
- Composite indexes.
- Bitmap indexes.
- Function-based indexes.
- Reverse key indexes.
- Domain indexes.
- Partitioned indexes.
- Local indexes.
- Global indexes.

### 7.1 Index Structure

For each important index, document:

- Index name.
- Table name.
- Owner.
- Index type.
- Key columns.
- Column order.
- Uniqueness.
- Partitioning information.
- Function expressions, if applicable.

Example:

```sql
CREATE INDEX IDX_ORDERS_CUSTOMER_DATE
ON ORDERS (CUSTOMER_ID, ORDER_DATE);
```

### 7.2 Index Review

Inspect potential concerns:

- Missing indexes on frequently filtered or joined columns.
- Duplicate indexes.
- Overlapping indexes.
- Excessive indexing on write-heavy tables.
- Incorrect composite index order.
- Function-based filtering without a suitable index.
- Bitmap indexes used in unsuitable high-concurrency workloads.

Important limitations:

- Schema inspection alone cannot prove that an index is missing.
- Index usage requires workload and usage statistics.
- Index selectivity and clustering factor require metadata or runtime evidence.
- An index that appears redundant may support another workload.

Do not create, rebuild, or drop indexes.

---

## 8. Sequences and Identifier Generation

Oracle applications frequently use sequences for primary key generation.

Inspect:

- Sequence definitions.
- Start values.
- Increment values.
- Minimum and maximum values.
- Cache settings.
- Cycle configuration.
- Sequence ownership.
- Application usage.

Common SQL:

```sql
CREATE SEQUENCE SEQ_USERS
START WITH 1
INCREMENT BY 1
NOCACHE;
```

Check whether application identifier generation matches the database strategy.

For Hibernate/JPA, inspect:

- `@SequenceGenerator`
- `@GeneratedValue`
- `GenerationType.SEQUENCE`
- Sequence names.
- Allocation size.
- Generator configuration.

Potential concerns:

- Incorrect sequence name.
- Allocation-size mismatch.
- Duplicate generator definitions.
- Application and database generation strategies that conflict.

Do not assume that sequence values are gap-free.

Do not call `NEXTVAL` or modify sequence configuration during read-only analysis.

---

## 9. Views and Materialized Views

Identify:

- Regular Views.
- Materialized Views.
- Materialized View Logs.
- Refresh configuration.
- Dependencies between views.

For each important view, inspect:

- Definition.
- Referenced tables.
- Joins.
- Filters.
- Aggregations.
- Nested views.
- Security-related options.

For materialized views, identify:

- Refresh mode.
- Refresh method.
- Refresh schedule.
- Query rewrite configuration, if available.
- Dependencies.

Do not assume a materialized view is refreshed automatically.

---

## 10. PL/SQL Analysis

Identify the use of PL/SQL objects:

- Procedures.
- Functions.
- Packages.
- Package Bodies.
- Triggers.
- Anonymous PL/SQL blocks.
- Types.
- Cursors.
- Exception handlers.

### 10.1 Stored Procedures

For each important procedure, inspect:

- Input parameters.
- Output parameters.
- IN OUT parameters.
- Return behavior.
- Referenced tables.
- Referenced packages.
- Transactions.
- Exception handling.
- Dynamic SQL.
- Cursor usage.

Check:

- Excessive procedural complexity.
- Repeated queries.
- Unnecessary row-by-row operations.
- Missing exception handling.
- Unsafe dynamic SQL.
- Hidden dependencies.
- Unclear transaction boundaries.

### 10.2 Functions

Inspect:

- Function parameters.
- Return types.
- Deterministic declarations.
- Referenced objects.
- SQL-callable usage.
- Side effects where relevant.

Check whether functions are used in large queries in ways that could affect performance.

Do not assume every PL/SQL function is slow.

### 10.3 Packages

For each important package, inspect:

- Package specification.
- Package body.
- Public procedures.
- Public functions.
- Private routines.
- Global variables.
- Dependencies.
- Exception handling.

Determine whether package responsibilities are clear and cohesive.

### 10.4 Triggers

Inspect trigger types:

- BEFORE.
- AFTER.
- INSTEAD OF.
- Row-level triggers.
- Statement-level triggers.
- Compound triggers.

Check:

- Trigger timing.
- Referenced tables.
- Recursive behavior.
- Hidden business logic.
- Audit behavior.
- Unexpected side effects.
- Mutating-table risks.

Do not execute triggers or modify their definitions.

---

## 11. SQL and Query Analysis

Inspect available SQL and PL/SQL source.

Review:

- SELECT.
- INSERT.
- UPDATE.
- DELETE.
- MERGE.
- JOIN.
- GROUP BY.
- ORDER BY.
- HAVING.
- Subqueries.
- Common Table Expressions.
- Analytic functions.
- Hierarchical queries.
- Dynamic SQL.

### 11.1 Query Design Concerns

Look for:

- `SELECT *` in stable application interfaces.
- Unnecessary columns.
- Missing filters.
- Functions applied to indexed filter columns.
- Implicit conversions.
- Unnecessary DISTINCT.
- Repeated correlated subqueries.
- Excessive nested queries.
- Large unbounded result sets.
- Missing pagination where appropriate.
- Incorrect joins.
- Unnecessary sorting.

Do not classify a query as slow based on syntax alone.

### 11.2 Bind Variables

Inspect whether queries use bind variables.

Example:

```sql
SELECT *
FROM USERS
WHERE EMAIL = :email;
```

Potential concerns:

- Dynamic SQL created through string concatenation.
- Missing bind variables.
- SQL injection.
- Incorrect parameter types.
- Excessive literal SQL variation.

Distinguish SQL injection risks from query performance concerns.

### 11.3 Pagination

Inspect Oracle pagination patterns:

- `OFFSET ... FETCH`.
- `ROWNUM`.
- `ROW_NUMBER()`.
- Keyset pagination.
- ORM-generated pagination.

Consider database version compatibility.

Check:

- Stable ordering.
- Large offset concerns.
- Filtering efficiency.
- Whether total-count queries are necessary.

Do not require pagination for small, bounded lookup tables without justification.

---

## 12. Execution Plans and Performance

Static analysis can identify possible performance risks, but actual performance requires runtime evidence.

When authorized execution-plan files or captured plans are available, inspect:

- `EXPLAIN PLAN`.
- `DBMS_XPLAN`.
- Actual cursor execution plans.
- Estimated cardinality.
- Actual rows.
- Access paths.
- Join methods.
- Predicate information.
- Cost estimates.
- Partition pruning.
- Parallel execution.

### 12.1 Common Access Paths

Identify:

- TABLE ACCESS FULL.
- INDEX RANGE SCAN.
- INDEX UNIQUE SCAN.
- INDEX FULL SCAN.
- INDEX FAST FULL SCAN.
- TABLE ACCESS BY INDEX ROWID.

Do not automatically classify a full table scan as a defect. It can be appropriate for small tables or queries returning a large proportion of rows.

### 12.2 Join Methods

Identify:

- Nested Loops.
- Hash Join.
- Sort Merge Join.

Evaluate whether the execution plan appears reasonable for the query and available evidence.

### 12.3 Performance Evidence

Look for:

- Actual execution plans.
- AWR reports, if available and authorized.
- ASH reports, if available and authorized.
- SQL Monitor reports.
- Query execution statistics.
- Database monitoring reports.
- Application logs.
- Wait event information.

Do not assume access to Oracle Diagnostic Pack or Tuning Pack features. Licensing and authorization must be verified before using related facilities.

Do not invent execution metrics.

### 12.4 Common Performance Risks

Potential areas:

- Full scans on large tables.
- Inefficient index usage.
- Poor cardinality estimates.
- Implicit conversions.
- Excessive context switching between SQL and PL/SQL.
- Row-by-row processing.
- Expensive correlated subqueries.
- Unnecessary sorting.
- Excessive database round trips.
- Poor connection pool configuration.
- Long-running transactions.

Classify findings as:

- Confirmed by runtime evidence.
- Potential risk from static inspection.
- Requires measurement.

---

## 13. Transactions and Concurrency

Inspect transaction behavior in SQL and application code.

Review:

- `COMMIT`.
- `ROLLBACK`.
- `SAVEPOINT`.
- Transaction boundaries.
- Isolation behavior.
- Locking.
- Deadlock handling.
- Optimistic concurrency.
- Pessimistic locking.

### 13.1 Transaction Behavior

Check:

- Whether transactions match business operations.
- Whether transaction boundaries are clear.
- Whether commits occur at appropriate points.
- Whether external service calls occur inside database transactions.
- Whether rollback behavior is handled correctly.

Remember that Oracle transaction behavior differs from SQL Server, including transaction control and read consistency.

### 13.2 Locking and Concurrency

Inspect:

- `SELECT ... FOR UPDATE`.
- Row-level locking.
- Table locking.
- Explicit lock statements.
- Long-running transactions.
- Concurrent update patterns.

Potential risks:

- Lock contention.
- Deadlocks.
- Long-held locks.
- Excessive serialization of operations.
- Lost update scenarios.

Do not claim that a deadlock or blocking problem exists without runtime evidence.

### 13.3 MVCC and Read Consistency

Consider Oracle's multiversion concurrency control (MVCC).

Inspect whether the application relies on:

- Statement-level read consistency.
- Transaction isolation settings.
- Serializable transactions.
- Explicit locking.

Do not confuse Oracle's default read consistency behavior with SQL Server's default isolation behavior.

---

## 14. Security Analysis

Inspect available database security configuration.

Review:

- Database users.
- Roles.
- System privileges.
- Object privileges.
- Schema ownership.
- Profiles.
- Password policy configuration.
- Network encryption.
- Transparent Data Encryption.
- Data Redaction.
- Virtual Private Database.
- Auditing.
- Database links.
- Dynamic SQL.

Potential risks:

- Excessive privileges.
- Application connecting as a highly privileged account.
- Credentials committed to source control.
- Unsafe dynamic SQL.
- Sensitive data exposed in scripts or logs.
- Insecure connection settings.
- Unnecessary public synonyms.
- Overly broad object grants.

Do not expose credentials or sensitive data.

Do not connect to the database or modify permissions.

For broader application security, use:

`references/security-analysis.md`

---

## 15. Tablespaces, Storage, and Partitioning

When metadata is available, inspect:

- Tablespaces.
- Data files.
- Temporary tablespaces.
- Undo tablespaces.
- Segment allocation.
- Extents.
- Table partitioning.
- Index partitioning.
- LOB storage.

### 15.1 Partitioning

Identify:

- Range partitioning.
- List partitioning.
- Hash partitioning.
- Composite partitioning.
- Interval partitioning.

Check:

- Partition keys.
- Partition boundaries.
- Local indexes.
- Global indexes.
- Partition pruning opportunities.

Do not assume that partitioning is beneficial for every large table.

### 15.2 LOB Storage

Inspect:

- CLOB.
- NCLOB.
- BLOB.
- LOB storage configuration.
- SecureFiles or BasicFiles, if identifiable.

Identify potential large-object access and storage concerns.

Do not modify storage settings.

---

## 16. Backup, Recovery, and Maintenance

Inspect available documentation and configuration for:

- RMAN.
- Full backups.
- Incremental backups.
- Archived redo logs.
- Recovery procedures.
- Flashback Database.
- Data Pump.
- Export and import.
- Data Guard.
- Recovery objectives.

Identify:

- Backup approach.
- Backup retention.
- Recovery documentation.
- Archive log configuration.
- Disaster recovery approach.
- Maintenance responsibilities.

Do not assume backups exist because Oracle supports RMAN.

Do not execute:

- RMAN backup or restore commands.
- Data Pump export or import.
- Flashback operations.
- Recovery commands.
- Statistics gathering.
- Index rebuilds.
- Database maintenance operations.

These require separate authorization and operational planning.

---

## 17. Migration and Schema Versioning

Identify the schema management approach.

Possible tools:

- Flyway.
- Liquibase.
- DbUp.
- Manual SQL scripts.
- Custom migration framework.

Inspect:

- Migration file naming.
- Version ordering.
- Rollback scripts.
- Changelog definitions.
- Schema ownership.
- Seed data.
- Repeatable migrations.
- Environment-specific changes.

Check:

- Whether schema changes are version-controlled.
- Whether migration history appears consistent.
- Whether scripts contain destructive operations.
- Whether migrations depend on environment-specific assumptions.

Do not apply, generate, modify, or rollback migrations.

---

## 18. Oracle Integration with Application Code

Identify how the application accesses Oracle.

Possible approaches:

- JDBC.
- Hibernate.
- Spring Data JPA.
- JPA EntityManager.
- MyBatis.
- ADO.NET Oracle providers.
- Oracle EF Core provider.
- Stored Procedure calls.
- Raw SQL.

For Java applications, inspect:

- Oracle JDBC driver.
- DataSource configuration.
- Hibernate dialect.
- JPA configuration.
- Sequence generators.
- Transaction management.
- Connection pooling.

For .NET applications, inspect:

- `Oracle.ManagedDataAccess`.
- Oracle EF Core provider.
- Connection management.
- Parameter binding.
- Transaction management.
- Stored Procedure invocation.

Check:

- Connection lifetime and disposal.
- Parameterized statements.
- Transaction boundaries.
- Async database operations where supported.
- Repeated database round trips.
- Provider-specific behavior.

Do not assume that an Oracle dependency proves the application uses Oracle at runtime.

---

## 19. Technical Debt and Risk Prioritization

Identify potential database technical debt:

- Missing constraints.
- Inconsistent naming.
- Duplicate indexes.
- Unclear relationships.
- Incorrect data types.
- Unnecessary PL/SQL complexity.
- Unsafe dynamic SQL.
- Unclear transaction boundaries.
- Missing migration history.
- Inadequate backup documentation.
- Potentially expensive queries.
- Weak access control.
- Excessive privileges.
- Unclear schema ownership.

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

## 20. Evidence and Confidence

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

- Schema names.
- Table names.
- Column names.
- Constraint names.
- Index names.
- Sequence names.
- Package names.
- Procedure names.
- SQL file paths.
- Migration files.
- Configuration keys.

Never invent database objects, metrics, or configuration.

---

## 21. Read-Only Analysis Rules

During this analysis:

- Do not modify database schemas.
- Do not execute INSERT, UPDATE, DELETE, or MERGE.
- Do not execute PL/SQL procedures or functions.
- Do not execute migrations.
- Do not create or drop tables.
- Do not create, alter, or drop indexes.
- Do not modify packages or triggers.
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

## 22. Expected Analysis Output

Provide a Persian report with the following sections:

1. معرفی دیتابیس و نسخه Oracle
2. شواهد شناسایی Oracle
3. معماری Database، Instance، Schema و PDB
4. روش اتصال برنامه به Oracle
5. فهرست Schemaها و اشیای دیتابیس
6. ساختار جداول و ستون‌های مهم
7. Primary Key و Foreign Key
8. روابط و Referential Integrity
9. بررسی Data Types و Nullability
10. Indexها و ساختار آن‌ها
11. Sequenceها و روش تولید شناسه
12. Viewها و Materialized Viewها
13. Stored Procedureها، Functionها و Packageها
14. Triggerها
15. تحلیل SQL و PL/SQL
16. Execution Plan و ملاحظات Performance
17. Transaction و Concurrency
18. امنیت و سطح دسترسی
19. Tablespace، Storage و Partitioning
20. Backup و Recovery
21. Migration و Schema Versioning
22. بدهی فنی و ریسک‌ها
23. موارد نیازمند بررسی بیشتر
24. پیشنهادهای اولویت‌بندی‌شده

For every important technical conclusion, include its evidence.

Keep the report factual, specific, and actionable.

Do not generate or update project documentation until the user approves the proposed documentation changes.
