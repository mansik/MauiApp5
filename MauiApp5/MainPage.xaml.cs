using MauiApp5.ViewModel;

namespace MauiApp5;

//public partial class MainPage : ContentPage
//{
//    public MainPage()
//    {
//        InitializeComponent();
//    }

//    private void EntryFirst_TextChanged(object? sender, TextChangedEventArgs e)
//    {
//        UpdateLabel();
//    }
//    private void EntryLast_TextChanged(object sender, TextChangedEventArgs e)
//    {
//        UpdateLabel();
//    }

//    void UpdateLabel()
//    {
//        LabelFullName.Text = $"{EntryFirst.Text} {EntryLast.Text}";
//    }

//    private void Button_Clicked(object sender, EventArgs e)
//    {
//        ButtonTest.IsEnabled = false;

//        Console.WriteLine(LabelFullName.Text);

//        ButtonTest.IsEnabled = true;
//    }
//}

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}