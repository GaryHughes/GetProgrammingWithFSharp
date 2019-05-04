﻿type FootballResult =
    {   HomeTeam : string
        AwayTeam : string
        HomeGoals : int
        AwayGoals : int }

let create (ht, hg) (at, ag) =
    { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag }

let results =
    [   create("Messiville", 1) ("Ronaldo City", 2)
        create("Messiville", 1) ("Bale Town", 3)
        create("Bale Town", 3) ("Ronaldo City", 1)
        create("Bale Town", 2) ("Messiville", 2)
        create("Ronaldo City", 4) ("Messiville", 2)
        create("Ronaldo City", 1) ("Bale Town", 2)  ]


open System.Collections.Generic

type TeamSummary = { Name : string; mutable AwayWins : int }

let summary = ResizeArray<TeamSummary>()

for result in results do
    if result.AwayGoals > result.HomeGoals then
        let mutable found = false
        for entry in summary do
            if entry.Name = result.AwayTeam then
                found <- true
                entry.AwayWins <- entry.AwayWins + 1
        if not found then
            summary.Add { Name = result.AwayTeam; AwayWins = 1 }

let comparer =
    {   new IComparer<TeamSummary> with
            member this.Compare(x, y) =
                if x.AwayWins > y.AwayWins then -1
                elif x.AwayWins < y.AwayWins then 1
                else 0  }

summary.Sort(comparer)


let isAwayWIn result = result.AwayGoals > result.HomeGoals

results 
|> List.filter isAwayWIn 
|> List.countBy(fun result -> result.AwayTeam) 
|> List.sortByDescending(fun (_, awayWins) -> awayWins)
