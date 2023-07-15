using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointCounterScript : MonoBehaviour
{
    public int points;
    public TMP_Text tmpText;

    private void Update()
    {
        if (points >= 50000)
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}
