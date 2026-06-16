using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using M6.Models;
using M6.Services;

namespace M6.ViewModels;

public class PartnersViewModel :
    INotifyPropertyChanged
{
    private readonly ApiService _api =
        new();

    private ObservableCollection<Partner>
        partners = new();

    public ObservableCollection<Partner>
        Partners
    {
        get => partners;
        set
        {
            partners = value;
            OnPropertyChanged();
        }
    }

    public PartnersViewModel()
    {
        _ = LoadPartners();
    }

    public async Task LoadPartners()
    {
        var data =
            await _api.GetPartners();

        Partners =
            new ObservableCollection<Partner>(
                data);
    }

    public event PropertyChangedEventHandler?
        PropertyChanged;

    private void OnPropertyChanged(
        [CallerMemberName]
        string propertyName = "")
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(
                propertyName));
    }
}