﻿namespace Domain;

public class Match
{
    public int Id { get; set; }
    public int Team1Id { get; set; }
    public Team Team1 { get; set; }

    public int Team2Id { get; set; }
    public Team Team2 { get; set; }

    public string Result { get; set; }
}
