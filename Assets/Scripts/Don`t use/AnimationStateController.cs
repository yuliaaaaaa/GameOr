using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }
    
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPress = Input.GetKeyDown("w"); // Перевірка натискання клавіші "w"
        bool forwardRelease = Input.GetKeyUp("w"); // Перевірка відпускання клавіші "w"

        if (forwardPress && !isWalking) // Перевірка натискання клавіші "w" і стану анімації
        {
            animator.SetBool(isWalkingHash, true); // Встановлення стану анімації на true
        }
        
        if (isWalking && forwardRelease) // Перевірка стану анімації і відпускання клавіші "w"
        {
            animator.SetBool(isWalkingHash, false); // Встановлення стану анімації на false
        }
    }
}