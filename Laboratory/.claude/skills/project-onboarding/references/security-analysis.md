\# Security Analysis Reference



\## 1. Purpose and Scope



This reference defines a systematic, technology-independent methodology for reviewing the security posture of existing software systems.



The objective is to identify security weaknesses, insecure implementation patterns, configuration risks, data exposure, authentication and authorization problems, and potential vulnerabilities.



This reference applies to:



\- .NET applications

\- Java applications

\- Spring Framework and Spring Boot

\- ASP.NET Core

\- Web applications

\- REST APIs

\- SOAP and gRPC services

\- Desktop applications

\- Background workers

\- Microservices

\- Distributed systems

\- Database-driven applications

\- Cloud and on-premises deployments



The analysis must be evidence-based and read-only.



Technology-specific security mechanisms must be investigated using the actual frameworks and libraries found in the repository.



Related references:



\- `dotnet-analysis.md`

\- `java-analysis.md`

\- `sqlserver-analysis.md`

\- `oracle-analysis.md`

\- `architecture-analysis.md`

\- `api-analysis.md`

\- `performance-analysis.md`



Do not duplicate their detailed responsibilities. Focus on security implications and cross-component security risks.



\---



\## 2. Security Analysis Principles



Follow these principles:



1\. Never assume an application is secure because it uses a recognized security framework.

2\. Never assume authentication automatically provides authorization.

3\. Never assume that an endpoint is protected without checking its effective security configuration.

4\. Verify security findings using source code, configuration, dependencies, and available documentation.

5\. Distinguish confirmed vulnerabilities from potential weaknesses.

6\. Do not expose credentials, tokens, passwords, private keys, or sensitive configuration values in reports.

7\. Never copy secrets into temporary files, prompts, logs, or external services.

8\. Do not perform active exploitation or penetration testing without explicit authorization.

9\. Do not claim that a vulnerability is exploitable without sufficient evidence.

10\. Evaluate security in the context of the application's actual deployment and business requirements.

11\. Identify both missing controls and incorrectly implemented controls.

12\. Report unknown security behavior explicitly.



\### Evidence Classification



Use the following labels:



\- Verified: directly confirmed by source code or configuration.

\- Inferred: supported by multiple observations but not conclusively established.

\- Requires Runtime Verification: cannot be established through static inspection alone.

\- Requires Developer Confirmation: depends on business rules or deployment knowledge.

\- Not Available: evidence is unavailable.



\### Confidence Levels



\- High

\- Medium

\- Low



A static code finding must not automatically be presented as a confirmed runtime vulnerability.



\---



\## 3. Security Architecture and Trust Boundaries



Identify the application's security architecture.



Inspect:



\- Application entry points

\- Public-facing APIs

\- Internal services

\- Authentication providers

\- Authorization mechanisms

\- Database connections

\- External integrations

\- Administrative interfaces

\- Network boundaries

\- Deployment configuration

\- Identity propagation



Determine:



1\. Which components are accessible from outside?

2\. Which components are internal?

3\. Where does authentication take place?

4\. Where are authorization decisions made?

5\. Which components handle sensitive data?

6\. How is identity propagated between services?

7\. Which external systems are trusted?

8\. Where are the main trust boundaries?



Identify:



\- Missing trust boundaries

\- Unprotected internal interfaces

\- Excessive trust between services

\- Unclear security responsibilities

\- Unnecessary exposure of internal components



Do not infer network exposure from source code alone.



Production exposure requires deployment or infrastructure evidence.



\---



\## 4. Authentication Analysis



Analyze how users and services establish their identities.



Inspect applicable mechanisms:



\- Username and Password

\- JWT Bearer Authentication

\- Cookie Authentication

\- OAuth 2.0

\- OpenID Connect

\- SAML

\- API Keys

\- Basic Authentication

\- Mutual TLS

\- Windows Authentication

\- LDAP

\- Active Directory

\- External Identity Providers

\- Service Accounts



Determine:



1\. Which authentication mechanisms are implemented?

2\. Where is authentication configured?

3\. Are authentication requirements applied consistently?

4\. Are anonymous endpoints explicitly identified?

5\. Are internal and external authentication flows separated?

6\. Is identity information validated before use?

7\. Are authentication failures handled safely?



\### JWT Analysis



Where JWT is used, investigate:



\- Token signature validation

\- Signing algorithm restrictions

\- Issuer validation

\- Audience validation

\- Expiration validation

\- Not-before validation

\- Clock skew configuration

\- Signing key management

\- Token lifetime

\- Refresh token behavior

\- Token revocation strategy

\- Claims validation



Do not expose token values or signing keys.



Do not assume JWT is secure merely because a JWT validation library is installed.



\### Cookie Authentication



Investigate:



\- Secure

\- HttpOnly

\- SameSite

\- Cookie expiration

\- Session expiration

\- Cookie signing and encryption

\- Session invalidation

\- Cookie scope and domain



\### Password-Based Authentication



Investigate:



\- Password verification

\- Password policy

\- Password hashing

\- Login failure handling

\- Account lockout

\- Password reset

\- Credential recovery

\- Session invalidation after password changes



\---



\## 5. Authorization Analysis



Authentication identifies a user. Authorization determines what that user is allowed to do.



Inspect:



\- Role-Based Access Control (RBAC)

\- Policy-Based Authorization

\- Claims-Based Authorization

\- Attribute-Based Access Control (ABAC)

\- Resource-Based Authorization

\- Permission systems

\- Endpoint-level restrictions

\- Service-level checks

\- Database-level restrictions



Determine:



1\. Are sensitive operations protected?

2\. Are authorization rules enforced consistently?

3\. Can users access resources belonging to other users?

4\. Are administrative functions restricted?

5\. Are authorization decisions based on trusted identity claims?

6\. Are permissions checked at the correct application boundary?

7\. Are authorization rules bypassable through alternative execution paths?



\### Common Authorization Risks



Investigate:



\- Missing authorization attributes or policies

\- Incorrect role checks

\- Trusting user-supplied role information

\- Missing resource ownership validation

\- Excessive administrative privileges

\- Inconsistent authorization across endpoints

\- Privilege escalation

\- Insecure direct object references



\### Important Concepts



Check for risks related to:



\- Broken Object Level Authorization (BOLA)

\- Broken Function Level Authorization (BFLA)

\- Insecure Direct Object Reference (IDOR)

\- Privilege Escalation

\- Horizontal Privilege Escalation

\- Vertical Privilege Escalation



Do not classify an endpoint as vulnerable merely because it does not contain an authorization attribute. Authorization may be enforced through middleware, filters, policies, gateways, or another verified mechanism.



\---



\## 6. Password and Credential Management



Analyze how passwords and credentials are handled.



Inspect:



\- Password storage

\- Password hashing algorithms

\- Salt generation

\- Password verification

\- Credential reset flows

\- Temporary passwords

\- Default accounts

\- Administrative credentials

\- API credentials

\- Service account credentials



\### Password Storage



Verify whether passwords are stored using an appropriate password hashing mechanism.



Look for:



\- Argon2id

\- bcrypt

\- scrypt

\- PBKDF2



Investigate:



\- Salt usage

\- Work factor or iteration count

\- Algorithm configuration

\- Legacy hashing methods

\- Plaintext password storage

\- Reversible password encryption



Never report actual password values.



Do not assume a hash is secure solely because it is not plaintext.



\### Credential Handling



Investigate whether credentials appear in:



\- Source code

\- Configuration files

\- Environment files

\- Deployment scripts

\- Docker files

\- CI/CD configuration

\- Log messages

\- Exception messages

\- Documentation

\- Test fixtures



When reporting a finding, identify the file and location without reproducing the secret.



If a credential appears exposed, recommend appropriate secret rotation through the authorized operational process. Do not rotate credentials yourself.



\---



\## 7. Session and Token Security



Investigate session management and token lifecycle.



Check:



\- Session creation

\- Session expiration

\- Session renewal

\- Logout behavior

\- Session invalidation

\- Session fixation protection

\- Concurrent session handling

\- Refresh token rotation

\- Token revocation

\- Device/session tracking



Identify:



\- Sessions without appropriate expiration

\- Tokens with excessive lifetime

\- Missing invalidation after credential changes

\- Insecure refresh token handling

\- Reusable refresh tokens without rotation or reuse detection

\- Weak session binding

\- Sensitive information stored in client-side sessions



Distinguish implementation evidence from runtime behavior.



\---



\## 8. Input Validation and Injection Risks



Analyze how untrusted input enters the application.



Identify input sources:



\- HTTP requests

\- Query parameters

\- Route parameters

\- Request bodies

\- Headers

\- Cookies

\- Uploaded files

\- External API responses

\- Message queues

\- User-generated content

\- Database values



Investigate the following risks:



\### SQL Injection



Check:



\- String concatenation in SQL queries

\- Dynamic SQL

\- Parameterized queries

\- Unsafe stored procedure construction

\- ORM raw SQL usage

\- User-controlled sorting or filtering



\### Command Injection



Check:



\- Process execution

\- Shell commands

\- User-controlled command arguments

\- Unsafe script execution



\### Cross-Site Scripting (XSS)



Check:



\- HTML output encoding

\- JavaScript output encoding

\- Unsafe HTML rendering

\- User-generated content

\- DOM-based rendering

\- Template escaping



\### Path Traversal



Check:



\- User-controlled file paths

\- File names

\- Directory traversal sequences

\- File storage boundaries



\### Server-Side Request Forgery (SSRF)



Check:



\- User-controlled URLs

\- External HTTP clients

\- Internal network access

\- Redirect handling

\- URL validation



\### Other Injection Risks



Where applicable, investigate:



\- LDAP Injection

\- XML External Entity (XXE)

\- XPath Injection

\- NoSQL Injection

\- Expression Language Injection

\- Template Injection

\- Deserialization Risks

\- Header Injection

\- Log Injection



Do not execute malicious payloads during static analysis.



\---



\## 9. Sensitive Data Protection



Identify sensitive data handled by the application.



Examples:



\- Passwords

\- Access Tokens

\- Refresh Tokens

\- API Keys

\- Personal Identifiable Information (PII)

\- Financial Information

\- Health Information

\- Identity Documents

\- Authentication Secrets

\- Private Business Data



Investigate:



1\. Where sensitive data enters the system.

2\. Where it is stored.

3\. Which components can access it.

4\. Whether it is transmitted securely.

5\. Whether it appears in logs.

6\. Whether it is returned by APIs.

7\. Whether unnecessary copies are created.

8\. Whether access is appropriately restricted.



\### Data Protection



Inspect:



\- Encryption at rest

\- Encryption in transit

\- Key management

\- Data masking

\- Data minimization

\- Retention policies

\- Secure deletion mechanisms

\- Backup protection



Do not claim encryption at rest exists without evidence from database, storage, or infrastructure configuration.



Do not reproduce sensitive values in the final report.



\---



\## 10. Cryptography and Key Management



Investigate cryptographic implementation.



Inspect:



\- Encryption algorithms

\- Hashing algorithms

\- Digital signatures

\- Key generation

\- Key storage

\- Key rotation

\- Certificate validation

\- TLS configuration

\- Random number generation



Look for:



\- Hardcoded cryptographic keys

\- Weak or deprecated algorithms

\- Insecure random number generators

\- Hardcoded initialization vectors

\- Reused nonces where prohibited

\- Insecure key derivation

\- Disabled certificate validation

\- Custom cryptographic implementations without justification



Prefer established cryptographic libraries and platform security APIs.



Do not recommend custom encryption implementations.



Never display actual cryptographic keys or certificate private material.



\---



\## 11. Transport and Network Security



Analyze communication security.



Inspect:



\- HTTPS configuration

\- TLS versions

\- Certificate validation

\- HTTP-to-HTTPS redirection

\- Secure cookies

\- Internal service communication

\- Reverse proxy settings

\- Network exposure

\- Allowed origins

\- Firewall or network policies, if available



Investigate:



\- HTTP endpoints carrying sensitive data

\- Disabled TLS certificate validation

\- Insecure internal communication

\- Unnecessary public exposure

\- Weak TLS configuration

\- Missing security headers



Do not infer production network security from local development settings.



\---



\## 12. CORS and Browser Security



Where browser-based clients are involved, inspect:



\- Allowed origins

\- Allowed methods

\- Allowed headers

\- Credential support

\- Wildcard origins

\- Preflight behavior

\- CORS policy placement



Investigate whether:



\- Sensitive endpoints accept unintended origins.

\- Credentialed requests use unsafe origin policies.

\- CORS configuration differs across environments.

\- Browser security boundaries are misunderstood.



Also inspect relevant security headers where applicable:



\- Content-Security-Policy

\- Strict-Transport-Security

\- X-Content-Type-Options

\- X-Frame-Options

\- Referrer-Policy

\- Permissions-Policy



Do not assume CORS is an authentication or authorization mechanism.



\---



\## 13. CSRF and Browser-Based Request Security



For cookie-based authentication and browser applications, investigate:



\- Anti-forgery tokens

\- SameSite cookie settings

\- Origin validation

\- Referer validation

\- State-changing HTTP methods

\- CSRF protection middleware

\- Cross-origin request behavior



Determine whether state-changing operations can be triggered through unintended cross-site requests.



Do not apply cookie-based CSRF assumptions to every API architecture. Evaluate the actual authentication model.



\---



\## 14. File Upload and Download Security



Inspect file handling.



\### Upload Risks



Investigate:



\- File type validation

\- Extension validation

\- Content-Type validation

\- File signature validation

\- File size limits

\- File name sanitization

\- Storage outside executable directories

\- Malware scanning integration

\- Archive extraction risks

\- Path traversal

\- Unauthorized upload access



\### Download Risks



Investigate:



\- Authorization checks

\- Resource ownership

\- File path construction

\- Content-Disposition

\- Content-Type

\- Public versus private storage

\- Predictable file identifiers

\- Unrestricted file access



Do not upload, execute, or download untrusted files during static analysis.



\---



\## 15. Database Security



Analyze database access security at the application boundary.



Inspect:



\- Database credentials

\- Connection configuration

\- Database authentication

\- Application database roles

\- Least-privilege permissions

\- Parameterized queries

\- ORM query construction

\- Stored procedure permissions

\- Sensitive data storage

\- Database connection encryption



Investigate:



\- Excessive database permissions

\- Shared administrative accounts

\- Credentials stored in source code

\- Unsafe dynamic SQL

\- Unnecessary access to sensitive tables

\- Missing separation between read and write responsibilities



Database-specific structural analysis belongs to:



\- `sqlserver-analysis.md`

\- `oracle-analysis.md`



Never execute schema modifications or data-changing commands during this review.



\---



\## 16. Dependency and Supply Chain Security



Analyze third-party dependencies and software supply chain risks.



Inspect:



\- NuGet packages

\- Maven dependencies

\- Gradle dependencies

\- npm packages

\- Python packages

\- Container base images

\- Build plugins

\- External binaries

\- Dependency lock files

\- Package source configuration



Investigate:



\- Outdated dependencies

\- Known vulnerable versions

\- Unsupported frameworks

\- Unmaintained libraries

\- Dependency confusion risks

\- Untrusted package sources

\- Unexpected transitive dependencies

\- Unpinned container image tags

\- Insecure build scripts



Distinguish:



\- Dependency identified in the repository

\- Dependency version confirmed

\- Known vulnerability confirmed by a reliable advisory

\- Vulnerability applicability to the actual application



Do not claim a dependency is vulnerable solely because it is old.



If current vulnerability intelligence is needed, request permission before using external services or sending dependency information outside the authorized environment.



Never upload private dependency manifests to third-party scanning services without permission.



\---



\## 17. Configuration and Secret Management



Inspect:



\- Application configuration files

\- Environment variables

\- Secret stores

\- Configuration providers

\- Docker configuration

\- CI/CD variables

\- Deployment manifests

\- Certificate configuration



Investigate:



\- Hardcoded credentials

\- Development secrets in production configuration

\- Weak default settings

\- Secrets committed to source control

\- Overly permissive configuration

\- Environment leakage

\- Insecure fallback configuration



Check whether secret values are accidentally included in:



\- Logs

\- Error messages

\- API responses

\- Diagnostic output

\- Documentation



Report only the location and type of exposed secret. Never reproduce the value.



Do not change secrets or configuration during analysis.



\---



\## 18. Logging, Auditing, and Security Monitoring



Analyze security visibility.



Inspect whether the application records:



\- Authentication failures

\- Authorization failures

\- Account lockouts

\- Password changes

\- Privilege changes

\- Administrative actions

\- Sensitive configuration changes

\- Suspicious access patterns

\- Security-relevant business operations



Investigate:



\- Log injection

\- Sensitive data in logs

\- Missing audit trails

\- Excessive logging

\- Inconsistent event structure

\- Missing correlation identifiers

\- Missing security alerts



Distinguish ordinary application logging from a reliable security audit mechanism.



Do not assume logs are centrally collected or monitored without infrastructure evidence.



\---



\## 19. Rate Limiting and Abuse Protection



Investigate protections against abuse and resource exhaustion.



Inspect:



\- Rate limiting

\- Request quotas

\- Account lockout

\- Login throttling

\- CAPTCHA integration

\- Request size limits

\- Upload limits

\- API gateway restrictions

\- Concurrency limits

\- Expensive operation controls



Consider risks related to:



\- Brute-force attacks

\- Credential stuffing

\- Denial of Service

\- Unrestricted resource consumption

\- Automated account creation

\- Excessive password reset requests

\- Expensive search operations



Evaluate protections according to endpoint sensitivity and business requirements.



Do not assume a missing global rate limiter makes every endpoint vulnerable. Identify the actual abuse scenario and impact.



\---



\## 20. Security Misconfiguration



Review security-related configuration.



Look for:



\- Debug mode enabled in production configuration

\- Detailed exception pages

\- Development-only endpoints exposed

\- Weak default credentials

\- Unnecessary HTTP methods

\- Excessive CORS permissions

\- Missing security headers

\- Insecure TLS settings

\- Exposed administration interfaces

\- Unnecessary service ports

\- Overly permissive file permissions

\- Unrestricted actuator or management endpoints



Separate configuration evidence from actual production deployment state.



\---



\## 21. Security Standards and Risk Classification



Use recognized security references where applicable:



\- OWASP Top 10

\- OWASP API Security Top 10

\- CWE

\- CVE

\- NIST Cybersecurity guidance

\- Relevant platform security documentation



Do not claim compliance with a standard based on a limited static review.



\### Severity Levels



\#### Critical



A confirmed or strongly evidenced issue with severe impact, such as:



\- Unauthenticated access to critical administrative functionality

\- Exposed high-impact credentials

\- Direct compromise of sensitive systems

\- Severe authorization bypass with broad impact



\#### High



Issues that can cause significant compromise, such as:



\- Unauthorized access to sensitive data

\- Privilege escalation

\- Exploitable injection vulnerabilities

\- Weak protection of critical operations



\#### Medium



Issues with meaningful but more limited impact, such as:



\- Inconsistent authorization checks

\- Insecure configuration with additional exploitation requirements

\- Sensitive information exposure in restricted contexts



\#### Low



Limited-impact weaknesses or defense-in-depth gaps.



\#### Informational



Observations that improve security understanding but do not establish a vulnerability.



\### Confidence



For each finding, specify:



\- High

\- Medium

\- Low



Never confuse severity with confidence.



A potentially critical issue with insufficient evidence must be reported as requiring verification, not as a confirmed critical vulnerability.



\---



\## 22. Security Finding Format



For every security finding, use this structure:



\### Finding ID



Example: SEC-001



\### Title



A short, precise description.



\### Category



Authentication, Authorization, Injection, Data Protection, Configuration, Dependency, or another relevant category.



\### Severity



Critical / High / Medium / Low / Informational



\### Confidence



High / Medium / Low



\### Evidence Classification



Verified / Inferred / Requires Runtime Verification / Requires Developer Confirmation



\### Location



\- File path

\- Class or method

\- Configuration key, without exposing its value

\- Relevant line numbers, if available



\### Description



Explain the observed security weakness.



\### Evidence



Describe the exact code or configuration behavior that supports the finding.



\### Attack Scenario



Describe a realistic potential abuse scenario without providing exploit instructions or executing an attack.



\### Impact



Explain potential effects on:



\- Confidentiality

\- Integrity

\- Availability

\- Business operations

\- Regulatory or privacy obligations, where established



\### Recommendation



Provide a practical and prioritized mitigation.



\### Verification Required



Identify what must be checked through runtime testing, deployment inspection, or developer confirmation.



\---



\## 23. Security Risk Prioritization



Use these priorities:



\### P0 - Critical



Immediate security attention is required.



Examples:



\- Confirmed critical authorization bypass

\- Exposed credentials with critical access

\- Severe injection vulnerability affecting sensitive systems

\- Critical sensitive-data exposure



\### P1 - High



Significant security risk requiring prompt remediation.



Examples:



\- High-impact access control weakness

\- Sensitive data exposure

\- Dangerous insecure configuration

\- Confirmed exploitable dependency vulnerability



\### P2 - Medium



Meaningful weaknesses that should be addressed in planned remediation.



\### P3 - Low



Minor weaknesses and defense-in-depth improvements.



Priority must be justified by actual impact, likelihood, exposure, and available evidence.



\---



\## 24. Read-Only Analysis Restrictions



This reference authorizes static security review only.



Unless the user explicitly grants separate permission:



\- Do not modify source code.

\- Do not change configuration files.

\- Do not install security tools or packages.

\- Do not rotate credentials.

\- Do not change passwords.

\- Do not modify access permissions.

\- Do not modify database users or roles.

\- Do not execute SQL modifications.

\- Do not run migrations.

\- Do not access production secrets.

\- Do not send credentials to external services.

\- Do not perform penetration testing.

\- Do not execute exploit payloads.

\- Do not perform vulnerability exploitation.

\- Do not run destructive security scans.

\- Do not perform load or stress testing.

\- Do not access production infrastructure.

\- Do not trigger CI/CD pipelines.

\- Do not deploy changes.

\- Do not modify Git history.



Static inspection of repository files is permitted within the available environment and permissions.



If dynamic testing is necessary, explain:



1\. Why static analysis is insufficient.

2\. Which environment is required.

3\. What tests would be performed.

4\. What risks the tests may introduce.



Request explicit authorization before proceeding.



\---



\## 25. Expected Security Analysis Report



Produce the final report in Persian.



Preserve technical identifiers, class names, method names, file paths, security standards, protocol names, and configuration keys in English.



Use this structure:



\# گزارش تحلیل امنیت پروژه



\## 1. خلاصه وضعیت امنیتی



\- وضعیت کلی

\- مهم‌ترین نقاط قوت

\- مهم‌ترین ریسک‌ها

\- محدودیت‌های بررسی



\## 2. معماری امنیت



\- Trust Boundaries

\- Public and Internal Components

\- Security Responsibilities

\- External Identity Providers



\## 3. Authentication



\- Authentication Mechanisms

\- JWT / Cookies / OAuth / Other Methods

\- Password Authentication

\- Session and Token Management



\## 4. Authorization



\- Roles

\- Policies

\- Permissions

\- Resource Ownership

\- Administrative Access

\- BOLA / BFLA / IDOR Risks



\## 5. Password and Credential Management



\- Password Hashing

\- Credential Storage

\- Password Reset

\- Default Accounts

\- Secret Exposure



\## 6. Data Protection



\- Sensitive Data

\- Encryption

\- Data Exposure

\- Logging Risks

\- Data Retention



\## 7. Input Validation and Injection



\- SQL Injection

\- XSS

\- Command Injection

\- SSRF

\- Path Traversal

\- Deserialization

\- Other Relevant Risks



\## 8. Network and Transport Security



\- HTTPS

\- TLS

\- Certificates

\- CORS

\- CSRF

\- Security Headers



\## 9. Database Security



\- Database Credentials

\- Database Permissions

\- Query Parameterization

\- Sensitive Data Access



\## 10. Dependency and Supply Chain Security



\- Dependency Versions

\- Known Vulnerabilities

\- Unsupported Components

\- Package Sources

\- Container Images



\## 11. Configuration and Secrets



\- Application Configuration

\- Environment Variables

\- Secret Management

\- Production Configuration Risks



\## 12. Logging and Monitoring



\- Security Events

\- Audit Trails

\- Sensitive Information in Logs

\- Monitoring Gaps



\## 13. Abuse Protection



\- Rate Limiting

\- Brute Force Protection

\- Resource Limits

\- Abuse Scenarios



\## 14. Security Findings



For each finding:



\- Finding ID

\- Title

\- Category

\- Severity

\- Confidence

\- Evidence

\- Location

\- Impact

\- Recommendation

\- Verification Requirements



\## 15. Risk Prioritization



Separate findings into P0, P1, P2, and P3.



\## 16. Items Requiring Runtime Verification



List findings that cannot be confirmed through static inspection.



\## 17. Developer Confirmation Required



List security assumptions that require business or deployment knowledge.



\## 18. Recommended Remediation Roadmap



Provide a prioritized remediation sequence.



Do not implement any recommendation without explicit authorization.



\---



\## 26. Final Security Quality Checklist



Before finalizing the analysis, verify:



\- \[ ] Application trust boundaries have been identified.

\- \[ ] Authentication mechanisms have been inspected.

\- \[ ] JWT or session validation has been reviewed where applicable.

\- \[ ] Authorization checks have been investigated.

\- \[ ] Resource ownership checks have been considered.

\- \[ ] Password storage and verification have been reviewed.

\- \[ ] Sensitive data exposure has been investigated.

\- \[ ] Cryptographic implementation has been reviewed.

\- \[ ] Input validation and injection risks have been examined.

\- \[ ] File upload and download security has been checked where applicable.

\- \[ ] Database access security has been considered.

\- \[ ] Dependencies and supply chain risks have been reviewed.

\- \[ ] Secret management has been inspected without exposing values.

\- \[ ] Logging and audit risks have been evaluated.

\- \[ ] Rate limiting and abuse protection have been considered.

\- \[ ] Security configuration has been reviewed.

\- \[ ] Findings include evidence and confidence levels.

\- \[ ] Severity is not confused with confidence.

\- \[ ] Static findings are distinguished from runtime-confirmed vulnerabilities.

\- \[ ] No penetration testing or exploitation has been performed.

\- \[ ] No source code or configuration has been modified.

\- \[ ] The final report is written in Persian.



If evidence is insufficient, explicitly state the limitation instead of making assumptions.

