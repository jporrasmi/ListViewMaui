namespace Mante1.Views;

public partial class UserList : ContentPage
{
	public UserList()
	{
		BindingContext = App.Current.Services.GetService<UsersViewModel>();
		InitializeComponent();
	}

    private void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {

    }
}