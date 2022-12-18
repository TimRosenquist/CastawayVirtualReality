using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIMenu
{
    public class SceneLoader : MonoBehaviour
    {
        // This function is called when you press on the Start button in the main Menu scene to switch over to the Castaway Virtual Reality Scene
        public void StartBtn()
        {
            SceneManager.LoadScene("CastawayVirtualReality");
        }
    }
}

