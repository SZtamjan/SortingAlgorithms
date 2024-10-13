using _Scripts.Interfaces;
using UnityEngine;

namespace LayZ.Debuggers.Logger.Demo
{
    public class DemoBuilding : MonoBehaviour, ILayzLogger
    {
        private void Start()
        {
            //As an argument to UseInstance() you need to provide string with the name of the GameObject from the Hierarchy that contains a logger script you want to use
            Log("I am a building and I needed to call by master instance, because I don't have a direct reference");
        
            //Uncomment and play with exceptions!
            //MasterLayZLogger.Instance?.UseInstance("ThisOneDoesntExist")?.Log("Script handles multiple exceptions!");
            //MasterLayZLogger.Instance?.UseInstance("PlayerLogger")?.Log("You didn't see this one in console, because it's turned off in the inspector!");
        }
        
        #region Loggers

        public void Log(string message)
        {
            MasterLayZLogger.Instance?.UseInstance("BuildingsLogger")?.Log(message);
        }

        public void LogWarning(string message)
        {
            MasterLayZLogger.Instance?.UseInstance("BuildingsLogger")?.LogWarning(message);
        }

        public void LogError(string message)
        {
            MasterLayZLogger.Instance?.UseInstance("BuildingsLogger")?.LogError(message);
        }

        #endregion
    }
}