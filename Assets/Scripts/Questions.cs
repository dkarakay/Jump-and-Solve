using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Questions : MonoBehaviour {
	public Text QuestionTime;
	public Text question;
	public Text answer1,answer2,answer3,answer4;
	public ScoreManager theScore;
	private int first,second,isaretRandom,firstDiv,secondDiv;
	private string isaret;
	public int answer,answerRandom;
	public int i,j;
	public PauseMenu thePause;
	public int lastChanceError;
	public Vector3[] lastChanceToSurvive;

	private int divRandom;
	public int [] lastChanceForReturn ; 
	public int firstDivX;
	public int[] lastChanceX;
	public int[] lastChanceY;
	private float soundEffect;
	public AudioClip backgroundMusic;

	public GameObject QuestionPanel;
	public DeathMenu theDeath;
	// Use this for initialization
	void Start () {
		soundEffect = PlayerPrefs.GetFloat ("SoundEffect");
		i = 0;
		i = j;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log ("Escape Pressed");
		}
		if (i == j) {

			switch (i) {
			case 0:
				lastChanceToSurvive [0] = thePause.lastChance;
				lastChanceX [0] = (int)lastChanceToSurvive [0].x;
				lastChanceY [0] = (int)lastChanceToSurvive [0].y;
				break;
			case 1:
				lastChanceToSurvive [1] = thePause.lastChance;
				lastChanceX [1] = (int)lastChanceToSurvive [1].x;
				lastChanceY [1] = (int)lastChanceToSurvive [1].y;
				break;
			case 2:
				lastChanceToSurvive [2] = thePause.lastChance;
				lastChanceX [2] = (int)lastChanceToSurvive [2].x;
				lastChanceY [2] = (int)lastChanceToSurvive [2].y;
				break;
			case 3:
				lastChanceToSurvive [3] = thePause.lastChance;
				lastChanceX [3] = (int)lastChanceToSurvive [3].x;
				lastChanceY [3] = (int)lastChanceToSurvive [3].y;
				break;
			case 4:
				lastChanceToSurvive [4] = thePause.lastChance;
				lastChanceX [4] = (int)lastChanceToSurvive [4].x;
				lastChanceY [4] = (int)lastChanceToSurvive [4].y;
				break;
			case 5:
				lastChanceToSurvive [5] = thePause.lastChance;
				lastChanceX [5] = (int)lastChanceToSurvive [5].x;
				lastChanceY [5] = (int)lastChanceToSurvive [5].y;
				break;
			case 6:
				lastChanceToSurvive [6] = thePause.lastChance;
				lastChanceX [6] = (int)lastChanceToSurvive [6].x;
				lastChanceY [6] = (int)lastChanceToSurvive [6].y;
				break;
			case 7:
				lastChanceToSurvive [7] = thePause.lastChance;
				lastChanceX [7] = (int)lastChanceToSurvive [7].x;
				lastChanceY [7] = (int)lastChanceToSurvive [7].y;
				break;
			case 8:
				lastChanceToSurvive [8] = thePause.lastChance;
				lastChanceX [8] = (int)lastChanceToSurvive [8].x;
				lastChanceY [8] = (int)lastChanceToSurvive [8].y;
				break;
			case 9:
				lastChanceToSurvive [9] = thePause.lastChance;
				lastChanceX [9] = (int)lastChanceToSurvive [9].x;
				lastChanceY [9] = (int)lastChanceToSurvive [9].y;
				break;
			case 10:
				lastChanceToSurvive [10] = thePause.lastChance;
				lastChanceX [10] =(int)lastChanceToSurvive [10].x;
				lastChanceY [10] =(int) lastChanceToSurvive [10].y;
				break;
			case 11:
				lastChanceToSurvive [11] = thePause.lastChance;
				lastChanceX [11] = (int)lastChanceToSurvive [11].x;
				lastChanceY [11] = (int)lastChanceToSurvive [11].y;
				break;
			case 12:
				lastChanceToSurvive [12] = thePause.lastChance;
				lastChanceX [12] = (int)lastChanceToSurvive [12].x;
				lastChanceY [12] = (int)lastChanceToSurvive [12].y;
				break;
			case 13:
				lastChanceToSurvive [13] = thePause.lastChance;
				lastChanceX [13] = (int)lastChanceToSurvive [13].x;
				lastChanceY [13] = (int)lastChanceToSurvive [13].y;
				break;
			case 14:
				lastChanceToSurvive [14] = thePause.lastChance;
				lastChanceX [14] = (int)lastChanceToSurvive [14].x;
				lastChanceY [14] = (int)lastChanceToSurvive [14].y;
				break;
			case 15:
				lastChanceToSurvive [15] = thePause.lastChance;
				lastChanceX [15] = (int)lastChanceToSurvive [15].x;
				lastChanceY [15] = (int)lastChanceToSurvive [15].y;
				break;
			case 16:
				lastChanceToSurvive [16] = thePause.lastChance;
				lastChanceX [16] = (int)lastChanceToSurvive [16].x;
				lastChanceY [16] = (int)lastChanceToSurvive [16].y;
				break;
			case 17:
				lastChanceToSurvive [17] = thePause.lastChance;
				lastChanceX [17] = (int)lastChanceToSurvive [17].x;
				lastChanceY [17] =(int) lastChanceToSurvive [17].y;
				break;
			case 18:
				lastChanceToSurvive [18] = thePause.lastChance;
				lastChanceX [18] = (int)lastChanceToSurvive [18].x;
				lastChanceY [19] = (int)lastChanceToSurvive [18].y;
				break;
			case 19:
				lastChanceToSurvive [19] = thePause.lastChance;
				lastChanceX [19] = (int)lastChanceToSurvive [19].x;
				lastChanceY [19] = (int)lastChanceToSurvive [19].y;
				break;
			case 20:
				lastChanceToSurvive [20] = thePause.lastChance;
				lastChanceX [20] = (int)Mathf.Round(lastChanceToSurvive [20].x);
				lastChanceY [20] = (int)Mathf.Round(lastChanceToSurvive [20].y);
				break;
			default:
				break;
			}

			/*for (int jj = 20; jj >lastChanceToSurvive.Length; jj--) {
				//if (i >= 2) {
				if (lastChanceToSurvive [jj+1] == lastChanceToSurvive [jj +2]) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (i >= 3) {
						if (lastChanceToSurvive [jj] == lastChanceToSurvive [jj+3]) {
							Debug.Log ("Thirdddd!!!!!!!!!!");
							lastChanceError = 2;
						}
					}
				} else {
					Debug.Log ("KEinn");
				}
				//}
			}*/

			/*if (lastChanceToSurvive [0] == lastChanceToSurvive [1]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [0] == lastChanceToSurvive [2]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [1] == lastChanceToSurvive [2]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [1] == lastChanceToSurvive [3]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [2] == lastChanceToSurvive [3]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [2] == lastChanceToSurvive [4]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [3] == lastChanceToSurvive [4]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [3] == lastChanceToSurvive [5]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [4] == lastChanceToSurvive [5]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [4] == lastChanceToSurvive [6]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [5] == lastChanceToSurvive [6]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [5] == lastChanceToSurvive [7]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [6] == lastChanceToSurvive [7]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [6] == lastChanceToSurvive [8]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [7] == lastChanceToSurvive [8]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [7] == lastChanceToSurvive [9]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [8] == lastChanceToSurvive [9]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [8] == lastChanceToSurvive [10]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [9] == lastChanceToSurvive [10]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [9] == lastChanceToSurvive [11]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [10] == lastChanceToSurvive [11]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [10] == lastChanceToSurvive [12]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [11] == lastChanceToSurvive [12]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [11] == lastChanceToSurvive [13]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [12] == lastChanceToSurvive [13]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [12] == lastChanceToSurvive [14]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [13] == lastChanceToSurvive [14]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [13] == lastChanceToSurvive [15]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [14] == lastChanceToSurvive [15]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [14] == lastChanceToSurvive [16]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [15] == lastChanceToSurvive [16]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [15] == lastChanceToSurvive [17]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [16] == lastChanceToSurvive [17]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [16] == lastChanceToSurvive [18]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [17] == lastChanceToSurvive [18]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [17] == lastChanceToSurvive [19]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [18] == lastChanceToSurvive [19]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [18] == lastChanceToSurvive [20]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			} else if (lastChanceToSurvive [19] == lastChanceToSurvive [20]) {
				Debug.Log ("TwiceError");
				lastChanceError = 2;
				if (lastChanceToSurvive [19] == lastChanceToSurvive [21]) {
					Debug.Log ("Third Error");
					PlayerPrefs.SetInt ("ErrorThird", 1);
				}
			}
			/*} else {
				Debug.Log ("NoProblem");
			}*/
////////////////////////////////////////////////// LASTVHANCEX ve Y //////////////////////////////////////////////////////////////////////////////////////////////////
				/*if (lastChanceToSurvive [0].x == lastChanceToSurvive [1].x || lastChanceToSurvive [0].y == lastChanceToSurvive [1].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [0].x == lastChanceToSurvive [2].x || lastChanceToSurvive [0].y == lastChanceToSurvive [2].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [1].x == lastChanceToSurvive [2].x || lastChanceToSurvive [1].y == lastChanceToSurvive [2].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [1].x == lastChanceToSurvive [3].x || lastChanceToSurvive [1].y == lastChanceToSurvive [3].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [2].x == lastChanceToSurvive [3].x || lastChanceToSurvive [2].y == lastChanceToSurvive [3].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [2].x == lastChanceToSurvive [4].x || lastChanceToSurvive [2].y == lastChanceToSurvive [4].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [3].x == lastChanceToSurvive [4].x || lastChanceToSurvive [3].y == lastChanceToSurvive [4].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [3].x == lastChanceToSurvive [5].x || lastChanceToSurvive [3].y == lastChanceToSurvive [5].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [4].x == lastChanceToSurvive [5].x || lastChanceToSurvive [4].y == lastChanceToSurvive [5].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [4].x == lastChanceToSurvive [6].x || lastChanceToSurvive [4].y == lastChanceToSurvive [6].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [5].x == lastChanceToSurvive [6].x || lastChanceToSurvive [5].y == lastChanceToSurvive [6].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [5].x == lastChanceToSurvive [7].x || lastChanceToSurvive [5].y == lastChanceToSurvive [7].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [6].x == lastChanceToSurvive [7].x || lastChanceToSurvive [6].y == lastChanceToSurvive [7].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [6].x == lastChanceToSurvive [8].x || lastChanceToSurvive [6].y == lastChanceToSurvive [8].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [7].x == lastChanceToSurvive [8].x || lastChanceToSurvive [7].y == lastChanceToSurvive [8].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [7].x == lastChanceToSurvive [9].x || lastChanceToSurvive [7].y == lastChanceToSurvive [9].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [8].x == lastChanceToSurvive [9].x && lastChanceToSurvive [8].y == lastChanceToSurvive [9].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [8].x == lastChanceToSurvive [10].x && lastChanceToSurvive [8].y == lastChanceToSurvive [10].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [9].x == lastChanceToSurvive [10].x && lastChanceToSurvive [9].y == lastChanceToSurvive [10].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [9].x == lastChanceToSurvive [11].x && lastChanceToSurvive [9].y == lastChanceToSurvive [11].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [10].x == lastChanceToSurvive [11].x && lastChanceToSurvive [10].y == lastChanceToSurvive [11].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [10].x == lastChanceToSurvive [12].x || lastChanceToSurvive [10].y == lastChanceToSurvive [12].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [11].x == lastChanceToSurvive [12].x || lastChanceToSurvive [11].y == lastChanceToSurvive [12].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [11].x == lastChanceToSurvive [13].x || lastChanceToSurvive [11].y == lastChanceToSurvive [13].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [12].x == lastChanceToSurvive [13].x || lastChanceToSurvive [12].y == lastChanceToSurvive [13].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [12].x == lastChanceToSurvive [14].x || lastChanceToSurvive [12].y == lastChanceToSurvive [13].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [13].x == lastChanceToSurvive [14].x || lastChanceToSurvive [13].y == lastChanceToSurvive [14].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [13].x == lastChanceToSurvive [15].x || lastChanceToSurvive [13].y == lastChanceToSurvive [15].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [14].x == lastChanceToSurvive [15].x || lastChanceToSurvive [14].y == lastChanceToSurvive [15].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [14].x == lastChanceToSurvive [16].x || lastChanceToSurvive [14].y == lastChanceToSurvive [16].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [15].x == lastChanceToSurvive [16].x || lastChanceToSurvive [15].y == lastChanceToSurvive [16].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [15].x == lastChanceToSurvive [17].x || lastChanceToSurvive [15].y == lastChanceToSurvive [17].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [16].x == lastChanceToSurvive [17].x || lastChanceToSurvive [16].y == lastChanceToSurvive [17].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [16].x == lastChanceToSurvive [18].x || lastChanceToSurvive [16].y == lastChanceToSurvive [18].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [17].x == lastChanceToSurvive [18].x || lastChanceToSurvive [17].y == lastChanceToSurvive [18].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [17].x == lastChanceToSurvive [19].x || lastChanceToSurvive [17].y == lastChanceToSurvive [19].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [18].x == lastChanceToSurvive [19].x || lastChanceToSurvive [18].y == lastChanceToSurvive [19].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [18].x == lastChanceToSurvive [20].x || lastChanceToSurvive [18].y == lastChanceToSurvive [20].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				} else if (lastChanceToSurvive [19].x == lastChanceToSurvive [20].x || lastChanceToSurvive [19].y == lastChanceToSurvive [20].y) {
					Debug.Log ("TwiceError");
					lastChanceError = 2;
					if (lastChanceToSurvive [19].x == lastChanceToSurvive [21].x || lastChanceToSurvive [19].y == lastChanceToSurvive [21].y) {
						Debug.Log ("Third Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}
				}
			/*} else {
				PlayerPrefs.SetInt ("ErrorThird", 0);
				Debug.Log ("NoProblem");
			}*/


			if (i == 0) {				
				first = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				second = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				firstDiv = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				secondDiv = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (1.5f, 3.5f));
			}else if (i == 1) {
				first = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				second = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				firstDiv = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				secondDiv = (int)Mathf.Round (Random.Range (0.5f, 9.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 1.5f));
			} else if (i == 2) {
				first = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				second = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				firstDiv = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				secondDiv = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 3.5f));
			} else if (i == 3) {
				first = (int)Mathf.Round (Random.Range (9.5f, 99.5f));
				second = (int)Mathf.Round (Random.Range (9.5f, 99.5f));
				firstDiv = (int)Mathf.Round (Random.Range (9.5f, 99.5f));
				secondDiv = (int)Mathf.Round (Random.Range (9.5f, 99.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 1.5f));
			} else if (i == 4) {
				first = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				second = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				firstDiv = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				secondDiv = (int)Mathf.Round (Random.Range (0.5f, 99.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 3.5f));
			} else if (i == 5) {
				first = (int)Mathf.Round (Random.Range (99.5f, 999.5f));
				second = (int)Mathf.Round (Random.Range (99.5f, 999.5f));
				firstDiv = (int)Mathf.Round (Random.Range (99.5f, 999.5f));
				secondDiv = (int)Mathf.Round (Random.Range (99.5f, 999.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 3.5f));
			} else if (i == 6) {
				first = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				second = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				firstDiv = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				secondDiv = (int)Mathf.Round (Random.Range (0.5f, 999.5f));	
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 3.5f));
			} else{
				first = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				second = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				firstDiv = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				secondDiv = (int)Mathf.Round (Random.Range (0.5f, 999.5f));
				isaretRandom = (int)Mathf.Round (Random.Range (-0.5f, 3.5f));
			}
			switch (isaretRandom) {
			case 0:
				isaret = "x";
				answer = first * second;

				break;
			case 1:
				isaret = "÷";
				if (secondDiv == firstDiv) {
					answer = 1;
				} else {
				firstDivX = firstDiv * secondDiv;
				divRandom = (int)Mathf.Round (Random.Range (-0.5f, 1.5f));
					switch (divRandom) {
					case 0:
					answer = firstDiv;
						break;
					case 1:
					answer = secondDiv;
						break;
					default:
					answer = firstDiv;
						break;
					}
				
				}
				break;
			case 2:
				isaret = "+";
				answer = first + second;
				break;
			case 3:
				isaret = "-";
				answer = first - second;
				break;
			}
			if (isaretRandom == 1) {
			switch (divRandom) {
			case 0:
				question.text = firstDivX + isaret + secondDiv + "=?";				
				break;
			case 1:
				question.text = firstDivX + isaret + firstDiv + "=?";				
				break;
			default:
				question.text = firstDivX + isaret + secondDiv + "=?";				
				break;
			}					
					
			} else {
				question.text = first + isaret + second + "=?";
			}

			answerRandom = (int)Mathf.Round (Random.Range (-0.5f, 3.5f));
			switch (answerRandom) {
			case 0:
				answer1.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer2.text = "" + (answer + second);
					answer3.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				case 1:
					answer2.text = "" + (answer + 1);
					answer3.text = "" + (answer + 1 + 1);
					answer4.text = "" + (answer - 1);
					break;
				case 2:
					answer2.text = "" + (answer + second);
					answer3.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				case 3:
					answer2.text = "" + (answer + second);
					answer3.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				}
				break;
			case 1:
				answer2.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer1.text = "" + (answer + second);
					answer3.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				case 1:
					answer1.text = "" + (answer + 1);
					answer3.text = "" + (answer + 2);
					answer4.text = "" + (answer - 1);
					break;
				case 2:
					answer1.text = "" + (answer + second);
					answer3.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				case 3:
					answer1.text = "" + (answer + second);
					answer3.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				}
				break;
			case 2:
				answer3.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer1.text = "" + (answer + second);
					answer2.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				case 1:
					answer1.text = "" + (answer + 1);
					answer2.text = "" + (answer + 1 + 1);
					answer4.text = "" + (answer - 1);
					break;
				case 2:
					answer1.text = "" + (answer + second);
					answer2.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				case 3:
					answer1.text = "" + (answer + second);
					answer2.text = "" + (answer + second + second);
					answer4.text = "" + (answer - second);
					break;
				}
				break;
			case 3:
				answer4.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer1.text = "" + (answer + second);
					answer2.text = "" + (answer + second + second);
					answer3.text = "" + (answer - second);
					break;
				case 1:
					answer1.text = "" + (answer + 1);
					answer2.text = "" + (answer + 1 + 1);
					answer3.text = "" + (answer - 1);
					break;
				case 2:
					answer1.text = "" + (answer + second);
					answer2.text = "" + (answer + second + second);
					answer3.text = "" + (answer - second);
					break;
				case 3:
					answer1.text = "" + (answer + second);
					answer2.text = "" + (answer + second + second);
					answer3.text = "" + (answer - second);
					break;
				}
				break;
			case 4:
				answer1.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer2.text = "" + (answer + first);
					answer3.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				case 1:
					answer2.text = "" + (answer + 1);
					answer3.text = "" + (answer + 1 + 1);
					answer4.text = "" + (answer - 1);
					break;
				case 2:
					answer2.text = "" + (answer + first);
					answer3.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				case 3:
					answer2.text = "" + (answer + first);
					answer3.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				}
				break;
			case 5:
				answer2.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer1.text = "" + (answer + first);
					answer3.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				case 1:
					answer1.text = "" + (answer + 1);
					answer3.text = "" + (answer + 1 + 1);
					answer4.text = "" + (answer - 1);
					break;
				case 2:
					answer1.text = "" + (answer + first);
					answer3.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				case 3:
					answer1.text = "" + (answer + first);
					answer3.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				}
				break;
			case 6:
				answer3.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer1.text = "" + (answer + first);
					answer2.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				case 1:
					answer1.text = "" + (answer + 1);
					answer2.text = "" + (answer + 1 + 1);
					answer4.text = "" + (answer - 1);
					break;
				case 2:
					answer1.text = "" + (answer + first);
					answer2.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				case 3:
					answer1.text = "" + (answer + first);
					answer2.text = "" + (answer + first + first);
					answer4.text = "" + (answer - first);
					break;
				}
				break;
			case 7:
				answer4.text = "" + answer;
				switch (isaretRandom) {
				case 0:
					answer1.text = "" + (answer + first);
					answer2.text = "" + (answer + first + first);
					answer3.text = "" + (answer - first);
					break;
				case 1:
					answer1.text = "" + (answer + 1);
					answer2.text = "" + (answer + 1 + 1);
					answer3.text = "" + (answer - 1);
					break;
				case 2:
					answer1.text = "" + (answer + first);
					answer2.text = "" + (answer + first + first);
					answer3.text = "" + (answer - first);
					break;
				case 3:
					answer1.text = "" + (answer + first);
					answer2.text = "" + (answer + first + first);
					answer3.text = "" + (answer - first);
					break;
				}
				break;
			}
		/*	QuestionTime.color = new Color32 (3,216,0,255);
			QuestionTime.text = "5";*/
	switch(i){
			case 1:
				if (lastChanceToSurvive [0].x == lastChanceToSurvive [1].x) {
					Debug.Log ("2nd Error" + i);
					lastChanceError = 2;
					lastChanceForReturn [0] = i;
				} else {
					Debug.Log ("OHHH NO");
				}
		break;
			case 2:
				if (lastChanceToSurvive [1].x == lastChanceToSurvive [2].x) {
					Debug.Log ("2nd Error" + i);
					lastChanceError = 2;
					if (lastChanceForReturn [0] == 1) {
						Debug.Log ("3rd Error");
						PlayerPrefs.SetInt ("ErrorThird", 1);
					}

				} else {
			Debug.Log ("OHHH NO");		
		}

		break;

	}
			StartCoroutine ("questionTime");
			i += 1;
		}
	}

	public void death(){
	MundoSound.Play (backgroundMusic,soundEffect,false);
		theDeath.gameObject.SetActive (true);
	}
	public IEnumerator questionTime(){		
			QuestionTime.color = new Color32 (3, 216, 0, 255);
			QuestionTime.text = "5";
			yield return new WaitForSeconds (1);
			QuestionTime.color = new Color32 (158, 206, 0, 255);
			QuestionTime.text = "4";
			yield return new WaitForSeconds (1);
			QuestionTime.color = new Color32 (212, 131, 0, 255);
			QuestionTime.text = "3";
			yield return new WaitForSeconds (1);
			QuestionTime.color = new Color32 (195, 26, 0, 255);
			QuestionTime.text = "2";
			yield return new WaitForSeconds (1);
			QuestionTime.color = new Color32 (197, 0, 0, 255);
			QuestionTime.text = "1";
		    PlayerPrefs.SetInt ("cevap", 0);
			yield return new WaitForSeconds (1);
			QuestionPanel.SetActive (false);
		    if (PlayerPrefs.GetInt ("cevap") == 1) {
			} else {
				death ();
			}
		}
}
