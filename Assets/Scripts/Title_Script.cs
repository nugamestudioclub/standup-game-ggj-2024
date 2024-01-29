using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title_Script : MonoBehaviour
{
    [SerializeField]
    private AudioSource chatter;
    [SerializeField]
    private AudioSource music;
    [SerializeField]
    private GameObject Transition;
    [SerializeField]
    private GameObject startButton;
    [SerializeField]
    private GameObject InstructionsButton;
    [SerializeField]
    private GameObject Instructions;
    [SerializeField]
    private Animator animator;
    private Image crossFade;
    private bool nextScene = false;
    private float fadeInSequence = 5f;
    private float next = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //set background
        crossFade = Transition.GetComponent<Image>();
        crossFade.color = new Color(0f, 0f, 0f);
        startButton.SetActive(false);
        InstructionsButton.SetActive(false);
        chatter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextScene)
        {
            startButton.SetActive(false);
            InstructionsButton.SetActive(false);
            fadeInSequence = -1f;
            if (animator.GetBool("Transition") && fadeInSequence == -1f)
            {
                animator.SetBool("Transition", false);
            }
            //Debug.Log(animator.GetBool("Transition"));
            if (crossFade.color == new Color(0f, 0f, 0f))
            {
                //Debug.Log("New Cross: " + crossFade.color);
                //Debug.Log("Next: " +  next);
                if (next >= 1f)
                {
                    Debug.Log("Next");
                    SceneManager.LoadScene("Seb_Finalization");
                }
                else
                {
                    next += Time.deltaTime;
                }
            }
        }
        //Debug.Log("Fade in: " + fadeInSequence);
        //Debug.Log("Cross fade: " + crossFade.color);
        if (fadeInSequence > 0f)
        {
            fadeInSequence -= Time.deltaTime;
            //Debug.Log("Fade in: " + fadeInSequence);
        }
        else if (Mathf.Round(fadeInSequence) == 0)
        {
            //switch the two
            //play animation
            if (!animator.GetBool("Transition"))
            {
                animator.SetBool("Transition", true);
            }
            if (crossFade.color == new Color(1f, 1f, 1f) && !Instructions.activeInHierarchy)
            {
                if (chatter.isPlaying)
                {
                    chatter.Stop();
                    music.Play();
                }
                startButton.SetActive(true);
                if (next <= 0)
                {
                    InstructionsButton.SetActive(true);
                    next = 0f;
                }
                else
                {
                    next -= Time.deltaTime;
                }
            }
        }
    }

    //on click for start button
    public void start_game(){
        nextScene = true;
    }
}
