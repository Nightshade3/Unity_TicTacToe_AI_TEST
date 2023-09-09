using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainScripts
{
    public class Gamecontrollerold : MonoBehaviour
    {
        public Sprite playo, playx, playnull;

        private bool cooldown;
        public bool reset;
        private int cooldowntimer;
        public bool playerx, playero;
        public int X_Win_Num, O_Win_Num;

        public int wops1, wops2, wops3,
                   wops4, wops5, wops6,
                   wops7, wops8, wops9;   //who owns playspace 0 = no one 1 = player x 2 = player o

        public SpriteRenderer playspace1, playspace2, playspace3,
                              playspace4, playspace5, playspace6,
                              playspace7, playspace8, playspace9;

        public Button m_button1, m_button2, m_button3,//seperated for visuals 
                      m_button4, m_button5, m_button6,
                      m_button7, m_button8, m_button9;
        public Button UI_reset, UI_SelectX, UI_SelectO;
        public Text Xnum, Onum;

        // Start is called before the first frame update
        void Start()
        {

            // creating listers to acitvate on click of button
            m_button1.onClick.AddListener(Button1clicked);
            m_button2.onClick.AddListener(Button2clicked);
            m_button3.onClick.AddListener(Button3clicked);
            m_button4.onClick.AddListener(Button4clicked);
            m_button5.onClick.AddListener(Button5clicked);
            m_button6.onClick.AddListener(Button6clicked);
            m_button7.onClick.AddListener(Button7clicked);
            m_button8.onClick.AddListener(Button8clicked);
            m_button9.onClick.AddListener(Button9clicked);
            UI_reset.onClick.AddListener(Resetclicked);
            UI_SelectX.onClick.AddListener(selectedX);
            UI_SelectO.onClick.AddListener(selectedO);

        }

        // Update is called once per frame
        void Update()
        {
            if (cooldown == true)
            {
                cooldowntimer++;
                if (cooldowntimer == 1)
                {
                    cooldowntimer = 0;
                    cooldown = false;
                }

                if (wops1 == 1 && wops2 == 1 && wops3 == 1 ||
                     wops4 == 1 && wops5 == 1 && wops6 == 1 ||
                     wops7 == 1 && wops8 == 1 && wops9 == 1 ||
                     wops1 == 1 && wops5 == 1 && wops9 == 1 ||
                     wops7 == 1 && wops5 == 1 && wops3 == 1 ||
                     wops1 == 1 && wops3 == 1 && wops7 == 1 ||
                     wops2 == 1 && wops5 == 1 && wops8 == 1 ||
                     wops3 == 1 && wops6 == 1 && wops9 == 1)
                // all possible ways for x to win
                {

                    Debug.Log("player1 wins");
                    X_Win_Num++;
                    Xnum.text = "" + X_Win_Num;
                    reset = true;
                }

                if (wops1 == 2 && wops2 == 2 && wops3 == 2 ||
                     wops4 == 2 && wops5 == 2 && wops6 == 2 ||
                     wops7 == 2 && wops8 == 2 && wops9 == 2 ||
                     wops1 == 2 && wops5 == 2 && wops9 == 2 ||
                     wops7 == 2 && wops5 == 2 && wops3 == 2 ||
                     wops1 == 2 && wops3 == 2 && wops7 == 2 ||
                     wops2 == 2 && wops5 == 5 && wops8 == 2 ||
                     wops3 == 2 && wops6 == 5 && wops9 == 2)
                // all possible ways got o to win
                {
                    Debug.Log("player2 wins");
                    O_Win_Num++;

                    Onum.text = "" + O_Win_Num;
                    reset = true;
                }
                if (reset == true)
                {
                    Debug.Log("gamereset");
                    playspace1.sprite = playnull;
                    playspace2.sprite = playnull;
                    playspace3.sprite = playnull;
                    playspace4.sprite = playnull;
                    playspace5.sprite = playnull;
                    playspace6.sprite = playnull;
                    playspace7.sprite = playnull;
                    playspace8.sprite = playnull;
                    playspace9.sprite = playnull;
                    wops1 = 0;
                    wops2 = 0;
                    wops3 = 0;
                    wops4 = 0;
                    wops5 = 0;
                    wops6 = 0;
                    wops7 = 0;
                    wops8 = 0;
                    wops9 = 0;
                    playerx = false;
                    playero = false;
                    reset = false;
                }


            }
        }

        void Resetclicked()
        {
            reset = true;
        }

        void selectedX()
        {
            if (cooldown == false)
            {
                Debug.Log("playerselectedX");
                playerx = true;
                playero = false;
                cooldown = true;
            }
        }
        void selectedO()
        {
            Debug.Log("playerselectedO");
            if (cooldown == false)
            {
                playerx = false;
                playero = true;
                cooldown = true;
            }
        }
        //this is how the game knows what buttons have been pressed by who
        void Button1clicked()
        {

            if (playero == true && playerx == false && cooldown == false && wops1 == 0) // player can only activate if neither payer has pressed the button
            {
                playspace1.sprite = playo;//setting sprite to correct player
                playerx = true; // changing turn
                playero = false;
                cooldown = true;//cooldown to prevent problems
                wops1 = 2;//marking that the turn player has control of playspace
                Debug.Log("playero made move on 1");
            }
            if (playerx == true && playero == false && cooldown == false && wops1 == 0)
            {
                playspace1.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops1 = 1;
                Debug.Log("playerx made move on 1");
            }
            Debug.Log("you clicked button1");
        }
        void Button2clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops2 == 0)
            {
                playspace2.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops2 = 2;
                Debug.Log("playero made move on 2");
            }
            if (playerx == true && playero == false && cooldown == false && wops2 == 0)
            {
                playspace2.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops2 = 1;
                Debug.Log("playerx made move on 2");
            }
            Debug.Log("you cliked button2");
        }
        void Button3clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops3 == 0)
            {
                playspace3.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops3 = 2;
                Debug.Log("playero made move on 3");
            }
            if (playerx == true && playero == false && cooldown == false && wops3 == 0)
            {
                playspace3.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops3 = 1;
                Debug.Log("playerx made move on 1");
            }
            Debug.Log("you cliked button3");
        }
        void Button4clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops4 == 0)
            {
                playspace4.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops4 = 2;
                Debug.Log("playero made move on 4");
            }
            if (playerx == true && playero == false && cooldown == false && wops4 == 0)
            {
                playspace4.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops4 = 1;
                Debug.Log("playerx made move on 4");
            }
            Debug.Log("you cliked button4");
        }
        void Button5clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops5 == 0)
            {
                playspace5.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops5 = 2;
                Debug.Log("playero made move on 5");
            }
            if (playerx == true && playero == false && cooldown == false && wops5 == 0)
            {
                playspace5.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops5 = 1;
                Debug.Log("playerx made move on 5");
            }
            Debug.Log("you cliked button5");
        }
        void Button6clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops6 == 0)
            {
                playspace6.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops6 = 2;
                Debug.Log("playero made move on 6");
            }
            if (playerx == true && playero == false && cooldown == false && wops6 == 0)
            {
                playspace6.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops6 = 1;
                Debug.Log("playerx made move on 6");
            }
            Debug.Log("you cliked button6");
        }
        void Button7clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops7 == 0)
            {
                playspace7.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops7 = 2;
                Debug.Log("playero made move on 7");
            }
            if (playerx == true && playero == false && cooldown == false && wops7 == 0)
            {
                playspace7.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops7 = 1;
                Debug.Log("playerx made move on 7");
            }
            Debug.Log("you cliked button7");
        }
        void Button8clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops8 == 0)
            {
                playspace8.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops8 = 2;
                Debug.Log("playero made move on 8");
            }
            if (playerx == true && playero == false && cooldown == false && wops8 == 0)
            {
                playspace8.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops8 = 1;
                Debug.Log("playerx made move on 8");
            }
            Debug.Log("you cliked button8");
        }
        void Button9clicked()
        {
            if (playero == true && playerx == false && cooldown == false && wops9 == 0)
            {
                playspace9.sprite = playo;
                playerx = true;
                playero = false;
                cooldown = true;
                wops9 = 2;
                Debug.Log("playero made move on 9");
            }
            if (playerx == true && playero == false && cooldown == false && wops9 == 0)
            {
                playspace9.sprite = playx;
                playerx = false;
                playero = true;
                cooldown = true;
                wops9 = 1;
                Debug.Log("playerx made move on 9");
            }
            Debug.Log("you cliked button9");
        }

    }
}
