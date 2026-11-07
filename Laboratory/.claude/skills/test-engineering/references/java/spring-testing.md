

\# Spring Framework and Spring Boot Testing



\## 1. Unit Testing



Use plain JUnit tests for classes that do not require Spring context.



Test:



\- Domain logic

\- Service behavior

\- Business rules

\- Validation

\- Calculations

\- Error handling



Use Mockito for external dependencies where appropriate.



Do not start a full Spring context for every unit test.



\## 2. Spring Context Testing



Use Spring Test and Spring Boot Test when testing:



\- Dependency injection

\- Bean configuration

\- Application context

\- Configuration properties

\- Profiles

\- Conditional beans

\- Framework integration



\## 3. Spring MVC Testing



Where compatible, use:



\- MockMvc

\- WebTestClient



Test:



\- Request mapping

\- Validation

\- Serialization

\- HTTP status codes

\- Exception handling

\- Filters

\- Interceptors



\## 4. Integration Testing



Use real Spring components when framework behavior matters.



Do not replace the entire application context with mocks and call the result an integration test.



\## 5. Transaction Testing



Understand:



\- Transaction boundaries

\- Propagation

\- Isolation

\- Rollback behavior

\- Commit behavior



A test that automatically rolls back does not necessarily prove production transaction behavior.



\## 6. External HTTP Services



Use controlled clients or mock servers for isolated tests.



Test:



\- Successful responses

\- Error responses

\- Timeouts

\- Invalid payloads

\- Retry behavior



\## 7. Version Compatibility



Spring Framework 6 and Spring Boot 3 introduce different JDK and Jakarta requirements compared with older generations.



Detect the actual project version.



Never migrate javax packages to jakarta packages or upgrade Spring as an incidental testing change.



