using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEventSystem
{
    public class MaterialsManager : MonoBehaviour
    {
        private int logCount = 0;
        private int ropeCount = 0;

        public void LogCountIncrease()
        {
            logCount++;
            //Debug.Log(logCount);

            if (logCount == 5)
            {
                Debug.Log("you have 5 logs");
            }
        }

        public void LogCountDecrease()
        {
            logCount--;
            //Debug.Log(logCount);
        }

        public void RopeCountIncrease()
        {
            ropeCount++;
            //Debug.Log(ropeCount);

            if (ropeCount == 2)
            {
                Debug.Log("you have 2 ropes");
            }
        }

        public void RopeCountDecrease()
        {
            ropeCount--;
            //Debug.Log(ropeCount);
        }
    }
}