﻿using Mante1.Views;

namespace Mante1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(UserList), typeof(UserList));
        Routing.RegisterRoute(nameof(User), typeof(User));
        Routing.RegisterRoute(nameof(UserDetail), typeof(UserDetail));
    }
}
