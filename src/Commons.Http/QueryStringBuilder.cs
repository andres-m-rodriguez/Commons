namespace Commons.Http;

public sealed class QueryStringBuilder
{
    private readonly List<string> _parameters = [];

    public QueryStringBuilder Add(string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            _parameters.Add($"{key}={Uri.EscapeDataString(value)}");
        }

        return this;
    }

    public QueryStringBuilder Add(string key, int? value)
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={value.Value}");
        }

        return this;
    }

    public QueryStringBuilder Add(string key, decimal? value)
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={value.Value}");
        }

        return this;
    }

    public QueryStringBuilder Add(string key, Guid? value)
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={value.Value}");
        }

        return this;
    }

    public QueryStringBuilder Add(string key, bool? value)
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={value.Value.ToString().ToLowerInvariant()}");
        }

        return this;
    }

    public QueryStringBuilder Add(string key, DateTimeOffset? value)
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={Uri.EscapeDataString(value.Value.ToString("O"))}");
        }

        return this;
    }

    public QueryStringBuilder Add(string key, DateTime? value)
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={Uri.EscapeDataString(value.Value.ToString("O"))}");
        }

        return this;
    }

    public QueryStringBuilder Add<T>(string key, T? value) where T : struct, Enum
    {
        if (value.HasValue)
        {
            _parameters.Add($"{key}={Uri.EscapeDataString(value.Value.ToString())}");
        }

        return this;
    }

    public string Build()
    {
        return _parameters.Count > 0 ? $"?{string.Join("&", _parameters)}" : string.Empty;
    }
}
