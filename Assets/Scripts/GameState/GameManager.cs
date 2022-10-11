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

    public static int currentWave = 0;
    public static float patience = 60;
    public static float customersRemaining = 0;
    [HideInInspector] public int servedCustomers = 0; //Customers served
    [HideInInspector] public int spawnedCustomers = 0; //Total spawned this round
    [HideInInspector] public int totalCustomers = 0; //Total needed to be spawned this round
    [HideInInspector] public int currentCustomers = 0; //Customers still waiting in the store
    [HideInInspector] public int i = 0;
    [HideInInspector] public static float timeRemaining = 120;

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
        customersRemaining--;
        if (servedCustomers == totalCustomers) ChangeState(postWave);
    }

    public void BeginWave()
    {
        timeRemaining = 120;
        customersRemaining = totalCustomers;
        StartCoroutine(SpawnCustomers((int)waveProperties[currentWave].x, waveProperties[currentWave].y));
        currentWave++;
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
