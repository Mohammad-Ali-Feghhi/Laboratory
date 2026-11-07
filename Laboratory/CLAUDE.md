# Project Instructions

## Project Overview

This is a .NET Laboratory Management System.

## General Rules

* Understand the existing architecture before making changes.
* Preserve existing business logic and application behavior.
* Do not rewrite entire modules without explicit approval.
* Prefer small, focused, reviewable changes.
* Avoid unnecessary abstractions and overengineering.
* Follow the existing coding conventions.

## Code Quality

* Follow SOLID principles where they provide practical value.
* Use Dependency Injection consistently with the existing architecture.
* Avoid duplicate code when the duplicated logic is genuinely shared.
* Use meaningful names for classes, methods, and variables.
* Keep each class and method focused on a clear responsibility.
* Add useful Persian XML documentation comments above handwritten methods when requested.

## Database

* Inspect existing database access patterns before changing queries.
* Do not modify database schema or execute migrations without approval.
* Preserve existing data and transaction behavior.

## Testing

* Build the solution after meaningful changes.
* Run relevant tests when available.
* Never claim a test or build succeeded unless it was actually executed.
* Report all commands and their actual results.

## Git

* Never discard existing user changes.
* Never run destructive Git commands without approval.
* Keep changes small and independently reviewable.
* Use one commit for each logically independent change.
* Do not commit secrets, credentials, or private configuration.

## Safety

* Do not expose passwords, API keys, tokens, or sensitive information.
* Do not publish, deploy, or modify production environments without explicit approval.
* Ask before deleting files or performing irreversible actions.

Project Documentation



Before starting any significant task:



1\. Read docs/project-overview.md.

2\. Read docs/ai-work-log.md.

3\. Review docs/module-review.md when working on module analysis or refactoring.

4\. Check the current Git status and active branch.



Always use ai-work-log.md to understand:

\- Completed tasks

\- Current project status

\- Pending tasks

\- Next recommended steps



After completing each significant task, update ai-work-log.md.

Never assume a task is completed without verifying the actual project state.



\## Language and Documentation Rules

\### 1. Mandatory Language

\- All reports, explanations, analyses, recommendations, summaries, reviews, and documentation must be written in Persian (Farsi).

\- Persian must be the default language for all user-facing responses and generated documentation.

\- Do not produce English reports or explanations unless the user explicitly requests English.



\### 2. Technical Terms

\- Keep programming-related technical terms in their original English form.

\- Do not translate or rename namespaces, classes, methods, properties, variables, interfaces, libraries, frameworks, packages, or file names.

\- Keep code, commands, paths, configuration keys, database object names, and identifiers unchanged.

\- Write Persian explanations around English technical terms.



Examples:

\- Correct: «طول عمر DbContext در Dependency Injection به‌درستی مدیریت شده است.»

\- Incorrect: "The DbContext lifetime is correctly managed."

\- Correct: «مشکل N+1 Query می‌تواند باعث افزایش تعداد درخواست‌ها به دیتابیس شود.»



\### 3. Documentation Files

\- All Markdown documentation files (\*.md) created or updated by Claude must be written in Persian.

\- Use Persian headings, descriptions, tables, checklists, and summaries.

\- Keep code snippets, commands, file paths, and technical identifiers in their original form.

\- Use clear and professional Persian suitable for a software development team.



\### 4. Code Comments

\- Write new code comments in Persian unless the existing file consistently uses English comments or the user explicitly requests otherwise.

\- Do not translate or rewrite existing comments unnecessarily.

\- Never change code identifiers merely to make them Persian.



\### 5. Tables and Reports

\- All table headings and explanatory content must be in Persian.

\- Technical names and values must remain unchanged.

\- Priority levels must use Persian labels:

&#x20; - زیاد

&#x20; - متوسط

&#x20; - کم

\- Clearly distinguish confirmed problems from potential risks and unverified assumptions.



\### 6. Final Response

\- Always provide the final response in Persian.

\- Explain technical findings in clear, precise, and practical Persian.

\- When referencing code, include the exact file path, class name, and method name.

\- Do not sacrifice technical accuracy when simplifying explanations.



\## Session Continuity and Project Context



At the beginning of every new session:



1\. Read the root CLAUDE.md file.

2\. Read docs/project-overview.md to understand the project architecture.

3\. Read docs/ai-work-log.md to identify completed tasks, current progress, and pending work.

4\. Read relevant review documents based on the task, such as:

&#x20;  - docs/module-review.md

&#x20;  - docs/performance-review-day-09.md

&#x20;  - docs/week-01-review.md

5\. Inspect the current Git branch and working tree using:

&#x20;  - git status

&#x20;  - git branch --show-current

6\. Review the latest relevant Git commits when necessary.



\### Continuation Rules



\- Continue from the latest documented project state.

\- Do not assume that a task was completed just because it was planned.

\- Verify actual code, Git history, and test results before making decisions.

\- Do not repeat completed tasks unless verification is necessary.

\- Do not overwrite or discard existing user changes.

\- If documentation and actual code disagree, report the inconsistency before proceeding.



\### End-of-Session Rules



At the end of each working session:



1\. Update docs/ai-work-log.md.

2\. Record completed and incomplete tasks.

3\. Record modified files and important technical decisions.

4\. Record actual Build and Test results.

5\. Document identified risks and unresolved issues.

6\. Specify the exact recommended next step.



Never commit, push, merge, revert, or deploy without explicit user approval.

