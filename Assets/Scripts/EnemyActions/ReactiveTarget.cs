using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (audioSource != null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        else
        { 
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReactToHit()
    {
        audioSource.Play();
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
