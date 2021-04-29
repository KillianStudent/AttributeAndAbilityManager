using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Attributes : EditorWindow
{
    Pawn _pawn;
    MonoScript _script = null;
    GameObject _character;
    AbilityCooldown _abilitycooldown;
    List<Ability> list;
    List<Ability> allAbilities;
    int ListSize;

    //public ScriptableObject[] _abilities = { DrivingStrike, SlowedMoveSpeed } ;

    float SpeedWeight;
    float PowerWeight;
    float TechWeight;

    int DesiredSpeedWeight;
    int DesiredPowerWeight;
    int DesiredTechWeight;

    bool SpeedGood = false;
    bool PowerGood = false;
    bool TechGood = false;


    [MenuItem("Tools/Attribute and Ability Manager")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Attributes));
    }

    
    private void OnGUI()
    {
        _character = EditorGUILayout.ObjectField("Character", _character, typeof(GameObject), true) as GameObject;
        if (_character != null)
        {
            _abilitycooldown = _character.GetComponent<AbilityCooldown>();
            DesiredSpeedWeight = EditorGUILayout.IntField("Desired Speed Weight: ", _character.GetComponent<Pawn>().SpeedWeight);
            DesiredPowerWeight = EditorGUILayout.IntField("Desired Power Weight: ", _character.GetComponent<Pawn>().PowerWeight);
            DesiredTechWeight = EditorGUILayout.IntField("Desired Tech Weight: ", _character.GetComponent<Pawn>().TechWeight);

            // apply values put in window to desired values
            _character.GetComponent<Pawn>().ApplyValues(DesiredPowerWeight, DesiredSpeedWeight, DesiredTechWeight);

            SpeedGood = false;
            PowerGood = false;
            TechGood = false;

            list = _abilitycooldown.abilities;

            int newCount = Mathf.Max(0, EditorGUILayout.IntField("Attribute number", list.Count));
            while (newCount < list.Count)
                list.RemoveAt(list.Count - 1);
            while (newCount > list.Count)
                list.Add(null);

            // sets the current actual weight of the abilities and attributes
            SpeedWeight = 0;
            PowerWeight = 0;
            TechWeight = 0;
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = (Ability)EditorGUILayout.ObjectField(list[i], typeof(Ability));
                if (list[i] != null)
                {
                    SpeedWeight += list[i].SpeedWeight;
                    PowerWeight += list[i].PowerWeight;
                    TechWeight += list[i].TechWeight;
                }
            }
            // commented out code to check all abilities the program is finding
            /*for (int i = 0; i < allAbilities.Count; i++)
            {
                allAbilities[i] = (Ability)EditorGUILayout.ObjectField(allAbilities[i], typeof(Ability));
            }  
            */  

            SpeedWeight = EditorGUILayout.FloatField("Current Speed Weight: ", SpeedWeight);
            PowerWeight = EditorGUILayout.FloatField("Current Power Weight: ", PowerWeight);
            TechWeight = EditorGUILayout.FloatField("Current Tech Weight: ", TechWeight);

            // individually checks each category if their weights meet the desierd weights
            if (SpeedWeight == DesiredSpeedWeight)
            {
                SpeedGood = true;
            }
            if (PowerWeight == DesiredPowerWeight)
            {
                PowerGood = true;
            }
            if (TechWeight == DesiredTechWeight)
            {
                TechGood = true;
            }

            if (SpeedGood && PowerGood && TechGood)
            {
                EditorGUILayout.HelpBox("Object is balanced!", MessageType.Warning);
            }
            else
            {
                Ability currentBest;
                float SpeedDifference = DesiredSpeedWeight - SpeedWeight;
                float PowerDifference = DesiredPowerWeight - PowerWeight;
                float TechDifference = DesiredTechWeight - TechWeight;
                PopulateAbilityList();
                for (int i = 0; i < allAbilities.Count; i++)
                {
                    if (allAbilities[i].SpeedWeight == SpeedDifference && allAbilities[i].PowerWeight == PowerDifference && allAbilities[i].TechWeight == TechDifference)
                    {
                        EditorGUILayout.HelpBox("Try adding " + allAbilities[i].AbilityName + "!", MessageType.Warning);
                        return;
                    }
                }
                EditorGUILayout.HelpBox("Try adding or creating a new ability!", MessageType.Warning);
            }
        }
    }

    // function to fill the full list of abilities to the menu's database
    void PopulateAbilityList()
    {
        string[] assetNames = AssetDatabase.FindAssets(null, new[] { "Assets/Abilities" });
        allAbilities = new List<Ability>();
        allAbilities.Clear();
            foreach (string SOName in assetNames)
            {
                var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
                var ability = AssetDatabase.LoadAssetAtPath<Ability>(SOpath);
                allAbilities.Add(ability);
            }
        
    }
}