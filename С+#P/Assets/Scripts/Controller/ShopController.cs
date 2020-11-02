using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] Text moneyAmountText;

    [SerializeField] Button buyBtnGan;
    [SerializeField] Button buyBtnUzimatic;
    [SerializeField] Button buyBtnAK47;
    [SerializeField] Button buyBtnSniper;
    [SerializeField] Button buyBtnGrenade;
    [SerializeField] Button buyBtnMinigan;
    [SerializeField] Button btnPlay;

    [SerializeField] int buyGan;
    [SerializeField] int buyUzimatic;
    [SerializeField] int buyAK47;
    [SerializeField] int buySniper;
    [SerializeField] int buyGtenade;
    [SerializeField] int buyMinigan;

    private GameManager gameManager;

    int indexWeapon;
    int moneyAmount; 

    void Start()
    {
        gameManager = GameManager.instance;
        moneyAmount = PlayerPrefs.HasKey("Money") ? PlayerPrefs.GetInt("Money") :0;
        indexWeapon = PlayerPrefs.HasKey("Weapon") ? PlayerPrefs.GetInt("Weapon") :0;
    }

    void Update()
    {
        moneyAmountText.text = "Money: " + moneyAmount.ToString() + " $";        
       
        if (moneyAmount>= buyGan )        
            buyBtnGan.interactable = true;        
        else        
            buyBtnGan.interactable = false;
        
        if (moneyAmount >= buyUzimatic) 
            buyBtnUzimatic.interactable = true;        
        else
            buyBtnUzimatic.interactable = false;
        
        if (moneyAmount >= buyAK47)        
            buyBtnAK47.interactable = true;        
        else
            buyBtnAK47.interactable = false;

        if (moneyAmount >= buySniper)        
            buyBtnSniper.interactable = true;        
        else
            buyBtnSniper.interactable = false;

        if (moneyAmount >= buyGtenade)        
            buyBtnGrenade.interactable = true;        
        else
            buyBtnGrenade.interactable = false;

        if (moneyAmount >= buyMinigan)        
            buyBtnMinigan.interactable = true;        
        else
            buyBtnMinigan.interactable = false;

            ControllerBuyWeapon();

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            resetPlayerPrefs();
        }
        
    }
    public void BuyGan()
    {
        moneyAmount -= buyGan;             
        indexWeapon = 0;
        PlayerPrefs.SetInt("Weapon", indexWeapon);
        ///PlayerPrefs.Save();
        buyBtnGan.gameObject.SetActive(false);
    }
    public void BuyUzimatic()
    {
        moneyAmount -= buyUzimatic;
        indexWeapon = 1;
        PlayerPrefs.SetInt("Weapon", indexWeapon);
        buyBtnUzimatic.gameObject.SetActive(false);
    }
    public void BuyAK47()
    {
        moneyAmount -= buyAK47;
        indexWeapon = 2;
        PlayerPrefs.SetInt("Weapon", indexWeapon);
        buyBtnAK47.gameObject.SetActive(false);
    }
    public void BuySniper()
    {
        moneyAmount -= buySniper;
        indexWeapon = 3;
        PlayerPrefs.SetInt("Weapon", indexWeapon);
        buyBtnSniper.gameObject.SetActive(false);
    }
    public void BuyGrenade()
    {
        moneyAmount -= buyGtenade;
        indexWeapon = 4;
        PlayerPrefs.SetInt("Weapon", indexWeapon);
        buyBtnGrenade.gameObject.SetActive(false);
    }
    public void BuyMinigan()
    {
        moneyAmount -= buyMinigan;
        indexWeapon = 5;
        PlayerPrefs.SetInt("Weapon", indexWeapon);
        buyBtnMinigan.gameObject.SetActive(false);
    }

    public void playGame()
    {
        PlayerPrefs.SetInt("Money", moneyAmount);    
        SceneManager.LoadScene("Level1");           
    }

    void ControllerBuyWeapon()    
    {
        if(indexWeapon == 0)
        buyBtnGan.gameObject.SetActive(false);

        if(indexWeapon == 1){
        buyBtnGan.gameObject.SetActive(false);
        buyBtnUzimatic.gameObject.SetActive(false);
        }

        if(indexWeapon == 2){
        buyBtnGan.gameObject.SetActive(false);
        buyBtnUzimatic.gameObject.SetActive(false);
        buyBtnAK47.gameObject.SetActive(false);
        }

        if(indexWeapon == 3){
        buyBtnGan.gameObject.SetActive(false);
        buyBtnUzimatic.gameObject.SetActive(false);
        buyBtnAK47.gameObject.SetActive(false);
        buyBtnSniper.gameObject.SetActive(false);
        }

        if(indexWeapon == 4){
        buyBtnGan.gameObject.SetActive(false);
        buyBtnUzimatic.gameObject.SetActive(false);
        buyBtnAK47.gameObject.SetActive(false);
        buyBtnSniper.gameObject.SetActive(false);
        buyBtnGrenade.gameObject.SetActive(false);
        }

        if(indexWeapon == 5){
        buyBtnGan.gameObject.SetActive(false);
        buyBtnUzimatic.gameObject.SetActive(false);
        buyBtnAK47.gameObject.SetActive(false);
        buyBtnSniper.gameObject.SetActive(false);
        buyBtnGrenade.gameObject.SetActive(false);
        buyBtnMinigan.gameObject.SetActive(false);
        }
        
    }
    void resetPlayerPrefs()
    {
        moneyAmount = 0;
        
        buyBtnUzimatic.gameObject.SetActive(true);
        buyBtnAK47.gameObject.SetActive(true);
        buyBtnSniper.gameObject.SetActive(true);
        buyBtnGrenade.gameObject.SetActive(true);
        buyBtnMinigan.gameObject.SetActive(true);
        PlayerPrefs.DeleteAll();
    }
}
