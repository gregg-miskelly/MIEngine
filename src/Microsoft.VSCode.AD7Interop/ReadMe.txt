----------------------------------------
About Microsoft.VSCode.AD7Interop
----------------------------------------

This assembly is a design-time assembly (meaning that it is used during building, but 
its types are embedded in assemblies that use it) and therefore isn't used at runtime.
It defines interfaces to be used between the OpenDebugAD7 project and debug engines that
it hosts. It has marshalling directives so that it could someday potentially host 
native-implemented debug engines on Windows, though it currently doesn't do so.

Microsoft.VSCode.AD7Interop.cs should be kept in sync between this project and any 
project that might use it.
