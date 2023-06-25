namespace Mante1.Views;

public partial class UserDetail : ContentPage
{
	public UserDetail()
	{
        BindingContext = App.Current.Services.GetService<UserDetailViewModel>();
        InitializeComponent();
	}
}