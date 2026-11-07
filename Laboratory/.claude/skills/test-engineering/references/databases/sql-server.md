

\# SQL Server Test Environment



This reference applies to the .NET ecosystem.



\## 1. Environment Discovery



Identify:



\- SQL Server version

\- SQL Server edition

\- Database provider

\- Authentication mechanism

\- Schema

\- Migration mechanism

\- Available test databases



Check whether the environment supports:



\- SQL Server LocalDB

\- SQL Server service

\- Dedicated test database

\- Docker

\- Testcontainers



Never assume these are installed.



\## 2. Recommended Test Environments



Depending on project compatibility:



\### SQL Server LocalDB



Useful for supported Windows development environments.



Verify compatibility with the project's SQL Server provider.



\### Dedicated Test Database



Use an isolated SQL Server database with dedicated test credentials.



\### Testcontainers



Consider only when Docker, image availability, licensing, SQL Server version, and CI support are verified.



\## 3. SQL Server-Specific Testing



Use real SQL Server for:



\- T-SQL

\- Stored Procedures

\- Functions

\- Views

\- Triggers

\- Constraints

\- Transactions

\- Isolation Levels

\- Locking

\- Deadlocks

\- SQL Server data types

\- Provider-specific query translation



\## 4. Safety



Never connect to production.



Never expose connection strings.



Obtain approval before:



\- Creating databases

\- Dropping databases

\- Running migrations

\- Modifying schemas

\- Executing destructive scripts

\- Cleaning shared test data



Use unique test records and reliable cleanup.



\## 5. Reporting



If SQL Server is unavailable, clearly report provider-specific tests as blocked or not run.



Do not claim that mocked repositories or EF InMemory tests prove SQL Server compatibility.



