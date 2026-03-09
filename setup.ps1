# Commons Setup Script
# Run this after cloning to select which libraries to include

param(
    [switch]$Http,
    [switch]$Results,
    [switch]$Pagination,
    [switch]$PaginationBlazor,
    [switch]$All
)

$root = $PSScriptRoot

if ($All) {
    Write-Host "Keeping all libraries" -ForegroundColor Green
    exit 0
}

if (-not ($Http -or $Results -or $Pagination -or $PaginationBlazor)) {
    Write-Host "Commons Setup" -ForegroundColor Cyan
    Write-Host ""
    Write-Host "Select libraries to include:"
    Write-Host ""

    $includeHttp = (Read-Host "Include Commons.Http? (y/n)") -eq 'y'
    $includeResults = (Read-Host "Include Commons.Results? (y/n)") -eq 'y'
    $includePagination = (Read-Host "Include Commons.Pagination? (y/n)") -eq 'y'
    $includePaginationBlazor = (Read-Host "Include Commons.Pagination.Blazor? (y/n)") -eq 'y'
} else {
    $includeHttp = $Http
    $includeResults = $Results
    $includePagination = $Pagination
    $includePaginationBlazor = $PaginationBlazor
}

# Pagination.Blazor requires Pagination
if ($includePaginationBlazor) { $includePagination = $true }

# Pagination requires Http
if ($includePagination) { $includeHttp = $true }

$removed = @()

if (-not $includeHttp) {
    Remove-Item -Recurse -Force "$root\src\Commons.Http"
    $removed += "Commons.Http"
}

if (-not $includeResults) {
    Remove-Item -Recurse -Force "$root\src\Commons.Results"
    $removed += "Commons.Results"
}

if (-not $includePagination) {
    Remove-Item -Recurse -Force "$root\src\Commons.Pagination"
    $removed += "Commons.Pagination"
}

if (-not $includePaginationBlazor) {
    Remove-Item -Recurse -Force "$root\src\Commons.Pagination.Blazor"
    $removed += "Commons.Pagination.Blazor"
}

# Regenerate solution
Remove-Item "$root\Commons.sln" -ErrorAction SilentlyContinue
dotnet new sln -n Commons -o $root

Get-ChildItem -Path "$root\src" -Filter "*.csproj" -Recurse | ForEach-Object {
    dotnet sln "$root\Commons.sln" add $_.FullName
}

Write-Host ""
if ($removed.Count -gt 0) {
    Write-Host "Removed: $($removed -join ', ')" -ForegroundColor Yellow
}
Write-Host "Setup complete!" -ForegroundColor Green
Write-Host ""
Write-Host "Run 'dotnet build' to verify"
