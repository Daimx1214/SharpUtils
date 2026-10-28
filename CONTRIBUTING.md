# Contributing to SharpUtils

Thanks for your interest in contributing!

## Getting started

1. Fork the repository and clone your fork.
2. Build and run the tests to make sure everything passes before you change anything:

   ```bash
   dotnet build
   dotnet test
   ```

## What makes a good contribution

- **Small and focused.** One helper (or one fix) per pull request.
- **No new dependencies.** SharpUtils is deliberately dependency-free.
- **Tests included.** Every new helper needs unit tests covering the normal case and at least one edge case.
- **XML docs.** Public methods should have a short `///` summary, matching the existing style.

## Pull requests

1. Create a branch: `git checkout -b add-date-helper`
2. Make your change and run `dotnet test` — all tests must pass.
3. Use a clear commit message that names the change, e.g. `Add DateTime.IsLeapYear extension`.
4. Open the pull request with a short description of what the helper does and why it belongs here.

## Code style

- Follow the existing formatting (4-space indent, file-scoped namespaces).
- Prefer clarity over cleverness — this library is read by learners too.
