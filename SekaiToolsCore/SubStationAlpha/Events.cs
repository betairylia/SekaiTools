using System.Text;

namespace SekaiToolsCore.SubStationAlpha;

public class Events(IEnumerable<Event> items)
{
    private readonly List<Event> _subtitleEventItems = items.ToList();

    public Events() : this(Enumerable.Empty<Event>())
    {
    }

    public Events(string source) : this()
    {
        _subtitleEventItems = (
            from s in source.Split('\n')
            where s.StartsWith("Dialogue:") || s.StartsWith("Comment:")
            select Event.FromString(s)
        ).ToList();
    }

    public override string ToString()
    {
        List<string> sb =
            ["[Events]", "Format: Layer, Start, End, Style, Name, MarginL, MarginR, MarginV, Effect, Text"];
        sb.AddRange(_subtitleEventItems.Select(subtitleEventItem => subtitleEventItem.ToString()));
        return string.Join("\n", sb).Trim();
    }

    public string ToSRTString(int startsFrom = 0)
    {
        StringBuilder sb = new StringBuilder();
        int i = 1;
        foreach (var e in _subtitleEventItems)
        {
            sb.Append($"{startsFrom + i}\n{e.ToSRTString()}\n\n");
            i++;
        }

        return sb.ToString();
    }

    public void Add(Event item)
    {
        _subtitleEventItems.Add(item);
    }
}