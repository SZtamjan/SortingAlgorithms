using _Scripts.Interfaces;
using UnityEngine;

namespace LayZ.Debuggers.Logger.Demo
{
    public class DemoUnit : MonoBehaviour, ILayzLogger
    {
        public LayZLogger layZLogger;
        private void Start()
        {
            Log("I am a unit and I called by a reference!");
        
            //Uncomment and play with exceptions!
            //MasterLayZLogger.Instance?.UseInstance("ThisOneDoesntExist")?.Log("Script handles multiple exceptions!");
            //MasterLayZLogger.Instance?.UseInstance("PlayerLogger")?.Log("You didn't see this one in console, because it's turned off in the inspector!");
        }

        #region Loggers

        public void Log(string message)
        {
            if (layZLogger) layZLogger.Log(message);
        }

        public void LogWarning(string message)
        {
            if (layZLogger) layZLogger.LogWarning(message);
        }

        public void LogError(string message)
        {
            if (layZLogger) layZLogger.LogError(message);
        }

        #endregion
    }
}