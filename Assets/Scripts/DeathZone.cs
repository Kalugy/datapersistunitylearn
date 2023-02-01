using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public MainManager Manager;
    public UIManager UiManager;

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Manager.GameOver();
        UiManager.UpdateScoreText();
    }
}
