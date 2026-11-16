using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Borealis.SplashScreen.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Borealis.SplashScreen.Views;

public partial class MainWindow : Window
{
    private const double ScreenSize = 0.5;
    
    public MainWindow()
    {
        InitializeComponent();
        ResizeWindow();
    }

    private void ResizeWindow()
    {
        var screen = Screens.Primary;
        if (screen is null)
            return;

        var area = screen.WorkingArea;
        var scaling = screen.Scaling;

        Width = area.Width / scaling * ScreenSize;
        Height = area.Height / scaling * ScreenSize;
    }
    
    private void Window_MouseLeftButtonDown(object sender, PointerPressedEventArgs e)
    {
        if(sender is Window window)
            window.BeginMoveDrag(e);
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}