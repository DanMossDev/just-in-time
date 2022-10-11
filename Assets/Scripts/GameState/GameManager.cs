using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [Space]
    [Header("Wave Options")]
    [Tooltip("X - Number of customers spawned | Y - Delay between customer spawns | Z - Patience for this wave")]
    public Vector3[] waveProperties;
    [Tooltip("Maximum number of customers that can be waiting at a given time")]
    [SerializeField] int maxCustomers = 3;
    [Tooltip("The prefabs of the customers")]
    [SerializeField] GameObject[] customers;

    [HideInInspector] public int currentWave = 0;
    [HideInInspector] public static float patience = 60;
    [HideInInspector] public int servedCustomers = 0; //Customers served
    [HideInInspector] public int spawnedCustomers = 0; //Total spawned this round
    [HideInInspector] public int totalCustomers = 0; //Total needed to be spawned this round
    [HideInInspector] public int currentCustomers = 0; //Customers still waiting
    [HideInInspector] public int i = 0;

    //States
    public GameState currentState;
    public GamePreWaveState preWave = new GamePreWaveState();
    public GameWaveState wave = new GameWaveState();
    public GamePostWaveState postWave = new GamePostWaveState();
    public GameOverState gameOver = new GameOverState();

    void Start()
    {
        currentState = preWave;
        currentState.EnterState(this);

        Invoke("OnStart", 5);
    }

    void OnEnable() {
        CustomerLeaveState.OnCustomerServed += CustomerServed;
    }

    void OnDisable() {
        CustomerLeaveState.OnCustomerServed -= CustomerServed;
    }

    void Update()
    {
        print(currentState.ToString());
        currentState.UpdateState(this);
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    void OnStart()
    {
        if (currentState == preWave) ChangeState(wave);
    }

    void CustomerServed()
    {
        servedCustomers++;
        currentCustomers--;

        if (servedCustomers == totalCustomers) ChangeState(postWave);
    }

    public void BeginWave()
    {
        StartCoroutine(SpawnCustomers((int)waveProperties[currentWave].x, waveProperties[currentWave].y));
    }

    IEnumerator SpawnCustomers(int count, float delay)
    {
        while (i < totalCustomers)
        {
            if (currentCustomers < maxCustomers) 
            {
                Instantiate(customers[Random.Range(0, customers.Length - 1)]);
                currentCustomers++;
                i++;
             yield return new WaitForSecondsRealtime(delay);
            } else yield return new WaitForSecondsRealtime(1);
        }
    }
}
