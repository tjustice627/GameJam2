using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public DashState dashState;
    public float dashTimer;
    public float maxDash;

    public Vector2 savedVelocity;

    PlayerController cont;

    void Awake()
    {
        cont = GetComponent<PlayerController>();
    }

    void Update()
    {
        switch (dashState)
        {
        case DashState.Ready:
            var isDashKeyDown = Input.GetKeyDown(KeyCode.LeftShift);
            if(isDashKeyDown)
            {
                savedVelocity = cont.speed;
                cont.speed = new Vector2(cont.speed.x*3.5f, cont.speed.y*3.5f);
                dashState = DashState.Dashing;
            }
            break;
        case DashState.Dashing:
            UIDashBar.instance.SetValue((maxDash - dashTimer)/maxDash);
            //cont.isInvincible = true;
            dashTimer += Time.deltaTime * 3;
            if(dashTimer >= maxDash)
            {
                dashTimer = maxDash;
                cont.speed = savedVelocity;
                dashState = DashState.Cooldown;
            }
            break;
        case DashState.Cooldown:
            UIDashBar.instance.SetValue((maxDash - dashTimer)/maxDash);
            //cont.isInvincible = false;
            dashTimer -= Time.deltaTime;
            if(dashTimer <= 0)
            {
                dashTimer = 0;
                dashState = DashState.Ready;
            }
            break;
        }
    }

}

public enum DashState
{
    Ready,
    Dashing,
    Cooldown
}