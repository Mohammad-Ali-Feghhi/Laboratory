
# .NET Testing

## 1. Supported Ecosystem

Support the complete .NET ecosystem, including:

- C#
- .NET Framework
- .NET Core
- Modern .NET
- ASP.NET MVC
- ASP.NET Core
- Web API
- Minimal API
- Razor Pages
- Blazor
- WinForms
- WPF
- Entity Framework 6
- Entity Framework Core
- Dapper
- ADO.NET

Default database ecosystem: Microsoft SQL Server.

## 2. Repository Discovery

Inspect:

- .sln
- .csproj
- packages.config
- Directory.Build.props
- Directory.Build.targets
- global.json
- NuGet.config

Identify:

- Target framework
- SDK version
- C# language version
- Project format
- Existing test projects
- ORM
- Database provider
- Existing testing libraries

## 3. Test Frameworks

Supported frameworks:

- xUnit
- NUnit
- MSTest

Prefer the framework already used by the repository.

## 4. Mocking Libraries

Supported options:

- Moq
- NSubstitute
- FakeItEasy

Use one appropriate library unless the repository has a justified reason for multiple libraries.

Do not mock every dependency.

## 5. Supporting Libraries

Consider:

- FluentAssertions
- AutoFixture
- Bogus
- Coverlet
- Microsoft.NET.Test.Sdk

Verify compatibility before recommending any package.

## 6. Legacy .NET Framework

For .NET Framework projects:

- Verify Windows and build-tool requirements.
- Verify reference assemblies.
- Verify test runner compatibility.
- Verify package compatibility.
- Do not assume modern dotnet CLI commands work with every legacy project.

For .NET Framework 4.7.2, verify every package's target-framework support.

## 7. Modern .NET

For .NET Core and modern .NET:

- Verify installed SDK.
- Verify target runtime.
- Verify test SDK compatibility.
- Inspect the project's build configuration.

## 8. Testing Priorities

Prioritize:

1. Domain logic
2. Validators
3. Result objects
4. Application services
5. Business rules
6. Repository behavior
7. API behavior
8. Security
9. Database integration
10. External integrations

## 9. Commands

Discover the correct commands from the repository.

Common examples:

dotnet test

dotnet test path/to/TestProject.csproj

dotnet test --filter FullyQualifiedName~SomeTests

For legacy projects, use the compatible Visual Studio, MSBuild, or test runner workflow.

Never assume a command works without checking the project format.

## 10. Package Safety

Before adding or upgrading packages:

- Check target framework compatibility.
- Check existing package versions.
- Check transitive dependencies.
- Check test runner compatibility.

Obtain approval before modifying dependencies.
