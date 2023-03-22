using UnityEngine;
using DG.Tweening;


// This interface defines the required properties and methods for an animation command.
public interface ICommand
{
    // Property to expose the animation sequence
    Sequence Sequence { get; }

    // Method to play the animation sequence
    void Play();
}
