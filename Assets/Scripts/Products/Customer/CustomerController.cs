using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    [SerializeField] Transform waitingArea;
    [SerializeField] Transform spawnPoint;
    CustomerOrder order;
    NavMeshAgent navMeshAgent;
    CustomerState currentState;
    public CustomerEnteringState EnterState = new CustomerEnteringState();
    public CustomerWaitState WaitState = new CustomerWaitState();
    public CustomerLeaveState LeaveState = new CustomerLeaveState();
    public CustomerGameOverState GameOver = new CustomerGameOverState();

    void Awake() 
    {
        order = GetComponent<CustomerOrder>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void OnEnable() 
    {
        currentState = EnterState;
        currentState.EnterState(this);
        navMeshAgent.destination = waitingArea.position;
    }

    void Update()
    {
        currentState.UpdateState(this, order);
    }
    public void Leave()
    {
        if (currentState == WaitState) WaitState.Leave(this);
    }

    public void SwitchState(CustomerState state)
    {
        if (state == LeaveState) navMeshAgent.destination = spawnPoint.position;
        currentState = state;
        state.EnterState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
}
