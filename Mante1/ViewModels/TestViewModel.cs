using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mante1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mante1.ViewModels
{
    public partial class TestViewModel: ObservableObject
    {
        private readonly IFunctions _functions;

        [ObservableProperty] 
        int count;
        
        [ObservableProperty] //Decorador para que sea visible desde la vista
        string text;
        
        
        public TestViewModel() 
            => _functions = App.Current.Services.GetRequiredService<IFunctions>();
        

        [RelayCommand]
        public void CambiarTexto() {
            Count++;
            Text = _functions.CambiarTexto("Hola gente", Count);
        }

    }
}
