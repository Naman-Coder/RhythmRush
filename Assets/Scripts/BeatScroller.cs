using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public static BeatScroller instance;
    // Game objects and variables
    public GameObject[] beats;
    public Transform beatParent;
    public float beatSpawnInterval = 1f;
    public float beatSpeed = 10f;
    public float yPos = 4f;

    // Audio and timing variables
    public AudioSource audioSource;
    public float songStartTime;
    public float songPosition;
    public float crotchet;
    public float beatTempo;

    // Game state variables
    private int currentBeatIndex = 0;

    void Start()
    {
        instance = this;
        // Set the beat tempo and calculate the crotchet length
        beatTempo = 90f;
        crotchet = 60f / beatTempo;

        // Start the song and wait for the user to start the game
        audioSource.Play();
        songStartTime = (float)AudioSettings.dspTime;
    }

    void Update()
    {
        // Update the song position
        songPosition = (float)AudioSettings.dspTime - songStartTime;

        // Spawn the next beat if it's time
        if (songPosition >= crotchet * currentBeatIndex - beatSpawnInterval)
        {
            SpawnBeat();
            currentBeatIndex++;
        }

        // Move the beats downwards
        for (int i = 0; i < beatParent.childCount; i++)
        {
            Transform beat = beatParent.GetChild(i);
            beat.position -= new Vector3(0f, beatSpeed * Time.deltaTime, 0f);
        }
}

    void SpawnBeat()
    {
        // Choose a random beat prefab and position          
        int beatIndex = Random.Range(0, beats.Length);
        Vector3 beatPosition = new Vector3(0, 0, 0);
        if(beatIndex == 0)
            beatPosition = new Vector3(-1, yPos, 0f);
        else if(beatIndex == 1) 
            beatPosition = new Vector3(0, yPos, 0f);
        else if(beatIndex == 2)
            beatPosition = new Vector3(1, yPos, 0f);
        else if(beatIndex == 3)
            beatPosition = new Vector3(2, yPos, 0f);
        GameObject beatPrefab = beats[beatIndex];

        // Instantiate the beat prefab and add it to the beat parent
        GameObject beatInstance = Instantiate(beatPrefab, beatPosition, Quaternion.identity, beatParent);
    }
}

