

\# Documentation Quality Analysis



\## 1. Purpose



This reference defines a systematic, evidence-based approach for evaluating the quality, accuracy, completeness, consistency, usability, and maintainability of technical documentation in a software repository.



The objective is to determine whether documentation accurately describes the actual system and provides sufficient information for developers, maintainers, testers, operators, and other relevant stakeholders.



This reference evaluates existing documentation. It does not independently authorize creating, modifying, or deleting documentation.



Follow the main `project-onboarding/SKILL.md` instructions for execution modes, approval requirements, output locations, reporting language, evidence classification, and safety restrictions.



\---



\## 2. Core Principles



Apply the following principles throughout the analysis:



1\. Evidence-first: evaluate documentation against actual source code, configuration, project files, database definitions, API contracts, deployment configuration, and other available evidence.

2\. Do not assume documentation is accurate simply because it exists.

3\. Do not assume documentation is missing simply because a topic is not covered in README.

4\. Distinguish between verified inaccuracies, missing information, outdated information, and recommendations.

5\. Do not invent system behavior to fill documentation gaps.

6\. Do not treat every undocumented implementation detail as a documentation defect.

7\. Consider the intended audience and operational importance of each document.

8\. Identify conflicting documentation and possible multiple sources of truth.

9\. Avoid unnecessary documentation duplication.

10\. Do not expose secrets, credentials, tokens, private keys, connection strings, or sensitive infrastructure details in reports.

11\. Do not modify files during documentation quality analysis.

12\. Do not assign artificial precision to documentation quality scores.



If source code or configuration is unavailable, explicitly state that accuracy could not be fully verified.



\---



\## 3. Documentation Discovery and Inventory



Identify documentation available in the repository.



Inspect relevant files and directories, including:



\### 3.1 General Documentation



\- README.md

\- README files in subdirectories

\- CONTRIBUTING.md

\- CHANGELOG.md

\- LICENSE

\- CODE\_OF\_CONDUCT.md

\- SECURITY.md

\- SUPPORT.md



\### 3.2 Architecture Documentation



\- Architecture overview

\- Architecture Decision Records (ADRs)

\- System context diagrams

\- Container and component diagrams

\- Deployment diagrams

\- Sequence diagrams

\- Data flow diagrams

\- Module and dependency documentation



\### 3.3 Technical Documentation



\- API documentation

\- Database documentation

\- Entity and relationship descriptions

\- Configuration references

\- Dependency documentation

\- Integration documentation

\- Coding standards

\- Development guidelines

\- Build instructions

\- Testing instructions



\### 3.4 Operational Documentation



\- Installation guides

\- Deployment guides

\- Environment setup instructions

\- Runbooks

\- Troubleshooting guides

\- Monitoring and alerting instructions

\- Backup and recovery procedures

\- Rollback procedures

\- Incident response procedures



\### 3.5 Inline Documentation



\- Code comments

\- XML documentation comments

\- JavaDoc

\- Public API documentation

\- Important configuration comments

\- Database object descriptions



\### 3.6 Documentation Inventory Requirements



For each relevant document, record:



\- File path

\- Document type

\- Intended audience, if identifiable

\- Main purpose

\- Last modification evidence, when available

\- Related system component

\- Whether the document appears active, outdated, incomplete, or conflicting

\- Verification status



Do not assume that file modification time represents the last meaningful review date.



Do not read generated, vendor, binary, or irrelevant documentation directories indiscriminately.



\---



\## 4. Documentation Hierarchy and Source of Truth



Evaluate whether the repository has a clear documentation structure.



Identify:



\- Main entry-point documentation

\- Developer onboarding documentation

\- Architecture documentation

\- API documentation

\- Database documentation

\- Operational documentation

\- Contribution guidelines

\- Historical documentation



Check for:



1\. Multiple documents describing the same feature differently.

2\. Conflicting installation or execution instructions.

3\. Different configuration examples for the same environment.

4\. Outdated architecture descriptions.

5\. Duplicate API references.

6\. Documentation stored in unexpected locations.

7\. Missing links between related documents.

8\. Unclear ownership of critical documentation.



Determine whether a reasonable single source of truth exists for important topics.



Do not recommend centralizing every document when distributed documentation is more appropriate.



\---



\## 5. Accuracy and Consistency



Compare documentation with the actual implementation.



Verify relevant claims against:



\- Source code

\- Project and solution files

\- Package manifests

\- Application configuration

\- Environment configuration templates

\- Database schema

\- ORM mappings

\- API routes and contracts

\- Authentication and authorization configuration

\- Deployment files

\- Docker configuration

\- CI/CD configuration

\- Infrastructure definitions

\- Existing tests, where relevant



Check whether documented information accurately describes:



\- Framework and runtime versions

\- Programming languages

\- Project structure

\- Architectural boundaries

\- Application startup

\- Dependency injection

\- Database providers

\- Entity relationships

\- API endpoints

\- Authentication mechanisms

\- Authorization rules

\- Configuration keys

\- Build and execution commands

\- Deployment procedures

\- External integrations



Classify accuracy findings as:



\- Verified accurate

\- Verified inaccurate

\- Partially accurate

\- Not verifiable

\- Conflicting information



Never claim that a document is inaccurate without identifying the implementation evidence that contradicts it.



\---



\## 6. Completeness Assessment



Evaluate whether documentation contains the information necessary for its intended purpose.



\### 6.1 Developer Onboarding



Check for:



\- Project purpose

\- Prerequisites

\- Required tools

\- Runtime and SDK versions

\- Repository structure

\- Environment setup

\- Configuration requirements

\- Database setup

\- Build instructions

\- Execution instructions

\- Test execution instructions

\- Common development workflows



\### 6.2 Architecture



Check for:



\- System overview

\- Main components

\- Component responsibilities

\- Dependency relationships

\- Data flow

\- External integrations

\- Important architectural decisions

\- Runtime and deployment topology, when relevant



\### 6.3 Database



Check for:



\- Database engine and relevant version

\- Schema organization

\- Important tables and entities

\- Relationships

\- Constraints

\- Indexes, where relevant

\- Migration strategy

\- Seed data strategy

\- Database initialization

\- Backup and recovery guidance, where operationally relevant



\### 6.4 API



Check for:



\- Endpoint inventory

\- HTTP methods

\- Request parameters

\- Request and response schemas

\- Authentication requirements

\- Authorization requirements

\- Status codes

\- Error responses

\- Pagination and filtering

\- API versioning

\- Important usage examples



\### 6.5 Security



Check for:



\- Authentication architecture

\- Authorization model

\- Secret management

\- Configuration security

\- Sensitive data handling

\- Security responsibilities

\- Relevant operational security procedures



Never require public disclosure of internal security-sensitive implementation details.



\### 6.6 Operations



Check for:



\- Deployment prerequisites

\- Environment requirements

\- Configuration

\- Startup and shutdown

\- Health checks

\- Logging

\- Monitoring

\- Troubleshooting

\- Rollback

\- Backup and restore

\- Incident response, when relevant



\### 6.7 Maintenance



Check for:



\- Contribution process

\- Coding conventions

\- Testing expectations

\- Dependency update procedures

\- Release process

\- Versioning policy

\- Change documentation



Mark irrelevant topics as N/A rather than treating them as missing documentation.



\---



\## 7. Clarity, Readability, and Usability



Evaluate whether documentation is understandable and usable by its intended audience.



Inspect:



\- Clear document titles

\- Logical section organization

\- Meaningful headings

\- Consistent terminology

\- Appropriate technical detail

\- Clear prerequisites

\- Step-by-step instructions where needed

\- Useful examples

\- Readable tables

\- Working internal links

\- Working external references, when verifiable

\- Appropriate language and writing style

\- Consistent naming with actual code identifiers



Identify:



\- Ambiguous instructions

\- Undefined technical terms

\- Unexplained abbreviations

\- Excessively long or poorly structured sections

\- Missing context

\- Unnecessary repetition

\- Instructions that require undocumented assumptions



Documentation should be detailed enough to be useful without becoming unnecessarily verbose.



\---



\## 8. Maintainability and Documentation Lifecycle



Evaluate whether documentation can remain accurate as the software evolves.



Inspect available evidence for:



\- Document ownership

\- Review responsibilities

\- Documentation update expectations

\- Version compatibility

\- Change history

\- Release notes

\- Documentation review practices

\- References to deprecated components

\- References to removed endpoints or configuration keys



Identify documentation that may have drifted from the current implementation.



Check whether important code changes have corresponding documentation updates, when Git history is available and authorized for inspection.



Do not assume that every code commit requires a documentation change.



Prioritize documentation updates according to the impact of the underlying software changes.



\---



\## 9. Code Examples, Commands, and Configuration



Inspect examples for correctness and safety.



\### 9.1 Code Examples



Check:



\- Whether examples match current APIs

\- Whether referenced classes and methods exist

\- Whether namespaces and imports are correct

\- Whether required dependencies are documented

\- Whether examples reflect current project conventions

\- Whether examples omit important prerequisites

\- Whether examples are misleading or incomplete



Do not execute undocumented or potentially destructive examples.



\### 9.2 Command Examples



Check:



\- Command syntax

\- Working directory assumptions

\- Operating system compatibility

\- Runtime and tool requirements

\- Correct project and file paths

\- Environment variable requirements

\- Whether commands are still applicable



\### 9.3 Configuration Examples



Check:



\- Configuration key names

\- Configuration hierarchy

\- Environment-specific behavior

\- Default values, when verifiable

\- Required versus optional settings

\- Safe placeholder values

\- Whether sensitive values are appropriately redacted



Never reproduce actual credentials or secrets in documentation findings.



Examples should use placeholders such as:



`YOUR\_CONNECTION\_STRING`



`YOUR\_API\_KEY`



`YOUR\_SECRET`



Do not invent real-looking credentials.



\---



\## 10. API Documentation Quality



When the application exposes APIs, evaluate documentation against actual API contracts.



Check:



1\. Endpoint coverage.

2\. HTTP methods.

3\. Route parameters.

4\. Query parameters.

5\. Request schemas.

6\. Response schemas.

7\. Validation requirements.

8\. Authentication requirements.

9\. Authorization requirements.

10\. Success status codes.

11\. Error status codes.

12\. Error response formats.

13\. Pagination and filtering.

14\. Versioning.

15\. Deprecation information.

16\. Example requests and responses.



Where OpenAPI or Swagger is available, compare the specification with the actual implementation.



Do not assume that the existence of Swagger automatically means API documentation is complete or correct.



Report undocumented endpoints and incorrect contracts with concrete evidence.



\---



\## 11. Architecture Diagrams and Visual Documentation



Evaluate diagrams for:



\- Technical accuracy

\- Consistency with actual architecture

\- Clear component names

\- Correct dependency direction

\- Correct relationship representation

\- Appropriate level of abstraction

\- Readability

\- Maintainability



When Mermaid diagrams exist, inspect their syntax and semantic consistency.



When diagram rendering or validation tools are unavailable, state that syntax validation was not performed.



Identify:



\- Missing critical components

\- Incorrect dependencies

\- Outdated connections

\- Ambiguous boundaries

\- Contradictions between diagrams and written descriptions



Do not create replacement diagrams during a read-only quality review.



If a diagram is proposed as an improvement, describe its required scope and purpose.



\---



\## 12. Database Documentation Quality



Compare database documentation with available database definitions, migrations, ORM mappings, and SQL scripts.



Check:



\- Database engine identification

\- Schema names

\- Table names

\- Column definitions

\- Data types

\- Nullability

\- Primary keys

\- Foreign keys

\- Unique constraints

\- Indexes

\- Relationships

\- Views

\- Stored procedures

\- Functions

\- Triggers

\- Migration procedures

\- Seed data

\- Backup and recovery guidance



Evaluate whether important business rules and database constraints are explained.



Do not assume that the existence of entity classes fully documents the database schema.



If the actual database is inaccessible, distinguish between schema inferred from source code and schema verified against a running database.



\---



\## 13. Security Documentation Quality



Evaluate whether security-related documentation is useful, accurate, and safe.



Check:



\- Authentication documentation

\- Authorization documentation

\- Role and permission descriptions

\- Secret management instructions

\- Secure configuration guidance

\- Sensitive data handling

\- Security reporting procedures

\- Dependency vulnerability handling

\- Security update procedures

\- Operational security responsibilities



Identify documentation that:



\- Encourages unsafe credential storage

\- Contains actual secrets

\- Recommends insecure defaults

\- Describes obsolete security mechanisms

\- Omits critical security prerequisites

\- Exposes sensitive internal information unnecessarily



Do not reproduce exposed secrets in the report.



If an actual secret is discovered, report its location without revealing its value and recommend following the organization's secret rotation and incident response procedures.



\---



\## 14. Operational Documentation Quality



Evaluate whether an operator or maintainer can use the available documentation to operate the system safely.



Check:



\### Deployment



\- Deployment prerequisites

\- Environment preparation

\- Configuration

\- Database compatibility

\- Deployment steps

\- Post-deployment verification



\### Rollback



\- Rollback conditions

\- Rollback steps

\- Database migration considerations

\- Version compatibility

\- Recovery limitations



\### Monitoring



\- Health checks

\- Application logs

\- Error monitoring

\- Important metrics

\- Alerting guidance



\### Backup and Recovery



\- Backup responsibilities

\- Backup frequency, if defined

\- Retention policies, if defined

\- Restore procedures

\- Recovery verification



\### Incident Response



\- Troubleshooting steps

\- Escalation procedures

\- Relevant operational contacts or roles

\- Incident documentation



Do not assume operational procedures exist unless supported by repository evidence.



Do not execute deployment, rollback, backup, restore, or recovery procedures during this analysis.



\---



\## 15. Documentation Drift and Change Impact



Identify differences between documentation and the current implementation.



Potential sources of drift include:



\- Renamed classes or modules

\- Changed API routes

\- Modified database schema

\- Changed configuration keys

\- Framework upgrades

\- Replaced dependencies

\- Changed authentication flows

\- Removed features

\- Updated deployment topology

\- Changed build or release processes



Where Git history is available and authorized:



\- Identify relevant implementation changes.

\- Check whether related documentation changed.

\- Identify possible undocumented breaking changes.

\- Distinguish historical documentation from active documentation.



Do not treat an unchanged document as automatically outdated.



Explain the actual impact of any identified discrepancy.



\---



\## 16. Documentation Quality Scoring



A scoring rubric may be used to summarize documentation quality.



Evaluate relevant dimensions using a 0–5 scale:



| Score | Meaning |

|---|---|

| 0 | Missing or unusable |

| 1 | Severely inadequate |

| 2 | Incomplete or unreliable |

| 3 | Acceptable with identifiable gaps |

| 4 | Good and mostly complete |

| 5 | Excellent, accurate, and maintainable |



Possible evaluation dimensions:



\- Coverage

\- Accuracy

\- Completeness

\- Clarity

\- Consistency

\- Maintainability

\- Technical correctness

\- Operational usefulness

\- Security awareness



\### Scoring Rules



1\. Use N/A for dimensions that do not apply.

2\. Explain the evidence behind significant scores.

3\. Do not calculate a score when evidence is insufficient.

4\. Do not use the score as a replacement for individual findings.

5\. Do not imply statistical accuracy.

6\. Avoid presenting small numerical differences as meaningful.

7\. Identify critical defects separately, regardless of the overall score.



If an overall score is calculated, explain the method and excluded N/A dimensions.



A high overall score must never hide a critical documentation defect.



\---



\## 17. Documentation Findings



Each significant finding should contain:



\- Finding ID

\- Title

\- Category

\- Affected document

\- Affected implementation component

\- Description

\- Supporting evidence

\- Impact

\- Recommended action

\- Priority

\- Confidence level



\### Finding Categories



Use relevant categories such as:



\- Missing Documentation

\- Incorrect Documentation

\- Outdated Documentation

\- Incomplete Documentation

\- Conflicting Documentation

\- Unclear Documentation

\- Broken Reference

\- Invalid Example

\- Security Documentation Issue

\- Operational Documentation Gap

\- Documentation Maintenance Issue



\### Priority



Use the following priority levels:



\- P0: Critical documentation defect that creates an immediate and severe operational, security, or data-loss risk.

\- P1: High-impact defect that can significantly affect development, deployment, security, or system operation.

\- P2: Medium-impact issue that causes confusion, incomplete understanding, or maintenance difficulties.

\- P3: Low-impact improvement, clarity issue, or minor documentation inconsistency.



Do not classify every missing document as P1.



\### Confidence



Use:



\- Confirmed

\- High Confidence

\- Medium Confidence

\- Low Confidence



Keep confidence separate from priority.



\---



\## 18. Evidence Requirements



Every significant finding must include concrete evidence.



Prefer:



\- File paths

\- Section headings

\- Configuration keys

\- Class and method names

\- API route definitions

\- Database object definitions

\- Project references

\- Relevant Git history, when authorized



Distinguish:



\### Verified



Directly supported by repository or system evidence.



\### Inferred



A reasonable conclusion derived from available evidence.



\### Requires Confirmation



Cannot be established without developer, operator, or business-owner input.



\### Not Verifiable



The necessary source or runtime evidence is unavailable.



Never fabricate:



\- Document contents

\- Review dates

\- Ownership information

\- API behavior

\- Deployment procedures

\- Operational policies

\- Database behavior



\---



\## 19. Read-Only and Safety Restrictions



Documentation quality analysis is read-only by default.



Do not:



\- Create documentation files.

\- Modify existing documentation.

\- Delete documentation.

\- Rename or move files.

\- Rewrite README files.

\- Generate diagrams inside the repository.

\- Run commands that modify project state.

\- Install documentation tools or dependencies.

\- Modify application source code.

\- Modify configuration.

\- Modify database objects.

\- Commit or push changes.



You may inspect existing files and produce findings in the response.



If the main Skill supports documentation creation or updates, follow its explicit approval requirements before making any changes.



A recommendation is not permission to execute that recommendation.



\---



\## 20. Persian Reporting Requirements



All documentation quality reports must be written in Persian.



Keep these items in English where appropriate:



\- File paths

\- Class names

\- Method names

\- API routes

\- Configuration keys

\- Database identifiers

\- Framework names

\- Technical terms

\- Error messages



Use clear technical Persian and avoid unnecessary literal translations.



\### Recommended Report Structure



\# گزارش ارزیابی کیفیت مستندات



\## 1. خلاصه مدیریتی



\- وضعیت کلی مستندات

\- نقاط قوت

\- مهم‌ترین شکاف‌ها

\- ریسک‌های اصلی

\- میزان اطمینان به ارزیابی



\## 2. فهرست مستندات



| مسیر فایل | نوع مستند | وضعیت | توضیح |

|---|---|---|---|



\## 3. ارزیابی ابعاد کیفیت



| بُعد | امتیاز | شواهد | توضیح |

|---|---:|---|---|



Use N/A where appropriate.



\## 4. مستندات صحیح و قابل اتکا



List documentation verified against the implementation.



\## 5. مستندات ناقص یا نیازمند اصلاح



List significant findings with evidence.



\## 6. مستندات متناقض یا قدیمی



Explain conflicts and documentation drift.



\## 7. شکاف‌های مستندسازی



Identify important undocumented topics.



\## 8. ریسک‌ها و اولویت‌ها



Group findings by P0, P1, P2, and P3.



\## 9. پیشنهادهای بهبود



Provide actionable recommendations without executing them.



\## 10. محدودیت‌های ارزیابی



Explain unavailable files, inaccessible runtime information, missing database access, and other limitations.



\## 11. نتیجه‌گیری



Summarize the documentation quality and the most important next steps.



\---



\## 21. Final Quality Checklist



Before completing the analysis, verify:



\- \[ ] Relevant documentation has been inventoried.

\- \[ ] Documentation has been compared with available implementation evidence.

\- \[ ] Accuracy and completeness have been evaluated separately.

\- \[ ] Important contradictions have been identified.

\- \[ ] Developer onboarding documentation has been reviewed.

\- \[ ] Architecture documentation has been reviewed.

\- \[ ] API documentation has been reviewed where applicable.

\- \[ ] Database documentation has been reviewed where applicable.

\- \[ ] Security documentation has been reviewed.

\- \[ ] Operational documentation has been reviewed where applicable.

\- \[ ] Code examples and commands have been checked where feasible.

\- \[ ] Documentation drift has been considered.

\- \[ ] Missing information has not been presented as a verified defect without context.

\- \[ ] Findings include evidence and impact.

\- \[ ] Priorities are proportionate to actual risk.

\- \[ ] Confidence levels are separate from priorities.

\- \[ ] N/A dimensions have not been scored as failures.

\- \[ ] Secrets and sensitive information have not been exposed.

\- \[ ] No files have been modified.

\- \[ ] The report is written in Persian.



\---



\## 22. Boundary with the Main Skill



This reference is responsible for evaluating the quality of existing documentation.



It does not independently decide to create, update, reorganize, or delete documentation.



The main `project-onboarding/SKILL.md` controls:



\- Whether documentation creation is within the selected execution mode.

\- Which documentation files should be created or updated.

\- Where output files should be stored.

\- Whether user approval is required.

\- How documentation changes are executed safely.



When documentation improvements are needed:



1\. Report the findings.

2\. Explain their impact.

3\. Recommend specific changes.

4\. Wait for the required user approval.

5\. Follow the main Skill's instructions for any subsequent documentation work.



A documentation quality review must remain read-only unless a separate, explicitly authorized task permits changes.



