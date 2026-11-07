

\# Java Persistence Testing — Oracle



\## 1. Supported Technologies



Identify:



\- JPA

\- Hibernate

\- Spring Data JPA

\- Oracle JDBC

\- JPQL

\- Criteria API

\- Native SQL

\- Stored Procedures

\- PL/SQL



Identify exact versions and database dialect.



\## 2. Unit Testing



Test domain logic and service decisions independently from persistence when possible.



Do not start Hibernate unnecessarily for pure business logic.



\## 3. Spring Data JPA Testing



Where compatible, consider:



@DataJpaTest



Test:



\- Repository methods

\- Entity mappings

\- Relationships

\- Query behavior

\- Pagination

\- Sorting

\- Null handling

\- Persistence behavior



\## 4. Hibernate Testing



Where relevant, test:



\- Entity lifecycle

\- Change tracking

\- Dirty checking

\- Lazy loading

\- Eager loading

\- Cascade operations

\- Orphan removal

\- Optimistic locking

\- Relationship mappings



\## 5. Oracle Database Testing



Use an isolated Oracle database for Oracle-specific behavior.



H2 is not Oracle.



Do not assume H2 reproduces:



\- Oracle SQL dialect

\- Oracle data types

\- Sequences

\- PL/SQL

\- Packages

\- Triggers

\- Locking

\- Transaction behavior



\## 6. Oracle Scenarios



Where applicable, test:



\- Sequences

\- Identity generation

\- PL/SQL procedures

\- Functions

\- Packages

\- Triggers

\- Views

\- Constraints

\- Native SQL

\- JDBC parameter mapping

\- Transactions

\- Rollback

\- Isolation

\- Locking

\- Concurrency



\## 7. Testcontainers



Consider Oracle Testcontainers only after verifying:



\- Docker availability

\- Oracle image availability

\- Licensing requirements

\- Version compatibility

\- CI support



Do not assume a container environment is available.



\## 8. Database Safety



Never use production databases.



Use isolated schemas and test credentials.



Obtain approval before schema changes, migrations, destructive cleanup, or database creation.



