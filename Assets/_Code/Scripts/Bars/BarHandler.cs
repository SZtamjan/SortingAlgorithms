using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

namespace _Code.Scripts.Bars
{
    [RequireComponent(typeof(BarSetup))]
    public class BarHandler : MonoBehaviour
    {
        public GameObject bar;
        public Transform leftEdge;
        public Transform rightEdge;
        public Transform barsPlace;
        
        private BarSetup _barSetup;

        private void Awake()
        {
            SetupVars();
        }

        private void SetupVars()
        {
            _barSetup = GetComponent<BarSetup>();
        }
        
        [Button]
        public void GenerateBars()
        {
            int barCount = _barSetup.barCount;
            int fixedBarCount = barCount - 1;
            Vector3 left = leftEdge.position;
            Vector3 right = rightEdge.position;

            GameObject[] barTable = new GameObject[barCount];
            List<int> usedPos = new List<int>();
            List<int> usedHeight = new List<int>();

            for (int i = 0; i < _barSetup.barCount; i++)
            {
                barTable[i] = Instantiate(bar,FindNewPos(barCount,fixedBarCount,left,right, usedPos),Quaternion.identity,barsPlace);
                //Randomized height 80-800
                RectTransform rTransform = barTable[i].GetComponent<RectTransform>();
                rTransform.sizeDelta = FindNewHeight(rTransform.sizeDelta, barCount, fixedBarCount, usedHeight);
            }
        }

        private Vector2 FindNewHeight(Vector2 currSize, int barCount, int fixedBarCount, List<int> usedHeight)
        {
            int fixedHeightBarCount = barCount + 1;
            int randomStep;
            do
            {
                randomStep = Random.Range(1, fixedHeightBarCount);
            } while (usedHeight.Contains(randomStep));
            usedHeight.Add(randomStep);
            
            //720 because bar height is between 80 and 800 
            float newHeight = 720 / (fixedBarCount / (float)randomStep);
            
            return new Vector2(currSize.x,newHeight);
        }

        private Vector3 FindNewPos(int barCount, int fixedBarCount, Vector3 left, Vector3 right, List<int> usedSteps)
        {
            int randomStep;
            
            do
            {
                randomStep = Random.Range(0, barCount);
            } while (usedSteps.Contains(randomStep));
            
            usedSteps.Add(randomStep);
            
            float newX = ((Mathf.Abs(left.x) + right.x) / (fixedBarCount / (float)randomStep)) -
                         Mathf.Abs(left.x);

            return new Vector3(newX, left.y, left.z);
        }
    }
}