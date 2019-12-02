﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
//Anything inside the script will "require" this component
public class ToneGenerator : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;
    //  Audio Source Component

    private float[] samples = new float[44100];
    //Establishing the max number of samples
    private int sampleFrequecy = 44100;

    private float[] notes = { 523.25f, 391.995f, 600.25f, 456.5f, 1300.05f };
    private int currentNote;
    [SerializeField]
    public int[] sequence = { 5, 3, 1, 1, 2, 0 };
    public int[] sequence2 = { 0, 1, 2, 3, 4, 5 };

    public float[] frequencies;
    public int thisfreq;
    public double frequency = 440.0;


    //sequence referencing the position of the numbers in the array

    [SerializeField]
    private float sampleLengthInSeconds = 1;
    [SerializeField]
    private float beatsPerMinuteTempo = 120;
    // Creating the notes using their special frequencies
    //Not using these variables yet


    void Awake()
    {
        source = GetComponent<AudioSource>();
        //refrences "source" above
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMelody();
        frequencies = new float[8];
        frequencies[0] = 440.0f;
        frequencies[1] = 494.0f;
        frequencies[2] = 554.0f;
        frequencies[3] = 587.0f;
        frequencies[4] = 659.0f;
        frequencies[5] = 740.0f;
        frequencies[6] = 831.0f;
        frequencies[7] = 880.0f;

        frequency = frequencies[thisfreq];
        thisfreq += 1;



    }

    void CreateTone(float note)

    {
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(Mathf.PI * 2 * i * note / sampleFrequecy);
            //Equation for generating a sine wave
        }

        clip = AudioClip.Create("Note", samples.Length, 1, sampleFrequecy, false);
        clip.SetData(samples, 0);
    }

    void CreateTone2(float note)
    {
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Cos(Mathf.PI * 3 * i * note / sampleFrequecy);

        }

        clip = AudioClip.Create("Note", samples.Length, 1, sampleFrequecy, false);
        clip.SetData(samples, 0);

        //the second note


        //Creating own methods then referencing it in void start
        //Create an array for the notes, Create a tempo; create sounds at certain intervals. Coroutine/invokerepeating to have a beat. Synthesise tones
    }
    void CreateTone3(float note)
    {
        for(int thisfreq = 1; thisfreq <= frequencies.Length; thisfreq++)
        {
            samples[thisfreq] = thisfreq / sampleLengthInSeconds;
        }
    }

    void CreateTone4(float note)
    {
        frequency = 440.0 * 2.0 * (1760 / 12);
    }


    void PlayMelody()
        {
            if (currentNote < sequence.Length)
                currentNote += 1;
            //currentNote = currentNote + 1
            else
                currentNote = 0;


        CreateTone(notes[sequence[currentNote]]);
        //Connecting all this syntax

        CreateTone2(notes[sequence[currentNote]]);

        CreateTone3(notes[sequence[currentNote]]);

        CreateTone4(notes[sequence[currentNote]]);


            source.clip = clip;
            source.Play();

        }
}