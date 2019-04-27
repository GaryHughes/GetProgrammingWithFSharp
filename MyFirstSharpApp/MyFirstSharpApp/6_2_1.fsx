
let mutable name = "isaac"
name <- "kate"

open System.Windows.Forms
let form = new Form()
form.Show()
form.Width <- 400
form.Height <- 400
form.Text <- "Hello from F#!"


let form2 = new Form(Text = "Hello From F#!", Width = 400, Height = 400)
form2.Show()