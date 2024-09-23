namespace BreakTime.Custom;

public class TimerLogic
{
    private int _intMin;

    public TimerLogic()
    {
        Reset();
    }

    public void Reset()
    {
        _intMin = 0;
    }

    public void SetTickCount()
    {
        _intMin++;
    }

    public int GetMinutes()
    {
        return _intMin;
    }
    public string GetFormattedString(int mins)
    {
        string minsLeft = (mins - _intMin).ToString();
        return minsLeft + " Minutes Left";
    }
}