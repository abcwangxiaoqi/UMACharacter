using UnityEngine;
using System.Collections;
using UMA;

public class UMAzingSpawn : MonoBehaviour {
	public string characterSavePath = "Assets/Character Saves";
	
	// If supplied, the script will look for a character with this name in the save path if no character has been supplied from a previous scene
	// This is useful if you want to test the game without having to re-create the character every time.
	public string fallbackCharacter = "Test Guy";

	public UMARecipeBase[] additionalRecipes;

	string characterName;

	void Start () {

		if (string.IsNullOrEmpty(PersistentNameHolder.characterName)) {
			characterName = fallbackCharacter;
		} else {
			characterName = PersistentNameHolder.characterName;
		}

		if (characterName.Length != 0)
		{
			var avatar = gameObject.GetComponent<UMAAvatarBase>();
			if( avatar != null )
			{
				// Combine the save path and character name strings to find the character
				string finalPath = characterSavePath + "/" + characterName + ".txt";
				var asset = ScriptableObject.CreateInstance<UMATextRecipe>();
				asset.recipeString = System.IO.File.ReadAllText(finalPath);
				if (asset != null)
				{
					avatar.Initialize();
					avatar.Load(asset);
					avatar.Load(asset, additionalRecipes);
				}
				else
				{
					Debug.LogError("Failed To Load Asset \"" + finalPath + "\"\nAssets must be inside the project and descend from the UMARecipeBase type");
				}

			}
		} else {
			Debug.LogError("Couldn't find a character to load. Make sure the character save path is correct and that the name override is blank if you are using the character creator.");
		}
	}
}
