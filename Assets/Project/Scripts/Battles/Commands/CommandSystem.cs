using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


// This class represents a command system that is responsible for managing and executing
// animation commands in a queue. This system ensures that commands are executed sequentially.
public class CommandSystem
{
    // A queue to store animation commands
    Queue<ICommand> _aniCommandQueue;

    // Constructor initializes the queue
    public CommandSystem()
    {
        _aniCommandQueue = new Queue<ICommand>();
    }

    // Adds a new command to the queue and starts playing it if it's the first command
    public void AddCommand(ICommand newCommand)
    {
        _aniCommandQueue.Enqueue(newCommand);

        if (_aniCommandQueue.Count == 1)
        {
            _aniCommandQueue.Peek().Play();
        }

        newCommand.Sequence.OnComplete(_onComplete);
    }

    // This method is called when an animation command has completed.
    // It removes the completed command from the queue and plays the next command if there are any left.
    private void _onComplete()
    {
        _aniCommandQueue.Dequeue();

        if (_aniCommandQueue.Count > 0)
        {
            _aniCommandQueue.Peek().Play();
        }
    }
}