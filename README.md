# Commons

Shared .NET 10 libraries for Blazor applications.

## Libraries

| Package | Description | Dependencies |
|---------|-------------|--------------|
| `Commons.Http` | QueryStringBuilder | - |
| `Commons.Results` | Result<T> pattern | - |
| `Commons.Pagination` | Cursor-based pagination | Http |
| `Commons.Pagination.Blazor` | VirtualizedList component | Pagination |

## Installation

```powershell
# Install the template
dotnet new install andres-m-rodriguez/Commons

# Create with all libraries
dotnet new commons -n MyProject
cd MyProject
./init.ps1

# Or select specific libraries
dotnet new commons -n MyProject --Results false --PaginationBlazor false
cd MyProject
./init.ps1
```

## Template Parameters

| Parameter | Default | Description |
|-----------|---------|-------------|
| `--Http` | true | Include QueryStringBuilder |
| `--Results` | true | Include Result<T> pattern |
| `--Pagination` | true | Include cursor pagination |
| `--PaginationBlazor` | true | Include VirtualizedList |

Dependencies are handled automatically (Pagination.Blazor includes Pagination and Http).
