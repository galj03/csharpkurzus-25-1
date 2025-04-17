using BSRKB5.Windows;

var menuOptions = new List<string> { "Play", "See leaderboard", "Exit" };   //TODO: get commands using reflection in window

var menu = new MenuWindow(menuOptions);
menu.ShowWindow();