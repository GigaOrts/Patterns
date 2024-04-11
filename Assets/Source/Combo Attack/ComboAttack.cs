using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;
    
    private int comboCounter;
    private int tempCounter;
    private bool isAttacking;
    private Animator animator;

    private Timer resetComboTimer;
    private Timer nextComboTimer;

    private void Awake()
    {
        resetComboTimer = new Timer(clip.length, ResetState);
        nextComboTimer = new Timer(clip.length, NextState);

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        bool CanAttack = comboCounter < 3 && Input.GetKeyDown(KeyCode.Space);

        if (CanAttack && isAttacking == false)
        {
            ProcessCombo();
        }
        else if (CanAttack && isAttacking)
        {
            PrepareNextState();
        }

        if (isAttacking && tempCounter > 0)
        {
            nextComboTimer.Countdown(Time.deltaTime);
        }
        else if (isAttacking)
        {
            resetComboTimer.Countdown(Time.deltaTime);
        }
    }

    private void ProcessCombo()
    {
        isAttacking = true;
        comboCounter++;
        resetComboTimer.Reset();

        animator.SetInteger("ComboCounter", comboCounter);
    }

    private void PrepareNextState()
    {
        tempCounter = comboCounter;
        tempCounter++;
        nextComboTimer.Countdown(resetComboTimer.ElapsedTime);
        
        resetComboTimer.Reset();
    }

    private void NextState()
    {
        comboCounter++;
        animator.SetInteger("ComboCounter", tempCounter);
        tempCounter = 0;
    }

    private void ResetState()
    {
        comboCounter = 0;
        animator.SetInteger("ComboCounter", comboCounter);
        isAttacking = false;
    }

    private void OnGUI()
    {
        GUILayout.Label($"ComboCounter: {comboCounter}");
        GUILayout.Label($"Elapsed RESET: {resetComboTimer.ElapsedTime}");
        GUILayout.Label($"Elapsed NEXT: {nextComboTimer.ElapsedTime}");
    }
}
