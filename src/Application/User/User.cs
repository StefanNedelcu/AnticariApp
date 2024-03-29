﻿namespace AnticariApp.Application.User;

public class User
{
    public long IdUser { get; set; }

    public string Email { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public Statistics Statistics { get; set; }

    public DateTime CreatedAt { get; set; }
}
