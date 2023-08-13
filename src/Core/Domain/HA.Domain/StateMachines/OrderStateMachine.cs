using HA.Domain.Enums;
using HA.Domain.Models;

namespace HA.Domain.StateMachines;
public static class OrderStateMachine
{
    public static void MoveNextState(this Order order)
    {
        var currentState = order.State;

        switch(currentState)
        {
            case OrderState.New:
                order.State = OrderState.Confirmed;
                break;
            case OrderState.Confirmed:
                order.State = OrderState.Completed;
                break;
        }
    }
}
