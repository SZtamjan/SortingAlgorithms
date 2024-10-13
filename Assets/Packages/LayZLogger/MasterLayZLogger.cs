using System.Collections.Generic;
using _Scripts.Interfaces;
using _Scripts.Singleton;
using UnityEngine;

namespace LayZ.Debuggers.Logger
{
    public class MasterLayZLogger : Singleton<MasterLayZLogger>, ILayzLogger
    {
        private Dictionary<string, LayZLogger> Instances = new Dictionary<string, LayZLogger>();
        public bool loggerIsOn = true;

        private void Awake()
        {
            SetupInstances();
        }

        //Use example:
        //MasterLayZLogger.Instance?.UseInstance("UnitsLogger")?.Log("I am a unit");
        public LayZLogger UseInstance(string instanceName)
        {
            if (Instances.ContainsKey(instanceName))
            {
                return Instances[instanceName];
            }

            string instanceNames = "";
            foreach (var instance in Instances)
            {
                instanceNames = $"{instanceNames} {instance.Key}, ";
            }
            
            LogError($"Lack of {instanceName} instance. <color=green>Available Instances: {instanceNames}</color>");

            return null;
        }

        private void SetupInstances()
        {
            foreach (Transform child in transform)
            {
                if (child.TryGetComponent(out LayZLogger layZLogger))
                {
                    Instances.Add(layZLogger.name,layZLogger);
                }
            }
        }
        
        #region Loggers

        public void Log(string message)
        {
            if(loggerIsOn) Debug.Log($"MasterDbgr: {message}");
        }

        public void LogWarning(string message)
        {
            if(loggerIsOn) Debug.LogWarning($"MasterDbgr: <color=yellow>{message}</color>");
        }

        public void LogError(string message)
        {
            if(loggerIsOn) Debug.LogError($"MasterDbgr: <color=red>{message}</color>");
        }

        #endregion
    }
}