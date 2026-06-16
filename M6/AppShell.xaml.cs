namespace M6;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(
            nameof(Views.EditPartnerPage),
            typeof(Views.EditPartnerPage));
    }
}