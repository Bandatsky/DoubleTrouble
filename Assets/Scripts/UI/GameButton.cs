﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButton : MonoBehaviour
{
  public void RestartGame() {
    // Time.timeScale = 1;
    SceneManager.LoadScene(0);
  }
}
