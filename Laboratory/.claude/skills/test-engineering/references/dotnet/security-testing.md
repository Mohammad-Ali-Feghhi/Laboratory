
# .NET Security Testing

## 1. Discover Security Architecture

Identify whether the project uses:

- ASP.NET Core Identity
- Custom authentication
- JWT Bearer
- Cookie Authentication
- Claims
- Roles
- Policies
- Custom authorization handlers

## 2. Authentication Tests

Test:

- Valid credentials
- Invalid credentials
- Missing credentials
- Expired tokens
- Invalid signatures
- Invalid issuer
- Invalid audience
- Disabled accounts
- Locked accounts

Only test behavior implemented by the application.

## 3. Authorization Tests

Test:

- Anonymous users
- Authenticated users
- Forbidden operations
- Role restrictions
- Claim restrictions
- Policy restrictions
- Resource ownership

A user must not access another user's protected resources without authorization.

## 4. Password Tests

Where applicable, test:

- Password hashing
- Password verification
- Password change
- Invalid old password
- Password validation
- Account lockout

Never assume plain-text password storage is acceptable.

## 5. Sensitive Data

Check that:

- Passwords are not logged.
- Tokens are not exposed in error responses.
- Connection strings are not included in reports.
- Secrets are not stored in test files.

## 6. Security Boundaries

Never disable authentication or authorization simply to make tests pass.

Use synthetic users, test-only signing keys, and isolated test configuration.

Security tests do not replace professional penetration testing.
