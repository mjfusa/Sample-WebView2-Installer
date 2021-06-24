# Sample: Project Reunion - WebView2 Runtime Installer

## Description

This sample installs the [WebView2 Evergreen standalone installer](https://developer.microsoft.com/en-us/microsoft-edge/webview2/). This will install the WebView2 runtime in scenarios where the target machine does not have internet access.

## Projects

**LauncherWebViewCheck** This checks to see if the WebView2 runtime is installed. If it is not installed, it will call the installer - ```MicrosoftEdgeWebView2RuntimeInstallerX64.exe```.

**Note:** ```MicrosoftEdgeWebView2RuntimeInstallerX64.exe``` is included in the project - _**but is a text file!**_ Please replace this with a real ```MicrosoftEdgeWebView2RuntimeInstallerX64.exe``` downloaded from the link in the description. (This was done since it exceed the GitHub file size limit.).

The launcher uses the API [CoreWebView2Environment.GetAvailableBrowserVersionString()](https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2environment.getavailablebrowserversionstring?view=webview2-dotnet-1.0.864.35) to check if the WebView2 runtime is installed.

The launcher starts the main app via it's registered protocol (**samplewebview2**) as follows:

```C#
Process.Start(new ProcessStartInfo("samplewebview2:") { UseShellExecute = true });
```
**Sample-WebView2** This is the main app that hosts the WebView 2 control. You will see the default Microsoft.com page displayed. Clicking the button will launch the Twitter.com home page.

**Sample-WebView2-Installer (Package)** This packages both the launcher and the main app. Here are some key points about the Package.appxmanifest:





Project > Properties> Application tab > change Output type to "Windows application".

No more console window.













dsf













