using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIMenu
{
    public class SceneLoader : MonoBehaviour
    {
        public void StartBtn()
        {
            SceneManager.LoadScene("CastawayVirtualReality");
        }
    }
}

