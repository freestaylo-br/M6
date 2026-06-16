using M6.Models;
using M6.Services;

namespace M6.Views;

public partial class EditPartnerPage : ContentPage
{
    private readonly ApiService _api =
        new();

    private Partner? currentPartner;

    private bool isEditMode;

    public EditPartnerPage()
    {
        InitializeComponent();

        TitleLabel.Text =
            "Добавление партнера";

        DeleteButton.IsVisible = false;

        LoadTypes();
    }

    public EditPartnerPage(
        Partner partner)
    {
        InitializeComponent();

        currentPartner = partner;

        isEditMode = true;

        TitleLabel.Text =
            "Редактирование партнера";

        LoadTypes();

        LoadPartner();
    }

    private void LoadTypes()
    {
        PartnerTypePicker.ItemsSource =
            new List<string>
            {
                "ЗАО",
                "ООО",
                "ПАО",
                "ОАО",
                "ИП"
            };
    }

    private void LoadPartner()
    {
        if (currentPartner == null)
            return;

        PartnerNameEntry.Text =
            currentPartner.PartnerName;

        PartnerTypePicker.SelectedItem =
            currentPartner.PartnerType;

        RatingEntry.Text =
            currentPartner.Rating;

        DirectorLastNameEntry.Text =
            currentPartner.DirectorLastname;

        DirectorFirstNameEntry.Text =
            currentPartner.DirectorFirstname;

        DirectorPatronymicEntry.Text =
            currentPartner.DirectorPatronymic;

        PhoneEntry.Text =
            currentPartner.PhoneNumber;

        EmailEntry.Text =
            currentPartner.Email;

        IndexEntry.Text =
            currentPartner.Index;

        RegionEntry.Text =
            currentPartner.Region;

        CityEntry.Text =
            currentPartner.City;

        StreetEntry.Text =
            currentPartner.Street;

        HouseEntry.Text =
            currentPartner.HouseNumber;

        InnEntry.Text =
            currentPartner.Inn;
    }

    private async void Save_Clicked(
    object sender,
    EventArgs e)
    {
        try
        {
            if (!int.TryParse(
                    RatingEntry.Text,
                    out int rating))
            {
                await DisplayAlert(
                    "Ошибка",
                    "Рейтинг должен быть числом",
                    "OK");

                return;
            }

            if (rating < 0)
            {
                await DisplayAlert(
                    "Ошибка",
                    "Рейтинг не может быть отрицательным",
                    "OK");

                return;
            }

            var partner =
                new Partner
                {
                    IdPartner =
                        currentPartner?.IdPartner ?? 0,

                    PartnerType =
                        PartnerTypePicker.SelectedItem
                            ?.ToString() ?? "",

                    PartnerName =
                        PartnerNameEntry.Text ?? "",

                    DirectorLastname =
                        DirectorLastNameEntry.Text ?? "",

                    DirectorFirstname =
                        DirectorFirstNameEntry.Text ?? "",

                    DirectorPatronymic =
                        DirectorPatronymicEntry.Text ?? "",

                    PhoneNumber =
                        PhoneEntry.Text ?? "",

                    Email =
                        EmailEntry.Text ?? "",

                    Index =
                        IndexEntry.Text ?? "",

                    Region =
                        RegionEntry.Text ?? "",

                    City =
                        CityEntry.Text ?? "",

                    Street =
                        StreetEntry.Text ?? "",

                    HouseNumber =
                        HouseEntry.Text ?? "",

                    Inn =
                        InnEntry.Text ?? "",

                    Rating =
                        rating.ToString()
                };

            bool result;

            if (isEditMode)
            {
                result =
                    await _api.UpdatePartnerAsync(
                        partner);
            }
            else
            {
                result =
                    await _api.CreatePartnerAsync(
                        partner);
            }

            if (result)
            {
                await DisplayAlert(
                    "Информация",
                    "Данные сохранены",
                    "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(
                    "Ошибка",
                    "Не удалось сохранить данные",
                    "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Ошибка",
                ex.Message,
                "OK");
        }
    }

    private async void Delete_Clicked(
    object sender,
    EventArgs e)
    {
        if (currentPartner == null)
            return;

        bool confirm =
            await DisplayAlert(
                "Предупреждение",
                "Удалить партнера?",
                "Да",
                "Нет");

        if (!confirm)
            return;

        var result =
            await _api.DeletePartnerAsync(
                currentPartner.IdPartner);

        if (result)
        {
            await DisplayAlert(
                "Информация",
                "Партнер удален",
                "OK");

            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert(
                "Ошибка",
                "Не удалось удалить партнера",
                "OK");
        }
    }

    private async void Back_Clicked(
        object sender,
        EventArgs e)
    {
        await Navigation.PopAsync();
    }
}