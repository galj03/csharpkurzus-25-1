//TODO: apply SOLID, this is just a sketch for the main menu
using BSRKB5.Windows;

var menuOptions = new List<string> { "Play", "See leaderboard", "Exit" };   //TODO: get from a resource?

var menu = new MenuWindow(menuOptions);
menu.ShowWindow();