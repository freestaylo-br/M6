using M6.ViewModels;

namespace M6.Views;

public partial class PartnersPage : ContentPage
{
    private readonly PartnersViewModel vm;

    public PartnersPage()
    {
        InitializeComponent();

        vm = new PartnersViewModel();

        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await vm.LoadPartners();
    }
}