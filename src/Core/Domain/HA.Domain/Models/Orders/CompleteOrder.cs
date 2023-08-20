namespace HA.Domain.Models.Orders;

public class CompleteOrder : BaseOrder
{
    public string EventPlan { get; set; }
    public Dictionary<string, string> Peoples { get; set; }
    public new int CountPeople => Peoples.Count;

    public List<EventFile> Files { get; set; }

    //Отзывы.
}