using UnityEngine;
using System.Collections;

public class Sound_Player : MonoBehaviour {

	
	public AudioClip[] Sound;
	
	
	
	public void SoundPlay(int SoundNumber){
         
         GetComponent<AudioSource>().clip = Sound[SoundNumber];
         GetComponent<AudioSource>().Play();
		
    }
	
}
