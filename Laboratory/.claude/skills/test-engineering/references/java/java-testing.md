

\# Java Testing



\## 1. Supported Ecosystem



Support:



\- Java

\- Spring Framework

\- Spring Boot

\- Spring MVC

\- Spring Security

\- Spring Data JPA

\- Hibernate

\- JPA

\- Maven

\- Gradle



Default database ecosystem: Oracle Database.



\## 2. Repository Discovery



Inspect:



\- pom.xml

\- build.gradle

\- build.gradle.kts

\- settings.gradle

\- gradle.properties

\- Maven Wrapper

\- Gradle Wrapper



Identify:



\- JDK version

\- Java version

\- Spring version

\- Spring Boot version

\- Hibernate version

\- JPA version

\- Oracle JDBC driver

\- Existing test framework



\## 3. Testing Frameworks



Supported:



\- JUnit 5

\- JUnit 4 for legacy projects



Prefer JUnit 5 for new projects when compatible.



Reuse the existing framework when possible.



\## 4. Supporting Libraries



Consider:



\- Mockito

\- AssertJ

\- Spring Test

\- Spring Boot Test

\- Spring Security Test

\- JaCoCo

\- Testcontainers



Verify compatibility before recommending new dependencies.



\## 5. Testing Priorities



Prioritize:



1\. Domain logic

2\. Validators

3\. Service classes

4\. Business rules

5\. Repository behavior

6\. JPA mappings

7\. Spring configuration

8\. REST endpoints

9\. Security

10\. Oracle integration

11\. External integrations



\## 6. Build Commands



Discover the actual build system.



Common Maven commands:



./mvnw test



mvn test



Common Gradle commands:



./gradlew test



gradle test



Do not assume wrapper files exist.



\## 7. Compatibility



Verify compatibility among:



\- JDK

\- Spring Framework

\- Spring Boot

\- Hibernate

\- JPA

\- Oracle JDBC

\- JUnit

\- Maven or Gradle plugins



Do not upgrade dependencies without approval.



