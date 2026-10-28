# SharpUtils

> Lightweight, dependency-free utility helpers for everyday C# development.

SharpUtils is a small open-source library of the helper methods .NET developers
end up rewriting in every project — string cleanup, date math, collection
helpers, number utilities and basic validation — packaged once, tested, and
ready to drop into any .NET 8 project.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)
![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)
![Tests](https://img.shields.io/badge/tests-40%2B%20passing-brightgreen)

## Features

- **StringExtensions** — `ToSlug`, `Truncate`, `NormalizeSpaces`, `CountWords`, `ReverseWords`, `IsPalindrome`, `ToCamelCase`
- **DateTimeExtensions** — `StartOfDay`, `EndOfDay`, `StartOfWeek`, `IsWeekend`, `AddBusinessDays`, `Age`, `DaysBetween`
- **CollectionExtensions** — `IsNullOrEmpty`, `ForEach`, `Partition`, `Batch`, `RandomElement`
- **NumericExtensions** — `IsEven`, `IsOdd`, `IsInRange`, `Clamp`, `PercentageOf`, `RoundToNearest`, `ToFileSize`
- **ValidationHelper** — `IsValidEmail`, `IsValidUrl`, `IsStrongPassword`, `IsValidPhoneNumber`

Zero external dependencies. Every method is covered by unit tests.

## Quick start

Clone and build:

```bash
git clone https://github.com/Daimx1214/SharpUtils.git
cd SharpUtils
dotnet build
dotnet test
```

Reference the project from your own app:

```bash
dotnet add reference src/SharpUtils/SharpUtils.csproj
```

## Usage

```csharp
using SharpUtils;

// Strings
"Hello World!".ToSlug();              // "hello-world"
"a very long sentence".Truncate(8);   // "a very …"
"one two three".ReverseWords();       // "three two one"

// Dates
var friday = new DateTime(2026, 10, 30);
friday.AddBusinessDays(1);            // Monday 2026-11-02 (skips the weekend)
new DateTime(2000, 6, 15).Age();      // age in whole years

// Collections
var (evens, odds) = new[] { 1, 2, 3, 4 }.Partition(x => x.IsEven());

// Validation
ValidationHelper.IsValidEmail("daim@example.com");  // true
ValidationHelper.IsStrongPassword("Str0ngPass");   // true

// Numbers
1536L.ToFileSize();                   // "1.5 KB"
50.0.PercentageOf(200.0);             // 25
```

## Project structure

```
src/SharpUtils/          the library (net8.0, no dependencies)
tests/SharpUtils.Tests/  xUnit test suite
```

## Contributing

Contributions are welcome — see [CONTRIBUTING.md](CONTRIBUTING.md).
Small, focused helpers with tests are the best fit for this project.

## License

Released under the [MIT License](LICENSE).

## Author

**Daim Ali** — BS Computer Science student, .NET backend developer in training.
GitHub: [@Daimx1214](https://github.com/Daimx1214) · LinkedIn: [daimx1214](https://www.linkedin.com/in/daimx1214/)
