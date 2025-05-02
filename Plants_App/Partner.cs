using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace Plants_App;
using System.Collections.ObjectModel;

public partial class Partner : INotifyPropertyChanged {
    private int _id;
    private string _partnerType = null!;
    private string _partnerName = null!;
    private string _director = null!;
    private string _emailAddress = null!;
    private string _partnerPhone = null!;
    private string _parterUrAddress = null!;
    private long _inn;
    private byte _reyting;
    private float _discount;
    private ObservableCollection<PartnerProduct> _partnerProducts = new ObservableCollection<PartnerProduct>();

    public int Id {
        get => _id;
        set {
            if (_id != value) {
                _id = value;
                OnPropertyChanged();
            }
        }
    }

    public string PartnerType {
        get => _partnerType;
        set {
            if (_partnerType != value) {
                _partnerType = value;
                OnPropertyChanged("PartnerType");
            }
        }
    }

    public string PartnerName {
        get => _partnerName;
        set {
            if (_partnerName != value) {
                _partnerName = value;
                OnPropertyChanged();
            }
        }
    }

    public string Director {
        get => _director;
        set {
            if (_director != value) {
                _director = value;
                OnPropertyChanged();
            }
        }
    }

    public string EmailAddress {
        get => _emailAddress;
        set {
            if (_emailAddress != value) {
                _emailAddress = value;
                OnPropertyChanged();
            }
        }
    }

    public string PartnerPhone {
        get => _partnerPhone;
        set {
            if (_partnerPhone != value) {
                _partnerPhone = value;
                OnPropertyChanged();
            }
        }
    }

    public string ParterUrAddress {
        get => _parterUrAddress;
        set {
            if (_parterUrAddress != value) {
                _parterUrAddress = value;
                OnPropertyChanged();
            }
        }
    }

    public long Inn {
        get => _inn;
        set {
            if (_inn != value) {
                _inn = value;
                OnPropertyChanged();
            }
        }
    }

    public byte Reyting {
        get => _reyting;
        set {
            if (_reyting != value) {
                _reyting = value;
                OnPropertyChanged();
            }
        }
    }

    public float Discount {
        get => _discount;
        set {
            if (Math.Abs(_discount - value) > float.Epsilon) {
                _discount = value;
                OnPropertyChanged();
            }
        }
    }

    public virtual ObservableCollection<PartnerProduct> PartnerProducts {
        get => _partnerProducts;
        set {
            if (_partnerProducts != value) {
                _partnerProducts = value;
                OnPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}