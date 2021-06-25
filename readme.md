# Sample: Project Reunion - WebView2 Runtime Installer

## Description

This sample installs the [WebView2 Evergreen standalone installer](https://developer.microsoft.com/en-us/microsoft-edge/webview2/). This will install the WebView2 runtime in scenarios where the target machine does not have internet access.

## Built with

* [Visual Studio 2019 Version 16.10.2](https://visualstudio.com)

* [Windows App SDK (0.5.7)](https://github.com/microsoft/WindowsAppSDK) (Aka Project Reunion)

* [Project Reunion Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftProjectReunion)

* .NET 5 (5.0.7)



## Projects

**LauncherWebViewCheck** This checks to see if the WebView2 runtime is installed. If it is not installed, it will call the installer - ```MicrosoftEdgeWebView2RuntimeInstallerX64.exe```.

**Note:** ```MicrosoftEdgeWebView2RuntimeInstallerX64.exe``` is included in the project - _**but is a text file!**_ Please replace this with a real ```MicrosoftEdgeWebView2RuntimeInstallerX64.exe``` downloaded from the link in the description. (This was done since it exceed the GitHub file size limit.).

Some key points about the project file:

 ```XML
  <PropertyGroup>
    <OutputType>WinExe</OutputType>     <!-- Default is Exe for console all. Setting to WinExe prevents the console window from showing. -->
    <TargetFramework>net5.0</TargetFramework>
    <Platforms>x86;x64</Platforms>     <!-- This is required for .NET to know which platforms to target. -->
  </PropertyGroup>
  ```

The launcher uses the API [CoreWebView2Environment.GetAvailableBrowserVersionString()](https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2environment.getavailablebrowserversionstring?view=webview2-dotnet-1.0.864.35) to check if the WebView2 runtime is installed.

The launcher starts the main app via it's registered protocol (**samplewebview2**) as follows:

```C#
Process.Start(new ProcessStartInfo("samplewebview2:") { UseShellExecute = true });
```
**Sample-WebView2** This is the main app that hosts the WebView 2 control. You will see the default Microsoft.com page displayed. Clicking the button will launch the Twitter.com home page.

**Sample-WebView2-Installer (Package)** This packages both the launcher and the main app. Here are some key points about the Package.appxmanifest:

```XML
  <Applications> <!-- First of two applications. First is the launcher app, the Second is the main app -->
    <Application Id="App"
      Executable="$targetnametoken$.exe" 
      EntryPoint="$targetentrypoint$"> <!-- Launcher app -->
      <uap:VisualElements
        DisplayName="Sample-WebView2-Installer (Package)"
        Description="Sample-WebView2-Installer (Package)"
        BackgroundColor="transparent"
        Square150x150Logo="Images\Square150x150Logo.png"
        Square44x44Logo="Images\Square44x44Logo.png">
        <uap:DefaultTile Wide310x150Logo="Images\Wide310x150Logo.png" />
        <uap:SplashScreen Image="Images\SplashScreen.png" />
      </uap:VisualElements>
    </Application>
	  <Application Id="Webview2App" Executable="Sample-Webview2\Sample-Webview2.exe" EntryPoint="Windows.FullTrustApplication"> <!-- Main app. This entry in the manifest had me be manually added.  -->
			  <uap:VisualElements
    			AppListEntry = "none"
				DisplayName="Webview2App"
				Description="Webview2App"
				BackgroundColor="transparent"
				Square150x150Logo="Images\Square150x150Logo.png"
				Square44x44Logo="Images\Square44x44Logo.png">
				  <uap:DefaultTile Wide310x150Logo="Images\Wide310x150Logo.png" />
				  <uap:SplashScreen Image="Images\SplashScreen.png" />
			  </uap:VisualElements>
			  <!--Protocol for launcher to start main app (this app)-->
			  <Extensions>
				  <uap:Extension Category="windows.protocol"> <!-- This is the protocol that the launcher uses to launch the main app. -->
					  <uap:Protocol Name="samplewebview2"/>
				  </uap:Extension>
			  </Extensions>
		  </Application>
  </Applications>
```
