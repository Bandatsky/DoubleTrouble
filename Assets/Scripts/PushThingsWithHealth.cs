﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushThingsWithHealth : MonoBehaviour
{
    [Tooltip("Кол-во здоровья предмета")] [SerializeField] float health;
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damageFoot)
    {
        health -= damageFoot;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    



}
