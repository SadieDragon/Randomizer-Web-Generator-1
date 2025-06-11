
This is a suggestion from DraconusLupa (sadie_dragon) on how to refactor the
file `LogicFunctions.cs`.

I have, at the time of writing this, less than a year's worth of experience
with C#. All of it comes from reading and writing code and refactors for this
project.

I am thus not claiming to be better, or smarter, or more correct than anyone.
This project is more of a practice for me on how to refactor for my main
projects, given it is a much more complex project than I have ever worked on,
and all of my code is hard to find good refactors for.

I am going to aim for a bit of a pyramid of isolation. To try to simulate
Python packaging as much as I can in C#.
```
TPRandomizerProvider.cs -> Implements fns for the bridges; injects from bridges
TPRToLFBridge.cs        -> Creates interfaces for LF to access TPR vars and fns
LFToTPRBridge.cs        -> Creates interfaces for TPR to access LF vars and fns
[The entirety of LF]    -> Isolated logic functions
```
