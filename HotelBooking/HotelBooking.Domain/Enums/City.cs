using Ardalis.SmartEnum;

namespace HotelBooking.Domain.Enums;

public class City : SmartEnum<City>
{
    public static readonly City Adana = new City("Adana", 1);
    public static readonly City Adýyaman = new City("Adýyaman", 2);
    public static readonly City Afyonkarahisar = new City("Afyonkarahisar", 3);
    public static readonly City Aðrý = new City("Aðrý", 4);
    public static readonly City Amasya = new City("Amasya", 5);
    public static readonly City Ankara = new City("Ankara", 6);
    public static readonly City Antalya = new City("Antalya", 7);
    public static readonly City Artvin = new City("Artvin", 8);
    public static readonly City Aydýn = new City("Aydýn", 9);
    public static readonly City Balýkesir = new City("Balýkesir", 10);
    public static readonly City Bilecik = new City("Bilecik", 11);
    public static readonly City Bingöl = new City("Bingöl", 12);
    public static readonly City Bitlis = new City("Bitlis", 13);
    public static readonly City Bolu = new City("Bolu", 14);
    public static readonly City Burdur = new City("Burdur", 15);
    public static readonly City Bursa = new City("Bursa", 16);
    public static readonly City Çanakkale = new City("Çanakkale", 17);
    public static readonly City Çankýrý = new City("Çankýrý", 18);
    public static readonly City Çorum = new City("Çorum", 19);
    public static readonly City Denizli = new City("Denizli", 20);
    public static readonly City Diyarbakýr = new City("Diyarbakýr", 21);
    public static readonly City Edirne = new City("Edirne", 22);
    public static readonly City Elazýð = new City("Elazýð", 23);
    public static readonly City Erzincan = new City("Erzincan", 24);
    public static readonly City Erzurum = new City("Erzurum", 25);
    public static readonly City Eskiþehir = new City("Eskiþehir", 26);
    public static readonly City Gaziantep = new City("Gaziantep", 27);
    public static readonly City Giresun = new City("Giresun", 28);
    public static readonly City Gümüþhane = new City("Gümüþhane", 29);
    public static readonly City Hakkari = new City("Hakkari", 30);
    public static readonly City Hatay = new City("Hatay", 31);
    public static readonly City Isparta = new City("Isparta", 32);
    public static readonly City Mersin = new City("Mersin", 33);
    public static readonly City Ýstanbul = new City("Ýstanbul", 34);
    public static readonly City Ýzmir = new City("Ýzmir", 35);
    public static readonly City Kars = new City("Kars", 36);
    public static readonly City Kastamonu = new City("Kastamonu", 37);
    public static readonly City Kayseri = new City("Kayseri", 38);
    public static readonly City Kýrklareli = new City("Kýrklareli", 39);
    public static readonly City Kýrþehir = new City("Kýrþehir", 40);
    public static readonly City Kocaeli = new City("Kocaeli", 41);
    public static readonly City Konya = new City("Konya", 42);
    public static readonly City Kütahya = new City("Kütahya", 43);
    public static readonly City Malatya = new City("Malatya", 44);
    public static readonly City Manisa = new City("Manisa", 45);
    public static readonly City Kahramanmaraþ = new City("Kahramanmaraþ", 46);
    public static readonly City Mardin = new City("Mardin", 47);
    public static readonly City Muðla = new City("Muðla", 48);
    public static readonly City Muþ = new City("Muþ", 49);
    public static readonly City Nevþehir = new City("Nevþehir", 50);
    public static readonly City Niðde = new City("Niðde", 51);
    public static readonly City Ordu = new City("Ordu", 52);
    public static readonly City Rize = new City("Rize", 53);
    public static readonly City Sakarya = new City("Sakarya", 54);
    public static readonly City Samsun = new City("Samsun", 55);
    public static readonly City Siirt = new City("Siirt", 56);
    public static readonly City Sinop = new City("Sinop", 57);
    public static readonly City Sivas = new City("Sivas", 58);
    public static readonly City Tekirdað = new City("Tekirdað", 59);
    public static readonly City Tokat = new City("Tokat", 60);
    public static readonly City Trabzon = new City("Trabzon", 61);
    public static readonly City Tunceli = new City("Tunceli", 62);
    public static readonly City Þanlýurfa = new City("Þanlýurfa", 63);
    public static readonly City Uþak = new City("Uþak", 64);
    public static readonly City Van = new City("Van", 65);
    public static readonly City Yozgat = new City("Yozgat", 66);
    public static readonly City Zonguldak = new City("Zonguldak", 67);
    public static readonly City Aksaray = new City("Aksaray", 68);
    public static readonly City Bayburt = new City("Bayburt", 69);
    public static readonly City Karaman = new City("Karaman", 70);
    public static readonly City Kýrýkkale = new City("Kýrýkkale", 71);
    public static readonly City Batman = new City("Batman", 72);
    public static readonly City Þýrnak = new City("Þýrnak", 73);
    public static readonly City Bartýn = new City("Bartýn", 74);
    public static readonly City Ardahan = new City("Ardahan", 75);
    public static readonly City Iðdýr = new City("Iðdýr", 76);
    public static readonly City Yalova = new City("Yalova", 77);
    public static readonly City Karabük = new City("Karabük", 78);
    public static readonly City Kilis = new City("Kilis", 79);
    public static readonly City Osmaniye = new City("Osmaniye", 80);
    public static readonly City Düzce = new City("Düzce", 81);

    private City(string name, int value) : base(name, value)
    {
    }
}
