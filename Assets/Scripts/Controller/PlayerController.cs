﻿using UnityEngine;
using System.Collections;

public class PlayerController : QCharacterController {

    private GameController m_gameController;

    protected override void Start()
    {
        base.Start();
        m_gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            this.GetComponent<Rigidbody>().isKinematic = true;
            EnemyController enemyController = other.gameObject.GetComponent<EnemyController>();
            m_gameController.M_GameLogic.M_EnemyLogics.Remove((EnemyLogic)enemyController.M_CharacterLogic);
            Destroy(other.gameObject);
            ((PlayerLogic)m_characterLogic).M_IsDead = true;
        }
    }

}
