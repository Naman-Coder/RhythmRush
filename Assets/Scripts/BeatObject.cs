using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode keyToPress;
    public static BeatObject instance;
    
    
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
            if(canBePressed){
                Destroy(gameObject);
                BeatHit();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Activator")
            canBePressed = true;
            
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(gameObject.activeSelf){
            if(other.tag == "Activator"){
                canBePressed = false;
            }
        }
    }
    public void BeatHit() {
        GameManager.instance.currentScore += 10;
        GameManager.instance.click.Play();
    }
    public void BeatMiss() {
        Debug.Log("Miss");
    }
}
