namespace CiocmareanCristianLab7;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();

        this.Content = new VerticalStackLayout
        {
            Children = {
                new Label {
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Text = "Welcome to .NET MAUI!"
                }
            }
        };
    }
}
