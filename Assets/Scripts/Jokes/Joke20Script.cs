using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Joke20Script : MonoBehaviour, JokeInterface
{
    public string ButtonText { get; private set; } //required

    public int OccurrenceWeight { get; private set; } //required

    public UnityEvent onJokeStarted { get; private set; } //required

    public UnityEvent onJokeCompleted { get; private set; } //required

    //You can add any number of fields to this as needed.

    public Joke20Script()
    {
        ButtonText = "The end!"; //put the text for the prompt button here
        OccurrenceWeight = 0; //customize the rarity of the joke occurred (less means rarer)

        onJokeStarted = new UnityEvent();
        onJokeCompleted = new UnityEvent();
    }

    //function that will run when the button for the joke is clicked
    public void run()
    {
        onJokeStarted.Invoke(); //required - this method should be the first method in run()
        StartCoroutine(Joke20Sequence());
    }

    IEnumerator Joke20Sequence()
    {
        Debug.Log("tell the joke");

        yield return StartCoroutine(TellJoke20());

        Debug.Log("Joke 20 is completed");
    }

    IEnumerator TellJoke20()
    {
        float timeToAnimate = 1f;

        float elapsedTime = 0f;

        while (elapsedTime < timeToAnimate)
        {

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Debug.Log("Animation completed");

        onJokeCompleted.Invoke(); //required - this method should be called at the of the joke, after
    }
}
