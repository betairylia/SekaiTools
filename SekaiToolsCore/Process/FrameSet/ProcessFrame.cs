using SekaiToolsCore.Process.Model;

namespace SekaiToolsCore.Process.FrameSet;

public interface IProcessFrame
{
    public int Index { get; }

    public FrameRate Fps { get; }

    public string ExactTime(int offset = 0);
    public string StartTime(int offset = 0);
    public string EndTime(int offset = 0);
}

public class ProcessFrame(int index, FrameRate fps) : IProcessFrame
{
    public int Index { get; } = index;

    public FrameRate Fps { get; } = fps;

    public static string Zero => "00:00:00.00";

    public string ExactTime(int offset = 0)
    {
        // return Fps.TimeAtFrame(Index + offset).GetAssFormatted();
        return Fps.TimeAtFrame(Index + offset).GetSrtFormatted();
    }

    public string StartTime(int offset = 0)
    {
        // return Fps.TimeAtFrame(Index + offset, FrameType.Start).GetAssFormatted();
        return Fps.TimeAtFrame(Index + offset, FrameType.Start).GetSrtFormatted();
    }

    public string EndTime(int offset = 0)
    {
        // return Fps.TimeAtFrame(Index + offset, FrameType.End).GetAssFormatted();
        return Fps.TimeAtFrame(Index + offset, FrameType.End).GetSrtFormatted();
    }
}