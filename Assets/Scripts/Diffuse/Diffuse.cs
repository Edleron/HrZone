using UnityEngine;

public class Diffuse : MonoBehaviour
{
    public static Diffuse Instance { get; private set; }
    private Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartDiffuseAnim(){
        animator.SetTrigger("StartAnim");
    }

    public void OpenCodeEditor(){
        EventManager.Fire_onOpenCodePanel();
    }
}
