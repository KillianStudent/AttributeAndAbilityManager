using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public string abilityButtonAxisName = "Fire1";
    public Image darkMask;
    public Text coolDownTextDisplay;

    public List<Ability> abilities;
    [SerializeField] private GameObject abilityHolder;
    private Image myButtonImage;
    private AudioSource abilitySource;
    private float coolDownDuration;
    private float nextReadyTime;
    private float coolDownTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Ability _ability in abilities)
        {
            Initialize(_ability, abilityHolder);
        }
        //Initialize(ability, abilityHolder);
    }

    public void Initialize(Ability selectedAbility, GameObject abilityHolder)
    {
        selectedAbility.Initialize(abilityHolder);
        //ability = selectedAbility;
        /*myButtonImage = GetComponent<Image>();
        abilitySource = GetComponent<AudioSource>();
        myButtonImage.sprite = ability.aSprite;
        darkMask.sprite = ability.aSprite;*/
        //coolDownDuration = ability.aBaseCoolDown;
        //ability.Initialize(abilityHolder);
        //AbilityReady();
    }

    // Update is called once per frame
    void Update()
    {
        bool coolDownComplete = (Time.time > nextReadyTime);
        if (coolDownComplete)
        {
            AbilityReady();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ButtonTriggered1();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //ButtonTriggered2();
            }
        }
        else
        {
            CoolDown();
        }
    }
    
    private void AbilityReady()
    {
        /*coolDownTextDisplay.enabled = false;
        darkMask.enabled = false;*/
    }

    private void CoolDown()
    {
        coolDownTimeLeft -= Time.deltaTime;
        float roundedCd = Mathf.Round(coolDownTimeLeft);
        /*coolDownTextDisplay.text = roundedCd.ToString();
        darkMask.fillAmount = coolDownTimeLeft / coolDownDuration;*/
    }

    private void ButtonTriggered1()
    {
        nextReadyTime = coolDownDuration = Time.time;
        coolDownTimeLeft = coolDownDuration;
        /*darkMask.enabled = true;
        coolDownTextDisplay.enabled = true;

        abilitySource.clip = ability.aSound;
        abilitySource.Play();*/
        abilities[0].TriggerAbility();
    }
}
