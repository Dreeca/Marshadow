﻿    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    private Animator anim_monster;
    private Rigidbody2D body;
    private bool isrotate;
    private float PV = 15f;

    private void Start()
    {
        anim_monster = this.GetComponent<Animator>();
        body = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 positionV2 = new Vector2(this.transform.position.x, this.transform.position.y);
        moveRight(positionV2);
    }

    private void moveRight(Vector2 posV2)
    {
        body.MovePosition(posV2 - Vector2.left * 0.05f);
        anim_monster.SetInteger("direction", 2);
        isrotate = true;
        this.GetComponent<SpriteRenderer>().flipX = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Touche");

        Destroy(collision.gameObject);
        PV = PV - collision.gameObject.GetComponent<Tir>().GetDamage();
        if (PV == 0)
            Destroy(gameObject);
    }


}
