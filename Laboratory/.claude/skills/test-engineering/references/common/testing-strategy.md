
# Testing Strategy

## 1. Testing Levels

Select the appropriate test level based on the behavior being tested.

### Unit Testing

Use for:
- Business rules
- Domain logic
- Validators
- Calculations
- Value objects
- Independent application services

Characteristics:
- Fast
- Isolated
- Deterministic
- No real database dependency

### Component Testing

Use when testing a component together with selected real dependencies.

### Integration Testing

Use for:
- Database interactions
- ORM behavior
- Dependency injection
- Framework configuration
- HTTP communication
- Authentication middleware
- Serialization
- Messaging

### Contract Testing

Use when independently developed services communicate through APIs or messaging contracts.

### End-to-End Testing

Use for critical business workflows across multiple application layers.

Keep these tests limited and maintainable.

### Architecture Testing

Use when the project has explicit architectural boundaries or dependency rules.

### Performance and Security Testing

Treat these as dedicated testing activities.

Do not assume ordinary unit tests prove performance or security.

## 2. Repository Analysis

Inspect:

- Build files
- Project files
- Dependencies
- Existing tests
- Runtime versions
- Database provider
- CI configuration
- Application architecture

Do not recommend a test framework before identifying the existing project setup.

## 3. Test Case Design

Consider the following scenarios:

- Successful execution
- Invalid input
- Missing data
- Duplicate data
- Boundary values
- Unauthorized access
- Forbidden access
- Dependency failure
- Timeout
- Cancellation
- Transaction rollback
- Previously identified defects

Only include scenarios relevant to the actual behavior.

## 4. Test Naming

Follow existing repository conventions.

If no convention exists, use:

MethodOrBehavior_Scenario_ExpectedOutcome

Examples:

CalculateTotal_WithValidItems_ReturnsExpectedTotal

CreateEmployee_WithDuplicateCode_ReturnsConflict

## 5. Test Isolation

Every test should be independently executable.

Avoid:
- Shared mutable state
- Execution-order dependencies
- Arbitrary delays
- Uncontrolled random data
- Shared database records
- Unreliable external services

## 6. Coverage

Coverage is a diagnostic metric.

Prioritize:
- Critical business rules
- Security-sensitive operations
- Complex branches
- Financial calculations
- Persistence boundaries

Do not optimize only for a percentage.

Do not introduce mandatory coverage thresholds without approval.
