# C# REST API Test Automation Framework

An automated API testing project built with C#, .NET, RestSharp, and NUnit. It exercises the Restful Booker API and covers authentication, booking CRUD behavior, configuration loading, and failure handling.

## Tech stack

- C#
- .NET 10 SDK
- RestSharp
- NUnit
- Microsoft.Extensions.Configuration

## Project structure

```text
ApiTestDemo/
├── Endpoints/           # HTTP client wrappers for API operations
├── Models/              # DTOs used for request/response payloads
├── Tests/               # NUnit test suites
├── Utils/               # Configuration, test data loading, and assertion helpers
├── TestData/            # JSON payload files used in tests
└── appsettings.json     # Base URL and credentials
```

## Prerequisites

- .NET 10 SDK installed
- Access to the Restful Booker API

## Configuration

The project reads its base URL and credentials from appsettings.json, and it also supports environment variables:

- API_BASE_URL
- API_ADMIN_USERNAME
- API_ADMIN_PASSWORD

Example:

```powershell
$env:API_BASE_URL = "https://restful-booker.herokuapp.com"
$env:API_ADMIN_USERNAME = "admin"
$env:API_ADMIN_PASSWORD = "password123"
```

## Running the tests

From the project root:

```powershell
dotnet test
```

## CI

A GitHub Actions workflow is included in [.github/workflows/dotnet.yml](.github/workflows/dotnet.yml) to run the suite on push and pull requests.

## What is covered

- Authentication flow
- Booking creation and retrieval
- Negative-path tests
- Configuration loading