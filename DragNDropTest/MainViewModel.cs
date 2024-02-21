using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DragNDropTest;

public class MainViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }


    private ObservableCollection<ItemModel> _collection;

    public ObservableCollection<ItemModel> Collection
    {
        get => _collection;
        set => SetField(ref _collection, value);
    }

    public MainViewModel()
    {
        _collection = new ObservableCollection<ItemModel>()
        {
            new ItemModel("ListBoxItem1"),
            new ItemModel("ListBoxItem2"),
            new ItemModel("ListBoxItem3"),
        };
    }
    
    
}

public class ItemModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private string _value;

    public string Value
    {
        get => _value;
        set => SetField(ref _value, value);
    }

    public ItemModel(string value)
    {
        _value = value;
    }
}