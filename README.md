# C# REST API Test Automation Framework

An automated end-to-end API testing framework built with **C#**, **.NET 10**, **RestSharp**, and **NUnit**. This project targets the [Restful Booker API](https://restful-booker.herokuapp.com) to validate core RESTful CRUD operations, HTTP response status codes, payload serialization, and JSON schema parsing.

---

## 🛠️ Tech Stack & Dependencies

* **Language:** C#
* **Framework:** .NET 10 SDK
* **HTTP Client:** [RestSharp](https://restsharp.dev/)
* **Test Runner:** [NUnit](https://nunit.org/)
* **JSON Parser:** [Newtonsoft.Json](https://www.newtonsoft.com/json)

---

## 🏗️ Framework Architecture

This framework follows the **Service Object Pattern** (a variation of the Page Object Model applied to API testing). By decoupling the raw HTTP request setup from the test logic, the framework remains highly maintainable, scalable, and readable.

```text
ApiTestDemo/
├── Models/             # Data Transfer Objects (DTOs) for Serialization / Deserialization
│   └── AuthRequest.cs  # Payload blueprint for /auth endpoint
├── Endpoints/          # Service Layer / HTTP Client wrappers
│   └── AuthClient.cs   # RestSharp request construction & execution
└── Tests/              # NUnit Test Suites & Assertions (AAA Pattern)
    └── AuthTests.cs    # Test methods verifying status codes and tokens