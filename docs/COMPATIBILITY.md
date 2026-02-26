# Framework Compatibility

This document describes the framework compatibility and security considerations for `qckdev.Extensions.Configuration.Abstractions`.

## Supported Frameworks

This package supports the following target frameworks:

| Framework | Status | Support Level |
|-----------|--------|---------------|
| .NET Standard 2.0 | ✅ Supported | Legacy compatibility |
| .NET Core 3.1 | ✅ Supported | End of Life (EOL) - December 2022 |
| .NET 8.0 | ✅ Supported | LTS - Supported until November 2026 |
| .NET 10.0 | ✅ Supported | Current - Supported until November 2027 |

## Package Versions

The library uses different versions of `Microsoft.Extensions.Configuration.Abstractions` depending on the target framework to ensure compatibility and security:

| Framework | Configuration.Abstractions Version |
|-----------|-------------------------------------|
| netstandard2.0 | 6.0.0 |
| netcoreapp3.1 | 3.1.25 |
| net8.0 | 8.0.0 |
| net10.0 | 10.0.0 |

## Security Considerations

### Version Selection Strategy

The package versions were selected using the **Minimum Viable Product (MVP)** approach:
- ✅ Uses the **minimum version** required to address known vulnerabilities
- ✅ Avoids unnecessary updates that might introduce breaking changes
- ✅ Maintains compatibility with older frameworks for legacy support
- ✅ Regular security audits using `dotnet list package --vulnerable`

### Vulnerability Mitigations

There are no known critical vulnerabilities in `Microsoft.Extensions.Configuration.Abstractions` at the versions used. Run the following command periodically to verify:

```powershell
dotnet list package --vulnerable --include-transitive
```

Expected output:
```
The given project has no vulnerable packages given the current sources.
```

## Package Version Analysis

This section compares the versions used in this project with the latest available versions for each framework.

### .NET Standard 2.0

| Package | Current | Latest for Framework | What's Missing |
|---------|---------|---------------------|----------------|
| Microsoft.Extensions.Configuration.Abstractions | **6.0.0** | 6.0.0 | ✅ Using latest for netstandard2.0 |

**Notes**:
- 6.0.0 is the recommended version for .NET Standard 2.0 compatibility, providing a stable API surface
- Newer versions (7.0+) target .NET-specific frameworks and may not fully support .NET Standard 2.0

### .NET Core 3.1 (EOL December 2022)

| Package | Current | Latest for 3.1 | What's Missing |
|---------|---------|----------------|----------------|
| Microsoft.Extensions.Configuration.Abstractions | **3.1.25** | **3.1.32** | Minor updates (3.1.26-3.1.32) |

**What's in newer versions**:
- **3.1.26-3.1.32**:
  - Minor bug fixes and stability improvements
  - No new security vulnerabilities fixed
  - No breaking changes

**Recommendation**: ⚠️ Framework is EOL. Prioritize migrating to .NET 8.0 LTS rather than updating packages.

### .NET 8.0 (LTS until November 2026)

| Package | Current | Latest for 8.0 | What's Missing |
|---------|---------|----------------|----------------|
| Microsoft.Extensions.Configuration.Abstractions | **8.0.0** | **8.0.3** | Minor updates (8.0.1-8.0.3) |

**What's in newer versions (8.0.1-8.0.3)**:
- **8.0.1** (February 2024): Stability improvements
- **8.0.2** (April 2024): Bug fixes
- **8.0.3** (August 2024): Performance optimizations and minor bug fixes

**Known Issues in 8.0.0**:
- Minor edge cases in configuration binding (fixed in 8.0.1)

**Recommendation**: ✅ Update to 8.0.3 for latest stability and performance improvements.

**Security Impact**: Low - No known security vulnerabilities in 8.0.0.

### .NET 10.0 (Current until November 2027)

| Package | Current | Latest for 10.0 | What's Missing |
|---------|---------|-----------------|----------------|
| Microsoft.Extensions.Configuration.Abstractions | **10.0.0** | **10.0.0** | ✅ Using latest |

**Notes**:
- 10.0.0 is the initial stable release for .NET 10.0
- .NET 10.0 is actively maintained and receiving regular updates

**Recommendation**: ✅ Keep up to date as new patch versions are released.

## Update Strategy Recommendations

### Priority 1: Critical (Do Immediately)
- **None** - No critical unpatched vulnerabilities detected

### Priority 2: High (Within 1 Month)
- **None** at this time

### Priority 3: Medium (Within 3 Months)
- **.NET 8.0**: Update to 8.0.3 for latest stability and performance patches
- **.NET Core 3.1**: Prioritize migration over package updates

### Priority 4: Low (When Convenient)
- **.NET Standard 2.0**: Already using latest recommended version
- **.NET 10.0**: Already using latest version

### Migration Path

For applications using EOL frameworks:

1. **.NET Core 3.1** → Migrate to .NET 8.0 LTS
2. **.NET Standard 2.0** → Upgrade to .NET 8.0 or .NET 10.0 for new projects

## Migration Guide

### From .NET Standard 2.0
If you're using .NET Standard 2.0 and want to migrate to a newer framework:
- **.NET Core 3.1**: Direct drop-in replacement (note: EOL)
- **.NET 8.0**: Recommended for LTS support
- **.NET 10.0**: Recommended for latest features

### End of Life (EOL) Frameworks
If you're using EOL frameworks (.NET Core 3.1):
- ⚠️ This framework no longer receives security updates from Microsoft
- ⚠️ Consider migrating to .NET 8.0 (LTS) for continued support
- ✅ This package provides compatibility support for this framework

## Additional Resources

- [Microsoft .NET Support Policy](https://dotnet.microsoft.com/platform/support/policy)
- [Microsoft.Extensions.Configuration on NuGet](https://www.nuget.org/packages/Microsoft.Extensions.Configuration.Abstractions)
- [NuGet Package Vulnerabilities](https://github.com/advisories?query=ecosystem%3Anuget)

## Last Updated

Document last updated: February 26, 2026

For the latest information, please check the [GitHub repository](https://github.com/hfrances/qckdev.Extensions.Configuration.Abstractions).
