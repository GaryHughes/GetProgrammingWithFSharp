open System

let buildDt year month day = DateTime(year, month, day)
//let buildDtThisYear month day = buildDt DateTime.UtcNow.Year month day
//let buildDtThisMonth day = buildDtThisYear DateTime.UtcNow.Month day

let buildDtThisYear = buildDt DateTime.UtcNow.Year
let buildDtThisMonth = buildDtThisYear DateTime.UtcNow.Month

buildDtThisMonth DateTime.UtcNow.Day



let writeToFile (date:DateTime) filename text =
    System.IO.File.WriteAllText(sprintf "C:\\TEMP\\%s-%s.txt" (date.ToString "yyMMdd") filename, text)

let writeToToday = writeToFile DateTime.UtcNow.Date
let writeToTomorrow = writeToFile (DateTime.UtcNow.Date.AddDays 1.)
let writeToTodayHelloWorld = writeToToday "hello-world"

writeToToday "first-file" "The quick brown fox jumped over the lazy dog"
writeToTomorrow "first-file" "The quick brown fox jumped over the lazy dog"
writeToTodayHelloWorld "The quick brown fox jumped over the lazy dog"



let checkCreation date =
    Console.WriteLine(date.ToString())

IO.Directory.GetCurrentDirectory() |> IO.Directory.GetCreationTime |> checkCreation


