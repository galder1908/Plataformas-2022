using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    bool invencible;


    public int score = 0;

    public enum DeathMode { Teleport, ReloadScene, Destroy}
    public DeathMode death_mode;
    public Transform respawn;
    // Start is called before the first frame update
    void Start()
    {
        lifes_current = lifes_max;  
    }

    public void Damage(int damage = 1, bool ignoreInvencible = false)
    {
        if(!invencible || ignoreInvencible)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_Corutine());
            if(lifes_current <= 0)
            {
                Death();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      
        
        if(other.tag == "Coin")
        {
            score++;
            Destroy(other.gameObject);
        }
    }
    public void Death()
    {
        switch (death_mode)
        {
            case DeathMode.Teleport:
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.ReloadScene:

                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
    IEnumerator Invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        yield return null;
        invencible = false;
    }
}
