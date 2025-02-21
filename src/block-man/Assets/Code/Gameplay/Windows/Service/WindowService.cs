using System.Collections.Generic;
using Code.Gameplay.Windows.Factory;
using UnityEngine;

namespace Code.Gameplay.Windows.Service
{
    public class WindowService : IWindowService
    {
        public bool OpenMenu { get; set; }
        
        private readonly IWindowFactory _windowsFactory;

        private readonly List<BaseWindow> _openedWindows = new();

        public WindowService(IWindowFactory windowsFactory) => 
            _windowsFactory = windowsFactory;
        
        public void Open(WindowsId windowsId)
        {
            _openedWindows.Add(_windowsFactory.CreateWindows(windowsId));
            Debug.Log(_openedWindows.Count);
        }

        public void Close(WindowsId windowsId)
        {
            BaseWindow window = _openedWindows.Find(w => w.Id == windowsId);
            
            _openedWindows.Remove(window);
            
            if (window.gameObject != null) 
            {
                GameObject.Destroy(window.gameObject);
            }
        }
    }
}