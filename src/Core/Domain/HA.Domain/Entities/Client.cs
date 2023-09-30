﻿using HA.Domain.Common;

namespace HA.Domain.Entities;

/// <summary>
/// Клиент.
/// </summary>
public class Client : Entity
{
    private Client() { }

    public Client(string name, string surname, string phone, string? patronymic = null)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        Phone = phone;
    }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; protected set; }

    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; protected set; }

    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; protected set; }

    /// <summary>
    /// Телефон.
    /// </summary>
    public string Phone { get; protected set; }
}
