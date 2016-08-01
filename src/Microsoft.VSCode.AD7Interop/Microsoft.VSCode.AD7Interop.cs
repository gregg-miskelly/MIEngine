// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Debugger.Interop;

namespace Microsoft.VSCode.AD7Interop
{
    /// <summary>
    /// TODO
    /// </summary>
    [ComImport()]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("8A6EC1FC-76F4-4E7B-8CBE-E44B1B124696")]
    public interface IDebugVSCodeEngineLaunch
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="args"></param>
        /// <param name="error"></param>
        /// <param name="process"></param>
        /// <returns></returns>
        [PreserveSig]
        int Launch(dynamic args, out IDebugVSCodeError error, out IDebugProcess2 process);

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="args"></param>
        /// <param name="error"></param>
        /// <param name="process"></param>
        /// <returns></returns>
        [PreserveSig]
        int Attach(dynamic args, out IDebugVSCodeError error, out IDebugProcess2 process);
    }

    /// <summary>
    /// Repesents a VS Code error response body to be returned to VS Code
    /// </summary>
    [ComImport()]
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FC0F0CA3-52E9-45A7-BE42-D3A704C90E7C")]
    public interface IDebugVSCodeError
    {
        /// <summary>
        /// TODO
        /// </summary>
        int Code { get; }

        /// <summary>
        /// TODO
        /// </summary>
        string Message
        {
            [return:MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary>
        /// True if 'Message' contains Personally Identifiable Information (PII) that should not be sent to telemetry
        /// </summary>
        bool HasPII
        {
            [return:MarshalAs(UnmanagedType.Bool)]
            get;
        }
    }
}
