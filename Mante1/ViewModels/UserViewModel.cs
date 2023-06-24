using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mante1.ViewModels
{
    public partial class UserViewModel: ObservableValidator 
    {


        public ObservableCollection<string> Errors { get; set; } = new();

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

        }


    }
}
