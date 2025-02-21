using System;
using UnityEngine;

namespace Code.Gameplay.Windows
{
    public class BaseWindow : MonoBehaviour
    {
        public WindowsId Id { get; protected set; }

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
        }

        private void OnDestroy() => 
            Cleanup();

        protected virtual void OnAwake()
        {
            
        }

        protected virtual void Initialize()
        {
            
        }

        protected virtual void Cleanup()
        {
            
        }
    }
}