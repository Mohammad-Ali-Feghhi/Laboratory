

\# Spring Security Testing



\## 1. Discover Security Configuration



Identify:



\- Spring Security version

\- Authentication mechanism

\- Authorization mechanism

\- Session management

\- JWT configuration

\- OAuth2

\- Resource Server

\- Custom filters

\- Method-level security



\## 2. Authentication Tests



Test:



\- Anonymous requests

\- Valid authentication

\- Invalid credentials

\- Expired JWT

\- Invalid JWT signature

\- Invalid issuer

\- Invalid audience

\- Disabled accounts



Only test behavior that exists in the application.



\## 3. Authorization Tests



Test:



\- Roles

\- Authorities

\- Method-level security

\- Resource ownership

\- Forbidden operations

\- Cross-user access restrictions



\## 4. Password Tests



Where applicable, test the configured PasswordEncoder.



Verify:



\- Password encoding

\- Password matching

\- Invalid password handling

\- Password change behavior



Never assume plain-text password storage is acceptable.



\## 5. Spring Security Test Support



Consider spring-security-test when compatible with the existing project.



Use synthetic users and test-only tokens.



\## 6. Security Safety



Never:



\- Use production credentials.

\- Use production JWT secrets.

\- Disable security globally to make tests pass.

\- Expose sensitive information in reports.



Security tests do not replace professional penetration testing.



