﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Regeneration : MonoBehaviour
{
    // [SerializeField][Tooltip("эффект лута")] private Animator animEffectLoot;
    [SerializeField][Tooltip("время ожидания эффекта")] private float waitEffect =1;
    [Tooltip("Кол-во восстановления здоровья ")] public int health=30;
    
    private AnimEffect animEffectLoot;
    private Animator animator;
    private Rigidbody rb;
    
    
    // Achive_Patrons
    //  Achive_Shest
    // Acive_Smt
    //  Achive_Heal  зеленый
    
    
    private void Start() {
        rb = GetComponent<Rigidbody>();
        animEffectLoot = FindObjectOfType<AnimEffect>();
        animator = animEffectLoot.GetComponent<Animator>();
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SecondPlayer") {
            StartCoroutine(EffectWait());
            
            rb.isKinematic = true;
            gameObject.transform.DOMove(SecondPlayer.Instance.transform.position, SecondPlayer.Instance.takeItemTime);
            SecondPlayer.Instance.HealthUpdate(health);
            QuestManager.Instance.CheckQuests(QuestManager.QuestStates.PUSHTOMIKE);
        }
    }

    IEnumerator EffectWait() {
        yield return new WaitForSeconds(waitEffect);
        animator.SetTrigger("Achive_Heal");
        Destroy(gameObject);
    }
}
