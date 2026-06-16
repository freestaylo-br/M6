using M6.Models;
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

    private async void AddPartner_Clicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync(
            nameof(EditPartnerPage));
    }

    private async void Partners_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        var partner =
            e.CurrentSelection
                .FirstOrDefault() as Partner;

        if (partner == null)
            return;

        PartnersCollection.SelectedItem =
            null;

        await Navigation.PushAsync(
            new EditPartnerPage(partner));
    }
}