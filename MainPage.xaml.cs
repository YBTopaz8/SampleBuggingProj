using UraniumUI.Pages;

namespace SampleBuggingProj;

public partial class MainPage : UraniumContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
        this.Attachments.Add(IPlatformApplication.Current.Services.GetService<NowPlayingBtmSheet>());   

    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}

