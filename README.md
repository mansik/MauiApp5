# What is the MVVM pattern, What benefits does MVVM have?(XAML, MVVM, Data Binding)

## About
(Example)What is the MVVM pattern, What benefits does MVVM have?(XAML, MVVM, Data Binding)

> Do you really need to learn MVVM to start developing apps with XAML frameworks like .NET MAUI, Uno, Avalonia, WPF, or WinUI 3? I get asked this question all the time and today, I break down what you need to know about MVVM, what it is, what it looks like to code without it, why you should learn and use it, and finally, how to take advantage of MVVM in your app! 

* [What is the MVVM pattern, What benefits does MVVM have?](https://youtu.be/AXpTeiWtbC8?si=US8mxtQrVurA544O)

* Development without MVVM & Data Binding(git branch: feature/without MVVM & data binding)
* Development with MVVM & Data Binding(git branch: feature/MVVM & data binding)

---
### Links
* [MVVM for Beginners](https://www.youtube.com/watch?v=Pso1MeX_HvI&t=0s)
* [MVVM Pattern](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)
* [.NET MAUI Data Binding](https://learn.microsoft.com/en-us/dotnet/maui/xaml/fundamentals/mvvm?view=net-maui-8.0) 
---

## Environment
* IDE: Visual Studio 2022
* Language: C#
* Applied Project Template: .MAUI APP
* NuGet
  * CommunityToolkit.Mvvm
* Third Party Libraries: x
* DataBase: x

## Reference
* [Grid](https://learn.microsoft.com/ko-kr/dotnet/maui/user-interface/layouts/grid?view=net-maui-8.0)
* [Control](https://learn.microsoft.com/ko-kr/dotnet/maui/user-interface/controls/?view=net-maui-8.0)

* [x:Array: XAML 태그 확장 사용](https://learn.microsoft.com/en-us/dotnet/maui/xaml/markup-extensions/consume?view=net-maui-8.0)
* [XAML markup extensions](https://learn.microsoft.com/ko-kr/dotnet/desktop/xaml-services/xarray-markup-extension)
* [8 Very Useful Markup Extensions in .NET MAUI](https://www.telerik.com/blogs/8-very-useful-markup-extensions-dotnet-maui)

* [MVVM](https://learn.microsoft.com/ko-kr/dotnet/architecture/maui/mvvm)
* [MVVM Toolkit](https://learn.microsoft.com/ko-kr/dotnet/architecture/maui/mvvm-community-toolkit-features)

* [data binding](https://learn.microsoft.com/ko-kr/dotnet/maui/fundamentals/data-binding/?view=net-maui-8.0)
* [Dependency injection](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/dependency-injection?view=net-maui-8.0&source=docs)
* [Combine ViewModel and View](https://loonacia.dev/2)
* [Task Constructors](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.-ctor?view=net-8.0#system-threading-tasks-task-ctor(system-action))

* [training dotnet maui](https://learn.microsoft.com/ko-kr/training/browse/?expanded=dotnet&products=dotnet-maui)


## Process

* Development without MVVM & Data Binding
	1. MainPage.xaml: add x:Name in controls
	    ```csharp
	    <Entry x:Name="EntryFirst" Placeholder="First name"/>
        <Entry x:Name="EntryLast" Placeholder="Last name"/>
            
        <Label x:Name="LabelFullName"/>
            
        <Button                
            Text="Click me"             
            HorizontalOptions="Center" />
	    ```
	2. MainPage.xaml.cs: add Method
        ```csharp
        void UpdateLabel()
        {
            LabelFullName.Text = $"{EntryFirst.Text} {EntryLast.Text}";
        }
        ```
    3. register an Event handler to an event      
        1. (from Code)MainPage.xaml.cs: Omit this and replace with xaml
        ```csharp
        public MainPage()
        {
            InitializeComponent();
            EntryFirst.TextChanged += EntryFirst_TextChanged;
        }
        ```
        2. (from xaml)MainPage.xaml: select 'new event handler' from "TextChanged=" -> auto Generate "EntryFirst_TextChanged" and "EntryLast_TextChanged" Event in MainPage.xaml.cs
        ```csharp
        <Entry x:Name="EntryFirst" Placeholder="First name"
                TextChanged="EntryFirst_TextChanged"/>
        <Entry x:Name="EntryLast" Placeholder="Last name"
                TextChanged="EntryLast_TextChanged"/>
        ```
        3. (from Code)MainPage.xaml.cs: add Code in TextChanged()
        ```csharp
        private void EntryFirst_TextChanged(object? sender, TextChangedEventArgs e)
         {
            UpdateLabel();
          }
          private void EntryLast_TextChanged(object sender, TextChangedEventArgs e)
          {
            UpdateLabel();
          }
        ```
        4. (from xaml)MainPage.xaml: add Clicked in Button
        ```csharp
        <Button                
                Text="Click me"             
                HorizontalOptions="Center"
                Clicked="Button_Clicked"/>
        ```
        5. (from Code)MainPage.xaml.cs: add Code in Button_Clicked()
        ```csharp
        private void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine(LabelFullName.Text);
        }
        ```
        6. (from xaml)MainPage.xaml: add x:Name in Button
        ```csharp
        <Button
                x:Name="ButtonTest"
                Text="Click me"             
                HorizontalOptions="Center"
                Clicked="Button_Clicked"/>
        ```
        7. (from Code)MainPage.xaml.cs: add "ButtonTest.IsEnabled ="
        ```csharp
        private void Button_Clicked(object sender, EventArgs e)
        {
            ButtonTest.IsEnabled = false;

            Console.WriteLine(LabelFullName.Text);

            ButtonTest.IsEnabled = true;
          }
        ```
* Development with MVVM & Data Binding
    1. add Nuget: CommunityToolkit.Mvvm
    2. add ViewModel folder and MainViewModel class
    3. MainViewModel.cs: add ObservableProperty and Property
      > auto generated Code at "Dependencies -> windows10.0.xxxx or net8.0-android -> Analyzers -> CommunityToolkit.Mvvm.SourceGenerators -> CommunityToolkit.Mvvm.SourceGenerators.ObservableProperty-> MauiApp5.ViewModel.MainViewModels.g.cs"
    ```csharp
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        string? firstName;

        [ObservableProperty]
        string? lastName;

        public string? FullName;

        [ObservableProperty]
        bool isBusy;
    }
    ```
    4. MainViewModel.cs: add [NotifyPropertyChangedFor(nameof(FullName))]: whenever first name or last name changes, raise a notification for full name.
    ```csharp
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        string? firstName;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FullName))]
        string? lastName;

        public string? FullName;

        [ObservableProperty]
        bool isBusy;
    }
    ```
	5. MainPage.xaml: add Binding in Controls
    ```csharp
    <Entry Placeholder="First name"
            Text="{Binding FirstName}"/>
    <Entry Placeholder="Last name"
            Text="{Binding LastName}"/>
            
    <Label Text="{Binding FullName}"/>
            
    <Button 
        IsEnabled="{Binding IsBusy}"
        Text="Click me"             
        HorizontalOptions="Center"/>
    ```
    6. MainPage.xaml: add xmlns:viewmodel and x:DataType
    ```csharp
    <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                    xmlns:viewmodel="clr-namespace:MauiApp5.ViewModel"
                    x:DataType="viewmodel:MainViewModel"
                    x:Class="MauiApp5.MainPage">
    ```
    7. MainViewModel.cs: add RelayCommand Tap() and Property
        > auto generated TapCommand at "Dependencies -> windows10.0.xxxx or net8.0-android -> Analyzers -> CommunityToolkit.Mvvm.SourceGenerators -> CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator-> MauiApp5.ViewModel.MainViewModels.g.cs"
    ```csharp
    public bool IsNotBusy => !IsBusy;

    [RelayCommand]
    void Tap()
    {
        IsBusy = true;

        Console.WriteLine(FullName);

        IsBusy = false;
    }
    ```
    8. MainViewModel.cs: add NotifyPropertyChangedFor in isBusy
    ```csharp
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;
    ```
    9. MainPage.xaml: add binding "Command and IsEnabled" in Button
    ```csharp
    <Button 
        IsEnabled="{Binding IsNotBusy}"
        Command="{Binding TapCommand}"
        Text="Click me"             
        HorizontalOptions="Center"/>
    ```
    10. MainPage.xaml.cs: add BindingContext
    ```csharp
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
    ```
			
