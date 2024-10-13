using _Scripts.Interfaces;
using UnityEngine;

namespace LayZ.Debuggers.Logger
{
    public class LayZLogger : MonoBehaviour, ILayzLogger
    {
        [SerializeField] private bool showMessage = true;
        [SerializeField] private string prefix;
        private MasterLayZLogger _masterLayZLogger;
        
        private void Awake()
        {
            SetupVars();
        }

        private void SetupVars()
        {
            if (!transform.parent.TryGetComponent(out MasterLayZLogger masterDebugLogger))
            {
                Debug.LogError($"Lack of {nameof(MasterLayZLogger)} on {transform.parent}");
                return;
            }
            _masterLayZLogger = masterDebugLogger;
            
            if (string.IsNullOrEmpty(prefix)) prefix = gameObject.name;
        }
        
        public void Log(string message)
        {
            if (!showMessage || !_masterLayZLogger || !gameObject.activeSelf || !_masterLayZLogger.loggerIsOn) return;
            Debug.Log($"{prefix}: {message}");
        }

        public void LogWarning(string message)
        {
            if (!showMessage || !_masterLayZLogger || !gameObject.activeSelf || !_masterLayZLogger.loggerIsOn) return;
            Debug.LogWarning($"{prefix}: <color=yellow>{message}</color>");
        }
        
        public void LogError(string message)
        {
            if (!showMessage || !_masterLayZLogger || !gameObject.activeSelf || !_masterLayZLogger.loggerIsOn) return;
            Debug.LogError($"{prefix}: <color=red>{message}</color>");
        }
    }
}