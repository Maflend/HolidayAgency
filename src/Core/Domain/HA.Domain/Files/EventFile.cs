using HA.Domain.Common;

namespace HA.Domain.Files;

/// <summary>
/// Файл мероприятия.
/// </summary>
public class EventFile : Entity
{
    /// <summary>
    /// Уникальное имя файла.
    /// </summary>
    public Guid Name { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Оригинальное имя файла.
    /// </summary>
    public required string OriginalName { get; set; }

    /// <summary>
    /// Путь.
    /// </summary>
    /// TODO: Файлы возможно будем хранить в S3 хранилище, и пути не будет.
    public required string Path { get; set; }

    /// <summary>
    /// Идентификатор выполненного заказа.
    /// </summary>
    public Guid CompletedOrderId { get; set; }
}
