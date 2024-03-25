using UnityEngine;
using System.Collections;
public class PickUpBehavior : MonoBehaviour
{
    public Animator playerAnim;
    public Outline script;
    public static bool outlineCheck;
    private static GameObject highlightedObject;
    private void Start()
    {
        script.enabled = false;
        outlineCheck = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.enabled = true;
            outlineCheck = true;
            highlightedObject = gameObject;            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            script.enabled = false;
            outlineCheck = false;
            if (highlightedObject == gameObject)
            {
                highlightedObject = null;
            }
        }
    }

    private void OnEnable()
    {
        if (script != null)
        {
            PressKeyBehavior.PressE.AddListener(GetItem);
        }
    }

    private void GetItem()
    {
        StartCoroutine(DestroyObjectAfterDelay(1f));
        playerAnim.SetTrigger("pickup");
        playerAnim.SetTrigger("idle");
        outlineCheck = false;
    }
    
    private IEnumerator DestroyObjectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(highlightedObject);
    }
}


