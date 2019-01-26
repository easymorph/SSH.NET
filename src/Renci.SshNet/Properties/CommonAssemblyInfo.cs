using System;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyDescription("EasyMorph's fork of SSH.NET.")]
//[assembly: AssemblyCompany("Renci")]
[assembly: AssemblyProduct("SSH.NET")]
//[assembly: AssemblyCopyright("Copyright © Renci 2010-2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("2016.1.3")]
[assembly: AssemblyFileVersion("2016.1.3")]
[assembly: AssemblyInformationalVersion("2016.1.3")]
[assembly: CLSCompliant(false)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]


#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif