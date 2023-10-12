﻿namespace BaltaAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}