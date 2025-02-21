namespace Code.Gameplay.Cursors
{
    public interface ICursorService
    {
        bool CursorActive { get; set; }
        void ShowCursor();
        void HideCursor();
    }
}