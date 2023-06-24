namespace Mante1.Views;

public partial class User : ContentPage
{
	public User()
	{
		BindingContext = App.Current.Services.GetService<UserViewModel>();
        InitializeComponent();
	}
}