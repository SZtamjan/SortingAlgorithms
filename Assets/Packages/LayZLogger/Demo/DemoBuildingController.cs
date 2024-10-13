using UnityEngine;

namespace LayZ.Debuggers.Logger.Demo
{
    public class DemoBuildingController : MonoBehaviour
    {
        public GameObject building;
        private void Start()
        {
            Instantiate(building, transform);
        }
    }
}