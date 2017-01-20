# school-assignment-reminders

Basically, just a simple to-do list centered around turning in school assignments written in WPF.

### Demo 

![demo](http://i.imgur.com/Db1sQGO.gif)  

---

## Features 

Add/remove classes and assignments, show the date from now until their due date. Meant to be very basic.

## Shortcuts

**Alt+=**: Create a new class.  

---

### Build & Run

**Requirements:** [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe) on PATH, Visual Studio 2015 and/or C# 6.0 Roslyn Compiler  
**Optional:** Devenv (Visual Studio 2015) on PATH  

```
git clone https://github.com/dukemiller/school-assignment-reminders/
cd school-assignment-reminders
nuget install school-assignment-reminders\packages.config -OutputDirectory packages
```  

**Building with Devenv (CLI):** ``devenv school-assignment-reminders.sln /Build``  
**Building with Visual Studio:**  Open (Ctrl+Shift+O) "school-assignment-reminders.sln", Build Solution (Ctrl+Shift+B)

A "school-assignment-reminders.exe" artifact will be created in the parent school-assignment-reminders folder.
