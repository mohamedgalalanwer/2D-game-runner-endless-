using UnityEngine;
using System.Collections;

public class Player_Get : MonoBehaviour
{
	
	public Sound_Player _SP;
	public Player_Move _PM;
	public int Get_Coin_Count;
	public Game_Manager _gm;
	//public Fade _fade;
	
	void Start(){
	
		GameObject a = GameObject.Find("05_GameManager");
		if(a!=null)_gm = a.GetComponent<Game_Manager>();
		
		//GameObject b = GameObject.Find("Black_Screen");
		//if(b!=null)_fade = b.GetComponent<Fade>();
		
	}
	
	void OnTriggerEnter (Collider other)
	{
       
		if (other.tag == "coin") {	
			other.gameObject.SetActive (false);
			Get_Coin_Count += 1;
			if (_gm != null)
				_gm.GETCOIN ();
			
			if (_SP != null)
				_SP.SoundPlay (1);
		}
		
		
		if (other.tag == "DeathZone") {
			Debug.Log ("Die");
			if (_PM.status != PlayerMoveStatus.Die) {
				_PM.status = PlayerMoveStatus.Die;
				//Handheld.Vibrate ();
				this.gameObject.GetComponent<Rigidbody>().AddForce (0, -50f, 0);
				if (_gm != null)
					_gm.GAMEOVER ();
			
				if (_SP != null)
					_SP.SoundPlay (2);
                //if (_fade != null)
                //    _fade.FadeOut ();
			}
			
		}
	}
		
}
