# Contributing to MAUI Blazor Hybrid Windows Sample

Thank you for your interest in contributing to this project! This document provides guidelines and instructions for contributing.

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Focus on what is best for the community
- Show empathy towards other community members

## How to Contribute

### Reporting Bugs

Before creating a bug report:
1. Check if the bug has already been reported in Issues
2. Verify you're using a supported Windows version (10 1809+)
3. Ensure all prerequisites are installed correctly

When reporting a bug, include:
- Windows version
- .NET SDK version (`dotnet --version`)
- Visual Studio version (if applicable)
- Steps to reproduce
- Expected behavior
- Actual behavior
- Screenshots if applicable
- Error messages and stack traces

### Suggesting Enhancements

Enhancement suggestions are welcome! Please:
1. Check if it's already suggested in Issues
2. Provide a clear use case
3. Explain why this enhancement would be useful
4. Consider if it fits the project's scope

### Pull Requests

1. **Fork the repository**
2. **Create a feature branch**
   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make your changes**
   - Follow the existing code style
   - Add comments for complex logic
   - Update documentation if needed
   - Test your changes thoroughly

4. **Commit your changes**
   ```bash
   git commit -m "Add: Brief description of your changes"
   ```
   Use prefixes:
   - `Add:` for new features
   - `Fix:` for bug fixes
   - `Update:` for updates to existing features
   - `Refactor:` for code refactoring
   - `Docs:` for documentation changes

5. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create a Pull Request**
   - Provide a clear title and description
   - Reference any related issues
   - Include screenshots for UI changes

## Development Guidelines

### Code Style

- Use C# naming conventions (PascalCase for classes/methods, camelCase for variables)
- Use meaningful variable and method names
- Keep methods focused and small
- Use async/await for I/O operations
- Dispose resources properly (using statements)

### Project Structure

- **Components/**: UI components only
- **Data/**: Database context and configurations
- **Models/**: Entity models (POCOs)
- **Services/**: Business logic and external integrations
- Keep layers separate (UI, Business Logic, Data Access)

### Testing

- Add unit tests for services
- Test CRUD operations
- Test edge cases and error handling
- Ensure tests pass before submitting PR

### Documentation

- Update README.md for new features
- Add XML comments for public APIs
- Update BUILD.md if build process changes
- Add entries to CHANGELOG.md

## Specific Contribution Areas

### 1. Grid Component Enhancement
Replace standard HTML tables with advanced grids:
- Telerik UI for MAUI
- Syncfusion DataGrid
- DevExpress Grid

**Requirements**:
- Maintain current interface
- Support sorting, filtering, paging
- Document installation and setup

### 2. Real Report Service Implementation
Implement actual report generation:
- AS-Report integration
- SpreadsheetGear integration
- Other reporting engines

**Requirements**:
- Implement IReportService interface
- Include sample templates
- Document usage and licensing

### 3. Excel Schema Processor
Extend Excel definition system:
- Dynamic entity generation from Excel
- Schema validation
- Migration generation

**Requirements**:
- Maintain backward compatibility
- Handle validation errors gracefully
- Document Excel format

### 4. Authentication & Authorization
Add user management:
- Windows Authentication
- Azure AD integration
- Role-based access control

**Requirements**:
- Use ASP.NET Core Identity
- Secure sensitive operations
- Document setup

### 5. Web Version
Create Blazor Server/WASM version:
- Share data models and services
- Adapt UI for web
- Handle offline scenarios

**Requirements**:
- Maximize code reuse
- Document differences
- Consider security implications

## Review Process

1. **Automated Checks**: PRs must pass automated checks
2. **Code Review**: At least one maintainer review required
3. **Testing**: Changes must be tested on Windows
4. **Documentation**: Required for user-facing changes

## Questions?

Feel free to:
- Open an issue for discussion
- Ask in pull request comments
- Contact maintainers

## License

By contributing, you agree that your contributions will be licensed under the same license as the project (MIT License).

Thank you for contributing! 🎉
