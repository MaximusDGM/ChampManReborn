﻿namespace ChampManReborn.Domain.Entities;

public class Person
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Age { get; set; }

}