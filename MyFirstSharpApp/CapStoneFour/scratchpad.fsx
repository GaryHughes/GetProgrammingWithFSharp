#load "Domain.fs"
#load "Auditing.fs"
#load "Operations.fs"
#load "Commands.fs"

open Operations
open Domain
open System
open Commands


tryParseCommand 'd'
tryParseCommand 'w'
tryParseCommand 'x'
tryParseCommand 'a'


