using BreakTime.Custom;
namespace BreakTime;

public partial class MainPage : ContentPage
{
    private TimerLogic oTimer = new TimerLogic();
    private CancellationTokenSource _cancel;
    private bool flash = false;

    public MainPage()
    {
        InitializeComponent();
        Title = "Break Time";
    }

    private void StartFlashing()
    {
        _cancel?.Cancel();
        _cancel = new CancellationTokenSource();
        var localCancel = _cancel;
        oTimer.Reset();
        
        Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (localCancel.IsCancellationRequested)
                return false;
            
            lblDisplay.Text = "Time is up!";
            if (flash)
            {
                flash = false;
                pgContent.Background = Colors.Red;
            }
            else
            {
                flash = true;
                pgContent.Background = Colors.White;
            }

            return true;
        });
        
    }

    private void StartTimer(int minutes)
    {
        _cancel?.Cancel();
        _cancel = new CancellationTokenSource();
        var localCancel = _cancel;
        oTimer.Reset();

        pgContent.Background = Colors.White;
        
        Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            if (localCancel.IsCancellationRequested)
                return false;

            oTimer.SetTickCount();
            lblDisplay.Text = oTimer.GetFormattedString(minutes);

            if (oTimer.GetMinutes() >= minutes)
            {
                StartFlashing();
                return false;
            }
            
            return oTimer.GetMinutes() < minutes;
        });
    }

    private void TakeFive_OnClicked(object sender, EventArgs e)
    {
        StartTimer(5);
    }

    private void TakeTen_OnClicked(object sender, EventArgs e)
    {
        StartTimer(10);
    }

    private void TakeFifteen_OnClicked(object sender, EventArgs e)
    {
        StartTimer(15);
    }
}