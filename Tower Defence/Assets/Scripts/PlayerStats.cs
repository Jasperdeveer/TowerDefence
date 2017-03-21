using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    private int startMoney = 1000;
    public int StartMoney { get{return this.startMoney;} set{this.startMoney = value;} }

    public static int Lives;
    private int startLives = 10;
	public int StartLives { get{return this.startLives;} set{this.startLives = value;} }

    public static int Rounds;



    void Start()
    {
        Money = StartMoney;
        Lives = StartLives;

        Rounds = 0;

    }
}
