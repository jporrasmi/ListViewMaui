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
    [QueryProperty("SecondLastName", "SecondLastName")]
    [QueryProperty("CodUser", "CodUser")]
    [QueryProperty("Id", "Id")]
    public partial class UserDetailViewModel: ObservableValidator 
    {
 
        private readonly IUserService _userService;
        public UserDetailViewModel() { 
            _userService = App.Current.Services.GetService<IUserService>();
        }


        public ObservableCollection<string> Errors { get; set; } = new();

        [ObservableProperty]
        private int id;

        private string  name;
        [Required(ErrorMessage = "You must type a name")]
        [MaxLength(25)]
        public string  Name
        {
            get { return name; }
            set { SetProperty(ref name, value, true); }
        }


        private string lastName;
        [Required(ErrorMessage = "You must type a last name")]
        [MaxLength(25)]
        public string LastName
        {
            get { return lastName; }
            set { SetProperty(ref lastName, value, true); }
        }


        private string secondlastName;
        [Required(ErrorMessage = "You must type a second last name")]
        [MaxLength(25)]
        public string SecondLastName
        {
            get { return secondlastName; }
            set { SetProperty(ref secondlastName, value, true); }
        }


        [RelayCommand]
        public async Task SaveUser()
        {
            ValidateAllProperties();

            Errors.Clear();
            GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));
            GetErrors(nameof(LastName)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));
            GetErrors(nameof(SecondLastName)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));

            await _userService.UpdateUser(new UserModel() { Name = Name, LastName = LastName, SecondLastName = SecondLastName, CodUser = LastName + Name.Substring(0, 1), Id=Id });
          
            await Task.Delay(2000);
            await Shell.Current.Navigation.PopToRootAsync();
        }

        [RelayCommand]
        public async Task DeleteUser()
        {
            ValidateAllProperties();

           //Errors.Clear();
           // GetErrors(nameof(Name)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));
            //GetErrors(nameof(LastName)).ToList().ForEach(f => Errors.Add(f.ErrorMessage));

            await _userService.DeleteUser(Id);

            await Task.Delay(2000);
            await Shell.Current.Navigation.PopToRootAsync();
        }



    }
}
