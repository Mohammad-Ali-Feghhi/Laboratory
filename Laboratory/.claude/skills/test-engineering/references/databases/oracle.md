

\# Oracle Database Test Environment



This reference applies to the Java and Spring ecosystem.



\## 1. Environment Discovery



Identify:



\- Oracle Database version

\- Oracle edition

\- Oracle JDBC driver

\- Hibernate dialect

\- JPA configuration

\- Authentication

\- Schema ownership

\- Migration mechanism



Verify whether an isolated Oracle test environment is available.



\## 2. Recommended Test Environments



\### Dedicated Oracle Test Database



Prefer an isolated test database or schema with dedicated credentials.



\### Oracle Testcontainers



Consider only after verifying:



\- Docker availability

\- Oracle image availability

\- Licensing requirements

\- Database version compatibility

\- CI environment support



\### In-Memory Databases



H2 may be useful for fast tests.



However, H2 is not Oracle.



Never treat successful H2 tests as proof of Oracle compatibility.



\## 3. Oracle-Specific Testing



Use real Oracle for:



\- Oracle SQL dialect

\- PL/SQL

\- Procedures

\- Functions

\- Packages

\- Sequences

\- Triggers

\- Views

\- Constraints

\- Oracle-specific data types

\- JDBC mappings

\- Transaction behavior

\- Locking

\- Concurrency



\## 4. Safety



Never connect to production.



Never expose connection strings or credentials.



Obtain approval before:



\- Creating schemas

\- Dropping schemas

\- Running migrations

\- Executing destructive scripts

\- Modifying database objects

\- Cleaning shared test data



Use isolated test data and deterministic cleanup.



\## 5. Reporting



If Oracle is unavailable, report Oracle-specific tests as blocked or not run.



Do not claim that H2 or mocked repositories prove Oracle compatibility.



