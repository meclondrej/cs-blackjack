A simple terminal blackjack. This time in C#.

## Precompiled

To use the precompiled app, simply download one from the releases.

## Self compiled

You will need dotnet. You can download it here: [https://dotnet.microsoft.com/en-us/](https://dotnet.microsoft.com/en-us/)

Then run this command in the project folder: ```dotnet publish --no-self-contained -r <RUNTIME_ID>```,
where ```<RUNTIME_ID>``` should be the RID (more info [here](https://learn.microsoft.com/en-us/dotnet/core/rid-catalog)).

For example: ```dotnet publish --no-self-contained -r win10-x64```
