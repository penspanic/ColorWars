using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SeletableButtons : MonoBehaviour
{
    public Button[] buttons;
    public Sprite[] normalSprites;
    public Sprite[] selectedSprites;

    public AudioSource audioSource;
    public AudioClip changeSound;
    public AudioClip enterSound;

    Action[] actions;
    

    int currIndex = 0;

    Main main;

    void Awake()
    {
        main = GameObject.FindObjectOfType<Main>();
        actions = new Action[buttons.Length];
    }

    int prevIndex = 0;
    bool canMove = true;
    void Update()
    {
        prevIndex = currIndex;
        if(Input.GetAxis("Vertical") >0 && canMove)
        {
            if (currIndex == 0)
                return;
            canMove = false;
            currIndex--;
            audioSource.PlayOneShot(changeSound);
            
        }

        if(Input.GetAxis("Vertical") < 0 && canMove)
        {
            if (currIndex == 2)
                return;
            canMove = false;
            currIndex++;
            audioSource.PlayOneShot(changeSound);
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            actions[currIndex]();
            audioSource.PlayOneShot(enterSound);
        }

        buttons[prevIndex].image.sprite = normalSprites[prevIndex];
        buttons[currIndex].image.sprite = selectedSprites[currIndex];

        //buttons[currIndex].image.SetNativeSize();
        //buttons[prevIndex].image.SetNativeSize();

        if (Input.GetAxis("Vertical") == 0)
            canMove = true;
    }

    public void AddEvent(int index, System.Action action)
    {
        actions[index] = action;
    }
}
