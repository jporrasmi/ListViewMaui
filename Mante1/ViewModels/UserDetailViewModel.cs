using CommunityToolkit.Mvvm.Input;
using Mante1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mante1.ViewModels
{

    [QueryProperty("Name", "Name")]
    [QueryProperty("LastName", "LastName")]
    [QueryProperty("CodUser", "CodUser")]
    public partial class UserDetailViewModel: ObservableValidator 
    {
 
        private readonly IUserService _userService;
        public UserDetailViewModel() { 
            _userService = App.Current.Services.GetService<IUserService>();
        }


        public ObservableCollection<string> Errors { get; set; } = new();

        [ObservableProperty]
        private string codUser;
   
        private string  name;
        [Required(ErrorMessage = "Debe digitar el nombre del usuario")]
        [MaxLength(25)]
        public string  Name
        {
            get { return name; }
            set { SetProperty(ref name, value, true); }
        }


        private string lastName;
        [Required(ErrorMessage = "Debe digitar el nombre del usuario")]
        [MaxLength(25)]
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value, true); }
        }

        [RelayCommand]
        public async Task SaveUser()
        {
            ValidateAllProperties();

            Errors.Clear();
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));
            GetErrors(nameof(LastName)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));

            await _userService.UpdateUser(new UserModel() { Name = Name, LastName = LastName, CodUser = CodUser});
          
            await Task.Delay(2000);
            await Shell.Current.Navigation.PopToRootAsync();
        }

        [RelayCommand]
        public async Task DeleteUser()
        {
            ValidateAllProperties();

            Errors.Clear();
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));
            GetErrors(nameof(LastName)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));

            await _userService.DeleteUser(CodUser);

            await Task.Delay(2000);
            await Shell.Current.Navigation.PopToRootAsync();
        }



    }
}
