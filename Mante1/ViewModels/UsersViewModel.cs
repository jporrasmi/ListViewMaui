
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mante1.Views;
using System.Collections.ObjectModel;

namespace Mante1.ViewModels
{
    public partial class UsersViewModel: ObservableObject
    {
        private readonly IUserService _userService;
        public UsersViewModel()
        {
            _userService = App.Current.Services.GetService<IUserService>();
        }

        //Igual se declara en el model de Products
        [ObservableProperty]
        UserModel selectedUser;

        public ObservableCollection<UserModel> Users { get; set; } = new ();


        //Para utilizar en caso de que no haya API.
        //[RelayCommand]
        //public async Task GetUsers()
        //{
        //    Users.Clear();
        //    Users.Add(new UserModel() { Name = "Nathasha", LastName = "Romanof" });
        //    Users.Add(new UserModel() { Name = "Steve", LastName = "Rogers" });
        //    Users.Add(new UserModel() { Name = "Bruce", LastName = "Banner" });

        //}

        [RelayCommand]
        public async Task GetUsers()
        {
            // IsLoading = true;
            Users.Clear();
            var users = await _userService.GetAllUsers();
            if (users != null) { 
                foreach (var item in users) Users.Add(item);
            }
            //IsLoading = false;
            //IsRefreshing = false;

        }


        [RelayCommand]
        public void AddNew()
        {
            Shell.Current.Navigation.PushAsync(new Views.User(), false);
        }


        [RelayCommand]
        async Task GoToDetails()
        {
            if (selectedUser == null)
                return;

            //var data = new Dictionary<string, object>
            //{
            //    {"SelectedUser", selectedUser }
            //};


            await Shell.Current.GoToAsync($"/User?Name={selectedUser.Name}&LastName={selectedUser.LastName}&CodUser={selectedUser.CodUser}", false);
        }

    }
}
