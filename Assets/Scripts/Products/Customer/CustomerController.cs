using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerController : MonoBehaviour
{
    Transform waitingArea;
    Transform leavePoint;
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
        currentState.EnterState(this, order);
        waitingArea = WaitingArea.waitingArea;
        leavePoint = LeavePoint.leavePoint;
        Vector3 range = waitingArea.GetComponent<BoxCollider>().size / 2;
        navMeshAgent.destination = waitingArea.position + new Vector3(Random.Range(-range.x, range.x), 0, Random.Range(-range.z, range.z));
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
        if (state == LeaveState) navMeshAgent.destination = leavePoint.position;
        currentState = state;
        state.EnterState(this, order);
    }

    void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }
}
