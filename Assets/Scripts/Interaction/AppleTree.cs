using System.Collections;
using UnityEngine;

public class AppleTree : MonoBehaviour, IInteractable
{
    private bool JustInteracted = false;

    public GameObject TreeNoApple;

    public AudioClip applePickupClip;

    public void OnInteract(Interactor interactor, out bool interactSuccessful)
    {
        if (JustInteracted == false)
        {
            Player.instance.GiveApple(3);

            JustInteracted = true;

            Player.instance.GetComponent<AudioSource>().PlayOneShot(applePickupClip);

            TreeNoApple.SetActive(true);
            
            StartCoroutine(WaitFiveSecondsAndAllowInteraction());
        }
        
        interactSuccessful = true;
    }

    IEnumerator WaitFiveSecondsAndAllowInteraction()
    {
        yield return new WaitForSeconds(5f);

        TreeNoApple.SetActive(false);

        JustInteracted = false;
    }
}
