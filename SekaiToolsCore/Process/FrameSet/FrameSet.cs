namespace SekaiToolsCore.Process.FrameSet;

public abstract class FrameSet
{
    public abstract bool IsEmpty();
    public abstract IProcessFrame Start();
    public abstract IProcessFrame End();
    public string StartTime(int offset = 0) => Start().StartTime(offset);
    public string EndTime(int offset = 0) => End().EndTime(offset);

    public int StartIndex() => Start().Index;

    public int EndIndex() => End().Index;
}