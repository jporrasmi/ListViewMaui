
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Mante1.ViewModels
{
    public partial class UsersViewModel: ObservableObject
    {
       
        public ObservableCollection<UserModel> Users { get; set; } = new ();



        [RelayCommand]
        public async Task GetUsers()
        {
            Users.Clear();
            Users.Add(new UserModel() { Name = "Nathasha", LastName = "Romanof" });
            Users.Add(new UserModel() { Name = "Steve", LastName = "Rogers" });
            Users.Add(new UserModel() { Name = "Bruce", LastName = "Banner" });

        }
    }
}
