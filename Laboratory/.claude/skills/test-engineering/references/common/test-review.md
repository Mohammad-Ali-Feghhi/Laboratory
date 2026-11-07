
# Test Quality Review

Review test code using the following criteria.

## 1. Behavior

Does the test verify meaningful externally observable behavior?

Does it verify the actual business requirement?

## 2. Assertions

Are assertions specific and meaningful?

A test that only checks whether an exception occurred may be insufficient when the returned result can also be verified.

## 3. Failure Sensitivity

Would the test fail if the intended behavior were broken?

Avoid tests that pass regardless of the actual result.

## 4. Isolation

Check for:

- Shared mutable state
- Execution-order dependencies
- Database record conflicts
- Resource leaks
- Uncontrolled external dependencies

## 5. Determinism

Avoid arbitrary sleeps.

Control time, random values, generated identifiers, and external dependencies when appropriate.

## 6. Mocking

Do not mock every dependency.

Prefer testing real domain logic.

Use mocks for external boundaries and dependencies whose behavior must be controlled.

## 7. Compatibility

Verify compatibility between:

- Runtime
- Test framework
- Test runner
- ORM
- Database provider
- Assertion library
- Mocking library

## 8. Maintainability

Check:

- Naming
- Readability
- Arrange/Act/Assert structure
- Duplication
- Fixture complexity
- Failure messages

## 9. Security

Ensure tests do not contain:

- Real passwords
- Production tokens
- Private keys
- Production connection strings
- Unsafe shortcuts

## 10. Review Findings

For every finding, report:

- Severity
- File and location
- Problem
- Potential consequence
- Recommended correction

Never modify tests just to make them pass.
