open System.IO

type Folder = {
    Name : string
    Size : int64
    NumberOfFiles : int
    AverageFileSize : float
    FileExtensions : string list
}

let root = @"C:\Program Files"

let summariseFolder (dirInfo:DirectoryInfo) = 
    Directory.EnumerateFiles(dirInfo.FullName) 
    |> Seq.fold
        (fun (sizes, extensions) file ->
            let fileInfo = FileInfo(file)
            (sizes @ [fileInfo.Length], extensions @ [fileInfo.Extension]) 
        ) ([], [])
    |> fun (sizes, extensions) -> 
        {
            Name = dirInfo.FullName;
            Size = sizes |> List.sum;
            NumberOfFiles = sizes.Length;
            AverageFileSize = 
                match sizes with
                | [] -> 0.0
                | _ -> sizes |> List.averageBy float;
            FileExtensions = extensions
        }
    
let subfolders = 
    Directory.EnumerateDirectories(root)    
    |> Seq.map(fun path -> DirectoryInfo(path))
    |> Seq.map(fun info -> summariseFolder info)  
    
    



