using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] private GameObject dummy;
    private CommandSystem _commandSystem;


    void Start()
    {
        _commandSystem = new CommandSystem();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get mousePosition
            Vector2 mousePosition = Input.mousePosition;

            _AddMoveToPositionCommand(mousePosition);
        }

        // check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _OnSpacebarPressed();
        }
    }

    /* =========================== TRIGGERED EVENTS =========================== */
    // Called by button
    public void OnAddAttackCommand()
    {
        Sequence seq = _CreateDoCastSkillSequence();
        ICommand doAttackCommand = new Command(seq);

        _commandSystem.AddCommand(doAttackCommand);
    }

    private void _OnSpacebarPressed()
    {
        Sequence seq = _CreateDelayedSequence();
        ICommand delayedCommand = new Command(seq);

        _commandSystem.AddCommand(delayedCommand);
    }

    // Adds a command to move the dummy to the given position
    private void _AddMoveToPositionCommand(Vector2 position)
    {
        Sequence seq = _CreateMoveToPositionSequence(position);
        ICommand moveToPositionCommand = new Command(seq);

        _commandSystem.AddCommand(moveToPositionCommand);
    }
    /* ========================================================================= */


    /* ========================== COMMAND CREATION ============================ */
    private Sequence _CreateMoveToPositionSequence(Vector2 position)
    {
        Sequence seq = DOTween.Sequence();
        seq.Pause(); // This is mandatory

        // Move dummy to the clicked position
        seq.Append(dummy.transform.DOMove(position, 1).SetEase(Ease.InOutCubic));

        return seq;
    }

    private Sequence _CreateDelayedSequence()
    {
        Sequence seq = DOTween.Sequence();
        seq.Pause(); // This is mandatory

        seq.AppendInterval(0.5f);
        seq.Append(dummy.transform.DOPunchScale(new Vector3(1, 1, 1), 0.25f));
        seq.AppendInterval(0.5f);

        return seq;
    }

    private Sequence _CreateDoCastSkillSequence()
    {
        Sequence seq = DOTween.Sequence();
        seq.Pause(); // This is mandatory

        // Make dummy scale up and down
        seq.Append(dummy.transform.DOScale(1.5f, 0.5f));
        seq.Append(dummy.transform.DOScale(1, 0.5f));

        return seq;
    }
    /* ========================================================================= */
}
