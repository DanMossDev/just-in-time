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
    [Space]
    [Header("Prefabs for states")]
    public GameObject gameOverScreen;
    public GameObject postWaveScreen;

    [HideInInspector] public int currentWave = 0;
    [HideInInspector] public float patience;
    [HideInInspector] public float customersRemaining = 0;
    [HideInInspector] public int servedCustomers = 0; //Customers served
    [HideInInspector] public int spawnedCustomers = 0; //Total spawned this round
    [HideInInspector] public int totalCustomers = 0; //Total needed to be spawned this round
    [HideInInspector] public int currentCustomers = 0; //Customers still waiting in the store
    [HideInInspector] public int i = 0;
    [HideInInspector] public float timeRemaining = 120;

    //States
    public GameState currentState;
    public GamePreWaveState preWave = new GamePreWaveState();
    public GameWaveState wave = new GameWaveState();
    public GamePostWaveState postWave = new GamePostWaveState();
    public GameOverState gameOver = new GameOverState();

    //Singleton
    public static GameManager Instance {get; private set;}

    void Awake() {
        if (Instance != null && Instance != this) Destroy(this); 
        else Instance = this;
    }

    void Start()
    {
        currentState = preWave;
        currentState.EnterState(this);
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

    public void OnStart()
    {
        StartCoroutine(WaveCountDown());
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

    IEnumerator WaveCountDown()
    {
        yield return new WaitForSecondsRealtime(3);
        if (currentState == preWave) ChangeState(wave);
    }

    IEnumerator SpawnCustomers(int count, float delay)
    {
        while (i < totalCustomers)
        {
            if (currentCustomers < maxCustomers) 
            {
                GameObject customer = CustomerPool.Instance.customers[Random.Range(0, CustomerPool.Instance.customers.Count)];
                customer.transform.position = transform.position;
                customer.SetActive(true);
                CustomerPool.Instance.customers.Remove(customer);
                currentCustomers++;
                i++;
                yield return new WaitForSecondsRealtime(delay);
            } else yield return new WaitForSecondsRealtime(1);
        }
    }
}
