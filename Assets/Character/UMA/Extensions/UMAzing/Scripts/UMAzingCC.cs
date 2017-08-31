using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UMA;

public class UMAzingCC : MonoBehaviour {
	
	[HideInInspector]
	public UMAData umaData;
	
	[HideInInspector]
	public UMADynamicAvatar umaDynamicAvatar;

	[HideInInspector]
	[System.Obsolete("Crowd slotLibrary is obsolete, please use the Crowd umaContext", false)]
	public SlotLibrary slotLibrary;
	[HideInInspector]
	[System.Obsolete("Crowd overlayLibrary is obsolete, please use the Crowd umaContext", false)]
	public OverlayLibrary overlayLibrary;
	[HideInInspector]
	[System.Obsolete("Crowd raceLibrary is obsolete, please use the Crowd umaContext", false)]
	public RaceLibrary raceLibrary;
	
	UMADnaHumanoid umaDna;
	
	[System.Serializable]
	public class SliderControl {
		public string name = "";
		public float value = 0.5f;
	}
	
	[System.Serializable]
	public class GlobalSettings {
		public int xPos = 100;
		public int yPos = 100;
		public int width = 600;
		public int padding = 10;
		public int spacing = 10;
	}
	
	[System.Serializable]
	public class GenderWindowSettings {
		public int height = 115;
		public int buttonHeight = 50;
	}
	
	[System.Serializable]
	public class TabWindowSettings {
		public int height = 50;
		public int buttonHeight = 20;
	}
	
	[System.Serializable]
	public class AttributeWindowSettings {
		public int height = 300;
	}
	
	[System.Serializable]
	public class FinishWindowSettings {
		public int height = 300;
	}
	
	[System.Serializable]
	public class SliderSettings {
		public int width = 300;
		[Range(0.0f, 0.5f)]
		public float minValue = 0.0f;
		[Range(0.5f, 1.0f)]
		public float maxValue = 1.0f;
	}
	
	// Set this in the inspector to the name of the scene you want to load after saving the character
	public string gameSceneName = "Game Scene";
	
	// Make sure to also create the same folder structure in your final build folder (or you will get an error and the character won't save.)
	public string savePath = "Assets/Character Saves";
	public bool allowRemoveUnderwear = false;

	public UMARecipeBase[] additionalRecipes;
	
	SliderControl[] sliderControlArray;

	public UMAContext umaContext;
	public RuntimeAnimatorController animationController;
	public UMAGenerator generator;
	public float atlasResolutionScale;
	private Transform tempUMA;

	public UMADataEvent CharacterCreated;
	public UMADataEvent CharacterDestroyed;
	public UMADataEvent CharacterUpdated;
	
	
	GameObject orbitCamera;
	GameObject cameraTarget;
	float cameraDistance;
	float cameraHeadDistance;
	float cameraBodyDistance;
	
	GameObject maleAvatarSpawn;
	GameObject maleAvatar;
	Transform maleAvatarHead;
	Transform maleAvatarBody;
	GameObject femaleAvatarSpawn;
	GameObject femaleAvatar;
	Transform femaleAvatarHead;
	Transform femaleAvatarBody;
	
	public GlobalSettings settings;
	public GenderWindowSettings genderWindowSettings;
	public TabWindowSettings tabWindowSettings;
	public AttributeWindowSettings attributeWindowSettings;
	public AttributeWindowSettings finishWindowSettings;
	public SliderSettings sliderSettings;
	
	public GUISkin guiSkin;
	public GUIStyle windowStyle;
	public GUIStyle headerlessWindowStyle;
	public GUIStyle verticalLayoutStyle;
	public GUIStyle horizontalLayoutStyle;
	public GUIStyle tabStyle;
	public GUIStyle buttonStyle;
	public GUIStyle sliderLayoutStyle;
	public GUIStyle labelStyle;
	public GUIStyle sliderValueStyle;
	public GUIStyle bottomBarStyle;
	public GUIStyle bottomBarLabelStyle;
	public GUIStyle bottomBarButtonStyle;
	
	bool hasCreatedMale = false;
	bool hasCreatedFemale = false;
	bool hasSelectedHead = false;
	string selectedGender = "";
	string selectedTab = "Basic";
	Rect attributeWindowRect;
	string characterName = "";
	Vector2 scrollPosition;
	
	public List<Color> eyeColors;
	public List<Color> hairColors;
	public List<Color> skinTones;
	public List<Color> shirtColors;
	public List<Color> pantsColors;
	public List<Color> underwearColors;
	public List<Color> lipstickColors;
	
	public List<string> lipstickTextures;
	public List<string> EyeballTextures;
	public List<string> EyeballTexturesAdjust;
	
	// Male-specific
	public List<string> maleEyeballs;
	public List<string> maleEyesockets;
	public List<string> maleEars;
	public List<string> maleNoses;
	public List<string> maleMouths;
	public List<string> maleBodyMeshes;
	public List<string> maleHands;
	public List<string> maleLegs;
	public List<string> maleFeet;
	
	public List<string> maleHeadMeshes;
	public List<string> maleHeadTextures;
	public List<string> maleHairStyles;
	public List<string> maleBeardStyles;
	public List<string> maleEyebrows;
	public List<string> maleBodies;
	
	public List<string> maleShirts;
	public List<string> malePants;
	public List<string> maleUnderwear;
	
	// Female-specific
	public List<string> femaleEyeballs;
	public List<string> femaleEyesockets;
	public List<string> femaleEars;
	public List<string> femaleNoses;
	public List<string> femaleMouths;
	public List<string> femaleBodyMeshes;
	public List<string> femaleHands;
	public List<string> femaleLegs;
	public List<string> femaleFeet;
	
	public List<string> femaleHeadMeshes;
	public List<string> femaleHeadTextures;
	public List<string> femaleHairStyles;
	public List<string> femaleEyebrows;
	public List<string> femaleBodies;
	
	public List<string> femaleShirts;
	public List<string> femalePants;
	public List<string> femaleUnderwear;
	
	// Male
	UMADnaHumanoid savedMaleUmaDna;
	
	int selectedMaleEyeballs = 0;
	int selectedMaleEyeballTexture = 0;
	int selectedMaleEyeballTextureAdjust = 0;
	int selectedMaleEyesockets = 0;
	int selectedMaleEars = 0;
	int selectedMaleNose = 0;
	int selectedMaleMouth = 0;
	int selectedMaleBodyMesh = 0;
	int selectedMaleHands = 0;
	int selectedMaleLegs = 0;
	int selectedMaleFeet = 0;
	
	int selectedMaleEyeColor = 0;
	int selectedMaleHeadMesh = 0;
	int selectedMaleHeadTexture = 0;
	int selectedMaleHairColor = 0;
	int selectedMaleHairStyle = 0;
	int selectedMaleBeardStyle = 0;
	int selectedMaleEyebrow = 0;
	int selectedMaleBody = 0;
	int selectedMaleSkinTone = 0;
	
	int selectedMaleShirt = 0;
	int selectedMaleShirtColor = 0;
	
	int selectedMalePants = 0;
	int selectedMalePantsColor = 0;
	
	int selectedMaleUnderwear = 1;
	int selectedMaleUnderwearColor = 0;
	
	// Female
    UMADnaHumanoid savedFemaleUmaDna;
	
	int selectedFemaleEyeballs = 0;
	int selectedFemaleEyeballTexture = 0;
	int selectedFemaleEyeballTextureAdjust = 0;
	int selectedFemaleEyesockets = 0;
	int selectedFemaleEars = 0;
	int selectedFemaleNose = 0;
	int selectedFemaleMouth = 0;
	int selectedFemaleBodyMesh = 0;
	int selectedFemaleLipstickTexture = 0;
	int selectedFemaleHands = 0;
	int selectedFemaleLegs = 0;
	int selectedFemaleFeet = 0;
	
	int selectedFemaleEyeColor = 0;
	int selectedFemaleHeadMesh = 0;
	int selectedFemaleHeadTexture = 0;
	int selectedFemaleLipstickColor = 0;
	int selectedFemaleHairColor = 0;
	int selectedFemaleHairStyle = 0;
	int selectedFemaleEyebrow = 0;
	int selectedFemaleBody = 0;
	int selectedFemaleSkinTone = 0;
	
	int selectedFemaleShirt = 0;
	int selectedFemaleShirtColor = 0;
	
	int selectedFemalePants = 0;
	int selectedFemalePantsColor = 0;
	
	int selectedFemaleUnderwear = 1;
	int selectedFemaleUnderwearColor = 0;
	
	void Start () {
		if (!allowRemoveUnderwear) {
			maleUnderwear.Remove("");
			femaleUnderwear.Remove("");
			
			selectedMaleUnderwear = 0;
			selectedFemaleUnderwear = 0;
		}

		if (generator == null) {Debug.LogError("UMA Generator is missing in UMAzing>Character Creator! please link it up to UMA>UMAGenerator");}
		if (umaContext == null) {Debug.LogError("UMA Context is missing in UMAzing>Character Creator! please link it up to UMA>UMAContext");}
		if (savePath == "") {Debug.LogError("You have no save path set in UMAzing>Character Creator and won't be able to save your characters.");}
		if (gameSceneName == "") {Debug.LogError("Game Scene Name is not set in UMAzing>Character Creator. The character creator will fail to load the game level.");}
		
		orbitCamera = GameObject.Find("Orbit Camera");
		cameraTarget = GameObject.Find("Camera Target");
		
		cameraHeadDistance = orbitCamera.GetComponent<CameraController>().headDistance;
		cameraBodyDistance = orbitCamera.GetComponent<CameraController>().bodyDistance;
		
		// Set the names of each slider control
		string[] nameArray = new string[] {
			// Basic
			"Height",
			"Head Size",
			"Head Width",
			
			// Body
			"Neck Thickness",
			"Upper Muscle",
			"Lower Muscle",
			
			"Breast Size",
			"Upper Weight",
			"Lower Weight",
			
			"Legs Size",
			"Belly",
			"Waist",
			
			"Gluteus Size",
			"Arm Length",
			"Arm Width",
			
			"Forearm Length",
			"Forearm Width",
			"Hands Size",
			
			"Leg Separation",
			"Feet Size",
			
			// Head
			"Forehead Size",
			"Forehead Position",
			"Nose Size",
			
			"Eye Size",
			"Lips Size",
			"Mouth Size",
			
			"Nose Curve",
			"Nose Width",
			"Nose Inclination",
			
			"Nose Position",
			"Nose Size",
			"Nose Flatten",
			
			"Chin Size",
			"Chin Out",
			"Chin Position",
			
			"Mandible Size",
			"Jaws Size",
			"Jaws Position",
			
			"Cheek Size",
			"Cheek Position",
			"Low Cheek Out",
			
			"Ears Size",
			"Ears Position",
			"Ears Rotation",
			
			"Low Cheek Position",
			"Eye Rotation"
		};
		
		sliderControlArray = new SliderControl[46];
		
		for(int i = 0; i < sliderControlArray.Length; i++){
			sliderControlArray[i] = new SliderControl();
			sliderControlArray[i].name = nameArray[i];
		}
		
		StartCoroutine(UpdateGuiDimensions());
		
	}
	
	void Update () {
		
		
		// We need to have the characters enabled (but out of sight) until we can get the body and head nodes for the camera target
		if (maleAvatarHead == null) {
			
			if (GameObject.Find("Male") != null) {
				maleAvatar = GameObject.Find("Male");
				if (maleAvatar != null){
					if (maleAvatar.FindInChildren("HeadAdjust") != null)
						maleAvatarHead = maleAvatar.FindInChildren("HeadAdjust").transform;
					if (maleAvatar.FindInChildren("SpineAdjust") != null)
						maleAvatarBody = maleAvatar.FindInChildren("SpineAdjust").transform;
				}
			}
		}

		
		// Do the same thing for the female
		if (femaleAvatarHead == null) {
			if (GameObject.Find("Female") != null) {
				femaleAvatar = GameObject.Find("Female");
				if (femaleAvatar != null){
					if (femaleAvatar.FindInChildren("HeadAdjust") != null)
						femaleAvatarHead = femaleAvatar.FindInChildren("HeadAdjust").transform;
					if (femaleAvatar.FindInChildren("SpineAdjust") != null)
						femaleAvatarBody = femaleAvatar.FindInChildren("SpineAdjust").transform;
				}
			}
		}
		
		
		MoveCamTarget(); 	// Make the camera target follow the character
		ZoomCamera(); 		// Make the camera zoom in on the face when needed
		
		UpdateAttributes(); // Send and retrieve the changes to the character
	}
	
	// Layout the GUI
	void OnGUI () {
		GUI.skin = guiSkin;
		
		GUILayout.BeginVertical();
		GUILayout.Window (0, new Rect(settings.xPos, settings.yPos, settings.width, genderWindowSettings.height), GenderWindowContents, "Choose Gender", windowStyle);
		
		if (selectedGender != "") {
			// Tab window
			GUILayout.Window (1, new Rect(settings.xPos, settings.yPos + genderWindowSettings.height + settings.spacing, settings.width, tabWindowSettings.height), TabWindowContents, "", headerlessWindowStyle);
			
			// Attribute windows
			attributeWindowRect = new Rect(settings.xPos, settings.yPos + genderWindowSettings.height + tabWindowSettings.height + (settings.spacing * 2), settings.width, attributeWindowSettings.height );
			if (selectedTab == "Basic") {
				GUILayout.Window (2, attributeWindowRect, BasicWindowContents, "Basic", windowStyle, GUILayout.ExpandHeight(true));
				hasSelectedHead = false;
			} else if (selectedTab == "Body") {
				GUILayout.Window (3, attributeWindowRect, BodyWindowContents, "Body", windowStyle, GUILayout.ExpandHeight(true));
				hasSelectedHead = false;
			} else if (selectedTab == "Face") {
				GUILayout.Window (4, attributeWindowRect, FaceWindowContents, "Face", windowStyle, GUILayout.ExpandHeight(true));
				hasSelectedHead = true;
			}
			
			// Finish window
			GUILayout.Window (5, new Rect(0, Screen.height - 120, Screen.width, 120), FinishWindowContents, "", bottomBarStyle);
		}
		GUILayout.EndVertical();
	}
	
	void GenderWindowContents (int windowID) {
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Male", buttonStyle, GUILayout.Height(genderWindowSettings.buttonHeight))) {
			SelectGender("Male");
		}
		if (GUILayout.Button("Female", buttonStyle, GUILayout.Height(genderWindowSettings.buttonHeight))) {
			SelectGender("Female");
		}
		GUILayout.EndHorizontal();
	}
	
	void TabWindowContents (int windowID) {
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("Basic", tabStyle, GUILayout.Height(tabWindowSettings.buttonHeight))) {
			selectedTab = "Basic";
		} else if (GUILayout.Button("Body", tabStyle, GUILayout.Height(tabWindowSettings.buttonHeight))) {
			selectedTab = "Body";
		} else if (GUILayout.Button("Face", tabStyle, GUILayout.Height(tabWindowSettings.buttonHeight))) {
			selectedTab = "Face";
		}
		GUILayout.EndHorizontal();
	}
	
	void BasicWindowContents (int windowID) {
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (settings.width - 10.0f), GUILayout.Height (attributeWindowSettings.height - 70.0f));
		GUILayout.BeginVertical(verticalLayoutStyle);
		
		if (GUILayout.Button("New all", tabStyle)) {
			RandomizeAll();
		}
		
		GUILayout.BeginHorizontal();
		if (GUILayout.Button("New body", tabStyle)) {
			RandomizeBody();
		}
		
		if (GUILayout.Button("New head", tabStyle)) {
			RandomizeHead();
		}
		
		if (GUILayout.Button("New shape", tabStyle)) {
			if (!umaData.isTextureDirty) GenerateOneUMA(true);
		}
		GUILayout.EndHorizontal();
		
		
		CreateSliderRow(new int[] {0, 1, 2});
		GUILayout.EndVertical();
		GUILayout.EndScrollView ();
	}
	
	void BodyWindowContents (int windowID) {
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (settings.width - 10.0f), GUILayout.Height (attributeWindowSettings.height - 70.0f));
		GUILayout.BeginVertical(verticalLayoutStyle);
		
		// Male Body
		if (selectedGender == "male" && maleBodyMeshes.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("body");}
			
			GUILayout.Label ("Body: " + (selectedMaleBodyMesh+1) + "/" + maleBodyMeshes.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("body");}
			GUILayout.EndHorizontal();
		}
		
		// Female Body
		if (selectedGender == "female" && femaleBodyMeshes.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("body");}
			
			GUILayout.Label ("Body: " + (selectedFemaleBodyMesh+1) + "/" + femaleBodyMeshes.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("body");}
			GUILayout.EndHorizontal();
		}
		
		// Male skin types
		if (selectedGender == "male" && maleBodies.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("skintype");}
			
			GUILayout.Label ("Skin type: " + (selectedMaleBody+1) + "/" + maleBodies.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("skintype");}
			GUILayout.EndHorizontal();
		}
		
		// Female skin types
		if (selectedGender == "female" && femaleBodies.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("skintype");}
			
			GUILayout.Label ("Skin type: " + (selectedFemaleBody+1) + "/" + femaleBodies.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("skintype");}
			GUILayout.EndHorizontal();
		}
		
		// Skin Tones
		if (skinTones.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("skincolor");}
			
			if (selectedGender == "male") {GUILayout.Label ("Skin tone: " + (selectedMaleSkinTone+1) + "/" + skinTones.Count, labelStyle);}
			else {GUILayout.Label ("Skin tone: " + (selectedFemaleSkinTone+1) + "/" + skinTones.Count, labelStyle);}
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("skincolor");}
			GUILayout.EndHorizontal();
		}
		
		// Male Hands
		if (selectedGender == "male" && maleHands.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("hands");}
			
			GUILayout.Label ("Hands: " + (selectedMaleHands+1) + "/" + maleHands.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("hands");}
			GUILayout.EndHorizontal();
		}
		
		// Female Hands
		if (selectedGender == "female" && femaleHands.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("hands");}
			
			GUILayout.Label ("Hands: " + (selectedFemaleHands+1) + "/" + femaleHands.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("hands");}
			GUILayout.EndHorizontal();
		}
		
		// Male Legs
		if (selectedGender == "male" && maleLegs.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("legs");}
			
			GUILayout.Label ("Legs: " + (selectedMaleLegs+1) + "/" + maleLegs.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("legs");}
			GUILayout.EndHorizontal();
		}
		
		// Female Legs
		if (selectedGender == "female" && femaleLegs.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("legs");}
			
			GUILayout.Label ("Legs: " + (selectedFemaleLegs+1) + "/" + femaleLegs.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("legs");}
			GUILayout.EndHorizontal();
		}
		
		// Male Feet
		if (selectedGender == "male" && maleFeet.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("legs");}
			
			GUILayout.Label ("Feet: " + (selectedMaleFeet+1) + "/" + maleFeet.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("legs");}
			GUILayout.EndHorizontal();
		}
		
		// Female Feet
		if (selectedGender == "female" && femaleFeet.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("feet");}
			
			GUILayout.Label ("Feet: " + (selectedFemaleFeet+1) + "/" + femaleFeet.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("feet");}
			GUILayout.EndHorizontal();
		}
		
		// Male Shirts
		if (selectedGender == "male" && maleShirts.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("upper");}
			
			GUILayout.Label ("Upper clothing: " + (selectedMaleShirt+1) + "/" + maleShirts.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("upper");}
			GUILayout.EndHorizontal();
		}
		
		// Female Shirts
		if (selectedGender == "female" && femaleShirts.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("upper");}
			
			GUILayout.Label ("Upper clothing: " + (selectedFemaleShirt+1) + "/" + femaleShirts.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("upper");}
			GUILayout.EndHorizontal();
		}
		
		// Shirt Colors
		if (shirtColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("uppercolor");}
			
			if (selectedGender == "male") {GUILayout.Label ("Upper clothing color: " + (selectedMaleShirtColor+1) + "/" + shirtColors.Count, labelStyle);}
			else {GUILayout.Label ("Upper clothing color: " + (selectedFemaleShirtColor+1) + "/" + shirtColors.Count, labelStyle);}
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("uppercolor");}
			GUILayout.EndHorizontal();
		}
		
		// Male Pants
		if (selectedGender == "male" && malePants.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("lower");}
			
			GUILayout.Label ("Lower clothing: " + (selectedMalePants+1) + "/" + malePants.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("lower");}
			GUILayout.EndHorizontal();
		}
		
		// Female Pants
		if (selectedGender == "female" && femalePants.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("lower");}
			
			GUILayout.Label ("Lower clothing: " + (selectedFemalePants+1) + "/" + femalePants.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("lower");}
			GUILayout.EndHorizontal();
		}
		
		// Pants colors
		if (pantsColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("lowercolor");}
			
			if (selectedGender == "male") {GUILayout.Label ("Lower clothing color: " + (selectedMalePantsColor+1) + "/" + pantsColors.Count, labelStyle);}
			else {GUILayout.Label ("Lower clothing color: " + (selectedFemalePantsColor+1) + "/" + pantsColors.Count, labelStyle);}
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("lowercolor");}
			GUILayout.EndHorizontal();
		}
		
		// Male Underwear
		if (selectedGender == "male" && maleUnderwear.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("underwear");}
			
			GUILayout.Label ("Underwear: " + (selectedMaleUnderwear+1) + "/" + maleUnderwear.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("underwear");}
			GUILayout.EndHorizontal();
		}
		
		// Female Underwear
		if (selectedGender == "female" && femaleUnderwear.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("underwear");}
			
			GUILayout.Label ("Underwear: " + (selectedFemaleUnderwear+1) + "/" + femaleUnderwear.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("underwear");}
			GUILayout.EndHorizontal();
		}
		
		// Underwear colors
		if (underwearColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("underwearcolor");}
			
			if (selectedGender == "male") {GUILayout.Label ("Underwear color: " + (selectedMaleUnderwearColor+1) + "/" + underwearColors.Count, labelStyle);}
			else {GUILayout.Label ("Underwear color: " + (selectedFemaleUnderwearColor+1) + "/" + underwearColors.Count, labelStyle);}
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("underwearcolor");}
			GUILayout.EndHorizontal();
		}
		
		CreateSliderRow(new int[] {3, 4, 5}); 
		CreateSliderRow(new int[] {6, 7, 8});
		CreateSliderRow(new int[] {9, 10, 11});
		CreateSliderRow(new int[] {12, 13, 14});
		CreateSliderRow(new int[] {15, 16, 17});
		CreateSliderRow(new int[] {18, 19});
		GUILayout.EndVertical();
		GUILayout.EndScrollView ();
	}
	
	void FaceWindowContents (int windowID) {
		scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (settings.width - 10.0f), GUILayout.Height (attributeWindowSettings.height - 70.0f));
		GUILayout.BeginVertical(verticalLayoutStyle);
		
		// Male Head Meshes
		if (selectedGender == "male" && maleHeadMeshes.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("headmesh");}
			
			GUILayout.Label ("Head: " + (selectedMaleHeadMesh+1) + "/" + maleHeadMeshes.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("headmesh");}
			GUILayout.EndHorizontal();
		}
		
		// Female Head Meshes
		if (selectedGender == "female" && femaleHeadMeshes.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("headmesh");}
			
			GUILayout.Label ("Head: " + (selectedFemaleHeadMesh+1) + "/" + femaleHeadMeshes.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("headmesh");}
			GUILayout.EndHorizontal();
		}
		
		// Male Head Textures
		if (selectedGender == "male" && maleHeadTextures.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("headtexture");}
			
			GUILayout.Label ("Face: " + (selectedMaleHeadTexture+1) + "/" + maleHeadTextures.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("headtexture");}
			GUILayout.EndHorizontal();
		}
		
		// Female Head Textures
		if (selectedGender == "female" && femaleHeadTextures.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("headtexture");}
			
			GUILayout.Label ("Face: " + (selectedFemaleHeadTexture+1) + "/" + femaleHeadTextures.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("headtexture");}
			GUILayout.EndHorizontal();
		}
		
		// Male Eye sockets
		if (selectedGender == "male" && maleEyesockets.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("eyesockets");}
			
			GUILayout.Label ("Eyes: " + (selectedMaleEyesockets+1) + "/" + maleEyesockets.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("eyesockets");}
			GUILayout.EndHorizontal();
		}
		
		// Female Eye sockets
		if (selectedGender == "female" && femaleEyesockets.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("eyesockets");}
			
			GUILayout.Label ("Eyes: " + (selectedFemaleEyesockets+1) + "/" + femaleEyesockets.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("eyesockets");}
			GUILayout.EndHorizontal();
		}
		
		// Male Ears
		if (selectedGender == "male" && maleEars.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("ears");}
			
			GUILayout.Label ("Ears: " + (selectedMaleEars+1) + "/" + maleEars.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("ears");}
			GUILayout.EndHorizontal();
		}
		
		// Female Ears
		if (selectedGender == "female" && femaleEars.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("ears");}
			
			GUILayout.Label ("Ears: " + (selectedFemaleEars+1) + "/" + femaleEars.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("ears");}
			GUILayout.EndHorizontal();
		}
		
		// Male Noses
		if (selectedGender == "male" && maleNoses.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("nose");}
			
			GUILayout.Label ("Nose: " + (selectedMaleNose+1) + "/" + maleNoses.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("nose");}
			GUILayout.EndHorizontal();
		}
		
		// Female Noses
		if (selectedGender == "female" && femaleNoses.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("nose");}
			
			GUILayout.Label ("Nose: " + (selectedFemaleNose+1) + "/" + femaleNoses.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("nose");}
			GUILayout.EndHorizontal();
		}
		
		// Male Mouths
		if (selectedGender == "male" && maleMouths.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("mouth");}
			
			GUILayout.Label ("Mouth: " + (selectedMaleMouth+1) + "/" + maleMouths.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("mouth");}
			GUILayout.EndHorizontal();
		}
		
		// Female Mouths
		if (selectedGender == "female" && femaleMouths.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("mouth");}
			
			GUILayout.Label ("Mouth: " + (selectedFemaleMouth+1) + "/" + femaleMouths.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("mouth");}
			GUILayout.EndHorizontal();
		}
		
		// Male eyebrows
		if (selectedGender == "male" && maleEyebrows.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("eyebrows");}
			
			GUILayout.Label ("Eyebrows: " + (selectedMaleEyebrow+1) + "/" + maleEyebrows.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("eyebrows");}
			GUILayout.EndHorizontal();
		}
		
		// Female eyebrows
		if (selectedGender == "female" && femaleEyebrows.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("eyebrows");}
			
			GUILayout.Label ("Eyebrows: " + (selectedFemaleEyebrow+1) + "/" + femaleEyebrows.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("eyebrows");}
			GUILayout.EndHorizontal();
		}
		
		// Male Hairstyles
		if (selectedGender == "male" && maleHairStyles.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("hairstyle");}
			
			GUILayout.Label ("Hairstyle: " + (selectedMaleHairStyle+1) + "/" + maleHairStyles.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("hairstyle");}
			GUILayout.EndHorizontal();
		}
		
		// Female Hairstyles
		if (selectedGender == "female" && femaleHairStyles.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("hairstyle");}
			
			GUILayout.Label ("Hairstyle: " + (selectedFemaleHairStyle+1) + "/" + femaleHairStyles.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("hairstyle");}
			GUILayout.EndHorizontal();
		}
		
		// Beard Styles
		if (selectedGender == "male" && maleBeardStyles.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("beardstyle");}
			
			GUILayout.Label ("Beardstyle: " + (selectedMaleBeardStyle+1) + "/" + maleBeardStyles.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("beardstyle");}
			GUILayout.EndHorizontal();
		} 
		
		// Male hair color
		if (selectedGender == "male" && hairColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("haircolor");}
			
			GUILayout.Label ("Hair color: " + (selectedMaleHairColor+1) + "/" + hairColors.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("haircolor");}
			GUILayout.EndHorizontal();
		}
		
		// Female hair color
		if (selectedGender == "female" && hairColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("haircolor");}
			
			GUILayout.Label ("Hair color: " + (selectedFemaleHairColor+1) + "/" + hairColors.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("haircolor");}
			GUILayout.EndHorizontal();
		}
		
		// Lipstick Colors
		if (selectedGender == "female" && lipstickColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("lipstick");}
			
			GUILayout.Label ("Lipstick Color: " + (selectedFemaleLipstickColor+1) + "/" + lipstickColors.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("lipstick");}
			GUILayout.EndHorizontal();
		}
		
		// Male eye color
		if (selectedGender == "male" && eyeColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("eyes");}
			
			GUILayout.Label ("Eye color: " + (selectedMaleEyeColor+1) + "/" + eyeColors.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("eyes");}
			GUILayout.EndHorizontal();
		}
		
		// Female eye color
		if (selectedGender == "female" && eyeColors.Count > 1) {
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("<", tabStyle)) {CycleToPrev("eyes");}
			
			GUILayout.Label ("Eye color: " + (selectedFemaleEyeColor+1) + "/" + eyeColors.Count, labelStyle);
			
			if (GUILayout.Button(">", tabStyle)) {CycleToNext("eyes");}
			GUILayout.EndHorizontal();
		}
		
		
		CreateSliderRow(new int[] {20, 21, 22});
		CreateSliderRow(new int[] {23, 24, 25});
		CreateSliderRow(new int[] {26, 27, 28});
		CreateSliderRow(new int[] {29, 30, 31});
		CreateSliderRow(new int[] {32, 33, 34});
		CreateSliderRow(new int[] {35, 36, 37});
		CreateSliderRow(new int[] {38, 39, 40});
		CreateSliderRow(new int[] {41, 42, 43});
		CreateSliderRow(new int[] {44, 45});
		GUILayout.EndVertical();
		GUILayout.EndScrollView ();
	}
	
	void FinishWindowContents (int windowID) {
		
		GUILayout.BeginHorizontal(horizontalLayoutStyle);
		
		GUILayout.BeginVertical(verticalLayoutStyle);
		GUILayout.Label ("Name", bottomBarLabelStyle);
		characterName = GUILayout.TextField(characterName);
		GUILayout.EndVertical();
		
		GUILayout.BeginVertical(verticalLayoutStyle);
		
		if (characterName.Length == 0) {
			GUI.enabled = false;
		}
		
		if (GUILayout.Button("Done", bottomBarButtonStyle)) {
			
			// Save the character, fade out the camera and load up the game scene
			GameObject avatarGO;
			
			if (selectedGender == "male") {
				avatarGO = maleAvatarSpawn;
			} else {
				avatarGO = femaleAvatarSpawn;
			}
			
			var avatar = avatarGO.GetComponent<UMAAvatarBase>();
			if( avatar != null )
			{
				string finalPath = savePath + "/" + characterName + ".txt";
				if (finalPath.Length != 0)
				{
					PersistentNameHolder.characterName = characterName;
					
					var asset = ScriptableObject.CreateInstance<UMATextRecipe>();
					asset.Save(avatar.umaData.umaRecipe, avatar.context);
					
					System.IO.File.WriteAllText(finalPath, asset.recipeString);
					ScriptableObject.Destroy(asset);
					
					// If the camera has a fader, make it fade out and load the game scene, otherwise just load the scene ourselves
					if (orbitCamera.GetComponent<CameraFader>() != null) {
						orbitCamera.GetComponent<CameraFader>().fadeOutAndLoadScene(gameSceneName);
					} else {
						Application.LoadLevel(gameSceneName);
					}
				}
			}
		}
		
		if (characterName.Length == 0) {
			GUI.enabled = true;
		}
		
		GUILayout.EndVertical();
		GUILayout.EndVertical();
	}
	
    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="gender"></param>
	void SelectGender (string gender) {
		if (gender == "Male") {
			if (selectedGender == "female" || selectedGender == "") {
				selectedGender = "male";
				hasSelectedHead = false;
				selectedTab = "Basic";
				
				// Make the camtarget re-evaluate what the head and body node is
				maleAvatarHead = null;
				maleAvatarBody = null;
				
				// If it's the first time we select gender, create one of that gender, otherwise just hide and show them
				if (hasCreatedFemale) {femaleAvatarSpawn.SetActive(false);}
				if (!hasCreatedMale) {
					GenerateOneUMA();
					hasCreatedMale = true;
				}
				else {
					maleAvatarSpawn.SetActive(true);
				}
			}
		} else {
			if (selectedGender == "male" || selectedGender == "") {
				selectedGender = "female";
				hasSelectedHead = false;
				selectedTab = "Basic";
				
				femaleAvatarHead = null;
				femaleAvatarBody = null;
				
				if (hasCreatedMale) {maleAvatarSpawn.SetActive(false);}
				if (!hasCreatedFemale) {
					GenerateOneUMA();
					hasCreatedFemale = true;
				}
				else {
					femaleAvatarSpawn.SetActive(true);
				}
			}
		}
	}
	
	void RandomizeAll () {
		if (!umaData.isTextureDirty) {
			if(selectedGender == "male") {
				selectedMaleSkinTone = Random.Range(0,skinTones.Count);
				selectedMaleShirtColor = Random.Range(0,shirtColors.Count);
				selectedMalePantsColor = Random.Range(0,pantsColors.Count);
				selectedMaleUnderwearColor = Random.Range(0,underwearColors.Count);
				selectedMaleBody = Random.Range(0,maleBodies.Count);
				selectedMaleShirt = Random.Range(0,maleShirts.Count);
				selectedMalePants = Random.Range(0,malePants.Count);
				selectedMaleUnderwear = Random.Range(0,maleUnderwear.Count);
				
				selectedMaleEyeColor = Random.Range(0,eyeColors.Count);
				selectedMaleHairColor = Random.Range(0,hairColors.Count);
				selectedMaleHeadMesh = Random.Range(0,maleHeadMeshes.Count);
				selectedMaleHeadTexture = Random.Range(0,maleHeadTextures.Count);
				selectedMaleHairStyle = Random.Range(0,maleHairStyles.Count);
				selectedMaleBeardStyle = Random.Range(0,maleBeardStyles.Count);
				selectedMaleEyebrow = Random.Range(0,maleEyebrows.Count);
				
				// Since most games won't need players to be able to choose between eye textures, no need to randomize those either.
				// selectedMaleEyeballs = Random.Range(0,maleEyeballs.Count);
				// selectedMaleEyeballTexture = Random.Range(0,EyeballTextures.Count);
				// selectedMaleEyeballTextureAdjust = Random.Range(0,EyeballTexturesAdjust.Count);
				selectedMaleEyesockets = Random.Range(0,maleEyesockets.Count);
				selectedMaleEars = Random.Range(0,maleEars.Count);
				selectedMaleNose = Random.Range(0,maleNoses.Count);
				selectedMaleMouth = Random.Range(0,maleMouths.Count);
				
				selectedMaleBodyMesh = Random.Range(0,maleBodyMeshes.Count);
				selectedMaleHands = Random.Range(0,maleHands.Count);
				selectedMaleLegs = Random.Range(0,maleLegs.Count);
				selectedMaleFeet = Random.Range(0,maleFeet.Count);
			}
			else {
				selectedFemaleSkinTone = Random.Range(0,skinTones.Count);
				selectedFemaleShirtColor = Random.Range(0,shirtColors.Count);
				selectedFemalePantsColor = Random.Range(0,pantsColors.Count);
				selectedFemaleUnderwearColor = Random.Range(0,underwearColors.Count);
				selectedFemaleBody = Random.Range(0,femaleBodies.Count);
				selectedFemaleShirt = Random.Range(0,femaleShirts.Count);
				selectedFemalePants = Random.Range(0,femalePants.Count);
				selectedFemaleUnderwear = Random.Range(0,femaleUnderwear.Count);
				
				selectedFemaleEyeColor = Random.Range(0,eyeColors.Count);
				selectedFemaleHairColor = Random.Range(0,hairColors.Count);
				selectedFemaleLipstickColor = Random.Range(0,lipstickColors.Count);
				selectedFemaleHeadMesh = Random.Range(0,femaleHeadMeshes.Count);
				selectedFemaleHeadTexture = Random.Range(0,femaleHeadTextures.Count);
				selectedFemaleHairStyle = Random.Range(0,femaleHairStyles.Count);
				selectedFemaleEyebrow = Random.Range(0,femaleEyebrows.Count);
				
				// selectedFemaleEyeballs = Random.Range(0,femaleEyeballs.Count);
				// selectedFemaleEyeballTexture = Random.Range(0,EyeballTextures.Count);
				// selectedFemaleEyeballTextureAdjust = Random.Range(0,EyeballTexturesAdjust.Count);
				selectedFemaleEyesockets = Random.Range(0,femaleEyesockets.Count);
				selectedFemaleEars = Random.Range(0,femaleEars.Count);
				selectedFemaleNose = Random.Range(0,femaleNoses.Count);
				selectedFemaleMouth = Random.Range(0,femaleMouths.Count);
				
				selectedFemaleBodyMesh = Random.Range(0,femaleBodyMeshes.Count);
				selectedFemaleHands = Random.Range(0,femaleHands.Count);
				selectedFemaleLegs = Random.Range(0,femaleLegs.Count);
				selectedFemaleFeet = Random.Range(0,femaleFeet.Count);
			}
			
			GenerateOneUMA(true);
		}
	}
	
	void RandomizeBody () {
		if (!umaData.isTextureDirty) {
			if(selectedGender == "male") {
				selectedMaleSkinTone = Random.Range(0,skinTones.Count);
				selectedMaleShirtColor = Random.Range(0,shirtColors.Count);
				selectedMalePantsColor = Random.Range(0,pantsColors.Count);
				selectedMaleUnderwearColor = Random.Range(0,underwearColors.Count);
				selectedMaleBody = Random.Range(0,maleBodies.Count);
				selectedMaleShirt = Random.Range(0,maleShirts.Count);
				selectedMalePants = Random.Range(0,malePants.Count);
				selectedMaleUnderwear = Random.Range(0,maleUnderwear.Count);
				
				selectedMaleBodyMesh = Random.Range(0,maleBodyMeshes.Count);
				selectedMaleHands = Random.Range(0,maleHands.Count);
				selectedMaleLegs = Random.Range(0,maleLegs.Count);
				selectedMaleFeet = Random.Range(0,maleFeet.Count);
			}
			else {
				selectedFemaleSkinTone = Random.Range(0,skinTones.Count);
				selectedFemaleShirtColor = Random.Range(0,shirtColors.Count);
				selectedFemalePantsColor = Random.Range(0,pantsColors.Count);
				selectedFemaleUnderwearColor = Random.Range(0,underwearColors.Count);
				selectedFemaleBody = Random.Range(0,femaleBodies.Count);
				selectedFemaleShirt = Random.Range(0,femaleShirts.Count);
				selectedFemalePants = Random.Range(0,femalePants.Count);
				selectedFemaleUnderwear = Random.Range(0,femaleUnderwear.Count);
				
				selectedFemaleBodyMesh = Random.Range(0,femaleBodyMeshes.Count);
				selectedFemaleHands = Random.Range(0,femaleHands.Count);
				selectedFemaleLegs = Random.Range(0,femaleLegs.Count);
				selectedFemaleFeet = Random.Range(0,femaleFeet.Count);
			}
			
			GenerateOneUMA();
		}
	}
	
	void RandomizeHead () {
		if (!umaData.isTextureDirty) {
			if(selectedGender == "male") {
				selectedMaleEyeColor = Random.Range(0,eyeColors.Count);
				selectedMaleHairColor = Random.Range(0,hairColors.Count);
				selectedMaleHeadMesh = Random.Range(0,maleHeadMeshes.Count);
				selectedMaleHeadTexture = Random.Range(0,maleHeadTextures.Count);
				selectedMaleHairStyle = Random.Range(0,maleHairStyles.Count);
				selectedMaleBeardStyle = Random.Range(0,maleBeardStyles.Count);
				selectedMaleEyebrow = Random.Range(0,maleEyebrows.Count);
				
				// selectedMaleEyeballs = Random.Range(0,maleEyeballs.Count);
				// selectedMaleEyeballTexture = Random.Range(0,EyeballTextures.Count);
				// selectedMaleEyeballTextureAdjust = Random.Range(0,EyeballTexturesAdjust.Count);
				selectedMaleEyesockets = Random.Range(0,maleEyesockets.Count);
				selectedMaleEars = Random.Range(0,maleEars.Count);
				selectedMaleNose = Random.Range(0,maleNoses.Count);
				selectedMaleMouth = Random.Range(0,maleMouths.Count);
			}
			else {
				selectedFemaleEyeColor = Random.Range(0,eyeColors.Count);
				selectedFemaleHairColor = Random.Range(0,hairColors.Count);
				selectedFemaleLipstickColor = Random.Range(0,lipstickColors.Count);
				selectedFemaleHeadMesh = Random.Range(0,femaleHeadMeshes.Count);
				selectedFemaleHeadTexture = Random.Range(0,femaleHeadTextures.Count);
				selectedFemaleHairStyle = Random.Range(0,femaleHairStyles.Count);
				selectedFemaleEyebrow = Random.Range(0,femaleEyebrows.Count);
				
				// selectedFemaleEyeballs = Random.Range(0,femaleEyeballs.Count);
				// selectedFemaleEyeballTexture = Random.Range(0,EyeballTextures.Count);
				// selectedFemaleEyeballTextureAdjust = Random.Range(0,EyeballTexturesAdjust.Count);
				selectedFemaleEyesockets = Random.Range(0,femaleEyesockets.Count);
				selectedFemaleEars = Random.Range(0,femaleEars.Count);
				selectedFemaleNose = Random.Range(0,femaleNoses.Count);
				selectedFemaleMouth = Random.Range(0,femaleMouths.Count);
			}
			
			GenerateOneUMA();
		}
	}
	
	void CycleToNext (string part) {
		if (!umaData.isTextureDirty) {
			bool refreshChar = true;
			
			if (selectedGender == "male") {
				if (part == "body" && selectedMaleBodyMesh < maleBodyMeshes.Count-1)
					selectedMaleBodyMesh++;
				else if (part == "skintype" && selectedMaleBody < maleBodies.Count-1)
					selectedMaleBody++;
				else if (part == "skincolor" && selectedMaleSkinTone < skinTones.Count-1)
					selectedMaleSkinTone++;
				else if (part == "hands" && selectedMaleHands < maleHands.Count-1)
					selectedMaleHands++;
				else if (part == "legs" && selectedMaleLegs < maleLegs.Count-1)
					selectedMaleLegs++;
				else if (part == "feet" && selectedMaleFeet < maleFeet.Count-1)
					selectedMaleFeet++;
				else if (part == "upper" && selectedMaleShirt < maleShirts.Count-1)
					selectedMaleShirt++;
				else if (part == "uppercolor" && selectedMaleShirtColor < shirtColors.Count-1)
					selectedMaleShirtColor++;
				else if (part == "lower" && selectedMalePants < malePants.Count-1)
					selectedMalePants++;
				else if (part == "lowercolor" && selectedMalePantsColor < pantsColors.Count-1)
					selectedMalePantsColor++;
				else if (part == "underwear" && selectedMaleUnderwear < maleUnderwear.Count-1)
					selectedMaleUnderwear++;
				else if (part == "underwearcolor" && selectedMaleUnderwearColor < underwearColors.Count-1)
					selectedMaleUnderwearColor++;
				else if (part == "headmesh" && selectedMaleHeadMesh < maleHeadMeshes.Count-1)
					selectedMaleHeadMesh++;
				else if (part == "headtexture" && selectedMaleHeadTexture < maleHeadTextures.Count-1)
					selectedMaleHeadTexture++;
				else if (part == "eyes" && selectedMaleEyeColor < eyeColors.Count-1)
					selectedMaleEyeColor++;
				else if (part == "eyebrows" && selectedMaleEyebrow < maleEyebrows.Count-1)
					selectedMaleEyebrow++;
				else if (part == "eyesockets" && selectedMaleEyesockets < maleEyesockets.Count-1)
					selectedMaleEyesockets++;
				else if (part == "ears" && selectedMaleEars < maleEars.Count-1)
					selectedMaleEars++;
				else if (part == "nose" && selectedMaleNose < maleNoses.Count-1)
					selectedMaleNose++;
				else if (part == "mouth" && selectedMaleMouth < maleMouths.Count-1)
					selectedMaleMouth++;
				else if (part == "hairstyle" && selectedMaleHairStyle < maleHairStyles.Count-1)
					selectedMaleHairStyle++;
				else if (part == "beardstyle" && selectedMaleBeardStyle < maleBeardStyles.Count-1)
					selectedMaleBeardStyle++;
				else if (part == "haircolor" && selectedMaleHairColor < hairColors.Count-1)
					selectedMaleHairColor++;
				else
					refreshChar = false;
			} 
			else {
				if (part == "body" && selectedFemaleBodyMesh < femaleBodyMeshes.Count-1)
					selectedFemaleBodyMesh++;
				else if (part == "skintype" && selectedFemaleBody < femaleBodies.Count-1)
					selectedFemaleBody++;
				else if (part == "skincolor" && selectedFemaleSkinTone < skinTones.Count-1)
					selectedFemaleSkinTone++;
				else if (part == "hands" && selectedFemaleHands < femaleHands.Count-1)
					selectedFemaleHands++;
				else if (part == "legs" && selectedFemaleLegs < femaleLegs.Count-1)
					selectedFemaleLegs++;
				else if (part == "feet" && selectedFemaleFeet < femaleFeet.Count-1)
					selectedFemaleFeet++;
				else if (part == "upper" && selectedFemaleShirt < femaleShirts.Count-1)
					selectedFemaleShirt++;
				else if (part == "uppercolor" && selectedFemaleShirtColor < shirtColors.Count-1)
					selectedFemaleShirtColor++;
				else if (part == "lower" && selectedFemalePants < femalePants.Count-1)
					selectedFemalePants++;
				else if (part == "lowercolor" && selectedFemalePantsColor < pantsColors.Count-1)
					selectedFemalePantsColor++;
				else if (part == "underwear" && selectedFemaleUnderwear < femaleUnderwear.Count-1)
					selectedFemaleUnderwear++;
				else if (part == "underwearcolor" && selectedFemaleUnderwearColor < underwearColors.Count-1)
					selectedFemaleUnderwearColor++;
				else if (part == "headmesh" && selectedFemaleHeadMesh < femaleHeadMeshes.Count-1)
					selectedFemaleHeadMesh++;
				else if (part == "headtexture" && selectedFemaleHeadTexture < femaleHeadTextures.Count-1)
					selectedFemaleHeadTexture++;
				else if (part == "eyes" && selectedFemaleEyeColor < eyeColors.Count-1)
					selectedFemaleEyeColor++;
				else if (part == "eyebrows" && selectedFemaleEyebrow < femaleEyebrows.Count-1)
					selectedFemaleEyebrow++;
				else if (part == "eyesockets" && selectedFemaleEyesockets < femaleEyesockets.Count-1)
					selectedFemaleEyesockets++;
				else if (part == "ears" && selectedFemaleEars < femaleEars.Count-1)
					selectedFemaleEars++;
				else if (part == "nose" && selectedFemaleNose < femaleNoses.Count-1)
					selectedFemaleNose++;
				else if (part == "mouth" && selectedFemaleMouth < femaleMouths.Count-1)
					selectedFemaleMouth++;
				else if (part == "hairstyle" && selectedFemaleHairStyle < femaleHairStyles.Count-1)
					selectedFemaleHairStyle++;
				else if (part == "haircolor" && selectedFemaleHairColor < hairColors.Count-1)
					selectedFemaleHairColor++;
				else if (part == "lipstick" && selectedFemaleLipstickColor < lipstickColors.Count-1)
					selectedFemaleLipstickColor++;
				else
					refreshChar = false;
			}
			
			if (refreshChar) GenerateOneUMA();
		}
	}
	
	void CycleToPrev (string part) {
		if (!umaData.isTextureDirty) {
			bool refreshChar = true;
			
			if (selectedGender == "male") {
				if (part == "body" && selectedMaleBodyMesh > 0)
					selectedMaleBodyMesh--;
				else if (part == "skintype" && selectedMaleBody > 0)
					selectedMaleBody--;
				else if (part == "skincolor" && selectedMaleSkinTone > 0)
					selectedMaleSkinTone--;
				else if (part == "legs" && selectedMaleLegs > 0)
					selectedMaleLegs--;
				else if (part == "upper" && selectedMaleShirt > 0)
					selectedMaleShirt--;
				else if (part == "uppercolor" && selectedMaleShirtColor > 0)
					selectedMaleShirtColor--;
				else if (part == "lower" && selectedMalePants > 0)
					selectedMalePants--;
				else if (part == "lowercolor" && selectedMalePantsColor > 0)
					selectedMalePantsColor--;
				else if (part == "underwear" && selectedMaleUnderwear > 0)
					selectedMaleUnderwear--;
				else if (part == "underwearcolor" && selectedMaleUnderwearColor > 0)
					selectedMaleUnderwearColor--;
				else if (part == "headmesh" && selectedMaleHeadMesh > 0)
					selectedMaleHeadMesh--;
				else if (part == "headtexture" && selectedMaleHeadTexture > 0)
					selectedMaleHeadTexture--;
				else if (part == "eyes" && selectedMaleEyeColor > 0)
					selectedMaleEyeColor--;
				else if (part == "eyebrows" && selectedMaleEyebrow > 0)
					selectedMaleEyebrow--;
				else if (part == "eyesockets" && selectedMaleEyesockets > 0)
					selectedMaleEyesockets--;
				else if (part == "ears" && selectedMaleEars > 0)
					selectedMaleEars--;
				else if (part == "nose" && selectedMaleNose > 0)
					selectedMaleNose--;
				else if (part == "mouth" && selectedMaleMouth > 0)
					selectedMaleMouth--;
				else if (part == "hairstyle" && selectedMaleHairStyle > 0)
					selectedMaleHairStyle--;
				else if (part == "beardstyle" && selectedMaleBeardStyle > 0)
					selectedMaleBeardStyle--;
				else if (part == "haircolor" && selectedMaleHairColor > 0)
					selectedMaleHairColor--;
				else
					refreshChar = false;
			} 
			else {
				if (part == "body" && selectedFemaleBodyMesh > 0)
					selectedFemaleBodyMesh--;
				else if (part == "skintype" && selectedFemaleBody > 0)
					selectedFemaleBody--;
				else if (part == "skincolor" && selectedFemaleSkinTone > 0)
					selectedFemaleSkinTone--;
				else if (part == "legs" && selectedFemaleLegs > 0)
					selectedFemaleLegs--;
				else if (part == "upper" && selectedFemaleShirt > 0)
					selectedFemaleShirt--;
				else if (part == "uppercolor" && selectedFemaleShirtColor > 0)
					selectedFemaleShirtColor--;
				else if (part == "lower" && selectedFemalePants > 0)
					selectedFemalePants--;
				else if (part == "lowercolor" && selectedFemalePantsColor > 0)
					selectedFemalePantsColor--;
				else if (part == "underwear" && selectedFemaleUnderwear > 0)
					selectedFemaleUnderwear--;
				else if (part == "underwearcolor" && selectedFemaleUnderwearColor > 0)
					selectedFemaleUnderwearColor--;
				else if (part == "headmesh" && selectedFemaleHeadMesh > 0)
					selectedFemaleHeadMesh--;
				else if (part == "headtexture" && selectedFemaleHeadTexture > 0)
					selectedFemaleHeadTexture--;
				else if (part == "eyes" && selectedFemaleEyeColor > 0)
					selectedFemaleEyeColor--;
				else if (part == "eyebrows" && selectedFemaleEyebrow > 0)
					selectedFemaleEyebrow--;
				else if (part == "eyesockets" && selectedFemaleEyesockets > 0)
					selectedFemaleEyesockets--;
				else if (part == "ears" && selectedFemaleEars > 0)
					selectedFemaleEars--;
				else if (part == "nose" && selectedFemaleNose > 0)
					selectedFemaleNose--;
				else if (part == "mouth" && selectedFemaleMouth > 0)
					selectedFemaleMouth--;
				else if (part == "hairstyle" && selectedFemaleHairStyle > 0)
					selectedFemaleHairStyle--;
				else if (part == "haircolor" && selectedFemaleHairColor > 0)
					selectedFemaleHairColor--;
				else if (part == "lipstick" && selectedFemaleLipstickColor > 0)
					selectedFemaleLipstickColor--;
				else
					refreshChar = false;
			}
			
			if (refreshChar) GenerateOneUMA();
		}
	}
	
	void DestroyCurrent () {
		if (selectedGender == "male") {
			Destroy(GameObject.Find("Male"));
			maleAvatarHead = null;
			maleAvatarBody = null;
		} 
		else {
			Destroy(GameObject.Find("Female"));
			femaleAvatarHead = null;
			femaleAvatarBody = null;
		}
	}
	
	// Make the camera target follow the active character
	void MoveCamTarget () {
		Transform target;
		
		if (selectedGender != "") {
			if (selectedGender == "male") {
				if (hasSelectedHead) {
					target = maleAvatarHead;
				} else {
					target = maleAvatarBody;
				}
			} 
			else {
				if (hasSelectedHead) {
					target = femaleAvatarHead;
				} else {
					target = femaleAvatarBody;
				}
			}
			
			if (!umaData.isTextureDirty) {
				if (cameraTarget != null && target != null) {
					float step = 1.0f * Vector3.Distance(cameraTarget.transform.position, target.position) * Time.deltaTime;
					cameraTarget.transform.position = Vector3.MoveTowards(cameraTarget.transform.position, target.position, step);
				}
			}
			
		}
	}
	
	// Handle zooming
	void ZoomCamera() {
		float targetDistance;
		
		if (hasSelectedHead)
			targetDistance = cameraHeadDistance;
		else
			targetDistance = cameraBodyDistance;
		
		orbitCamera.GetComponent<CameraController>().distance = Mathf.Lerp(orbitCamera.GetComponent<CameraController>().distance, targetDistance, Time.deltaTime * 2.0f);
	}
	
	void UpdateAttributes () {
		// Don't try to update attributes until we have spawned a character
		if (selectedGender != "") {
			UMAData tempUMA;
			
			if (selectedGender == "male") {
				tempUMA = maleAvatarSpawn.GetComponent<UMAData>();
			} else {
				tempUMA = femaleAvatarSpawn.GetComponent<UMAData>();
			}
			
			umaDynamicAvatar = tempUMA.gameObject.GetComponent<UMADynamicAvatar>();
			
			// Recieve if we're not pulling the sliders, and send if we do
			if (!Input.GetMouseButton(0)) {
				if(tempUMA){
					umaData = tempUMA;
					
					umaDna = umaData.umaRecipe.GetDna<UMADnaHumanoid>();
					
					ReceiveValues();
				}
			} 
			
			if (Input.GetMouseButton(0)){
				if(umaData){
					TransferValues();
					UpdateUMAShape();
				}
			}
		}
	}
	
	void CreateSlider (int number) {
		GUILayout.BeginVertical(sliderLayoutStyle);
		GUILayout.Label (sliderControlArray[number].name, labelStyle);
		sliderControlArray[number].value = GUILayout.HorizontalSlider(sliderControlArray[number].value, sliderSettings.minValue, sliderSettings.maxValue);
		GUILayout.Box(sliderControlArray[number].value.ToString("F2"), sliderValueStyle);
		GUILayout.EndVertical();
	}
	
	void CreateSliderRow (int[] numbers) {
		GUILayout.BeginHorizontal(horizontalLayoutStyle);
		for (int i = 0; i < numbers.Length; i++) {
			CreateSlider(numbers[i]);
		}
		GUILayout.EndHorizontal();
	}
	
	IEnumerator UpdateGuiDimensions () {
		while (true) {
			attributeWindowSettings.height = Screen.height - (settings.yPos + genderWindowSettings.height + tabWindowSettings.height + (settings.spacing * 2)) - 122;
			bottomBarStyle.padding.left = Screen.width - 400;
			
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	public void UpdateUMAShape(){
		umaData.isShapeDirty = true;
		umaData.Dirty();
	}
	
	public void ReceiveValues(){
		if(umaDna != null){
			sliderControlArray[0].value = umaDna.height;
			sliderControlArray[1].value = umaDna.headSize;
			sliderControlArray[2].value = umaDna.headWidth;
			
			
			
			sliderControlArray[3].value = umaDna.neckThickness;
			sliderControlArray[4].value = umaDna.upperMuscle;
			sliderControlArray[5].value = umaDna.lowerMuscle;
			
			sliderControlArray[6].value = umaDna.breastSize;	
			sliderControlArray[7].value = umaDna.upperWeight;
			sliderControlArray[8].value = umaDna.lowerWeight;
			
			sliderControlArray[9].value = umaDna.legsSize;
			sliderControlArray[10].value = umaDna.belly;
			sliderControlArray[11].value = umaDna.waist;
			
			sliderControlArray[12].value = umaDna.gluteusSize;	
			sliderControlArray[13].value = umaDna.armLength;
			sliderControlArray[14].value = umaDna.armWidth;
			
			sliderControlArray[15].value = umaDna.forearmLength;
			sliderControlArray[16].value = umaDna.forearmWidth;
			sliderControlArray[17].value = umaDna.handsSize;
			
			sliderControlArray[18].value = umaDna.legSeparation;
			sliderControlArray[19].value = umaDna.feetSize;
			
			
			
			sliderControlArray[20].value = umaDna.foreheadSize;
			sliderControlArray[21].value = umaDna.foreheadPosition;
			sliderControlArray[22].value = umaDna.noseSize;
			
			sliderControlArray[23].value = umaDna.eyeSize;
			sliderControlArray[24].value = umaDna.lipsSize;
			sliderControlArray[25].value = umaDna.mouthSize;
			
			sliderControlArray[26].value = umaDna.noseCurve;
			sliderControlArray[27].value = umaDna.noseWidth;
			sliderControlArray[28].value = umaDna.noseInclination;
			
			sliderControlArray[29].value = umaDna.nosePosition;
			sliderControlArray[30].value = umaDna.nosePronounced;
			sliderControlArray[31].value = umaDna.noseFlatten;
			
			sliderControlArray[32].value = umaDna.chinSize;
			sliderControlArray[33].value = umaDna.chinPronounced;
			sliderControlArray[34].value = umaDna.chinPosition;
			
			sliderControlArray[35].value = umaDna.mandibleSize;
			sliderControlArray[36].value = umaDna.jawsSize;
			sliderControlArray[37].value = umaDna.jawsPosition;
			
			sliderControlArray[38].value = umaDna.cheekSize;
			sliderControlArray[39].value = umaDna.cheekPosition;
			sliderControlArray[40].value = umaDna.lowCheekPronounced;
			
			sliderControlArray[41].value = umaDna.earsSize;
			sliderControlArray[42].value = umaDna.earsPosition;
			sliderControlArray[43].value = umaDna.earsRotation;
			
			sliderControlArray[44].value = umaDna.lowCheekPosition;
			sliderControlArray[45].value = umaDna.eyeRotation;
		}
	}
	
	public void TransferValues(){
		if(umaDna != null){
			umaDna.height = sliderControlArray[0].value;
			umaDna.headSize = sliderControlArray[1].value;
			umaDna.headWidth = sliderControlArray[2].value;
			
			
			
			umaDna.neckThickness = sliderControlArray[3].value;
			umaDna.upperMuscle = sliderControlArray[4].value;
			umaDna.lowerMuscle = sliderControlArray[5].value;
			
			umaDna.breastSize = sliderControlArray[6].value;
			umaDna.upperWeight = sliderControlArray[7].value;
			umaDna.lowerWeight = sliderControlArray[8].value;
			
			umaDna.legsSize = sliderControlArray[9].value;
			umaDna.belly = sliderControlArray[10].value;
			umaDna.waist = sliderControlArray[11].value;
			
			umaDna.gluteusSize = sliderControlArray[12].value;
			umaDna.armLength = sliderControlArray[13].value;
			umaDna.armWidth = sliderControlArray[14].value;
			
			umaDna.forearmLength = sliderControlArray[15].value;
			umaDna.forearmWidth = sliderControlArray[16].value;
			umaDna.handsSize = sliderControlArray[17].value;
			
			umaDna.legSeparation = sliderControlArray[18].value;
			umaDna.feetSize = sliderControlArray[19].value;
			
			
			
			umaDna.foreheadSize = sliderControlArray[20].value;
			umaDna.foreheadPosition = sliderControlArray[21].value;
			umaDna.noseSize = sliderControlArray[22].value;
			
			umaDna.eyeSize = sliderControlArray[23].value;
			umaDna.lipsSize = sliderControlArray[24].value;
			umaDna.mouthSize = sliderControlArray[25].value;
			
			umaDna.noseCurve = sliderControlArray[26].value;
			umaDna.noseWidth = sliderControlArray[27].value;
			umaDna.noseInclination = sliderControlArray[28].value;
			
			umaDna.nosePosition = sliderControlArray[29].value;
			umaDna.nosePronounced = sliderControlArray[30].value;
			umaDna.noseFlatten = sliderControlArray[31].value;
			
			umaDna.chinSize = sliderControlArray[32].value;
			umaDna.chinPronounced = sliderControlArray[33].value;
			umaDna.chinPosition = sliderControlArray[34].value;
			
			umaDna.mandibleSize = sliderControlArray[35].value;
			umaDna.jawsSize = sliderControlArray[36].value;
			umaDna.jawsPosition = sliderControlArray[37].value;
			
			umaDna.cheekSize = sliderControlArray[38].value;
			umaDna.cheekPosition = sliderControlArray[39].value;
			umaDna.lowCheekPronounced = sliderControlArray[40].value;
			
			umaDna.earsSize = sliderControlArray[41].value;
			umaDna.earsPosition = sliderControlArray[42].value;
			umaDna.earsRotation = sliderControlArray[43].value;
			
			umaDna.lowCheekPosition = sliderControlArray[44].value;
			umaDna.eyeRotation = sliderControlArray[45].value;
		}
	}
	
    /// <summary>
    /// 创建出人物 
    /// </summary>
	void DefineSlots() {
        
		umaData.umaRecipe.slotDataList = new SlotData[15];
		
		if (selectedGender == "male") {
			
			// Eyeballs 眼球
			umaData.umaRecipe.slotDataList[0] = GetSlotLibrary().InstantiateSlot(maleEyeballs[selectedMaleEyeballs]);
			umaData.umaRecipe.slotDataList[0].AddOverlay(GetOverlayLibrary().InstantiateOverlay(EyeballTextures[selectedMaleEyeballTexture]));
			umaData.umaRecipe.slotDataList[0].AddOverlay(GetOverlayLibrary().InstantiateOverlay(EyeballTexturesAdjust[selectedMaleEyeballTextureAdjust],eyeColors[selectedMaleEyeColor]));
			
			// Head Mesh 头
			umaData.umaRecipe.slotDataList[1] = GetSlotLibrary().InstantiateSlot(maleHeadMeshes[selectedMaleHeadMesh]);
			
			// Head Texture 头纹理
			umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleHeadTextures[selectedMaleHeadTexture], skinTones[selectedMaleSkinTone]));
			
			//Eyes 眼睛
			umaData.umaRecipe.slotDataList[7] = GetSlotLibrary().InstantiateSlot(maleEyesockets[selectedMaleEyesockets],umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			// Ears 耳朵
			// umaData.umaRecipe.slotDataList[8] = GetSlotLibrary().InstantiateSlot("MaleHead_ElvenEars");
			// umaData.umaRecipe.slotDataList[8].AddOverlay(GetOverlayLibrary().InstantiateOverlay("ElvenEars",skinColor));
			umaData.umaRecipe.slotDataList[8] = GetSlotLibrary().InstantiateSlot(maleEars[selectedMaleEars], umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			// Mouth 嘴
			umaData.umaRecipe.slotDataList[9] = GetSlotLibrary().InstantiateSlot(maleMouths[selectedMaleMouth], umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			// Nose 鼻子
			umaData.umaRecipe.slotDataList[10] = GetSlotLibrary().InstantiateSlot(maleNoses[selectedMaleNose], umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			// Hair 头发
			if (maleHairStyles[selectedMaleHairStyle] != "") {
				umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleHairStyles[selectedMaleHairStyle], hairColors[selectedMaleHairColor]*0.25f));
			}
			
			// Beard 胡须
			if (maleBeardStyles[selectedMaleBeardStyle] != "") {
				umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleBeardStyles[selectedMaleBeardStyle], hairColors[selectedMaleHairColor]*0.15f));
			}			
			
			// Eyebrows 眉毛
			umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleEyebrows[selectedMaleEyebrow], hairColors[selectedMaleHairColor]*0.05f));
			
			// Torso mesh 躯干
			umaData.umaRecipe.slotDataList[2] = GetSlotLibrary().InstantiateSlot(maleBodyMeshes[selectedMaleBodyMesh]);
			
			// Body skin 皮肤
			umaData.umaRecipe.slotDataList[2].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleBodies[selectedMaleBody], skinTones[selectedMaleSkinTone]));

            //Shirt 衬衫
			if (maleShirts[selectedMaleShirt] != "") {
				umaData.umaRecipe.slotDataList[2].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleShirts[selectedMaleShirt], shirtColors[selectedMaleShirtColor]));
			}
			
			//Hands 手
			umaData.umaRecipe.slotDataList[3] = GetSlotLibrary().InstantiateSlot(maleHands[selectedMaleHands], umaData.umaRecipe.slotDataList[2].GetOverlayList());
			
			//Inner mouth 口腔
			umaData.umaRecipe.slotDataList[4] = GetSlotLibrary().InstantiateSlot("MaleInnerMouth");
			umaData.umaRecipe.slotDataList[4].AddOverlay(GetOverlayLibrary().InstantiateOverlay("InnerMouth"));
			
			// Legs and underwear 腿和内裤
			umaData.umaRecipe.slotDataList[5] = GetSlotLibrary().InstantiateSlot(maleLegs[selectedMaleLegs], umaData.umaRecipe.slotDataList[2].GetOverlayList());
			if (maleUnderwear[selectedMaleUnderwear] != "") {
				umaData.umaRecipe.slotDataList[2].AddOverlay(GetOverlayLibrary().InstantiateOverlay(maleUnderwear[selectedMaleUnderwear], underwearColors[selectedMaleUnderwearColor]));
			}
			
			// Pants 裤子
			if (malePants[selectedMalePants] != "") {
				umaData.umaRecipe.slotDataList[5] = GetSlotLibrary().InstantiateSlot(malePants[selectedMalePants]);
				umaData.umaRecipe.slotDataList[5].AddOverlay(GetOverlayLibrary().InstantiateOverlay(malePants[selectedMalePants], pantsColors[selectedMalePantsColor]));
			}
			
			// Feet or shoes 脚或者鞋
			umaData.umaRecipe.slotDataList[6] = GetSlotLibrary().InstantiateSlot(maleFeet[selectedMaleFeet], umaData.umaRecipe.slotDataList[2].GetOverlayList());
			
		}
		else if (selectedGender == "female") {
			
			// Eyeballs
			umaData.umaRecipe.slotDataList[0] = GetSlotLibrary().InstantiateSlot(femaleEyeballs[selectedFemaleEyeballs]);            
			umaData.umaRecipe.slotDataList[0].AddOverlay(GetOverlayLibrary().InstantiateOverlay(EyeballTextures[selectedFemaleEyeballTexture]));
			umaData.umaRecipe.slotDataList[0].AddOverlay(GetOverlayLibrary().InstantiateOverlay(EyeballTexturesAdjust[selectedFemaleEyeballTextureAdjust],eyeColors[selectedFemaleEyeColor]));
            
			// Head Mesh
			umaData.umaRecipe.slotDataList[1] = GetSlotLibrary().InstantiateSlot(femaleHeadMeshes[selectedFemaleHeadMesh]);
			
			// Head Texture
			umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleHeadTextures[selectedFemaleHeadTexture], skinTones[selectedFemaleSkinTone]));
			
			// Eyebrows
			umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleEyebrows[selectedFemaleEyebrow], hairColors[selectedFemaleHairColor]*0.05f));
			
			//Eyes
			umaData.umaRecipe.slotDataList[7] = GetSlotLibrary().InstantiateSlot(femaleEyesockets[selectedFemaleEyesockets],umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			// Ears
			// umaData.umaRecipe.slotDataList[8] = GetSlotLibrary().InstantiateSlot("FemaleHead_ElvenEars");
			// umaData.umaRecipe.slotDataList[8].AddOverlay(GetOverlayLibrary().InstantiateOverlay("ElvenEars",skinColor));
			umaData.umaRecipe.slotDataList[8] = GetSlotLibrary().InstantiateSlot(femaleEars[selectedFemaleEars], umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			// Mouth
			umaData.umaRecipe.slotDataList[9] = GetSlotLibrary().InstantiateSlot(femaleMouths[selectedFemaleMouth], umaData.umaRecipe.slotDataList[1].GetOverlayList());
			umaData.umaRecipe.slotDataList[9].AddOverlay(GetOverlayLibrary().InstantiateOverlay(lipstickTextures[selectedFemaleLipstickTexture], lipstickColors[selectedFemaleLipstickColor]));
			
			// Nose
			umaData.umaRecipe.slotDataList[10] = GetSlotLibrary().InstantiateSlot(femaleNoses[selectedFemaleNose], umaData.umaRecipe.slotDataList[1].GetOverlayList());
			
			
			// Eyelashes
			umaData.umaRecipe.slotDataList[11] = GetSlotLibrary().InstantiateSlot("FemaleEyelash");
			umaData.umaRecipe.slotDataList[11].AddOverlay(GetOverlayLibrary().InstantiateOverlay("FemaleEyelash", Color.black));
			
			// Torso mesh
			umaData.umaRecipe.slotDataList[2] = GetSlotLibrary().InstantiateSlot(femaleBodyMeshes[selectedFemaleBodyMesh]);
			
			// Body skin
			umaData.umaRecipe.slotDataList[2].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleBodies[selectedFemaleBody], skinTones[selectedFemaleSkinTone]));
			
			// Hands
			umaData.umaRecipe.slotDataList[3] = GetSlotLibrary().InstantiateSlot(femaleHands[selectedFemaleHands], umaData.umaRecipe.slotDataList[2].GetOverlayList());
			
			//Inner mouth
			umaData.umaRecipe.slotDataList[4] = GetSlotLibrary().InstantiateSlot("FemaleInnerMouth");
			umaData.umaRecipe.slotDataList[4].AddOverlay(GetOverlayLibrary().InstantiateOverlay("InnerMouth"));
			
			// Legs
			umaData.umaRecipe.slotDataList[5] = GetSlotLibrary().InstantiateSlot(femaleLegs[selectedFemaleLegs], umaData.umaRecipe.slotDataList[2].GetOverlayList());
			
			// Underwear
			if (femaleUnderwear[selectedFemaleUnderwear] != "") {
				umaData.umaRecipe.slotDataList[2].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleUnderwear[selectedFemaleUnderwear], underwearColors[selectedFemaleUnderwearColor]));
			}
			
			// Pants
			if (femalePants[selectedFemalePants] != "") {
				umaData.umaRecipe.slotDataList[5].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femalePants[selectedFemalePants], pantsColors[selectedFemalePantsColor]));
			}
			
			// Feet or shoes
			umaData.umaRecipe.slotDataList[6] = GetSlotLibrary().InstantiateSlot(femaleFeet[selectedFemaleFeet], umaData.umaRecipe.slotDataList[2].GetOverlayList());
			
			// Shirt
			if (femaleShirts[selectedFemaleShirt] != "") {
				if(femaleShirts[selectedFemaleShirt] != "FemaleTshirt01") {
					umaData.umaRecipe.slotDataList[2].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleShirts[selectedFemaleShirt], shirtColors[selectedFemaleShirtColor]));
				} else {
					umaData.umaRecipe.slotDataList[14] = GetSlotLibrary().InstantiateSlot(femaleShirts[selectedFemaleShirt]);
					umaData.umaRecipe.slotDataList[14].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleShirts[selectedFemaleShirt], shirtColors[selectedFemaleShirtColor]));
				}
			}
			
			// Hair (mesh)
			if (femaleHairStyles[selectedFemaleHairStyle] != "") {
				if(femaleHairStyles[selectedFemaleHairStyle] != "FemaleLongHair01_Module") {
					umaData.umaRecipe.slotDataList[12] = GetSlotLibrary().InstantiateSlot(femaleHairStyles[selectedFemaleHairStyle], umaData.umaRecipe.slotDataList[1].GetOverlayList());
					umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay(femaleHairStyles[selectedFemaleHairStyle], hairColors[selectedFemaleHairColor]));	
				}
				else {
					umaData.umaRecipe.slotDataList[12] = GetSlotLibrary().InstantiateSlot("FemaleLongHair01", umaData.umaRecipe.slotDataList[1].GetOverlayList());
					umaData.umaRecipe.slotDataList[1].AddOverlay(GetOverlayLibrary().InstantiateOverlay("FemaleLongHair01", hairColors[selectedFemaleHairColor]));	
					umaData.umaRecipe.slotDataList[13] = GetSlotLibrary().InstantiateSlot("FemaleLongHair01_Module");
					umaData.umaRecipe.slotDataList[13].AddOverlay(GetOverlayLibrary().InstantiateOverlay("FemaleLongHair01_Module", hairColors[selectedFemaleHairColor]));	
				}
			}
		}
	}

	protected virtual void SetUMAData()
	{
		umaData.atlasResolutionScale = atlasResolutionScale;
		umaData.OnCharacterCreated += CharacterCreatedCallback;
	}

	void CharacterCreatedCallback(UMAData umaData)
	{
		if (umaData.animator != null)
			umaData.animator.enabled = false;
		if (umaData.myRenderer != null)
			umaData.myRenderer.enabled = false;
	}
	
	void GenerateUMAShapes (bool randomize = false){
		
		// If it's the first time we create a female or male, add the default DNA
		if (selectedGender == "male") {
			if (savedMaleUmaDna == null) {savedMaleUmaDna = new UMADnaHumanoid();}
			umaData.umaRecipe.AddDna(savedMaleUmaDna);
		} 
		else {
			if (savedFemaleUmaDna == null) {savedFemaleUmaDna = new UMADnaHumanoid();}
			umaData.umaRecipe.AddDna(savedFemaleUmaDna);
		}
		
		// Here you can define the randomness ranges to suit what should be plausible in your game
		if (randomize) {
			// It's possible to do gender specific randomness like this
			if (selectedGender == "male"){
				umaDna.height = Random.Range(0.5f,0.6f);
				umaDna.waist = 0.5f;
			}else{
				umaDna.height = Random.Range(0.4f,0.5f);
				umaDna.waist = Random.Range(0.3f,0.8f);
			}
			
			umaDna.headSize = Random.Range(0.485f,0.515f);
			umaDna.headWidth = Random.Range(0.4f,0.6f);
			
			umaDna.neckThickness = Random.Range(0.495f,0.51f);
			
			umaDna.handsSize = Random.Range(0.485f,0.515f);
			umaDna.feetSize = Random.Range(0.485f,0.515f);
			
			umaDna.armLength = Random.Range(0.485f,0.515f);
			umaDna.forearmLength = Random.Range(0.485f,0.515f);
			umaDna.armWidth = Random.Range(0.4f,0.6f);
			umaDna.forearmWidth = Random.Range(0.4f,0.6f);
			
			// It's also possible to have some values depend on others
			umaDna.upperMuscle = Random.Range(0.4f,0.6f);
			umaDna.upperWeight = Random.Range(-0.2f,0.2f) + umaDna.upperMuscle;
			if(umaDna.upperWeight > 1.0){ umaDna.upperWeight = 1.0f;}
			if(umaDna.upperWeight < 0.0){ umaDna.upperWeight = 0.0f;}
			
			umaDna.lowerMuscle = Random.Range(-0.2f,0.2f) + umaDna.upperMuscle;
			if(umaDna.lowerMuscle > 1.0){ umaDna.lowerMuscle = 1.0f;}
			if(umaDna.lowerMuscle < 0.0){ umaDna.lowerMuscle = 0.0f;}
			
			umaDna.lowerWeight = Random.Range(-0.1f,0.1f) + umaDna.upperWeight;
			if(umaDna.lowerWeight > 1.0){ umaDna.lowerWeight = 1.0f;}
			if(umaDna.lowerWeight < 0.0){ umaDna.lowerWeight = 0.0f;}
			
			umaDna.belly = umaDna.upperWeight;
			umaDna.legsSize = Random.Range(0.4f,0.6f);
			umaDna.gluteusSize = Random.Range(0.4f,0.6f);
			
			umaDna.earsSize = Random.Range(0.2f,0.8f);
			umaDna.earsPosition = Random.Range(0.2f,0.8f);
			umaDna.earsRotation = Random.Range(0.2f,0.8f);
			
			umaDna.noseSize = Random.Range(0.2f,0.8f);
			umaDna.noseCurve = Random.Range(0.2f,0.8f);
			umaDna.noseWidth = Random.Range(0.2f,0.8f);
			umaDna.noseInclination = Random.Range(0.2f,0.8f);
			umaDna.nosePosition = Random.Range(0.2f,0.8f);
			umaDna.nosePronounced = Random.Range(0.2f,0.8f);
			umaDna.noseFlatten = Random.Range(0.2f,0.8f);
			
			umaDna.chinSize = Random.Range(0.2f,0.8f);
			umaDna.chinPronounced = Random.Range(0.2f,0.8f);
			umaDna.chinPosition = Random.Range(0.2f,0.8f);
			
			umaDna.mandibleSize = Random.Range(0.45f,0.52f);
			umaDna.jawsSize = Random.Range(0.2f,0.8f);
			umaDna.jawsPosition = Random.Range(0.2f,0.8f);
			
			umaDna.cheekSize = Random.Range(0.2f,0.8f);
			umaDna.cheekPosition = Random.Range(0.2f,0.8f);
			umaDna.lowCheekPronounced = Random.Range(0.2f,0.8f);
			umaDna.lowCheekPosition = Random.Range(0.2f,0.8f);
			
			umaDna.foreheadSize = Random.Range(0.2f,0.8f);
			umaDna.foreheadPosition = Random.Range(0.15f,0.65f);
			
			umaDna.lipsSize = Random.Range(0.2f,0.8f);
			umaDna.mouthSize = Random.Range(0.2f,0.8f);
			umaDna.eyeRotation = Random.Range(0.2f,0.8f);
			umaDna.eyeSize = Random.Range(0.2f,0.8f);
			umaDna.breastSize = Random.Range(0.2f,0.8f);
		}
	}
	
	/// <summary>
	///  创建角色 具体操作
	/// </summary>
	/// <param name="randomizeShape"></param>
	void GenerateOneUMA(bool randomizeShape = false){
		
		var newGO = new GameObject();
		newGO.transform.parent = GameObject.Find("UMAzing").transform;
		
		// Rotate the character to face the camera
		newGO.transform.localEulerAngles = new Vector3(0, 180, 0);
		UMADynamicAvatar umaDynamicAvatar = newGO.AddComponent<UMADynamicAvatar>();
		umaDynamicAvatar.Initialize();
		umaData = umaDynamicAvatar.umaData;
		umaData.CharacterCreated = new UMADataEvent(CharacterCreated);
		umaData.CharacterDestroyed = new UMADataEvent(CharacterDestroyed);
		umaData.CharacterUpdated = new UMADataEvent(CharacterUpdated);
		umaDynamicAvatar.umaGenerator = generator;
		umaData.umaGenerator = generator;
		var umaRecipe = umaDynamicAvatar.umaData.umaRecipe;
      
		if (hasCreatedMale || hasCreatedFemale) {DestroyCurrent();}
		
		// Male or female?
		if (selectedGender == "male") { 
			umaRecipe.SetRace(GetRaceLibrary().GetRace("HumanMale")); 
			newGO.name = "Male";
			maleAvatarSpawn = newGO;
		}
		else { 
			umaRecipe.SetRace(GetRaceLibrary().GetRace("HumanFemale")); 
			newGO.name = "Female";
			femaleAvatarSpawn = newGO;
		}
        
		umaData.atlasResolutionScale = atlasResolutionScale;
		umaData.Dirty(true, true, true);
        
		// Instantiate slots and add overlays 实例化人物
		DefineSlots();
        
		AddAdditionalSlots();
        
		// Set/randomize the shape values
		GenerateUMAShapes(randomizeShape);

		if (animationController != null)
		{
			umaDynamicAvatar.animationController = animationController;
		}
		
		umaDynamicAvatar.UpdateNewRace();
		if (umaData.myRenderer != null)
			umaDynamicAvatar.umaData.myRenderer.enabled = false;
		
	}

	private void AddAdditionalSlots()
	{
		umaData.AddAdditionalRecipes(additionalRecipes, UMAContext.FindInstance());
	}

	private RaceLibraryBase GetRaceLibrary()
	{
		if (umaContext != null) return umaContext.raceLibrary;
		#pragma warning disable 618
		return raceLibrary;
		#pragma warning restore 618
	}
	
	private SlotLibraryBase GetSlotLibrary()
	{
		if (umaContext != null) return umaContext.slotLibrary;
		#pragma warning disable 618
		return slotLibrary;
		#pragma warning restore 618
	}
	
	private OverlayLibraryBase GetOverlayLibrary()
	{
		if (umaContext != null) return umaContext.overlayLibrary;
		#pragma warning disable 618
		return overlayLibrary;
		#pragma warning restore 618
	}
}

public static class Helper
	
{
	public static GameObject FindInChildren(this GameObject go, string name) {
		GameObject selectedGO = null;
		if (go != null && name != null){
			if ((from x in go.GetComponentsInChildren<Transform>()
			     where x.gameObject.name == name
			     select x.gameObject).Any()){
					selectedGO = (from x in go.GetComponentsInChildren<Transform>()
		                 where x.gameObject.name == name
		                  select x.gameObject).First();
			}
		}
		return selectedGO;
		
	}
	
}
