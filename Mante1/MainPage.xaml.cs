using Mante1.ViewModels;

namespace Mante1;

public partial class MainPage : ContentPage
{
    //private readonly IFunctions _functions;
    //int count = 0;

	public MainPage()
	{
		//_functions = App.Current.Services.GetRequiredService<IFunctions>();
		BindingContext = App.Current.Services.GetRequiredService<TestViewModel>();
		InitializeComponent();
	}

}

