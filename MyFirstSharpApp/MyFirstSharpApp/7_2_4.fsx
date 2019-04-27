
let writeTextToDisk text =
    let path = System.IO.Path.GetTempFileName()
    System.IO.File.WriteAllText(path, text)
    path

let createManyFiles() =
    ignore(writeTextToDisk "The quick brown fox jumped over the lazy dog")
    ignore(writeTextToDisk "The quick brown fox jumped over the lazy dog")
    ignore(writeTextToDisk "The quick brown fox jumped over the lazy dog")

createManyFiles()