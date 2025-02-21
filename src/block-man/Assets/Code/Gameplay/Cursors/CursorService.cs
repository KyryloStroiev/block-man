using UnityEngine;

namespace Code.Gameplay.Cursors
{
    public class CursorService : ICursorService
    {
        public bool CursorActive { get; set; }

        public void ShowCursor()
        {
            CursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        public void HideCursor()
        {
            CursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        
    }
}