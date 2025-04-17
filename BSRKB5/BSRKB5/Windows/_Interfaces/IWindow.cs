using BSRKB5.Commands;

namespace BSRKB5.Windows;
public interface IWindow
{
    CommandType WindowCommandsType { get; }

    void ShowWindow();
    void PrintContent();
}
