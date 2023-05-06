using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Utility
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            transform.SetParent(null);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
