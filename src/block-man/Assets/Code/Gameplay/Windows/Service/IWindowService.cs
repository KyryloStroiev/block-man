namespace Code.Gameplay.Windows.Service
{
    public interface IWindowService
    {
        void Open(WindowsId windowsId);
        void Close(WindowsId windowsId);
        bool OpenMenu { get; set; }
    }
}