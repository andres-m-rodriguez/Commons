using System.Text;

namespace Commons.Pagination;

/// <summary>
/// Helper methods for encoding/decoding opaque cursors.
/// Use this when you want to hide the internal cursor format from clients.
/// </summary>
public static class CursorHelper
{
    public static string Encode(Guid id)
    {
        return Convert.ToBase64String(id.ToByteArray());
    }

    public static string Encode(int id)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(id.ToString()));
    }

    public static Guid DecodeGuid(string cursor)
    {
        var bytes = Convert.FromBase64String(cursor);
        return new Guid(bytes);
    }

    public static int DecodeInt(string cursor)
    {
        var bytes = Convert.FromBase64String(cursor);
        var idString = Encoding.UTF8.GetString(bytes);
        return int.Parse(idString);
    }

    public static bool TryDecodeGuid(string cursor, out Guid id)
    {
        try
        {
            id = DecodeGuid(cursor);
            return true;
        }
        catch
        {
            id = Guid.Empty;
            return false;
        }
    }

    public static bool TryDecodeInt(string cursor, out int id)
    {
        try
        {
            id = DecodeInt(cursor);
            return true;
        }
        catch
        {
            id = 0;
            return false;
        }
    }
}
