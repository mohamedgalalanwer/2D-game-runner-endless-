using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum GameState
{
	Play,
	Pause,
	End,
}

public class Game_Manager : MonoBehaviour
{
	public GameState GS;
	public int GameLv;
	public float GameSpeed;
	public Box_Loop _BL;
	//public Scroll_Mapping _SM;

	

	public float Meter;
	public int GetMoney = 0;


	

	public GUIText Gold_Label;
	public GUIText Meter_Label;
	
	GUIStyle guiRectStyle;

	public Texture Pause_btn;
	public Texture Go_btn;
	public Texture Replay_btn;
	
	float screenX;
	float screenY;
	
	void Start ()
	{		
		GameObject a = GameObject.Find("02_Box_Maker");
		if(a!=null)_BL = a.GetComponent<Box_Loop>();		
		GameObject b = GameObject.Find("01_Sky");
		//if(b!=null)_SM = b.GetComponent<Scroll_Mapping>();
		
		GameSpeed = _BL.Speed;		
		SCREENSETTING ();
	}

	void Update ()
	{
		if (GS == GameState.Play) {
			METERUPDATE ();
		}

	}
	
	void SCREENSETTING ()
	{
		screenX = Screen.width;
		screenY = Screen.height;
		guiRectStyle = new GUIStyle ();
		guiRectStyle.border = new RectOffset (0, 0, 0, 0);
		//_fade.FadeIn ();
	}
	
	void OnGUI ()
	{
		

		if (GS == GameState.Play) {

			if (GUI.Button (new Rect (20, 20, Pause_btn.width, Pause_btn.height), Pause_btn, guiRectStyle)) {
			
				GS = GameState.Pause;
				Time.timeScale = 0;
			}
		}


		

		if (GS == GameState.Pause) {

			if (GUI.Button (new Rect (screenX * 0.5f - Go_btn.width * 0.5f, screenY * 0.5f + Replay_btn.height * 0.5f + 10f, Go_btn.width, Go_btn.height), Go_btn, guiRectStyle)) {
				
				Time.timeScale = 1;
				GS = GameState.Play;

			}

		}

		

        if (GS == GameState.End)
        {
            if (GUI.Button(new Rect(screenX * 0.5f - Replay_btn.width * 0.5f, screenY * 0.5f + 10f, Replay_btn.width, Replay_btn.height), Replay_btn, guiRectStyle))
            {
                SceneManager.LoadScene("GameManager");
               
            }

            
		}
	}
   
	public void GAMEOVER ()
	{
		GS = GameState.End;
       
	}
	
	public void GETCOIN ()
	{
		GetMoney += 1;
		Gold_Label.text = string.Format ("{0:N0}", GetMoney);
	}

	public void METERUPDATE ()
	{
		Meter += Time.deltaTime * GameSpeed;
		Meter_Label.text = string.Format ("{0:N0}<color=#ff3366> m</color>", Meter);

		

		if (Meter >= 50 && GameLv == 1) {
			GameLevelUp ();
		}

		if (Meter >= 100 && GameLv == 2) {
			GameLevelUp ();
		}

		if (Meter >= 150 && GameLv == 3) {
			GameLevelUp ();
		}

		if (Meter >= 200 && GameLv == 4) {
			GameLevelUp ();
		}

		if (Meter >= 250 && GameLv == 5) {
			GameLevelUp ();
		}

		if (Meter >= 300 && GameLv == 6) {
			GameLevelUp ();
		}
	}

	public void GameLevelUp ()
	{
		GameLv += 1;
		GameSpeed += 3;
		//_SM.ScrollSpeed += 0.1f;
		_BL.Speed = GameSpeed;
	}
}