using UnityEngine;
using System.Collections;
using System;

public class Enemy : MovingObject
{
    public int playerDamage;

    private Animator animator;
    private Transform target;
    private bool skipMove = true;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    protected override void AttemptMove<T>(int xDir, int yDir)
    {
        skipMove = !skipMove;
        if (skipMove) return;
        base.AttemptMove<T>(xDir, yDir);
    }

    public void MoveEnemy()
    {
        int xDir = 0;
        int yDir = 0;
        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon)
        {
            yDir = Math.Sign(target.position.y - transform.position.y);
        }
        else
        {
            xDir = Math.Sign(target.position.x - transform.position.x);
        }
        AttemptMove<Player>(xDir, yDir);
    }

    protected override void OnCantMove<T>(T component)
    {
        Player hitPlayer = component as Player;
        hitPlayer.LoseFood(playerDamage);
    }
}
