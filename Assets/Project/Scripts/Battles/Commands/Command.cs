using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// This class represents a command which implements the ICommand interface.
public class Command : ICommand
{
    private Sequence _sequence;

    // Property that exposes the sequence of the command
    public Sequence Sequence => _sequence;

    // Constructor initializes the sequence with a given value
    public Command(Sequence sequence)
    {
        _sequence = sequence;
    }

    // Starts playing the sequence
    public void Play()
    {
        _sequence.Play();
    }
}