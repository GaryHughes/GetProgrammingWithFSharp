
#I @"C:\Users\Gary Hughes\.nuget\packages"

#r @"NETStandard.Library\2.0.0\build\netstandard2.0\ref\netstandard.dll"
#r @"C:\Users\Gary Hughes\.nuget\packages\humanizer.core\2.6.2\lib\netstandard2.0\Humanizer.dll"
#r @"C:\Users\Gary Hughes\.nuget\packages\Newtonsoft.Json\12.0.2\lib\netstandard2.0\Newtonsoft.Json.dll"

open Humanizer

"ScriptsAreAGreatWayToExplorePackages".Humanize()

#load "Library.fs"

Library.getPerson()


