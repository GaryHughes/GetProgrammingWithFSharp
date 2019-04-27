open System
open System.Net
open System.Windows.Forms

let browse (url : string) =
    let browser = 
        let fsharpOrg = 
            let webClient = new WebClient()
            webClient.DownloadString(Uri url)
        new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)
    let form = new Form(Text = "Hello from F#!")
    form.Controls.Add browser
    form.Show()

browse "http://fsharp.org"
