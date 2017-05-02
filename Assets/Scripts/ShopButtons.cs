using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;


public class ShopButtons : MonoBehaviour {
	public GameObject theCharacterPanel,theExtrasPanel,theBGPanel,theNotEnoughPanel,theExchange,theExchangefromGold,theExchangefromBronze;
	private int selected,selectedTile,selectedBG;
	private int selectedSure,selectedItemC = 0,selectItemT = 5,selectedItemBG = 2;
	public string [] boughtItemC,boughtItemT,boughtItemBG;
	public GameObject [] iBought,iHere,iSelect,iSelectT,iSelectBG;
	public Button[] interactButtons;
	public AudioClip audioClip;
	private float musicSound;
	public int b_ex = 0,g_ex = 0;
	// Use this for initialization
	public Text coinGold,coinBronze,B_Ex_Bronze,G_ExchangeFromBronze,B_Ex_G,G_ExG;
	public GameObject theSurePanel;
	void Start () {

		B_Ex_Bronze.text = ""+b_ex;
		G_ExchangeFromBronze.text = ""+b_ex;
		B_Ex_G.text = "" + g_ex;
		G_ExG.text = "" + g_ex;
	/*	PlayerPrefs.SetInt ("CoinGold", 10000);
		PlayerPrefs.SetInt ("CoinBronze", 10000);*/
		theCharacterPanel.SetActive (true);	
		//PlayerPrefs.SetInt ("FBScreen", 0);
		musicSound = PlayerPrefs.GetFloat ("MusicSound");
		selectedTile = PlayerPrefs.GetInt("selectedTile");
		MundoSound.Play (audioClip, (musicSound), true);
	}
	
	// Update is called once per frame
	void Update () {
		AllCharacter ();
		AllTiles ();
		AllBGs ();
		if (PlayerPrefs.GetString ("AQL") == "on" && PlayerPrefs.GetString ("ALL") == "on") {
			Social.ReportProgress(AchievementsJS.achievement_character_expert, 100.0f, (bool success) => {
				// handle success or failure
			});
		} else {
		}
		if (PlayerPrefs.GetInt ("CoinGold") > 50) {
			Social.ReportProgress(AchievementsJS.achievement_gold_collector, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt ("CoinBronze") > 50) {
			Social.ReportProgress(AchievementsJS.achievement_bronze_collector, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt ("CoinBronze") > 100 && PlayerPrefs.GetInt ("CoinGold") > 100) {
			Social.ReportProgress(AchievementsJS.achievement_real_collector, 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		coinGold.text = "" + PlayerPrefs.GetInt ("CoinGold");
		coinBronze.text = "" + PlayerPrefs.GetInt ("CoinBronze");
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene ("MainMenu");
		}
		//Interact Buttons
		if (theNotEnoughPanel.activeInHierarchy || theSurePanel.activeInHierarchy) {
			for (int i = 0; i < interactButtons.Length; i++) {
				interactButtons [i].interactable = false;
			}
		} else {
			for (int i = 0; i < interactButtons.Length; i++) {
				interactButtons [i].interactable = true;
			}
		}
		//Bought System
		for (int i = 0; i < iHere.Length; i++) {
			if (PlayerPrefs.GetString ("Bought" + i) == "yes") {
				if (i != 9 || i != 19) {
					iHere [i].SetActive (false);
					iBought [i].SetActive (true);
				}

			}
		}
		for (int i = 0; i < 5; i++) {
			
				iSelectT [i].SetActive (false);

		}
		for (int i = 6; i < iSelectT.Length; i++) {
			iSelectT [i].SetActive (false);

		}
	
		for (int i = 0; i < iSelectBG.Length; i++) {
			iSelectBG [i].SetActive (false);
				
		}
		for (int i = 0; i < iSelect.Length-1; i++) {
			if (i != 9) {
				iSelect [i].SetActive (false);
			}
		}
		int sel = PlayerPrefs.GetInt ("selectedThickCharacter");
		int selT = PlayerPrefs.GetInt ("selectedThickTile");
		int selBG = PlayerPrefs.GetInt ("selectedThickBG"); 
		switch (selBG){
		case 0:
			iSelectBG [0].SetActive (true);		
			Debug.Log ("Active BG 0");
			break;
		case 1:
			iSelectBG [1].SetActive (true);		
			Debug.Log ("Active BG 1");
			break;
		case 2:
			iSelectBG [2].SetActive (true);
			Debug.Log ("Active BG 2");
			break;
		default :
			Debug.Log ("Active BG 2");
			iSelectBG [2].SetActive (true);
			break;
		}
		switch (selT) {
		case 0:
			iSelectT [0].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 1:
			iSelectT [1].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 2:
			iSelectT [2].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 3:
			iSelectT [3].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 4:
			iSelectT [4].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 5:
			iSelectT [5].SetActive (true);
			break;
		case 6:
			iSelectT [6].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 7:
			iSelectT [7].SetActive (true);
			iSelectT [5].SetActive (false);		
			break;
		case 8:
			iSelectT [8].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 9:
			iSelectT [9].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 10:
			iSelectT [10].SetActive (true);
			iSelectT [5].SetActive (false);
			break;
		case 11:
			iSelectT [11].SetActive (true);
			iSelectT [5].SetActive (false);
			break;		
		case 12:
			iSelectT [12].SetActive (true);
			iSelectT [5].SetActive (false);
			break;		
		default :
			iSelectT [5].SetActive (true);
			break;
		}


		switch (sel) {
		case 0:			
			iSelect [0].SetActive (true);
			break;
		case 1:
			iSelect [1].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 2:
			iSelect [2].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 3:
			iSelect [3].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 4:			
			iSelect [4].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 5:
			iSelect [5].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 6:
			iSelect [6].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 7:
			iSelect [7].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 8:			
			iSelect [8].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 10:
			iSelect [10].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 11:
			iSelect [11].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 12:
			iSelect [12].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 13:
			iSelect [13].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 14:			
			iSelect [14].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 15:
			iSelect [15].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 16:
			iSelect [16].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 17:
			iSelect [17].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		case 18:			
			iSelect [18].SetActive (true);
			iSelect [0].SetActive (false);
			break;
		default:
			iSelect [0].SetActive (true);
			break;
		}


	}


	public void PlusfromBronze(){
		int bronze = PlayerPrefs.GetInt ("CoinBronze");
		int q = bronze / 5;
		if (q * 5 <= bronze) {
			b_ex += 5;
			B_Ex_Bronze.text = "" + b_ex;
			G_ExchangeFromBronze.text = "" + b_ex / 5;
	
		}
	}
	public void MinusfromBronze(){		
		if (b_ex != 0) {
			b_ex -= 5;
			B_Ex_Bronze.text = "" + b_ex;
			G_ExchangeFromBronze.text = "" + b_ex / 5;
		}
	}
	public void PlusfromGold(){
		int bronze = PlayerPrefs.GetInt ("CoinGold");
		int q = bronze * 5;
		if (q / 5 <= bronze) {
			g_ex += 1;
			G_ExG.text = "" + g_ex;
			B_Ex_G.text = "" + g_ex * 5;

		}
	}
	public void MinusfromGold(){		
		if (g_ex != 0) {
			g_ex -= 1;
			G_ExG.text = "" + g_ex;
			B_Ex_G.text = "" + g_ex * 5;
		}
	}
	public void B_OK(){
		if (b_ex != 0) {
			int bronze = PlayerPrefs.GetInt ("CoinBronze");
			int gold = PlayerPrefs.GetInt ("CoinGold");
			if (b_ex <= bronze) {
				PlayerPrefs.SetInt ("OKB", 0);
				BronzeBuy (b_ex);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					int gg = b_ex / 5;
					PlayerPrefs.SetInt ("CoinGold", gold + gg);
					SceneManager.LoadScene ("Shop");
					Social.ReportProgress(AchievementsJS.achievement_exchange_it, 100.0f, (bool success) => {
						// handle success or failure
					});
				}
			} else {
				theExchangefromGold.SetActive (false);
				theExchangefromBronze.SetActive (false);
				theNotEnoughPanel.SetActive (true);
			}
		}
	}
	public void G_OK(){
		if (g_ex != 0) {
			int bronze = PlayerPrefs.GetInt ("CoinBronze");
			int gold = PlayerPrefs.GetInt ("CoinGold");
			if (g_ex <= gold) {
				PlayerPrefs.SetInt ("OKG", 0);
				GoldBuy (g_ex);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					int gg = g_ex * 5;
					PlayerPrefs.SetInt ("CoinBronze", bronze + gg);
					SceneManager.LoadScene ("Shop");
					Social.ReportProgress(AchievementsJS.achievement_exchange_it, 100.0f, (bool success) => {
						// handle success or failure
					});
				}
			} else {
				theExchangefromGold.SetActive (false);
				theExchangefromBronze.SetActive (false);
				theNotEnoughPanel.SetActive (true);
			}
		}
	}
	public void B_Max(){
		int bronze = PlayerPrefs.GetInt ("CoinBronze");
		int q = bronze / 5;
		B_Ex_Bronze.text = "" + q*5;
		G_ExchangeFromBronze.text = "" + q;
		b_ex = q * 5;
	}
	public void G_Max(){
		int gold = PlayerPrefs.GetInt ("CoinGold");
		int q = gold * 5;
		B_Ex_G.text = "" + q;
		G_ExG.text = "" + gold;
		g_ex = gold;
	}




	public void ExchangefromGold(){
		theExchangefromBronze.SetActive (false);
		theExchange.SetActive (false);
		theExchangefromGold.SetActive (true);
	}
	public void ExchangefromBronze(){		
		theExchange.SetActive (false);
		theExchangefromGold.SetActive (false);
		theExchangefromBronze.SetActive (true);
	}
	public void CharacterButton (){
		theExchangefromBronze.SetActive (false);
		theExchangefromGold.SetActive (false);
		theExtrasPanel.SetActive (false);
		theExchange.SetActive (false);
		theBGPanel.SetActive (false);
		theCharacterPanel.SetActive (true);	
	}
	public void ExtrasButton (){
		theExchangefromBronze.SetActive (false);
		theExchangefromGold.SetActive (false);
		theCharacterPanel.SetActive (false);
		theExchange.SetActive (false);
		theBGPanel.SetActive (false);
		theExtrasPanel.SetActive (true);
	}
	public void BGButton(){
		theExchangefromBronze.SetActive (false);
		theExchangefromGold.SetActive (false);
		theCharacterPanel.SetActive (false);
		theExtrasPanel.SetActive (false);
		theExchange.SetActive (false);
		theBGPanel.SetActive (true);
	}
	public void ExChangeButton(){
		theExchangefromBronze.SetActive (false);
		theExchangefromGold.SetActive (false);
		theCharacterPanel.SetActive (false);
		theExtrasPanel.SetActive (false);
		theBGPanel.SetActive (false);
		theExchange.SetActive (true);
	}

	public void BlueButton(){
		selectedSure = 0;
		Select (selectedSure);
	}
	public void RedButton(){
		selectedSure = 1;
		if (PlayerPrefs.GetString ("Bought1") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void GreenButton(){
		selectedSure = 2;
		if (PlayerPrefs.GetString ("Bought2") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void GreyButton(){
		selectedSure = 3;
		if (PlayerPrefs.GetString ("Bought3") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void BlueReButton(){
		selectedSure = 10;
		if (PlayerPrefs.GetString ("Bought10") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void RedReButton(){
		selectedSure = 11;
		if (PlayerPrefs.GetString ("Bought11") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void GreenReButton(){
		selectedSure = 12;
		if (PlayerPrefs.GetString ("Bought12") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void GreyReButton(){
		selectedSure = 13;
		if (PlayerPrefs.GetString ("Bought13") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void DevilButton(){
		selectedSure = 14;
		if (PlayerPrefs.GetString ("Bought14") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void AlienBiegeButton(){
		selectedSure = 15;
		if (PlayerPrefs.GetString ("Bought15") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void AlienBlueButton(){
		selectedSure = 4;
		if (PlayerPrefs.GetString ("Bought4") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void AlienYellowButton(){
		selectedSure = 16;
		if (PlayerPrefs.GetString ("Bought16") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void AlienDarkBlueButton(){
		selectedSure = 17;
		if (PlayerPrefs.GetString ("Bought17") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void AlienPinkButton(){
		selectedSure = 18;
		if (PlayerPrefs.GetString ("Bought18") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void TruckYellowButton(){
		selectedSure = 6;
		if (PlayerPrefs.GetString ("Bought6") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void TruckRedButton(){
		selectedSure = 5;
		if (PlayerPrefs.GetString ("Bought5") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void TruckGreenButton(){
		selectedSure = 8;
		if (PlayerPrefs.GetString ("Bought8") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void TruckBlueButton(){
		selectedSure = 7;
		if (PlayerPrefs.GetString ("Bought7") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			Select (selectedSure);
		}
	}
	public void TileBlue(){
		selectedSure = 20;
		if (PlayerPrefs.GetString ("Bought20") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileGreen(){
		selectedSure = 22;
		if (PlayerPrefs.GetString ("Bought22") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
		
	}
	public void TileYellow(){
		selectedSure = 21;
		if (PlayerPrefs.GetString ("Bought21") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileCake(){
		selectedSure = 23;
		if (PlayerPrefs.GetString ("Bought23") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileCastle(){
		selectedSure = 24;
		if (PlayerPrefs.GetString ("Bought24") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileChoco(){
		selectedSure = 25;
		/*if (PlayerPrefs.GetString ("Bought25") != "yes") {
			theSurePanel.SetActive (true);
		}else{*/
			SelectTile (selectedSure);
		//}
	}
	public void TileDirt(){
		selectedSure = 26;
		if (PlayerPrefs.GetString ("Bought26") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileGrass(){
		selectedSure = 27;
		if (PlayerPrefs.GetString ("Bought27") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileMetal(){
		selectedSure = 28;
		if (PlayerPrefs.GetString ("Bought28") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileSand(){
		selectedSure = 29;
		if (PlayerPrefs.GetString ("Bought29") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileTundra(){
		selectedSure = 30;
		if (PlayerPrefs.GetString ("Bought30") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TileSnow(){
		selectedSure = 31;
		if (PlayerPrefs.GetString ("Bought31") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void TilePurple(){
		selectedSure = 32;
		if (PlayerPrefs.GetString ("Bought32") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectTile (selectedSure);
		}
	}
	public void BGCloud(){
		selectedSure = 34;
		if (PlayerPrefs.GetString ("Bought34") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectBG (selectedSure);
		}
	}
	public void BGCity(){
		selectedSure = 33;
		if (PlayerPrefs.GetString ("Bought33") != "yes") {
			theSurePanel.SetActive (true);
		}else{
			SelectBG (selectedSure);
	}
		
	}public void BGNight(){
		selectedSure = 35;
		/*if (PlayerPrefs.GetString ("Bought35") != "yes") {
			theSurePanel.SetActive (true);
		}else{*/
			SelectBG (selectedSure);
		//}
		
	}
	public void GoToMenu(){
		SceneManager.LoadScene ("MainMenu");
	}
	public void YesSureButton(){
		switch (selectedSure) {
		case 0:
			Select (0);
			break;
		case 1:
			if (PlayerPrefs.GetString ("Bought1") != "yes") {				
				BronzeBuy (50);			
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought1", "yes");
					FirstCharacter ();
					Select (1);
				}
			}			
			break;
		case 2:
			if (PlayerPrefs.GetString ("Bought2") != "yes") {				
				BronzeBuy (100);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought2", "yes");
					FirstCharacter ();
					Select (2);
				}
			}		
			break;
		case 3:
			if (PlayerPrefs.GetString ("Bought3") != "yes") {				
				BronzeBuy (150);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought3", "yes");
					FirstCharacter ();
					Select (3);
				}
			}
			break;
		case 4:
			if (PlayerPrefs.GetString ("Bought4") != "yes") {				
				BronzeBuy (100);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought4", "yes");
					FirstCharacter ();
					Select (4);
				}
			}

			break;
		case 5:
			if (PlayerPrefs.GetString ("Bought5") != "yes") {
				
				GoldBuy (100);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought5", "yes");
					FirstCharacter ();
					Select (5);
				}
			}

			break;
		case 6:
			if (PlayerPrefs.GetString ("Bought6") != "yes") {
				
				GoldBuy (200);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought6", "yes");
					FirstCharacter ();
					Select (6);
				}
			}

			break;
		case 7:
			if (PlayerPrefs.GetString ("Bought7") != "yes") {
				
				GoldBuy (400);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought7", "yes");
					FirstCharacter ();
					Select (7);
				}
			}

			break;
		case 8:
			if (PlayerPrefs.GetString ("Bought8") != "yes") {
				
				GoldBuy (300);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought8", "yes");
					FirstCharacter ();
					Select (8);
				}
			}

			break;
		case 10:
			if (PlayerPrefs.GetString ("Bought10") != "yes") {
				
				GoldBuy (100);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought10", "yes");
					FirstCharacter ();
					Select (10);
				}
			}
			break;
		case 11:
			if (PlayerPrefs.GetString ("Bought11") != "yes") {
				
				GoldBuy (200);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought11", "yes");
					FirstCharacter ();
					Select (11);
				}
			}
	
			break;
		case 12:
			if (PlayerPrefs.GetString ("Bought12") != "yes") {
				
				GoldBuy (250);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought12", "yes");
					FirstCharacter ();
					Select (12);
				}
			}
			break;
		case 13:
			if (PlayerPrefs.GetString ("Bought13") != "yes") {
				
				GoldBuy (300);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought13", "yes");
					FirstCharacter ();
					Select (13);
				}
			}
			break;
		case 14:
			if (PlayerPrefs.GetString ("Bought14") != "yes") {
				
				GoldBuy (500);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought14", "yes");
					FirstCharacter ();
					Select (14);
				}
			}

			break;
		case 15:
			if (PlayerPrefs.GetString ("Bought15") != "yes") {
				
				BronzeBuy (200);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought15", "yes");
					FirstCharacter ();
					Select (15);
				}
			}
			break;
		case 16:
			if (PlayerPrefs.GetString ("Bought16") != "yes") {
				
				BronzeBuy (300);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought16", "yes");
					FirstCharacter ();
					Select (16);
				}			
			}
			break;
		case 17:
			if (PlayerPrefs.GetString ("Bought17") != "yes") {
				
				BronzeBuy (500);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought17", "yes");
					FirstCharacter ();
					Select (17);
				}
			}
		
			break;
		case 18:
			if (PlayerPrefs.GetString ("Bought18") != "yes") {
				
				BronzeBuy (400);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought18", "yes");
					FirstCharacter ();
					Select (18);
				}
			}
			break;
			//TilesBegin
		case 20:
			if (PlayerPrefs.GetString ("Bought20") != "yes") {
				BronzeBuy (50);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought20", "yes");
					FirstTile ();
					SelectTile (20);
				}
			}
			break;
		case 21:
			if (PlayerPrefs.GetString ("Bought21") != "yes") {
				BronzeBuy (100);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought21", "yes");
					FirstTile ();
					SelectTile (21);
				}
			}
			break;
		case 22:
			if (PlayerPrefs.GetString ("Bought22") != "yes") {
				BronzeBuy (100);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought22", "yes");
					FirstTile ();
					SelectTile (22);
				}
			}
			break;
		case 23:
			if (PlayerPrefs.GetString ("Bought23") != "yes") {
				BronzeBuy (150);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought23", "yes");
					FirstTile ();
					SelectTile (23);
				}
			}
			break;
		case 24:
			if (PlayerPrefs.GetString ("Bought24") != "yes") {
				GoldBuy (20);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought24", "yes");
					FirstTile ();
					SelectTile (24);
				}
			}
			break;
		case 25:
			if (PlayerPrefs.GetString ("Bought25") != "yes") {
				BronzeBuy (2);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought25", "yes");
					SelectTile (25);
				}
			}
			break;
		case 26:
			if (PlayerPrefs.GetString ("Bought26") != "yes") {
				GoldBuy (20);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought26", "yes");
					FirstTile ();
					SelectTile (26);
				}
			}
			break;
		case 27:
			if (PlayerPrefs.GetString ("Bought27") != "yes") {
				GoldBuy (50);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought27", "yes");
					FirstTile ();
					SelectTile (27);
				}
			}
			break;
		case 28:
			if (PlayerPrefs.GetString ("Bought28") != "yes") {
				GoldBuy (75);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought28", "yes");
					FirstTile ();
					SelectTile (28);
				}
			}
			break;
		case 29:
			if (PlayerPrefs.GetString ("Bought29") != "yes") {
				BronzeBuy (100);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought29", "yes");
					FirstTile ();
					SelectTile (29);
				}
			}
			break;
		case 30:
			if (PlayerPrefs.GetString ("Bought30") != "yes") {
				BronzeBuy (125);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					FirstTile ();
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought30", "yes");
					SelectTile (30);
				}
			}
			break;
		case 31:
			if (PlayerPrefs.GetString ("Bought31") != "yes") {
				BronzeBuy (150);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought31", "yes");
					FirstTile ();
					SelectTile (31);
				}
			}
			break;
		case 32:
			if (PlayerPrefs.GetString ("Bought32") != "yes") {
				GoldBuy (50);		
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought32", "yes");
					FirstTile ();
					SelectTile (32);
				}
			}
			break;
		case 33:
			if (PlayerPrefs.GetString ("Bought33") != "yes") {
				GoldBuy (500);	
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought33", "yes");
					SelectBG (33);
					FirstBG ();
				}
			}
			break;
		case 34:
			if (PlayerPrefs.GetString ("Bought34") != "yes") {
				GoldBuy (500);
				if (PlayerPrefs.GetInt ("OKG") == 1) {
					PlayerPrefs.SetInt ("OKG", 0);
					PlayerPrefs.SetString ("Bought34", "yes");
					SelectBG (34);
					FirstBG ();
				}
			}
			break;
		case 35:
			if (PlayerPrefs.GetString ("Bought35") != "yes") {
				GoldBuy (500);
				if (PlayerPrefs.GetInt ("OKB") == 1) {
					PlayerPrefs.SetInt ("OKB", 0);
					PlayerPrefs.SetString ("Bought35", "yes");
					SelectBG (35);
				}
			}
			break;
		}
		theSurePanel.SetActive (false);
	}
	public void NoSureButton(){
		theSurePanel.SetActive (false);
	}
	private void GoldBuy(int gold){
		int myGold = PlayerPrefs.GetInt ("CoinGold");
		if (myGold >= gold) {
			myGold -= gold;
			PlayerPrefs.SetInt ("CoinGold", myGold);
			PlayerPrefs.SetInt ("OKG", 1);
		} else {
			PlayerPrefs.SetInt ("OKG", 0);
			theSurePanel.SetActive (false);
			theNotEnoughPanel.SetActive (true);
		}
	}
	private void BronzeBuy(int bronze){
		int myBronze = PlayerPrefs.GetInt ("CoinBronze");
		if (myBronze >= bronze) {
			myBronze -= bronze;
			PlayerPrefs.SetInt ("CoinBronze", myBronze);
			PlayerPrefs.SetInt ("OKB", 1);
		} else {
			PlayerPrefs.SetInt ("OKB", 0);
			theSurePanel.SetActive (false);
			theNotEnoughPanel.SetActive (true);
		}
	}
	private void Select (int s){
		boughtItemC [s] = "yes";
		PlayerPrefs.SetString ("CharacterOn","on");
		selected = s;
		PlayerPrefs.SetInt ("CharacterSelected",selected );
		selectedItemC = s;
		PlayerPrefs.SetInt ("selectedThickCharacter", selectedItemC);
		Debug.Log (selected);
	}
	private void SelectTile (int s){
		boughtItemT [s-20] = "yes";
		PlayerPrefs.SetString ("SelectedTile","on");
		selected = s-20;
		PlayerPrefs.SetInt ("selectedTile",selected );
		selectItemT = s-20;
		PlayerPrefs.SetInt ("selectedThickTile", selectItemT);
		Debug.Log (selected);
	}
	private void SelectBG (int s){
		s -= 33;
		//s = Mathf.Abs (s-35);

		boughtItemBG [s] = "yes";
		PlayerPrefs.SetString ("SelectedBG","on");
		selected = s;
		PlayerPrefs.SetInt ("selectedBG",selected );
		selectedItemBG = s;
		PlayerPrefs.SetInt ("selectedThickBG", selectedItemBG);
		Debug.Log (selected);
	}
	public void OKEnoughButton(){
		theSurePanel.SetActive (false);
		theNotEnoughPanel.SetActive (false);
		if (theCharacterPanel.activeInHierarchy == true) {
		}else if(theBGPanel.activeInHierarchy == true){
		}else if(theExtrasPanel.activeInHierarchy == true){
		} else {
			theExchange.SetActive (true);
		}
		//SceneManager.LoadScene ("Shop");
	}
	public void FirstTile(){
		Social.ReportProgress (	AchievementsJS.achievement_first_tile, 100.0f, (bool success) => {
		});
	}
	public void FirstBG(){
		Social.ReportProgress (	AchievementsJS.achievement_first_background, 100.0f, (bool success) => {
		});
	}
	public void FirstCharacter(){
		Social.ReportProgress (	AchievementsJS.achievement_first_character, 100.0f, (bool success) => {
		});
	}
	public void AllBGs(){
		if (PlayerPrefs.GetString ("Bought33") == "yes") {
			if (PlayerPrefs.GetString ("Bought34") == "yes") {
				if (PlayerPrefs.GetString ("Bought35") == "yes") {
					Social.ReportProgress (AchievementsJS.achievement_background_expert, 100.0f, (bool success) => {
					});
				} else {
					Social.ReportProgress (AchievementsJS.achievement_background_expert, 100.0f, (bool success) => {
					});
				}
			}
		}
	}
	public void AllTiles(){
		//if (PlayerPrefs.GetString ("Bought20") == "yes") {
			if (PlayerPrefs.GetString ("Bought21") == "yes") {
				if (PlayerPrefs.GetString ("Bought22") == "yes") {
					if (PlayerPrefs.GetString ("Bought23") == "yes") {
						if (PlayerPrefs.GetString ("Bought24") == "yes") {
							if (PlayerPrefs.GetString ("Bought25") == "yes") {
								if (PlayerPrefs.GetString ("Bought26") == "yes") {
									if (PlayerPrefs.GetString ("Bought27") == "yes") {
										if (PlayerPrefs.GetString ("Bought28") == "yes") {
											if (PlayerPrefs.GetString ("Bought29") == "yes") {
												if (PlayerPrefs.GetString ("Bought30") == "yes") {
													if (PlayerPrefs.GetString ("Bought31") == "yes") {
														if (PlayerPrefs.GetString ("Bought32") == "yes") {
															Social.ReportProgress (	AchievementsJS.achievement_tile_expert, 100.0f, (bool success) => {
															});
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		//}
	}
	public void AllCharacter(){
		if (PlayerPrefs.GetString ("Bought1") == "yes") {
			if (PlayerPrefs.GetString ("Bought2") == "yes") {
				if (PlayerPrefs.GetString ("Bought3") == "yes") {
					if (PlayerPrefs.GetString ("Bought4") == "yes") {
						if (PlayerPrefs.GetString ("Bought5") == "yes") {
							if (PlayerPrefs.GetString ("Bought6") == "yes") {
								if (PlayerPrefs.GetString ("Bought7") == "yes") {
									if (PlayerPrefs.GetString ("Bought8") == "yes") {
										if (PlayerPrefs.GetString ("Bought10") == "yes") {
											if (PlayerPrefs.GetString ("Bought1") == "yes") {
												if (PlayerPrefs.GetString ("Bought11") == "yes") {
													if (PlayerPrefs.GetString ("Bought12") == "yes") {
														if (PlayerPrefs.GetString ("Bought13") == "yes") {
															if (PlayerPrefs.GetString ("Bought14") == "yes") {
																if (PlayerPrefs.GetString ("Bought15") == "yes") {
																	if (PlayerPrefs.GetString ("Bought16") == "yes") {
																		if (PlayerPrefs.GetString ("Bought17") == "yes") {
																			if (PlayerPrefs.GetString ("Bought18") == "yes") {
																				if (PlayerPrefs.GetString ("Bought19") == "yes") {
																					Social.ReportProgress (AchievementsJS.achievement_character_expert, 100.0f, (bool success) => {
																					});
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
