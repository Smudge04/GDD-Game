using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    void Start() //NS
    {
        DontDestroyOnLoad(gameObject);
    }
}
