using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowSnake : MonoBehaviour {
    public AudioClip hitSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.CompareTag ("Player")) {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(hitSound, vol);
            transform.localScale = new Vector3 (-1, 1, 1);
		}
	}
}
