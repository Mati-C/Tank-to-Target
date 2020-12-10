using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Console : MonoBehaviour
{

    public int DefaultTimeSpeed = 1;
    public float ConsoleTimeSpeed = 0.1f;

    public static Console console;

    public delegate void Function();
    public Function function;

    public Dictionary<string, Function> commands = new Dictionary<string, Function>();

    public Text backgroundText;
    public InputField inputText;
    public Scrollbar scrollBar;

    public GameObject consoleContent;

    #region Command Activation Checkers
    public static bool unlimitedFireRate;
    public static bool unlimitedAttempts;
    public static bool shotgunMode;
    public static bool slowMo;
    public static bool invincible;
    public static bool fastmo;
    public static bool allahuAkbar;
    #endregion

    public static bool ConsoleOpen = false;

    // Use this for initialization
    void Start()
    {

        consoleContent.SetActive(false);

        #region Commands
        NewCommand("unlimitedfirerate", UnlimitedFireRate);
        NewCommand("unlimitedattempts", UnlimitedAttempts);
        NewCommand("shotgunmode", ShotgunMode);
        NewCommand("slowmo", SlowMo);
        NewCommand("madness", Madness);
        NewCommand("refillarmor", RefillArmor);
        NewCommand("extralife", ExtraLife);
        NewCommand("invincible", Invincible);
        NewCommand("fastmo", FastMo);
        NewCommand("allahu akbar", AllahuAkbar);

        unlimitedFireRate = false;
        unlimitedAttempts = false;
        shotgunMode = false;
        slowMo = false;
        invincible = false;
        fastmo = false;
        allahuAkbar = false;
        #endregion
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Insert)) OpenOrCloseConsole();

        #region Console State

        if (consoleContent.activeSelf == true)
        {
            Time.timeScale = ConsoleTimeSpeed;
            ConsoleOpen = true;
        }

        else if (consoleContent.activeSelf == false)
        {

            Time.timeScale = DefaultTimeSpeed;
            ConsoleOpen = false;
        }


        #endregion

        if (consoleContent.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            InstantiateCommand();
        }
    }

    public void FixScroll()
    {
        scrollBar.value = 0;
        inputText.Select();
    }

    public void NewCommand(string name, Function command)
    {
        commands[name] = command;
    }

    #region Command Actions
    public void UnlimitedFireRate()
    {
        Write("Unlimited Fire Rate Activated/Deactivated");
        unlimitedFireRate = !unlimitedFireRate;
    }

    public void UnlimitedAttempts()
    {
        Write("Unlimited Attempts Activated/Deactivated");
        unlimitedAttempts = !unlimitedAttempts;
    }

    public void ShotgunMode()
    {
        Write("Shotgun Mode Activated/Deactivated");
        shotgunMode = !shotgunMode;
    }

    public void SlowMo()
    {
        Write("Slow-Mo Activated/Deactivated");
        slowMo = !slowMo;
    }

    public void Madness()
    {
        Write("Loading Madness Level...");
        SceneManager.LoadScene(14);
    }

    public void FastMo()
    {
        Write("Extra Speed Activated/Deactivated");
        fastmo = !fastmo;
    }

    public void ExtraLife()
    {
        Write("Extra Life Added");
        Main.remainingAttempts++;
    }

    public void RefillArmor()
    {
        Write("Armor Maxed Out");
        Tank.life = 10;
    }

    public void Invincible()
    {
        Write("Invincible Mode Activated/Deactivated");
        invincible = !invincible;
    }

    public void AllahuAkbar()
    {
        Write("Get ready for a blast!");
        allahuAkbar = !allahuAkbar;
    }
    #endregion

    public void Write(string text)
    {
        backgroundText.text += "\n" + text;
    }

    public void OpenOrCloseConsole()
    {
        consoleContent.SetActive(!consoleContent.activeSelf);
    }

    public void InstantiateCommand()
    {
        string commandName = inputText.text;
        if (commands.ContainsKey(commandName))
        {
            commands[inputText.text].Invoke();
            inputText.text = null;
        }
        else
        {
            Write("Invalid Command");
            inputText.text = null;

        }

        Invoke("FixScroll", 0.2f);
    }


}
