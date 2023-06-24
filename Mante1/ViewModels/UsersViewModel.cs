
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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


        public ObservableCollection<UserModel> Users { get; set; } = new ();



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
        

    }
}
