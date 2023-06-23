﻿using Mante1.Services;
using Mante1.ViewModels;

namespace Mante1;

public partial class App : Application
{
	//Propiedad statica para manejar las depdencias en un nuevo colector.
	public new static App Current => (App)Application.Current;

	public IServiceProvider Services { get; }

	public App()
	{
		var services = new ServiceCollection();
		Services = ConfigureServices(services);
		InitializeComponent();

		MainPage = new AppShell();
	}

	//Inyector de dependencias propio
	private static IServiceProvider ConfigureServices(ServiceCollection services)
	{
		//Services
		services.AddSingleton<IFunctions, Functions>();

		//ViewModels
		services.AddTransient<TestViewModel>();

		return services.BuildServiceProvider();
    }

}