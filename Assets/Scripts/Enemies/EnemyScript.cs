﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private int health = 1;
    
    [SerializeField]
    private GameObject collected = null;

    private SpriteRenderer render;
    private Color originalColor;
    private void Start()
    {
        render = transform.parent.GetComponent<SpriteRenderer>();
        originalColor = render.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            Flash();
            PlayerScript script = other.gameObject.GetComponent<PlayerScript>();
            if(script.states.isHiding){
                return;
            }


            var rb2d = other.gameObject.GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector2(0f, 0f);
            rb2d.AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse);
            health--;
            GameObject.Find("Managers/SoundManager").GetComponent<SoundManagerScript>().PlaySound("enemyHit");
            if(health <= 0){
                Destroy(this.transform.parent.gameObject);
                Instantiate(collected, transform.position, transform.rotation);
            }
        }
    }

    void Flash(){
        render.color = Color.red;
        Invoke("ResetColor", 0.2f);
    }

    void ResetColor(){
        render.color = originalColor;
    }
}
