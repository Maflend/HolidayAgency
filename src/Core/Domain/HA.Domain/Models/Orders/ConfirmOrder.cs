namespace HA.Domain.Models.Orders;

public class ConfirmOrder : BaseOrder
{
    public string EventPlan { get; set; }
    public Dictionary<string, string> Peoples { get; set; }
    public new int CountPeople => Peoples.Count;
}
