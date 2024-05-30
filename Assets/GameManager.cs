using System.Collections;
using System.Collections.Generic;
using UnityEngine;
private void Start(){}
	public class GameManager : MonoBehaviour(){
    // Start is called before the first frame update
    #region Singleton;
	public static GameManager Instance;
	private void Awake()
		if ( Instance==null) Instance=this;{
			
		}
	#endregion;
	public float currentScore=Of;
	
	public bool isPlaying =false;
	private void Update(){
		if (isPlaying){
			currentScore+=Time.deltaTime;
		}
	}
	
	public void GameOver(){
		currentScore=0;
	}
	public string PrettyScore (){
		return Mathf.RoundToInt(currentScore).ToString();
	}
	}