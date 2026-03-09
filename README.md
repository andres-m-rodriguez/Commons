# Commons

Shared .NET 10 libraries for Blazor applications.

## Libraries

| Package | Description | Dependencies |
|---------|-------------|--------------|
| `Commons.Http` | QueryStringBuilder | - |
| `Commons.Results` | Result<T> pattern | - |
| `Commons.Pagination` | Cursor-based pagination | Http |
| `Commons.Pagination.Blazor` | VirtualizedList component | Pagination |

## Use as Template

1. Click **Use this template** on GitHub
2. Clone your new repository
3. Run setup to select libraries:

```powershell
# Interactive mode
./setup.ps1

# Or specify directly
./setup.ps1 -Results -Pagination

# Keep all
./setup.ps1 -All
```
