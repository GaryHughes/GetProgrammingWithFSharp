#r @"C:\Users\Gary Hughes\.nuget\packages\NETStandard.Library\2.0.0\build\netstandard2.0\ref\netstandard.dll"
#r @"C:\Users\Gary Hughes\Documents\git\GetProgrammingWithFSharp\MyFirstSharpApp\CSharpProject\bin\Debug\netstandard2.0\CSharpProject.dll"

open CSharpProject

let simon = CSharpProject.Person "Simon"
simon.PrintName()


