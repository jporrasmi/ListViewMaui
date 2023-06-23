namespace Mante1.Views;

public partial class UserList : ContentPage
{
	public UserList()
	{
		BindingContext = App.Current.Services.GetService<UserViewModel>();
		InitializeComponent();
	}
}