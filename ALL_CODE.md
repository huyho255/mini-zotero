# MiniZotero - All Code

Generated from the current workspace source files. Build output, IDE folders, node_modules, and Git internals are excluded.

## .gitattributes

``gitattributes
* text=auto

# Keep GitHub language stats focused on C#.
* linguist-vendored
*.cs linguist-vendored=false linguist-language=C#

````

## .gitignore

``gitignore
bin/
obj/
.vs/
*.user
*.suo
*.userosscache
*.sln.docstates

# Build output
[Bb]in/
[Oo]bj/

# Rider
.idea/

# Visual Studio Code
.vscode/

# Node packages used only to vendor PDF.js assets.
node_modules/

````

## AGENTS.md

``markdown
# Repository rules

- After every code change, update `ALL_CODE.md` so it reflects the current project code.

````

## MiniZotero.sln

``text

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.14.36518.9 d17.14
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "MiniZotero", "MiniZotero\MiniZotero.csproj", "{8C38B81B-B5CC-48CB-A61B-590819D69E6F}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {57A150A0-920C-443B-A780-8D6D4F0656F7}
	EndGlobalSection
EndGlobal

````

## MiniZotero/App.axaml

``xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="MiniZotero.App"
             xmlns:local="using:MiniZotero"
             RequestedThemeVariant="Default">
             <!-- "Default" ThemeVariant follows system theme variant. "Dark" or "Light" are other available options. -->

    <Application.DataTemplates>
        <local:ViewLocator/>
    </Application.DataTemplates>
  
    <Application.Styles>
        <FluentTheme />
    </Application.Styles>
</Application>
````

## MiniZotero/App.axaml.cs

``csharp
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MiniZotero.ViewModels;
using MiniZotero.Views;

namespace MiniZotero
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}

````

## MiniZotero/app.manifest

``xml
<?xml version="1.0" encoding="utf-8"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
  <!-- This manifest is used on Windows only.
       Don't remove it as it might cause problems with window transparency and embedded controls.
       For more details visit https://learn.microsoft.com/en-us/windows/win32/sbscs/application-manifests -->
  <assemblyIdentity version="1.0.0.0" name="MiniZotero.Desktop"/>

  <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
      <!-- A list of the Windows versions that this application has been tested on
           and is designed to work with. Uncomment the appropriate elements
           and Windows will automatically select the most compatible environment. -->

      <!-- Windows 10 -->
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
    </application>
  </compatibility>
</assembly>

````

## MiniZotero/Assets/avalonia-logo.ico

_Skipped binary or large file. Size: 175875 bytes._

## MiniZotero/Assets/PdfJs/build/pdf.mjs

_Skipped binary or large file. Size: 817035 bytes._

## MiniZotero/Assets/PdfJs/build/pdf.worker.mjs

_Skipped binary or large file. Size: 2161149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-EUC-H.bcmap

_Skipped binary or large file. Size: 2404 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-EUC-V.bcmap

_Skipped binary or large file. Size: 173 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-H.bcmap

_Skipped binary or large file. Size: 2379 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78ms-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2651 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78ms-RKSJ-V.bcmap

_Skipped binary or large file. Size: 290 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2398 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-RKSJ-V.bcmap

_Skipped binary or large file. Size: 173 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/Assets/PdfJs/cmaps/83pv-RKSJ-H.bcmap

_Skipped binary or large file. Size: 905 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90msp-RKSJ-H.bcmap

_Skipped binary or large file. Size: 715 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90msp-RKSJ-V.bcmap

_Skipped binary or large file. Size: 291 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90ms-RKSJ-H.bcmap

_Skipped binary or large file. Size: 721 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90ms-RKSJ-V.bcmap

_Skipped binary or large file. Size: 290 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90pv-RKSJ-H.bcmap

_Skipped binary or large file. Size: 982 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90pv-RKSJ-V.bcmap

_Skipped binary or large file. Size: 260 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-H.bcmap

_Skipped binary or large file. Size: 2419 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2413 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-RKSJ-V.bcmap

_Skipped binary or large file. Size: 287 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-V.bcmap

_Skipped binary or large file. Size: 282 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-0.bcmap

_Skipped binary or large file. Size: 317 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-1.bcmap

_Skipped binary or large file. Size: 371 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-2.bcmap

_Skipped binary or large file. Size: 376 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-3.bcmap

_Skipped binary or large file. Size: 401 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-4.bcmap

_Skipped binary or large file. Size: 405 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-5.bcmap

_Skipped binary or large file. Size: 406 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-6.bcmap

_Skipped binary or large file. Size: 406 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-UCS2.bcmap

_Skipped binary or large file. Size: 41193 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-0.bcmap

_Skipped binary or large file. Size: 217 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-1.bcmap

_Skipped binary or large file. Size: 250 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-2.bcmap

_Skipped binary or large file. Size: 465 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-3.bcmap

_Skipped binary or large file. Size: 470 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-4.bcmap

_Skipped binary or large file. Size: 601 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-5.bcmap

_Skipped binary or large file. Size: 625 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-UCS2.bcmap

_Skipped binary or large file. Size: 33974 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-0.bcmap

_Skipped binary or large file. Size: 225 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-1.bcmap

_Skipped binary or large file. Size: 226 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-2.bcmap

_Skipped binary or large file. Size: 233 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-3.bcmap

_Skipped binary or large file. Size: 242 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-4.bcmap

_Skipped binary or large file. Size: 337 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-5.bcmap

_Skipped binary or large file. Size: 430 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-6.bcmap

_Skipped binary or large file. Size: 485 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-UCS2.bcmap

_Skipped binary or large file. Size: 40951 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-0.bcmap

_Skipped binary or large file. Size: 241 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-1.bcmap

_Skipped binary or large file. Size: 386 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-2.bcmap

_Skipped binary or large file. Size: 391 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-UCS2.bcmap

_Skipped binary or large file. Size: 23293 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5-H.bcmap

_Skipped binary or large file. Size: 1086 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5pc-H.bcmap

_Skipped binary or large file. Size: 1099 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5pc-V.bcmap

_Skipped binary or large file. Size: 144 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5-V.bcmap

_Skipped binary or large file. Size: 142 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS1-H.bcmap

_Skipped binary or large file. Size: 706 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS1-V.bcmap

_Skipped binary or large file. Size: 143 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS2-H.bcmap

_Skipped binary or large file. Size: 504 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS2-V.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE�CNS2-H
````

## MiniZotero/Assets/PdfJs/cmaps/CNS-EUC-H.bcmap

_Skipped binary or large file. Size: 1780 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS-EUC-V.bcmap

_Skipped binary or large file. Size: 1920 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETen-B5-H.bcmap

_Skipped binary or large file. Size: 1125 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETen-B5-V.bcmap

_Skipped binary or large file. Size: 158 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETenms-B5-H.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE�	ETen-B5-H` ^
````

## MiniZotero/Assets/PdfJs/cmaps/ETenms-B5-V.bcmap

_Skipped binary or large file. Size: 172 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETHK-B5-H.bcmap

_Skipped binary or large file. Size: 4426 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETHK-B5-V.bcmap

_Skipped binary or large file. Size: 158 bytes._

## MiniZotero/Assets/PdfJs/cmaps/EUC-H.bcmap

_Skipped binary or large file. Size: 578 bytes._

## MiniZotero/Assets/PdfJs/cmaps/EUC-V.bcmap

_Skipped binary or large file. Size: 170 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-H.bcmap

_Skipped binary or large file. Size: 2536 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2542 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-RKSJ-V.bcmap

_Skipped binary or large file. Size: 218 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-V.bcmap

_Skipped binary or large file. Size: 215 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-EUC-H.bcmap

_Skipped binary or large file. Size: 549 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-EUC-V.bcmap

_Skipped binary or large file. Size: 179 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-H.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE!!��]aX!!]`�21�>	�p�z�$]��"R�d�-U�7�*�4�%�+ �Z �{�/�%�<�9K�b�1]�.�"��`]�,�"]�
�"]�h�"]�F�"]�$�"]��"]�`�"]�>�"]��"]�z�"]�X�"]�6�"]��"]�r�"]�P�"]�.�"]��"]�j�"]�H�"]�&�"]��"]�b�"]�@�"]��"]�|�"]�Z�"]�8�"]��"]�t�"]�R�"]�0�"]��"]�l�"]�J�"]�(�"]��"]�d�"]�B�"]� �"X�~�']�W�"]�5�"]��"]�q�"]�O�"]�-�"]��"]�i�"]�G�"]�%�"]��"]�a�"]�?�"]��"]�{�"]�Y�"]�7�"]��"]�s�"]�Q�"]�/�"]��"]�k�"]�I�"]�'�"]��"]�c�"]�A�"]��"]�}�"]�[�"]�9
````

## MiniZotero/Assets/PdfJs/cmaps/GBK2K-H.bcmap

_Skipped binary or large file. Size: 19662 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBK2K-V.bcmap

_Skipped binary or large file. Size: 219 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBK-EUC-H.bcmap

_Skipped binary or large file. Size: 14692 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBK-EUC-V.bcmap

_Skipped binary or large file. Size: 180 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBKp-EUC-H.bcmap

_Skipped binary or large file. Size: 14686 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBKp-EUC-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBpc-EUC-H.bcmap

_Skipped binary or large file. Size: 557 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBpc-EUC-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-EUC-H.bcmap

_Skipped binary or large file. Size: 7290 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-EUC-V.bcmap

_Skipped binary or large file. Size: 180 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-H.bcmap

_Skipped binary or large file. Size: 7269 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBTpc-EUC-H.bcmap

_Skipped binary or large file. Size: 7298 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBTpc-EUC-V.bcmap

_Skipped binary or large file. Size: 182 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-V.bcmap

_Skipped binary or large file. Size: 176 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-V.bcmap

_Skipped binary or large file. Size: 175 bytes._

## MiniZotero/Assets/PdfJs/cmaps/H.bcmap

_Skipped binary or large file. Size: 553 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Hankaku.bcmap

_Skipped binary or large file. Size: 132 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Hiragana.bcmap

_Skipped binary or large file. Size: 124 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdla-B5-H.bcmap

_Skipped binary or large file. Size: 2654 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdla-B5-V.bcmap

_Skipped binary or large file. Size: 148 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdlb-B5-H.bcmap

_Skipped binary or large file. Size: 2414 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdlb-B5-V.bcmap

_Skipped binary or large file. Size: 148 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKgccs-B5-H.bcmap

_Skipped binary or large file. Size: 2292 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKgccs-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm314-B5-H.bcmap

_Skipped binary or large file. Size: 1772 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm314-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm471-B5-H.bcmap

_Skipped binary or large file. Size: 2171 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm471-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKscs-B5-H.bcmap

_Skipped binary or large file. Size: 4437 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKscs-B5-V.bcmap

_Skipped binary or large file. Size: 159 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Katakana.bcmap

_Skipped binary or large file. Size: 100 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-EUC-H.bcmap

_Skipped binary or large file. Size: 1848 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-EUC-V.bcmap

_Skipped binary or large file. Size: 164 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-H.bcmap

_Skipped binary or large file. Size: 1831 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-Johab-H.bcmap

_Skipped binary or large file. Size: 16791 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-Johab-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-H.bcmap

_Skipped binary or large file. Size: 2787 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-HW-H.bcmap

_Skipped binary or large file. Size: 2789 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-HW-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCpc-EUC-H.bcmap

_Skipped binary or large file. Size: 2024 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCpc-EUC-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-V.bcmap

_Skipped binary or large file. Size: 160 bytes._

## MiniZotero/Assets/PdfJs/cmaps/LICENSE

``text
%%Copyright: -----------------------------------------------------------
%%Copyright: Copyright 1990-2009 Adobe Systems Incorporated.
%%Copyright: All rights reserved.
%%Copyright:
%%Copyright: Redistribution and use in source and binary forms, with or
%%Copyright: without modification, are permitted provided that the
%%Copyright: following conditions are met:
%%Copyright:
%%Copyright: Redistributions of source code must retain the above
%%Copyright: copyright notice, this list of conditions and the following
%%Copyright: disclaimer.
%%Copyright:
%%Copyright: Redistributions in binary form must reproduce the above
%%Copyright: copyright notice, this list of conditions and the following
%%Copyright: disclaimer in the documentation and/or other materials
%%Copyright: provided with the distribution. 
%%Copyright:
%%Copyright: Neither the name of Adobe Systems Incorporated nor the names
%%Copyright: of its contributors may be used to endorse or promote
%%Copyright: products derived from this software without specific prior
%%Copyright: written permission. 
%%Copyright:
%%Copyright: THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
%%Copyright: CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
%%Copyright: INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
%%Copyright: MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
%%Copyright: DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
%%Copyright: CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
%%Copyright: SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
%%Copyright: NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
%%Copyright: LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
%%Copyright: HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
%%Copyright: CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
%%Copyright: OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
%%Copyright: SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
%%Copyright: -----------------------------------------------------------

````

## MiniZotero/Assets/PdfJs/cmaps/NWP-H.bcmap

_Skipped binary or large file. Size: 2765 bytes._

## MiniZotero/Assets/PdfJs/cmaps/NWP-V.bcmap

_Skipped binary or large file. Size: 252 bytes._

## MiniZotero/Assets/PdfJs/cmaps/RKSJ-H.bcmap

_Skipped binary or large file. Size: 534 bytes._

## MiniZotero/Assets/PdfJs/cmaps/RKSJ-V.bcmap

_Skipped binary or large file. Size: 170 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Roman.bcmap

_Skipped binary or large file. Size: 96 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UCS2-H.bcmap

_Skipped binary or large file. Size: 48280 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UCS2-V.bcmap

_Skipped binary or large file. Size: 156 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF16-H.bcmap

_Skipped binary or large file. Size: 50419 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF16-V.bcmap

_Skipped binary or large file. Size: 156 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF32-H.bcmap

_Skipped binary or large file. Size: 52679 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF32-V.bcmap

_Skipped binary or large file. Size: 160 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF8-H.bcmap

_Skipped binary or large file. Size: 53629 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF8-V.bcmap

_Skipped binary or large file. Size: 157 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UCS2-H.bcmap

_Skipped binary or large file. Size: 43366 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UCS2-V.bcmap

_Skipped binary or large file. Size: 193 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF16-H.bcmap

_Skipped binary or large file. Size: 44086 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF16-V.bcmap

_Skipped binary or large file. Size: 178 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF32-H.bcmap

_Skipped binary or large file. Size: 45738 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF32-V.bcmap

_Skipped binary or large file. Size: 182 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF8-H.bcmap

_Skipped binary or large file. Size: 46837 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF8-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF16-H.bcmap

_Skipped binary or large file. Size: 39534 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF16-V.bcmap

_Skipped binary or large file. Size: 647 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF32-H.bcmap

_Skipped binary or large file. Size: 40630 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF32-V.bcmap

_Skipped binary or large file. Size: 681 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF8-H.bcmap

_Skipped binary or large file. Size: 41779 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF8-V.bcmap

_Skipped binary or large file. Size: 682 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISPro-UCS2-HW-V.bcmap

_Skipped binary or large file. Size: 705 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISPro-UCS2-V.bcmap

_Skipped binary or large file. Size: 689 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISPro-UTF8-V.bcmap

_Skipped binary or large file. Size: 726 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-H.bcmap

_Skipped binary or large file. Size: 25439 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-HW-H.bcmap

_Skipped binary or large file. Size: 119 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-HW-V.bcmap

_Skipped binary or large file. Size: 680 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-V.bcmap

_Skipped binary or large file. Size: 664 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF16-H.bcmap

_Skipped binary or large file. Size: 39443 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF16-V.bcmap

_Skipped binary or large file. Size: 643 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF32-H.bcmap

_Skipped binary or large file. Size: 40539 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF32-V.bcmap

_Skipped binary or large file. Size: 677 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF8-H.bcmap

_Skipped binary or large file. Size: 41695 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF8-V.bcmap

_Skipped binary or large file. Size: 678 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX02132004-UTF32-H.bcmap

_Skipped binary or large file. Size: 40608 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX02132004-UTF32-V.bcmap

_Skipped binary or large file. Size: 688 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX0213-UTF32-H.bcmap

_Skipped binary or large file. Size: 40517 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX0213-UTF32-V.bcmap

_Skipped binary or large file. Size: 684 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UCS2-H.bcmap

_Skipped binary or large file. Size: 25783 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UCS2-V.bcmap

_Skipped binary or large file. Size: 178 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF16-H.bcmap

_Skipped binary or large file. Size: 26327 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF16-V.bcmap

_Skipped binary or large file. Size: 164 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF32-H.bcmap

_Skipped binary or large file. Size: 26451 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF32-V.bcmap

_Skipped binary or large file. Size: 168 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF8-H.bcmap

_Skipped binary or large file. Size: 27790 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF8-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/Assets/PdfJs/cmaps/V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/WP-Symbol.bcmap

_Skipped binary or large file. Size: 179 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitDingbats.pfb

_Skipped binary or large file. Size: 29513 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixed.pfb

_Skipped binary or large file. Size: 17597 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixedBold.pfb

_Skipped binary or large file. Size: 18055 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixedBoldItalic.pfb

_Skipped binary or large file. Size: 19151 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixedItalic.pfb

_Skipped binary or large file. Size: 18746 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerif.pfb

_Skipped binary or large file. Size: 19469 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerifBold.pfb

_Skipped binary or large file. Size: 19395 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerifBoldItalic.pfb

_Skipped binary or large file. Size: 20733 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerifItalic.pfb

_Skipped binary or large file. Size: 21227 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSymbol.pfb

_Skipped binary or large file. Size: 16729 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-Bold.ttf

_Skipped binary or large file. Size: 137052 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-BoldItalic.ttf

_Skipped binary or large file. Size: 135124 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-Italic.ttf

_Skipped binary or large file. Size: 162036 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-Regular.ttf

_Skipped binary or large file. Size: 139512 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LICENSE_FOXIT

``text
// Copyright 2014 PDFium Authors. All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//    * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//    * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

````

## MiniZotero/Assets/PdfJs/standard_fonts/LICENSE_LIBERATION

``text
Digitized data copyright (c) 2010 Google Corporation
	with Reserved Font Arimo, Tinos and Cousine.
Copyright (c) 2012 Red Hat, Inc.
	with Reserved Font Name Liberation.

This Font Software is licensed under the SIL Open Font License,
Version 1.1.

This license is copied below, and is also available with a FAQ at:
http://scripts.sil.org/OFL

SIL OPEN FONT LICENSE Version 1.1 - 26 February 2007

PREAMBLE The goals of the Open Font License (OFL) are to stimulate
worldwide development of collaborative font projects, to support the font
creation efforts of academic and linguistic communities, and to provide
a free and open framework in which fonts may be shared and improved in
partnership with others.

The OFL allows the licensed fonts to be used, studied, modified and
redistributed freely as long as they are not sold by themselves.
The fonts, including any derivative works, can be bundled, embedded,
redistributed and/or sold with any software provided that any reserved
names are not used by derivative works.  The fonts and derivatives,
however, cannot be released under any other type of license.  The
requirement for fonts to remain under this license does not apply to
any document created using the fonts or their derivatives.

 

DEFINITIONS
"Font Software" refers to the set of files released by the Copyright
Holder(s) under this license and clearly marked as such.
This may include source files, build scripts and documentation.

"Reserved Font Name" refers to any names specified as such after the
copyright statement(s).

"Original Version" refers to the collection of Font Software components
as distributed by the Copyright Holder(s).

"Modified Version" refers to any derivative made by adding to, deleting,
or substituting ? in part or in whole ?
any of the components of the Original Version, by changing formats or
by porting the Font Software to a new environment.

"Author" refers to any designer, engineer, programmer, technical writer
or other person who contributed to the Font Software.


PERMISSION & CONDITIONS

Permission is hereby granted, free of charge, to any person obtaining a
copy of the Font Software, to use, study, copy, merge, embed, modify,
redistribute, and sell modified and unmodified copies of the Font
Software, subject to the following conditions:

1) Neither the Font Software nor any of its individual components,in
   Original or Modified Versions, may be sold by itself.

2) Original or Modified Versions of the Font Software may be bundled,
   redistributed and/or sold with any software, provided that each copy
   contains the above copyright notice and this license. These can be
   included either as stand-alone text files, human-readable headers or
   in the appropriate machine-readable metadata fields within text or
   binary files as long as those fields can be easily viewed by the user.

3) No Modified Version of the Font Software may use the Reserved Font
   Name(s) unless explicit written permission is granted by the
   corresponding Copyright Holder. This restriction only applies to the
   primary font name as presented to the users.

4) The name(s) of the Copyright Holder(s) or the Author(s) of the Font
   Software shall not be used to promote, endorse or advertise any
   Modified Version, except to acknowledge the contribution(s) of the
   Copyright Holder(s) and the Author(s) or with their explicit written
   permission.

5) The Font Software, modified or unmodified, in part or in whole, must
   be distributed entirely under this license, and must not be distributed
   under any other license. The requirement for fonts to remain under
   this license does not apply to any document created using the Font
   Software.


 
TERMINATION
This license becomes null and void if any of the above conditions are not met.

 

DISCLAIMER
THE FONT SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO ANY WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT
OF COPYRIGHT, PATENT, TRADEMARK, OR OTHER RIGHT.  IN NO EVENT SHALL THE
COPYRIGHT HOLDER BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
INCLUDING ANY GENERAL, SPECIAL, INDIRECT, INCIDENTAL, OR CONSEQUENTIAL
DAMAGES, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF THE USE OR INABILITY TO USE THE FONT SOFTWARE OR FROM OTHER
DEALINGS IN THE FONT SOFTWARE.


````

## MiniZotero/Assets/PdfViewer/index.html

``html
<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>MiniZotero PDF Viewer</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="app">
        <div id="status">Loading PDF...</div>
        <div id="viewer"></div>
    </div>

    <script type="module" src="viewer.js"></script>
</body>
</html>

````

## MiniZotero/Assets/PdfViewer/style.css

``css
html,
body {
    margin: 0;
    padding: 0;
    height: 100%;
    background: #e8ecf2;
    font-family: Segoe UI, Arial, sans-serif;
    overflow: hidden;
    user-select: text;
    -webkit-user-select: text;
}

#app {
    height: 100%;
    display: flex;
    flex-direction: column;
}

#status {
    display: none;
}

#viewer {
    position: relative;
    flex: 1;
    overflow: auto;
    padding: 24px 0;
    box-sizing: border-box;
    user-select: none;
    -webkit-user-select: none;
}

#viewer.toolSelect {
    cursor: text;
}

#viewer.toolHighlight {
    cursor: text;
}

#viewer.toolHand {
    cursor: grab;
}

#viewer.toolHand.panning {
    cursor: grabbing;
}

#viewer.viewerLiveZoom .textLayer,
.viewerLiveZoom .textLayer {
    pointer-events: none;
    user-select: none;
}

.page {
    position: relative;
    display: block;
    margin: 0 auto 22px auto;
    background: transparent;
}

.pageContent {
    position: absolute;
    top: 0;
    left: 0;
    background: white;
    overflow: hidden;
    transform-origin: 0 0;
    box-shadow: 0 4px 18px rgba(0, 0, 0, 0.18);
    user-select: text;
    -webkit-user-select: text;
}

.canvasLayer {
    position: absolute;
    left: 0;
    top: 0;
    display: block;
    image-rendering: auto;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
    z-index: 0;
}

.textLayer {
    position: absolute;
    inset: 0;
    overflow: hidden;
    opacity: 1;
    line-height: 1;
    text-align: initial;
    transform-origin: 0 0;
    forced-color-adjust: none;
    z-index: 2;
    cursor: text;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
}

.textLayer span,
.textLayer br {
    position: absolute;
    color: transparent;
    white-space: pre;
    cursor: text;
    transform-origin: 0% 0%;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
}

.textLayer ::selection,
.textLayer span::selection {
    background: transparent !important;
}

.textLayer .markedContent {
    display: contents;
}

.textLayer .endOfContent {
    display: block;
    position: absolute;
    inset: 100% 0 0;
    z-index: 0;
    cursor: default;
    user-select: none;
}

.highlightLayer {
    position: absolute;
    left: 0;
    top: 0;
    pointer-events: none;
    z-index: 1;
}

.highlightLayer .highlightItem {
    position: absolute;
    background: rgba(250, 204, 21, 0.34);
    border-radius: 2px;
    pointer-events: none;
}

.highlightLayer .highlightItem:hover {
    background: rgba(250, 204, 21, 0.52);
}

.highlightLayer.isInteractive {
    z-index: 3;
    pointer-events: auto;
}

.highlightLayer.isInteractive .highlightItem {
    cursor: pointer;
    pointer-events: auto;
}

.selectionOverlay {
    position: absolute;
    inset: 0;
    pointer-events: none;
    z-index: 3;
}

.selectionOverlayRect {
    position: absolute;
    background: rgba(245, 158, 11, 0.28);
    border-radius: 2px;
    pointer-events: none;
}

.selectionDragBox {
    position: absolute;
    border: 1px solid rgba(59, 130, 246, 0.7);
    background: rgba(59, 130, 246, 0.08);
    border-radius: 3px;
    pointer-events: none;
    z-index: 10;
}

.error {
    margin: 40px auto;
    max-width: 520px;
    background: white;
    color: #b91c1c;
    border: 1px solid #fecaca;
    border-radius: 8px;
    padding: 16px;
    font-size: 13px;
}

````

## MiniZotero/Assets/PdfViewer/viewer.js

``javascript
import * as pdfjsLib from "../PdfJs/build/pdf.mjs";

pdfjsLib.GlobalWorkerOptions.workerSrc = "../PdfJs/build/pdf.worker.mjs";

const viewer = document.getElementById("viewer");
const statusBar = document.getElementById("status");

const pageStates = new Map();

let pdfDocument = null;
let currentScale = 1.2;
let visualScale = 1.2;
let currentPage = 1;
let zoomTimer = null;
let isLiveZooming = false;
let scrollTimer = null;
let customSelection = null;
let areaSelectionBox = null;
let currentToolMode = "select";
let handPanState = null;
let storedHighlights = [];

const RENDER_QUALITY = 2;
const MAX_OUTPUT_SCALE = 4;
const MIN_ZOOM = 0.5;
const MAX_ZOOM = 4;
const AREA_SELECTION_THRESHOLD = 4;

function getQueryValue(name) {
    const params = new URLSearchParams(window.location.search);
    return params.get(name);
}

function getHashValue(name, fallback) {
    const hash = window.location.hash.replace("#", "");
    const params = new URLSearchParams(hash);
    return params.get(name) || fallback;
}

function clampScale(scale) {
    return Math.min(Math.max(scale, MIN_ZOOM), MAX_ZOOM);
}

function sendToCSharp(type, data = {}) {
    const payload = JSON.stringify({
        type,
        pageNumber: data.pageNumber || currentPage,
        zoomPercent: Math.round(currentScale * 100),
        ...data
    });

    try {
        if (typeof invokeCSharpAction === "function") {
            invokeCSharpAction(payload);
            return;
        }

        if (window.chrome?.webview?.postMessage) {
            window.chrome.webview.postMessage(payload);
            return;
        }

        if (window.webkit?.messageHandlers?.webview?.postMessage) {
            window.webkit.messageHandlers.webview.postMessage(payload);
        }
    } catch {
    }
}

function getOutputScale() {
    const deviceScale = window.devicePixelRatio || 1;
    return Math.min(deviceScale * RENDER_QUALITY, MAX_OUTPUT_SCALE);
}

function cancelTask(task) {
    try {
        task?.cancel?.();
    } catch {
    }
}

function isCancellationError(error) {
    return error?.name === "RenderingCancelledException" ||
        error?.name === "AbortException";
}

function applyPageVisualScale(state, nextVisualScale) {
    const visualWidth = Math.floor(state.baseWidth * nextVisualScale);
    const visualHeight = Math.floor(state.baseHeight * nextVisualScale);

    state.wrapper.style.width = `${visualWidth}px`;
    state.wrapper.style.height = `${visualHeight}px`;

    if (!state.content || !state.renderedScale) {
        return;
    }

    const ratio = nextVisualScale / state.renderedScale;

    if (Math.abs(ratio - 1) < 0.001) {
        state.content.style.transform = "";
        state.content.style.transformOrigin = "";
        return;
    }

    state.content.style.transform = `scale(${ratio})`;
    state.content.style.transformOrigin = "0 0";
}

function getZoomAnchor(clientX = null, clientY = null) {
    const viewerRect = viewer.getBoundingClientRect();
    const fallbackClientX = viewerRect.left + viewer.clientWidth / 2;
    const fallbackClientY = viewerRect.top + viewer.clientHeight / 2;
    const anchorClientX = clientX ?? fallbackClientX;
    const anchorClientY = clientY ?? fallbackClientY;
    const clampedClientX = Math.min(
        Math.max(anchorClientX, viewerRect.left),
        viewerRect.right
    );
    const clampedClientY = Math.min(
        Math.max(anchorClientY, viewerRect.top),
        viewerRect.bottom
    );

    let anchorState = null;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageRect = state.wrapper.getBoundingClientRect();

        if (pageRect.top <= clampedClientY && pageRect.bottom >= clampedClientY) {
            anchorState = state;
            break;
        }

        const pageMiddle = pageRect.top + pageRect.height / 2;
        const distance = Math.abs(pageMiddle - clampedClientY);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            anchorState = state;
        }
    }

    if (!anchorState) {
        return null;
    }

    const pageHeight = Math.max(anchorState.wrapper.clientHeight, 1);
    const pageWidth = Math.max(anchorState.wrapper.clientWidth, 1);
    const pageRect = anchorState.wrapper.getBoundingClientRect();
    const yRatio = Math.min(
        Math.max((clampedClientY - pageRect.top) / pageHeight, 0),
        1
    );
    const xRatio = Math.min(
        Math.max((clampedClientX - pageRect.left) / pageWidth, 0),
        1
    );

    return {
        pageNumber: anchorState.pageNumber,
        xRatio,
        yRatio,
        offsetInViewerX: clampedClientX - viewerRect.left,
        offsetInViewerY: clampedClientY - viewerRect.top
    };
}

function restoreZoomAnchor(anchor) {
    if (!anchor) {
        return;
    }

    const state = pageStates.get(anchor.pageNumber);

    if (!state) {
        return;
    }

    viewer.scrollLeft = state.wrapper.offsetLeft +
        state.wrapper.clientWidth * anchor.xRatio -
        anchor.offsetInViewerX;
    viewer.scrollTop = state.wrapper.offsetTop +
        state.wrapper.clientHeight * anchor.yRatio -
        anchor.offsetInViewerY;
}

async function cancelActiveRenderTasks() {
    for (const state of pageStates.values()) {
        cancelTask(state.renderTask);
        cancelTask(state.textLayerTask);
        state.renderTask = null;
        state.textLayerTask = null;
        state.renderPromise = null;
        state.renderingScale = 0;
    }
}

async function createPagePlaceholder(pageNumber) {
    const page = await pdfDocument.getPage(pageNumber);
    const baseViewport = page.getViewport({ scale: 1 });

    const wrapper = document.createElement("div");
    wrapper.className = "page";
    wrapper.dataset.pageNumber = String(pageNumber);

    const state = {
        pageNumber,
        wrapper,
        content: null,
        canvas: null,
        textLayer: null,
        highlightLayer: null,
        selectionOverlay: null,
        textItems: [],
        selectedWordRects: [],
        renderTask: null,
        textLayerTask: null,
        renderPromise: null,
        renderingScale: 0,
        renderedScale: 0,
        baseWidth: baseViewport.width,
        baseHeight: baseViewport.height,
        isRendered: false
    };

    pageStates.set(pageNumber, state);
    viewer.appendChild(wrapper);
    applyPageVisualScale(state, currentScale);
}

async function createPagePlaceholders() {
    viewer.innerHTML = "";
    pageStates.clear();

    for (let pageNumber = 1; pageNumber <= pdfDocument.numPages; pageNumber++) {
        await createPagePlaceholder(pageNumber);
    }
}

function buildSelectableWords(textContent, viewport) {
    const words = [];
    let globalIndex = 0;

    for (const item of textContent.items) {
        if (!item.str || !item.transform) {
            continue;
        }

        const text = item.str;
        const pdfTransform = pdfjsLib.Util.transform(
            viewport.transform,
            item.transform
        );
        const x = pdfTransform[4];
        const y = pdfTransform[5];
        const fontHeight = Math.abs(pdfTransform[3]) || item.height || 10;
        const itemWidth = Number.isFinite(item.width)
            ? Math.abs(item.width * viewport.scale)
            : Math.max(text.length * fontHeight * 0.45, 1);
        const parts = text.match(/\S+|\s+/g) ?? [];

        let cursorX = x;

        for (const part of parts) {
            const width = text.length > 0
                ? itemWidth * (part.length / text.length)
                : 0;

            if (part.trim().length > 0) {
                words.push({
                    index: globalIndex++,
                    text: part,
                    left: cursorX,
                    top: y - fontHeight,
                    right: cursorX + width,
                    bottom: y,
                    width,
                    height: fontHeight,
                    lineY: y
                });
            }

            cursorX += width;
        }
    }

    return words;
}

async function renderTextLayer(page, viewport, content, state) {
    const textLayerDiv = document.createElement("div");
    textLayerDiv.className = "textLayer";
    textLayerDiv.style.width = `${Math.floor(viewport.width)}px`;
    textLayerDiv.style.height = `${Math.floor(viewport.height)}px`;

    content.appendChild(textLayerDiv);

    const textContent = await page.getTextContent({
        includeMarkedContent: true,
        disableNormalization: false
    });

    state.textItems = buildSelectableWords(textContent, viewport);

    if (!pdfjsLib.TextLayer) {
        throw new Error("PDF.js TextLayer API is not available in this build.");
    }

    const textLayer = new pdfjsLib.TextLayer({
        textContentSource: textContent,
        container: textLayerDiv,
        viewport
    });

    state.textLayerTask = textLayer;
    await textLayer.render();
    state.textLayerTask = null;

    return textLayerDiv;
}

function createHighlightLayer(viewport) {
    const highlightLayer = document.createElement("div");
    highlightLayer.className = "highlightLayer";
    highlightLayer.style.width = `${Math.floor(viewport.width)}px`;
    highlightLayer.style.height = `${Math.floor(viewport.height)}px`;
    return highlightLayer;
}

async function renderPage(pageNumber, force = false) {
    const state = pageStates.get(pageNumber);

    if (!state || isLiveZooming) {
        return;
    }

    if (!force && state.isRendered && state.renderedScale === currentScale) {
        return;
    }

    if (!force && state.renderPromise && state.renderingScale === currentScale) {
        return state.renderPromise;
    }

    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);
    state.renderTask = null;
    state.textLayerTask = null;

    const renderPromise = renderPageInternal(state);
    state.renderPromise = renderPromise;
    state.renderingScale = currentScale;

    try {
        await renderPromise;
    } finally {
        if (state.renderPromise === renderPromise) {
            state.renderPromise = null;
            state.renderingScale = 0;
        }
    }
}

async function renderPageInternal(state) {
    const targetScale = currentScale;
    const page = await pdfDocument.getPage(state.pageNumber);
    const viewport = page.getViewport({ scale: targetScale });

    const content = document.createElement("div");
    content.className = "pageContent";
    content.style.width = `${Math.floor(viewport.width)}px`;
    content.style.height = `${Math.floor(viewport.height)}px`;
    content.style.setProperty("--total-scale-factor", String(targetScale));

    const canvas = document.createElement("canvas");
    canvas.className = "canvasLayer";
    canvas.style.width = `${Math.floor(viewport.width)}px`;
    canvas.style.height = `${Math.floor(viewport.height)}px`;

    const context = canvas.getContext("2d", {
        alpha: false
    });

    if (!context) {
        throw new Error("Unable to create canvas context.");
    }

    const outputScale = getOutputScale();

    canvas.width = Math.floor(viewport.width * outputScale);
    canvas.height = Math.floor(viewport.height * outputScale);

    content.appendChild(canvas);

    const renderTask = page.render({
        canvasContext: context,
        viewport,
        transform: outputScale !== 1
            ? [outputScale, 0, 0, outputScale, 0, 0]
            : null
    });

    state.renderTask = renderTask;

    try {
        await renderTask.promise;
    } catch (error) {
        if (isCancellationError(error)) {
            return;
        }

        throw error;
    } finally {
        if (state.renderTask === renderTask) {
            state.renderTask = null;
        }
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    let textLayer = null;

    try {
        textLayer = await renderTextLayer(page, viewport, content, state);
    } catch (error) {
        if (!isCancellationError(error)) {
            throw error;
        }

        return;
    } finally {
        state.textLayerTask = null;
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    const highlightLayer = createHighlightLayer(viewport);
    content.appendChild(highlightLayer);

    const selectionOverlay = document.createElement("div");
    selectionOverlay.className = "selectionOverlay";
    content.appendChild(selectionOverlay);

    const oldContent = state.content;

    state.wrapper.appendChild(content);

    if (oldContent) {
        oldContent.remove();
    }

    state.content = content;
    state.canvas = canvas;
    state.textLayer = textLayer;
    state.highlightLayer = highlightLayer;
    state.selectionOverlay = selectionOverlay;
    state.renderedScale = targetScale;
    state.isRendered = true;

    renderStoredHighlightsForPage(state);
    applyPageVisualScale(state, visualScale);
}

function isPageNearViewport(wrapper, buffer = viewer.clientHeight) {
    const viewerRect = viewer.getBoundingClientRect();
    const pageRect = wrapper.getBoundingClientRect();

    return (
        pageRect.bottom >= viewerRect.top - buffer &&
        pageRect.top <= viewerRect.bottom + buffer
    );
}

function unloadPage(state) {
    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);

    state.content?.remove();

    state.content = null;
    state.canvas = null;
    state.textLayer = null;
    state.highlightLayer = null;
    state.selectionOverlay = null;
    state.textItems = [];
    state.selectedWordRects = [];
    state.renderTask = null;
    state.textLayerTask = null;
    state.renderPromise = null;
    state.renderingScale = 0;
    state.renderedScale = 0;
    state.isRendered = false;
}

function cleanupFarPages() {
    const buffer = viewer.clientHeight * 3;

    for (const state of pageStates.values()) {
        if (!isPageNearViewport(state.wrapper, buffer)) {
            unloadPage(state);
        }
    }
}

async function renderVisiblePages(force = false) {
    if (isLiveZooming) {
        return;
    }

    const renderPromises = [];

    for (const state of pageStates.values()) {
        if (isPageNearViewport(state.wrapper)) {
            renderPromises.push(renderPage(state.pageNumber, force));
        }
    }

    cleanupFarPages();
    await Promise.all(renderPromises);
}

function updateCurrentPageFromScroll() {
    if (pageStates.size === 0) {
        return;
    }

    const viewportMiddle = viewer.scrollTop + viewer.clientHeight / 2;

    let nearestPage = 1;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageTop = state.wrapper.offsetTop;
        const pageMiddle = pageTop + state.wrapper.clientHeight / 2;
        const distance = Math.abs(pageMiddle - viewportMiddle);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            nearestPage = state.pageNumber;
        }
    }

    if (nearestPage !== currentPage) {
        currentPage = nearestPage;
        statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function scrollToPage(pageNumber, notify = true) {
    const state = pageStates.get(pageNumber);

    if (!state) {
        return;
    }

    state.wrapper.scrollIntoView({ block: "start" });
    currentPage = pageNumber;

    if (notify) {
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function clearAllSelectionOverlays() {
    for (const state of pageStates.values()) {
        if (state.selectionOverlay) {
            state.selectionOverlay.innerHTML = "";
        }
    }
}

function clearCustomSelection() {
    customSelection = null;
    clearAllSelectionOverlays();
    clearAreaSelectionBox();
}

function clearAreaSelectionBox() {
    areaSelectionBox?.remove();
    areaSelectionBox = null;
}

function setToolMode(toolMode) {
    currentToolMode = ["hand", "highlight"].includes(toolMode)
        ? toolMode
        : "select";
    handPanState = null;
    viewer.classList.toggle("toolHand", currentToolMode === "hand");
    viewer.classList.toggle("toolSelect", currentToolMode === "select");
    viewer.classList.toggle("toolHighlight", currentToolMode === "highlight");
    viewer.classList.remove("panning");

    if (currentToolMode === "hand") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
    }
}

function startHandPan(event) {
    if (event.button !== 0 || isLiveZooming) {
        return false;
    }

    handPanState = {
        pointerId: event.pointerId,
        startClientX: event.clientX,
        startClientY: event.clientY,
        startScrollLeft: viewer.scrollLeft,
        startScrollTop: viewer.scrollTop
    };

    viewer.classList.add("panning");
    viewer.setPointerCapture?.(event.pointerId);
    event.preventDefault();
    return true;
}

function moveHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    viewer.scrollLeft = handPanState.startScrollLeft -
        (event.clientX - handPanState.startClientX);
    viewer.scrollTop = handPanState.startScrollTop -
        (event.clientY - handPanState.startClientY);
    event.preventDefault();
    return true;
}

function stopHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    handPanState = null;
    viewer.classList.remove("panning");

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    event.preventDefault();
    return true;
}

function getPagePointFromClient(state, clientX, clientY) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        x: (clientX - contentRect.left) / scaleX,
        y: (clientY - contentRect.top) / scaleY
    };
}

function findRenderedPageAtClientPoint(clientX, clientY) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX >= contentRect.left &&
            clientX <= contentRect.right &&
            clientY >= contentRect.top &&
            clientY <= contentRect.bottom
        ) {
            return state;
        }
    }

    return null;
}

function findWordAtClientPoint(clientX, clientY, includeNearbyWord = true) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX < contentRect.left ||
            clientX > contentRect.right ||
            clientY < contentRect.top ||
            clientY > contentRect.bottom
        ) {
            continue;
        }

        const point = getPagePointFromClient(state, clientX, clientY);
        let bestWord = null;
        let bestDistance = Number.MAX_VALUE;

        for (const word of state.textItems) {
            const inside =
                point.x >= word.left &&
                point.x <= word.right &&
                point.y >= word.top &&
                point.y <= word.bottom;

            if (inside) {
                return { state, word };
            }

            const centerX = (word.left + word.right) / 2;
            const centerY = (word.top + word.bottom) / 2;
            const dx = point.x - centerX;
            const dy = point.y - centerY;
            const distance = dx * dx + dy * dy;

            if (distance < bestDistance) {
                bestDistance = distance;
                bestWord = word;
            }
        }

        if (includeNearbyWord && bestWord && bestDistance < 900) {
            return {
                state,
                word: bestWord
            };
        }
    }

    return null;
}

function getClientDragRect(selection) {
    const left = Math.min(selection.startClientX, selection.endClientX);
    const top = Math.min(selection.startClientY, selection.endClientY);
    const right = Math.max(selection.startClientX, selection.endClientX);
    const bottom = Math.max(selection.startClientY, selection.endClientY);

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function rectsIntersect(first, second) {
    return first.right >= second.left &&
        first.left <= second.right &&
        first.bottom >= second.top &&
        first.top <= second.bottom;
}

function getWordClientRect(state, word) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        left: contentRect.left + word.left * scaleX,
        top: contentRect.top + word.top * scaleY,
        right: contentRect.left + word.right * scaleX,
        bottom: contentRect.top + word.bottom * scaleY
    };
}

function getOrCreateAreaSelectionBox() {
    if (areaSelectionBox) {
        return areaSelectionBox;
    }

    areaSelectionBox = document.createElement("div");
    areaSelectionBox.className = "selectionDragBox";
    viewer.appendChild(areaSelectionBox);
    return areaSelectionBox;
}

function renderAreaSelectionBox(selection) {
    const dragRect = getClientDragRect(selection);

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        clearAreaSelectionBox();
        return;
    }

    const viewerRect = viewer.getBoundingClientRect();
    const box = getOrCreateAreaSelectionBox();

    box.style.left = `${dragRect.left - viewerRect.left + viewer.scrollLeft}px`;
    box.style.top = `${dragRect.top - viewerRect.top + viewer.scrollTop}px`;
    box.style.width = `${dragRect.width}px`;
    box.style.height = `${dragRect.height}px`;
}

function updateAreaSelectionWords(selection) {
    const dragRect = getClientDragRect(selection);
    const wordIndexesByPage = new Map();

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        selection.wordIndexesByPage = wordIndexesByPage;
        return;
    }

    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (!rectsIntersect(dragRect, contentRect)) {
            continue;
        }

        const selectedIndexes = new Set();

        for (const word of state.textItems) {
            if (rectsIntersect(dragRect, getWordClientRect(state, word))) {
                selectedIndexes.add(word.index);
            }
        }

        if (selectedIndexes.size > 0) {
            wordIndexesByPage.set(state.pageNumber, selectedIndexes);
        }
    }

    selection.wordIndexesByPage = wordIndexesByPage;
}

function compareSelectionPosition(firstPage, firstIndex, secondPage, secondIndex) {
    if (firstPage !== secondPage) {
        return firstPage - secondPage;
    }

    return firstIndex - secondIndex;
}

function getSelectedWordsForPage(state) {
    if (!customSelection || state.textItems.length === 0) {
        return [];
    }

    if (customSelection.mode === "area") {
        const selectedIndexes = customSelection.wordIndexesByPage?.get(state.pageNumber);

        if (!selectedIndexes) {
            return [];
        }

        return state.textItems.filter(word => selectedIndexes.has(word.index));
    }

    const direction = compareSelectionPosition(
        customSelection.startPage,
        customSelection.startWordIndex,
        customSelection.endPage,
        customSelection.endWordIndex
    );
    const isForward = direction <= 0;
    const firstPage = isForward ? customSelection.startPage : customSelection.endPage;
    const lastPage = isForward ? customSelection.endPage : customSelection.startPage;

    if (state.pageNumber < firstPage || state.pageNumber > lastPage) {
        return [];
    }

    let startIndex = 0;
    let endIndex = state.textItems[state.textItems.length - 1].index;

    if (isForward) {
        if (state.pageNumber === customSelection.startPage) {
            startIndex = customSelection.startWordIndex;
        }

        if (state.pageNumber === customSelection.endPage) {
            endIndex = customSelection.endWordIndex;
        }
    } else {
        if (state.pageNumber === customSelection.endPage) {
            startIndex = customSelection.endWordIndex;
        }

        if (state.pageNumber === customSelection.startPage) {
            endIndex = customSelection.startWordIndex;
        }
    }

    if (startIndex > endIndex) {
        const temp = startIndex;
        startIndex = endIndex;
        endIndex = temp;
    }

    return state.textItems.filter(word =>
        word.index >= startIndex &&
        word.index <= endIndex
    );
}

function groupWordsByLine(words) {
    const lines = new Map();

    for (const word of words) {
        const key = Math.round(word.lineY / 4) * 4;

        if (!lines.has(key)) {
            lines.set(key, []);
        }

        lines.get(key).push(word);
    }

    return [...lines.entries()].sort((first, second) => first[0] - second[0]);
}

function renderCustomSelection() {
    clearAllSelectionOverlays();

    for (const state of pageStates.values()) {
        if (!state.selectionOverlay) {
            continue;
        }

        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const fragment = document.createDocumentFragment();

        for (const segment of buildHighlightSegments(words, state)) {
            const rect = document.createElement("div");

            rect.className = "selectionOverlayRect";
            rect.style.left = `${segment.left}px`;
            rect.style.top = `${segment.top}px`;
            rect.style.width = `${segment.width}px`;
            rect.style.height = `${segment.height}px`;

            fragment.appendChild(rect);
        }

        state.selectionOverlay.appendChild(fragment);
    }
}

function getRenderedPageWidth(state) {
    if (state.content?.offsetWidth) {
        return state.content.offsetWidth;
    }

    if (state.baseWidth && state.renderedScale) {
        return state.baseWidth * state.renderedScale;
    }

    return state.baseWidth * currentScale;
}

function getLineFontHeight(line) {
    const heights = line.words
        .map(word => word.height || 0)
        .filter(height => height > 0)
        .sort((first, second) => first - second);

    return heights.length === 0
        ? 12
        : heights[Math.floor(heights.length / 2)];
}

function getLineText(line) {
    return line.words
        .map(word => word.text ?? "")
        .join("")
        .trim();
}

function compareLinePosition(first, second) {
    const fontHeight = Math.max(getLineFontHeight(first), getLineFontHeight(second));
    const yTolerance = Math.max(2, fontHeight * 0.4);

    if (Math.abs(first.top - second.top) > yTolerance) {
        return first.top - second.top;
    }

    return first.left - second.left;
}

function isProbablyHeadingText(text) {
    if (!text) {
        return false;
    }

    const normalized = text.replace(/\s+/g, " ").trim();

    if (normalized.length <= 3) {
        return false;
    }

    const isUpper = /^([IVXLCDM]+\.?\s+)?[A-ZÀ-Ỵ0-9\s\-–().:]+$/.test(normalized);
    const isNumbered = /^(chương|chapter|section|phần|mục|\d+(\.\d+)*\.?)\s+\d*.*$/i.test(normalized);
    const isCommonHeader = /^(Abstract|Introduction|Methodology|Methods|Results|Discussion|Conclusion|References|Acknowledgment|Tóm\s+tắt|Tổng\s+quan|Kết\s+luận)$/i.test(normalized);

    return isUpper || isNumbered || isCommonHeader;
}

function isFullWidthLine(line, state) {
    const pageWidth = getRenderedPageWidth(state);
    const widthRatio = line.width / Math.max(pageWidth, 1);
    const touchesLeft = line.left <= pageWidth * 0.2;
    const touchesRight = line.right >= pageWidth * 0.8;

    return widthRatio >= 0.65 ||
        (widthRatio >= 0.52 && touchesLeft && touchesRight);
}

function isStructuralLine(line, state) {
    if (isFullWidthLine(line, state)) {
        return true;
    }

    const text = getLineText(line);
    const pageWidth = getRenderedPageWidth(state);

    return isProbablyHeadingText(text) &&
        (line.width / Math.max(pageWidth, 1)) <= 0.65;
}

function groupWordsIntoVisualLines(words, state) {
    const pageWidth = getRenderedPageWidth(state);
    const sortedWords = [...words].sort((first, second) => {
        const fontHeight = Math.max(first.height || 12, second.height || 12);

        return Math.abs(first.lineY - second.lineY) > Math.max(2, fontHeight * 0.4)
            ? first.lineY - second.lineY
            : first.left - second.left;
    });
    const rows = [];

    for (const word of sortedWords) {
        const yTolerance = Math.max(2, (word.height || 12) * 0.4);
        let targetRow = rows.find(row => Math.abs(row.lineY - word.lineY) <= yTolerance);

        if (!targetRow) {
            targetRow = {
                lineY: word.lineY,
                words: []
            };
            rows.push(targetRow);
        }

        targetRow.words.push(word);
    }

    const lines = [];

    for (const row of rows) {
        const rowWords = row.words.sort((first, second) => first.left - second.left);
        let currentLineWords = [];

        for (const word of rowWords) {
            const previous = currentLineWords[currentLineWords.length - 1];

            if (!previous) {
                currentLineWords.push(word);
                continue;
            }

            const fontHeight = Math.max(previous.height || 12, word.height || 12);

            if ((word.left - previous.right) > Math.max(fontHeight * 2.8, pageWidth * 0.022)) {
                lines.push(createVisualLineFromWords(currentLineWords));
                currentLineWords = [word];
            } else {
                currentLineWords.push(word);
            }
        }

        if (currentLineWords.length > 0) {
            lines.push(createVisualLineFromWords(currentLineWords));
        }
    }

    return lines.sort(compareLinePosition);
}

function createVisualLineFromWords(words) {
    const left = Math.min(...words.map(word => word.left));
    const right = Math.max(...words.map(word => word.right));
    const top = Math.min(...words.map(word => word.top));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        words,
        left,
        right,
        top,
        bottom,
        lineY: words.reduce((sum, word) => sum + word.lineY, 0) / words.length,
        width: right - left,
        height: bottom - top,
        centerX: (left + right) / 2
    };
}

function getHorizontalOverlapRatio(line, column) {
    const overlap = Math.min(line.right, column.right) -
        Math.max(line.left, column.left);

    return overlap <= 0
        ? 0
        : overlap / Math.min(line.width, column.right - column.left);
}

function groupLinesIntoColumns(lines, state) {
    const columns = [];

    for (const line of [...lines].sort(compareLinePosition)) {
        if (isStructuralLine(line, state)) {
            columns.push({
                lines: [line],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: true
            });
            continue;
        }

        let bestColumn = null;
        let bestScore = 0;

        for (const column of columns) {
            if (column.isStructural) {
                continue;
            }

            const overlapScore = getHorizontalOverlapRatio(line, column);
            const xTolerance = Math.max(3, getLineFontHeight(line) * 0.75);
            const score = line.centerX >= column.left - xTolerance &&
                line.centerX <= column.right + xTolerance
                ? Math.max(overlapScore, 0.5)
                : overlapScore;

            if (score > bestScore) {
                bestScore = score;
                bestColumn = column;
            }
        }

        if (!bestColumn || bestScore < 0.25) {
            bestColumn = {
                lines: [],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: false
            };
            columns.push(bestColumn);
        }

        bestColumn.lines.push(line);
        bestColumn.left = Math.min(bestColumn.left, line.left);
        bestColumn.right = Math.max(bestColumn.right, line.right);
        bestColumn.top = Math.min(bestColumn.top, line.top);
        bestColumn.bottom = Math.max(bestColumn.bottom, line.bottom);
    }

    return columns;
}

function getCopyLinesInReadingOrder(words, state) {
    const lines = groupWordsIntoVisualLines(words, state);

    if (lines.length === 0) {
        return [];
    }

    const sortedLines = [...lines].sort(compareLinePosition);
    const output = [];
    let sectionLines = [];

    function flushSection() {
        if (sectionLines.length === 0) {
            return;
        }

        const columns = groupLinesIntoColumns(sectionLines, state)
            .filter(column => !column.isStructural)
            .sort((first, second) => first.left - second.left);

        for (const column of columns) {
            for (const line of column.lines.sort(compareLinePosition)) {
                output.push(line.words);
            }
        }

        sectionLines = [];
    }

    for (const line of sortedLines) {
        if (isStructuralLine(line, state)) {
            flushSection();
            output.push(line.words);
            continue;
        }

        sectionLines.push(line);
    }

    flushSection();
    return output;
}

function shouldInsertSpaceBetweenWords(previous, current) {
    if (!previous || !current) {
        return false;
    }

    const previousText = previous.text ?? "";
    const currentText = current.text ?? "";

    if (!previousText ||
        !currentText ||
        /^[,.;:!?%)\]\}]/.test(currentText) ||
        /[(\[\{]$/.test(previousText)) {
        return false;
    }

    return (current.left - previous.right) >
        Math.max(2, Math.max(previous.height || 0, current.height || 0, 10) * 0.22);
}

function buildCopiedLineText(lineWords) {
    const sortedWords = [...lineWords].sort((first, second) => first.left - second.left);
    let result = "";
    let previous = null;

    for (const word of sortedWords) {
        if (!word.text) {
            continue;
        }

        if (previous && shouldInsertSpaceBetweenWords(previous, word)) {
            result += " ";
        }

        result += word.text;
        previous = word;
    }

    return result
        .replace(/\s+([,.;:!?%)\]\}])/g, "$1")
        .replace(/([(\[\{])\s+/g, "$1")
        .replace(/\s{2,}/g, " ")
        .trim();
}

function shouldSplitHighlightSegment(previous, current, state) {
    if (!previous || !current) {
        return false;
    }

    const gap = current.left - previous.right;
    const fontHeight = Math.max(previous.height || 12, current.height || 12);
    const pageWidth = getRenderedPageWidth(state);

    return gap > Math.max(fontHeight * 1.15, pageWidth * 0.012, 8);
}

function createHighlightSegment(words) {
    const left = Math.min(...words.map(word => word.left));
    const top = Math.min(...words.map(word => word.top));
    const right = Math.max(...words.map(word => word.right));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function buildHighlightSegments(words, state) {
    const segments = [];
    const lines = groupWordsIntoVisualLines(words, state);

    for (const line of lines) {
        const sortedWords = [...line.words].sort((first, second) => first.left - second.left);
        let segmentWords = [];

        for (const word of sortedWords) {
            const previous = segmentWords[segmentWords.length - 1];

            if (previous && shouldSplitHighlightSegment(previous, word, state)) {
                segments.push(createHighlightSegment(segmentWords));
                segmentWords = [];
            }

            segmentWords.push(word);
        }

        if (segmentWords.length > 0) {
            segments.push(createHighlightSegment(segmentWords));
        }
    }

    return segments;
}

function getCustomSelectedText() {
    if (!customSelection) {
        return "";
    }

    const selectedLines = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const pageLines = getCopyLinesInReadingOrder(words, state)
            .map(lineWords => buildCopiedLineText(lineWords))
            .filter(line => line.length > 0);

        selectedLines.push(...pageLines);
    }

    return selectedLines.join("\n");
}

function getSelectedHighlightRects() {
    if (!customSelection) {
        return [];
    }

    const result = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const scale = state.renderedScale || currentScale || 1;

        for (const segment of buildHighlightSegments(words, state)) {
            result.push({
                pageNumber: state.pageNumber,
                left: segment.left / scale,
                top: segment.top / scale,
                width: segment.width / scale,
                height: segment.height / scale
            });
        }
    }

    return result;
}

function renderStoredHighlightsForPage(state) {
    if (!state.highlightLayer) {
        return;
    }

    state.highlightLayer.innerHTML = "";

    const scale = state.renderedScale || currentScale || 1;

    for (const highlight of storedHighlights) {
        const rects = highlight.rects ?? highlight.Rects ?? [];

        for (const rect of rects) {
            const pageNumber = rect.pageNumber ?? rect.PageNumber;

            if (pageNumber !== state.pageNumber) {
                continue;
            }

            const left = rect.left ?? rect.Left ?? 0;
            const top = rect.top ?? rect.Top ?? 0;
            const width = rect.width ?? rect.Width ?? 0;
            const height = rect.height ?? rect.Height ?? 0;
            const item = document.createElement("div");

            item.className = "highlightItem";
            item.dataset.highlightId = highlight.id ?? highlight.Id ?? "";
            item.style.left = `${left * scale}px`;
            item.style.top = `${top * scale}px`;
            item.style.width = `${width * scale}px`;
            item.style.height = `${height * scale}px`;

            state.highlightLayer.appendChild(item);
        }
    }
}

function renderAllStoredHighlights() {
    for (const state of pageStates.values()) {
        renderStoredHighlightsForPage(state);
    }
}

function setStoredHighlights(highlights) {
    storedHighlights = Array.isArray(highlights)
        ? highlights
        : [];
    renderAllStoredHighlights();
}

function navigateToStoredHighlight(highlightId) {
    const highlight = storedHighlights.find(item =>
        (item.id ?? item.Id) === highlightId
    );

    if (!highlight) {
        return;
    }

    const rects = highlight.rects ?? highlight.Rects ?? [];

    if (rects.length === 0) {
        return;
    }

    const firstRect = rects[0];
    const pageNumber = firstRect.pageNumber ?? firstRect.PageNumber ?? 1;

    clearCustomSelection();
    scrollToPage(pageNumber);

    setTimeout(async () => {
        await renderVisiblePages(true);
        renderAllStoredHighlights();

        const state = pageStates.get(pageNumber);

        if (!state) {
            return;
        }

        const scale = state.renderedScale || currentScale || 1;
        const top = (firstRect.top ?? firstRect.Top ?? 0) * scale;

        viewer.scrollTop = state.wrapper.offsetTop + top - 80;
    }, 120);
}

function createHighlightFromSelection() {
    const text = getCustomSelectedText();
    const rects = getSelectedHighlightRects();

    if (!text || rects.length === 0) {
        return;
    }

    const firstRect = rects[0];

    sendToCSharp("highlightCreated", {
        text,
        pageNumber: firstRect.pageNumber,
        rects
    });

    clearCustomSelection();
}

function scheduleZoom(newScale, anchorClientX = null, anchorClientY = null) {
    clearCustomSelection();
    window.getSelection()?.removeAllRanges();

    const anchor = getZoomAnchor(anchorClientX, anchorClientY);

    visualScale = clampScale(newScale);
    isLiveZooming = true;

    viewer.classList.add("viewerLiveZoom");

    for (const state of pageStates.values()) {
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(anchor);
    clearTimeout(zoomTimer);

    zoomTimer = setTimeout(async () => {
        await finishZoom(visualScale, anchor);
    }, 300);
}

async function finishZoom(finalScale, zoomAnchor = null) {
    currentScale = clampScale(finalScale);
    visualScale = currentScale;
    isLiveZooming = false;

    viewer.classList.remove("viewerLiveZoom");

    await cancelActiveRenderTasks();

    for (const state of pageStates.values()) {
        state.isRendered = false;
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());

    await renderVisiblePages(true);

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());
    updateCurrentPageFromScroll();
    sendToCSharp("zoomChanged", {
        pageNumber: currentPage
    });
}

window.miniZoteroPdf = {
    goToPage(pageNumber) {
        scrollToPage(pageNumber);
        renderVisiblePages();
    },

    zoomIn() {
        scheduleZoom(visualScale + 0.25);
    },

    zoomOut() {
        scheduleZoom(visualScale - 0.25);
    },

    setZoom(percent) {
        scheduleZoom(percent / 100);
    },

    setToolMode(toolMode) {
        setToolMode(toolMode);
    },

    setHighlights(highlights) {
        setStoredHighlights(highlights);
    },

    goToHighlight(highlightId) {
        navigateToStoredHighlight(highlightId);
    },

    getState() {
        sendToCSharp("state", {
            pageNumber: currentPage
        });
    }
};

async function boot() {
    try {
        setToolMode(currentToolMode);

        const fileUrl = getQueryValue("file");

        if (!fileUrl) {
            throw new Error("Missing file query parameter.");
        }

        const startPage = Number(getHashValue("page", "1"));
        const startZoom = Number(getHashValue("zoom", "120"));

        currentPage = Number.isFinite(startPage) && startPage > 0 ? startPage : 1;
        currentScale = Number.isFinite(startZoom) && startZoom > 0
            ? clampScale(startZoom / 100)
            : 1.2;
        visualScale = currentScale;

        statusBar.textContent = "Loading PDF...";

        pdfDocument = await pdfjsLib.getDocument({
            url: fileUrl,
            cMapUrl: "/PdfJs/cmaps/",
            cMapPacked: true,
            standardFontDataUrl: "/PdfJs/standard_fonts/",
            useSystemFonts: true
        }).promise;

        await createPagePlaceholders();

        setTimeout(async () => {
            scrollToPage(currentPage, false);
            await renderVisiblePages(true);
            statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
            sendToCSharp("loaded", { pageNumber: currentPage });
        }, 150);
    } catch (error) {
        statusBar.textContent = "Failed to load PDF";

        const errorBox = document.createElement("div");
        errorBox.className = "error";
        errorBox.textContent = error?.message || String(error);

        viewer.innerHTML = "";
        viewer.appendChild(errorBox);
    }
}

viewer.addEventListener("scroll", () => {
    clearTimeout(scrollTimer);

    scrollTimer = setTimeout(async () => {
        updateCurrentPageFromScroll();
        await renderVisiblePages();
        renderCustomSelection();
    }, 120);
}, { passive: true });

viewer.addEventListener("pointerdown", event => {
    if (currentToolMode === "hand") {
        startHandPan(event);
        return;
    }

    if (event.button !== 0 || isLiveZooming) {
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY, false);

    if (!hit) {
        const pageState = findRenderedPageAtClientPoint(event.clientX, event.clientY);

        if (!pageState) {
            clearCustomSelection();
            return;
        }

        event.preventDefault();

        customSelection = {
            mode: "area",
            startClientX: event.clientX,
            startClientY: event.clientY,
            endClientX: event.clientX,
            endClientY: event.clientY,
            isDragging: true,
            wordIndexesByPage: new Map()
        };

        viewer.setPointerCapture?.(event.pointerId);
        clearAllSelectionOverlays();
        return;
    }

    event.preventDefault();

    customSelection = {
        mode: "word",
        startPage: hit.state.pageNumber,
        startWordIndex: hit.word.index,
        endPage: hit.state.pageNumber,
        endWordIndex: hit.word.index,
        isDragging: true
    };

    viewer.setPointerCapture?.(event.pointerId);
    renderCustomSelection();
});

viewer.addEventListener("pointermove", event => {
    if (currentToolMode === "hand") {
        moveHandPan(event);
        return;
    }

    if (!customSelection?.isDragging || isLiveZooming) {
        return;
    }

    if (customSelection.mode === "area") {
        event.preventDefault();

        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;

        renderAreaSelectionBox(customSelection);
        updateAreaSelectionWords(customSelection);
        renderCustomSelection();
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY);

    if (!hit) {
        return;
    }

    event.preventDefault();

    customSelection.endPage = hit.state.pageNumber;
    customSelection.endWordIndex = hit.word.index;

    renderCustomSelection();
});

viewer.addEventListener("pointerup", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;

    if (customSelection.mode === "area") {
        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;
        updateAreaSelectionWords(customSelection);
    }

    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    renderCustomSelection();

    if (currentToolMode === "highlight") {
        createHighlightFromSelection();
    }
});

viewer.addEventListener("pointercancel", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;
    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }
});

viewer.addEventListener("wheel", event => {
    if (!event.ctrlKey) {
        return;
    }

    event.preventDefault();

    const direction = event.deltaY < 0 ? 1 : -1;
    const factor = direction > 0 ? 1.1 : 0.9;

    scheduleZoom(visualScale * factor, event.clientX, event.clientY);
}, { passive: false });

document.addEventListener("copy", event => {
    const text = getCustomSelectedText();

    if (!text) {
        return;
    }

    event.preventDefault();
    event.clipboardData?.setData("text/plain", text);
});

document.addEventListener("keydown", event => {
    if (event.key === "Escape") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
        return;
    }

    if (event.ctrlKey && event.key.toLowerCase() === "h") {
        event.preventDefault();
        createHighlightFromSelection();
    }
});

boot();

````

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/build/pdf.mjs

_Skipped binary or large file. Size: 817035 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/build/pdf.worker.mjs

_Skipped binary or large file. Size: 2161149 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78-EUC-H.bcmap

_Skipped binary or large file. Size: 2404 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78-EUC-V.bcmap

_Skipped binary or large file. Size: 173 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78-H.bcmap

_Skipped binary or large file. Size: 2379 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78ms-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2651 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78ms-RKSJ-V.bcmap

_Skipped binary or large file. Size: 290 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2398 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78-RKSJ-V.bcmap

_Skipped binary or large file. Size: 173 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/78-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/83pv-RKSJ-H.bcmap

_Skipped binary or large file. Size: 905 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/90msp-RKSJ-H.bcmap

_Skipped binary or large file. Size: 715 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/90msp-RKSJ-V.bcmap

_Skipped binary or large file. Size: 291 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/90ms-RKSJ-H.bcmap

_Skipped binary or large file. Size: 721 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/90ms-RKSJ-V.bcmap

_Skipped binary or large file. Size: 290 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/90pv-RKSJ-H.bcmap

_Skipped binary or large file. Size: 982 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/90pv-RKSJ-V.bcmap

_Skipped binary or large file. Size: 260 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Add-H.bcmap

_Skipped binary or large file. Size: 2419 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Add-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2413 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Add-RKSJ-V.bcmap

_Skipped binary or large file. Size: 287 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Add-V.bcmap

_Skipped binary or large file. Size: 282 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-0.bcmap

_Skipped binary or large file. Size: 317 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-1.bcmap

_Skipped binary or large file. Size: 371 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-2.bcmap

_Skipped binary or large file. Size: 376 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-3.bcmap

_Skipped binary or large file. Size: 401 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-4.bcmap

_Skipped binary or large file. Size: 405 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-5.bcmap

_Skipped binary or large file. Size: 406 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-6.bcmap

_Skipped binary or large file. Size: 406 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-CNS1-UCS2.bcmap

_Skipped binary or large file. Size: 41193 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-0.bcmap

_Skipped binary or large file. Size: 217 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-1.bcmap

_Skipped binary or large file. Size: 250 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-2.bcmap

_Skipped binary or large file. Size: 465 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-3.bcmap

_Skipped binary or large file. Size: 470 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-4.bcmap

_Skipped binary or large file. Size: 601 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-5.bcmap

_Skipped binary or large file. Size: 625 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-GB1-UCS2.bcmap

_Skipped binary or large file. Size: 33974 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-0.bcmap

_Skipped binary or large file. Size: 225 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-1.bcmap

_Skipped binary or large file. Size: 226 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-2.bcmap

_Skipped binary or large file. Size: 233 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-3.bcmap

_Skipped binary or large file. Size: 242 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-4.bcmap

_Skipped binary or large file. Size: 337 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-5.bcmap

_Skipped binary or large file. Size: 430 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-6.bcmap

_Skipped binary or large file. Size: 485 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Japan1-UCS2.bcmap

_Skipped binary or large file. Size: 40951 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Korea1-0.bcmap

_Skipped binary or large file. Size: 241 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Korea1-1.bcmap

_Skipped binary or large file. Size: 386 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Korea1-2.bcmap

_Skipped binary or large file. Size: 391 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Adobe-Korea1-UCS2.bcmap

_Skipped binary or large file. Size: 23293 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/B5-H.bcmap

_Skipped binary or large file. Size: 1086 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/B5pc-H.bcmap

_Skipped binary or large file. Size: 1099 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/B5pc-V.bcmap

_Skipped binary or large file. Size: 144 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/B5-V.bcmap

_Skipped binary or large file. Size: 142 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/CNS1-H.bcmap

_Skipped binary or large file. Size: 706 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/CNS1-V.bcmap

_Skipped binary or large file. Size: 143 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/CNS2-H.bcmap

_Skipped binary or large file. Size: 504 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/CNS2-V.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE�CNS2-H
````

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/CNS-EUC-H.bcmap

_Skipped binary or large file. Size: 1780 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/CNS-EUC-V.bcmap

_Skipped binary or large file. Size: 1920 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/ETen-B5-H.bcmap

_Skipped binary or large file. Size: 1125 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/ETen-B5-V.bcmap

_Skipped binary or large file. Size: 158 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/ETenms-B5-H.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE�	ETen-B5-H` ^
````

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/ETenms-B5-V.bcmap

_Skipped binary or large file. Size: 172 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/ETHK-B5-H.bcmap

_Skipped binary or large file. Size: 4426 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/ETHK-B5-V.bcmap

_Skipped binary or large file. Size: 158 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/EUC-H.bcmap

_Skipped binary or large file. Size: 578 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/EUC-V.bcmap

_Skipped binary or large file. Size: 170 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Ext-H.bcmap

_Skipped binary or large file. Size: 2536 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Ext-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2542 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Ext-RKSJ-V.bcmap

_Skipped binary or large file. Size: 218 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Ext-V.bcmap

_Skipped binary or large file. Size: 215 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GB-EUC-H.bcmap

_Skipped binary or large file. Size: 549 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GB-EUC-V.bcmap

_Skipped binary or large file. Size: 179 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GB-H.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE!!��]aX!!]`�21�>	�p�z�$]��"R�d�-U�7�*�4�%�+ �Z �{�/�%�<�9K�b�1]�.�"��`]�,�"]�
�"]�h�"]�F�"]�$�"]��"]�`�"]�>�"]��"]�z�"]�X�"]�6�"]��"]�r�"]�P�"]�.�"]��"]�j�"]�H�"]�&�"]��"]�b�"]�@�"]��"]�|�"]�Z�"]�8�"]��"]�t�"]�R�"]�0�"]��"]�l�"]�J�"]�(�"]��"]�d�"]�B�"]� �"X�~�']�W�"]�5�"]��"]�q�"]�O�"]�-�"]��"]�i�"]�G�"]�%�"]��"]�a�"]�?�"]��"]�{�"]�Y�"]�7�"]��"]�s�"]�Q�"]�/�"]��"]�k�"]�I�"]�'�"]��"]�c�"]�A�"]��"]�}�"]�[�"]�9
````

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBK2K-H.bcmap

_Skipped binary or large file. Size: 19662 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBK2K-V.bcmap

_Skipped binary or large file. Size: 219 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBK-EUC-H.bcmap

_Skipped binary or large file. Size: 14692 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBK-EUC-V.bcmap

_Skipped binary or large file. Size: 180 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBKp-EUC-H.bcmap

_Skipped binary or large file. Size: 14686 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBKp-EUC-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBpc-EUC-H.bcmap

_Skipped binary or large file. Size: 557 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBpc-EUC-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBT-EUC-H.bcmap

_Skipped binary or large file. Size: 7290 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBT-EUC-V.bcmap

_Skipped binary or large file. Size: 180 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBT-H.bcmap

_Skipped binary or large file. Size: 7269 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBTpc-EUC-H.bcmap

_Skipped binary or large file. Size: 7298 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBTpc-EUC-V.bcmap

_Skipped binary or large file. Size: 182 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GBT-V.bcmap

_Skipped binary or large file. Size: 176 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/GB-V.bcmap

_Skipped binary or large file. Size: 175 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/H.bcmap

_Skipped binary or large file. Size: 553 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Hankaku.bcmap

_Skipped binary or large file. Size: 132 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Hiragana.bcmap

_Skipped binary or large file. Size: 124 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKdla-B5-H.bcmap

_Skipped binary or large file. Size: 2654 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKdla-B5-V.bcmap

_Skipped binary or large file. Size: 148 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKdlb-B5-H.bcmap

_Skipped binary or large file. Size: 2414 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKdlb-B5-V.bcmap

_Skipped binary or large file. Size: 148 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKgccs-B5-H.bcmap

_Skipped binary or large file. Size: 2292 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKgccs-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKm314-B5-H.bcmap

_Skipped binary or large file. Size: 1772 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKm314-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKm471-B5-H.bcmap

_Skipped binary or large file. Size: 2171 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKm471-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKscs-B5-H.bcmap

_Skipped binary or large file. Size: 4437 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/HKscs-B5-V.bcmap

_Skipped binary or large file. Size: 159 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Katakana.bcmap

_Skipped binary or large file. Size: 100 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSC-EUC-H.bcmap

_Skipped binary or large file. Size: 1848 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSC-EUC-V.bcmap

_Skipped binary or large file. Size: 164 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSC-H.bcmap

_Skipped binary or large file. Size: 1831 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSC-Johab-H.bcmap

_Skipped binary or large file. Size: 16791 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSC-Johab-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSCms-UHC-H.bcmap

_Skipped binary or large file. Size: 2787 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSCms-UHC-HW-H.bcmap

_Skipped binary or large file. Size: 2789 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSCms-UHC-HW-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSCms-UHC-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSCpc-EUC-H.bcmap

_Skipped binary or large file. Size: 2024 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSCpc-EUC-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/KSC-V.bcmap

_Skipped binary or large file. Size: 160 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/LICENSE

``text
%%Copyright: -----------------------------------------------------------
%%Copyright: Copyright 1990-2009 Adobe Systems Incorporated.
%%Copyright: All rights reserved.
%%Copyright:
%%Copyright: Redistribution and use in source and binary forms, with or
%%Copyright: without modification, are permitted provided that the
%%Copyright: following conditions are met:
%%Copyright:
%%Copyright: Redistributions of source code must retain the above
%%Copyright: copyright notice, this list of conditions and the following
%%Copyright: disclaimer.
%%Copyright:
%%Copyright: Redistributions in binary form must reproduce the above
%%Copyright: copyright notice, this list of conditions and the following
%%Copyright: disclaimer in the documentation and/or other materials
%%Copyright: provided with the distribution. 
%%Copyright:
%%Copyright: Neither the name of Adobe Systems Incorporated nor the names
%%Copyright: of its contributors may be used to endorse or promote
%%Copyright: products derived from this software without specific prior
%%Copyright: written permission. 
%%Copyright:
%%Copyright: THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
%%Copyright: CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
%%Copyright: INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
%%Copyright: MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
%%Copyright: DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
%%Copyright: CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
%%Copyright: SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
%%Copyright: NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
%%Copyright: LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
%%Copyright: HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
%%Copyright: CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
%%Copyright: OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
%%Copyright: SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
%%Copyright: -----------------------------------------------------------

````

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/NWP-H.bcmap

_Skipped binary or large file. Size: 2765 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/NWP-V.bcmap

_Skipped binary or large file. Size: 252 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/RKSJ-H.bcmap

_Skipped binary or large file. Size: 534 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/RKSJ-V.bcmap

_Skipped binary or large file. Size: 170 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/Roman.bcmap

_Skipped binary or large file. Size: 96 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UCS2-H.bcmap

_Skipped binary or large file. Size: 48280 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UCS2-V.bcmap

_Skipped binary or large file. Size: 156 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UTF16-H.bcmap

_Skipped binary or large file. Size: 50419 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UTF16-V.bcmap

_Skipped binary or large file. Size: 156 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UTF32-H.bcmap

_Skipped binary or large file. Size: 52679 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UTF32-V.bcmap

_Skipped binary or large file. Size: 160 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UTF8-H.bcmap

_Skipped binary or large file. Size: 53629 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniCNS-UTF8-V.bcmap

_Skipped binary or large file. Size: 157 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UCS2-H.bcmap

_Skipped binary or large file. Size: 43366 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UCS2-V.bcmap

_Skipped binary or large file. Size: 193 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UTF16-H.bcmap

_Skipped binary or large file. Size: 44086 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UTF16-V.bcmap

_Skipped binary or large file. Size: 178 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UTF32-H.bcmap

_Skipped binary or large file. Size: 45738 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UTF32-V.bcmap

_Skipped binary or large file. Size: 182 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UTF8-H.bcmap

_Skipped binary or large file. Size: 46837 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniGB-UTF8-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS2004-UTF16-H.bcmap

_Skipped binary or large file. Size: 39534 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS2004-UTF16-V.bcmap

_Skipped binary or large file. Size: 647 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS2004-UTF32-H.bcmap

_Skipped binary or large file. Size: 40630 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS2004-UTF32-V.bcmap

_Skipped binary or large file. Size: 681 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS2004-UTF8-H.bcmap

_Skipped binary or large file. Size: 41779 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS2004-UTF8-V.bcmap

_Skipped binary or large file. Size: 682 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISPro-UCS2-HW-V.bcmap

_Skipped binary or large file. Size: 705 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISPro-UCS2-V.bcmap

_Skipped binary or large file. Size: 689 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISPro-UTF8-V.bcmap

_Skipped binary or large file. Size: 726 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UCS2-H.bcmap

_Skipped binary or large file. Size: 25439 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UCS2-HW-H.bcmap

_Skipped binary or large file. Size: 119 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UCS2-HW-V.bcmap

_Skipped binary or large file. Size: 680 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UCS2-V.bcmap

_Skipped binary or large file. Size: 664 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UTF16-H.bcmap

_Skipped binary or large file. Size: 39443 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UTF16-V.bcmap

_Skipped binary or large file. Size: 643 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UTF32-H.bcmap

_Skipped binary or large file. Size: 40539 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UTF32-V.bcmap

_Skipped binary or large file. Size: 677 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UTF8-H.bcmap

_Skipped binary or large file. Size: 41695 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJIS-UTF8-V.bcmap

_Skipped binary or large file. Size: 678 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISX02132004-UTF32-H.bcmap

_Skipped binary or large file. Size: 40608 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISX02132004-UTF32-V.bcmap

_Skipped binary or large file. Size: 688 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISX0213-UTF32-H.bcmap

_Skipped binary or large file. Size: 40517 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniJISX0213-UTF32-V.bcmap

_Skipped binary or large file. Size: 684 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UCS2-H.bcmap

_Skipped binary or large file. Size: 25783 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UCS2-V.bcmap

_Skipped binary or large file. Size: 178 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UTF16-H.bcmap

_Skipped binary or large file. Size: 26327 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UTF16-V.bcmap

_Skipped binary or large file. Size: 164 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UTF32-H.bcmap

_Skipped binary or large file. Size: 26451 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UTF32-V.bcmap

_Skipped binary or large file. Size: 168 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UTF8-H.bcmap

_Skipped binary or large file. Size: 27790 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/UniKS-UTF8-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/cmaps/WP-Symbol.bcmap

_Skipped binary or large file. Size: 179 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitDingbats.pfb

_Skipped binary or large file. Size: 29513 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitFixed.pfb

_Skipped binary or large file. Size: 17597 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitFixedBold.pfb

_Skipped binary or large file. Size: 18055 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitFixedBoldItalic.pfb

_Skipped binary or large file. Size: 19151 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitFixedItalic.pfb

_Skipped binary or large file. Size: 18746 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitSerif.pfb

_Skipped binary or large file. Size: 19469 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitSerifBold.pfb

_Skipped binary or large file. Size: 19395 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitSerifBoldItalic.pfb

_Skipped binary or large file. Size: 20733 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitSerifItalic.pfb

_Skipped binary or large file. Size: 21227 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/FoxitSymbol.pfb

_Skipped binary or large file. Size: 16729 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/LiberationSans-Bold.ttf

_Skipped binary or large file. Size: 137052 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/LiberationSans-BoldItalic.ttf

_Skipped binary or large file. Size: 135124 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/LiberationSans-Italic.ttf

_Skipped binary or large file. Size: 162036 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/LiberationSans-Regular.ttf

_Skipped binary or large file. Size: 139512 bytes._

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/LICENSE_FOXIT

``text
// Copyright 2014 PDFium Authors. All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//    * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//    * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

````

## MiniZotero/bin/Debug/net8.0/Assets/PdfJs/standard_fonts/LICENSE_LIBERATION

``text
Digitized data copyright (c) 2010 Google Corporation
	with Reserved Font Arimo, Tinos and Cousine.
Copyright (c) 2012 Red Hat, Inc.
	with Reserved Font Name Liberation.

This Font Software is licensed under the SIL Open Font License,
Version 1.1.

This license is copied below, and is also available with a FAQ at:
http://scripts.sil.org/OFL

SIL OPEN FONT LICENSE Version 1.1 - 26 February 2007

PREAMBLE The goals of the Open Font License (OFL) are to stimulate
worldwide development of collaborative font projects, to support the font
creation efforts of academic and linguistic communities, and to provide
a free and open framework in which fonts may be shared and improved in
partnership with others.

The OFL allows the licensed fonts to be used, studied, modified and
redistributed freely as long as they are not sold by themselves.
The fonts, including any derivative works, can be bundled, embedded,
redistributed and/or sold with any software provided that any reserved
names are not used by derivative works.  The fonts and derivatives,
however, cannot be released under any other type of license.  The
requirement for fonts to remain under this license does not apply to
any document created using the fonts or their derivatives.

 

DEFINITIONS
"Font Software" refers to the set of files released by the Copyright
Holder(s) under this license and clearly marked as such.
This may include source files, build scripts and documentation.

"Reserved Font Name" refers to any names specified as such after the
copyright statement(s).

"Original Version" refers to the collection of Font Software components
as distributed by the Copyright Holder(s).

"Modified Version" refers to any derivative made by adding to, deleting,
or substituting ? in part or in whole ?
any of the components of the Original Version, by changing formats or
by porting the Font Software to a new environment.

"Author" refers to any designer, engineer, programmer, technical writer
or other person who contributed to the Font Software.


PERMISSION & CONDITIONS

Permission is hereby granted, free of charge, to any person obtaining a
copy of the Font Software, to use, study, copy, merge, embed, modify,
redistribute, and sell modified and unmodified copies of the Font
Software, subject to the following conditions:

1) Neither the Font Software nor any of its individual components,in
   Original or Modified Versions, may be sold by itself.

2) Original or Modified Versions of the Font Software may be bundled,
   redistributed and/or sold with any software, provided that each copy
   contains the above copyright notice and this license. These can be
   included either as stand-alone text files, human-readable headers or
   in the appropriate machine-readable metadata fields within text or
   binary files as long as those fields can be easily viewed by the user.

3) No Modified Version of the Font Software may use the Reserved Font
   Name(s) unless explicit written permission is granted by the
   corresponding Copyright Holder. This restriction only applies to the
   primary font name as presented to the users.

4) The name(s) of the Copyright Holder(s) or the Author(s) of the Font
   Software shall not be used to promote, endorse or advertise any
   Modified Version, except to acknowledge the contribution(s) of the
   Copyright Holder(s) and the Author(s) or with their explicit written
   permission.

5) The Font Software, modified or unmodified, in part or in whole, must
   be distributed entirely under this license, and must not be distributed
   under any other license. The requirement for fonts to remain under
   this license does not apply to any document created using the Font
   Software.


 
TERMINATION
This license becomes null and void if any of the above conditions are not met.

 

DISCLAIMER
THE FONT SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO ANY WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT
OF COPYRIGHT, PATENT, TRADEMARK, OR OTHER RIGHT.  IN NO EVENT SHALL THE
COPYRIGHT HOLDER BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
INCLUDING ANY GENERAL, SPECIAL, INDIRECT, INCIDENTAL, OR CONSEQUENTIAL
DAMAGES, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF THE USE OR INABILITY TO USE THE FONT SOFTWARE OR FROM OTHER
DEALINGS IN THE FONT SOFTWARE.


````

## MiniZotero/bin/Debug/net8.0/Assets/PdfViewer/index.html

``html
<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>MiniZotero PDF Viewer</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="app">
        <div id="status">Loading PDF...</div>
        <div id="viewer"></div>
    </div>

    <script type="module" src="viewer.js"></script>
</body>
</html>

````

## MiniZotero/bin/Debug/net8.0/Assets/PdfViewer/style.css

``css
html,
body {
    margin: 0;
    padding: 0;
    height: 100%;
    background: #e8ecf2;
    font-family: Segoe UI, Arial, sans-serif;
    overflow: hidden;
    user-select: text;
    -webkit-user-select: text;
}

#app {
    height: 100%;
    display: flex;
    flex-direction: column;
}

#status {
    display: none;
}

#viewer {
    position: relative;
    flex: 1;
    overflow: auto;
    padding: 24px 0;
    box-sizing: border-box;
    user-select: none;
    -webkit-user-select: none;
}

#viewer.toolSelect {
    cursor: text;
}

#viewer.toolHighlight {
    cursor: text;
}

#viewer.toolHand {
    cursor: grab;
}

#viewer.toolHand.panning {
    cursor: grabbing;
}

#viewer.viewerLiveZoom .textLayer,
.viewerLiveZoom .textLayer {
    pointer-events: none;
    user-select: none;
}

.page {
    position: relative;
    display: block;
    margin: 0 auto 22px auto;
    background: transparent;
}

.pageContent {
    position: absolute;
    top: 0;
    left: 0;
    background: white;
    overflow: hidden;
    transform-origin: 0 0;
    box-shadow: 0 4px 18px rgba(0, 0, 0, 0.18);
    user-select: text;
    -webkit-user-select: text;
}

.canvasLayer {
    position: absolute;
    left: 0;
    top: 0;
    display: block;
    image-rendering: auto;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
    z-index: 0;
}

.textLayer {
    position: absolute;
    inset: 0;
    overflow: hidden;
    opacity: 1;
    line-height: 1;
    text-align: initial;
    transform-origin: 0 0;
    forced-color-adjust: none;
    z-index: 2;
    cursor: text;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
}

.textLayer span,
.textLayer br {
    position: absolute;
    color: transparent;
    white-space: pre;
    cursor: text;
    transform-origin: 0% 0%;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
}

.textLayer ::selection,
.textLayer span::selection {
    background: transparent !important;
}

.textLayer .markedContent {
    display: contents;
}

.textLayer .endOfContent {
    display: block;
    position: absolute;
    inset: 100% 0 0;
    z-index: 0;
    cursor: default;
    user-select: none;
}

.highlightLayer {
    position: absolute;
    left: 0;
    top: 0;
    pointer-events: none;
    z-index: 1;
}

.highlightLayer .highlightItem {
    position: absolute;
    background: rgba(250, 204, 21, 0.34);
    border-radius: 2px;
    pointer-events: none;
}

.highlightLayer .highlightItem:hover {
    background: rgba(250, 204, 21, 0.52);
}

.highlightLayer.isInteractive {
    z-index: 3;
    pointer-events: auto;
}

.highlightLayer.isInteractive .highlightItem {
    cursor: pointer;
    pointer-events: auto;
}

.selectionOverlay {
    position: absolute;
    inset: 0;
    pointer-events: none;
    z-index: 3;
}

.selectionOverlayRect {
    position: absolute;
    background: rgba(245, 158, 11, 0.28);
    border-radius: 2px;
    pointer-events: none;
}

.selectionDragBox {
    position: absolute;
    border: 1px solid rgba(59, 130, 246, 0.7);
    background: rgba(59, 130, 246, 0.08);
    border-radius: 3px;
    pointer-events: none;
    z-index: 10;
}

.error {
    margin: 40px auto;
    max-width: 520px;
    background: white;
    color: #b91c1c;
    border: 1px solid #fecaca;
    border-radius: 8px;
    padding: 16px;
    font-size: 13px;
}

````

## MiniZotero/bin/Debug/net8.0/Assets/PdfViewer/viewer.js

``javascript
import * as pdfjsLib from "../PdfJs/build/pdf.mjs";

pdfjsLib.GlobalWorkerOptions.workerSrc = "../PdfJs/build/pdf.worker.mjs";

const viewer = document.getElementById("viewer");
const statusBar = document.getElementById("status");

const pageStates = new Map();

let pdfDocument = null;
let currentScale = 1.2;
let visualScale = 1.2;
let currentPage = 1;
let zoomTimer = null;
let isLiveZooming = false;
let scrollTimer = null;
let customSelection = null;
let areaSelectionBox = null;
let currentToolMode = "select";
let handPanState = null;
let storedHighlights = [];

const RENDER_QUALITY = 2;
const MAX_OUTPUT_SCALE = 4;
const MIN_ZOOM = 0.5;
const MAX_ZOOM = 4;
const AREA_SELECTION_THRESHOLD = 4;

function getQueryValue(name) {
    const params = new URLSearchParams(window.location.search);
    return params.get(name);
}

function getHashValue(name, fallback) {
    const hash = window.location.hash.replace("#", "");
    const params = new URLSearchParams(hash);
    return params.get(name) || fallback;
}

function clampScale(scale) {
    return Math.min(Math.max(scale, MIN_ZOOM), MAX_ZOOM);
}

function sendToCSharp(type, data = {}) {
    const payload = JSON.stringify({
        type,
        pageNumber: data.pageNumber || currentPage,
        zoomPercent: Math.round(currentScale * 100),
        ...data
    });

    try {
        if (typeof invokeCSharpAction === "function") {
            invokeCSharpAction(payload);
            return;
        }

        if (window.chrome?.webview?.postMessage) {
            window.chrome.webview.postMessage(payload);
            return;
        }

        if (window.webkit?.messageHandlers?.webview?.postMessage) {
            window.webkit.messageHandlers.webview.postMessage(payload);
        }
    } catch {
    }
}

function getOutputScale() {
    const deviceScale = window.devicePixelRatio || 1;
    return Math.min(deviceScale * RENDER_QUALITY, MAX_OUTPUT_SCALE);
}

function cancelTask(task) {
    try {
        task?.cancel?.();
    } catch {
    }
}

function isCancellationError(error) {
    return error?.name === "RenderingCancelledException" ||
        error?.name === "AbortException";
}

function applyPageVisualScale(state, nextVisualScale) {
    const visualWidth = Math.floor(state.baseWidth * nextVisualScale);
    const visualHeight = Math.floor(state.baseHeight * nextVisualScale);

    state.wrapper.style.width = `${visualWidth}px`;
    state.wrapper.style.height = `${visualHeight}px`;

    if (!state.content || !state.renderedScale) {
        return;
    }

    const ratio = nextVisualScale / state.renderedScale;

    if (Math.abs(ratio - 1) < 0.001) {
        state.content.style.transform = "";
        state.content.style.transformOrigin = "";
        return;
    }

    state.content.style.transform = `scale(${ratio})`;
    state.content.style.transformOrigin = "0 0";
}

function getZoomAnchor(clientX = null, clientY = null) {
    const viewerRect = viewer.getBoundingClientRect();
    const fallbackClientX = viewerRect.left + viewer.clientWidth / 2;
    const fallbackClientY = viewerRect.top + viewer.clientHeight / 2;
    const anchorClientX = clientX ?? fallbackClientX;
    const anchorClientY = clientY ?? fallbackClientY;
    const clampedClientX = Math.min(
        Math.max(anchorClientX, viewerRect.left),
        viewerRect.right
    );
    const clampedClientY = Math.min(
        Math.max(anchorClientY, viewerRect.top),
        viewerRect.bottom
    );

    let anchorState = null;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageRect = state.wrapper.getBoundingClientRect();

        if (pageRect.top <= clampedClientY && pageRect.bottom >= clampedClientY) {
            anchorState = state;
            break;
        }

        const pageMiddle = pageRect.top + pageRect.height / 2;
        const distance = Math.abs(pageMiddle - clampedClientY);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            anchorState = state;
        }
    }

    if (!anchorState) {
        return null;
    }

    const pageHeight = Math.max(anchorState.wrapper.clientHeight, 1);
    const pageWidth = Math.max(anchorState.wrapper.clientWidth, 1);
    const pageRect = anchorState.wrapper.getBoundingClientRect();
    const yRatio = Math.min(
        Math.max((clampedClientY - pageRect.top) / pageHeight, 0),
        1
    );
    const xRatio = Math.min(
        Math.max((clampedClientX - pageRect.left) / pageWidth, 0),
        1
    );

    return {
        pageNumber: anchorState.pageNumber,
        xRatio,
        yRatio,
        offsetInViewerX: clampedClientX - viewerRect.left,
        offsetInViewerY: clampedClientY - viewerRect.top
    };
}

function restoreZoomAnchor(anchor) {
    if (!anchor) {
        return;
    }

    const state = pageStates.get(anchor.pageNumber);

    if (!state) {
        return;
    }

    viewer.scrollLeft = state.wrapper.offsetLeft +
        state.wrapper.clientWidth * anchor.xRatio -
        anchor.offsetInViewerX;
    viewer.scrollTop = state.wrapper.offsetTop +
        state.wrapper.clientHeight * anchor.yRatio -
        anchor.offsetInViewerY;
}

async function cancelActiveRenderTasks() {
    for (const state of pageStates.values()) {
        cancelTask(state.renderTask);
        cancelTask(state.textLayerTask);
        state.renderTask = null;
        state.textLayerTask = null;
        state.renderPromise = null;
        state.renderingScale = 0;
    }
}

async function createPagePlaceholder(pageNumber) {
    const page = await pdfDocument.getPage(pageNumber);
    const baseViewport = page.getViewport({ scale: 1 });

    const wrapper = document.createElement("div");
    wrapper.className = "page";
    wrapper.dataset.pageNumber = String(pageNumber);

    const state = {
        pageNumber,
        wrapper,
        content: null,
        canvas: null,
        textLayer: null,
        highlightLayer: null,
        selectionOverlay: null,
        textItems: [],
        selectedWordRects: [],
        renderTask: null,
        textLayerTask: null,
        renderPromise: null,
        renderingScale: 0,
        renderedScale: 0,
        baseWidth: baseViewport.width,
        baseHeight: baseViewport.height,
        isRendered: false
    };

    pageStates.set(pageNumber, state);
    viewer.appendChild(wrapper);
    applyPageVisualScale(state, currentScale);
}

async function createPagePlaceholders() {
    viewer.innerHTML = "";
    pageStates.clear();

    for (let pageNumber = 1; pageNumber <= pdfDocument.numPages; pageNumber++) {
        await createPagePlaceholder(pageNumber);
    }
}

function buildSelectableWords(textContent, viewport) {
    const words = [];
    let globalIndex = 0;

    for (const item of textContent.items) {
        if (!item.str || !item.transform) {
            continue;
        }

        const text = item.str;
        const pdfTransform = pdfjsLib.Util.transform(
            viewport.transform,
            item.transform
        );
        const x = pdfTransform[4];
        const y = pdfTransform[5];
        const fontHeight = Math.abs(pdfTransform[3]) || item.height || 10;
        const itemWidth = Number.isFinite(item.width)
            ? Math.abs(item.width * viewport.scale)
            : Math.max(text.length * fontHeight * 0.45, 1);
        const parts = text.match(/\S+|\s+/g) ?? [];

        let cursorX = x;

        for (const part of parts) {
            const width = text.length > 0
                ? itemWidth * (part.length / text.length)
                : 0;

            if (part.trim().length > 0) {
                words.push({
                    index: globalIndex++,
                    text: part,
                    left: cursorX,
                    top: y - fontHeight,
                    right: cursorX + width,
                    bottom: y,
                    width,
                    height: fontHeight,
                    lineY: y
                });
            }

            cursorX += width;
        }
    }

    return words;
}

async function renderTextLayer(page, viewport, content, state) {
    const textLayerDiv = document.createElement("div");
    textLayerDiv.className = "textLayer";
    textLayerDiv.style.width = `${Math.floor(viewport.width)}px`;
    textLayerDiv.style.height = `${Math.floor(viewport.height)}px`;

    content.appendChild(textLayerDiv);

    const textContent = await page.getTextContent({
        includeMarkedContent: true,
        disableNormalization: false
    });

    state.textItems = buildSelectableWords(textContent, viewport);

    if (!pdfjsLib.TextLayer) {
        throw new Error("PDF.js TextLayer API is not available in this build.");
    }

    const textLayer = new pdfjsLib.TextLayer({
        textContentSource: textContent,
        container: textLayerDiv,
        viewport
    });

    state.textLayerTask = textLayer;
    await textLayer.render();
    state.textLayerTask = null;

    return textLayerDiv;
}

function createHighlightLayer(viewport) {
    const highlightLayer = document.createElement("div");
    highlightLayer.className = "highlightLayer";
    highlightLayer.style.width = `${Math.floor(viewport.width)}px`;
    highlightLayer.style.height = `${Math.floor(viewport.height)}px`;
    return highlightLayer;
}

async function renderPage(pageNumber, force = false) {
    const state = pageStates.get(pageNumber);

    if (!state || isLiveZooming) {
        return;
    }

    if (!force && state.isRendered && state.renderedScale === currentScale) {
        return;
    }

    if (!force && state.renderPromise && state.renderingScale === currentScale) {
        return state.renderPromise;
    }

    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);
    state.renderTask = null;
    state.textLayerTask = null;

    const renderPromise = renderPageInternal(state);
    state.renderPromise = renderPromise;
    state.renderingScale = currentScale;

    try {
        await renderPromise;
    } finally {
        if (state.renderPromise === renderPromise) {
            state.renderPromise = null;
            state.renderingScale = 0;
        }
    }
}

async function renderPageInternal(state) {
    const targetScale = currentScale;
    const page = await pdfDocument.getPage(state.pageNumber);
    const viewport = page.getViewport({ scale: targetScale });

    const content = document.createElement("div");
    content.className = "pageContent";
    content.style.width = `${Math.floor(viewport.width)}px`;
    content.style.height = `${Math.floor(viewport.height)}px`;
    content.style.setProperty("--total-scale-factor", String(targetScale));

    const canvas = document.createElement("canvas");
    canvas.className = "canvasLayer";
    canvas.style.width = `${Math.floor(viewport.width)}px`;
    canvas.style.height = `${Math.floor(viewport.height)}px`;

    const context = canvas.getContext("2d", {
        alpha: false
    });

    if (!context) {
        throw new Error("Unable to create canvas context.");
    }

    const outputScale = getOutputScale();

    canvas.width = Math.floor(viewport.width * outputScale);
    canvas.height = Math.floor(viewport.height * outputScale);

    content.appendChild(canvas);

    const renderTask = page.render({
        canvasContext: context,
        viewport,
        transform: outputScale !== 1
            ? [outputScale, 0, 0, outputScale, 0, 0]
            : null
    });

    state.renderTask = renderTask;

    try {
        await renderTask.promise;
    } catch (error) {
        if (isCancellationError(error)) {
            return;
        }

        throw error;
    } finally {
        if (state.renderTask === renderTask) {
            state.renderTask = null;
        }
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    let textLayer = null;

    try {
        textLayer = await renderTextLayer(page, viewport, content, state);
    } catch (error) {
        if (!isCancellationError(error)) {
            throw error;
        }

        return;
    } finally {
        state.textLayerTask = null;
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    const highlightLayer = createHighlightLayer(viewport);
    content.appendChild(highlightLayer);

    const selectionOverlay = document.createElement("div");
    selectionOverlay.className = "selectionOverlay";
    content.appendChild(selectionOverlay);

    const oldContent = state.content;

    state.wrapper.appendChild(content);

    if (oldContent) {
        oldContent.remove();
    }

    state.content = content;
    state.canvas = canvas;
    state.textLayer = textLayer;
    state.highlightLayer = highlightLayer;
    state.selectionOverlay = selectionOverlay;
    state.renderedScale = targetScale;
    state.isRendered = true;

    renderStoredHighlightsForPage(state);
    applyPageVisualScale(state, visualScale);
}

function isPageNearViewport(wrapper, buffer = viewer.clientHeight) {
    const viewerRect = viewer.getBoundingClientRect();
    const pageRect = wrapper.getBoundingClientRect();

    return (
        pageRect.bottom >= viewerRect.top - buffer &&
        pageRect.top <= viewerRect.bottom + buffer
    );
}

function unloadPage(state) {
    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);

    state.content?.remove();

    state.content = null;
    state.canvas = null;
    state.textLayer = null;
    state.highlightLayer = null;
    state.selectionOverlay = null;
    state.textItems = [];
    state.selectedWordRects = [];
    state.renderTask = null;
    state.textLayerTask = null;
    state.renderPromise = null;
    state.renderingScale = 0;
    state.renderedScale = 0;
    state.isRendered = false;
}

function cleanupFarPages() {
    const buffer = viewer.clientHeight * 3;

    for (const state of pageStates.values()) {
        if (!isPageNearViewport(state.wrapper, buffer)) {
            unloadPage(state);
        }
    }
}

async function renderVisiblePages(force = false) {
    if (isLiveZooming) {
        return;
    }

    const renderPromises = [];

    for (const state of pageStates.values()) {
        if (isPageNearViewport(state.wrapper)) {
            renderPromises.push(renderPage(state.pageNumber, force));
        }
    }

    cleanupFarPages();
    await Promise.all(renderPromises);
}

function updateCurrentPageFromScroll() {
    if (pageStates.size === 0) {
        return;
    }

    const viewportMiddle = viewer.scrollTop + viewer.clientHeight / 2;

    let nearestPage = 1;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageTop = state.wrapper.offsetTop;
        const pageMiddle = pageTop + state.wrapper.clientHeight / 2;
        const distance = Math.abs(pageMiddle - viewportMiddle);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            nearestPage = state.pageNumber;
        }
    }

    if (nearestPage !== currentPage) {
        currentPage = nearestPage;
        statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function scrollToPage(pageNumber, notify = true) {
    const state = pageStates.get(pageNumber);

    if (!state) {
        return;
    }

    state.wrapper.scrollIntoView({ block: "start" });
    currentPage = pageNumber;

    if (notify) {
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function clearAllSelectionOverlays() {
    for (const state of pageStates.values()) {
        if (state.selectionOverlay) {
            state.selectionOverlay.innerHTML = "";
        }
    }
}

function clearCustomSelection() {
    customSelection = null;
    clearAllSelectionOverlays();
    clearAreaSelectionBox();
}

function clearAreaSelectionBox() {
    areaSelectionBox?.remove();
    areaSelectionBox = null;
}

function setToolMode(toolMode) {
    currentToolMode = ["hand", "highlight"].includes(toolMode)
        ? toolMode
        : "select";
    handPanState = null;
    viewer.classList.toggle("toolHand", currentToolMode === "hand");
    viewer.classList.toggle("toolSelect", currentToolMode === "select");
    viewer.classList.toggle("toolHighlight", currentToolMode === "highlight");
    viewer.classList.remove("panning");

    if (currentToolMode === "hand") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
    }
}

function startHandPan(event) {
    if (event.button !== 0 || isLiveZooming) {
        return false;
    }

    handPanState = {
        pointerId: event.pointerId,
        startClientX: event.clientX,
        startClientY: event.clientY,
        startScrollLeft: viewer.scrollLeft,
        startScrollTop: viewer.scrollTop
    };

    viewer.classList.add("panning");
    viewer.setPointerCapture?.(event.pointerId);
    event.preventDefault();
    return true;
}

function moveHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    viewer.scrollLeft = handPanState.startScrollLeft -
        (event.clientX - handPanState.startClientX);
    viewer.scrollTop = handPanState.startScrollTop -
        (event.clientY - handPanState.startClientY);
    event.preventDefault();
    return true;
}

function stopHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    handPanState = null;
    viewer.classList.remove("panning");

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    event.preventDefault();
    return true;
}

function getPagePointFromClient(state, clientX, clientY) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        x: (clientX - contentRect.left) / scaleX,
        y: (clientY - contentRect.top) / scaleY
    };
}

function findRenderedPageAtClientPoint(clientX, clientY) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX >= contentRect.left &&
            clientX <= contentRect.right &&
            clientY >= contentRect.top &&
            clientY <= contentRect.bottom
        ) {
            return state;
        }
    }

    return null;
}

function findWordAtClientPoint(clientX, clientY, includeNearbyWord = true) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX < contentRect.left ||
            clientX > contentRect.right ||
            clientY < contentRect.top ||
            clientY > contentRect.bottom
        ) {
            continue;
        }

        const point = getPagePointFromClient(state, clientX, clientY);
        let bestWord = null;
        let bestDistance = Number.MAX_VALUE;

        for (const word of state.textItems) {
            const inside =
                point.x >= word.left &&
                point.x <= word.right &&
                point.y >= word.top &&
                point.y <= word.bottom;

            if (inside) {
                return { state, word };
            }

            const centerX = (word.left + word.right) / 2;
            const centerY = (word.top + word.bottom) / 2;
            const dx = point.x - centerX;
            const dy = point.y - centerY;
            const distance = dx * dx + dy * dy;

            if (distance < bestDistance) {
                bestDistance = distance;
                bestWord = word;
            }
        }

        if (includeNearbyWord && bestWord && bestDistance < 900) {
            return {
                state,
                word: bestWord
            };
        }
    }

    return null;
}

function getClientDragRect(selection) {
    const left = Math.min(selection.startClientX, selection.endClientX);
    const top = Math.min(selection.startClientY, selection.endClientY);
    const right = Math.max(selection.startClientX, selection.endClientX);
    const bottom = Math.max(selection.startClientY, selection.endClientY);

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function rectsIntersect(first, second) {
    return first.right >= second.left &&
        first.left <= second.right &&
        first.bottom >= second.top &&
        first.top <= second.bottom;
}

function getWordClientRect(state, word) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        left: contentRect.left + word.left * scaleX,
        top: contentRect.top + word.top * scaleY,
        right: contentRect.left + word.right * scaleX,
        bottom: contentRect.top + word.bottom * scaleY
    };
}

function getOrCreateAreaSelectionBox() {
    if (areaSelectionBox) {
        return areaSelectionBox;
    }

    areaSelectionBox = document.createElement("div");
    areaSelectionBox.className = "selectionDragBox";
    viewer.appendChild(areaSelectionBox);
    return areaSelectionBox;
}

function renderAreaSelectionBox(selection) {
    const dragRect = getClientDragRect(selection);

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        clearAreaSelectionBox();
        return;
    }

    const viewerRect = viewer.getBoundingClientRect();
    const box = getOrCreateAreaSelectionBox();

    box.style.left = `${dragRect.left - viewerRect.left + viewer.scrollLeft}px`;
    box.style.top = `${dragRect.top - viewerRect.top + viewer.scrollTop}px`;
    box.style.width = `${dragRect.width}px`;
    box.style.height = `${dragRect.height}px`;
}

function updateAreaSelectionWords(selection) {
    const dragRect = getClientDragRect(selection);
    const wordIndexesByPage = new Map();

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        selection.wordIndexesByPage = wordIndexesByPage;
        return;
    }

    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (!rectsIntersect(dragRect, contentRect)) {
            continue;
        }

        const selectedIndexes = new Set();

        for (const word of state.textItems) {
            if (rectsIntersect(dragRect, getWordClientRect(state, word))) {
                selectedIndexes.add(word.index);
            }
        }

        if (selectedIndexes.size > 0) {
            wordIndexesByPage.set(state.pageNumber, selectedIndexes);
        }
    }

    selection.wordIndexesByPage = wordIndexesByPage;
}

function compareSelectionPosition(firstPage, firstIndex, secondPage, secondIndex) {
    if (firstPage !== secondPage) {
        return firstPage - secondPage;
    }

    return firstIndex - secondIndex;
}

function getSelectedWordsForPage(state) {
    if (!customSelection || state.textItems.length === 0) {
        return [];
    }

    if (customSelection.mode === "area") {
        const selectedIndexes = customSelection.wordIndexesByPage?.get(state.pageNumber);

        if (!selectedIndexes) {
            return [];
        }

        return state.textItems.filter(word => selectedIndexes.has(word.index));
    }

    const direction = compareSelectionPosition(
        customSelection.startPage,
        customSelection.startWordIndex,
        customSelection.endPage,
        customSelection.endWordIndex
    );
    const isForward = direction <= 0;
    const firstPage = isForward ? customSelection.startPage : customSelection.endPage;
    const lastPage = isForward ? customSelection.endPage : customSelection.startPage;

    if (state.pageNumber < firstPage || state.pageNumber > lastPage) {
        return [];
    }

    let startIndex = 0;
    let endIndex = state.textItems[state.textItems.length - 1].index;

    if (isForward) {
        if (state.pageNumber === customSelection.startPage) {
            startIndex = customSelection.startWordIndex;
        }

        if (state.pageNumber === customSelection.endPage) {
            endIndex = customSelection.endWordIndex;
        }
    } else {
        if (state.pageNumber === customSelection.endPage) {
            startIndex = customSelection.endWordIndex;
        }

        if (state.pageNumber === customSelection.startPage) {
            endIndex = customSelection.startWordIndex;
        }
    }

    if (startIndex > endIndex) {
        const temp = startIndex;
        startIndex = endIndex;
        endIndex = temp;
    }

    return state.textItems.filter(word =>
        word.index >= startIndex &&
        word.index <= endIndex
    );
}

function groupWordsByLine(words) {
    const lines = new Map();

    for (const word of words) {
        const key = Math.round(word.lineY / 4) * 4;

        if (!lines.has(key)) {
            lines.set(key, []);
        }

        lines.get(key).push(word);
    }

    return [...lines.entries()].sort((first, second) => first[0] - second[0]);
}

function renderCustomSelection() {
    clearAllSelectionOverlays();

    for (const state of pageStates.values()) {
        if (!state.selectionOverlay) {
            continue;
        }

        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const fragment = document.createDocumentFragment();

        for (const segment of buildHighlightSegments(words, state)) {
            const rect = document.createElement("div");

            rect.className = "selectionOverlayRect";
            rect.style.left = `${segment.left}px`;
            rect.style.top = `${segment.top}px`;
            rect.style.width = `${segment.width}px`;
            rect.style.height = `${segment.height}px`;

            fragment.appendChild(rect);
        }

        state.selectionOverlay.appendChild(fragment);
    }
}

function getRenderedPageWidth(state) {
    if (state.content?.offsetWidth) {
        return state.content.offsetWidth;
    }

    if (state.baseWidth && state.renderedScale) {
        return state.baseWidth * state.renderedScale;
    }

    return state.baseWidth * currentScale;
}

function getLineFontHeight(line) {
    const heights = line.words
        .map(word => word.height || 0)
        .filter(height => height > 0)
        .sort((first, second) => first - second);

    return heights.length === 0
        ? 12
        : heights[Math.floor(heights.length / 2)];
}

function getLineText(line) {
    return line.words
        .map(word => word.text ?? "")
        .join("")
        .trim();
}

function compareLinePosition(first, second) {
    const fontHeight = Math.max(getLineFontHeight(first), getLineFontHeight(second));
    const yTolerance = Math.max(2, fontHeight * 0.4);

    if (Math.abs(first.top - second.top) > yTolerance) {
        return first.top - second.top;
    }

    return first.left - second.left;
}

function isProbablyHeadingText(text) {
    if (!text) {
        return false;
    }

    const normalized = text.replace(/\s+/g, " ").trim();

    if (normalized.length <= 3) {
        return false;
    }

    const isUpper = /^([IVXLCDM]+\.?\s+)?[A-ZÀ-Ỵ0-9\s\-–().:]+$/.test(normalized);
    const isNumbered = /^(chương|chapter|section|phần|mục|\d+(\.\d+)*\.?)\s+\d*.*$/i.test(normalized);
    const isCommonHeader = /^(Abstract|Introduction|Methodology|Methods|Results|Discussion|Conclusion|References|Acknowledgment|Tóm\s+tắt|Tổng\s+quan|Kết\s+luận)$/i.test(normalized);

    return isUpper || isNumbered || isCommonHeader;
}

function isFullWidthLine(line, state) {
    const pageWidth = getRenderedPageWidth(state);
    const widthRatio = line.width / Math.max(pageWidth, 1);
    const touchesLeft = line.left <= pageWidth * 0.2;
    const touchesRight = line.right >= pageWidth * 0.8;

    return widthRatio >= 0.65 ||
        (widthRatio >= 0.52 && touchesLeft && touchesRight);
}

function isStructuralLine(line, state) {
    if (isFullWidthLine(line, state)) {
        return true;
    }

    const text = getLineText(line);
    const pageWidth = getRenderedPageWidth(state);

    return isProbablyHeadingText(text) &&
        (line.width / Math.max(pageWidth, 1)) <= 0.65;
}

function groupWordsIntoVisualLines(words, state) {
    const pageWidth = getRenderedPageWidth(state);
    const sortedWords = [...words].sort((first, second) => {
        const fontHeight = Math.max(first.height || 12, second.height || 12);

        return Math.abs(first.lineY - second.lineY) > Math.max(2, fontHeight * 0.4)
            ? first.lineY - second.lineY
            : first.left - second.left;
    });
    const rows = [];

    for (const word of sortedWords) {
        const yTolerance = Math.max(2, (word.height || 12) * 0.4);
        let targetRow = rows.find(row => Math.abs(row.lineY - word.lineY) <= yTolerance);

        if (!targetRow) {
            targetRow = {
                lineY: word.lineY,
                words: []
            };
            rows.push(targetRow);
        }

        targetRow.words.push(word);
    }

    const lines = [];

    for (const row of rows) {
        const rowWords = row.words.sort((first, second) => first.left - second.left);
        let currentLineWords = [];

        for (const word of rowWords) {
            const previous = currentLineWords[currentLineWords.length - 1];

            if (!previous) {
                currentLineWords.push(word);
                continue;
            }

            const fontHeight = Math.max(previous.height || 12, word.height || 12);

            if ((word.left - previous.right) > Math.max(fontHeight * 2.8, pageWidth * 0.022)) {
                lines.push(createVisualLineFromWords(currentLineWords));
                currentLineWords = [word];
            } else {
                currentLineWords.push(word);
            }
        }

        if (currentLineWords.length > 0) {
            lines.push(createVisualLineFromWords(currentLineWords));
        }
    }

    return lines.sort(compareLinePosition);
}

function createVisualLineFromWords(words) {
    const left = Math.min(...words.map(word => word.left));
    const right = Math.max(...words.map(word => word.right));
    const top = Math.min(...words.map(word => word.top));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        words,
        left,
        right,
        top,
        bottom,
        lineY: words.reduce((sum, word) => sum + word.lineY, 0) / words.length,
        width: right - left,
        height: bottom - top,
        centerX: (left + right) / 2
    };
}

function getHorizontalOverlapRatio(line, column) {
    const overlap = Math.min(line.right, column.right) -
        Math.max(line.left, column.left);

    return overlap <= 0
        ? 0
        : overlap / Math.min(line.width, column.right - column.left);
}

function groupLinesIntoColumns(lines, state) {
    const columns = [];

    for (const line of [...lines].sort(compareLinePosition)) {
        if (isStructuralLine(line, state)) {
            columns.push({
                lines: [line],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: true
            });
            continue;
        }

        let bestColumn = null;
        let bestScore = 0;

        for (const column of columns) {
            if (column.isStructural) {
                continue;
            }

            const overlapScore = getHorizontalOverlapRatio(line, column);
            const xTolerance = Math.max(3, getLineFontHeight(line) * 0.75);
            const score = line.centerX >= column.left - xTolerance &&
                line.centerX <= column.right + xTolerance
                ? Math.max(overlapScore, 0.5)
                : overlapScore;

            if (score > bestScore) {
                bestScore = score;
                bestColumn = column;
            }
        }

        if (!bestColumn || bestScore < 0.25) {
            bestColumn = {
                lines: [],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: false
            };
            columns.push(bestColumn);
        }

        bestColumn.lines.push(line);
        bestColumn.left = Math.min(bestColumn.left, line.left);
        bestColumn.right = Math.max(bestColumn.right, line.right);
        bestColumn.top = Math.min(bestColumn.top, line.top);
        bestColumn.bottom = Math.max(bestColumn.bottom, line.bottom);
    }

    return columns;
}

function getCopyLinesInReadingOrder(words, state) {
    const lines = groupWordsIntoVisualLines(words, state);

    if (lines.length === 0) {
        return [];
    }

    const sortedLines = [...lines].sort(compareLinePosition);
    const output = [];
    let sectionLines = [];

    function flushSection() {
        if (sectionLines.length === 0) {
            return;
        }

        const columns = groupLinesIntoColumns(sectionLines, state)
            .filter(column => !column.isStructural)
            .sort((first, second) => first.left - second.left);

        for (const column of columns) {
            for (const line of column.lines.sort(compareLinePosition)) {
                output.push(line.words);
            }
        }

        sectionLines = [];
    }

    for (const line of sortedLines) {
        if (isStructuralLine(line, state)) {
            flushSection();
            output.push(line.words);
            continue;
        }

        sectionLines.push(line);
    }

    flushSection();
    return output;
}

function shouldInsertSpaceBetweenWords(previous, current) {
    if (!previous || !current) {
        return false;
    }

    const previousText = previous.text ?? "";
    const currentText = current.text ?? "";

    if (!previousText ||
        !currentText ||
        /^[,.;:!?%)\]\}]/.test(currentText) ||
        /[(\[\{]$/.test(previousText)) {
        return false;
    }

    return (current.left - previous.right) >
        Math.max(2, Math.max(previous.height || 0, current.height || 0, 10) * 0.22);
}

function buildCopiedLineText(lineWords) {
    const sortedWords = [...lineWords].sort((first, second) => first.left - second.left);
    let result = "";
    let previous = null;

    for (const word of sortedWords) {
        if (!word.text) {
            continue;
        }

        if (previous && shouldInsertSpaceBetweenWords(previous, word)) {
            result += " ";
        }

        result += word.text;
        previous = word;
    }

    return result
        .replace(/\s+([,.;:!?%)\]\}])/g, "$1")
        .replace(/([(\[\{])\s+/g, "$1")
        .replace(/\s{2,}/g, " ")
        .trim();
}

function shouldSplitHighlightSegment(previous, current, state) {
    if (!previous || !current) {
        return false;
    }

    const gap = current.left - previous.right;
    const fontHeight = Math.max(previous.height || 12, current.height || 12);
    const pageWidth = getRenderedPageWidth(state);

    return gap > Math.max(fontHeight * 1.15, pageWidth * 0.012, 8);
}

function createHighlightSegment(words) {
    const left = Math.min(...words.map(word => word.left));
    const top = Math.min(...words.map(word => word.top));
    const right = Math.max(...words.map(word => word.right));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function buildHighlightSegments(words, state) {
    const segments = [];
    const lines = groupWordsIntoVisualLines(words, state);

    for (const line of lines) {
        const sortedWords = [...line.words].sort((first, second) => first.left - second.left);
        let segmentWords = [];

        for (const word of sortedWords) {
            const previous = segmentWords[segmentWords.length - 1];

            if (previous && shouldSplitHighlightSegment(previous, word, state)) {
                segments.push(createHighlightSegment(segmentWords));
                segmentWords = [];
            }

            segmentWords.push(word);
        }

        if (segmentWords.length > 0) {
            segments.push(createHighlightSegment(segmentWords));
        }
    }

    return segments;
}

function getCustomSelectedText() {
    if (!customSelection) {
        return "";
    }

    const selectedLines = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const pageLines = getCopyLinesInReadingOrder(words, state)
            .map(lineWords => buildCopiedLineText(lineWords))
            .filter(line => line.length > 0);

        selectedLines.push(...pageLines);
    }

    return selectedLines.join("\n");
}

function getSelectedHighlightRects() {
    if (!customSelection) {
        return [];
    }

    const result = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const scale = state.renderedScale || currentScale || 1;

        for (const segment of buildHighlightSegments(words, state)) {
            result.push({
                pageNumber: state.pageNumber,
                left: segment.left / scale,
                top: segment.top / scale,
                width: segment.width / scale,
                height: segment.height / scale
            });
        }
    }

    return result;
}

function renderStoredHighlightsForPage(state) {
    if (!state.highlightLayer) {
        return;
    }

    state.highlightLayer.innerHTML = "";

    const scale = state.renderedScale || currentScale || 1;

    for (const highlight of storedHighlights) {
        const rects = highlight.rects ?? highlight.Rects ?? [];

        for (const rect of rects) {
            const pageNumber = rect.pageNumber ?? rect.PageNumber;

            if (pageNumber !== state.pageNumber) {
                continue;
            }

            const left = rect.left ?? rect.Left ?? 0;
            const top = rect.top ?? rect.Top ?? 0;
            const width = rect.width ?? rect.Width ?? 0;
            const height = rect.height ?? rect.Height ?? 0;
            const item = document.createElement("div");

            item.className = "highlightItem";
            item.dataset.highlightId = highlight.id ?? highlight.Id ?? "";
            item.style.left = `${left * scale}px`;
            item.style.top = `${top * scale}px`;
            item.style.width = `${width * scale}px`;
            item.style.height = `${height * scale}px`;

            state.highlightLayer.appendChild(item);
        }
    }
}

function renderAllStoredHighlights() {
    for (const state of pageStates.values()) {
        renderStoredHighlightsForPage(state);
    }
}

function setStoredHighlights(highlights) {
    storedHighlights = Array.isArray(highlights)
        ? highlights
        : [];
    renderAllStoredHighlights();
}

function navigateToStoredHighlight(highlightId) {
    const highlight = storedHighlights.find(item =>
        (item.id ?? item.Id) === highlightId
    );

    if (!highlight) {
        return;
    }

    const rects = highlight.rects ?? highlight.Rects ?? [];

    if (rects.length === 0) {
        return;
    }

    const firstRect = rects[0];
    const pageNumber = firstRect.pageNumber ?? firstRect.PageNumber ?? 1;

    clearCustomSelection();
    scrollToPage(pageNumber);

    setTimeout(async () => {
        await renderVisiblePages(true);
        renderAllStoredHighlights();

        const state = pageStates.get(pageNumber);

        if (!state) {
            return;
        }

        const scale = state.renderedScale || currentScale || 1;
        const top = (firstRect.top ?? firstRect.Top ?? 0) * scale;

        viewer.scrollTop = state.wrapper.offsetTop + top - 80;
    }, 120);
}

function createHighlightFromSelection() {
    const text = getCustomSelectedText();
    const rects = getSelectedHighlightRects();

    if (!text || rects.length === 0) {
        return;
    }

    const firstRect = rects[0];

    sendToCSharp("highlightCreated", {
        text,
        pageNumber: firstRect.pageNumber,
        rects
    });

    clearCustomSelection();
}

function scheduleZoom(newScale, anchorClientX = null, anchorClientY = null) {
    clearCustomSelection();
    window.getSelection()?.removeAllRanges();

    const anchor = getZoomAnchor(anchorClientX, anchorClientY);

    visualScale = clampScale(newScale);
    isLiveZooming = true;

    viewer.classList.add("viewerLiveZoom");

    for (const state of pageStates.values()) {
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(anchor);
    clearTimeout(zoomTimer);

    zoomTimer = setTimeout(async () => {
        await finishZoom(visualScale, anchor);
    }, 300);
}

async function finishZoom(finalScale, zoomAnchor = null) {
    currentScale = clampScale(finalScale);
    visualScale = currentScale;
    isLiveZooming = false;

    viewer.classList.remove("viewerLiveZoom");

    await cancelActiveRenderTasks();

    for (const state of pageStates.values()) {
        state.isRendered = false;
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());

    await renderVisiblePages(true);

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());
    updateCurrentPageFromScroll();
    sendToCSharp("zoomChanged", {
        pageNumber: currentPage
    });
}

window.miniZoteroPdf = {
    goToPage(pageNumber) {
        scrollToPage(pageNumber);
        renderVisiblePages();
    },

    zoomIn() {
        scheduleZoom(visualScale + 0.25);
    },

    zoomOut() {
        scheduleZoom(visualScale - 0.25);
    },

    setZoom(percent) {
        scheduleZoom(percent / 100);
    },

    setToolMode(toolMode) {
        setToolMode(toolMode);
    },

    setHighlights(highlights) {
        setStoredHighlights(highlights);
    },

    goToHighlight(highlightId) {
        navigateToStoredHighlight(highlightId);
    },

    getState() {
        sendToCSharp("state", {
            pageNumber: currentPage
        });
    }
};

async function boot() {
    try {
        setToolMode(currentToolMode);

        const fileUrl = getQueryValue("file");

        if (!fileUrl) {
            throw new Error("Missing file query parameter.");
        }

        const startPage = Number(getHashValue("page", "1"));
        const startZoom = Number(getHashValue("zoom", "120"));

        currentPage = Number.isFinite(startPage) && startPage > 0 ? startPage : 1;
        currentScale = Number.isFinite(startZoom) && startZoom > 0
            ? clampScale(startZoom / 100)
            : 1.2;
        visualScale = currentScale;

        statusBar.textContent = "Loading PDF...";

        pdfDocument = await pdfjsLib.getDocument({
            url: fileUrl,
            cMapUrl: "/PdfJs/cmaps/",
            cMapPacked: true,
            standardFontDataUrl: "/PdfJs/standard_fonts/",
            useSystemFonts: true
        }).promise;

        await createPagePlaceholders();

        setTimeout(async () => {
            scrollToPage(currentPage, false);
            await renderVisiblePages(true);
            statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
            sendToCSharp("loaded", { pageNumber: currentPage });
        }, 150);
    } catch (error) {
        statusBar.textContent = "Failed to load PDF";

        const errorBox = document.createElement("div");
        errorBox.className = "error";
        errorBox.textContent = error?.message || String(error);

        viewer.innerHTML = "";
        viewer.appendChild(errorBox);
    }
}

viewer.addEventListener("scroll", () => {
    clearTimeout(scrollTimer);

    scrollTimer = setTimeout(async () => {
        updateCurrentPageFromScroll();
        await renderVisiblePages();
        renderCustomSelection();
    }, 120);
}, { passive: true });

viewer.addEventListener("pointerdown", event => {
    if (currentToolMode === "hand") {
        startHandPan(event);
        return;
    }

    if (event.button !== 0 || isLiveZooming) {
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY, false);

    if (!hit) {
        const pageState = findRenderedPageAtClientPoint(event.clientX, event.clientY);

        if (!pageState) {
            clearCustomSelection();
            return;
        }

        event.preventDefault();

        customSelection = {
            mode: "area",
            startClientX: event.clientX,
            startClientY: event.clientY,
            endClientX: event.clientX,
            endClientY: event.clientY,
            isDragging: true,
            wordIndexesByPage: new Map()
        };

        viewer.setPointerCapture?.(event.pointerId);
        clearAllSelectionOverlays();
        return;
    }

    event.preventDefault();

    customSelection = {
        mode: "word",
        startPage: hit.state.pageNumber,
        startWordIndex: hit.word.index,
        endPage: hit.state.pageNumber,
        endWordIndex: hit.word.index,
        isDragging: true
    };

    viewer.setPointerCapture?.(event.pointerId);
    renderCustomSelection();
});

viewer.addEventListener("pointermove", event => {
    if (currentToolMode === "hand") {
        moveHandPan(event);
        return;
    }

    if (!customSelection?.isDragging || isLiveZooming) {
        return;
    }

    if (customSelection.mode === "area") {
        event.preventDefault();

        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;

        renderAreaSelectionBox(customSelection);
        updateAreaSelectionWords(customSelection);
        renderCustomSelection();
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY);

    if (!hit) {
        return;
    }

    event.preventDefault();

    customSelection.endPage = hit.state.pageNumber;
    customSelection.endWordIndex = hit.word.index;

    renderCustomSelection();
});

viewer.addEventListener("pointerup", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;

    if (customSelection.mode === "area") {
        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;
        updateAreaSelectionWords(customSelection);
    }

    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    renderCustomSelection();

    if (currentToolMode === "highlight") {
        createHighlightFromSelection();
    }
});

viewer.addEventListener("pointercancel", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;
    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }
});

viewer.addEventListener("wheel", event => {
    if (!event.ctrlKey) {
        return;
    }

    event.preventDefault();

    const direction = event.deltaY < 0 ? 1 : -1;
    const factor = direction > 0 ? 1.1 : 0.9;

    scheduleZoom(visualScale * factor, event.clientX, event.clientY);
}, { passive: false });

document.addEventListener("copy", event => {
    const text = getCustomSelectedText();

    if (!text) {
        return;
    }

    event.preventDefault();
    event.clipboardData?.setData("text/plain", text);
});

document.addEventListener("keydown", event => {
    if (event.key === "Escape") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
        return;
    }

    if (event.ctrlKey && event.key.toLowerCase() === "h") {
        event.preventDefault();
        createHighlightFromSelection();
    }
});

boot();

````

## MiniZotero/bin/Debug/net8.0/Avalonia.Base.dll

_Skipped binary or large file. Size: 2258432 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Controls.dll

_Skipped binary or large file. Size: 1302016 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Controls.WebView.dll

_Skipped binary or large file. Size: 1248768 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.DesignerSupport.dll

_Skipped binary or large file. Size: 215552 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Desktop.dll

_Skipped binary or large file. Size: 15360 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Dialogs.dll

_Skipped binary or large file. Size: 243200 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.dll

_Skipped binary or large file. Size: 4096 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Fonts.Inter.dll

_Skipped binary or large file. Size: 1892864 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.FreeDesktop.AtSpi.dll

_Skipped binary or large file. Size: 559616 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.FreeDesktop.dll

_Skipped binary or large file. Size: 201216 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.HarfBuzz.dll

_Skipped binary or large file. Size: 22016 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Markup.dll

_Skipped binary or large file. Size: 45568 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Markup.Xaml.dll

_Skipped binary or large file. Size: 74752 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Metal.dll

_Skipped binary or large file. Size: 15360 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.MicroCom.dll

_Skipped binary or large file. Size: 15360 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Native.dll

_Skipped binary or large file. Size: 343040 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.OpenGL.dll

_Skipped binary or large file. Size: 116736 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Remote.Protocol.dll

_Skipped binary or large file. Size: 75264 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Skia.dll

_Skipped binary or large file. Size: 123904 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Themes.Fluent.dll

_Skipped binary or large file. Size: 712704 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Vulkan.dll

_Skipped binary or large file. Size: 190976 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Win32.Automation.dll

_Skipped binary or large file. Size: 116224 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.Win32.dll

_Skipped binary or large file. Size: 933376 bytes._

## MiniZotero/bin/Debug/net8.0/Avalonia.X11.dll

_Skipped binary or large file. Size: 372224 bytes._

## MiniZotero/bin/Debug/net8.0/CommunityToolkit.Mvvm.dll

_Skipped binary or large file. Size: 146760 bytes._

## MiniZotero/bin/Debug/net8.0/HarfBuzzSharp.dll

_Skipped binary or large file. Size: 122400 bytes._

## MiniZotero/bin/Debug/net8.0/MicroCom.Runtime.dll

_Skipped binary or large file. Size: 16384 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.deps.json

``json
{
  "runtimeTarget": {
    "name": ".NETCoreApp,Version=v8.0",
    "signature": ""
  },
  "compilationOptions": {},
  "targets": {
    ".NETCoreApp,Version=v8.0": {
      "MiniZotero/1.0.0": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.Controls.WebView": "12.0.1",
          "Avalonia.Desktop": "12.0.3",
          "Avalonia.Fonts.Inter": "12.0.3",
          "Avalonia.Themes.Fluent": "12.0.3",
          "CommunityToolkit.Mvvm": "8.4.1"
        },
        "runtime": {
          "MiniZotero.dll": {}
        }
      },
      "Avalonia/12.0.3": {
        "dependencies": {
          "Avalonia.BuildServices": "11.3.2",
          "Avalonia.Remote.Protocol": "12.0.3",
          "MicroCom.Runtime": "0.11.4"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Base.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.Controls.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.DesignerSupport.dll": {
            "assemblyVersion": "0.7.0.0",
            "fileVersion": "0.7.0.0"
          },
          "lib/net8.0/Avalonia.Dialogs.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.Markup.Xaml.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.Markup.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.Metal.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.MicroCom.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.OpenGL.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.Vulkan.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.Angle.Windows.Natives/2.1.25547.20250602": {
        "runtimeTargets": {
          "runtimes/win-arm64/native/av_libglesv2.dll": {
            "rid": "win-arm64",
            "assetType": "native",
            "fileVersion": "2.1.25606.0"
          },
          "runtimes/win-x64/native/av_libglesv2.dll": {
            "rid": "win-x64",
            "assetType": "native",
            "fileVersion": "2.1.25606.0"
          },
          "runtimes/win-x86/native/av_libglesv2.dll": {
            "rid": "win-x86",
            "assetType": "native",
            "fileVersion": "2.1.25606.0"
          }
        }
      },
      "Avalonia.BuildServices/11.3.2": {},
      "Avalonia.Controls.WebView/12.0.1": {
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Controls.WebView.dll": {
            "assemblyVersion": "12.0.1.0",
            "fileVersion": "12.0.1.0"
          }
        }
      },
      "Avalonia.Desktop/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.HarfBuzz": "12.0.3",
          "Avalonia.Native": "12.0.3",
          "Avalonia.Skia": "12.0.3",
          "Avalonia.Win32": "12.0.3",
          "Avalonia.X11": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Desktop.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.Fonts.Inter/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Fonts.Inter.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.FreeDesktop/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "Tmds.DBus.Protocol": "0.92.0"
        },
        "runtime": {
          "lib/net8.0/Avalonia.FreeDesktop.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.FreeDesktop.AtSpi/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.FreeDesktop.AtSpi.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.HarfBuzz/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "HarfBuzzSharp": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.Linux": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.WebAssembly": "8.3.1.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.HarfBuzz.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.Native/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Native.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        },
        "runtimeTargets": {
          "runtimes/osx/native/libAvaloniaNative.dylib": {
            "rid": "osx",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "Avalonia.Remote.Protocol/12.0.3": {
        "runtime": {
          "lib/net8.0/Avalonia.Remote.Protocol.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.Skia/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "HarfBuzzSharp": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.Linux": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.WebAssembly": "8.3.1.3",
          "SkiaSharp": "3.119.4-preview.1.1",
          "SkiaSharp.NativeAssets.Linux": "3.119.4-preview.1.1",
          "SkiaSharp.NativeAssets.WebAssembly": "3.119.4-preview.1.1"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Skia.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.Themes.Fluent/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Themes.Fluent.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.Win32/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.Angle.Windows.Natives": "2.1.25547.20250602"
        },
        "runtime": {
          "lib/net8.0/Avalonia.Win32.Automation.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          },
          "lib/net8.0/Avalonia.Win32.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "Avalonia.X11/12.0.3": {
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.FreeDesktop": "12.0.3",
          "Avalonia.FreeDesktop.AtSpi": "12.0.3",
          "Avalonia.Skia": "12.0.3"
        },
        "runtime": {
          "lib/net8.0/Avalonia.X11.dll": {
            "assemblyVersion": "12.0.3.0",
            "fileVersion": "12.0.3.0"
          }
        }
      },
      "CommunityToolkit.Mvvm/8.4.1": {
        "runtime": {
          "lib/net8.0/CommunityToolkit.Mvvm.dll": {
            "assemblyVersion": "8.4.0.0",
            "fileVersion": "8.4.1.1"
          }
        }
      },
      "HarfBuzzSharp/8.3.1.3": {
        "dependencies": {
          "HarfBuzzSharp.NativeAssets.Win32": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.macOS": "8.3.1.3"
        },
        "runtime": {
          "lib/net8.0/HarfBuzzSharp.dll": {
            "assemblyVersion": "1.0.0.0",
            "fileVersion": "8.3.1.3"
          }
        }
      },
      "HarfBuzzSharp.NativeAssets.Linux/8.3.1.3": {
        "runtimeTargets": {
          "runtimes/linux-arm/native/libHarfBuzzSharp.so": {
            "rid": "linux-arm",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-arm64/native/libHarfBuzzSharp.so": {
            "rid": "linux-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-loongarch64/native/libHarfBuzzSharp.so": {
            "rid": "linux-loongarch64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-arm/native/libHarfBuzzSharp.so": {
            "rid": "linux-musl-arm",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-arm64/native/libHarfBuzzSharp.so": {
            "rid": "linux-musl-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-loongarch64/native/libHarfBuzzSharp.so": {
            "rid": "linux-musl-loongarch64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-riscv64/native/libHarfBuzzSharp.so": {
            "rid": "linux-musl-riscv64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-x64/native/libHarfBuzzSharp.so": {
            "rid": "linux-musl-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-riscv64/native/libHarfBuzzSharp.so": {
            "rid": "linux-riscv64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-x64/native/libHarfBuzzSharp.so": {
            "rid": "linux-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-x86/native/libHarfBuzzSharp.so": {
            "rid": "linux-x86",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "HarfBuzzSharp.NativeAssets.macOS/8.3.1.3": {
        "runtimeTargets": {
          "runtimes/osx/native/libHarfBuzzSharp.dylib": {
            "rid": "osx",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "HarfBuzzSharp.NativeAssets.WebAssembly/8.3.1.3": {},
      "HarfBuzzSharp.NativeAssets.Win32/8.3.1.3": {
        "runtimeTargets": {
          "runtimes/win-arm64/native/libHarfBuzzSharp.dll": {
            "rid": "win-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-arm64/native/libHarfBuzzSharp.pdb": {
            "rid": "win-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x64/native/libHarfBuzzSharp.dll": {
            "rid": "win-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x64/native/libHarfBuzzSharp.pdb": {
            "rid": "win-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x86/native/libHarfBuzzSharp.dll": {
            "rid": "win-x86",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x86/native/libHarfBuzzSharp.pdb": {
            "rid": "win-x86",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "MicroCom.Runtime/0.11.4": {
        "runtime": {
          "lib/net5.0/MicroCom.Runtime.dll": {
            "assemblyVersion": "0.11.4.0",
            "fileVersion": "0.11.4.0"
          }
        }
      },
      "SkiaSharp/3.119.4-preview.1.1": {
        "dependencies": {
          "SkiaSharp.NativeAssets.Win32": "3.119.4-preview.1.1",
          "SkiaSharp.NativeAssets.macOS": "3.119.4-preview.1.1"
        },
        "runtime": {
          "lib/net6.0/SkiaSharp.dll": {
            "assemblyVersion": "3.119.0.0",
            "fileVersion": "3.119.4.0"
          }
        }
      },
      "SkiaSharp.NativeAssets.Linux/3.119.4-preview.1.1": {
        "runtimeTargets": {
          "runtimes/linux-arm/native/libSkiaSharp.so": {
            "rid": "linux-arm",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-arm64/native/libSkiaSharp.so": {
            "rid": "linux-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-bionic-arm64/native/libSkiaSharp.so": {
            "rid": "linux-bionic-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-bionic-x64/native/libSkiaSharp.so": {
            "rid": "linux-bionic-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-loongarch64/native/libSkiaSharp.so": {
            "rid": "linux-loongarch64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-arm/native/libSkiaSharp.so": {
            "rid": "linux-musl-arm",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-arm64/native/libSkiaSharp.so": {
            "rid": "linux-musl-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-loongarch64/native/libSkiaSharp.so": {
            "rid": "linux-musl-loongarch64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-riscv64/native/libSkiaSharp.so": {
            "rid": "linux-musl-riscv64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-musl-x64/native/libSkiaSharp.so": {
            "rid": "linux-musl-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-riscv64/native/libSkiaSharp.so": {
            "rid": "linux-riscv64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-x64/native/libSkiaSharp.so": {
            "rid": "linux-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/linux-x86/native/libSkiaSharp.so": {
            "rid": "linux-x86",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "SkiaSharp.NativeAssets.macOS/3.119.4-preview.1.1": {
        "runtimeTargets": {
          "runtimes/osx/native/libSkiaSharp.dylib": {
            "rid": "osx",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "SkiaSharp.NativeAssets.WebAssembly/3.119.4-preview.1.1": {},
      "SkiaSharp.NativeAssets.Win32/3.119.4-preview.1.1": {
        "runtimeTargets": {
          "runtimes/win-arm64/native/libSkiaSharp.dll": {
            "rid": "win-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-arm64/native/libSkiaSharp.pdb": {
            "rid": "win-arm64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x64/native/libSkiaSharp.dll": {
            "rid": "win-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x64/native/libSkiaSharp.pdb": {
            "rid": "win-x64",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x86/native/libSkiaSharp.dll": {
            "rid": "win-x86",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          },
          "runtimes/win-x86/native/libSkiaSharp.pdb": {
            "rid": "win-x86",
            "assetType": "native",
            "fileVersion": "0.0.0.0"
          }
        }
      },
      "System.IO.Pipelines/8.0.0": {
        "runtime": {
          "lib/net8.0/System.IO.Pipelines.dll": {
            "assemblyVersion": "8.0.0.0",
            "fileVersion": "8.0.23.53103"
          }
        }
      },
      "Tmds.DBus.Protocol/0.92.0": {
        "dependencies": {
          "System.IO.Pipelines": "8.0.0"
        },
        "runtime": {
          "lib/net8.0/Tmds.DBus.Protocol.dll": {
            "assemblyVersion": "0.92.0.0",
            "fileVersion": "0.92.0.0"
          }
        }
      }
    }
  },
  "libraries": {
    "MiniZotero/1.0.0": {
      "type": "project",
      "serviceable": false,
      "sha512": ""
    },
    "Avalonia/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-OVAzdZB5T/QIOEpw/WmQ0ZJM13BMmLO7RqR5z+lZtBMuStK63W68SV/Q+PNn/GdFEC3Ab8eQhH2FMb8FhNLK+w==",
      "path": "avalonia/12.0.3",
      "hashPath": "avalonia.12.0.3.nupkg.sha512"
    },
    "Avalonia.Angle.Windows.Natives/2.1.25547.20250602": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-ZL0VLc4s9rvNNFt19Pxm5UNAkmKNylugAwJPX9ulXZ6JWs/l6XZihPWWTyezaoNOVyEPU8YbURtW7XMAtqXH5A==",
      "path": "avalonia.angle.windows.natives/2.1.25547.20250602",
      "hashPath": "avalonia.angle.windows.natives.2.1.25547.20250602.nupkg.sha512"
    },
    "Avalonia.BuildServices/11.3.2": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-qHDToxto1e3hci5YqbG9n0Ty8mlp3zBUN5wT66wKqaDVzXyQ0do3EnRILd4Ke9jpvsktaPpgE0YjEk7hornryQ==",
      "path": "avalonia.buildservices/11.3.2",
      "hashPath": "avalonia.buildservices.11.3.2.nupkg.sha512"
    },
    "Avalonia.Controls.WebView/12.0.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-GrCIpIIBL7ueFDsNu3lyYc1mgO3QGGl1c1MCK8YAgjaNZwF9PV5PF2UB3lm1uuqj/MWOKNhemLwcSDLyYv0JjQ==",
      "path": "avalonia.controls.webview/12.0.1",
      "hashPath": "avalonia.controls.webview.12.0.1.nupkg.sha512"
    },
    "Avalonia.Desktop/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-1WT6o5+HFQivTSBqqeyKWUQC2SbesgtlI6+ZT8JN+Rg9YarwWOw3DuPdHIYb2jkLzU+wjSkmBXRi7Nox7hfBOw==",
      "path": "avalonia.desktop/12.0.3",
      "hashPath": "avalonia.desktop.12.0.3.nupkg.sha512"
    },
    "Avalonia.Fonts.Inter/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-UWB0YZ15H0RKkkNgywtsO0aee3fcd6C0KQlG72QuDjoc7UIiwAgIrwu/LXkxCmXJcoh/xK/EWeclkwXEr7E50Q==",
      "path": "avalonia.fonts.inter/12.0.3",
      "hashPath": "avalonia.fonts.inter.12.0.3.nupkg.sha512"
    },
    "Avalonia.FreeDesktop/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-t6qSD9slmHDlkBScuOecf5LZHGEhl57d8DQ0raXWXgm3mXkSZc2DTfkGBJajovrQdeuaISlu6sDHzYAs8Zv/iQ==",
      "path": "avalonia.freedesktop/12.0.3",
      "hashPath": "avalonia.freedesktop.12.0.3.nupkg.sha512"
    },
    "Avalonia.FreeDesktop.AtSpi/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-+i58/6jM/YrjfPA3vXfHbEeLNPC2BY1lXGZ4HtZU4IHZ1XkP6xGBGEqwABuruAlSpLoyrE9LVMZ0Uqg3pYOtiQ==",
      "path": "avalonia.freedesktop.atspi/12.0.3",
      "hashPath": "avalonia.freedesktop.atspi.12.0.3.nupkg.sha512"
    },
    "Avalonia.HarfBuzz/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-6R8pHRC9iDrAgT7AD/A3mE6hAPYXf66Ql5kWV046msSWF9ntYwuhNmJwlWeFwUVhb7nXThyTOIfUd3WV0GFXXA==",
      "path": "avalonia.harfbuzz/12.0.3",
      "hashPath": "avalonia.harfbuzz.12.0.3.nupkg.sha512"
    },
    "Avalonia.Native/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-o+36bdY62STT9SjoEIlp/lSHVrQH8uC15gMUA4JMszz4Q4r5rgVMVTsorsIAurdawJ1LaBKIzvbDHyyiRjXROg==",
      "path": "avalonia.native/12.0.3",
      "hashPath": "avalonia.native.12.0.3.nupkg.sha512"
    },
    "Avalonia.Remote.Protocol/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-NHvbiGC461oB3DXt8qgLNN+QfcYARcSxY7diyic9R7u6jQA4bc+ZbjEQKX8y8WyF1vOssedRmuOeTvRXlXbF9Q==",
      "path": "avalonia.remote.protocol/12.0.3",
      "hashPath": "avalonia.remote.protocol.12.0.3.nupkg.sha512"
    },
    "Avalonia.Skia/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-Q0PYiN/B5dZumh89RcDOgbsceh7aUvTGVCKjiq+kcBmVZcvcygHpSRsDJKKUfFHBQLJLtQp7ErLRQUkN4LuIRA==",
      "path": "avalonia.skia/12.0.3",
      "hashPath": "avalonia.skia.12.0.3.nupkg.sha512"
    },
    "Avalonia.Themes.Fluent/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-Acj+gmRm52U8sQIVHk5sCCU65RWjYcurDtxo8zyZSYmM4Vl1z2N9ZLnbK9+wp3N56Z0z/1ddsKYXRq3XfGSP3Q==",
      "path": "avalonia.themes.fluent/12.0.3",
      "hashPath": "avalonia.themes.fluent.12.0.3.nupkg.sha512"
    },
    "Avalonia.Win32/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-shPBe7puXXjEWr9gq4DKZZBpfv2tGxdghK1nsRnVC7J3tx3Hm2/+Ik7vYoIYSdUv7MkAZZ4ham9Inqn8CcODBw==",
      "path": "avalonia.win32/12.0.3",
      "hashPath": "avalonia.win32.12.0.3.nupkg.sha512"
    },
    "Avalonia.X11/12.0.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-rQ0gbEcKcWXN2Pc0PS5gtLUEsi/yW1JvEbxGWi9D6ip/hdmczLtEG1n3Irtn7MJFjLJq5N6cLM2Prh4Euxwg9Q==",
      "path": "avalonia.x11/12.0.3",
      "hashPath": "avalonia.x11.12.0.3.nupkg.sha512"
    },
    "CommunityToolkit.Mvvm/8.4.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-BTRteP8SvFyd/4KAreIFJBcxD2O9trLxLDD/p8YkSDDrfFOzy2U8cHyz6r+5Eh4kDhJdzAVglei6a+Bh4jCpUA==",
      "path": "communitytoolkit.mvvm/8.4.1",
      "hashPath": "communitytoolkit.mvvm.8.4.1.nupkg.sha512"
    },
    "HarfBuzzSharp/8.3.1.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-NGZ2+ZVNPM+NdHB/asW0/ykWngyHWwcqjrbN2nDeH1B/aptPGlCUl8wkQ2cSJxw5fdWgdmIPmNuTPWpLwNVXWg==",
      "path": "harfbuzzsharp/8.3.1.3",
      "hashPath": "harfbuzzsharp.8.3.1.3.nupkg.sha512"
    },
    "HarfBuzzSharp.NativeAssets.Linux/8.3.1.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-RI6A1LgmooU30+4QIyFt5rmBCzP0VzTR+587IJSGvYIsHHWlahFufihYxtraLfsIhW7I8dn6+xX+DZGygOPKWQ==",
      "path": "harfbuzzsharp.nativeassets.linux/8.3.1.3",
      "hashPath": "harfbuzzsharp.nativeassets.linux.8.3.1.3.nupkg.sha512"
    },
    "HarfBuzzSharp.NativeAssets.macOS/8.3.1.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-KPTq0xnslkI6nAo0jh3ptcQPJvZZr7MWYXa2jUe4SnHc9q+JlHElmNXp0sfFoiTgoCX7WOYpYsurypuH9Gehxw==",
      "path": "harfbuzzsharp.nativeassets.macos/8.3.1.3",
      "hashPath": "harfbuzzsharp.nativeassets.macos.8.3.1.3.nupkg.sha512"
    },
    "HarfBuzzSharp.NativeAssets.WebAssembly/8.3.1.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-w2QfdNm9Uz/sUa0B5D+OnVQhyq3G/fBq6ibQMdWBlQqqwh0g0/5j3RFvYqZAmRZ5+RzvjVe8o8SFFnWYUSkuxA==",
      "path": "harfbuzzsharp.nativeassets.webassembly/8.3.1.3",
      "hashPath": "harfbuzzsharp.nativeassets.webassembly.8.3.1.3.nupkg.sha512"
    },
    "HarfBuzzSharp.NativeAssets.Win32/8.3.1.3": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-bx8CE8Js+XGX8PUxAHCBDEORt5aaBYtMN4Hr9QFs57Xithh6yjUyYqksizH6eRDhJkwsGI+SXWmPmMm8lZC9Pw==",
      "path": "harfbuzzsharp.nativeassets.win32/8.3.1.3",
      "hashPath": "harfbuzzsharp.nativeassets.win32.8.3.1.3.nupkg.sha512"
    },
    "MicroCom.Runtime/0.11.4": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-yZ8+Lgwo+KtRI29TB2mIOEMzV+csMJ+pKZg4YHReAP3vRewWLKKeYfrBDo5FS69rWnEbCfU3sbM+ZEQr+GDLtg==",
      "path": "microcom.runtime/0.11.4",
      "hashPath": "microcom.runtime.0.11.4.nupkg.sha512"
    },
    "SkiaSharp/3.119.4-preview.1.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-cyRjWksj/SwFWo7uPfpFk0sOPyUcE+FhF6ENFc3Q100sdJWHEA2nU1PcEeT7LsLFKBvDP/67q0A8vEXc4kvXnA==",
      "path": "skiasharp/3.119.4-preview.1.1",
      "hashPath": "skiasharp.3.119.4-preview.1.1.nupkg.sha512"
    },
    "SkiaSharp.NativeAssets.Linux/3.119.4-preview.1.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-rZEnNkds7UWOWCCsi//v3VQ7MWbhqn83J1mCzl9069N1Zza7SXufVvsvpI4qJYUHaRx8ZhAaL0yi3zlKoXaUJw==",
      "path": "skiasharp.nativeassets.linux/3.119.4-preview.1.1",
      "hashPath": "skiasharp.nativeassets.linux.3.119.4-preview.1.1.nupkg.sha512"
    },
    "SkiaSharp.NativeAssets.macOS/3.119.4-preview.1.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-77gyFnZD0uU12ABgI6pe8Iw2GRBYGryMP4EaHFs7fniffthVT5sf4PTug4ytwNzLKkVDiLobEpIvAJAj3UXwEw==",
      "path": "skiasharp.nativeassets.macos/3.119.4-preview.1.1",
      "hashPath": "skiasharp.nativeassets.macos.3.119.4-preview.1.1.nupkg.sha512"
    },
    "SkiaSharp.NativeAssets.WebAssembly/3.119.4-preview.1.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-IyNI0QRJGl5sT0Dz2rGHBYVmenNoXcOCaC21avrLG5LwkX8ou0PluW2Hgz7NxHxiRL9D0kPmtoYWrr3uxd1NgA==",
      "path": "skiasharp.nativeassets.webassembly/3.119.4-preview.1.1",
      "hashPath": "skiasharp.nativeassets.webassembly.3.119.4-preview.1.1.nupkg.sha512"
    },
    "SkiaSharp.NativeAssets.Win32/3.119.4-preview.1.1": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-BYwNLG02IAYMsBPgU9lM37xJgCM3B/2X5z1FQEBR34dmn+Hxvcw8X83PInY2rzix7mlbcv7OF8UHjf7yMbsDaA==",
      "path": "skiasharp.nativeassets.win32/3.119.4-preview.1.1",
      "hashPath": "skiasharp.nativeassets.win32.3.119.4-preview.1.1.nupkg.sha512"
    },
    "System.IO.Pipelines/8.0.0": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-FHNOatmUq0sqJOkTx+UF/9YK1f180cnW5FVqnQMvYUN0elp6wFzbtPSiqbo1/ru8ICp43JM1i7kKkk6GsNGHlA==",
      "path": "system.io.pipelines/8.0.0",
      "hashPath": "system.io.pipelines.8.0.0.nupkg.sha512"
    },
    "Tmds.DBus.Protocol/0.92.0": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-h7IMakm0PF2jxiagoysoAjrzzLQ0UBdnSXQL5kb17YW0Fvyo12Tg96A99QkzwktWRrd7H+Uw9EzjasNLUfGYlA==",
      "path": "tmds.dbus.protocol/0.92.0",
      "hashPath": "tmds.dbus.protocol.0.92.0.nupkg.sha512"
    }
  }
}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.dll

_Skipped binary or large file. Size: 5384192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe

_Skipped binary or large file. Size: 152064 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/AutoLaunchProtocolsComponent/1.0.0.10/manifest.json

``json
{
    "description" : "AutoLaunch Protocols Preregistration",
    "name" : "Protocol Preregistration",
    "version" : "1.0.0.10"
}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/AutoLaunchProtocolsComponent/1.0.0.10/protocols.json

``json
{
  "allow": [
    {
      "origins": [
        "https://.get.microsoft.com",
        "https://.apps.microsoft.com"
      ],
      "protocol": "ms-windows-store"
    },
    {
      "origins": [
        "https://.onedrive.com",
        "https://.onedrive.live.com",
        "https://sharepoint.com"
      ],
      "protocol": "ms-word"
    },
    {
      "origins": [
        "https://[a-z1-9-]*word-edit.officeapps.live.com",
        "https://[a-z1-9-]*word-view.officeapps.live.com",
        "https://[a-z1-9-]*onenote.officeapps.live.com",
        "https://[a-z1-9-]*eap.officeapps.live.com",
        "https://[a-z1-9-]*shared.officeapps.live.com",
        "https://[a-z1-9-]*afhs.officeapps.live.com",
        "https://[a-z1-9-]*vhs.officeapps.live.com",
        "https://[a-z1-9-]*optin.online.office.com"
      ],
      "use_regex": true,
      "protocol": "ms-word"
    },
    {
      "origins": [
        "https://.onedrive.com",
        "https://.onedrive.live.com",
        "https://sharepoint.com"
      ],
      "protocol": "ms-excel"
    },
    {
      "origins": [
        "https://[a-z1-9-]*excel.officeapps.live.com",
        "https://[a-z1-9-]*onenote.officeapps.live.com",
        "https://[a-z1-9-]*eap.officeapps.live.com",
        "https://[a-z1-9-]*shared.officeapps.live.com",
        "https://[a-z1-9-]*afhs.officeapps.live.com",
        "https://[a-z1-9-]*vhs.officeapps.live.com",
        "https://[a-z1-9-]*optin.online.office.com"
      ],
      "use_regex": true,
      "protocol": "ms-excel"
    },
    {
      "origins": [
        "https://.onedrive.com",
        "https://.onedrive.live.com",
        "https://sharepoint.com"
      ],
      "protocol": "ms-powerpoint"
    },
    {
      "origins": [
        "https://[a-z1-9-]*powerpoint.officeapps.live.com",
        "https://[a-z1-9-]*onenote.officeapps.live.com",
        "https://[a-z1-9-]*eap.officeapps.live.com",
        "https://[a-z1-9-]*shared.officeapps.live.com",
        "https://[a-z1-9-]*afhs.officeapps.live.com",
        "https://[a-z1-9-]*vhs.officeapps.live.com",
        "https://[a-z1-9-]*optin.online.office.com"
      ],
      "use_regex": true,
      "protocol": "ms-powerpoint"
    },
    {
      "origins": [
        "https://.onedrive.com",
        "https://.onedrive.live.com",
        "https://sharepoint.com"
      ],
      "protocol": "ms-visio"
    },
    {
      "origins": [
        "https://[a-z1-9-]*visio.officeapps.live.com",
        "https://[a-z1-9-]*onenote.officeapps.live.com",
        "https://[a-z1-9-]*eap.officeapps.live.com",
        "https://[a-z1-9-]*shared.officeapps.live.com",
        "https://[a-z1-9-]*afhs.officeapps.live.com",
        "https://[a-z1-9-]*vhs.officeapps.live.com",
        "https://[a-z1-9-]*optin.online.office.com"
      ],
      "use_regex": true,
      "protocol": "ms-visio"
    },
    {
      "origins": [
        "https://www.microsoft.com",
        "https://copilot.microsoft.com"
      ],
      "protocol": "ms-copilot"
    }
  ],
  "warn": [
    {
      "origins": [
        "*"
      ],
      "protocol": "ms-test-warn"
    }
  ],
  "block": [
    {
      "origins": [
        "*"
      ],
      "protocol": "ms-test-block"
    }
  ]
}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/BrowserMetrics/BrowserMetrics-6A17C200-8808.pma

_Skipped binary or large file. Size: 1310720 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/BrowserMetrics/BrowserMetrics-6A17C2FF-75D4.pma

_Skipped binary or large file. Size: 1310720 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/CertificateRevocation/6498.2025.9.4/crl-set

_Skipped binary or large file. Size: 23123 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/CertificateRevocation/6498.2025.9.4/manifest.json

``json
{
    "description":  "Microsoft CRLSet",
    "name":  "MicrosoftCRLSet",
    "version":  "6498.2025.9.4"
}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/00af3f07b5abb71f6d30337e1eef62fa280f06ef19485c0cf6b72171f92ccc0a

_Skipped binary or large file. Size: 1093663 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/720517793663c90e0dbd77cb42709bac49af733f83f73320ba89859d9b0310e0

_Skipped binary or large file. Size: 2393882 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/a81d1959892ae4180554347df1b97834abba2e1a5e6b9aeba000ecea26eabecc

_Skipped binary or large file. Size: 975576 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/a922b7d113e67ce71528805d3c6780f7a207cada8ad56642047577358e46ba3d

_Skipped binary or large file. Size: 8410 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/bec8ead1da3c9600fe66bbcc0e7a9bed9a184c1be821b4d23570c6b7af7f0410

_Skipped binary or large file. Size: 186331 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/fa29a6d5775ff340900a65b39b02fc8b4b77d403c048d8debf22f2f5d09c61a0

_Skipped binary or large file. Size: 23359 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/component_crx_cache/metadata.json

``json
{"hashes":{"00af3f07b5abb71f6d30337e1eef62fa280f06ef19485c0cf6b72171f92ccc0a":{"appid":"kpfehajjjbbcifeehjgfgnabifknmdad"},"720517793663c90e0dbd77cb42709bac49af733f83f73320ba89859d9b0310e0":{"appid":"ndikpojcjlepofdkaaldkinkjbeeebkl"},"a81d1959892ae4180554347df1b97834abba2e1a5e6b9aeba000ecea26eabecc":{"appid":"fppmbhmldokgmleojlplaaodlkibgikh"},"a922b7d113e67ce71528805d3c6780f7a207cada8ad56642047577358e46ba3d":{"appid":"fgbafbciocncjfbbonhocjaohoknlaco"},"bec8ead1da3c9600fe66bbcc0e7a9bed9a184c1be821b4d23570c6b7af7f0410":{"appid":"alpjnmnfbgfkmmpcfpejmmoebdndedno"},"fa29a6d5775ff340900a65b39b02fc8b4b77d403c048d8debf22f2f5d09c61a0":{"appid":"oankkpibpaokgecfckkdkgaoafllipag"}}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Crashpad/metadata

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Crashpad/settings.dat

_Skipped binary or large file. Size: 288 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Crashpad/throttle_store.dat

``text
level=none expiry=0

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/AutofillAiModelCache/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/AutofillAiModelCache/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/AutofillAiModelCache/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/AutofillStrikeDatabase/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/AutofillStrikeDatabase/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/AutofillStrikeDatabase/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BookmarkMergedSurfaceOrdering

``text
{
}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BrowsingTopicsSiteData

_Skipped binary or large file. Size: 28672 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BrowsingTopicsSiteData-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BrowsingTopicsState

``text
{
   "epochs": [ {
      "calculation_time": "13423917261701730",
      "config_version": 0,
      "model_version": "0",
      "padded_top_topics_start_index": 0,
      "taxonomy_version": 0,
      "top_topics_and_observing_domains": [  ]
   } ],
   "hex_encoded_hmac_key": "BF97503F6E829B56F911EF627741767C4CD283AC4F385DDA93F770193A936B76",
   "next_scheduled_calculation_time": "13424522061702464"
}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BudgetDatabase/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BudgetDatabase/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/BudgetDatabase/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/data_0

_Skipped binary or large file. Size: 45056 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/data_2

_Skipped binary or large file. Size: 1056768 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/data_3

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0000fc

_Skipped binary or large file. Size: 3170919 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000100

_Skipped binary or large file. Size: 292727 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000108

_Skipped binary or large file. Size: 3170919 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00010c

_Skipped binary or large file. Size: 2147168 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000114

_Skipped binary or large file. Size: 1939780 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000118

_Skipped binary or large file. Size: 1933317 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00011f

_Skipped binary or large file. Size: 566803 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000123

_Skipped binary or large file. Size: 2147168 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000127

_Skipped binary or large file. Size: 4363006 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00012b

_Skipped binary or large file. Size: 3740336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00012f

_Skipped binary or large file. Size: 668345 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000133

_Skipped binary or large file. Size: 123603 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000137

_Skipped binary or large file. Size: 3587590 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00013b

_Skipped binary or large file. Size: 823182 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00013f

_Skipped binary or large file. Size: 5134217 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00014f

_Skipped binary or large file. Size: 210007 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000153

_Skipped binary or large file. Size: 283972 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000157

_Skipped binary or large file. Size: 210007 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00015b

_Skipped binary or large file. Size: 643695 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00015f

_Skipped binary or large file. Size: 212683 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000173

_Skipped binary or large file. Size: 210007 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000177

_Skipped binary or large file. Size: 210007 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00017f

_Skipped binary or large file. Size: 212683 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000183

_Skipped binary or large file. Size: 212683 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000187

_Skipped binary or large file. Size: 15061238 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00018b

_Skipped binary or large file. Size: 155223 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00018f

_Skipped binary or large file. Size: 2024946 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000197

_Skipped binary or large file. Size: 1939780 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00019b

_Skipped binary or large file. Size: 1933317 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00019f

_Skipped binary or large file. Size: 512868 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001a3

_Skipped binary or large file. Size: 2716400 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001a7

_Skipped binary or large file. Size: 3587590 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001bf

_Skipped binary or large file. Size: 60828 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001d7

_Skipped binary or large file. Size: 7497559 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001df

_Skipped binary or large file. Size: 7497559 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001e3

_Skipped binary or large file. Size: 306778 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_0001fb

_Skipped binary or large file. Size: 3170919 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000203

_Skipped binary or large file. Size: 283972 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000207

_Skipped binary or large file. Size: 135646 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000208

``text
import * as pdfjsLib from "../PdfJs/build/pdf.mjs";

pdfjsLib.GlobalWorkerOptions.workerSrc = "../PdfJs/build/pdf.worker.mjs";

const viewer = document.getElementById("viewer");
const statusBar = document.getElementById("status");

const pageStates = new Map();

let pdfDocument = null;
let currentScale = 1.2;
let visualScale = 1.2;
let currentPage = 1;
let zoomTimer = null;
let isLiveZooming = false;
let scrollTimer = null;
let customSelection = null;
let areaSelectionBox = null;
let currentToolMode = "select";
let handPanState = null;
let storedHighlights = [];

const RENDER_QUALITY = 2;
const MAX_OUTPUT_SCALE = 4;
const MIN_ZOOM = 0.5;
const MAX_ZOOM = 4;
const AREA_SELECTION_THRESHOLD = 4;

function getQueryValue(name) {
    const params = new URLSearchParams(window.location.search);
    return params.get(name);
}

function getHashValue(name, fallback) {
    const hash = window.location.hash.replace("#", "");
    const params = new URLSearchParams(hash);
    return params.get(name) || fallback;
}

function clampScale(scale) {
    return Math.min(Math.max(scale, MIN_ZOOM), MAX_ZOOM);
}

function sendToCSharp(type, data = {}) {
    const payload = JSON.stringify({
        type,
        pageNumber: data.pageNumber || currentPage,
        zoomPercent: Math.round(currentScale * 100),
        ...data
    });

    try {
        if (typeof invokeCSharpAction === "function") {
            invokeCSharpAction(payload);
            return;
        }

        if (window.chrome?.webview?.postMessage) {
            window.chrome.webview.postMessage(payload);
            return;
        }

        if (window.webkit?.messageHandlers?.webview?.postMessage) {
            window.webkit.messageHandlers.webview.postMessage(payload);
        }
    } catch {
    }
}

function getOutputScale() {
    const deviceScale = window.devicePixelRatio || 1;
    return Math.min(deviceScale * RENDER_QUALITY, MAX_OUTPUT_SCALE);
}

function cancelTask(task) {
    try {
        task?.cancel?.();
    } catch {
    }
}

function isCancellationError(error) {
    return error?.name === "RenderingCancelledException" ||
        error?.name === "AbortException";
}

function applyPageVisualScale(state, nextVisualScale) {
    const visualWidth = Math.floor(state.baseWidth * nextVisualScale);
    const visualHeight = Math.floor(state.baseHeight * nextVisualScale);

    state.wrapper.style.width = `${visualWidth}px`;
    state.wrapper.style.height = `${visualHeight}px`;

    if (!state.content || !state.renderedScale) {
        return;
    }

    const ratio = nextVisualScale / state.renderedScale;

    if (Math.abs(ratio - 1) < 0.001) {
        state.content.style.transform = "";
        state.content.style.transformOrigin = "";
        return;
    }

    state.content.style.transform = `scale(${ratio})`;
    state.content.style.transformOrigin = "0 0";
}

function getZoomAnchor(clientX = null, clientY = null) {
    const viewerRect = viewer.getBoundingClientRect();
    const fallbackClientX = viewerRect.left + viewer.clientWidth / 2;
    const fallbackClientY = viewerRect.top + viewer.clientHeight / 2;
    const anchorClientX = clientX ?? fallbackClientX;
    const anchorClientY = clientY ?? fallbackClientY;
    const clampedClientX = Math.min(
        Math.max(anchorClientX, viewerRect.left),
        viewerRect.right
    );
    const clampedClientY = Math.min(
        Math.max(anchorClientY, viewerRect.top),
        viewerRect.bottom
    );

    let anchorState = null;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageRect = state.wrapper.getBoundingClientRect();

        if (pageRect.top <= clampedClientY && pageRect.bottom >= clampedClientY) {
            anchorState = state;
            break;
        }

        const pageMiddle = pageRect.top + pageRect.height / 2;
        const distance = Math.abs(pageMiddle - clampedClientY);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            anchorState = state;
        }
    }

    if (!anchorState) {
        return null;
    }

    const pageHeight = Math.max(anchorState.wrapper.clientHeight, 1);
    const pageWidth = Math.max(anchorState.wrapper.clientWidth, 1);
    const pageRect = anchorState.wrapper.getBoundingClientRect();
    const yRatio = Math.min(
        Math.max((clampedClientY - pageRect.top) / pageHeight, 0),
        1
    );
    const xRatio = Math.min(
        Math.max((clampedClientX - pageRect.left) / pageWidth, 0),
        1
    );

    return {
        pageNumber: anchorState.pageNumber,
        xRatio,
        yRatio,
        offsetInViewerX: clampedClientX - viewerRect.left,
        offsetInViewerY: clampedClientY - viewerRect.top
    };
}

function restoreZoomAnchor(anchor) {
    if (!anchor) {
        return;
    }

    const state = pageStates.get(anchor.pageNumber);

    if (!state) {
        return;
    }

    viewer.scrollLeft = state.wrapper.offsetLeft +
        state.wrapper.clientWidth * anchor.xRatio -
        anchor.offsetInViewerX;
    viewer.scrollTop = state.wrapper.offsetTop +
        state.wrapper.clientHeight * anchor.yRatio -
        anchor.offsetInViewerY;
}

async function cancelActiveRenderTasks() {
    for (const state of pageStates.values()) {
        cancelTask(state.renderTask);
        cancelTask(state.textLayerTask);
        state.renderTask = null;
        state.textLayerTask = null;
        state.renderPromise = null;
        state.renderingScale = 0;
    }
}

async function createPagePlaceholder(pageNumber) {
    const page = await pdfDocument.getPage(pageNumber);
    const baseViewport = page.getViewport({ scale: 1 });

    const wrapper = document.createElement("div");
    wrapper.className = "page";
    wrapper.dataset.pageNumber = String(pageNumber);

    const state = {
        pageNumber,
        wrapper,
        content: null,
        canvas: null,
        textLayer: null,
        highlightLayer: null,
        selectionOverlay: null,
        textItems: [],
        selectedWordRects: [],
        renderTask: null,
        textLayerTask: null,
        renderPromise: null,
        renderingScale: 0,
        renderedScale: 0,
        baseWidth: baseViewport.width,
        baseHeight: baseViewport.height,
        isRendered: false
    };

    pageStates.set(pageNumber, state);
    viewer.appendChild(wrapper);
    applyPageVisualScale(state, currentScale);
}

async function createPagePlaceholders() {
    viewer.innerHTML = "";
    pageStates.clear();

    for (let pageNumber = 1; pageNumber <= pdfDocument.numPages; pageNumber++) {
        await createPagePlaceholder(pageNumber);
    }
}

function buildSelectableWords(textContent, viewport) {
    const words = [];
    let globalIndex = 0;

    for (const item of textContent.items) {
        if (!item.str || !item.transform) {
            continue;
        }

        const text = item.str;
        const pdfTransform = pdfjsLib.Util.transform(
            viewport.transform,
            item.transform
        );
        const x = pdfTransform[4];
        const y = pdfTransform[5];
        const fontHeight = Math.abs(pdfTransform[3]) || item.height || 10;
        const itemWidth = Number.isFinite(item.width)
            ? Math.abs(item.width * viewport.scale)
            : Math.max(text.length * fontHeight * 0.45, 1);
        const parts = text.match(/\S+|\s+/g) ?? [];

        let cursorX = x;

        for (const part of parts) {
            const width = text.length > 0
                ? itemWidth * (part.length / text.length)
                : 0;

            if (part.trim().length > 0) {
                words.push({
                    index: globalIndex++,
                    text: part,
                    left: cursorX,
                    top: y - fontHeight,
                    right: cursorX + width,
                    bottom: y,
                    width,
                    height: fontHeight,
                    lineY: y
                });
            }

            cursorX += width;
        }
    }

    return words;
}

async function renderTextLayer(page, viewport, content, state) {
    const textLayerDiv = document.createElement("div");
    textLayerDiv.className = "textLayer";
    textLayerDiv.style.width = `${Math.floor(viewport.width)}px`;
    textLayerDiv.style.height = `${Math.floor(viewport.height)}px`;

    content.appendChild(textLayerDiv);

    const textContent = await page.getTextContent({
        includeMarkedContent: true,
        disableNormalization: false
    });

    state.textItems = buildSelectableWords(textContent, viewport);

    if (!pdfjsLib.TextLayer) {
        throw new Error("PDF.js TextLayer API is not available in this build.");
    }

    const textLayer = new pdfjsLib.TextLayer({
        textContentSource: textContent,
        container: textLayerDiv,
        viewport
    });

    state.textLayerTask = textLayer;
    await textLayer.render();
    state.textLayerTask = null;

    return textLayerDiv;
}

function createHighlightLayer(viewport) {
    const highlightLayer = document.createElement("div");
    highlightLayer.className = "highlightLayer";
    highlightLayer.style.width = `${Math.floor(viewport.width)}px`;
    highlightLayer.style.height = `${Math.floor(viewport.height)}px`;
    return highlightLayer;
}

async function renderPage(pageNumber, force = false) {
    const state = pageStates.get(pageNumber);

    if (!state || isLiveZooming) {
        return;
    }

    if (!force && state.isRendered && state.renderedScale === currentScale) {
        return;
    }

    if (!force && state.renderPromise && state.renderingScale === currentScale) {
        return state.renderPromise;
    }

    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);
    state.renderTask = null;
    state.textLayerTask = null;

    const renderPromise = renderPageInternal(state);
    state.renderPromise = renderPromise;
    state.renderingScale = currentScale;

    try {
        await renderPromise;
    } finally {
        if (state.renderPromise === renderPromise) {
            state.renderPromise = null;
            state.renderingScale = 0;
        }
    }
}

async function renderPageInternal(state) {
    const targetScale = currentScale;
    const page = await pdfDocument.getPage(state.pageNumber);
    const viewport = page.getViewport({ scale: targetScale });

    const content = document.createElement("div");
    content.className = "pageContent";
    content.style.width = `${Math.floor(viewport.width)}px`;
    content.style.height = `${Math.floor(viewport.height)}px`;
    content.style.setProperty("--total-scale-factor", String(targetScale));

    const canvas = document.createElement("canvas");
    canvas.className = "canvasLayer";
    canvas.style.width = `${Math.floor(viewport.width)}px`;
    canvas.style.height = `${Math.floor(viewport.height)}px`;

    const context = canvas.getContext("2d", {
        alpha: false
    });

    if (!context) {
        throw new Error("Unable to create canvas context.");
    }

    const outputScale = getOutputScale();

    canvas.width = Math.floor(viewport.width * outputScale);
    canvas.height = Math.floor(viewport.height * outputScale);

    content.appendChild(canvas);

    const renderTask = page.render({
        canvasContext: context,
        viewport,
        transform: outputScale !== 1
            ? [outputScale, 0, 0, outputScale, 0, 0]
            : null
    });

    state.renderTask = renderTask;

    try {
        await renderTask.promise;
    } catch (error) {
        if (isCancellationError(error)) {
            return;
        }

        throw error;
    } finally {
        if (state.renderTask === renderTask) {
            state.renderTask = null;
        }
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    let textLayer = null;

    try {
        textLayer = await renderTextLayer(page, viewport, content, state);
    } catch (error) {
        if (!isCancellationError(error)) {
            throw error;
        }

        return;
    } finally {
        state.textLayerTask = null;
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    const highlightLayer = createHighlightLayer(viewport);
    content.appendChild(highlightLayer);

    const selectionOverlay = document.createElement("div");
    selectionOverlay.className = "selectionOverlay";
    content.appendChild(selectionOverlay);

    const oldContent = state.content;

    state.wrapper.appendChild(content);

    if (oldContent) {
        oldContent.remove();
    }

    state.content = content;
    state.canvas = canvas;
    state.textLayer = textLayer;
    state.highlightLayer = highlightLayer;
    state.selectionOverlay = selectionOverlay;
    state.renderedScale = targetScale;
    state.isRendered = true;

    renderStoredHighlightsForPage(state);
    applyPageVisualScale(state, visualScale);
}

function isPageNearViewport(wrapper, buffer = viewer.clientHeight) {
    const viewerRect = viewer.getBoundingClientRect();
    const pageRect = wrapper.getBoundingClientRect();

    return (
        pageRect.bottom >= viewerRect.top - buffer &&
        pageRect.top <= viewerRect.bottom + buffer
    );
}

function unloadPage(state) {
    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);

    state.content?.remove();

    state.content = null;
    state.canvas = null;
    state.textLayer = null;
    state.highlightLayer = null;
    state.selectionOverlay = null;
    state.textItems = [];
    state.selectedWordRects = [];
    state.renderTask = null;
    state.textLayerTask = null;
    state.renderPromise = null;
    state.renderingScale = 0;
    state.renderedScale = 0;
    state.isRendered = false;
}

function cleanupFarPages() {
    const buffer = viewer.clientHeight * 3;

    for (const state of pageStates.values()) {
        if (!isPageNearViewport(state.wrapper, buffer)) {
            unloadPage(state);
        }
    }
}

async function renderVisiblePages(force = false) {
    if (isLiveZooming) {
        return;
    }

    const renderPromises = [];

    for (const state of pageStates.values()) {
        if (isPageNearViewport(state.wrapper)) {
            renderPromises.push(renderPage(state.pageNumber, force));
        }
    }

    cleanupFarPages();
    await Promise.all(renderPromises);
}

function updateCurrentPageFromScroll() {
    if (pageStates.size === 0) {
        return;
    }

    const viewportMiddle = viewer.scrollTop + viewer.clientHeight / 2;

    let nearestPage = 1;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageTop = state.wrapper.offsetTop;
        const pageMiddle = pageTop + state.wrapper.clientHeight / 2;
        const distance = Math.abs(pageMiddle - viewportMiddle);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            nearestPage = state.pageNumber;
        }
    }

    if (nearestPage !== currentPage) {
        currentPage = nearestPage;
        statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function scrollToPage(pageNumber, notify = true) {
    const state = pageStates.get(pageNumber);

    if (!state) {
        return;
    }

    state.wrapper.scrollIntoView({ block: "start" });
    currentPage = pageNumber;

    if (notify) {
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function clearAllSelectionOverlays() {
    for (const state of pageStates.values()) {
        if (state.selectionOverlay) {
            state.selectionOverlay.innerHTML = "";
        }
    }
}

function clearCustomSelection() {
    customSelection = null;
    clearAllSelectionOverlays();
    clearAreaSelectionBox();
}

function clearAreaSelectionBox() {
    areaSelectionBox?.remove();
    areaSelectionBox = null;
}

function setToolMode(toolMode) {
    currentToolMode = ["hand", "highlight"].includes(toolMode)
        ? toolMode
        : "select";
    handPanState = null;
    viewer.classList.toggle("toolHand", currentToolMode === "hand");
    viewer.classList.toggle("toolSelect", currentToolMode === "select");
    viewer.classList.toggle("toolHighlight", currentToolMode === "highlight");
    viewer.classList.remove("panning");

    if (currentToolMode === "hand") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
    }
}

function startHandPan(event) {
    if (event.button !== 0 || isLiveZooming) {
        return false;
    }

    handPanState = {
        pointerId: event.pointerId,
        startClientX: event.clientX,
        startClientY: event.clientY,
        startScrollLeft: viewer.scrollLeft,
        startScrollTop: viewer.scrollTop
    };

    viewer.classList.add("panning");
    viewer.setPointerCapture?.(event.pointerId);
    event.preventDefault();
    return true;
}

function moveHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    viewer.scrollLeft = handPanState.startScrollLeft -
        (event.clientX - handPanState.startClientX);
    viewer.scrollTop = handPanState.startScrollTop -
        (event.clientY - handPanState.startClientY);
    event.preventDefault();
    return true;
}

function stopHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    handPanState = null;
    viewer.classList.remove("panning");

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    event.preventDefault();
    return true;
}

function getPagePointFromClient(state, clientX, clientY) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        x: (clientX - contentRect.left) / scaleX,
        y: (clientY - contentRect.top) / scaleY
    };
}

function findRenderedPageAtClientPoint(clientX, clientY) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX >= contentRect.left &&
            clientX <= contentRect.right &&
            clientY >= contentRect.top &&
            clientY <= contentRect.bottom
        ) {
            return state;
        }
    }

    return null;
}

function findWordAtClientPoint(clientX, clientY, includeNearbyWord = true) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX < contentRect.left ||
            clientX > contentRect.right ||
            clientY < contentRect.top ||
            clientY > contentRect.bottom
        ) {
            continue;
        }

        const point = getPagePointFromClient(state, clientX, clientY);
        let bestWord = null;
        let bestDistance = Number.MAX_VALUE;

        for (const word of state.textItems) {
            const inside =
                point.x >= word.left &&
                point.x <= word.right &&
                point.y >= word.top &&
                point.y <= word.bottom;

            if (inside) {
                return { state, word };
            }

            const centerX = (word.left + word.right) / 2;
            const centerY = (word.top + word.bottom) / 2;
            const dx = point.x - centerX;
            const dy = point.y - centerY;
            const distance = dx * dx + dy * dy;

            if (distance < bestDistance) {
                bestDistance = distance;
                bestWord = word;
            }
        }

        if (includeNearbyWord && bestWord && bestDistance < 900) {
            return {
                state,
                word: bestWord
            };
        }
    }

    return null;
}

function getClientDragRect(selection) {
    const left = Math.min(selection.startClientX, selection.endClientX);
    const top = Math.min(selection.startClientY, selection.endClientY);
    const right = Math.max(selection.startClientX, selection.endClientX);
    const bottom = Math.max(selection.startClientY, selection.endClientY);

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function rectsIntersect(first, second) {
    return first.right >= second.left &&
        first.left <= second.right &&
        first.bottom >= second.top &&
        first.top <= second.bottom;
}

function getWordClientRect(state, word) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        left: contentRect.left + word.left * scaleX,
        top: contentRect.top + word.top * scaleY,
        right: contentRect.left + word.right * scaleX,
        bottom: contentRect.top + word.bottom * scaleY
    };
}

function getOrCreateAreaSelectionBox() {
    if (areaSelectionBox) {
        return areaSelectionBox;
    }

    areaSelectionBox = document.createElement("div");
    areaSelectionBox.className = "selectionDragBox";
    viewer.appendChild(areaSelectionBox);
    return areaSelectionBox;
}

function renderAreaSelectionBox(selection) {
    const dragRect = getClientDragRect(selection);

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        clearAreaSelectionBox();
        return;
    }

    const viewerRect = viewer.getBoundingClientRect();
    const box = getOrCreateAreaSelectionBox();

    box.style.left = `${dragRect.left - viewerRect.left + viewer.scrollLeft}px`;
    box.style.top = `${dragRect.top - viewerRect.top + viewer.scrollTop}px`;
    box.style.width = `${dragRect.width}px`;
    box.style.height = `${dragRect.height}px`;
}

function updateAreaSelectionWords(selection) {
    const dragRect = getClientDragRect(selection);
    const wordIndexesByPage = new Map();

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        selection.wordIndexesByPage = wordIndexesByPage;
        return;
    }

    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (!rectsIntersect(dragRect, contentRect)) {
            continue;
        }

        const selectedIndexes = new Set();

        for (const word of state.textItems) {
            if (rectsIntersect(dragRect, getWordClientRect(state, word))) {
                selectedIndexes.add(word.index);
            }
        }

        if (selectedIndexes.size > 0) {
            wordIndexesByPage.set(state.pageNumber, selectedIndexes);
        }
    }

    selection.wordIndexesByPage = wordIndexesByPage;
}

function compareSelectionPosition(firstPage, firstIndex, secondPage, secondIndex) {
    if (firstPage !== secondPage) {
        return firstPage - secondPage;
    }

    return firstIndex - secondIndex;
}

function getSelectedWordsForPage(state) {
    if (!customSelection || state.textItems.length === 0) {
        return [];
    }

    if (customSelection.mode === "area") {
        const selectedIndexes = customSelection.wordIndexesByPage?.get(state.pageNumber);

        if (!selectedIndexes) {
            return [];
        }

        return state.textItems.filter(word => selectedIndexes.has(word.index));
    }

    const direction = compareSelectionPosition(
        customSelection.startPage,
        customSelection.startWordIndex,
        customSelection.endPage,
        customSelection.endWordIndex
    );
    const isForward = direction <= 0;
    const firstPage = isForward ? customSelection.startPage : customSelection.endPage;
    const lastPage = isForward ? customSelection.endPage : customSelection.startPage;

    if (state.pageNumber < firstPage || state.pageNumber > lastPage) {
        return [];
    }

    let startIndex = 0;
    let endIndex = state.textItems[state.textItems.length - 1].index;

    if (isForward) {
        if (state.pageNumber === customSelection.startPage) {
            startIndex = customSelection.startWordIndex;
        }

        if (state.pageNumber === customSelection.endPage) {
            endIndex = customSelection.endWordIndex;
        }
    } else {
        if (state.pageNumber === customSelection.endPage) {
            startIndex = customSelection.endWordIndex;
        }

        if (state.pageNumber === customSelection.startPage) {
            endIndex = customSelection.startWordIndex;
        }
    }

    if (startIndex > endIndex) {
        const temp = startIndex;
        startIndex = endIndex;
        endIndex = temp;
    }

    return state.textItems.filter(word =>
        word.index >= startIndex &&
        word.index <= endIndex
    );
}

function groupWordsByLine(words) {
    const lines = new Map();

    for (const word of words) {
        const key = Math.round(word.lineY / 4) * 4;

        if (!lines.has(key)) {
            lines.set(key, []);
        }

        lines.get(key).push(word);
    }

    return [...lines.entries()].sort((first, second) => first[0] - second[0]);
}

function renderCustomSelection() {
    clearAllSelectionOverlays();

    for (const state of pageStates.values()) {
        if (!state.selectionOverlay) {
            continue;
        }

        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const fragment = document.createDocumentFragment();

        for (const segment of buildHighlightSegments(words, state)) {
            const rect = document.createElement("div");

            rect.className = "selectionOverlayRect";
            rect.style.left = `${segment.left}px`;
            rect.style.top = `${segment.top}px`;
            rect.style.width = `${segment.width}px`;
            rect.style.height = `${segment.height}px`;

            fragment.appendChild(rect);
        }

        state.selectionOverlay.appendChild(fragment);
    }
}

function getRenderedPageWidth(state) {
    if (state.content?.offsetWidth) {
        return state.content.offsetWidth;
    }

    if (state.baseWidth && state.renderedScale) {
        return state.baseWidth * state.renderedScale;
    }

    return state.baseWidth * currentScale;
}

function getLineFontHeight(line) {
    const heights = line.words
        .map(word => word.height || 0)
        .filter(height => height > 0)
        .sort((first, second) => first - second);

    return heights.length === 0
        ? 12
        : heights[Math.floor(heights.length / 2)];
}

function getLineText(line) {
    return line.words
        .map(word => word.text ?? "")
        .join("")
        .trim();
}

function compareLinePosition(first, second) {
    const fontHeight = Math.max(getLineFontHeight(first), getLineFontHeight(second));
    const yTolerance = Math.max(2, fontHeight * 0.4);

    if (Math.abs(first.top - second.top) > yTolerance) {
        return first.top - second.top;
    }

    return first.left - second.left;
}

function isProbablyHeadingText(text) {
    if (!text) {
        return false;
    }

    const normalized = text.replace(/\s+/g, " ").trim();

    if (normalized.length <= 3) {
        return false;
    }

    const isUpper = /^([IVXLCDM]+\.?\s+)?[A-ZÀ-Ỵ0-9\s\-–().:]+$/.test(normalized);
    const isNumbered = /^(chương|chapter|section|phần|mục|\d+(\.\d+)*\.?)\s+\d*.*$/i.test(normalized);
    const isCommonHeader = /^(Abstract|Introduction|Methodology|Methods|Results|Discussion|Conclusion|References|Acknowledgment|Tóm\s+tắt|Tổng\s+quan|Kết\s+luận)$/i.test(normalized);

    return isUpper || isNumbered || isCommonHeader;
}

function isFullWidthLine(line, state) {
    const pageWidth = getRenderedPageWidth(state);
    const widthRatio = line.width / Math.max(pageWidth, 1);
    const touchesLeft = line.left <= pageWidth * 0.2;
    const touchesRight = line.right >= pageWidth * 0.8;

    return widthRatio >= 0.65 ||
        (widthRatio >= 0.52 && touchesLeft && touchesRight);
}

function isStructuralLine(line, state) {
    if (isFullWidthLine(line, state)) {
        return true;
    }

    const text = getLineText(line);
    const pageWidth = getRenderedPageWidth(state);

    return isProbablyHeadingText(text) &&
        (line.width / Math.max(pageWidth, 1)) <= 0.65;
}

function groupWordsIntoVisualLines(words, state) {
    const pageWidth = getRenderedPageWidth(state);
    const sortedWords = [...words].sort((first, second) => {
        const fontHeight = Math.max(first.height || 12, second.height || 12);

        return Math.abs(first.lineY - second.lineY) > Math.max(2, fontHeight * 0.4)
            ? first.lineY - second.lineY
            : first.left - second.left;
    });
    const rows = [];

    for (const word of sortedWords) {
        const yTolerance = Math.max(2, (word.height || 12) * 0.4);
        let targetRow = rows.find(row => Math.abs(row.lineY - word.lineY) <= yTolerance);

        if (!targetRow) {
            targetRow = {
                lineY: word.lineY,
                words: []
            };
            rows.push(targetRow);
        }

        targetRow.words.push(word);
    }

    const lines = [];

    for (const row of rows) {
        const rowWords = row.words.sort((first, second) => first.left - second.left);
        let currentLineWords = [];

        for (const word of rowWords) {
            const previous = currentLineWords[currentLineWords.length - 1];

            if (!previous) {
                currentLineWords.push(word);
                continue;
            }

            const fontHeight = Math.max(previous.height || 12, word.height || 12);

            if ((word.left - previous.right) > Math.max(fontHeight * 2.8, pageWidth * 0.022)) {
                lines.push(createVisualLineFromWords(currentLineWords));
                currentLineWords = [word];
            } else {
                currentLineWords.push(word);
            }
        }

        if (currentLineWords.length > 0) {
            lines.push(createVisualLineFromWords(currentLineWords));
        }
    }

    return lines.sort(compareLinePosition);
}

function createVisualLineFromWords(words) {
    const left = Math.min(...words.map(word => word.left));
    const right = Math.max(...words.map(word => word.right));
    const top = Math.min(...words.map(word => word.top));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        words,
        left,
        right,
        top,
        bottom,
        lineY: words.reduce((sum, word) => sum + word.lineY, 0) / words.length,
        width: right - left,
        height: bottom - top,
        centerX: (left + right) / 2
    };
}

function getHorizontalOverlapRatio(line, column) {
    const overlap = Math.min(line.right, column.right) -
        Math.max(line.left, column.left);

    return overlap <= 0
        ? 0
        : overlap / Math.min(line.width, column.right - column.left);
}

function groupLinesIntoColumns(lines, state) {
    const columns = [];

    for (const line of [...lines].sort(compareLinePosition)) {
        if (isStructuralLine(line, state)) {
            columns.push({
                lines: [line],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: true
            });
            continue;
        }

        let bestColumn = null;
        let bestScore = 0;

        for (const column of columns) {
            if (column.isStructural) {
                continue;
            }

            const overlapScore = getHorizontalOverlapRatio(line, column);
            const xTolerance = Math.max(3, getLineFontHeight(line) * 0.75);
            const score = line.centerX >= column.left - xTolerance &&
                line.centerX <= column.right + xTolerance
                ? Math.max(overlapScore, 0.5)
                : overlapScore;

            if (score > bestScore) {
                bestScore = score;
                bestColumn = column;
            }
        }

        if (!bestColumn || bestScore < 0.25) {
            bestColumn = {
                lines: [],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: false
            };
            columns.push(bestColumn);
        }

        bestColumn.lines.push(line);
        bestColumn.left = Math.min(bestColumn.left, line.left);
        bestColumn.right = Math.max(bestColumn.right, line.right);
        bestColumn.top = Math.min(bestColumn.top, line.top);
        bestColumn.bottom = Math.max(bestColumn.bottom, line.bottom);
    }

    return columns;
}

function getCopyLinesInReadingOrder(words, state) {
    const lines = groupWordsIntoVisualLines(words, state);

    if (lines.length === 0) {
        return [];
    }

    const sortedLines = [...lines].sort(compareLinePosition);
    const output = [];
    let sectionLines = [];

    function flushSection() {
        if (sectionLines.length === 0) {
            return;
        }

        const columns = groupLinesIntoColumns(sectionLines, state)
            .filter(column => !column.isStructural)
            .sort((first, second) => first.left - second.left);

        for (const column of columns) {
            for (const line of column.lines.sort(compareLinePosition)) {
                output.push(line.words);
            }
        }

        sectionLines = [];
    }

    for (const line of sortedLines) {
        if (isStructuralLine(line, state)) {
            flushSection();
            output.push(line.words);
            continue;
        }

        sectionLines.push(line);
    }

    flushSection();
    return output;
}

function shouldInsertSpaceBetweenWords(previous, current) {
    if (!previous || !current) {
        return false;
    }

    const previousText = previous.text ?? "";
    const currentText = current.text ?? "";

    if (!previousText ||
        !currentText ||
        /^[,.;:!?%)\]\}]/.test(currentText) ||
        /[(\[\{]$/.test(previousText)) {
        return false;
    }

    return (current.left - previous.right) >
        Math.max(2, Math.max(previous.height || 0, current.height || 0, 10) * 0.22);
}

function buildCopiedLineText(lineWords) {
    const sortedWords = [...lineWords].sort((first, second) => first.left - second.left);
    let result = "";
    let previous = null;

    for (const word of sortedWords) {
        if (!word.text) {
            continue;
        }

        if (previous && shouldInsertSpaceBetweenWords(previous, word)) {
            result += " ";
        }

        result += word.text;
        previous = word;
    }

    return result
        .replace(/\s+([,.;:!?%)\]\}])/g, "$1")
        .replace(/([(\[\{])\s+/g, "$1")
        .replace(/\s{2,}/g, " ")
        .trim();
}

function shouldSplitHighlightSegment(previous, current, state) {
    if (!previous || !current) {
        return false;
    }

    const gap = current.left - previous.right;
    const fontHeight = Math.max(previous.height || 12, current.height || 12);
    const pageWidth = getRenderedPageWidth(state);

    return gap > Math.max(fontHeight * 1.15, pageWidth * 0.012, 8);
}

function createHighlightSegment(words) {
    const left = Math.min(...words.map(word => word.left));
    const top = Math.min(...words.map(word => word.top));
    const right = Math.max(...words.map(word => word.right));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function buildHighlightSegments(words, state) {
    const segments = [];
    const lines = groupWordsIntoVisualLines(words, state);

    for (const line of lines) {
        const sortedWords = [...line.words].sort((first, second) => first.left - second.left);
        let segmentWords = [];

        for (const word of sortedWords) {
            const previous = segmentWords[segmentWords.length - 1];

            if (previous && shouldSplitHighlightSegment(previous, word, state)) {
                segments.push(createHighlightSegment(segmentWords));
                segmentWords = [];
            }

            segmentWords.push(word);
        }

        if (segmentWords.length > 0) {
            segments.push(createHighlightSegment(segmentWords));
        }
    }

    return segments;
}

function getCustomSelectedText() {
    if (!customSelection) {
        return "";
    }

    const selectedLines = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const pageLines = getCopyLinesInReadingOrder(words, state)
            .map(lineWords => buildCopiedLineText(lineWords))
            .filter(line => line.length > 0);

        selectedLines.push(...pageLines);
    }

    return selectedLines.join("\n");
}

function getSelectedHighlightRects() {
    if (!customSelection) {
        return [];
    }

    const result = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const scale = state.renderedScale || currentScale || 1;

        for (const segment of buildHighlightSegments(words, state)) {
            result.push({
                pageNumber: state.pageNumber,
                left: segment.left / scale,
                top: segment.top / scale,
                width: segment.width / scale,
                height: segment.height / scale
            });
        }
    }

    return result;
}

function renderStoredHighlightsForPage(state) {
    if (!state.highlightLayer) {
        return;
    }

    state.highlightLayer.innerHTML = "";

    const scale = state.renderedScale || currentScale || 1;

    for (const highlight of storedHighlights) {
        const rects = highlight.rects ?? highlight.Rects ?? [];

        for (const rect of rects) {
            const pageNumber = rect.pageNumber ?? rect.PageNumber;

            if (pageNumber !== state.pageNumber) {
                continue;
            }

            const left = rect.left ?? rect.Left ?? 0;
            const top = rect.top ?? rect.Top ?? 0;
            const width = rect.width ?? rect.Width ?? 0;
            const height = rect.height ?? rect.Height ?? 0;
            const item = document.createElement("div");

            item.className = "highlightItem";
            item.dataset.highlightId = highlight.id ?? highlight.Id ?? "";
            item.style.left = `${left * scale}px`;
            item.style.top = `${top * scale}px`;
            item.style.width = `${width * scale}px`;
            item.style.height = `${height * scale}px`;

            state.highlightLayer.appendChild(item);
        }
    }
}

function renderAllStoredHighlights() {
    for (const state of pageStates.values()) {
        renderStoredHighlightsForPage(state);
    }
}

function setStoredHighlights(highlights) {
    storedHighlights = Array.isArray(highlights)
        ? highlights
        : [];
    renderAllStoredHighlights();
}

function navigateToStoredHighlight(highlightId) {
    const highlight = storedHighlights.find(item =>
        (item.id ?? item.Id) === highlightId
    );

    if (!highlight) {
        return;
    }

    const rects = highlight.rects ?? highlight.Rects ?? [];

    if (rects.length === 0) {
        return;
    }

    const firstRect = rects[0];
    const pageNumber = firstRect.pageNumber ?? firstRect.PageNumber ?? 1;

    clearCustomSelection();
    scrollToPage(pageNumber);

    setTimeout(async () => {
        await renderVisiblePages(true);
        renderAllStoredHighlights();

        const state = pageStates.get(pageNumber);

        if (!state) {
            return;
        }

        const scale = state.renderedScale || currentScale || 1;
        const top = (firstRect.top ?? firstRect.Top ?? 0) * scale;

        viewer.scrollTop = state.wrapper.offsetTop + top - 80;
    }, 120);
}

function createHighlightFromSelection() {
    const text = getCustomSelectedText();
    const rects = getSelectedHighlightRects();

    if (!text || rects.length === 0) {
        return;
    }

    const firstRect = rects[0];

    sendToCSharp("highlightCreated", {
        text,
        pageNumber: firstRect.pageNumber,
        rects
    });

    clearCustomSelection();
}

function scheduleZoom(newScale, anchorClientX = null, anchorClientY = null) {
    clearCustomSelection();
    window.getSelection()?.removeAllRanges();

    const anchor = getZoomAnchor(anchorClientX, anchorClientY);

    visualScale = clampScale(newScale);
    isLiveZooming = true;

    viewer.classList.add("viewerLiveZoom");

    for (const state of pageStates.values()) {
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(anchor);
    clearTimeout(zoomTimer);

    zoomTimer = setTimeout(async () => {
        await finishZoom(visualScale, anchor);
    }, 300);
}

async function finishZoom(finalScale, zoomAnchor = null) {
    currentScale = clampScale(finalScale);
    visualScale = currentScale;
    isLiveZooming = false;

    viewer.classList.remove("viewerLiveZoom");

    await cancelActiveRenderTasks();

    for (const state of pageStates.values()) {
        state.isRendered = false;
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());

    await renderVisiblePages(true);

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());
    updateCurrentPageFromScroll();
    sendToCSharp("zoomChanged", {
        pageNumber: currentPage
    });
}

window.miniZoteroPdf = {
    goToPage(pageNumber) {
        scrollToPage(pageNumber);
        renderVisiblePages();
    },

    zoomIn() {
        scheduleZoom(visualScale + 0.25);
    },

    zoomOut() {
        scheduleZoom(visualScale - 0.25);
    },

    setZoom(percent) {
        scheduleZoom(percent / 100);
    },

    setToolMode(toolMode) {
        setToolMode(toolMode);
    },

    setHighlights(highlights) {
        setStoredHighlights(highlights);
    },

    goToHighlight(highlightId) {
        navigateToStoredHighlight(highlightId);
    },

    getState() {
        sendToCSharp("state", {
            pageNumber: currentPage
        });
    }
};

async function boot() {
    try {
        setToolMode(currentToolMode);

        const fileUrl = getQueryValue("file");

        if (!fileUrl) {
            throw new Error("Missing file query parameter.");
        }

        const startPage = Number(getHashValue("page", "1"));
        const startZoom = Number(getHashValue("zoom", "120"));

        currentPage = Number.isFinite(startPage) && startPage > 0 ? startPage : 1;
        currentScale = Number.isFinite(startZoom) && startZoom > 0
            ? clampScale(startZoom / 100)
            : 1.2;
        visualScale = currentScale;

        statusBar.textContent = "Loading PDF...";

        pdfDocument = await pdfjsLib.getDocument({
            url: fileUrl,
            cMapUrl: "/PdfJs/cmaps/",
            cMapPacked: true,
            standardFontDataUrl: "/PdfJs/standard_fonts/",
            useSystemFonts: true
        }).promise;

        await createPagePlaceholders();

        setTimeout(async () => {
            scrollToPage(currentPage, false);
            await renderVisiblePages(true);
            statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
            sendToCSharp("loaded", { pageNumber: currentPage });
        }, 150);
    } catch (error) {
        statusBar.textContent = "Failed to load PDF";

        const errorBox = document.createElement("div");
        errorBox.className = "error";
        errorBox.textContent = error?.message || String(error);

        viewer.innerHTML = "";
        viewer.appendChild(errorBox);
    }
}

viewer.addEventListener("scroll", () => {
    clearTimeout(scrollTimer);

    scrollTimer = setTimeout(async () => {
        updateCurrentPageFromScroll();
        await renderVisiblePages();
        renderCustomSelection();
    }, 120);
}, { passive: true });

viewer.addEventListener("pointerdown", event => {
    if (currentToolMode === "hand") {
        startHandPan(event);
        return;
    }

    if (event.button !== 0 || isLiveZooming) {
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY, false);

    if (!hit) {
        const pageState = findRenderedPageAtClientPoint(event.clientX, event.clientY);

        if (!pageState) {
            clearCustomSelection();
            return;
        }

        event.preventDefault();

        customSelection = {
            mode: "area",
            startClientX: event.clientX,
            startClientY: event.clientY,
            endClientX: event.clientX,
            endClientY: event.clientY,
            isDragging: true,
            wordIndexesByPage: new Map()
        };

        viewer.setPointerCapture?.(event.pointerId);
        clearAllSelectionOverlays();
        return;
    }

    event.preventDefault();

    customSelection = {
        mode: "word",
        startPage: hit.state.pageNumber,
        startWordIndex: hit.word.index,
        endPage: hit.state.pageNumber,
        endWordIndex: hit.word.index,
        isDragging: true
    };

    viewer.setPointerCapture?.(event.pointerId);
    renderCustomSelection();
});

viewer.addEventListener("pointermove", event => {
    if (currentToolMode === "hand") {
        moveHandPan(event);
        return;
    }

    if (!customSelection?.isDragging || isLiveZooming) {
        return;
    }

    if (customSelection.mode === "area") {
        event.preventDefault();

        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;

        renderAreaSelectionBox(customSelection);
        updateAreaSelectionWords(customSelection);
        renderCustomSelection();
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY);

    if (!hit) {
        return;
    }

    event.preventDefault();

    customSelection.endPage = hit.state.pageNumber;
    customSelection.endWordIndex = hit.word.index;

    renderCustomSelection();
});

viewer.addEventListener("pointerup", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;

    if (customSelection.mode === "area") {
        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;
        updateAreaSelectionWords(customSelection);
    }

    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    renderCustomSelection();

    if (currentToolMode === "highlight") {
        createHighlightFromSelection();
    }
});

viewer.addEventListener("pointercancel", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;
    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }
});

viewer.addEventListener("wheel", event => {
    if (!event.ctrlKey) {
        return;
    }

    event.preventDefault();

    const direction = event.deltaY < 0 ? 1 : -1;
    const factor = direction > 0 ? 1.1 : 0.9;

    scheduleZoom(visualScale * factor, event.clientX, event.clientY);
}, { passive: false });

document.addEventListener("copy", event => {
    const text = getCustomSelectedText();

    if (!text) {
        return;
    }

    event.preventDefault();
    event.clipboardData?.setData("text/plain", text);
});

document.addEventListener("keydown", event => {
    if (event.key === "Escape") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
        return;
    }

    if (event.ctrlKey && event.key.toLowerCase() === "h") {
        event.preventDefault();
        createHighlightFromSelection();
    }
});

boot();

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_000209

_Skipped binary or large file. Size: 817035 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00020a

_Skipped binary or large file. Size: 2161149 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/f_00020b

_Skipped binary or large file. Size: 307316 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/Cache_Data/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/No_Vary_Search/journal.baj

``text
$F~
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Cache/No_Vary_Search/snapshot.baf

_Skipped binary or large file. Size: 20 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ClientCertificates/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ClientCertificates/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ClientCertificates/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/js/30a228af677286e9_0

_Skipped binary or large file. Size: 202 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/js/8f7648d511e37c73_0

_Skipped binary or large file. Size: 205 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/js/9f8996b37dac4fdf_0

_Skipped binary or large file. Size: 212 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/js/index

_Skipped binary or large file. Size: 24 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/js/index-dir/the-real-index

_Skipped binary or large file. Size: 120 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/wasm/index

_Skipped binary or large file. Size: 24 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Code Cache/wasm/index-dir/the-real-index

_Skipped binary or large file. Size: 48 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/commerce_subscription_db/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/commerce_subscription_db/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/commerce_subscription_db/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DashTrackerDatabase

_Skipped binary or large file. Size: 10240 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DashTrackerDatabase-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnGraphiteCache/data_0

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnGraphiteCache/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnGraphiteCache/data_2

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnGraphiteCache/data_3

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnGraphiteCache/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnWebGPUCache/data_0

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnWebGPUCache/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnWebGPUCache/data_2

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnWebGPUCache/data_3

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DawnWebGPUCache/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/DIPS

_Skipped binary or large file. Size: 36864 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/discount_infos_db/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/discount_infos_db/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/discount_infos_db/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/discounts_db/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/discounts_db/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/discounts_db/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/EdgeJourneys/EdgeJourneys.db

_Skipped binary or large file. Size: 114688 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Rules/000003.log

_Skipped binary or large file. Size: 38 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Rules/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Rules/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Rules/LOG

``text
2026/05/22-16:54:19.383 b1b8 Creating DB C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension Rules since it was missing.
2026/05/22-16:54:19.418 b1b8 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension Rules/MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Rules/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Scripts/000003.log

_Skipped binary or large file. Size: 38 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Scripts/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Scripts/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Scripts/LOG

``text
2026/05/22-16:54:19.422 b1b8 Creating DB C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension Scripts since it was missing.
2026/05/22-16:54:19.438 b1b8 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension Scripts/MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension Scripts/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension State/000003.log

_Skipped binary or large file. Size: 114 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension State/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension State/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension State/LOG

``text
2026/05/28-11:22:23.881 8210 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension State/MANIFEST-000001
2026/05/28-11:22:23.882 8210 Recovering log #3
2026/05/28-11:22:23.883 8210 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension State/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension State/LOG.old

``text
2026/05/28-11:18:08.604 57fc Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension State/MANIFEST-000001
2026/05/28-11:18:08.605 57fc Recovering log #3
2026/05/28-11:18:08.605 57fc Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Extension State/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Extension State/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ExtensionActivityComp

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ExtensionActivityEdge

_Skipped binary or large file. Size: 32768 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ExtensionActivityEdge-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Favicons

_Skipped binary or large file. Size: 20480 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Favicons-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/favorites_diagnostic.log

``text
2026-05-22 09:54:19.376: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:02:43.837: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:05:20.161: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:07:38.263: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:12:03.365: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:13:24.202: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:18:02.340: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:28:57.736: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:30:01.963: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:37:37.050: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:40:04.925: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:43:49.129: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:48:18.396: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:51:04.250: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 10:51:38.074: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:03:46.158: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:06:13.165: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:08:17.744: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:12:12.323: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:17:43.590: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:27:18.652: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:30:44.537: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:32:59.009: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:36:57.034: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:46:38.809: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:49:33.765: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:51:25.302: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 11:54:21.670: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 12:00:40.918: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 12:08:43.326: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 12:13:11.175: [INFO] OnDoneLoading sync enabled: 0
2026-05-22 12:17:29.305: [INFO] OnDoneLoading sync enabled: 0
2026-05-26 13:21:40.290: [INFO] OnDoneLoading sync enabled: 0
2026-05-28 04:18:08.489: [INFO] OnDoneLoading sync enabled: 0
2026-05-28 04:22:23.754: [INFO] OnDoneLoading sync enabled: 0

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Feature Engagement Tracker/AvailabilityDB/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Feature Engagement Tracker/AvailabilityDB/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Feature Engagement Tracker/AvailabilityDB/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Feature Engagement Tracker/EventDB/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Feature Engagement Tracker/EventDB/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Feature Engagement Tracker/EventDB/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/GPUCache/data_0

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/GPUCache/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/GPUCache/data_2

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/GPUCache/data_3

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/GPUCache/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/heavy_ad_intervention_opt_out.db

_Skipped binary or large file. Size: 16384 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/heavy_ad_intervention_opt_out.db-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/History

_Skipped binary or large file. Size: 262144 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/History-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Local Storage/leveldb/000003.log

_Skipped binary or large file. Size: 239 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Local Storage/leveldb/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Local Storage/leveldb/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Local Storage/leveldb/LOG

``text
2026/05/28-11:22:23.903 2064 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Local Storage\leveldb/MANIFEST-000001
2026/05/28-11:22:23.918 2064 Recovering log #3
2026/05/28-11:22:23.922 2064 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Local Storage\leveldb/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Local Storage/leveldb/LOG.old

``text
2026/05/28-11:18:08.596 78b8 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Local Storage\leveldb/MANIFEST-000001
2026/05/28-11:18:08.605 78b8 Recovering log #3
2026/05/28-11:18:08.610 78b8 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Local Storage\leveldb/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Local Storage/leveldb/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Login Data

_Skipped binary or large file. Size: 43008 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Login Data For Account

_Skipped binary or large file. Size: 43008 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Login Data For Account-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Login Data-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network Action Predictor

_Skipped binary or large file. Size: 53248 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network Action Predictor-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Cookies

_Skipped binary or large file. Size: 20480 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Cookies-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Device Bound Sessions

_Skipped binary or large file. Size: 20480 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Device Bound Sessions-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Network Persistent State

``text
{"net":{"http_server_properties":{"servers":[],"version":5},"network_qualities":{"CAASABiAgICA+P////8B":"4G"}}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/NetworkDataMigrated

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Reporting and NEL

_Skipped binary or large file. Size: 36864 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Reporting and NEL-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/SCT Auditing Pending Reports

``text
[]
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Sdch Dictionaries

``text
{"SDCH":{"dictionaries":{},"version":2}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Trust Tokens

_Skipped binary or large file. Size: 36864 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Network/Trust Tokens-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/optimization_guide_hint_cache_store/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/optimization_guide_hint_cache_store/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/optimization_guide_hint_cache_store/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/parcel_tracking_db/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/parcel_tracking_db/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/parcel_tracking_db/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/PersistentOriginTrials/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/PersistentOriginTrials/LOG

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/PersistentOriginTrials/LOG.old

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Preferences

``text
{"aadc_info":{"age_group":0},"accessibility":{"captions":{"headless_caption_enabled":false}},"account_tracker_service_last_update":"13424415488490487","autocomplete":{"retention_policy_last_version":148},"autofill":{"edge_autofill_advanced_ml_enabled":true,"edge_autofill_purge_low_quality_profiles_by_timeline":false,"last_version_deduped":148},"bookmark":{"storage_computation_last_update":"13424415488489572"},"browser":{"available_dark_theme_options":"All","recent_theme_color_list":[4293914607.0,4293914607.0,4293914607.0,4293914607.0,4293914607.0],"show_downloads_hub_pinned":false,"show_toolbar_edge_generic_sidebar_button":false,"user_level_features_context":{}},"browser_content_container_height":867,"browser_content_container_width":1162,"browser_content_container_x":0,"browser_content_container_y":0,"commerce_daily_metrics_last_update_time":"13424415488491302","countryid_at_install":21843,"credentials_enable_service":false,"edge":{"bookmarks":{"last_dup_info_record_time":"13424415498499422"},"msa_sso_info":{"allow_for_non_msa_profile":true},"profile_sso_info":{"is_msa_first_profile":true,"msa_sso_algo_state":1},"services":{"signin_scoped_device_id":"c3a9ca8e-e8a9-4785-9cf0-7d4132b8f2b8"}},"edge_journeys":{"latest_journeys_count":0},"edge_rewards":{"cache_data":"CAA=","coachmark_promotions":{},"hva_promotions":[],"hva_webui_action_status_dict":{},"refresh_status_muted_until":"13424522059341636"},"edge_ux_config":{"assignmentcontext":"","dataversion":"0","experimentvariables":{},"flights":{}},"edge_vpn":{"available":true},"edge_wallet":{"passwords":{"password_lost_report_date":"13423918088208373"}},"enterprise_profile_guid":"0d7b3875-edac-46b5-a81b-10a968ff0596","extension":{"installed_extension_count":2},"extensions":{"alerts":{"initialized":true},"chrome_url_overrides":{},"last_chrome_version":"148.0.3967.83","pdf_upsell_triggered":false,"pinned_extension_migration":true,"pinned_extensions":[]},"fsd":{"retention_policy_last_version":148},"gaia_cookie":{"periodic_report_time_2":"13424415488462835"},"https_upgrade_navigations":{"2026-05-22":110},"in_product_help":{"recent_session_enabled_time":"13423917259403809","recent_session_start_times":["13424415488506183","13424275300304588","13423917259403809"],"session_last_active_time":"13424415743769264","session_number":4,"session_start_time":"13424415488506183"},"intl":{"selected_languages":"en-GB,en,en-US"},"language_dwell_time_average":{"en":13.531914893617024},"language_usage_count":{"en":47},"media":{"engagement":{"schema_version":5}},"muid":{"last_sync":"13424415488490318","values_seen":[]},"optimization_guide":{"hintsfetcher":{"hosts_successfully_fetched":{}},"previously_registered_optimization_types":{"ABOUT_THIS_SITE":true,"AUTOFILL_ACTOR_IFRAME_ORIGIN_ALLOWLIST":true,"GLIC_ACTION_PAGE_BLOCK":true,"HISTORY_CLUSTERS":true,"LOADING_PREDICTOR":true,"MERCHANT_TRUST_SIGNALS_V2":true,"PRICE_TRACKING":true,"SAVED_TAB_GROUP":true,"V8_COMPILE_HINTS":true}},"password_manager":{"account_store_backup_password_cleaning_last_timestamp":"13423918118197457","account_store_migrated_to_os_crypt_async":true,"profile_store_backup_password_cleaning_last_timestamp":"13423918118197751","profile_store_migrated_to_os_crypt_async":true},"personalization_data_consent":{"personalization_in_context_consent_can_prompt":true,"personalization_in_context_count":0},"privacy_sandbox":{"first_party_sets_data_access_allowed_initialized":true},"profile":{"avatar_index":20,"background_password_check":{"check_fri_weight":9,"check_interval":"2592000000000","check_mon_weight":6,"check_sat_weight":6,"check_sun_weight":6,"check_thu_weight":9,"check_tue_weight":9,"check_wed_weight":9,"next_check_time":"13425884397428538"},"content_settings":{"exceptions":{"3pcd_heuristics_grants":{},"abusive_notification_permissions":{},"access_to_get_all_screens_media_in_session":{},"anti_abuse":{},"app_banner":{},"ar":{},"are_suspicious_notifications_allowlisted_by_user":{},"auto_picture_in_picture":{},"auto_select_certificate":{},"automatic_downloads":{},"automatic_fullscreen":{},"autoplay":{},"background_sync":{},"bluetooth_chooser_data":{},"bluetooth_guard":{},"bluetooth_scanning":{},"camera_pan_tilt_zoom":{},"captured_surface_control":{},"clear_browsing_data_cookies_exceptions":{},"client_hints":{},"clipboard":{},"controlled_frame":{},"cookie_controls_metadata":{"http://127.0.0.1,*":{"last_modified":"13424415744417801","setting":{}}},"cookies":{},"direct_sockets":{},"direct_sockets_private_network_access":{},"display_media_system_audio":{},"disruptive_notification_permissions":{},"durable_storage":{},"edge_ad_targeting":{},"edge_ad_targeting_data":{},"edge_all_file_read_access":{},"edge_browser_action":{},"edge_sdsm":{},"edge_split_screen":{},"edge_tech_scam_detection":{},"edge_u2f_api_request":{},"edge_user_agent_token":{},"fedcm_idp_registration":{},"fedcm_idp_signin":{},"fedcm_share":{},"file_system_access_chooser_data":{},"file_system_access_extended_permission":{},"file_system_access_restore_permission":{},"file_system_last_picked_directory":{},"file_system_read_guard":{},"file_system_write_guard":{},"formfill_metadata":{},"geolocation":{},"geolocation_with_options":{},"hand_tracking":{},"has_migrated_local_network_access":true,"hid_chooser_data":{},"hid_guard":{},"http_allowed":{},"https_enforced":{},"idle_detection":{},"images":{},"important_site_info":{},"initialized_translations":{},"intent_picker_auto_display":{},"javascript":{},"javascript_jit":{},"javascript_optimizer":{},"keyboard_lock":{},"legacy_cookie_access":{},"legacy_cookie_scope":{},"local_fonts":{},"local_network":{},"local_network_access":{},"loopback_network":{},"media_engagement":{"http://127.0.0.1:51234,*":{"expiration":"13432191764720392","last_modified":"13424415764720397","lifetime":"7776000000000","setting":{"hasHighScore":false,"lastMediaPlaybackTime":0.0,"mediaPlaybacks":0,"visits":31}}},"media_stream_camera":{},"media_stream_mic":{},"midi_sysex":{},"mixed_script":{},"nfc_devices":{},"notification_interactions":{},"notification_permission_review":{},"notifications":{},"ondevice_languages_downloaded":{},"password_protection":{},"payment_handler":{},"permission_actions_history":{},"permission_autoblocking_data":{},"permission_autorevocation_data":{},"pointer_lock":{},"popups":{},"protected_media_identifier":{},"protocol_handler":{},"reduced_accept_language":{},"safe_browsing_url_check_data":{},"secure_network":{},"secure_network_sites":{},"sensors":{},"serial_chooser_data":{},"serial_guard":{},"site_engagement":{"http://127.0.0.1:51234,*":{"last_modified":"13424415744419733","setting":{"lastEngagementTime":1.3424415744419668e+16,"lastShortcutLaunchTime":0.0,"pointsAddedToday":7.5,"rawScore":27.580092608415}}},"sleeping_tabs":{},"sound":{},"speaker_selection":{},"ssl_cert_decisions":{},"storage_access":{},"storage_access_header_origin_trial":{},"subresource_filter":{},"subresource_filter_data":{},"suspicious_notification_ids":{},"suspicious_notification_show_original":{},"top_level_storage_access":{},"trackers":{},"trackers_data":{},"tracking_org_exceptions":{},"tracking_org_relationships":{},"typosquatting":{},"unused_site_permissions":{},"usb_chooser_data":{},"usb_guard":{},"vr":{},"web_app_installation":{},"webid_api":{},"webid_auto_reauthn":{},"window_placement":{}},"pref_version":1},"created_by_version":"148.0.3967.70","creation_time":"13423917259263863","default_content_setting_values":{"has_migrated_local_network_access":true},"edge_password_is_using_new_login_db_path":false,"edge_password_login_db_path_flip_flop_count":0,"edge_profile_id":"1f3a29ca-9824-4f73-9854-3b845cb78a5a","edge_user_with_non_zero_passwords":false,"exit_type":"Normal","has_seen_signin_fre":false,"is_relative_to_aad":false,"last_engagement_time":"13424415744419669","last_time_obsolete_http_credentials_removed":1779444518.197508,"last_time_password_store_metrics_reported":1779444488.208039,"managed_user_id":"","name":"Profile 1","network_pbs":{},"observed_session_time":{"feedback_rating_in_product_help_observed_session_time_key_148.0.3967.70":245.0},"password_hash_data_list":[],"signin_fre_seen_time":"13423917259293835","were_old_google_logins_removed":true},"reset_prepopulated_engines":false,"safety_hub":{"unused_site_permissions_revocation":{"migration_completed":true}},"saved_tab_groups":{"did_enable_shared_tab_groups_in_last_session":false,"specifics_to_data_migration":true},"sessions":{"event_log":[{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423924226512580","type":2,"window_count":0},{"crashed":false,"time":"13423924285279355","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423924306920898","type":2,"window_count":0},{"crashed":false,"time":"13423924461644966","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423924832292297","type":2,"window_count":0},{"crashed":false,"time":"13423924840895107","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423924873914322","type":2,"window_count":0},{"crashed":false,"time":"13423925323299979","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423925414186807","type":2,"window_count":0},{"crashed":false,"time":"13423925591152015","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423925685333046","type":2,"window_count":0},{"crashed":false,"time":"13423925849284013","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13423925859586450","type":2,"window_count":0},{"crashed":false,"time":"13424275300267200","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13424275321371882","type":2,"window_count":0},{"crashed":false,"time":"13424415488467149","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13424415509289113","type":2,"window_count":0},{"crashed":false,"time":"13424415743726675","type":0},{"did_schedule_command":false,"first_session_service":true,"tab_count":0,"time":"13424415764741333","type":2,"window_count":0}],"session_data_status":3},"signin":{"accounts_metadata_dict":{},"allowed":true},"spellcheck":{"dictionaries":["en-GB"]},"syncing_theme_prefs_migrated_to_non_syncing":true,"tab_search":{"pinned_to_tabstrip_migration_complete_2":true},"total_passwords_available_for_account":0,"total_passwords_available_for_profile":0,"translate_site_blacklist":[],"translate_site_blocklist_with_time":{},"typosquatting":{"allowlist_migration_done":true},"user_experience_metrics":{"personalization_data_consent_enabled_last_known_value":false},"webrtc":{"udp_port_range":"0-0"}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/README

``text
Microsoft Edge settings and storage represent user-selected preferences and information and MUST not be extracted, overwritten or modified except through Microsoft Edge defined APIs.
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Safe Browsing Network/NetworkDataMigrated

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Safe Browsing Network/Safe Browsing Cookies

_Skipped binary or large file. Size: 20480 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Safe Browsing Network/Safe Browsing Cookies-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Secure Preferences

``text
{"extensions":{"settings":{"dgiklkfkllikcanfonkcabmbdfmgleag":{"account_extension_type":0,"active_permissions":{"api":[],"explicit_host":[],"manifest_permissions":[],"scriptable_host":[]},"commands":{},"content_settings":[],"creation_flags":1,"disable_reasons":[],"events":[],"first_install_time":"13423917259364307","from_webstore":false,"incognito_content_settings":[],"incognito_preferences":{},"last_update_time":"13423917259364307","location":5,"manifest":{"content_capabilities":{"include_globs":["https://*excel.officeapps.live.com/*","https://*onenote.officeapps.live.com/*","https://*powerpoint.officeapps.live.com/*","https://*word-edit.officeapps.live.com/*","https://*excel.officeapps.live.com.mcas.ms/*","https://*onenote.officeapps.live.com.mcas.ms/*","https://*word-edit.officeapps.live.com.mcas.ms/*","https://*excel.partner.officewebapps.cn/*","https://*onenote.partner.officewebapps.cn/*","https://*powerpoint.partner.officewebapps.cn/*","https://*word-edit.partner.officewebapps.cn/*","https://*excel.gov.online.office365.us/*","https://*onenote.gov.online.office365.us/*","https://*powerpoint.gov.online.office365.us/*","https://*word-edit.gov.online.office365.us/*","https://*excel.dod.online.office365.us/*","https://*onenote.dod.online.office365.us/*","https://*powerpoint.dod.online.office365.us/*","https://*word-edit.dod.online.office365.us/*","https://*visio.partner.officewebapps.cn/*","https://*visio.gov.online.office365.us/*","https://*visio.dod.online.office365.us/*"],"matches":["https://*.officeapps.live.com/*","https://*.officeapps.live.com.mcas.ms/*","https://*.partner.officewebapps.cn/*","https://*.gov.online.office365.us/*","https://*.dod.online.office365.us/*","https://*.app.whiteboard.microsoft.com/*","https://*.whiteboard.office.com/*","https://*.app.int.whiteboard.microsoft.com/*","https://*.whiteboard.office365.us/*","https://*.dev.whiteboard.microsoft.com/*"],"permissions":["clipboardRead","clipboardWrite"]},"default_locale":"en","description":"This extension grants Microsoft web sites permission to read and write from the clipboard.","key":"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCz4t/X7GeuP6GBpjmxndrjtzF//4CWeHlC68rkoV7hP3h5Ka6eX7ZMNlYJkSjmB5iRmPHO5kR1y7rGY8JXnRPDQh/CQNLVA7OsKeV6w+UO+vx8KGI+TrTAhzH8YGcMIsxsUjxtC4cBmprja+xDr0zVp2EMgqHu+GBKgwSRHTkDuwIDAQAB","manifest_version":2,"minimum_chrome_version":"77","name":"Microsoft Clipboard Extension","version":"1.0"},"path":"C:\\Program Files (x86)\\Microsoft\\EdgeWebView\\Application\\148.0.3967.70\\resources\\edge_clipboard","preferences":{},"regular_only_preferences":{},"was_installed_by_default":false,"was_installed_by_oem":false},"mhjfbmdgcfjbbpaeojofohoefgiehjai":{"account_extension_type":0,"active_permissions":{"api":["contentSettings","fileSystem","fileSystem.write","metricsPrivate","tabs","resourcesPrivate","pdfViewerPrivate","fileSystem.readFullPath","errorReporting","edgeLearningToolsPrivate","fileSystem.getCurrentEntry","edgePdfPrivate","edgeCertVerifierPrivate"],"explicit_host":["edge://resources/*","edge://webui-test/*"],"manifest_permissions":[],"scriptable_host":[]},"commands":{},"content_settings":[],"creation_flags":1,"disable_reasons":[],"events":[],"first_install_time":"13423917259363390","from_webstore":false,"incognito_content_settings":[],"incognito_preferences":{},"last_update_time":"13423917259363390","location":5,"manifest":{"content_security_policy":"script-src 'self' 'wasm-eval' blob: filesystem: chrome://resources chrome://webui-test; object-src * blob: externalfile: file: filesystem: data:; trusted-types edge-internal fast-html pdf-url edge-pdf-static-policy;","description":"","incognito":"split","key":"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDN6hM0rsDYGbzQPQfOygqlRtQgKUXMfnSjhIBL7LnReAVBEd7ZmKtyN2qmSasMl4HZpMhVe2rPWVVwBDl6iyNE/Kok6E6v6V3vCLGsOpQAuuNVye/3QxzIldzG/jQAdWZiyXReRVapOhZtLjGfywCvlWq7Sl/e3sbc0vWybSDI2QIDAQAB","manifest_version":2,"mime_types":["application/pdf"],"mime_types_handler":"edge_pdf/index.html","name":"Microsoft Edge PDF Viewer","offline_enabled":true,"permissions":["errorReporting","chrome://resources/","chrome://webui-test/","contentSettings","metricsPrivate","edgeCertVerifierPrivate","edgeLearningToolsPrivate","edgePdfPrivate","pdfViewerPrivate","resourcesPrivate","tabs",{"fileSystem":["write","readFullPath","getCurrentEntry"]}],"version":"1","web_accessible_resources":["pdf_embedder.css"]},"path":"C:\\Program Files (x86)\\Microsoft\\EdgeWebView\\Application\\148.0.3967.70\\resources\\edge_pdf","preferences":{},"regular_only_preferences":{},"was_installed_by_default":false,"was_installed_by_oem":false}}},"protection":{"macs":{"browser":{"show_home_button":"C13BBB2F707DABFE5CC5EC15940101D8715A26A6F28EE469CD9E728A9BA67CCB","show_home_button_encrypted_hash":"djEwL34VnF+rfBSSpDWxey8aRY0bAslWHYmAhm5lbjGQVMOH1s2oJif8ZO1dvWxwTIQCQNuaswYVAOmVNFB5"},"default_search_provider_data":{"template_url_data":"3524B07BB50B4E6F72FF159025101E5EE1A4259A2B001D7D775BDB54928E8C93","template_url_data_encrypted_hash":"djEww7yfvyIT5dvPAaIKhCk7r2OjSPCNe5gRrJlsbbFuKAuPz68xIvg5Fwl7O81SdEf4p5X+3aSR1trCDft3"},"edge":{"services":{"account_id":"A4AE77CDA8078610D46E5DC5B32BB06594CFD2A75F32898D2841A5A3BB4873B5","account_id_encrypted_hash":"djEwDpR4E+UidRzAgdDw5uXRNWlSlXneqUjXl9vrH712fT3uavbOHLrbBsri1MWYWrEZ6FGr6GYagvClGgO3","last_username":"56D4640E1398238F77FB559BB9F980997C80114244E3727E0DF9525CE8AE0924","last_username_encrypted_hash":"djEwDLlA2F7q+CWTZyu/OwYB6Sk1U/0lV2gEtrIQW5rjJDKxpf15EXGTHessxCF1x0hl4UifjqCrr6u9rDPX"}},"enterprise_signin":{"policy_recovery_token":"61E52B0CBB767DA982377505E8183BAF14BD77C49CABCBCA7166014AD71B382F","policy_recovery_token_encrypted_hash":"djEwpySrwImeNGmSLl56Xfz6+zfkVfgQM5do80HyD03OEoSdVmr4oIMQRstw6z9tIDWFrUzEXpj/JeLqqZpW"},"extensions":{"install":{"initiallist":"290C77476BD8F38E291F229686ADA78F3581A119DC35FF4E7F548D552CC2401D","initiallist_encrypted_hash":"djEwaDjdh/7NrmYx+LCGVfI/eCIWXjGyWbaWr2zhk4iEkpgqT3dp59ziuuvx6ogC+rSj4c2DB3ptxS1ojr46","initialprovidername":"97FDFC2691C2CDBC36BD3F37CF2CF9756DDB9CE8EA3C74ACC98920F1BD20D00D","initialprovidername_encrypted_hash":"djEwJoV1+b/6kizAlxdZtbrvLxPWi9kl0+/pOnbdimktQBf11gb62ntgBNciNWEI4bCFTaWDf7Nyo+eeYFHJ"},"settings":{"dgiklkfkllikcanfonkcabmbdfmgleag":"4BC131CF823B197EC4A666D569F47609C4E330B3B8975CE97695A960E4C5C1BA","mhjfbmdgcfjbbpaeojofohoefgiehjai":"AA5DCF11C7965BA28F3FD8671DB6168C6A7DC3B80F95AEC48BC67B93DB25996C"},"settings_encrypted_hash":{"dgiklkfkllikcanfonkcabmbdfmgleag":"djEwASwKcge+fZ4SrNv4wYYZA5C/nB0DAiRaSEuKy/cpASLQBT1gZVjPfshGQfW6k1Yr8PwxsTxTsdaf4fFd","mhjfbmdgcfjbbpaeojofohoefgiehjai":"djEw5a+Sy8Knip4V268XBb3vU0Rwhu5BjXEdSQ8BL0Gvmbw4FCs8mxPYdIOyvam47GY4V/uijIJ9xSfjgMS1"},"ui":{"developer_mode":"F6698843002646426AEF5065CAFEFC723EA3DF5AE4A6C2BA21754E44EC6EC5AF","developer_mode_encrypted_hash":"djEw/84Vp0RgpCGxCtXtljtZ5wk51EIagj8BBwbTqZHZ3DTTN199CwTQ2VF8zWvqDO2T2Un0oTtFHcRYTXAr"}},"google":{"services":{"last_signed_in_username":"60559191474E048FFE73B04A126100F7CFB6EE6DB2B52A7085874A360C116859","last_signed_in_username_encrypted_hash":"djEwCgyMa1ec+2kp4bf2na+OsSZTqwLV63Xt5u8D8C4ITlp+qqWJiDlZP7N1Qo4eRtL8fpXKTvxnACjZ7jsU"}},"homepage":"5D2EFA4DC3FD3B8C3F92D29CBF70DF2D073CA8AD72EE744C4B6A3D1D27FB9D04","homepage_encrypted_hash":"djEwDfVbYSbXEsTi26MIL/XFQSg39dTRzbcPv0VH9UYFmxekUeKDMFBmY9UKchjq6gczxwDglf2Yn/3VVKR+","homepage_is_newtabpage":"97ECCA2984DC8B86A6D9A09B0A00710C3C22B307E20001265C325C339A1D1FAD","homepage_is_newtabpage_encrypted_hash":"djEwYMx6zt/eMUuBWj28RxDYTM1SBeUEI+jcpxPlWNNzwfBT5H28gG2wlMLedvmhmKaQVsFaHxhxfA9DSwpY","media":{"cdm":{"origin_data":"144087F8949F6959596666C12849CE20BFF6071B64E2E5D2D823C8B6507451C2","origin_data_encrypted_hash":"djEwuDhDKpFEGV/CUU6Fl9hFSSD1ssEGhAqPongnod3II8escENn8Uy5qnsFZMhveRAF1NZ67ebw9zA533I6"},"storage_id_salt":"91585521830AC6ED0E3A60B32B4EAD5933D165E8C5706A198ED2D14E62EAED09","storage_id_salt_encrypted_hash":"djEwMSiVLoANffXaZj5i/K7r8Ljma460MQUpYVtZZxfYtQ2vneBRO5/ryk7F81eryQjwMdMuHjIgqh05awWt"},"pinned_tabs":"F38F73CE0A47DFAC280D5637F9E19DFFC1E18AD9219FB4452C5FDF8866F542AB","pinned_tabs_encrypted_hash":"djEwTVjc1PNoC+i62zYFK/zWNR3seFwPAIE+JOKGjQiS7JguRsyAZEP9SRu8x1p+5iVJiV28MJj94wxrFUtC","prefs":{"preference_reset_time":"33E373BEE74421296BD7F2018F76D7DAE63275AF3681DCFECE62931BE2E10BEF","preference_reset_time_encrypted_hash":"djEwx4QFXkE09vrO72+9ZjIyBghmcgI93A/AJkMSZ8k+LD+FH/RIlVyKUJrOLJ4UwBwpzsDY4538Vih2XqHg"},"safebrowsing":{"incidents_sent":"9F1F4AD8069998611AF42A83C03C22DB089F7338DCC7AA9FEB7F77167C361FFE","incidents_sent_encrypted_hash":"djEwesGQ6W1kxjDjpEAygang5dNKyL5zOhjlGABK3b9xJC8XUNRZ9bgEZE2kXeTmzzrlmsJRwDz1OBUpYcC4"},"schedule_to_flush_to_disk":"145597B240EFEAFDD1F70FDD6EA4F58883A83A628116129CB622810A5EB5E633","schedule_to_flush_to_disk_encrypted_hash":"djEwq5DHM1SCsOPCVy4wI1Hp//b6kMrI7TonHGI4qtbBfymGRjVRJcc192P0m5Ecxy29P8qmHYZ+NCXuRvOn","search_provider_overrides":"38DF6E2CFE163C0A278471A4513A7A8F90FF896D14E11147E7DF9BA0CD6CBBCC","search_provider_overrides_encrypted_hash":"djEwodik00ZdVuOJSAFndwbKrOuGrG1SR9fR/77XJAif46EXWkGJywW4N+NarPByCrnF3gO8DCtOv1CJHkjA","session":{"restore_on_startup":"D28C3C8D7707C4755AD9D5A4983F07A99A6C7D12199867BD7C4F7AD1E48D2C79","restore_on_startup_encrypted_hash":"djEwFLvtvbLf+/QJRm6Nglxao4LDhcmcBK5YwJZiu+TgqMKTGOiU6KwKkdh1IY3ML+5YtpWPxD4SMf+5G8Hv","startup_urls":"519885DAC9D309E60968FC35EED33D4A03DD43E1AD44D7B98E740A95771AA7FA","startup_urls_encrypted_hash":"djEwtUsZOYvEZQ5dZZbZlBR9toXEeS2gV1NpuhkvFxr26Glu28Xa5AaRgoxz0ta9rJbLFzUF9duRCt0+97XM"}},"super_mac":"4BDA7F25ABEDFB5B80F0FCAB9E0B1B228BF93489041B8A852CC4724D87A5774F"},"schedule_to_flush_to_disk":"13424415743753701"}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ServerCertificate

_Skipped binary or large file. Size: 20480 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/ServerCertificate-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Session Storage/000003.log

_Skipped binary or large file. Size: 6318 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Session Storage/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Session Storage/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Session Storage/LOG

``text
2026/05/28-11:22:24.429 2064 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Session Storage/MANIFEST-000001
2026/05/28-11:22:24.431 2064 Recovering log #3
2026/05/28-11:22:24.435 2064 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Session Storage/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Session Storage/LOG.old

``text
2026/05/28-11:18:09.265 78b8 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Session Storage/MANIFEST-000001
2026/05/28-11:18:09.267 78b8 Recovering log #3
2026/05/28-11:18:09.271 78b8 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Session Storage/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Session Storage/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Shared Dictionary/cache/index

_Skipped binary or large file. Size: 24 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Shared Dictionary/cache/index-dir/the-real-index

_Skipped binary or large file. Size: 48 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Shared Dictionary/db

_Skipped binary or large file. Size: 45056 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Shared Dictionary/db-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/000003.log

_Skipped binary or large file. Size: 6380 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/LOG

``text
2026/05/28-11:22:23.771 8880 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db/MANIFEST-000001
2026/05/28-11:22:23.772 8880 Recovering log #3
2026/05/28-11:22:23.773 8880 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/LOG.old

``text
2026/05/28-11:18:08.517 60b4 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db/MANIFEST-000001
2026/05/28-11:18:08.517 60b4 Recovering log #3
2026/05/28-11:18:08.518 60b4 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/metadata/000003.log

_Skipped binary or large file. Size: 1974 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/metadata/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/metadata/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/metadata/LOG

``text
2026/05/28-11:22:23.763 8880 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db\metadata/MANIFEST-000001
2026/05/28-11:22:23.764 8880 Recovering log #3
2026/05/28-11:22:23.764 8880 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db\metadata/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/metadata/LOG.old

``text
2026/05/28-11:18:08.507 60b4 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db\metadata/MANIFEST-000001
2026/05/28-11:18:08.508 60b4 Recovering log #3
2026/05/28-11:18:08.508 60b4 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\shared_proto_db\metadata/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/shared_proto_db/metadata/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/SharedStorage

_Skipped binary or large file. Size: 4096 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Site Characteristics Database/000003.log

_Skipped binary or large file. Size: 2272 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Site Characteristics Database/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Site Characteristics Database/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Site Characteristics Database/LOG

``text
2026/05/28-11:22:23.754 4dcc Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Site Characteristics Database/MANIFEST-000001
2026/05/28-11:22:23.755 4dcc Recovering log #3
2026/05/28-11:22:23.756 4dcc Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Site Characteristics Database/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Site Characteristics Database/LOG.old

``text
2026/05/28-11:18:08.468 85b0 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Site Characteristics Database/MANIFEST-000001
2026/05/28-11:18:08.471 85b0 Recovering log #3
2026/05/28-11:18:08.472 85b0 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Site Characteristics Database/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Site Characteristics Database/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Sync Data/LevelDB/000003.log

_Skipped binary or large file. Size: 65 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Sync Data/LevelDB/CURRENT

``text
MANIFEST-000001

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Sync Data/LevelDB/LOCK

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Sync Data/LevelDB/LOG

``text
2026/05/28-11:22:23.738 7e84 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Sync Data\LevelDB/MANIFEST-000001
2026/05/28-11:22:23.741 7e84 Recovering log #3
2026/05/28-11:22:23.742 7e84 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Sync Data\LevelDB/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Sync Data/LevelDB/LOG.old

``text
2026/05/28-11:18:08.469 be4 Reusing MANIFEST C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Sync Data\LevelDB/MANIFEST-000001
2026/05/28-11:18:08.472 be4 Recovering log #3
2026/05/28-11:18:08.472 be4 Reusing old log C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe.WebView2\EBWebView\Default\Sync Data\LevelDB/000003.log 

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Sync Data/LevelDB/MANIFEST-000001

_Skipped binary or large file. Size: 41 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Top Sites

_Skipped binary or large file. Size: 20480 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Top Sites-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Vpn Tokens

_Skipped binary or large file. Size: 28672 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Vpn Tokens-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Web Data

_Skipped binary or large file. Size: 227328 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Default/Web Data-journal

``text

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/extensions_crx_cache/metadata.json

``json
{"hashes":{}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GraphiteDawnCache/data_0

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GraphiteDawnCache/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GraphiteDawnCache/data_2

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GraphiteDawnCache/data_3

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GraphiteDawnCache/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/data_0

_Skipped binary or large file. Size: 45056 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/data_2

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/data_3

_Skipped binary or large file. Size: 4202496 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000001

_Skipped binary or large file. Size: 19268 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000002

_Skipped binary or large file. Size: 16572 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000003

_Skipped binary or large file. Size: 20652 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000004

_Skipped binary or large file. Size: 19284 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000005

_Skipped binary or large file. Size: 22408 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000006

_Skipped binary or large file. Size: 22836 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000007

_Skipped binary or large file. Size: 19736 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000008

_Skipped binary or large file. Size: 16572 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/f_000009

_Skipped binary or large file. Size: 19268 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/GrShaderCache/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/_metadata/verified_contents.json

``json
[{"description":"treehash per file","signed_content":{"payload":"eyJjb250ZW50X2hhc2hlcyI6W3siYmxvY2tfc2l6ZSI6NDA5NiwiZGlnZXN0Ijoic2hhMjU2IiwiZmlsZXMiOlt7InBhdGgiOiJoeXBoLWFmLmh5YiIsInJvb3RfaGFzaCI6ImU3S1ZpWjlhODYwT3ZfdHR1dTRDME9JODlGQUNkcjR0Z01lOGhnNU1xVUkifSx7InBhdGgiOiJoeXBoLWFzLmh5YiIsInJvb3RfaGFzaCI6InduaE9NeFdLZ0hFMWhROXhKYWZxcS1SeXM4X0hyN2dzZFBBdHBwNmlVUDQifSx7InBhdGgiOiJoeXBoLWJlLmh5YiIsInJvb3RfaGFzaCI6IlpLdnllRTdIQmlLMktnYjBwRUUzVnotRmZ4RlJoQVNQcUJHeXlCbGtkaDAifSx7InBhdGgiOiJoeXBoLWJnLmh5YiIsInJvb3RfaGFzaCI6ImRaUHdPVkNCNC02eTJGRnRFSFJtQ0tfWUpzXzlUbjQzMVRrMm1UMGdDaE0ifSx7InBhdGgiOiJoeXBoLWJuLmh5YiIsInJvb3RfaGFzaCI6InduaE9NeFdLZ0hFMWhROXhKYWZxcS1SeXM4X0hyN2dzZFBBdHBwNmlVUDQifSx7InBhdGgiOiJoeXBoLWNzLmh5YiIsInJvb3RfaGFzaCI6IklnUndJWmZEOFctRjdYbExMMHJ4TTdkYTVRc3FVQlVwS2F5SkdodlVfRXcifSx7InBhdGgiOiJoeXBoLWN1Lmh5YiIsInJvb3RfaGFzaCI6ImFiWlhPbWx5T0dnSEplVWlHMkhaQURadHA3dlM2QnI3RGh3TUF0eWV4N2sifSx7InBhdGgiOiJoeXBoLWN5Lmh5YiIsInJvb3RfaGFzaCI6Ims5Y1JTUUhCNDNiNlVNaHN6cE5nN3k2cGliTVZGOFJnQjk3MmpQVGNvYkEifSx7InBhdGgiOiJoeXBoLWRhLmh5YiIsInJvb3RfaGFzaCI6IlRMZk92MjdUTFFpSDdWaFNIbDlCblQydDlKSkl1WEpDMWlFWUxRS251bGcifSx7InBhdGgiOiJoeXBoLWRlLTE5MDEuaHliIiwicm9vdF9oYXNoIjoiMHlHekNnc2tpTGI1STJoTC0yc1FCVmJMXzNCekE4VFNwSUZ6aDltd1ZsYyJ9LHsicGF0aCI6Imh5cGgtZGUtMTk5Ni5oeWIiLCJyb290X2hhc2giOiJIMGVZZHhlbDNyZU15UHRqVEt2QUI4RWFzaEFTbGpMUmhZOU83c0ljUFVRIn0seyJwYXRoIjoiaHlwaC1kZS1jaC0xOTAxLmh5YiIsInJvb3RfaGFzaCI6InpMQVlIVGVvc3IwdlBrcTc2VjdJM083b0V1cUI5M3NtSmxqNThibjZuYWMifSx7InBhdGgiOiJoeXBoLWVsLmh5YiIsInJvb3RfaGFzaCI6IjFOazV4S1JiR1ZYVElCUkVIbjB2SFJzU1VNTjZfdDAzdTVtRkwzMEtNN3MifSx7InBhdGgiOiJoeXBoLWVuLWdiLmh5YiIsInJvb3RfaGFzaCI6IlZvR2ZOaHpnajBOQ29qelhscjBQdjFSdnpFTEZJVFJ3MURRTWRUMXZiT0kifSx7InBhdGgiOiJoeXBoLWVuLXVzLmh5YiIsInJvb3RfaGFzaCI6Il94OUFGM2dFMzBLelE0bHFRU1BqLWZXWnl0bnNqLURWQVgzdDRqZEVUVXMifSx7InBhdGgiOiJoeXBoLWVzLmh5YiIsInJvb3RfaGFzaCI6IjBmdWc0YWVadDc0Z19XbEVyNUtsY1JHWkVkMzJXZFEtWFptSkxZX2xuRWsifSx7InBhdGgiOiJoeXBoLWV0Lmh5YiIsInJvb3RfaGFzaCI6ImxkUFIwUm14R3EyZ3EzNFF1Ylp6LXRlRGtvWFFibmg4VjM2bjIyRkNxY0EifSx7InBhdGgiOiJoeXBoLWV1Lmh5YiIsInJvb3RfaGFzaCI6IjRuZUtUOGU0OEdTaksycEV2Q254RGlaTm5XSVV1TzI0NjlIMTl0YU9MckkifSx7InBhdGgiOiJoeXBoLWZyLmh5YiIsInJvb3RfaGFzaCI6IjFudGF1Nm9FVUtQbWV2SFJKSkwydEc5c1FYQmxOcHFSZFJxYlZpMnJZeDAifSx7InBhdGgiOiJoeXBoLWdhLmh5YiIsInJvb3RfaGFzaCI6ImxGLVlGb3VwcUItempfM1ZadFc0aEw4Uk51Ql9YREpna0p2N1VMMFJFc1kifSx7InBhdGgiOiJoeXBoLWdsLmh5YiIsInJvb3RfaGFzaCI6IlJBU1hfb0MxVzFDUmtOYURETC0xZVoxYnYyS0c0Y2hfWE1jUEU4cXRpY1kifSx7InBhdGgiOiJoeXBoLWd1Lmh5YiIsInJvb3RfaGFzaCI6InJ3N2JaOElobTRBOFByYkIzdWJ5MUJvXzRBUm9xZHFMNk85UVZ0Y0JxX00ifSx7InBhdGgiOiJoeXBoLWhpLmh5YiIsInJvb3RfaGFzaCI6IjlOOGlUVVdmMFJGcGpkV2hOaFBGdV9EdEVmQkNlTllDTU5Bb0FRNnNERUkifSx7InBhdGgiOiJoeXBoLWhyLmh5YiIsInJvb3RfaGFzaCI6IjFmQm1wV1ZfSFh3NTBGT1ZiZklFdDVKdlFOTC1UMmxYT3ZDZGtKQm00bXcifSx7InBhdGgiOiJoeXBoLWh1Lmh5YiIsInJvb3RfaGFzaCI6InExWmRIaTR3VElWbFFiSHhVdW5NVEJaaEMya29JWTg1d3pUTnE0aUhTVlEifSx7InBhdGgiOiJoeXBoLWh5Lmh5YiIsInJvb3RfaGFzaCI6Im16VGZ5b1hMSjFSb0tmRUU4VGQxZnZzblNUVEI2ZFNaSDFXdFZrbGlwMm8ifSx7InBhdGgiOiJoeXBoLWl0Lmh5YiIsInJvb3RfaGFzaCI6Ii1jQW4xXzFFc0J6VjRjMzRBdUlNWTFZR2N3bUs4WXZxQ1RDNm12TTA0UGMifSx7InBhdGgiOiJoeXBoLWthLmh5YiIsInJvb3RfaGFzaCI6IlZoTFVGQnBOSDg5RDU2WXVPRmx4dnRqTTBJcjZfVTRLMUJacXB6NzVmaTAifSx7InBhdGgiOiJoeXBoLWtuLmh5YiIsInJvb3RfaGFzaCI6Iks1bWRDaFV2Z0VZQnFvODRfdzA2YmxsSmwzdngycWR2cUlpc3JpRlNZb2MifSx7InBhdGgiOiJoeXBoLWxhLmh5YiIsInJvb3RfaGFzaCI6Il9VdHZOaE5jMDdreTQxRHNJQmZmMkowdU5xd2liMVRreVBMa3ZHMndXVDAifSx7InBhdGgiOiJoeXBoLWx0Lmh5YiIsInJvb3RfaGFzaCI6Il9pbnpod2o5ZEtMZ3NOeDdVOHV1TGE4WVlXZUFnZVZQb2pVVUJ2eVZPUkUifSx7InBhdGgiOiJoeXBoLWx2Lmh5YiIsInJvb3RfaGFzaCI6Imtkc0Ytd1FuNHpQQzNySW83ekw0UUZLNlJ4NkNZVjZmVkhzd3dBM0tDV2MifSx7InBhdGgiOiJoeXBoLW1sLmh5YiIsInJvb3RfaGFzaCI6ImtGY3R1UFNiQWV4cUVDY3l6ZkZQd19COU5qeS1EU1lSQS1XREJERms2SWcifSx7InBhdGgiOiJoeXBoLW1uLWN5cmwuaHliIiwicm9vdF9oYXNoIjoiMm5yb3g2UFNHU19XQ1FZWUk3SnZ0cWwxMlhjUHVTd3UxMk1aS2VMT1QzayJ9LHsicGF0aCI6Imh5cGgtbXIuaHliIiwicm9vdF9oYXNoIjoiOU44aVRVV2YwUkZwamRXaE5oUEZ1X0R0RWZCQ2VOWUNNTkFvQVE2c0RFSSJ9LHsicGF0aCI6Imh5cGgtbXVsLWV0aGkuaHliIiwicm9vdF9oYXNoIjoiOHZyQnZRYWZfbHpSRVMyVXpERVRmdE9LR3hZUWstelhUSndXaUVLTGFJcyJ9LHsicGF0aCI6Imh5cGgtbmIuaHliIiwicm9vdF9oYXNoIjoidW1oN2VNX0ptaVRpdVdjeUNSU2Y0eGVnT085aDZaczZxcl9XeHdtQk9IdyJ9LHsicGF0aCI6Imh5cGgtbmwuaHliIiwicm9vdF9oYXNoIjoiMWNMSjEtZ0J3UkhNMDlhVExINVZZOWpXeGY2cUpqYjgydFdSX0tsRlg5ZyJ9LHsicGF0aCI6Imh5cGgtbm4uaHliIiwicm9vdF9oYXNoIjoiVVRNblpKaGR0LW51UGEwSGRBMmpqeE9yUU9CMTZ4UVk3ZFo1b2dKeVB2MCJ9LHsicGF0aCI6Imh5cGgtb3IuaHliIiwicm9vdF9oYXNoIjoiVHB6VEFycl94T28tbGxJeWZxSkFjdXZ6ZTF4UHdIR1NrcjJzRUtxdFpscyJ9LHsicGF0aCI6Imh5cGgtcGEuaHliIiwicm9vdF9oYXNoIjoiUndNcDBvLXFTRS1VWFhqXzc3RjIzTGJ5QXl4MVBpVzhBVUVHclNTeXhvbyJ9LHsicGF0aCI6Imh5cGgtcHQuaHliIiwicm9vdF9oYXNoIjoiOXZ2eHZMSmd6SVlsYjhTVTg0ajNzbjBRaGwtX2oyRlJmZTRscjAxWTF1ZyJ9LHsicGF0aCI6Imh5cGgtcnUuaHliIiwicm9vdF9oYXNoIjoicXN2dk9SNU5oUWlrYV8zVXU5N3QwQ0tWU2o2RFhPSVFFMVVXbWRmR1VRdyJ9LHsicGF0aCI6Imh5cGgtc2suaHliIiwicm9vdF9oYXNoIjoiN2Z4MDBSMHQtYjVscVVlX3hGNy1pVThuNkZUTzJrVjNmYy1odGdEQVZlYyJ9LHsicGF0aCI6Imh5cGgtc2wuaHliIiwicm9vdF9oYXNoIjoiT1hDWTBsMS0wYzZ2eVk4YmpURTBObEJBSnlvUVl5YmFfOVp0WVN0UF83byJ9LHsicGF0aCI6Imh5cGgtc3EuaHliIiwicm9vdF9oYXNoIjoidkNuSlFCenBVa0ZNdXV2RnlPNGRKOEZ3Ykc5M2dIdGY5eFBpRWtRNHM4byJ9LHsicGF0aCI6Imh5cGgtc3YuaHliIiwicm9vdF9oYXNoIjoiR1hhQU9rUmRyWE5ac1FLbHBKX3lCd1doZUNpRzhjZFNzREZ4OWc3MnJwOCJ9LHsicGF0aCI6Imh5cGgtdGEuaHliIiwicm9vdF9oYXNoIjoiUVAycFNGYW9id1pkNkxxbUdFNm1QYzJ3RWU1TXBKaW53ZjdrVEpreFRHYyJ9LHsicGF0aCI6Imh5cGgtdGUuaHliIiwicm9vdF9oYXNoIjoiVVctcFpVLWpycXEwZ05RT3IyclhqOEE1Q0d2WTdjRkV2ajFaVWw3Y3JDayJ9LHsicGF0aCI6Imh5cGgtdGsuaHliIiwicm9vdF9oYXNoIjoiZF8ydTBwdllRcXFwZHF0LS1CdGhlaFhBb3RIcjBSWWNHX0pyZWFFSXRjMCJ9LHsicGF0aCI6Imh5cGgtdWsuaHliIiwicm9vdF9oYXNoIjoieWxjVXUzT05ZS3N1LW9pS3R5VWNSak1PQnhwZzBMdjdMNENvZHpsUW5zayJ9LHsicGF0aCI6Imh5cGgtdW5kLWV0aGkuaHliIiwicm9vdF9oYXNoIjoiSGVnOHQ0ZmZyMVA3Zm02TnM2cmxBSXJTVHIzU2ktQWdNVEJ1cWVuejRvVSJ9LHsicGF0aCI6Im1hbmlmZXN0Lmpzb24iLCJyb290X2hhc2giOiIxWEh2TTdEbkIxY2ZFTHMzdVpwZ2ZXOURyLU1fVTlGYlE1V3hidlA5cG1VIn1dLCJmb3JtYXQiOiJ0cmVlaGFzaCIsImhhc2hfYmxvY2tfc2l6ZSI6NDA5Nn1dLCJpdGVtX2lkIjoiamFtaGNubmtpaGlubWRsa2Fra2FvcGJqYmJjbmdmbGMiLCJpdGVtX3ZlcnNpb24iOiIxMjAuMC42MDUwLjAiLCJwcm90b2NvbF92ZXJzaW9uIjoxfQ","signatures":[{"header":{"kid":"publisher"},"protected":"eyJhbGciOiJSUzI1NiJ9","signature":"ud33uh3_3o_eTIMSj_MKboC9-GzBxQ-Bu6XS31wn7JB3ntcoVSUfAgMjTBCsIYEEgqVfKJlf92wgl3SbjJWaT-_XfV8sMFwZtuAT0qJV0p9gammnprPP0OmUwJdJB-kK1MO8ESwSyeGKCEeIXGDqAVdQHkYD-oKzYS-zKhe9KVnU-WtJ6mtG80ybhjxJDM1aLyS6_ocXKYBmcB9av0IY-saDVR7hkVNjc-iR9lhYI1682VbDmlQ9-uueCkK4YsqmO1mOSgYcQ-Hm56zQxhGrMHbGokIX667-8yHRbxjoag7eNxHrY5VQI-te17pDKE9G9cz87qvGSMPUi9QGdyt7a1652KWPXe6bDEOjIoaHUq9juOd7r8SxYCv8tqhAx5nxhqkaq9oHSfiYrrcddaSdtdCOYo7hyqVQV1562x0NZiNrGH9sU5V-e_5DAmPVqBMA1yjY3ZQEWWyTdQ_Wtw5qbs3m5qh5Grut8RtIb7yGJJsamDN3LG73jcrtXZ1cMynqN3LysksG8Y73RfO3joVhy3gw5Y1X6ES1gvQi4n1hxvOCCXoGIbIJwIZGjTlcuh2J_eweLo0hm1IeXK_lAB9P1RiruKfEc0P75CY4V_LDziEdFHxIpFS6PjH94n1aAj0F3ba6opqyjgXs6n8uuhoJvdq5GwnAuwsOzs771p8mWl0"},{"header":{"kid":"webstore"},"protected":"eyJhbGciOiJSUzI1NiJ9","signature":"fLFplPrKe8OWo-G7YhCQxsnj2MHPUqYvWL9ACSCD1WuA4K5c0pOFNMZ10w0Po0lgprE7LTCjWTk3pKKvyTxojWAyAg-c75DU2kfnntDabBEn9ooCiBcWJIuOkJMdcLYBbfe-t-JO0KPKm-2mGi59MkO9xir2MMwAqtITGdrH4WXjHTIB6guYQMtre_Bp_zqvZnGQKqZI0Cdq8QVqd7z69_j63fvv0CjXuZ-6F1RNElS75H3FzJ1OrVMCOjEOaKyk1DD-aqgr-6lUq2er1XWrf9JxtAmAawpnh3RAEi_1VoGtbga92USt_0ZLiapoC4PlWSloLuX-_NYFg9gtPJNS9w"}]}}]
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-af.hyb

_Skipped binary or large file. Size: 72640 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-as.hyb

_Skipped binary or large file. Size: 703 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-be.hyb

_Skipped binary or large file. Size: 6098 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-bg.hyb

_Skipped binary or large file. Size: 3467 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-bn.hyb

_Skipped binary or large file. Size: 703 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-cs.hyb

_Skipped binary or large file. Size: 64245 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-cu.hyb

_Skipped binary or large file. Size: 52842 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-cy.hyb

_Skipped binary or large file. Size: 35913 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-da.hyb

_Skipped binary or large file. Size: 6967 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-de-1901.hyb

_Skipped binary or large file. Size: 121393 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-de-1996.hyb

_Skipped binary or large file. Size: 120412 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-de-ch-1901.hyb

_Skipped binary or large file. Size: 120218 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-el.hyb

_Skipped binary or large file. Size: 4219 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-en-gb.hyb

_Skipped binary or large file. Size: 46607 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-en-us.hyb

_Skipped binary or large file. Size: 59802 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-es.hyb

_Skipped binary or large file. Size: 14995 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-et.hyb

_Skipped binary or large file. Size: 21421 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-eu.hyb

_Skipped binary or large file. Size: 665 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-fr.hyb

_Skipped binary or large file. Size: 8165 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-ga.hyb

_Skipped binary or large file. Size: 35824 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-gl.hyb

_Skipped binary or large file. Size: 9289 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-gu.hyb

_Skipped binary or large file. Size: 655 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-hi.hyb

_Skipped binary or large file. Size: 687 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-hr.hyb

_Skipped binary or large file. Size: 3031 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-hu.hyb

_Skipped binary or large file. Size: 317251 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-hy.hyb

_Skipped binary or large file. Size: 605 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-it.hyb

_Skipped binary or large file. Size: 2512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-ka.hyb

_Skipped binary or large file. Size: 9996 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-kn.hyb

_Skipped binary or large file. Size: 711 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-la.hyb

_Skipped binary or large file. Size: 1839 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-lt.hyb

_Skipped binary or large file. Size: 7774 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-lv.hyb

_Skipped binary or large file. Size: 38602 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-ml.hyb

_Skipped binary or large file. Size: 776 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-mn-cyrl.hyb

_Skipped binary or large file. Size: 5142 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-mr.hyb

_Skipped binary or large file. Size: 687 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-mul-ethi.hyb

_Skipped binary or large file. Size: 3740 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-nb.hyb

_Skipped binary or large file. Size: 145263 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-nl.hyb

_Skipped binary or large file. Size: 77080 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-nn.hyb

_Skipped binary or large file. Size: 145263 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-or.hyb

_Skipped binary or large file. Size: 647 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-pa.hyb

_Skipped binary or large file. Size: 607 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-pt.hyb

_Skipped binary or large file. Size: 1414 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-ru.hyb

_Skipped binary or large file. Size: 19886 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-sk.hyb

_Skipped binary or large file. Size: 64103 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-sl.hyb

_Skipped binary or large file. Size: 6631 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-sq.hyb

_Skipped binary or large file. Size: 2013 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-sv.hyb

_Skipped binary or large file. Size: 72119 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-ta.hyb

_Skipped binary or large file. Size: 554 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-te.hyb

_Skipped binary or large file. Size: 703 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-tk.hyb

_Skipped binary or large file. Size: 2712 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-uk.hyb

_Skipped binary or large file. Size: 19417 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/hyph-und-ethi.hyb

_Skipped binary or large file. Size: 3484 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/hyphen-data/120.0.6050.0/manifest.json

``json
{
  "manifest_version": 2,
  "name": "hyphens-data",
  "version": "120.0.6050.0"
}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Last Version

``text
148.0.3967.83
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Local State

``text
{"accessibility":{"captions":{"common_models_path":"","soda_translation_binary_path":""}},"autofill":{"ablation_seed":"bUtjrxmr0SY="},"breadcrumbs":{"enabled":true,"enabled_time":"13423917259259365"},"default_browser":{"browser_name_enum":1},"desktop_session_duration_tracker":{"last_session_end_timestamp":"1779452007"},"domain_actions_config":"H4sIAAAAAAAAAL2abW/bOBKA/0pg3Id2UStpu9fe5VAURa+HLrDFFr0u9oDNnjEix9LUJIchKUvKtv/9QL+kdi0polLchyQ2w2eGL6PhzFB/zoTUC16jcyRxdvnnDKxVJCAQGz+7/H3XgHJhWZFoZ5ezX4xq3zSWPb5X0H5AkO3s0UyyBjKzy5lXZIpMsJ59eTRI/0YS12TwEA5cZWE9hdTQSNaYSZxCQy4mD3mdRQKn8gqeZxSmkM2SDIV2quIagijDOhPcTBVBhaGAYZ05LtD5qWJyVaGo3DpK8iXUmYApYkpU1GRrksjBsZk6GuEooCM2ogRjUE2VYwKEMprk1P3h2jr0aIK3qpq8uOuymfhIlZWqpmoFa7PrisSqRGWnCvkn+fKVaesS3W4V/3g027CEW+dkQGOvSwqtjf+MTW7TFIdwQhwo3gG3LVHdGp0nNrPLx18ezQRLFInu8i1JfLd8i2vxOtJprmMANmQCGsmDC3PK7+Z42NgxTR1XZkFGkcHU48GGX6rwrS0UDrQGp4a81QnoS3BomUyYRs3lMgU0HKeVeR4LKFoPPd0n/Xm5JDGBePrsr5OhTAvwmfajYYPSTZuXwb5j7IQQiiuZaRKOPS9HY5sFT1ATELT/qmai7VWjF0+w1myivbMrxkI15lldQvCRSxihYEuKkyYFkvOknQUnMqDRIwKzhqQpgBVV0gxECQ5EQJcyrBJCYdPUKKgkpujgr4fUOEIiWqAUQ4nEUDTSCXjEVab7guJ+JEUNQdpEUOEajYLcZzTa2WpwK8G2TdgUjSHJHHXlliniW0PmEyQQ5m8mYcYc0uzcorMKm5gSJECcZLW7iHQbAKSoceR1ylJdV6RUnuberms0CSocal5jlo+2W1eZGlqd9Az6ynDCmHxrQomeIMFOAjZBsAs4lMedHjubNCeFaHkoHTjpfgOW0hTsT7RJB3agVeAkv5UPFypOV6yus4K5GMz1T6jK+uHcZUt0BOExvg+LJamAbsFmwcvlwtcURDkuEn+9lfCvjYAjx3W8vj0DO8ZPxofCJmYG7xWQ+YhN+PXDzz4mYEfJJpiCq+DvXOFBKfGov58Er0AMWNEguwSBOQ8Z4SBe42b4U2FqaKDmMQhfX0/Wmg95nWGWnYzHyUBlY5APNYVBDzZIS/KCnRx8AroE7PLnN6/fx4ZNj7DrcfqMkFSJz8iuiuFwSQ3KN+/eHIUPGJaxxNU74zG0D5UkHlj0QSG68iQy0HCzKbBln+x3EFKt7i/k3pPpKxyPl4A9eeJ4CUt3Xwlk7i2hJ7tO2Iye6m3Sdmb5lLW44/JhkGWLhqRgY1CEmJTDTeWwxtxTQL8tO/Q4ii65++rjvlF31BNJQ4ELDYWhZbtwWGCT6C8U1+iPSiSxIfuhe/6YQ0u6OMrFtk19hHBAhVfkjwO129Y+LuibI1+tb3p7givwOJLbtPT1z3Mf04+jWui+rY+xZILD4zlQZsnEmfdaSzSIALk6qkk79HSDLuOwU9mLA7nc5N/YuABRDoQmGg04ebShQpps2ywGD6u9JaxBVfH71dXLONIXD7T83KiHZ9tvTaMOy+BfDWKP+bl6cHUlf3h45ufq8bOLi8PuR9awJxZPLy6apxcXV1fZ2eLxk4uL5u8XF9khtjWG2/5abro26rjT3g72/f77l7OXNckXUeRhxwMD2Hf9h4bmLVJRhhfbwceG30iGcvf97FDAgTXsBZw/efqsOT87fx7/HPY9tIF95wcaJVX6s4oj/tx4DUo9PD8rqwKP2FsDuNXykvSifvH8ycXZ7uPjH388mtvX/b9V9m6r7N9Ry+efo8qH52f/2Xw4P/Uomzx7gY1V7GLWcM/S/RMtTUrBlXQx93PtzTy6cFiBBrpBmSKiw+uOT+fm2Ng+J/B9EkAB5D3O0YIrDPae2F3JrUSLKfUf4RACTsuGJS7RSHQObjgpB5foqTDoJqplU4CTJi3vl5VYxZ+CU6i7s60OxiHO4y+BSs09KwpAaXXbXXY52si2/X1r5O7hS1FGBc9rdDmCC7RCNV5tJDn/hMHbKk/CrOMlpWmyjjUnEMYHiDeCKUuhyKxQkhmvJvV6ToO9rrA/pumo5+4SstHA1BtAsNZnydeNFo0DUrFmCUlXUlyF3MEd4VFXAbpBNfSiwmm5E8GJMjOwTvMYO66FkpN8xsQb5RWvKcnPRPuOx9HmTIraRluID+ygwOTN9muRcMvr26I/Wu6qMIsy3m1Wm/eN/k/l2TvrO9/vKrUFrZNr4aFKu0vdFXQzhWnnnAUX4oGayvmSbZY/yaeAtWPWyaDCAkRbIqhQpribHJTCELwoK4VzRqdoFc/JcvS+kwLjV22KUg0FibmKScNd9fmfzGE+T16/2cXXH1uL2/8fxPC3qgaIzop/5dEtoIhF/7S4/XXpWOOvr47CDsf724rZo5mFUC40bK4Ofp+dC3CIbi4dgkZ3Ht9SO5/90blwXbI9qZIrDAHn8YnrtZAuVrdZ3d4Mv851wO3WEGWBH3mF5gNaBQI1msP07XQta8wX8X2e5W7lUq8qHGt7Evs7lJKGCvSdVECFhQNbkpE0cB99SgfS6Hm55Ta/Ny0pImzlSzRFPFFShx1VGa4N1kkaN0kSV5aNA0OpZF2yQs8a22ogOuxmwa8UkEpa4sh50JpzGrwy6gRRVLAmn6Swusm8rYKh1WZhXZWi0MjN+7ppg1SkLThBMHBv3Y1aXoNDw6vEYaIPIIEHy7inJKvGwop8AJOxz4IY/ZjE90lSt4FV4vA2FtaQz8EMXfCdcLoKFahlZWQGkkILOTkFAiyF9B0ZccPYyY3IuLpBjd6jKYaCo5+MYE2meA1KHW9Lx8t3fTdte+U7f2+33w9O1W+07PrRrnUhYvNB963AV0Z2c1v5CzBy8Y2I44Pky/8Av7GpyCExAAA=","edge":{"manageability":{"edge_last_active_time":"13423925604374563"},"mitigation_manager":{"renderer_app_container_compatible_count":35},"retrigger_features":[],"tab_stabs":{"closed_without_unfreeze_never_unfrozen":0,"closed_without_unfreeze_previously_unfrozen":0,"discard_without_unfreeze_never_unfrozen":0,"discard_without_unfreeze_previously_unfrozen":0},"tab_stats":{"frozen_daily":0,"unfrozen_daily":0}},"edge_ci":{"num_healthy_browsers_since_failure":8},"hardware_acceleration_mode_previous":true,"identity_combined_status":{"aad":2,"ad":1},"legacy":{"profile":{"name":{"migrated":true}}},"local":{"password_hash_data_list":[]},"network_time":{"network_time_mapping":{"local":1.779941889890499e+12,"network":1.77994189e+12,"ticks":163675012811.0,"uncertainty":1349334.0}},"optimization_guide":{"model_execution":{"last_usage_by_feature":{}},"model_store_metadata":{},"on_device":{"last_version":"148.0.3967.83","model_crash_count":0}},"os_crypt":{"audit_enabled":true,"encrypted_key":"RFBBUEkBAAAA0Iyd3wEV0RGMegDAT8KX6wEAAADZoDg7gSkmQaWnd9fm/5SUEAAAAB4AAABNAGkAYwByAG8AcwBvAGYAdAAgAEUAZABnAGUAAAAQZgAAAAEAACAAAAD65zA6qg/tooC0TcxvATuppJIhyckfPXlmJoqkrOI1ZAAAAAAOgAAAAAIAACAAAAAVy9Fo/Eo9VgypJ2YeWo0Rnv5DpKEW5MQV4LSl6rShAzAAAAD03hLzmXJ1wcP4VbIen3H3TFKHLksjGA4IOwP1mtZiww+FMlpN/zpetrGB8+ghKAxAAAAAKNsxjoskJjAZFdO7mw1p4Bw76tv1LunjVLS4QFN5dNicnKYbVGfExY0lV+yvGP8/udPrg4poHW1a9E9jgXCoFg=="},"performance_intervention":{"last_daily_sample":"13424415488481934"},"phoenix":{"user_laf_toggle_state_static":2},"policy":{"last_statistics_update":"13424415488421936"},"profile":{"info_cache":{"Default":{"active_time":1779451999.763254,"avatar_icon":"chrome://theme/IDR_PROFILE_AVATAR_20","background_apps":false,"edge_account_cid":"","edge_account_environment":0,"edge_account_environment_string":"","edge_account_first_name":"","edge_account_last_name":"","edge_account_oid":"","edge_account_sovereignty":0,"edge_account_tenant_id":"","edge_account_type":0,"edge_create_profile_shortcut":false,"edge_non_signin_profile_type":1,"edge_profile_can_be_deleted":true,"edge_profile_can_be_edited":true,"edge_test_on_premises":false,"edge_wam_aad_for_app_account_type":0,"enterprise_label":"","force_signin_profile_locked":false,"gaia_given_name":"","gaia_id":"","gaia_name":"","hosted_domain":"","is_consented_primary_account":false,"is_ephemeral":false,"is_glic_eligible":false,"is_managed":0,"is_using_default_avatar":true,"is_using_default_name":true,"managed_user_id":"","metrics_bucket_index":1,"name":"Profile 1","signin.with_credential_provider":false,"user_name":""}},"last_active_profiles":[],"metrics":{"next_bucket_index":2},"profile_counts_reported":"13424415488421406","profiles_order":["Default"]},"profile_network_context_service":{"http_cache_finch_experiment_groups":"None None None None"},"profiles":{"edge":{"guided_switch_pref":[],"multiple_profiles_with_same_account":false},"edge_sso_info":{"msa_first_profile_key":"Default","msa_sso_algo_state":1},"signin_last_seen_version":"148.0.3967.83","signin_last_updated_time":1779941888.477035},"sentinel_creation_time":"0","session_id_generator_last_value":"1527593965","signin":{"active_accounts_last_emitted":"13424415488368240"},"startup_boost":{"last_browser_open_time":"13424415764725658"},"subresource_filter":{"ruleset_version":{"checksum":860988201,"content":"10.34.0.84","format":37}},"tab_stats":{"discards_expired":0,"discards_external":0,"discards_proactive":0,"discards_urgent":0,"last_daily_sample":"13424415488405630","max_tabs_per_window":1,"reloads_expired":0,"reloads_external":0,"reloads_urgent":0,"total_tab_count_max":1,"window_count_max":1},"telemetry_client":{"cloned_install":{"user_data_dir_id":5577004},"governance":{"last_dma_change_date":"13423917259231611","last_known_cps":0},"host_telclient_path":"QzpcUHJvZ3JhbSBGaWxlcyAoeDg2KVxNaWNyb3NvZnRcRWRnZVdlYlZpZXdcQXBwbGljYXRpb25cMTQ4LjAuMzk2Ny43MFx0ZWxjbGllbnQuZGxs","sample_id":67306662},"uninstall_metrics":{"installation_date2":"1779443659"},"updateclientdata":{"apps":{"alpjnmnfbgfkmmpcfpejmmoebdndedno":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"46.0.0.0"},"eeobbhfgfagbclfofmgbdfoicabjdbkn":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"1.0.0.10"},"fgbafbciocncjfbbonhocjaohoknlaco":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"2026.3.23.1"},"fppmbhmldokgmleojlplaaodlkibgikh":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"1.15.0.1"},"jbfaflocpnkhbgcijpkiafdpbjkedane":{"cohort":"","cohortname":"","installdate":-1},"kpfehajjjbbcifeehjgfgnabifknmdad":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"120.0.6050.0"},"laoigpblnllgcgjnjnllmfolckpjlhki":{"cohort":"","cohortname":"","installdate":-1},"ndikpojcjlepofdkaaldkinkjbeeebkl":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"10.34.0.84"},"oankkpibpaokgecfckkdkgaoafllipag":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"6498.2025.9.4"},"ohckeflnhegojcjlcpbfpciadgikcohk":{"cohort":"","cohortname":"","fp":"","installdate":-1,"max_pv":"0.0.0.0","pv":"0.0.1.7"},"ojblfafjmiikbkepnnolpgbbhejhlcim":{"cohort":"","cohortname":"","installdate":-1}}},"updateclientlastupdatecheckerror":0,"updateclientlastupdatecheckerrorcategory":0,"updateclientlastupdatecheckerrorextracode1":0,"user_experience_metrics":{"chrome_download_action_count":0,"client_id2":"{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}C:\\Users\\huyho0s:3A02F2DE-3009-472C-BE97-36554D8055CA","diagnostics":{"last_data_collection_level_on_launch":1},"limited_entropy_randomization_source":"A9FF69BB8A6E12706019AABFC2EE8578","low_entropy_source3":2763,"machine_id":4383090,"payload_counter":1,"pseudo_low_entropy_source":4342,"reporting_enabled":false,"reset_client_id_deterministic":true,"session_id":34,"stability":{"browser_last_live_timestamp":"13424415764761560","exited_cleanly":true,"stats_buildtime":"1779334689","stats_version":"148.0.3967.83-64","system_crash_count":0}},"variations_compressed_seed":"safe_seed_content","variations_config_ids":"P-R-1820855-3-9,P-R-1736541-5-5,P-R-1315481-1-8,P-R-1541171-6-9,P-R-1528200-3-4,P-R-1113531-4-9,P-R-68474-9-12,P-R-61206-24-23,P-R-60617-8-21,P-R-45373-8-87,P-R-1075865-4-8","variations_crash_streak":0,"variations_failed_to_fetch_seed_streak":1,"variations_google_groups":{"Default":[]},"variations_last_fetch_time":"13424415488760330","variations_last_runtime_fetch_time":"13424415490009222","variations_runtime_compressed_seed":"H4sIAAAAAAAAAG2PS2uDQBSF/8vd1gszc8d5CN1UU5pQWhXJpunC6NQKiRZfJQT/e4m2uy6/8x04914hbJuPutpGPQQQY4qcWRLSR47C99bAKCaRI+mFtSGmkCM3K5ISC65WEVc+ShRqQZ+EJBS4SsmYJaQ/SUZLiRrtaokba1FYlNZ6MUbIuW8UlyhQ/l5CRiuGAjkDDzZl5dKxGeqzW5+A4Aqb89dw+de4Jj+e3KPLh7FzPQRv4FxXwPs8e/Dk8tJ1/a0WtmMzdJewLR0EsH+5DWV5BQEcIKMkjnX5OVmtiuZ5N40yeX2I9olJu1OYmW09Hovvu93UFvcHgHn+Af8c9hhfAQAA","variations_runtime_config_ids":"P-R-1093245-1-25,P-R-108604-1-37,P-R-78306-1-18,P-R-73626-1-17,P-R-63165-4-26,P-R-53243-2-7,P-R-40093-3-26,P-R-38744-7-97,P-R-31899-29-499,P-D-1158614-2-4,P-R-1038760-2-10","variations_safe_compressed_seed":"H4sIAAAAAAAAAJVVbW8aORD+K5G/3jq39r6G032gvLQoIaUhNJXaKjK7w8aH1ya2F4Iq/nvlNaEhV5S7fIiYmWeeeWY8a/9Ag94UdX6gnuAgbU/JBa8azSxXcrYqmYXBGqR1iD4Iy65UNZBsLqBEnQUTBgI0bISYgj0dGWp4bEAWW9QhYbgL0OCpEE0JgycLWjLhi45KM5JXqkIdqxsIkPdeqeqW6Qos6iAoK7g31tVAjqWswINaddy4QL+pVx/lSK6Z4OU1W/OqbeUDsBK0ccDSA4fAbKPBoM5X9EbS913wTH+lCiauwW6UXnaLAozpPUCxPMF7Au0ZN2s6ZbKcq6cT2SOjBLOwB0E5WmhWw5GcIRcw3RoL9Qt6wY09Qfka3+caCqv0dmTBn/k7oTyD78vV8qd695l2y5I7DBMTrVz6JRcCylsQUIPVW1cU5OuatbmD+WcOm7fzXbVpWTz4iqfo3Lk7VAv/NBv1HHDF3HBse8ZffyDJakAdVDwwKUGgAK2ZaJxniHbBIQwrVTy8CEah/3uJ0WA1k6bmtl28eyXvN1zDveU1qMbe11wIbqBQsjQvqKhjcQI/rkFrXsLscmxOdTRb1u/V2n0LsoArd3zfgxMdteBnzhb6q+aYF1oZtbDnQ66NnTBtt/vtu3FfoLE3YBphAxKQ5K9jee1XflKgj3aFUJu35LXQNwXewfydVhsD+nyilVXzZnE+uxyf++WcaLXgAoLQ6fwPSZZZc36lqqll2gZhEP+fpJ6qVwIstHl+KIeNnKjVlLlw+5/L6tSAhkoXcEg7oANUG3eDgbEzyRdK131urObzpr1fuLGq0qw+Pc9Kq2ZFDzKOFuzllpawYI2w7x38d+gjcLOsT1J+3+1v1naFbhr564Yd1Cu7/X3o3yMBWOgCtWxTqGqQtr1eHHiolbQcdLcpOcjCVb5W0gkZd0ddIVAHte8HCtDd3eDYYYrVonGesP1dNUyXz8YadPtzHKVJT2k4zuwpaUHaKeg1L8C8qgPzL7fHrndcVsce1/qx57BlM+Nq7/27AL14bga3rEId9A0t0z9uK/1PPylst//pw7T/56Vm0fJxPHnYXobhXaQfp1/Ip/lmGf/9Dbl6TyveThMNNQ/OKD0bs+0ZDWl6RsJOEndoePZ+fNv21kirtz1VumF+vkYBcuvdmL2nvYyeX9RR3+tyzz6a4BtMsoQkaYgJJkFrhzlNstZ2jj6OaZTnmOIUHT+6PjunYZ4kOMIXPjuL0iQmOMGJtyOSxDnBBOfeTmJCMoLTZ3xCcxqGOMKxtwmJkojgeB9P8ziL8QUm1JuEhimmMaaRt8OUZDjH1GuPkyiLcI7zDP1+jb3mMEvyNMExztHr/dyPhKQZiTAJ/QxuMImzKCTprzZIcnGRJ5g8t0lIdEESTJNDRniRR1GMCU690jTMckxwdLCyQ3Ya5jnFBPse4yjMKY72sZhmsWOhaLf7CchK9TuuCQAA","variations_safe_seed_date":"13424275300000000","variations_safe_seed_fetch_time":"13424415488760330","variations_safe_seed_locale":"en-GB","variations_safe_seed_milestone":148,"variations_safe_seed_signature":"","variations_seed_client_version_at_store":"148.0.3967.70","variations_seed_date":"13424415490000000","variations_seed_etag":"\"k6+TgrjD5ctADQHSD/Kra3kqMPhyK00W3rqSX1Qbwk4=\"","variations_seed_milestone":148,"variations_seed_runtime_etag":"\"T3QPP7dhv976cnLJvu4QOBDVQ8RrlCT8Iiubcw+Jvoc=\"","variations_seed_runtime_serial_number":"\"T3QPP7dhv976cnLJvu4QOBDVQ8RrlCT8Iiubcw+Jvoc=\"","variations_seed_serial_number":"\"k6+TgrjD5ctADQHSD/Kra3kqMPhyK00W3rqSX1Qbwk4=\"","variations_seed_signature":"","variations_sticky_studies":"","was":{"restarted":false}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/OriginTrials/0.0.1.7/manifest.json

``json
{"version": "0.0.1.7", "origin-trials": {}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/PKIMetadata/46.0.0.0/crs.pb

_Skipped binary or large file. Size: 239119 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/PKIMetadata/46.0.0.0/ct_config.pb

_Skipped binary or large file. Size: 16452 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/PKIMetadata/46.0.0.0/kp_pinslist.pb

_Skipped binary or large file. Size: 10674 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/PKIMetadata/46.0.0.0/manifest.json

``json
{
   "description" : "Microsoft PKI Metadata",
   "name" : "PKIMetadata",
   "version" : "46.0.0.0"
}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/ShaderCache/data_0

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/ShaderCache/data_1

_Skipped binary or large file. Size: 270336 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/ShaderCache/data_2

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/ShaderCache/data_3

_Skipped binary or large file. Size: 8192 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/ShaderCache/index

_Skipped binary or large file. Size: 262512 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/SmartScreen/RemoteData/edgeSettings

``text
edgeSettings_2.0-0
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/SmartScreen/RemoteData/edgeSettings_2.0-0

``text
{"models":[],"geoidMaps":{"gw_my":"https://malaysia.smartscreen.microsoft.com/","gw_tw":"https://taiwan.smartscreen.microsoft.com/","gw_at":"https://austria.smartscreen.microsoft.com/","gw_es":"https://spain.smartscreen.microsoft.com/","gw_pl":"https://poland.smartscreen.microsoft.com/","gw_se":"https://sweden.smartscreen.microsoft.com/","gw_kr":"https://southkorea.smartscreen.microsoft.com/","gw_br":"https://brazil.smartscreen.microsoft.com/","au":"https://australia.smartscreen.microsoft.com/","dk":"https://denmark.smartscreen.microsoft.com/","gw_sg":"https://singapore.smartscreen.microsoft.com/","gw_fr":"https://france.smartscreen.microsoft.com/","gw_ca":"https://canada.smartscreen.microsoft.com/","gw_il":"https://israel.smartscreen.microsoft.com/","gw_au":"https://australia.smartscreen.microsoft.com/","gw_ffl4mod":"https://unitedstates4.ss.wd.microsoft.us/","gw_ffl4":"https://unitedstates1.ss.wd.microsoft.us/","gw_eu":"https://europe.smartscreen.microsoft.com/","gw_gr":"https://greece.smartscreen.microsoft.com/","gw_de":"https://germany.smartscreen.microsoft.com/","br":"https://brazil.smartscreen.microsoft.com/","gw_uk":"https://unitedkingdom.smartscreen.microsoft.com/","gw_it":"https://italy.smartscreen.microsoft.com/","gw_us":"https://unitedstates.smartscreen.microsoft.com/","il":"https://israel.smartscreen.microsoft.com/","es":"https://spain.smartscreen.microsoft.com/","ch":"https://switzerland.smartscreen.microsoft.com/","at":"https://austria.smartscreen.microsoft.com/","jp":"https://japan.smartscreen.microsoft.com/","kr":"https://southkorea.smartscreen.microsoft.com/","nz":"https://newzealand.smartscreen.microsoft.com/","gw_cl":"https://chile.smartscreen.microsoft.com/","pl":"https://poland.smartscreen.microsoft.com/","eu":"https://europe.smartscreen.microsoft.com/","de":"https://germany.smartscreen.microsoft.com/","gw_no":"https://norway.smartscreen.microsoft.com/","ffl4mod":"https://unitedstates4.ss.wd.microsoft.us/","gw_jp":"https://japan.smartscreen.microsoft.com/","mx":"https://mexico.smartscreen.microsoft.com/","gw_ffl5":"https://unitedstates2.ss.wd.microsoft.us/","se":"https://sweden.smartscreen.microsoft.com/","gw_ch":"https://switzerland.smartscreen.microsoft.com/","gw_ae":"https://uae.smartscreen.microsoft.com/","my":"https://malaysia.smartscreen.microsoft.com/","gw_nz":"https://newzealand.smartscreen.microsoft.com/","ca":"https://canada.smartscreen.microsoft.com/","fr":"https://france.smartscreen.microsoft.com/","gw_mx":"https://mexico.smartscreen.microsoft.com/","no":"https://norway.smartscreen.microsoft.com/","gr":"https://greece.smartscreen.microsoft.com/","gw_qa":"https://qatar.smartscreen.microsoft.com/","gw_in":"https://india.smartscreen.microsoft.com/","in":"https://india.smartscreen.microsoft.com/","tw":"https://taiwan.smartscreen.microsoft.com/","sg":"https://singapore.smartscreen.microsoft.com/","ffl5":"https://unitedstates2.ss.wd.microsoft.us/","ae":"https://uae.smartscreen.microsoft.com/","gw_dk":"https://denmark.smartscreen.microsoft.com/","gw_za":"https://southafrica.smartscreen.microsoft.com/","uk":"https://unitedkingdom.smartscreen.microsoft.com/","cl":"https://chile.smartscreen.microsoft.com/","us":"https://unitedstates.smartscreen.microsoft.com/","qa":"https://qatar.smartscreen.microsoft.com/","za":"https://southafrica.smartscreen.microsoft.com/","ffl4":"https://unitedstates1.ss.wd.microsoft.us/","it":"https://italy.smartscreen.microsoft.com/"},"sampleBuckets":{"evaluateModel":1.0,"error":1.0,"uriLookup":0.01,"userAction":1.0,"topTrafficHit":0.00007}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Speech Recognition/1.15.0.1/manifest.json

``json
{"manifest_version": 2,"name": "Speech Recognition","version": "1.15.0.1"}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Speech Recognition/1.15.0.1/Microsoft.CognitiveServices.Speech.core.dll

_Skipped binary or large file. Size: 2692424 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Indexed Rules/37/10.34.0.84/LICENSE

``text
EasyList Repository Licences

   Unless otherwise noted, the contents of the EasyList repository
   (https://github.com/easylist) is dual licensed under the GNU General
   Public License version 3 of the License, or (at your option) any later
   version, and Creative Commons Attribution-ShareAlike 3.0 Unported, or
   (at your option) any later version. You may use and/or modify the files
   as permitted by either licence; if required, "The EasyList authors
   (https://easylist.to/)" should be attributed as the source of the
   material. All relevant licence files are included in the repository.

   Please be aware that files hosted externally and referenced in the
   repository, including but not limited to subscriptions other than
   EasyList, EasyPrivacy, EasyList Germany and EasyList Italy, may be
   available under other conditions; permission must be granted by the
   respective copyright holders to authorise the use of their material.


Creative Commons Attribution-ShareAlike 3.0 Unported

     CREATIVE COMMONS CORPORATION IS NOT A LAW FIRM AND DOES NOT PROVIDE
     LEGAL SERVICES. DISTRIBUTION OF THIS LICENSE DOES NOT CREATE AN
     ATTORNEY-CLIENT RELATIONSHIP. CREATIVE COMMONS PROVIDES THIS
     INFORMATION ON AN "AS-IS" BASIS. CREATIVE COMMONS MAKES NO
     WARRANTIES REGARDING THE INFORMATION PROVIDED, AND DISCLAIMS
     LIABILITY FOR DAMAGES RESULTING FROM ITS USE.

License

   THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS
   CREATIVE COMMONS PUBLIC LICENSE ("CCPL" OR "LICENSE"). THE WORK IS
   PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK
   OTHER THAN AS AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS
   PROHIBITED.

   BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HERE, YOU ACCEPT AND
   AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. TO THE EXTENT THIS
   LICENSE MAY BE CONSIDERED TO BE A CONTRACT, THE LICENSOR GRANTS YOU THE
   RIGHTS CONTAINED HERE IN CONSIDERATION OF YOUR ACCEPTANCE OF SUCH TERMS
   AND CONDITIONS.

   1. Definitions
    a. "Adaptation" means a work based upon the Work, or upon the Work and
       other pre-existing works, such as a translation, adaptation,
       derivative work, arrangement of music or other alterations of a
       literary or artistic work, or phonogram or performance and includes
       cinematographic adaptations or any other form in which the Work may
       be recast, transformed, or adapted including in any form
       recognizably derived from the original, except that a work that
       constitutes a Collection will not be considered an Adaptation for
       the purpose of this License. For the avoidance of doubt, where the
       Work is a musical work, performance or phonogram, the
       synchronization of the Work in timed-relation with a moving image
       ("synching") will be considered an Adaptation for the purpose of
       this License.
    b. "Collection" means a collection of literary or artistic works, such
       as encyclopedias and anthologies, or performances, phonograms or
       broadcasts, or other works or subject matter other than works
       listed in Section 1(f) below, which, by reason of the selection and
       arrangement of their contents, constitute intellectual creations,
       in which the Work is included in its entirety in unmodified form
       along with one or more other contributions, each constituting
       separate and independent works in themselves, which together are
       assembled into a collective whole. A work that constitutes a
       Collection will not be considered an Adaptation (as defined below)
       for the purposes of this License.
    c. "Creative Commons Compatible License" means a license that is
       listed at https://creativecommons.org/compatiblelicenses that has
       been approved by Creative Commons as being essentially equivalent
       to this License, including, at a minimum, because that license: (i)
       contains terms that have the same purpose, meaning and effect as
       the License Elements of this License; and, (ii) explicitly permits
       the relicensing of adaptations of works made available under that
       license under this License or a Creative Commons jurisdiction
       license with the same License Elements as this License.
    d. "Distribute" means to make available to the public the original and
       copies of the Work or Adaptation, as appropriate, through sale or
       other transfer of ownership.
    e. "License Elements" means the following high-level license
       attributes as selected by Licensor and indicated in the title of
       this License: Attribution, ShareAlike.
    f. "Licensor" means the individual, individuals, entity or entities
       that offer(s) the Work under the terms of this License.
    g. "Original Author" means, in the case of a literary or artistic
       work, the individual, individuals, entity or entities who created
       the Work or if no individual or entity can be identified, the
       publisher; and in addition (i) in the case of a performance the
       actors, singers, musicians, dancers, and other persons who act,
       sing, deliver, declaim, play in, interpret or otherwise perform
       literary or artistic works or expressions of folklore; (ii) in the
       case of a phonogram the producer being the person or legal entity
       who first fixes the sounds of a performance or other sounds; and,
       (iii) in the case of broadcasts, the organization that transmits
       the broadcast.
    h. "Work" means the literary and/or artistic work offered under the
       terms of this License including without limitation any production
       in the literary, scientific and artistic domain, whatever may be
       the mode or form of its expression including digital form, such as
       a book, pamphlet and other writing; a lecture, address, sermon or
       other work of the same nature; a dramatic or dramatico-musical
       work; a choreographic work or entertainment in dumb show; a musical
       composition with or without words; a cinematographic work to which
       are assimilated works expressed by a process analogous to
       cinematography; a work of drawing, painting, architecture,
       sculpture, engraving or lithography; a photographic work to which
       are assimilated works expressed by a process analogous to
       photography; a work of applied art; an illustration, map, plan,
       sketch or three-dimensional work relative to geography, topography,
       architecture or science; a performance; a broadcast; a phonogram; a
       compilation of data to the extent it is protected as a
       copyrightable work; or a work performed by a variety or circus
       performer to the extent it is not otherwise considered a literary
       or artistic work.
    i. "You" means an individual or entity exercising rights under this
       License who has not previously violated the terms of this License
       with respect to the Work, or who has received express permission
       from the Licensor to exercise rights under this License despite a
       previous violation.
    j. "Publicly Perform" means to perform public recitations of the Work
       and to communicate to the public those public recitations, by any
       means or process, including by wire or wireless means or public
       digital performances; to make available to the public Works in such
       a way that members of the public may access these Works from a
       place and at a place individually chosen by them; to perform the
       Work to the public by any means or process and the communication to
       the public of the performances of the Work, including by public
       digital performance; to broadcast and rebroadcast the Work by any
       means including signs, sounds or images.
    k. "Reproduce" means to make copies of the Work by any means including
       without limitation by sound or visual recordings and the right of
       fixation and reproducing fixations of the Work, including storage
       of a protected performance or phonogram in digital form or other
       electronic medium.

   2. Fair Dealing Rights. Nothing in this License is intended to reduce,
   limit, or restrict any uses free from copyright or rights arising from
   limitations or exceptions that are provided for in connection with the
   copyright protection under copyright law or other applicable laws.

   3. License Grant. Subject to the terms and conditions of this License,
   Licensor hereby grants You a worldwide, royalty-free, non-exclusive,
   perpetual (for the duration of the applicable copyright) license to
   exercise the rights in the Work as stated below:
    a. to Reproduce the Work, to incorporate the Work into one or more
       Collections, and to Reproduce the Work as incorporated in the
       Collections;
    b. to create and Reproduce Adaptations provided that any such
       Adaptation, including any translation in any medium, takes
       reasonable steps to clearly label, demarcate or otherwise identify
       that changes were made to the original Work. For example, a
       translation could be marked "The original work was translated from
       English to Spanish," or a modification could indicate "The original
       work has been modified.";
    c. to Distribute and Publicly Perform the Work including as
       incorporated in Collections; and,
    d. to Distribute and Publicly Perform Adaptations.
    e. For the avoidance of doubt:
         i. Non-waivable Compulsory License Schemes. In those
            jurisdictions in which the right to collect royalties through
            any statutory or compulsory licensing scheme cannot be waived,
            the Licensor reserves the exclusive right to collect such
            royalties for any exercise by You of the rights granted under
            this License;
        ii. Waivable Compulsory License Schemes. In those jurisdictions in
            which the right to collect royalties through any statutory or
            compulsory licensing scheme can be waived, the Licensor waives
            the exclusive right to collect such royalties for any exercise
            by You of the rights granted under this License; and,
        iii. Voluntary License Schemes. The Licensor waives the right to
            collect royalties, whether individually or, in the event that
            the Licensor is a member of a collecting society that
            administers voluntary licensing schemes, via that society,
            from any exercise by You of the rights granted under this
            License.

   The above rights may be exercised in all media and formats whether now
   known or hereafter devised. The above rights include the right to make
   such modifications as are technically necessary to exercise the rights
   in other media and formats. Subject to Section 8(f), all rights not
   expressly granted by Licensor are hereby reserved.

   4. Restrictions. The license granted in Section 3 above is expressly
   made subject to and limited by the following restrictions:
    a. You may Distribute or Publicly Perform the Work only under the
       terms of this License. You must include a copy of, or the Uniform
       Resource Identifier (URI) for, this License with every copy of the
       Work You Distribute or Publicly Perform. You may not offer or
       impose any terms on the Work that restrict the terms of this
       License or the ability of the recipient of the Work to exercise the
       rights granted to that recipient under the terms of the License.
       You may not sublicense the Work. You must keep intact all notices
       that refer to this License and to the disclaimer of warranties with
       every copy of the Work You Distribute or Publicly Perform. When You
       Distribute or Publicly Perform the Work, You may not impose any
       effective technological measures on the Work that restrict the
       ability of a recipient of the Work from You to exercise the rights
       granted to that recipient under the terms of the License. This
       Section 4(a) applies to the Work as incorporated in a Collection,
       but this does not require the Collection apart from the Work itself
       to be made subject to the terms of this License. If You create a
       Collection, upon notice from any Licensor You must, to the extent
       practicable, remove from the Collection any credit as required by
       Section 4(c), as requested. If You create an Adaptation, upon
       notice from any Licensor You must, to the extent practicable,
       remove from the Adaptation any credit as required by Section 4(c),
       as requested.
    b. You may Distribute or Publicly Perform an Adaptation only under the
       terms of: (i) this License; (ii) a later version of this License
       with the same License Elements as this License; (iii) a Creative
       Commons jurisdiction license (either this or a later license
       version) that contains the same License Elements as this License
       (e.g., Attribution-ShareAlike 3.0 US)); (iv) a Creative Commons
       Compatible License. If you license the Adaptation under one of the
       licenses mentioned in (iv), you must comply with the terms of that
       license. If you license the Adaptation under the terms of any of
       the licenses mentioned in (i), (ii) or (iii) (the "Applicable
       License"), you must comply with the terms of the Applicable License
       generally and the following provisions: (I) You must include a copy
       of, or the URI for, the Applicable License with every copy of each
       Adaptation You Distribute or Publicly Perform; (II) You may not
       offer or impose any terms on the Adaptation that restrict the terms
       of the Applicable License or the ability of the recipient of the
       Adaptation to exercise the rights granted to that recipient under
       the terms of the Applicable License; (III) You must keep intact all
       notices that refer to the Applicable License and to the disclaimer
       of warranties with every copy of the Work as included in the
       Adaptation You Distribute or Publicly Perform; (IV) when You
       Distribute or Publicly Perform the Adaptation, You may not impose
       any effective technological measures on the Adaptation that
       restrict the ability of a recipient of the Adaptation from You to
       exercise the rights granted to that recipient under the terms of
       the Applicable License. This Section 4(b) applies to the Adaptation
       as incorporated in a Collection, but this does not require the
       Collection apart from the Adaptation itself to be made subject to
       the terms of the Applicable License.
    c. If You Distribute, or Publicly Perform the Work or any Adaptations
       or Collections, You must, unless a request has been made pursuant
       to Section 4(a), keep intact all copyright notices for the Work and
       provide, reasonable to the medium or means You are utilizing: (i)
       the name of the Original Author (or pseudonym, if applicable) if
       supplied, and/or if the Original Author and/or Licensor designate
       another party or parties (e.g., a sponsor institute, publishing
       entity, journal) for attribution ("Attribution Parties") in
       Licensor's copyright notice, terms of service or by other
       reasonable means, the name of such party or parties; (ii) the title
       of the Work if supplied; (iii) to the extent reasonably
       practicable, the URI, if any, that Licensor specifies to be
       associated with the Work, unless such URI does not refer to the
       copyright notice or licensing information for the Work; and (iv) ,
       consistent with Ssection 3(b), in the case of an Adaptation, a
       credit identifying the use of the Work in the Adaptation (e.g.,
       "French translation of the Work by Original Author," or "Screenplay
       based on original Work by Original Author"). The credit required by
       this Section 4(c) may be implemented in any reasonable manner;
       provided, however, that in the case of a Adaptation or Collection,
       at a minimum such credit will appear, if a credit for all
       contributing authors of the Adaptation or Collection appears, then
       as part of these credits and in a manner at least as prominent as
       the credits for the other contributing authors. For the avoidance
       of doubt, You may only use the credit required by this Section for
       the purpose of attribution in the manner set out above and, by
       exercising Your rights under this License, You may not implicitly
       or explicitly assert or imply any connection with, sponsorship or
       endorsement by the Original Author, Licensor and/or Attribution
       Parties, as appropriate, of You or Your use of the Work, without
       the separate, express prior written permission of the Original
       Author, Licensor and/or Attribution Parties.
    d. Except as otherwise agreed in writing by the Licensor or as may be
       otherwise permitted by applicable law, if You Reproduce, Distribute
       or Publicly Perform the Work either by itself or as part of any
       Adaptations or Collections, You must not distort, mutilate, modify
       or take other derogatory action in relation to the Work which would
       be prejudicial to the Original Author's honor or reputation.
       Licensor agrees that in those jurisdictions (e.g. Japan), in which
       any exercise of the right granted in Section 3(b) of this License
       (the right to make Adaptations) would be deemed to be a distortion,
       mutilation, modification or other derogatory action prejudicial to
       the Original Author's honor and reputation, the Licensor will waive
       or not assert, as appropriate, this Section, to the fullest extent
       permitted by the applicable national law, to enable You to
       reasonably exercise Your right under Section 3(b) of this License
       (right to make Adaptations) but not otherwise.

   5. Representations, Warranties and Disclaimer

   UNLESS OTHERWISE MUTUALLY AGREED TO BY THE PARTIES IN WRITING, LICENSOR
   OFFERS THE WORK AS-IS AND MAKES NO REPRESENTATIONS OR WARRANTIES OF ANY
   KIND CONCERNING THE WORK, EXPRESS, IMPLIED, STATUTORY OR OTHERWISE,
   INCLUDING, WITHOUT LIMITATION, WARRANTIES OF TITLE, MERCHANTIBILITY,
   FITNESS FOR A PARTICULAR PURPOSE, NONINFRINGEMENT, OR THE ABSENCE OF
   LATENT OR OTHER DEFECTS, ACCURACY, OR THE PRESENCE OF ABSENCE OF
   ERRORS, WHETHER OR NOT DISCOVERABLE. SOME JURISDICTIONS DO NOT ALLOW
   THE EXCLUSION OF IMPLIED WARRANTIES, SO SUCH EXCLUSION MAY NOT APPLY TO
   YOU.

   6. Limitation on Liability. EXCEPT TO THE EXTENT REQUIRED BY APPLICABLE
   LAW, IN NO EVENT WILL LICENSOR BE LIABLE TO YOU ON ANY LEGAL THEORY FOR
   ANY SPECIAL, INCIDENTAL, CONSEQUENTIAL, PUNITIVE OR EXEMPLARY DAMAGES
   ARISING OUT OF THIS LICENSE OR THE USE OF THE WORK, EVEN IF LICENSOR
   HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.

   7. Termination
    a. This License and the rights granted hereunder will terminate
       automatically upon any breach by You of the terms of this License.
       Individuals or entities who have received Adaptations or
       Collections from You under this License, however, will not have
       their licenses terminated provided such individuals or entities
       remain in full compliance with those licenses. Sections 1, 2, 5, 6,
       7, and 8 will survive any termination of this License.
    b. Subject to the above terms and conditions, the license granted here
       is perpetual (for the duration of the applicable copyright in the
       Work). Notwithstanding the above, Licensor reserves the right to
       release the Work under different license terms or to stop
       distributing the Work at any time; provided, however that any such
       election will not serve to withdraw this License (or any other
       license that has been, or is required to be, granted under the
       terms of this License), and this License will continue in full
       force and effect unless terminated as stated above.

   8. Miscellaneous
    a. Each time You Distribute or Publicly Perform the Work or a
       Collection, the Licensor offers to the recipient a license to the
       Work on the same terms and conditions as the license granted to You
       under this License.
    b. Each time You Distribute or Publicly Perform an Adaptation,
       Licensor offers to the recipient a license to the original Work on
       the same terms and conditions as the license granted to You under
       this License.
    c. If any provision of this License is invalid or unenforceable under
       applicable law, it shall not affect the validity or enforceability
       of the remainder of the terms of this License, and without further
       action by the parties to this agreement, such provision shall be
       reformed to the minimum extent necessary to make such provision
       valid and enforceable.
    d. No term or provision of this License shall be deemed waived and no
       breach consented to unless such waiver or consent shall be in
       writing and signed by the party to be charged with such waiver or
       consent.
    e. This License constitutes the entire agreement between the parties
       with respect to the Work licensed here. There are no
       understandings, agreements or representations with respect to the
       Work not specified here. Licensor shall not be bound by any
       additional provisions that may appear in any communication from
       You. This License may not be modified without the mutual written
       agreement of the Licensor and You.
    f. The rights granted under, and the subject matter referenced, in
       this License were drafted utilizing the terminology of the Berne
       Convention for the Protection of Literary and Artistic Works (as
       amended on September 28, 1979), the Rome Convention of 1961, the
       WIPO Copyright Treaty of 1996, the WIPO Performances and Phonograms
       Treaty of 1996 and the Universal Copyright Convention (as revised
       on July 24, 1971). These rights and subject matter take effect in
       the relevant jurisdiction in which the License terms are sought to
       be enforced according to the corresponding provisions of the
       implementation of those treaty provisions in the applicable
       national law. If the standard suite of rights granted under
       applicable copyright law includes additional rights not granted
       under this License, such additional rights are deemed to be
       included in the License; this License is not intended to restrict
       the license of any rights under applicable law.

Creative Commons Notice

     Creative Commons is not a party to this License, and makes no
     warranty whatsoever in connection with the Work. Creative Commons
     will not be liable to You or any party on any legal theory for any
     damages whatsoever, including without limitation any general,
     special, incidental or consequential damages arising in connection
     to this license. Notwithstanding the foregoing two (2) sentences, if
     Creative Commons has expressly identified itself as the Licensor
     hereunder, it shall have all rights and obligations of Licensor.

     Except for the limited purpose of indicating to the public that the
     Work is licensed under the CCPL, Creative Commons does not authorize
     the use by either party of the trademark "Creative Commons" or any
     related trademark or logo of Creative Commons without the prior
     written consent of Creative Commons. Any permitted use will be in
     compliance with Creative Commons' then-current trademark usage
     guidelines, as may be published on its website or otherwise made
     available upon request from time to time. For the avoidance of
     doubt, this trademark restriction does not form part of the License.

     Creative Commons may be contacted at https://creativecommons.org/.
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Indexed Rules/37/10.34.0.84/Ruleset Data

_Skipped binary or large file. Size: 3717992 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/adblock_snippet.js

``javascript
(()=>{function e(){"undefined"!=typeof videoAdsBlockerNativeHandler&&videoAdsBlockerNativeHandler.logBlockSuccess()}function t(t,n){if(!t)throw new Error("[override-property-read snippet]: No property to override.");if(void 0===n)throw new Error("[override-property-read snippet]: No value to override with.");let l;if("false"===n)l=!1;else if("true"===n)l=!0;else if("null"===n)l=null;else if("noopFunc"===n)l=()=>{};else if("trueFunc"===n)l=()=>!0;else if("falseFunc"===n)l=()=>!1;else if(/^\d+$/.test(n))l=parseFloat(n);else if(""===n)l=n;else if("undefined"!==n)throw new Error(`[override-property-read snippet]: Value "${n}" is not valid.`);r(window,t,{get:()=>(e(),l),set(){}})}function r(e,t,n){let l=t.indexOf(".");if(-1==l){let r=Object.getOwnPropertyDescriptor(e,t);if(r&&!r.configurable)return;let l=Object.assign({},n,{configurable:!0});if(!r&&!l.get&&l.set){let r=e[t];l.get=()=>r}return void Object.defineProperty(e,t,l)}let o=t.slice(0,l);t=t.slice(l+1);let s=e[o];!s||"object"!=typeof s&&"function"!=typeof s||r(s,t,n);let i=Object.getOwnPropertyDescriptor(e,o);i&&!i.configurable||Object.defineProperty(e,o,{get:()=>s,set:e=>{s=e,!e||"object"!=typeof e&&"function"!=typeof s||r(e,t,n)},configurable:!0})}let n={isOwnProperty:Object.prototype.hasOwnProperty};t("playerResponse.adPlacements","undefined"),t("ytInitialPlayerResponse.adPlacements","undefined"),function(t,r=""){if(!t)throw new Error("Missing paths to prune");let l=t.split(/ +/),o=""!==r?r.split(/ +/):[],s=JSON.parse,i={value(...t){let r;if(r=s.apply(this,t),o.length>0&&o.some((e=>!p(r,e))))return r;for(let t of l){let n=p(r,t);void 0!==n&&(e(),delete n[0][n[1]])}return r}};function p(e,t){if(!(e instanceof window.Object))return;let r=e,l=t.split(".");if(0===l.length)return;for(let e=0;e<l.length-1;e++){let t=l[e];if(!n.isOwnProperty.call(r,t))return;if(r=r[t],!(r instanceof window.Object))return}let o=l[l.length-1];return n.isOwnProperty.call(r,o)?[r,o]:void 0}Object.defineProperty(JSON,"parse",i)}("0.playerResponse.adPlacements 0.playerResponse.playerAds 1.playerResponse.adPlacements 1.playerResponse.playerAds 2.playerResponse.adPlacements 2.playerResponse.playerAds playerResponse.adPlacements playerResponse.playerAds ytInitialPlayerResponse.adPlacements ytInitialPlayerResponse.playerAds adPlacements playerAds adSlots")})();
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Filtering Rules

_Skipped binary or large file. Size: 2153681 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Filtering Rules-AA

_Skipped binary or large file. Size: 2395466 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Filtering Rules-CA

``text
�]�
google.com.af
google.com.ag
google.com.ai
google.com.ar
google.com.au
google.com.bd
google.com.bh
google.com.bi
google.com.bn
google.com.bo
google.com.br
google.com.by
google.com.bz
google.com.cn
google.com.co
google.com.cu
google.com.cy
google.com.do
google.com.dz
google.com.ec
google.com.eg
google.com.er
google.com.et
google.com.fj
google.com.ge
google.com.gh
google.com.gi
google.com.gp
google.com.gr
google.com.gt
google.com.gy
google.com.hk
google.com.ht
google.com.iq
google.com.jm
google.com.jo
google.com.kh
google.com.kw
google.com.kz
google.com.lb
google.com.lv
google.com.ly
google.com.mm
google.com.mt
google.com.mx
google.com.my
google.com.na
google.com.nc
google.com.nf
google.com.ng
google.com.ni
google.com.np
google.com.nr
google.com.om
google.com.pa
google.com.pe
google.com.pg
google.com.ph
google.com.pk
google.com.pl
google.com.pr
google.com.ps
google.com.pt
google.com.py
google.com.qa
google.com.ru
google.com.sa
google.com.sb
google.com.sg
google.com.sl
google.com.sv
google.com.tj
google.com.tm
google.com.tn
google.com.tr
google.com.tw
google.com.ua
google.com.uy
google.com.vc
google.com.ve
google.com.vn
google.off.ai
google.co.ao
google.co.bw
google.co.ck
google.co.cr
google.co.gy
google.co.hu
google.co.id
google.co.il
google.co.im
google.co.in
google.co.je
google.co.jp
google.co.ke
google.co.kr
google.co.ls
google.co.ma
google.co.mz
google.co.nz
google.co.rs
google.co.th
google.co.tz
google.co.ug
google.co.uk
google.co.uz
google.co.ve
google.co.vi
google.co.za
google.co.zm
google.co.zw
google.it.ao
google.ne.jp
google.info
google.jobs

google.cat

google.com

google.net

google.org

google.tel
	google.ac
	google.ad
	google.ae
	google.af
	google.ag
	google.al
	google.am
	google.as
	google.at
	google.aw
	google.az
	google.ba
	google.be
	google.bf
	google.bg
	google.bi
	google.bj
	google.bm
	google.bn
	google.bo
	google.bs
	google.bt
	google.by
	google.ca
	google.cc
	google.cd
	google.cf
	google.cg
	google.ch
	google.ci
	google.cl
	google.cm
	google.cn
	google.co
	google.cv
	google.cz
	google.de
	google.dj
	google.dk
	google.dm
	google.do
	google.dz
	google.ec
	google.ee
	google.es
	google.eu
	google.fi
	google.fm
	google.fr
	google.ga
	google.gd
	google.ge
	google.gf
	google.gg
	google.gl
	google.gm
	google.gp
	google.gr
	google.gw
	google.gy
	google.hk
	google.hn
	google.hr
	google.ht
	google.hu
	google.ie
	google.im
	google.in
	google.io
	google.iq
	google.is
	google.it
	google.je
	google.jo
	google.jp
	google.kg
	google.ki
	google.km
	google.kr
	google.kz
	google.la
	google.li
	google.lk
	google.lt
	google.lu
	google.lv
	google.ma
	google.md
	google.me
	google.mg
	google.mk
	google.ml
	google.mn
	google.mr
	google.ms
	google.mu
	google.mv
	google.mw
	google.mx
	google.ne
	google.ng
	google.nl
	google.no
	google.nr
	google.nu
	google.pf
	google.ph
	google.pk
	google.pl
	google.pn
	google.ps
	google.pt
	google.qa
	google.re
	google.ro
	google.rs
	google.ru
	google.rw
	google.sc
	google.se
	google.sg
	google.sh
	google.si
	google.sk
	google.sl
	google.sm
	google.sn
	google.so
	google.sr
	google.st
	google.sz
	google.td
	google.tg
	google.tk
	google.tl
	google.tm
	google.tn
	google.to
	google.tt
	google.tw
	google.ua
	google.us
	google.uz
	google.vg
	google.vn
	google.vu
	google.ws
	google.ytidiv[role="dialog"][aria-describedby="promo_desc_id"],div[role="dialog"][aria-labelledby="promo_label_id"]�
google.com.af
google.com.ag
google.com.ai
google.com.ar
google.com.au
google.com.bd
google.com.bh
google.com.bi
google.com.bn
google.com.bo
google.com.br
google.com.by
google.com.bz
google.com.cn
google.com.co
google.com.cu
google.com.cy
google.com.do
google.com.dz
google.com.ec
google.com.eg
google.com.er
google.com.et
google.com.fj
google.com.ge
google.com.gh
google.com.gi
google.com.gp
google.com.gr
google.com.gt
google.com.gy
google.com.hk
google.com.ht
google.com.iq
google.com.jm
google.com.jo
google.com.kh
google.com.kw
google.com.kz
google.com.lb
google.com.lv
google.com.ly
google.com.mm
google.com.mt
google.com.mx
google.com.my
google.com.na
google.com.nc
google.com.nf
google.com.ng
google.com.ni
google.com.np
google.com.nr
google.com.om
google.com.pa
google.com.pe
google.com.pg
google.com.ph
google.com.pk
google.com.pl
google.com.pr
google.com.ps
google.com.pt
google.com.py
google.com.qa
google.com.ru
google.com.sa
google.com.sb
google.com.sg
google.com.sl
google.com.sv
google.com.tj
google.com.tm
google.com.tn
google.com.tr
google.com.tw
google.com.ua
google.com.uy
google.com.vc
google.com.ve
google.com.vn
google.off.ai
google.co.ao
google.co.bw
google.co.ck
google.co.cr
google.co.gy
google.co.hu
google.co.id
google.co.il
google.co.im
google.co.in
google.co.je
google.co.jp
google.co.ke
google.co.kr
google.co.ls
google.co.ma
google.co.mz
google.co.nz
google.co.rs
google.co.th
google.co.tz
google.co.ug
google.co.uk
google.co.uz
google.co.ve
google.co.vi
google.co.za
google.co.zm
google.co.zw
google.it.ao
google.ne.jp
google.info
google.jobs

google.cat

google.com

google.net

google.org

google.tel
	google.ac
	google.ad
	google.ae
	google.af
	google.ag
	google.al
	google.am
	google.as
	google.at
	google.aw
	google.az
	google.ba
	google.be
	google.bf
	google.bg
	google.bi
	google.bj
	google.bm
	google.bn
	google.bo
	google.bs
	google.bt
	google.by
	google.ca
	google.cc
	google.cd
	google.cf
	google.cg
	google.ch
	google.ci
	google.cl
	google.cm
	google.cn
	google.co
	google.cv
	google.cz
	google.de
	google.dj
	google.dk
	google.dm
	google.do
	google.dz
	google.ec
	google.ee
	google.es
	google.eu
	google.fi
	google.fm
	google.fr
	google.ga
	google.gd
	google.ge
	google.gf
	google.gg
	google.gl
	google.gm
	google.gp
	google.gr
	google.gw
	google.gy
	google.hk
	google.hn
	google.hr
	google.ht
	google.hu
	google.ie
	google.im
	google.in
	google.io
	google.iq
	google.is
	google.it
	google.je
	google.jo
	google.jp
	google.kg
	google.ki
	google.km
	google.kr
	google.kz
	google.la
	google.li
	google.lk
	google.lt
	google.lu
	google.lv
	google.ma
	google.md
	google.me
	google.mg
	google.mk
	google.ml
	google.mn
	google.mr
	google.ms
	google.mu
	google.mv
	google.mw
	google.mx
	google.ne
	google.ng
	google.nl
	google.no
	google.nr
	google.nu
	google.pf
	google.ph
	google.pk
	google.pl
	google.pn
	google.ps
	google.pt
	google.qa
	google.re
	google.ro
	google.rs
	google.ru
	google.rw
	google.sc
	google.se
	google.sg
	google.sh
	google.si
	google.sk
	google.sl
	google.sm
	google.sn
	google.so
	google.sr
	google.st
	google.sz
	google.td
	google.tg
	google.tk
	google.tl
	google.tm
	google.tn
	google.to
	google.tt
	google.tw
	google.ua
	google.us
	google.uz
	google.vg
	google.vn
	google.vu
	google.ws
	google.ytdiv:has(#promo_label_id)J
ogs.google.com4div[role="dialog"]:has(a[href*="google.com/chrome"])�
google.com.af
google.com.ag
google.com.ai
google.com.ar
google.com.au
google.com.bd
google.com.bh
google.com.bi
google.com.bn
google.com.bo
google.com.br
google.com.by
google.com.bz
google.com.cn
google.com.co
google.com.cu
google.com.cy
google.com.do
google.com.dz
google.com.ec
google.com.eg
google.com.er
google.com.et
google.com.fj
google.com.ge
google.com.gh
google.com.gi
google.com.gp
google.com.gr
google.com.gt
google.com.gy
google.com.hk
google.com.ht
google.com.iq
google.com.jm
google.com.jo
google.com.kh
google.com.kw
google.com.kz
google.com.lb
google.com.lv
google.com.ly
google.com.mm
google.com.mt
google.com.mx
google.com.my
google.com.na
google.com.nc
google.com.nf
google.com.ng
google.com.ni
google.com.np
google.com.nr
google.com.om
google.com.pa
google.com.pe
google.com.pg
google.com.ph
google.com.pk
google.com.pl
google.com.pr
google.com.ps
google.com.pt
google.com.py
google.com.qa
google.com.ru
google.com.sa
google.com.sb
google.com.sg
google.com.sl
google.com.sv
google.com.tj
google.com.tm
google.com.tn
google.com.tr
google.com.tw
google.com.ua
google.com.uy
google.com.vc
google.com.ve
google.com.vn
google.off.ai
google.co.ao
google.co.bw
google.co.ck
google.co.cr
google.co.gy
google.co.hu
google.co.id
google.co.il
google.co.im
google.co.in
google.co.je
google.co.jp
google.co.ke
google.co.kr
google.co.ls
google.co.ma
google.co.mz
google.co.nz
google.co.rs
google.co.th
google.co.tz
google.co.ug
google.co.uk
google.co.uz
google.co.ve
google.co.vi
google.co.za
google.co.zm
google.co.zw
google.it.ao
google.ne.jp
google.info
google.jobs

google.cat

google.com

google.net

google.org

google.tel
	google.ac
	google.ad
	google.ae
	google.af
	google.ag
	google.al
	google.am
	google.as
	google.at
	google.aw
	google.az
	google.ba
	google.be
	google.bf
	google.bg
	google.bi
	google.bj
	google.bm
	google.bn
	google.bo
	google.bs
	google.bt
	google.by
	google.ca
	google.cc
	google.cd
	google.cf
	google.cg
	google.ch
	google.ci
	google.cl
	google.cm
	google.cn
	google.co
	google.cv
	google.cz
	google.de
	google.dj
	google.dk
	google.dm
	google.do
	google.dz
	google.ec
	google.ee
	google.es
	google.eu
	google.fi
	google.fm
	google.fr
	google.ga
	google.gd
	google.ge
	google.gf
	google.gg
	google.gl
	google.gm
	google.gp
	google.gr
	google.gw
	google.gy
	google.hk
	google.hn
	google.hr
	google.ht
	google.hu
	google.ie
	google.im
	google.in
	google.io
	google.iq
	google.is
	google.it
	google.je
	google.jo
	google.jp
	google.kg
	google.ki
	google.km
	google.kr
	google.kz
	google.la
	google.li
	google.lk
	google.lt
	google.lu
	google.lv
	google.ma
	google.md
	google.me
	google.mg
	google.mk
	google.ml
	google.mn
	google.mr
	google.ms
	google.mu
	google.mv
	google.mw
	google.mx
	google.ne
	google.ng
	google.nl
	google.no
	google.nr
	google.nu
	google.pf
	google.ph
	google.pk
	google.pl
	google.pn
	google.ps
	google.pt
	google.qa
	google.re
	google.ro
	google.rs
	google.ru
	google.rw
	google.sc
	google.se
	google.sg
	google.sh
	google.si
	google.sk
	google.sl
	google.sm
	google.sn
	google.so
	google.sr
	google.st
	google.sz
	google.td
	google.tg
	google.tk
	google.tl
	google.tm
	google.tn
	google.to
	google.tt
	google.tw
	google.ua
	google.us
	google.uz
	google.vg
	google.vn
	google.vu
	google.ws
	google.yt#stUuGf
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/LICENSE

``text
EasyList Repository Licences

   Unless otherwise noted, the contents of the EasyList repository
   (https://github.com/easylist) is dual licensed under the GNU General
   Public License version 3 of the License, or (at your option) any later
   version, and Creative Commons Attribution-ShareAlike 3.0 Unported, or
   (at your option) any later version. You may use and/or modify the files
   as permitted by either licence; if required, "The EasyList authors
   (https://easylist.to/)" should be attributed as the source of the
   material. All relevant licence files are included in the repository.

   Please be aware that files hosted externally and referenced in the
   repository, including but not limited to subscriptions other than
   EasyList, EasyPrivacy, EasyList Germany and EasyList Italy, may be
   available under other conditions; permission must be granted by the
   respective copyright holders to authorise the use of their material.


Creative Commons Attribution-ShareAlike 3.0 Unported

     CREATIVE COMMONS CORPORATION IS NOT A LAW FIRM AND DOES NOT PROVIDE
     LEGAL SERVICES. DISTRIBUTION OF THIS LICENSE DOES NOT CREATE AN
     ATTORNEY-CLIENT RELATIONSHIP. CREATIVE COMMONS PROVIDES THIS
     INFORMATION ON AN "AS-IS" BASIS. CREATIVE COMMONS MAKES NO
     WARRANTIES REGARDING THE INFORMATION PROVIDED, AND DISCLAIMS
     LIABILITY FOR DAMAGES RESULTING FROM ITS USE.

License

   THE WORK (AS DEFINED BELOW) IS PROVIDED UNDER THE TERMS OF THIS
   CREATIVE COMMONS PUBLIC LICENSE ("CCPL" OR "LICENSE"). THE WORK IS
   PROTECTED BY COPYRIGHT AND/OR OTHER APPLICABLE LAW. ANY USE OF THE WORK
   OTHER THAN AS AUTHORIZED UNDER THIS LICENSE OR COPYRIGHT LAW IS
   PROHIBITED.

   BY EXERCISING ANY RIGHTS TO THE WORK PROVIDED HERE, YOU ACCEPT AND
   AGREE TO BE BOUND BY THE TERMS OF THIS LICENSE. TO THE EXTENT THIS
   LICENSE MAY BE CONSIDERED TO BE A CONTRACT, THE LICENSOR GRANTS YOU THE
   RIGHTS CONTAINED HERE IN CONSIDERATION OF YOUR ACCEPTANCE OF SUCH TERMS
   AND CONDITIONS.

   1. Definitions
    a. "Adaptation" means a work based upon the Work, or upon the Work and
       other pre-existing works, such as a translation, adaptation,
       derivative work, arrangement of music or other alterations of a
       literary or artistic work, or phonogram or performance and includes
       cinematographic adaptations or any other form in which the Work may
       be recast, transformed, or adapted including in any form
       recognizably derived from the original, except that a work that
       constitutes a Collection will not be considered an Adaptation for
       the purpose of this License. For the avoidance of doubt, where the
       Work is a musical work, performance or phonogram, the
       synchronization of the Work in timed-relation with a moving image
       ("synching") will be considered an Adaptation for the purpose of
       this License.
    b. "Collection" means a collection of literary or artistic works, such
       as encyclopedias and anthologies, or performances, phonograms or
       broadcasts, or other works or subject matter other than works
       listed in Section 1(f) below, which, by reason of the selection and
       arrangement of their contents, constitute intellectual creations,
       in which the Work is included in its entirety in unmodified form
       along with one or more other contributions, each constituting
       separate and independent works in themselves, which together are
       assembled into a collective whole. A work that constitutes a
       Collection will not be considered an Adaptation (as defined below)
       for the purposes of this License.
    c. "Creative Commons Compatible License" means a license that is
       listed at https://creativecommons.org/compatiblelicenses that has
       been approved by Creative Commons as being essentially equivalent
       to this License, including, at a minimum, because that license: (i)
       contains terms that have the same purpose, meaning and effect as
       the License Elements of this License; and, (ii) explicitly permits
       the relicensing of adaptations of works made available under that
       license under this License or a Creative Commons jurisdiction
       license with the same License Elements as this License.
    d. "Distribute" means to make available to the public the original and
       copies of the Work or Adaptation, as appropriate, through sale or
       other transfer of ownership.
    e. "License Elements" means the following high-level license
       attributes as selected by Licensor and indicated in the title of
       this License: Attribution, ShareAlike.
    f. "Licensor" means the individual, individuals, entity or entities
       that offer(s) the Work under the terms of this License.
    g. "Original Author" means, in the case of a literary or artistic
       work, the individual, individuals, entity or entities who created
       the Work or if no individual or entity can be identified, the
       publisher; and in addition (i) in the case of a performance the
       actors, singers, musicians, dancers, and other persons who act,
       sing, deliver, declaim, play in, interpret or otherwise perform
       literary or artistic works or expressions of folklore; (ii) in the
       case of a phonogram the producer being the person or legal entity
       who first fixes the sounds of a performance or other sounds; and,
       (iii) in the case of broadcasts, the organization that transmits
       the broadcast.
    h. "Work" means the literary and/or artistic work offered under the
       terms of this License including without limitation any production
       in the literary, scientific and artistic domain, whatever may be
       the mode or form of its expression including digital form, such as
       a book, pamphlet and other writing; a lecture, address, sermon or
       other work of the same nature; a dramatic or dramatico-musical
       work; a choreographic work or entertainment in dumb show; a musical
       composition with or without words; a cinematographic work to which
       are assimilated works expressed by a process analogous to
       cinematography; a work of drawing, painting, architecture,
       sculpture, engraving or lithography; a photographic work to which
       are assimilated works expressed by a process analogous to
       photography; a work of applied art; an illustration, map, plan,
       sketch or three-dimensional work relative to geography, topography,
       architecture or science; a performance; a broadcast; a phonogram; a
       compilation of data to the extent it is protected as a
       copyrightable work; or a work performed by a variety or circus
       performer to the extent it is not otherwise considered a literary
       or artistic work.
    i. "You" means an individual or entity exercising rights under this
       License who has not previously violated the terms of this License
       with respect to the Work, or who has received express permission
       from the Licensor to exercise rights under this License despite a
       previous violation.
    j. "Publicly Perform" means to perform public recitations of the Work
       and to communicate to the public those public recitations, by any
       means or process, including by wire or wireless means or public
       digital performances; to make available to the public Works in such
       a way that members of the public may access these Works from a
       place and at a place individually chosen by them; to perform the
       Work to the public by any means or process and the communication to
       the public of the performances of the Work, including by public
       digital performance; to broadcast and rebroadcast the Work by any
       means including signs, sounds or images.
    k. "Reproduce" means to make copies of the Work by any means including
       without limitation by sound or visual recordings and the right of
       fixation and reproducing fixations of the Work, including storage
       of a protected performance or phonogram in digital form or other
       electronic medium.

   2. Fair Dealing Rights. Nothing in this License is intended to reduce,
   limit, or restrict any uses free from copyright or rights arising from
   limitations or exceptions that are provided for in connection with the
   copyright protection under copyright law or other applicable laws.

   3. License Grant. Subject to the terms and conditions of this License,
   Licensor hereby grants You a worldwide, royalty-free, non-exclusive,
   perpetual (for the duration of the applicable copyright) license to
   exercise the rights in the Work as stated below:
    a. to Reproduce the Work, to incorporate the Work into one or more
       Collections, and to Reproduce the Work as incorporated in the
       Collections;
    b. to create and Reproduce Adaptations provided that any such
       Adaptation, including any translation in any medium, takes
       reasonable steps to clearly label, demarcate or otherwise identify
       that changes were made to the original Work. For example, a
       translation could be marked "The original work was translated from
       English to Spanish," or a modification could indicate "The original
       work has been modified.";
    c. to Distribute and Publicly Perform the Work including as
       incorporated in Collections; and,
    d. to Distribute and Publicly Perform Adaptations.
    e. For the avoidance of doubt:
         i. Non-waivable Compulsory License Schemes. In those
            jurisdictions in which the right to collect royalties through
            any statutory or compulsory licensing scheme cannot be waived,
            the Licensor reserves the exclusive right to collect such
            royalties for any exercise by You of the rights granted under
            this License;
        ii. Waivable Compulsory License Schemes. In those jurisdictions in
            which the right to collect royalties through any statutory or
            compulsory licensing scheme can be waived, the Licensor waives
            the exclusive right to collect such royalties for any exercise
            by You of the rights granted under this License; and,
        iii. Voluntary License Schemes. The Licensor waives the right to
            collect royalties, whether individually or, in the event that
            the Licensor is a member of a collecting society that
            administers voluntary licensing schemes, via that society,
            from any exercise by You of the rights granted under this
            License.

   The above rights may be exercised in all media and formats whether now
   known or hereafter devised. The above rights include the right to make
   such modifications as are technically necessary to exercise the rights
   in other media and formats. Subject to Section 8(f), all rights not
   expressly granted by Licensor are hereby reserved.

   4. Restrictions. The license granted in Section 3 above is expressly
   made subject to and limited by the following restrictions:
    a. You may Distribute or Publicly Perform the Work only under the
       terms of this License. You must include a copy of, or the Uniform
       Resource Identifier (URI) for, this License with every copy of the
       Work You Distribute or Publicly Perform. You may not offer or
       impose any terms on the Work that restrict the terms of this
       License or the ability of the recipient of the Work to exercise the
       rights granted to that recipient under the terms of the License.
       You may not sublicense the Work. You must keep intact all notices
       that refer to this License and to the disclaimer of warranties with
       every copy of the Work You Distribute or Publicly Perform. When You
       Distribute or Publicly Perform the Work, You may not impose any
       effective technological measures on the Work that restrict the
       ability of a recipient of the Work from You to exercise the rights
       granted to that recipient under the terms of the License. This
       Section 4(a) applies to the Work as incorporated in a Collection,
       but this does not require the Collection apart from the Work itself
       to be made subject to the terms of this License. If You create a
       Collection, upon notice from any Licensor You must, to the extent
       practicable, remove from the Collection any credit as required by
       Section 4(c), as requested. If You create an Adaptation, upon
       notice from any Licensor You must, to the extent practicable,
       remove from the Adaptation any credit as required by Section 4(c),
       as requested.
    b. You may Distribute or Publicly Perform an Adaptation only under the
       terms of: (i) this License; (ii) a later version of this License
       with the same License Elements as this License; (iii) a Creative
       Commons jurisdiction license (either this or a later license
       version) that contains the same License Elements as this License
       (e.g., Attribution-ShareAlike 3.0 US)); (iv) a Creative Commons
       Compatible License. If you license the Adaptation under one of the
       licenses mentioned in (iv), you must comply with the terms of that
       license. If you license the Adaptation under the terms of any of
       the licenses mentioned in (i), (ii) or (iii) (the "Applicable
       License"), you must comply with the terms of the Applicable License
       generally and the following provisions: (I) You must include a copy
       of, or the URI for, the Applicable License with every copy of each
       Adaptation You Distribute or Publicly Perform; (II) You may not
       offer or impose any terms on the Adaptation that restrict the terms
       of the Applicable License or the ability of the recipient of the
       Adaptation to exercise the rights granted to that recipient under
       the terms of the Applicable License; (III) You must keep intact all
       notices that refer to the Applicable License and to the disclaimer
       of warranties with every copy of the Work as included in the
       Adaptation You Distribute or Publicly Perform; (IV) when You
       Distribute or Publicly Perform the Adaptation, You may not impose
       any effective technological measures on the Adaptation that
       restrict the ability of a recipient of the Adaptation from You to
       exercise the rights granted to that recipient under the terms of
       the Applicable License. This Section 4(b) applies to the Adaptation
       as incorporated in a Collection, but this does not require the
       Collection apart from the Adaptation itself to be made subject to
       the terms of the Applicable License.
    c. If You Distribute, or Publicly Perform the Work or any Adaptations
       or Collections, You must, unless a request has been made pursuant
       to Section 4(a), keep intact all copyright notices for the Work and
       provide, reasonable to the medium or means You are utilizing: (i)
       the name of the Original Author (or pseudonym, if applicable) if
       supplied, and/or if the Original Author and/or Licensor designate
       another party or parties (e.g., a sponsor institute, publishing
       entity, journal) for attribution ("Attribution Parties") in
       Licensor's copyright notice, terms of service or by other
       reasonable means, the name of such party or parties; (ii) the title
       of the Work if supplied; (iii) to the extent reasonably
       practicable, the URI, if any, that Licensor specifies to be
       associated with the Work, unless such URI does not refer to the
       copyright notice or licensing information for the Work; and (iv) ,
       consistent with Ssection 3(b), in the case of an Adaptation, a
       credit identifying the use of the Work in the Adaptation (e.g.,
       "French translation of the Work by Original Author," or "Screenplay
       based on original Work by Original Author"). The credit required by
       this Section 4(c) may be implemented in any reasonable manner;
       provided, however, that in the case of a Adaptation or Collection,
       at a minimum such credit will appear, if a credit for all
       contributing authors of the Adaptation or Collection appears, then
       as part of these credits and in a manner at least as prominent as
       the credits for the other contributing authors. For the avoidance
       of doubt, You may only use the credit required by this Section for
       the purpose of attribution in the manner set out above and, by
       exercising Your rights under this License, You may not implicitly
       or explicitly assert or imply any connection with, sponsorship or
       endorsement by the Original Author, Licensor and/or Attribution
       Parties, as appropriate, of You or Your use of the Work, without
       the separate, express prior written permission of the Original
       Author, Licensor and/or Attribution Parties.
    d. Except as otherwise agreed in writing by the Licensor or as may be
       otherwise permitted by applicable law, if You Reproduce, Distribute
       or Publicly Perform the Work either by itself or as part of any
       Adaptations or Collections, You must not distort, mutilate, modify
       or take other derogatory action in relation to the Work which would
       be prejudicial to the Original Author's honor or reputation.
       Licensor agrees that in those jurisdictions (e.g. Japan), in which
       any exercise of the right granted in Section 3(b) of this License
       (the right to make Adaptations) would be deemed to be a distortion,
       mutilation, modification or other derogatory action prejudicial to
       the Original Author's honor and reputation, the Licensor will waive
       or not assert, as appropriate, this Section, to the fullest extent
       permitted by the applicable national law, to enable You to
       reasonably exercise Your right under Section 3(b) of this License
       (right to make Adaptations) but not otherwise.

   5. Representations, Warranties and Disclaimer

   UNLESS OTHERWISE MUTUALLY AGREED TO BY THE PARTIES IN WRITING, LICENSOR
   OFFERS THE WORK AS-IS AND MAKES NO REPRESENTATIONS OR WARRANTIES OF ANY
   KIND CONCERNING THE WORK, EXPRESS, IMPLIED, STATUTORY OR OTHERWISE,
   INCLUDING, WITHOUT LIMITATION, WARRANTIES OF TITLE, MERCHANTIBILITY,
   FITNESS FOR A PARTICULAR PURPOSE, NONINFRINGEMENT, OR THE ABSENCE OF
   LATENT OR OTHER DEFECTS, ACCURACY, OR THE PRESENCE OF ABSENCE OF
   ERRORS, WHETHER OR NOT DISCOVERABLE. SOME JURISDICTIONS DO NOT ALLOW
   THE EXCLUSION OF IMPLIED WARRANTIES, SO SUCH EXCLUSION MAY NOT APPLY TO
   YOU.

   6. Limitation on Liability. EXCEPT TO THE EXTENT REQUIRED BY APPLICABLE
   LAW, IN NO EVENT WILL LICENSOR BE LIABLE TO YOU ON ANY LEGAL THEORY FOR
   ANY SPECIAL, INCIDENTAL, CONSEQUENTIAL, PUNITIVE OR EXEMPLARY DAMAGES
   ARISING OUT OF THIS LICENSE OR THE USE OF THE WORK, EVEN IF LICENSOR
   HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.

   7. Termination
    a. This License and the rights granted hereunder will terminate
       automatically upon any breach by You of the terms of this License.
       Individuals or entities who have received Adaptations or
       Collections from You under this License, however, will not have
       their licenses terminated provided such individuals or entities
       remain in full compliance with those licenses. Sections 1, 2, 5, 6,
       7, and 8 will survive any termination of this License.
    b. Subject to the above terms and conditions, the license granted here
       is perpetual (for the duration of the applicable copyright in the
       Work). Notwithstanding the above, Licensor reserves the right to
       release the Work under different license terms or to stop
       distributing the Work at any time; provided, however that any such
       election will not serve to withdraw this License (or any other
       license that has been, or is required to be, granted under the
       terms of this License), and this License will continue in full
       force and effect unless terminated as stated above.

   8. Miscellaneous
    a. Each time You Distribute or Publicly Perform the Work or a
       Collection, the Licensor offers to the recipient a license to the
       Work on the same terms and conditions as the license granted to You
       under this License.
    b. Each time You Distribute or Publicly Perform an Adaptation,
       Licensor offers to the recipient a license to the original Work on
       the same terms and conditions as the license granted to You under
       this License.
    c. If any provision of this License is invalid or unenforceable under
       applicable law, it shall not affect the validity or enforceability
       of the remainder of the terms of this License, and without further
       action by the parties to this agreement, such provision shall be
       reformed to the minimum extent necessary to make such provision
       valid and enforceable.
    d. No term or provision of this License shall be deemed waived and no
       breach consented to unless such waiver or consent shall be in
       writing and signed by the party to be charged with such waiver or
       consent.
    e. This License constitutes the entire agreement between the parties
       with respect to the Work licensed here. There are no
       understandings, agreements or representations with respect to the
       Work not specified here. Licensor shall not be bound by any
       additional provisions that may appear in any communication from
       You. This License may not be modified without the mutual written
       agreement of the Licensor and You.
    f. The rights granted under, and the subject matter referenced, in
       this License were drafted utilizing the terminology of the Berne
       Convention for the Protection of Literary and Artistic Works (as
       amended on September 28, 1979), the Rome Convention of 1961, the
       WIPO Copyright Treaty of 1996, the WIPO Performances and Phonograms
       Treaty of 1996 and the Universal Copyright Convention (as revised
       on July 24, 1971). These rights and subject matter take effect in
       the relevant jurisdiction in which the License terms are sought to
       be enforced according to the corresponding provisions of the
       implementation of those treaty provisions in the applicable
       national law. If the standard suite of rights granted under
       applicable copyright law includes additional rights not granted
       under this License, such additional rights are deemed to be
       included in the License; this License is not intended to restrict
       the license of any rights under applicable law.

Creative Commons Notice

     Creative Commons is not a party to this License, and makes no
     warranty whatsoever in connection with the Work. Creative Commons
     will not be liable to You or any party on any legal theory for any
     damages whatsoever, including without limitation any general,
     special, incidental or consequential damages arising in connection
     to this license. Notwithstanding the foregoing two (2) sentences, if
     Creative Commons has expressly identified itself as the Licensor
     hereunder, it shall have all rights and obligations of Licensor.

     Except for the limited purpose of indicating to the public that the
     Work is licensed under the CCPL, Creative Commons does not authorize
     the use by either party of the trademark "Creative Commons" or any
     related trademark or logo of Creative Commons without the prior
     written consent of Creative Commons. Any permitted use will be in
     compliance with Creative Commons' then-current trademark usage
     guidelines, as may be published on its website or otherwise made
     available upon request from time to time. For the avoidance of
     doubt, this trademark restriction does not form part of the License.

     Creative Commons may be contacted at https://creativecommons.org/.
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/manifest.json

``json
{
  "manifest_version": 2,
  "name": "Subresource Filter Rules",
  "ruleset_format": 1,
  "version": "10.34.0.84"
}

````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-DE

_Skipped binary or large file. Size: 312807 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-ES

_Skipped binary or large file. Size: 140844 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-FR

_Skipped binary or large file. Size: 540971 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-IT

_Skipped binary or large file. Size: 221404 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-NL

``text
�
!��08@R-reclameplaatjes/
��08@R/adbron.
��08@R/adtwee/
 ��08@R/adv_tekstlinks.
��08@R/adverteerders/
$��08@R/advertentie-banner-
���*
anzeigen-aufgabe-alpha.de*
anzeigen-aufgabe-beta.de*
anzeigen-aufgabe-test.de*	
rd.nl08@R/advertentie.
���*
anzeigen-aufgabe-alpha.de*
anzeigen-aufgabe-beta.de*
anzeigen-aufgabe-test.de*	
rd.nl08@R/advertentie/
��08@R/advertentie1.
��08@R/advertentie2/
"��08@R/advertentie_head.
)��08@R/advertentieblokje120x20.
)��08@R/advertentieblokje300x20.
��08@R/advertenties.
��08@R/advertenties/
��08@R/bannerlookup.
��08@R/big_reclames/
:��08@R*/bolcom-partnerprogramma-wordpress-plugin/
��08@R
/img/recl/
��08@R/mediahuis-ads/
��08@R	/nmc/adv/
��08@R/pebble-adhese.
%��08@R/prikbordAdvertentie_
��08@R/reclame-extra.
 ��08@R/reclame-nieuws.
��08@R
/reclame2.
 ��08@R/reclamebanners/
 ��08@R/small_reclames/
#��08@R/tekst_advertentie_
 ��08@R/topadvertentie.
��08@R://promotie.
$��08@R_advertentie300x250_
,��08@R_advertentieleaderboardhome.
��08@R2k19.nl^
��08@Radrequest.net^
��08@Radshim.com^
��08@R
adswag.nl^
��08@Raffilaxy.com^
&��08@Raffiliatepartners.com^
&��08@Raffiliateprogramma.eu^
!��08@Rbanner-online.nl^
$��08@Rbelieve-the-hype.be^
��08@R
botndm.nl^
 ��08@Rcashpartners.eu^
��08@Rcrnsgngrpj.nl^
��08@Rdntblckmpls.nl^
��08@Rds1.nl^
��08@R	dt51.net^
��08@R	dt71.net^
"��08@Rgratis-neuken.com^
��08@R	mt67.net^
��08@R
nojazz.eu^
#��08@Rnonstoppartner.net^
"��08@Ronline-banners.nl^
&��08@Roptoutadvertising.com^
��08@Rpublize.net^
!��08@Rsponsorkliks.com^
 ��08@Rstatic-dscn.net^
!��08@Rtools-affil2.com^
 ��08@Rtools.islive.nl^
��08@Rtravelads.be^
��08@Rtrickyrock.com^
��08@Rviadata.store^
��08@Rvpscash.nl^�
��08@Rxpartners.nl^
/ *
start-player.npo.nl08@R
.nl/adurl/
��08@Radcdn.ster.nl^
"��08@Rads.nextday.media^
/��08@Radvertising-cdn.dpgmedia.cloud^
6��08@R&advertising-module.api.dpgmedia.cloud^
(��08@Rbannersimages.s-bol.com^
,��08@Rbnpparibasmarkets.nl/widget/
*��08@Rbol.com/nl/upload/banners/
3��08@R#bol.com/nl/upload/partnerprogramma/
H��08@R8centraal.helpmij.nl/images/nieuwsbrief/nod32-colofon.jpg
E��*
feyenoord.nl08@R%cloudfront.net/-/media/6-parnerships/
F��*
feyenoord.nl08@R&cloudfront.net/Assets/images/partners/
8��*
eredivisie.nl08@Rcloudfront.net/banners/
4��08@R$feenstra-internetservices.nl/?_dnid=
*��08@Rflexwebhosting.nl/banners/
"��08@Rfx.nl/_ext/widget/
!��08@Rgo2.go2cloud.org^
.��08@Rinfotalia.com/worktalia_promo_
:��08@R*jobat.be/extra/trackuityhn/ticker_new.html
"��08@Rjobfish.nl/widget/
1��08@R!kjdsfjisdfjr23.azurewebsites.net^
��08@Rmmcdn.nl/tags/
2��08@R"nextdaymedia-ads.s3.amazonaws.com^
4��*

viafora.nl08@Rouders.nl/uploads/alt/
 ��08@Rpartner.bol.com^
)��08@Rpartnerprogramma.bol.com^
7��*
intermediair.nl08@Rpexi.nl/dpos/widget-
08@Rpornokartel.nl^
6��08@R&pubble.nl/Content.svc/getAdCollection?
4��08@R$recreatief.nl/kerstarrangementen.gif
5��08@R%s-bol.com/nl/upload/partnerprogramma/
.��08@Rsearch-result.com^*/klokad2.js
*��08@Rsedproductions.nl/banners/
$��08@Rseks.com/img/bnr.gif
2��08@R"seksbuddy.nl/img/frontend/banners/
.��08@Rsociaaldigitaal.nl/img/Banner-
 ��08@Rsp.dpgmedia.net^
0��08@R stepstone.be/*?event=widgettool.
4��08@R$strafrechtadvocaten.nl/media/banner/
3��08@R#swpportal.com/upload/squarebanners/
��08@Rt.bazarow.com^
$��08@Rtraffic.12flirt.com^
���*
albrandswaardsdagblad.nl*
barendrechtsdagblad.nl*
ridderkerksdagblad.nl*
zoetermeersdagblad.nl*
rijswijksdagblad.nl*
voorburgsdagblad.nl*
goudsdagblad.nl*
startpagina.nl*
dagblad010.nl*
dagblad070.nl*	
sgxl.nl08@Rviralize.tv/display/
/ 08@R!wertuipsertj34.azurewebsites.net^
8��*
nzbserver.com08@Rwidget.vpnnederland.nl^
8��*
puuropreis.nl08@Rwidgets.skyscanner.net^
c��*
groentennieuws.nl*
uiennieuws.nl*
bpnieuws.nl*
agf.nl08@Rwindows.net/banners/
>��08@R.wp.com/www.bol.com/nl/upload/partnerprogramma/
?��08@R/xmissy.nl/admnfiles1809/sinclub/freechatbanner_
&��08@R123video.nl^*/300x100_
��08@R1twente.nl/Ads/
0��08@R 24cars.nl/api/advertise-deliver/
!��08@R2link.be/banners/
��08@Raa.tweakers.nl^
G��08@R7aafm.nl/cms/wp-content/themes/omroepalmelo/img/banners/
/��08@Rabcsuriname.com/images/banners/
-��08@Radodenhaag.nl/images/banners/
;��08@R+agconnect.nl/sites/ag/files/styles/partner_
7��08@R'am-forum.nl/upload/logo_elektrodump.png
6��08@R&antilliaansdagblad.com/images/banners/
#��08@Rapintie.sr/bannerz/
+��08@Rautosport.nl/images/Banner-
,��08@Rautosport.nl/images/banners/�
@��08@R0baarsclassicrock.nl/wp-content/uploads/*/banner_
9��08@R)bdsm-vrienden.nl/sb_data/modules/mod_aav/
$��08@Rbdsmgirl.nl/banners/
%��08@Rbdsmgirl.nl^*/banner/
,��08@Rbelgiancycling.be^*/Banners/
8��08@R(belgiancycling.be^*/Logo%27s%20partners/
1��08@R!bloovi.be/frontend/files/banners/
6��08@R&bodemvondstenwereld.nl/images/banners/
<��08@R,boek9.nl/sites/default/files/advertisements/
>��08@R.boek9.nl/sites/default/files/rotating-banners/
3��08@R#bol-an.nl/wp-content/uploads/*/Adv_
5��08@R%brandweerspotters.nl/modules/banners/
+��08@Rbuzzbie.nl/uploads/banners/
%��08@Rcdn-tmo.nl^*/banners/
,��08@Rcdn-webcam-harlingen.nl/adv/
/��08@Rchatmetvreemden.be/static/html/
/��08@Rchatmetvreemden.nl/static/html/
.��08@Rchristelijknieuws.nl^*/banner/
7��08@R'ciaotutti.nl/wp-content/uploads/Banner_
(��08@Rclubbrugge.be^*/partner/
1��08@R!coastline945fm.nl/cache/partners/
.��08@Rcoastlinefm.nl/cache/partners/
#��08@Rcontent1.pcmweb.nl^
��08@Rcontent1.pu.nl^
(��08@Rcontent1.wasmachines.nl^
!��08@Rcontent1.zoom.nl^
)��08@Rcontent2.besteproduct.nl^
'��08@Rcontent2.kieskeurig.nl^
��08@Rcontent2.pu.nl^
(��08@Rcontent2.wasmachines.nl^
!��08@Rcontent2.zoom.nl^
>��08@R.cryptobenelux.com/wp-content/uploads/*-banner-
>��08@R.cryptobenelux.com/wp-content/uploads/*-Banner.
>��08@R.cryptobenelux.com/wp-content/uploads/*/banner_
7��08@R'cryptoprijzen.com/cryptoprijzen-widget/
2��08@R"debestevpn.nl/wp-content/*-banner.
7��08@R'decibel.nl/wp-content/uploads/*/banner-
5��08@R%dewereldmorgen.be/wp-content/banners/
L��08@R<digitaalburg.com/rn02/wp-content/uploads/*/CornetAnimationA-
F��08@R6digitaalburg.com/rn02/wp-content/uploads/*/MERKX11.png
C��08@R3digitaalburg.com/rn02/wp-content/uploads/*/Roel.jpg
I��08@R9digitaalburg.com/rn02/wp-content/uploads/*/uitwaard21.jpg
D��08@R4digitaalburg.com/rn02/wp-content/uploads/*/Vacature-
G��08@R7digitaalburg.com/rn02/wp-content/uploads/*/vertiadvies_
E��08@R5digitaalburg.com/rn02/wp-content/uploads/*/webbanner-
'��08@Rdolcevia.com^*/Banners/
+��08@Rduurzaam-actueel.nl^*banner
6��08@R&edelmetaal-info.nl/cdfund-336x280.html
J��08@R:edelmetaal-info.nl/wp-content/uploads/images/goudpensioen/
4��08@R$eredivisie.nl/images/logos/partners/
1��08@R!excellentfm.nl/images/aanbieding/
8��08@R(fanclubbarcelona.nl/viewfile/mainbanner/
,��08@Rfarmaline.be/assets/banners/
(��08@Rfcupdate.nl/js/adslot.js
*��08@Rfcutrecht.net/img/banners/
/��08@Rflirtmee.nl/img/160x70_sponsor-
)��08@Rfloranews.com/img/banner/
%��08@Rfonkmagazine.nl/adds/
#��08@Rfonkonline.nl/adds/
5��08@R%forum.spaarinformatie.nl/si-info.html
,��08@Rgenemuidenactueel.nl^*banner
,��08@Rgic.nl/uploads/fckconnector/
8��08@R(gigantfm.nl/upload/20170420110645812.jpg
8��08@R(gigantfm.nl/upload/20210730122903794.gif�
9��08@R)gigantfm.nl/upload/autoonderdelen24_1.png
5��08@R%gigantfm.nl/upload/onderdelenshop.gif
U��08@REgoedkoopstekeukensduitsland.nl/wp-content/uploads/*/I-kook-banner.jpg
_��08@ROgoedkoopstekeukensduitsland.nl/wp-content/uploads/*/Keuken-ontwerp-aan-huis.jpg
T��08@RDgoedkoopstekeukensduitsland.nl/wp-content/uploads/*/Keukenplaats.jpg
*��08@Rgolf.be/files/BannerImage/
)��08@Rgratissextube.be/banners/
.��08@Rgreenkeeper.nl/upload/banners/
/��08@Rgreenkeeper.nl/upload/relaties/
,��08@Rgroentennieuws.nl^*/banners/
2��08@R"halstadcentraal.nl/images/banners/
;��08@R+handbalstartpunt.nl/content/schoonkapje.gif
;��08@R+handbalstartpunt.nl/images/mizuno-small.jpg
(��08@Rhoekschnieuws.nl/banner/
=��08@R-hoekschnieuws.nl/wp-content/uploads/*/Banner-
7��08@R'hotradiohits.nl/image/picture/*_banner.
/��08@Rhtforum.nl/yabbse/*-banner2.gif
*��08@Rhtforum.nl/yabbse/banners/
1��08@R!htforum.nl/yabbse/topframe_v3.php
'��08@Riex.nl/uploads/banners/
9��08@R)katholiek.nl/wp-content/uploads/*/banner-
8��08@R(kavelplatform.nl/assets/uploads/banners/
&��08@Rkilroynews.net^*banner
6��08@R&klokradio.nl/wp-content/uploads/*/adv-
)��08@Rkranenwebsite.nl/banners/
(��08@Rlandenweb.nl/imgBoeking/
5��08@R%linqmedia.nl/cwm/fm/userfiles/banner/
K��08@R;loemedia.nl/wp-content/uploads/*/BannerPruisSchilderwerken-
A��08@R1loemedia.nl/wp-content/uploads/*/HemaBannerGroot-
7��08@R'lokaleomroepzeewolde.nl/images/banners/
7��08@R'luister.nl/wp-content/uploads/*/Banner_
*��08@Rmaarkelsnieuws.nl/banners/
>��08@R.maaslandradio.nl/wp-content/uploads/*/autodoc.
=��08@R-maaslandradio.nl/wp-content/uploads/*/Banner-
B��08@R2maaslandradio.nl/wp-content/uploads/*/Hekwerkland.
+��08@Rmandelnieuws.be^*/Sponsors/
<��08@R,mannennieuws.nl/wp-content/uploads/*-banner.
<��08@R,marktplaats.nl/*/api/complementary-listings?
-��08@Rmeerdangewenst.nl^*/sponsors/
$��08@Rmetalfan.nl/banners/
0��08@R midvliet.nl/images/advertenties-
2��08@R"mo.be/sites/default/files/banners/
*��08@Rmotocrossplanet.nl/banner/
6��08@R&motocrossplanet.nl/wwwuploads/banners/
9��08@R)motokicx.com/wp-content/uploads/*/BANNER-
=��08@R-motokicx.com/wp-content/uploads/*/Website-ad-
,��08@Rnetonline.be/slices/banners/
$��08@Rnevobo.nl^*/sponsor/
)��08@Rniburu.co/images/banners/
B��08@R2nieuwsopbeeld.nl/wp-content/uploads/*/Advertentie-
1��08@R!nieuwsuitnijmegen.nl/gfx/banners/
5��08@R%nieuwsuitnijmegen.nl/uploads/banners/
-��08@Rnoordkopcentraal.nl^*/banner_
8 08@R*notebookcheck.nl/fileadmin/Sonstiges/amaz_
!��08@Rnrc.nl/tag/tag.js
'��08@Romroeppenm.nl^*/banner/
0��08@R onderwijsland.com/files/banners/
1��08@R!onderwijsland.com/files/partners/
'��08@Ronlinecorrectie.nl/cnc/
;��08@R+ontdek-amerika.nl/marketing/bartsbanner.gif
,��08@Roogtv.nl/wp-content/banners/
��08@Roops.nl/banner/
?��08@R/openingsurengids.be/includes/js/checkblockv2.js
:��08@R*openingsurengids.be/template/images/publi/�
'��08@Ropwindend.net/Promotie/
&��08@Rpdd-nos.nl/footer.html
1��08@R!persberichten.com/Images/Banners/
3��08@R#persberichten.com/Images/marcommit/
C��08@R3popinstituut.nl/wp-content/uploads/2014/02/Huren.nl
M��08@R=pornokartel.nl/wp-content/uploads/*/wp-script-leaderboard.gif
7��08@R'promootjesite.nl/images/affliateBanner/
:��08@R*propertynl.com/media/organization/banners/
0��08@R puurnaturisme.nl/images/banners/
*��08@Rracexpress.nl/advertising/
0��08@R racingnews365.nl/images/banners/
)��08@Rradioacacia.nl/sponsoren/
C��08@R3radioeenhoorn.nl/images/Maxaro-badkamers-tegels.png
8��08@R(radiolelystad.nl/images/stories/Banners/
&��08@Rradioluisteren.fm/ads/
8��08@R(radionl.fm/wp-content/uploads/*/Maxiaxi_
2��08@R"radiostadmontfoort.nl/cms/img/ads/
1��08@R!radiovisie.eu/wp-content/banners/
9��08@R)railhobby.nl/wp-content/uploads/*_banner-
 ��08@Rrd.nl/deliver.js
V��*
voetbalverslaafd.nl*

topgear.nl08@R!resources.planetnine.com/scripts/
;��08@R+retaildetail.be/sites/default/files/banner/
;��08@R+retaildetail.nl/sites/default/files/banner/
2��08@R"rickfm.nl/cwm/fm/userfiles/banner/
.��08@Rrivierenland-radio.nl/banners/
8��08@R(rtvdordrecht.nl/cwm/fm/userfiles/banner/
6��08@R&rtveen.nl/wp-content/uploads/*-Banner-
6��08@R&rtveen.nl/wp-content/uploads/*/banner-
F��08@R6rtvlansingerland.nl/wp-content/uploads/*/Zorgvilla.gif
)��08@Rrtvmaastricht.nl/banners/
"��08@Rrtvnof.nl/prowurk/
'��08@Rschie.nu/images/banner/
,��08@Rschuttevaer.nl/partnersites/
0��08@R seksverhalen.org/telefoonsex.png
0��08@R seksverhalen.org/vluggertjes.png
1��08@R!sexchatlounge.nl/bannerlinks.html
2��08@R"sexchatlounge.nl/bannerrechts.html
,��08@Rsexervaringendelen.nl/porno/
6��08@R&simone.nl/wp-content/uploads/*-banner-
B��08@R2simone.nl/wp-content/uploads/*-besteonderdelen.nl-
C��08@R3simone.nl/wp-content/uploads/*-onderdelenexpert.nl-
@��08@R0simone.nl/wp-content/uploads/*/tijdelijkkkkk.png
)��08@Rsolarmagazine.nl/u/edwin/
:��08@R*spreekbuis.nl/wp-content/uploads/*-banner-
:��08@R*spreekbuis.nl/wp-content/uploads/*/Banner-
0��08@R srherald.com/wp-content/banners/
<��08@R,streamwijzer.be/wp-content/uploads/*-banner.
(��08@Rte-les-koop.nl/images/B_
6��08@R&techgaming.nl/image_uploads/sponsored/
A��08@R1tennisplaza.be/wp-content/uploads/*/tennisdirect-
>��08@R.tennisvlaanderen.be/documents/*/19Sponsorblok-
>��08@R.tennisvlaanderen.be/documents/*/21Sponsorblok-
��08@Rtijd.be/ad/
5��08@R%touretappe.nl/images/topposblock.html
*��08@Rtouretappe.nl/images/xtra/
"��08@Rtpo.nl/broodplank/
%��08@Rtradeidee.nl/banners/
A��08@R1transport-online.nl/site/includes/uploads/banner-
-��08@Rtvvisie.be/textads/textads.js
I��08@R9twentefm.nl/directcast/custom/rtvnot/playout/commercials/
'��08@Ruecl-voetbal.nl/derden/
&��08@Ruel-voetbal.nl/derden/
$��08@Ruitslagen.nl/banner/
#��08@Runity.nu^*/Banners/�
/��08@Rvagina.nl/fish-hooks/fetch.json
>��08@R.vbro.be/wp-content/uploads/*/autoonderdelen24_
,��08@Rverkeerplaza.nl/js/banner.js
1��08@R!visserijnieuws.nl/images/banners/
;��08@R+vitesse.nl/assets/img/layout/etoro-logo.png
0��08@R vitesse.nl^*_sponsors_footer.png
5��08@R%vives.nl/wp-content/uploads/*-Banner-
3��08@R#vives.nl/wp-content/uploads/Banner_
,��08@Rvoetbalkrant.com/images/pub/
1��08@R!voetbalnederland.nl/img/bravo.gif
Q��08@RAvoetbalrotterdam.nl/wp-content/uploads/*/soccerdealbanner1170.jpg
4��08@R$volleybal.nl/uploads/images/Banners/
2��08@R"volleybal.nl/uploads/images/Logos/
5��*
koken.vtm.be08@Rvtm.be^*-achtergrond-
0��*
koken.vtm.be08@Rvtm.be^*-header-
-��08@Rwaarzo.nl/imagestore/banners/
2��08@R"waarzo.nl/imagestore/site-banners/
%��08@Rwaldnet.nl/images/ac/
%��08@Rwanttoknow.nl^*Banner
:��08@R*watersport-tv.nl/content/31400/pages/clnt/
1��08@R!webcam-aalsmeer.nl/media/banners/
2��08@R"webcam-aalsmeer.nl/media/banners2/
0��08@R webcam-airport.nl/media/banners/
1��08@R!webcam-airport.nl/media/banners2/
4��08@R$webcam-binnenvaart.nl/media/banners/
5��08@R%webcam-binnenvaart.nl/media/banners2/
1��08@R!webcam-blokzijl.nl/media/banners/
2��08@R"webcam-blokzijl.nl/media/banners2/
2��08@R"webcam-brandaris.nl/media/banners/
3��08@R#webcam-brandaris.nl/media/banners2/
1��08@R!webcam-delfzijl.nl/media/banners/
2��08@R"webcam-delfzijl.nl/media/banners2/
2��08@R"webcam-denhelder.nl/media/banners/
3��08@R#webcam-denhelder.nl/media/banners2/
1��08@R!webcam-denoever.nl/media/banners/
2��08@R"webcam-denoever.nl/media/banners2/
/��08@Rwebcam-dokkum.nl/media/banners/
0��08@R webcam-dokkum.nl/media/banners2/
2��08@R"webcam-dordrecht.nl/media/banners/
3��08@R#webcam-dordrecht.nl/media/banners2/
2��08@R"webcam-enkhuizen.nl/media/banners/
3��08@R#webcam-enkhuizen.nl/media/banners2/
4��08@R$webcam-friesemeren.nl/media/banners/
5��08@R%webcam-friesemeren.nl/media/banners2/
-��08@Rwebcam-grou.nl/media/banners/
.��08@Rwebcam-grou.nl/media/banners2/
2��08@R"webcam-harlingen.nl/media/banners/
3��08@R#webcam-harlingen.nl/media/banners2/
6��08@R&webcam-havenijmuiden.nl/media/banners/
7��08@R'webcam-havenijmuiden.nl/media/banners2/
4��08@R$webcam-hindeloopen.nl/media/banners/
5��08@R%webcam-hindeloopen.nl/media/banners2/
7��08@R'webcam-hoekvanholland.nl/media/banners/
8��08@R(webcam-hoekvanholland.nl/media/banners2/
/��08@Rwebcam-kampen.nl/media/banners/
0��08@R webcam-kampen.nl/media/banners2/
3��08@R#webcam-lauwersoog.nl/media/banners/
4��08@R$webcam-lauwersoog.nl/media/banners2/
3��08@R#webcam-leeuwarden.nl/media/banners/
4��08@R$webcam-leeuwarden.nl/media/banners2/
1��08@R!webcam-lelystad.nl/media/banners/
2��08@R"webcam-lelystad.nl/media/banners2/
2��08@R"webcam-maassluis.nl/media/banners/
3��08@R#webcam-maassluis.nl/media/banners2/�
3��08@R#webcam-maastricht.nl/media/banners/
4��08@R$webcam-maastricht.nl/media/banners2/
/��08@Rwebcam-marken.nl/media/banners/
0��08@R webcam-marken.nl/media/banners2/
5��08@R%webcam-monnickendam.nl/media/banners/
6��08@R&webcam-monnickendam.nl/media/banners2/
2��08@R"webcam-rotterdam.nl/media/banners/
3��08@R#webcam-rotterdam.nl/media/banners2/
.��08@Rwebcam-sneek.nl/media/banners/
/��08@Rwebcam-sneek.nl/media/banners2/
2��08@R"webcam-terneuzen.nl/media/banners/
3��08@R#webcam-terneuzen.nl/media/banners2/
4��08@R$webcam-vlaardingen.nl/media/banners/
5��08@R%webcam-vlaardingen.nl/media/banners2/
1��08@R!webcam-volendam.nl/media/banners/
2��08@R"webcam-volendam.nl/media/banners2/
0��08@R webcam-workum.nl//media/banners/
0��08@R webcam-workum.nl/media/banners2/
2��08@R"webcam-zaanzicht.nl/media/banners/
3��08@R#webcam-zaanzicht.nl/media/banners2/
1��08@R!webcam-zoutkamp.nl/media/banners/
2��08@R"webcam-zoutkamp.nl/media/banners2/
3��08@R#webcam-zwartsluis.nl/media/banners/
4��08@R$webcam-zwartsluis.nl/media/banners2/
1��08@R!webcams-ameland.nl/media/banners/
2��08@R"webcams-ameland.nl/media/banners2/
6��08@R&webcams-scheveningen.nl/media/banners/
7��08@R'webcams-scheveningen.nl/media/banners2/
/��08@Rwebcams-texel.nl/media/banners/
0��08@R webcams-texel.nl/media/banners2/
4��08@R$webcams-vlissingen.nl/media/banners/
5��08@R%webcams-vlissingen.nl/media/banners2/
7��08@R'webcamschiermonnikoog.nl/media/banners/
8��08@R(webcamschiermonnikoog.nl/media/banners2/
0��08@R webcamvlieland.nl/media/banners/
1��08@R!webcamvlieland.nl/media/banners2/
.��08@Rwebstick.nl/images/images-ads/
L��08@R<wereldstopcontacten.nl/wp-content/uploads/*/image-aff-nl.jpg
+��08@Rwieringernieuws.nl/gfx/ads/
2��08@R"wijchensnieuws.nl/uploads/banners/
E��08@R5wildfm.nl/wp-content/uploads/*/thumbnail_image002.png
$��08@Rwillem-ii.nl/banner/
G��08@R7wp.com/amsterdamactueel.nl/wp-content/uploads/*/728x60_
W��08@RGwp.com/romagazine.nl/14nwsite/wp-content/uploads/2021/07/amstelveen.jpg
x��08@Rhwp.com/romagazine.nl/14nwsite/wp-content/uploads/2021/07/Coordinatoromgevingsvergunningen-Rijksoverheid-
U��08@REwp.com/romagazine.nl/14nwsite/wp-content/uploads/2021/07/enschede.png
W��08@RGwp.com/romagazine.nl/14nwsite/wp-content/uploads/2021/07/rijksoverheid-
f��08@RVwp.com/romagazine.nl/14nwsite/wp-content/uploads/2021/07/seniorprojectleideralmelo.jpg
H��08@R8wp.com/www.appletips.nl/wp-content/uploads/amacdeals.jpg
C��08@R3wp.com/www.appletips.nl/wp-content/uploads/cnmx.png
J��08@R:wp.com/www.appletips.nl/wp-content/uploads/upgreatest1.png
H��08@R8wp.com/www.regionoordkop.nl/wp-content/uploads/*/banner-
X��08@RHwp.com/www.regionoordkop.nl/wp-content/uploads/*/Bdijknov2016336x280.gif
J��08@R:wp.com/www.regionoordkop.nl/wp-content/uploads/*/Costa.jpg
%��08@Ryachtfocus.com^*/bnr/
-��08@Rzilverengoudkopen.nl/banners/
$��08@Rzoekhulp.nl/img/bnr-
B��08@R2zwartewaterfm.nl/images/SponsorenZwarteWaterFM.jpg
W*
autoblog.bbvms.com*
omroepbrabant.nl08@R2mdn.net/instream/html5/ima3.js
H��*
vi.nl08@R/ads.nextday.media/prebid/jw-video/7.43.0.min.js
>*
crime-nieuws.nl08@Rads.viralize.tv/display/?zid=
L *
sportnieuws.nl08@R,advertising-module.api.dpgmedia.cloud/video/
O*
radioluisteren.fm08@R,aka.spotxcdn.com/integration/ados/v1/ados.js
^*
autoblog.bbvms.com08@R:cdn.bluebillywig.com/scripts/prebid/*/bluebillywig_pbjs.js�
O*
radioluisteren.fm08@R,cdn.spotxcdn.com/integration/easi/v1/easi.js
N08@R@files.skoften.net/website/lib/vjs/plugins/ads/videojs.ads.min.js
���*
crime-nieuws.nl*
sportnieuws.nl*
dailybuzz.nl*
weerplaza.nl*
skoften.net*
	goplay.be*
vtm.be08@R*imasdk.googleapis.com/js/sdkloader/ima3.js
K��*
	goplay.be08@R.imasdk.googleapis.com/js/sdkloader/ima3_dai.js
I��*
spelletjes.nl08@R(improvedigital.com/pbw/headerlift.min.js
@*
radioluisteren.fm08@Rjs.spotx.tv/ados/v1/106185.js
[*
welingelichtekringen.nl*
dailybuzz.nl*

radio.nl08@Rmassariuscdn.com/pubs/
<*
	vkmag.com08@R!mmcdn.nl/tags/vkmag.com/pagina.js
U*
crime-nieuws.nl08@R4monetize-static.viralize.tv/viralize_player_content.
E*
radioluisteren.fm08@R"search.spotxchange.com/js/spotx.js
R*
radioluisteren.fm08@R/sync.search.spotxchange.com/partner?source=easi
K�*
flirtmee.nl08@R-tools.vpscash.nl/datingv3/docs/plug_and_play/
P*
2dehands.be08@R3images.2dehands.com/api/v1/listing-twh-p/images/ad/
:��08@R*showmodeluitverkoop.nl/upload/advertentie/
T��08@RDsliedrecht24.nl/wp-content/uploads/2022/02/Banner-300x250-1.jpg.webp
/��08@Rte-les-koop.nl/advertenties.php
7��08@R'zilverengoudkopen.nl/banners/header.jpg
6��08@R&zilverengoudkopen.nl/banners/onder.jpg
708@R)vinatera.be/wp-content/uploads/*_300x600.#adBoven	#adRechts
#adRechts2#advertentie.advertentie-2-container.advertentie_226.advertentie_links.content-rechts-ad.gamereel_featured-ad.gesponsord_blokje.gesponsord_blokje_wrap	.hoofdAd2.kwebler-ad-minimal.massarius-dfp-unit($a[href^="https://go2.go2cloud.org/"] a[href^="https://mt67.net/"]#a[href^="https://www.2k19.nl/"]A=a[href^="https://www.flirtadvertenties.nl/direct-sexdating/"]'#a[href^="https://xltube.nl/click/"]#advertentieblokjeid#gesponsordelink	#reclame2#reclame_rechts#reclamebanner#reclamediv#rightbanner_adbest#semilo-lrectangle#sidereclame#vipAdmarktBannerBlock.ads-mobiel	.adstekst.advertentie.advertenties!.advertorial_koersen_home_top.ankeiler--advertisement.aw_url_admarkt_bottom.banner_advert6blok.banner_advertentie_footer.bericht_adv1.bovenadvertentiediv.category-advertentie.gesponsordelink	.groei-ad.justLease_ad.mp-adsense-header-top�.ontwerp_ads.reclame.reclameIndex.reclamekop.reclamelogos.sponsorbalk!
immo.vlan.be#ProvidersBox"
immo.vlan.be#TopCompareBoxP
dingenvoorvrouwen.nl
autobahn.eu

playboy.nl#WB_VIDEO_PLAYER_TARGET

gaynews.nl#abri

gaynews.nl#abri1)
voetbal24.be#ad-desktop-incontent&
voetbalkrant.com#ad-intro-text-
voetbal24.be#ad-mobile-home-rectangle(
voetbal24.be#ad-mobile-incontent(
voetbal24.be#ad-mobile-outstream#
welklidwoord.nl#ad-takeover
menselijklichaam.nl#ad1$
filmtotaal.nl#adf-autonative&
filmtotaal.nl#adf-autonative-26
lonelyplanet.nl
filmtotaal.nl#adf-billboard'
lonelyplanet.nl#adf-billboard-2#
filmtotaal.nl#adf-rectangle`
noordernieuws.nl
112nederland.nl
gelrenieuws.nl
112brabant.nl

apintie.sr#ads&
openingstijden.com#adsense_CSA	
veto.be#advert-campaign
	rtveen.nl#advertenties0
omroeppenm.nl
	rickfm.nl#advertisement.
alle-tests.nl
	bloovi.be#advertisingQ
volkskrant.nl
demorgen.be
	parool.nl

trouw.nl#article_paragraph_1�
volkskrant.nl
demorgen.be
margriet.nl

libelle.nl
	parool.nl

flair.nl

trouw.nl	
humo.be#article_paragraph_3Q
volkskrant.nl
demorgen.be
	parool.nl

trouw.nl#article_paragraph_6Q
volkskrant.nl
demorgen.be
	parool.nl

trouw.nl#article_paragraph_9!
autobahn.eu#avantisTarget#
ciaotutti.nl#b_searchboxInc/
belgiancycling.be
zoekhulp.nl#banner'
autowereld.nl#banner-detail-top'
autowereld.nl#banner-lister-top=
marktplaats.nl
2dehands.be#banner-top-dt-container
dwtonline.com#banner1#
afkortingen.nu#banner_right!
afkortingen.nu#banner_top"
kranenwebsite.nl
#bannerdivX
brandweerspotters.nl
fanclubbarcelona.nl
a1mediagroep.nl
coc.nl#banners#
historiek.net#before-header 
bierdopje.com#billboards
	bol-an.nl	#block-10
	bol-an.nl	#block-11!
groningerkrant.nl#block-2
spreekbuis.nl#block-3%
tiener-sexverhalen.nl#block-6
	bol-an.nl#block-9+
luchtvaartnieuws.nl#block-block-191&
blikopnieuws.nl#block-block-382
scheepvaartkrant.nl#block-topbannersidebar<
zakenreisnieuws.nl"#block-views-banner_carousel-block:

boek9.nl*#block-views-block-advertisements-ads-left;

boek9.nl+#block-views-block-advertisements-ads-right:
mandelnieuws.be##block-views-block-sponsors-block-1:
mandelnieuws.be##block-views-block-sponsors-block-2:
mandelnieuws.be##block-views-block-sponsors-block-3:
mandelnieuws.be##block-views-block-sponsors-block-4=
willem-ii.nl)#block-views-block-view-business-partners8
willem-ii.nl$#block-views-block-view-main-sponsor�9
willem-ii.nl%#block-views-block-view-shirt-sponsor1

boek9.nl!#block-views-sponsor-banner-block#
	vagina.nl#bottom-fish-hooks!
voetbalnederland.nl#bravo

kekmama.nl#c1
startkabel.nl	#campagne<

indiexl.nl*#carousel-indiexl_partners_carousel_widget,
basketballbelgium.be#carousel-item-2'
topvolleybelgium.be#contacts3-5#
almere-nieuws.nl#containerx%
looopings.nl#contentBillboard(
grandprixradio.nl#custom_html-109
grandprixradio.nl
cryptosjop.nl#custom_html-13(
grandprixradio.nl#custom_html-17(
grandprixradio.nl#custom_html-18P
omroepeemsdelta.nl
wereldreizigers.nl
minimumloon.nl#custom_html-24
messianieuws.nl
arrowcaz.nl#custom_html-3 
	exxact.nl#custom_html-31$
historiek.net#custom_html-38<
heelhollandkijkt.nl
messianieuws.nl#custom_html-46
messianieuws.nl
huisvlijt.com#custom_html-5*
rtvalbrandswaard.com#custom_html-6
	nljug.org#custom_html-7!

vroom.be#divBanneringSlot 	
oops.nl#dropinboxv2cover3
cryptonieuws.nl#elementor-popup-modal-256753
cryptonieuws.nl#elementor-popup-modal-256861
cryptoclan.nl#elementor-popup-modal-400651
cryptoclan.nl#elementor-popup-modal-40079&
pornoplekje.nl#exitpopup-modal8
fcupdate.nl%#fcupdate\.nl_web_billboard_970x250_1:
fcupdate.nl'#fcupdate\.nl_web_billboardskin_970x2506
androidplanet.nl

iphoned.nl#featured-header9
androidworld.be
androidworld.nl#fh-placeholderT
footballtransfers.com7#footballtransfers\.com_ros_alpha_leaderboard-billboardQ
footballtransfers.com4#footballtransfers\.com_ros_bravo_rectangle-halfpage"
alkmaarguardians.nl#footer
	nieuws.nl#footer-banner%
manpedia.nl#gridlove-module-2'
vrouwpedia.nl#gridlove-module-3
	nieuws.nl#header-banner:
unitednews.sr%#image-vertical-reel-scroll-slideshowG
indeleiderstrui.nl-#indeleiderstrui_ros_alpha_rectangle-halfpageJ
indeleiderstrui.nl0#indeleiderstrui_ros_bravo_leaderboard-billboardB
indeleiderstrui.nl(#indeleiderstrui_ros_bravo_mini_ad_fluidG
indeleiderstrui.nl-#indeleiderstrui_ros_bravo_rectangle-halfpage%
marktplaats.nl#inloggenDialog*

itdaily.be#itdaily-article-sidebar&

itdaily.be#itdaily-article-top!

itdaily.be#itdaily-footer
techzine.nl#lead"
eindexamens.nu#leaderboard"

made-in.be#leaderboard_row$
autosport.nl#liggende-banner"
greenkeeper.nl#lijst_logos 
autowereld.nl#mainbanner3
messianieuws.nl
	palnws.be#media_image-10$
spreekbuis.nl#media_image-11 
	palnws.be#media_image-12 
	bol-an.nl#media_image-13&
omroepalmere.nl#media_image-16&
omroepalmere.nl#media_image-18O
dutchcryptotalk.com
classicstogo.nl
messianieuws.nl#media_image-2&
omroepalmere.nl#media_image-21�&
omroepalmere.nl#media_image-22#
mariabode.nl#media_image-28r
schiedamsnieuws.nl
kanaancourant.nl
oomroepalmere.nl
keizerstad.nl
vivocyclo.com#media_image-3#
mariabode.nl#media_image-34J
schiedamsnieuws.nl
keizerstad.nl
vivocyclo.com#media_image-4%
messianieuws.nl#media_image-5&
maaslandradio.nl#media_image-7/
wielerflits.be
wielerflits.nl#mm_hpa7
wielerflits.be
wielerflits.nl#mm_leaderboard5
wielerflits.be
wielerflits.nl#mm_rectangle#
surinameview.com#nav_menu-2
autoblog.nl#nav_menu-5 

pokeren.nl#onetime-popup$
starnieuws.com#overig_nieuwsY
indeleiderstrui.nl
wielerflits.be
wielerflits.nl
autoreview.nl
#parentgpt!
eredivisie.nl#partner-bar
	vagina.nl#partner-linksm
belgiancycling.be
coastline945fm.nl
fonkmagazine.nl
coastlinefm.nl
elfvoetbal.nl	#partners)
coastline945fm.nl#partners_slides1
ans-online.nl#penci_latest_news_widget-120
ans-online.nl#penci_latest_news_widget-7&
rtvkrimpenerwaard.nl
#pg-1407-8$
meteoalblasserdam.nl#pic_446&
sexpower.nl#pre-footer-banners"
bdsmgirl.nl#product_banner$
boerderij.nl#rb_logolink_box
fcutrecht.net#reclame/
	stubru.be
mnm.be#reclameblok-wrapper
nashvilletv.nl#ribbon"
motorfietsblog.nl	#shopside'

franska.nl#shopsuiteApplication!
	vagina.nl#side-fish-hooks'
112achterhoek-nieuws.nl#sidebar

top40.nl#sky1

top40.nl#sky2

top40.nl#sky3

top40.nl#sky4
	geelfm.be#slider&
	jammfm.nl#slider_32982_slide010
dartfreakz.nl#soliloquy-container-3268310
dartfreakz.nl#soliloquy-container-3268350
dartfreakz.nl#soliloquy-container-3341750
dartfreakz.nl#soliloquy-container-3341860
dartfreakz.nl#soliloquy-container-334192-
sciencelink.net#sponsored-content_280)
zwartewaterfm.nl#sponsorenBtmCntr0
	easyfm.nl
	goldfm.be#sponsors-carousel%
adodenhaag.nl#sponsors-normal	
itwm.nl#tdi_37
voetbal4u.be#text-11.
livestreamvandaag.be
h20.gg#text-14-
radiozuidrand.be
	exxact.nl#text-15"
edelmetaal-info.nl#text-161
edelmetaal-info.nl
loemedia.nl#text-179
voetbalweddenrss.nl
edelmetaal-info.nl#text-19
omrekenen.org#text-2"
edelmetaal-info.nl#text-20
messianieuws.nl#text-24!
edelmetaal-info.nl#text-3%
despirituelewereld.be#text-37- 
goedkoopstekeukensduitsland.nl#text-5"
feyenoordreport.nl#text-50
psvreport.nl#text-57
psvreport.nl#text-58�X 
goedkoopstekeukensduitsland.nl
voetbalnotering.nl
duurzaamnieuws.nl#text-6
voetbalsnafu.nl#text-64
voetbalsnafu.nl#text-65
voetbalsnafu.nl#text-66
senseigaming.be#text-7A 
goedkoopstekeukensduitsland.nl
hoekschnieuws.nl#text-8
voetbal4u.com#text-81
ajaxreport.nl#text-88
ajaxreport.nl#text-91
sexpower.nl#top-banner)
marktplaats.nl#top-banner-wrapper1
onderwijsnieuwsdienst.nl#topAdvertisement!
escort46.nl#top_image_divR
hollandskroonnieuws.nl
wieringernieuws.nl
radio-minerva.be
#topbanner!
voetbal-vandaag.nl#topbox#
hotradiohits.nl#tpl_banners%
gratissextube.be#tracking-url
tweakers.net#true0
omroepalmere.nl#widget_carousel_slider-3)
culturescope.nl#widget_sp_image-2)
culturescope.nl#widget_sp_image-44

negerin.nl"#widget_text.widget-sidebar.widget*
broadcastmagazine.nl.Advertisement5
telegraaf.nl!.ArticleBodyBlocks__bannerWrapper/
telegraaf.nl.ArticlePageWrapper__banner
telegraaf.nl.Banner7
marktplaats.nl
2dehands.be.BannerBottom-root'
marktplaats.nl.BannerRight-root-
marktplaats.nl.Banners-bannerFeedItem+
telegraaf.nl.BasicTeaser__sponsored
guruwatch.nl
.Billboardh
beursduivel.be
beursonline.nl
eurobench.com
belegger.nl

debeurs.nl.Billboard-wrapper&
telegraaf.nl.ComponentRotation
iex.nl.ContentPartner#
guruwatch.nl.LargeRectangle'

iexgeld.nl.LeaderboardContainer

topgear.nl	.Pnvp__ad

iexgeld.nl
.Rectangleh
beursduivel.be
beursonline.nl
eurobench.com
belegger.nl

debeurs.nl.Rectangle-wrapper/
telegraaf.nl.SectionPage__bannerWrapper
onsoranje.nl.SponsorBar	
knvb.nl.SponsorBar-list%
totoknvbbeker.nl.SponsorBlock0
telegraaf.nl.SportScoreboardPage__banner0
zelfmaak-ideetjes.nl.Sticky_Ad_Widget_SP!

buzzbie.nl.TS_Banner_Spot3
telegraaf.nl.TextArticlePage__bannerWrapper-
telegraaf.nl.VideoArticlePage__banner&
telegraaf.nl.VideoPage__bannerg
deondernemer.nlP.\-mb-10.box-content.flex.hidden.items-center.p-4.md\:mb-0.md\:flex.md\:min-h-25T
christelijknieuws.nl
dartfreakz.nl
zozwanger.nl

thehike.nl	.a-single
upinthesky.nl.a-wrap!
ditishelmond.nl
.aanbieder
	rtveen.nl	.aas_zone!
rivierenland-radio.nl.aba2

newsbit.nl .acf-block-cta-conversion-rating�
beleggersbelangen.nl
hetnieuwsvandaag.be
banden.autoweek.nl
voetbalprimeur.nl
voetbalnieuws.nl
a1mediagroep.nl
alarmeringen.nl
besteproduct.nl
rtvnunspeet.nl
tripadvisor.nl
wijlimburg.nl
eurosport.nl
indebuurt.nl
koopplein.nl
limburger.nl
persinfo.org
tradeidee.nl
autozine.nl

dumpert.nl

gpblog.com

tellows.nl
	24cars.nl
	bright.nl

sport.be	
vrmg.nl
xgn.nl
rd.nl.ad&
crypto-insiders.nl.ad-category�
omroepflevoland.nl
sportuitslagen.org
soccernews.nl
trendalert.nl
babybytes.nl

bruzz.be
pu.nl.ad-container
voetbal.com.adbox

sozio.nl
.adchannel,
faillissementsdossier.nl.adcontainer%
nieuwsmotor.nl.add-background1
voetbalvandaag.be
vlaamskijken.nl.adds�!

beurs.nl.addslotJ
a1mediagroep.nl
rtvnunspeet.nl
loemedia.nl	
vrmg.nl.adlead)
westerwoldeactueel.nl.adr-wrapper�
dagelijkseverhalen.nl
openrotterdam.nl
wegdamnieuws.nl
viamichelin.be
viamichelin.nl
cinenews.be

handbal.nl
	vkmag.com

clint.be.ads>
treinreiziger.nl&.ads-adsense-treinreiziger-horizontaal@
treinreiziger.nl(.ads-adsense-treinreiziger-horizontaal-5*
faillissementsdossier.nl
.adsbybinqD
openingstijden.com
promootjesite.nl

radiofm.nl.adsense)
adodenhaag.nl
spelletje.nl.adv�
talentenjacht.tv
informatief.tv
gezondheid.tv
ondernemen.tv
spelletjes.tv
verkiezing.tv
amusement.tv
nederland.tv
formule1.tv
jongeren.tv
kinderen.tv
politiek.tv
vaartuig.tv
voertuig.tv

cultuur.tv

onrecht.tv

sporten.tv

voetbal.tv
	geloof.tv
	kennis.tv
	lachen.tv
	mensen.tv
	muziek.tv
	natuur.tv
	nieuws.tv
	oranje.tv

beurs.tv

gamen.tv

serie.tv	
kook.tv	
mode.tv	
reis.tv	
weer.tv	
woon.tv
.adv-tekst?
intermediair.nl
filmtotaal.nl
hoimedia.com.advert(

newsbit.nl.advert-converting-bar&
juf-milou.nl.adverteerdersblok)
startlijstjes.nl.advertentieblock(
rallylovers.be.advertentierechts
autoweek.nl
.advertise�
elektormagazine.nl
fonkmagazine.nl
maassluis24.nl
kieskeurig.nl
schiedam24.nl
zijaanzij.nl
hpdetijd.nl
twentefm.nl

1twente.nl

bnnvara.nl
	tvgids.tv	
nl24.nu.advertisement+

goodbye.be
	sporza.be.advertising�
albrandswaardsdagblad.nl
barendrechtsdagblad.nl
ridderkerksdagblad.nl
zoetermeersdagblad.nl
rijswijksdagblad.nl
voorburgsdagblad.nl
goudsdagblad.nl
dagblad010.nl
dagblad070.nl.advrow"
geenstijl.nl.afctr-wrapper8
wielerflits.be
wielerflits.nl.affiliate_links4
gfcnieuws.com
historiek.net.ai-viewport-1&
voedingswaardetabel.nl.amgrayB&
voedingswaardetabel.nl.amgrayT$
autoreview.nl.ar_300_600_mid$
autoreview.nl.ar_300_600_top 
autoreview.nl.ar_970_2500
rtvkrimpenerwaard.nl.art-positioncontrol'
zeelandnet.nl.article-bnr-first4
geenstijl.nl .article-premium-promotion-block*
motocrossplanet.nl.artikel-banners'
zeelandnet.nl.as__bottom-banner
nailtalk.nl.ashe-widget!
klimaatinfo.nl.aside__add
yachtfocus.com.av'

salvora.nl.avia-content-slider1
gaykrant.nl.awac 

hookers.nl.axd-container
stadszaken.nl.b-side�
executive-people.nl
dutchitchannel.nl
beursgorilla.nl
retaildetail.be
retaildetail.nl
afkortingen.nu
beursduivel.be
propertynl.com
startpagina.nl
filmladder.nl
televizier.nl
uiennieuws.nl
uitslagen.nl
uw-folder.nl
bpnieuws.nl
ibestuur.nl
iexprofs.nl
metalfan.nl
telezien.nl
totaaltv.nl
tvgemist.be

folderz.nl

waldnet.nl
	klasse.be
	tvgids.nl

beurs.nl

oogtv.nl

unity.nu	
vnci.nl
agf.nl
nrc.nl
nu.nl.banner)
nieuwsuitnijmegen.nl.banner-box-1"
goudengids.be.banner-boxes0
speeleiland.nl.banner-btf-side-rectangle$
feyenoord.nl.banner-carousel&
sportnieuws.nl.banner-centered�
deliciousmagazine.nl
rootsmagazine.nl
lokaaltotaal.nl
fietsactief.nl
truckstar.nl
knipmode.nl

seasons.nl

vorsten.nl

fiets.nl
zin.nl.banner-container
	tvblik.nl.banner-fluid"
prewarcar.nl.banner-holder"
yachtfocus.com.banner-item(
ewmagazine.nl.banner-leaderboard&
freeones.nl.banner-placeholder!
marktplaats.nl.banner-row2
maarkelsnieuws.nl.banner-secondary-sidebar 

nnieuws.be.banner-silver2
radioviainternet.be.banner-size-leaderbord!
speeleiland.nl.banner-skyD
nieuwsuitnijmegen.nl
wijchensnieuws.nl.banner-slider-item!
dolcevia.com.banner-style'
maarkelsnieuws.nl.banner-widget5
deblueskrant.nl
nieuweoogst.nl.banner-wrap2
autowereld.nl

sexjobs.nl.banner-wrapper"
opwindend.net.banner468x60$
motocrossplanet.nl
.banner540'
rtvdordrecht.nl.bannerContainer�%
meetingmagazine.nl.bannerLine#
iexprofs.nl.banner__article'
tostrams.nl.banner__articleside$
tostrams.nl.banner__homeside 
iexprofs.nl.banner__side
tpo.nl.banner__true 
iexprofs.nl.banner__wrap&
iexprofs.nl.banner__wrapbottom�
talentenjacht.tv
informatief.tv
gezondheid.tv
ondernemen.tv
spelletjes.tv
verkiezing.tv
amusement.tv
nederland.tv
formule1.tv
jongeren.tv
kinderen.tv
politiek.tv
vaartuig.tv
voertuig.tv

cultuur.tv

onrecht.tv

sporten.tv

voetbal.tv
	geloof.tv
	kennis.tv
	lachen.tv
	mensen.tv
	muziek.tv
	natuur.tv
	nieuws.tv
	oranje.tv

beurs.tv

gamen.tv

serie.tv	
kook.tv	
mode.tv	
reis.tv	
weer.tv	
woon.tv.banner_image�
talentenjacht.tv
informatief.tv
gezondheid.tv
ondernemen.tv
spelletjes.tv
verkiezing.tv
amusement.tv
nederland.tv
formule1.tv
jongeren.tv
kinderen.tv
politiek.tv
vaartuig.tv
voertuig.tv

cultuur.tv

onrecht.tv

sporten.tv

voetbal.tv
	geloof.tv
	kennis.tv
	lachen.tv
	mensen.tv
	muziek.tv
	natuur.tv
	nieuws.tv
	oranje.tv

beurs.tv

gamen.tv

serie.tv	
kook.tv	
mode.tv	
reis.tv	
weer.tv	
woon.tv.banner_image2:
zwaremetalen.com
abcsuriname.com.banner_wrapper�
lokaleomroepzeewolde.nl
antilliaansdagblad.com
h2owaternetwerk.nl
halstadcentraal.nl
radiolelystad.nl
abcsuriname.com
dolcevia.com
midvliet.nl.bannergroup#
puurnaturisme.nl.banneritem0

kbradio.nl

rkvvo.nl
gic.nl.banners%
radiomonique.am.bannerswidget%
twentefm.nl.bannerzone_728x90!
dutchitchannel.nl.bannner
fcupdate.nl.bet365@
feyenoordpings.nl
twentefans.nl.betcity-intro-wrapper/
voetbalnieuws.nl.betting-article-insert"
vi.nl.betting-provider-row$
bieos-omroep.nl.bieos-widget
autosport.nl
.bigbanner*
faillissementsdossier.nl
.billboard+
tostrams.nl
iex.nl.billboardwrap(
tostrams.nl.billboardwrap-bottom 
iex.nl.billboardwrapdown$
cryptosjop.nl.bitvavo-widgetA
hagelandactueel.be
leuvenactueel.be.block-banner-block#
	livios.be.block-leaderboard"
psv.nl.block-sponsors--psv%
psv.nl.block-sponsors-desktop%
scholieren.com.blockvertorialA
escortgirls.be
topescort.nl
sexguide.nl.blogBanners`
voetbalverslaafd.nl
feyenoordpings.nl
kantinepraat.nl
twentefans.nl.bn__wrapper0
podcastluisteren.nl
zeelandnet.nl.bnr
bnr.nl.bnr-message!
bodylifebenelux.nl.bnrrow
tpo.nl.bol_pml_box
wijwedden.net.bookies*
voetbalvandaag.nl.bookmaker-banner&
autoreview.nl.bottom-bannuring,
onderwijsnieuwsdienst.nl.bottomSpace
bnr.nl.branded

classic.nl.brievenbus
xgn.nl.bs
mijnserie.nl.buyThis
	tzum.info.bzrwfrm$
	wradio.be.c-advertiser-logos*	
tijd.be.c-articleteaser--sponsored*
flaironline.nl.c-commerical_banner 
ngf.nl.c-footer-sponsorsA
financialinvestigator.nl!.c-newsList__story--partnernieuws$
ditjesendatjes.nl.c-partners-
farmaline.be.c-sidebar-banner-wrapper5
	tennis.nl

knltb.nl.c-site-footer__partners(
lekkercryptisch.nl.c-sponsoredBy'
	qmusic.nl	
golf.nl.c-sponsors/
binnenlandsbestuur.nl.c-teaser--partner#
	hockey.nl.card--leaderboard 
	hockey.nl.card--partners 
volleybal.nl.card-banner&
volleybal.nl.card-banner-largeN
webcam-maastricht.nl
webcam-harlingen.nl
rkcwaalwijk.nl	.carousel�.
halstadcentraal.nl.carouselbanner_left'
fonkonline.nl.carrousel-wrapperM
nieuwsblad.be
standaard.be	
hbvl.be
gva.be.cba_container_grid#
motorfietsblog.nl
.cbcontent#
monitor.iex.nl.centerbanner
techzine.nl.chimney<
autoscout24.be
autoscout24.nl.cl-billboad-wrapper,
bitcoinmagazine.nl.clickout-relative+
skoften.net.cls-placeholder-160-600+
skoften.net.cls-placeholder-300-600+
skoften.net.cls-placeholder-970-250
rd.nl.codalt-container1
gfcnieuws.com
techgaming.nl.code-block? 
achterhoeknieuwswinterswijk.nl.component__pubble-banner%	
bol.com.consideration-displayE
deaandeelhouder.be
deaandeelhouder.nl.container-commercial%
	jumbo.com.container.sponsored$
twentefans.nl.content-action)
juf-milou.nl.content_blok_reclame
iex.nl.contentwidget>
weerstationleeuwarden.nl.cookieconsent-optin-marketing

tameteo.nl.creatividad)
veronicasuperguide.nl.css-12wfacz

dumpert.nl.css-12wfvx3

dumpert.nl.css-1e3vcj9)
veronicasuperguide.nl.css-1t8ljyq

dumpert.nl.css-44y8rm

dumpert.nl.css-50zgs1

dumpert.nl.css-izjevn 
voetbaluitslagen.com.cta
	menttv.be.cta-container)
voetbaluitslagen.com.cta__toplist"

kekmama.nl.cts-row-wrapper)
zelfmaak-ideetjes.nl.da-container�
albrandswaardsdagblad.nl
barendrechtsdagblad.nl
ridderkerksdagblad.nl
zoetermeersdagblad.nl
rijswijksdagblad.nl
voorburgsdagblad.nl
goudsdagblad.nl
dagblad010.nl
dagblad070.nl.ddbad_wrapper!

radionl.fm.desktop_mobile
touretappe.nl
.desktopad'
flashscore.nl.detailLeaderboard
sliedrecht24.nl.dfad�
gelderlander.nl
goedgevoel.be
destentor.nl
bndestem.nl
tubantia.nl
hln.be
pzc.nl
ad.nl
bd.nl
ed.nl.dfp+
dagelijksekost.een.be.dish-sponsors 

rkvvo.nl.divFooterBanner 

rkvvo.nl.divHeaderBanner
tpo.nl.dus6
androidplanet.nl

iphoned.nl.dynamic-content=
androidplanet.nl

iphoned.nl.dynamic-content-native#
turksemedia.nl.easingslider(

decibel.nl.edgtf-carousel-holderM
247spice.com9.elementor-element-2da19501 + .elementor-element-6406e4833
cryptobenelux.com.elementor-element-3839f8f-
biflatie.nl.elementor-element-3f470751
dartsactueel.nl.elementor-element-4a0fad51
domstadradio.nl.elementor-element-a6b91341
dartsactueel.nl.elementor-element-b29a928.
mr-online.nl.elementor-element-b8e990e-
radio182.nl.elementor-element-bf3ae4f1
dartsactueel.nl.elementor-element-cda7c32.
mr-online.nl.elementor-element-da14229,
biflatie.nl.elementor-location-popup)
biflatie.nl.elementor-popup-modal;
motorrijder.be%.elementor-widget-container > a > img:
aalsmeervandaag.nl .elementor-widget-media-carousel1
radiocontinu.nl.eskimo-carousel-container	
sol2.nl.et_pb_image_0� 	
sol2.nl.et_pb_slider2
noordkopcentraal.nl.ewic-slider-pro-widget-
pornoplekje.nl.exitpopup-modal-window(
crypto-insiders.nl.exp-google-ad
musicmeter.nl	.external>
escortgirls.be
topescort.nl
sexguide.nl	.fBanners
voetbalzone.nl.fco-ad%
voetbalzone.nl.fco-openweb-ad.
voetbalzone.nl.fco-sponsored-text-link
fd.nl.fd-message,
ml5.nl.fl-module-uabb-image-carousel�
id.nlz.flex.items-center.justify-center.mx-auto.min-h-\[280px\].md\:my-2.w-\[336px\].h-\[280px\].md\:w-\[970px\].md\:h-\[250px\]�
webcam-hoekvanholland.nl
webcamschiermonnikoog.nl
webcam-havenijmuiden.nl
webcams-scheveningen.nl
webcam-monnickendam.nl
webcam-binnenvaart.nl
webcam-friesemeren.nl
webcam-hindeloopen.nl
webcam-vlaardingen.nl
webcams-vlissingen.nl
webcam-lauwersoog.nl
webcam-leeuwarden.nl
webcam-zwartsluis.nl
webcam-brandaris.nl
webcam-denhelder.nl
webcam-dordrecht.nl
webcam-enkhuizen.nl
webcam-maassluis.nl
webcam-rotterdam.nl
webcam-terneuzen.nl
webcam-zaanzicht.nl
webcam-aalsmeer.nl
webcam-blokzijl.nl
webcam-delfzijl.nl
webcam-denoever.nl
webcam-lelystad.nl
webcam-volendam.nl
webcam-zoutkamp.nl
webcams-ameland.nl
webcam-airport.nl
webcamvlieland.nl
webcam-dokkum.nl
webcam-kampen.nl
webcam-marken.nl
webcam-workum.nl
webcams-texel.nl
webcam-sneek.nl
webcam-grou.nl.flexslider9
bdsm-vrienden.nl!.floatLeft.marginTop.resizeImages!
heracles.nl.footer-blocks!
fcutrecht.nl.footer-logos$
bekijkporno.nl.footer-margin#
heracles.nl.footer-sponsors

handbal.be.footer-top)
anoniem-surfen.nl.footer-widget-1#

ajax1.nl.footer__footer-fat;
feyenoordpings.nl
twentefans.nl.footer__partners4
voetbalverslaafd.nl.footer__partners-wrapper

rtvgo.nl
.footeradd!
burggolf.nl.footercontent6
uecl-voetbal.nl
uel-voetbal.nl.footerderden
kanaalxxx.nl.fpbnrp
motorrijdenexpert.nlT.full-row.relative-row.no-padding-bottom.title-txt-btn.flat-theme.flat-theme-content/
unitednews.sr.fullwidthbanner-container�
despirituelewereld.be
westerwoldeactueel.nl
binnenvaartkrant.nl
amateursexstart.nl
dewereldmorgen.be
regioinbedrijf.nl
christmaholic.nl
hoekschnieuws.nl
noordernieuws.nl
dbsuriname.com
dehavengids.nl
sekswebsite.nl
sleutelstad.nl
dartfreakz.nl

curacao.nu

seksmet.nl

shespot.nl.g
zozwanger.nl	.g-single
zeelandnet.nl	.g_banner
radiovisie.eu.gmollik
srherald.com.gsrhera
ninefornews.nl.gyehnsh5
porntube.nl

sextube.nl.happy-player-beside/
porntube.nl

sextube.nl.happy-section&
noordkopcentraal.nl.headbannere
voetbalnieuws.be
wielernieuws.be
televizier.nl

gpinfo.com
	tvblik.nl.header-banner1
hardware.info.header-navigation__truelogo)
schaatsen.nl.header-partners-logo
wos.nl.header-right.
anoniem-surfen.nl.header-widget-region'
gratisoptehalen.nl.headerAdWrap	
golf.be.header__bottom"

4gamers.be.header__combell$	
ajax.nl.header__partner-link+
eredivisie.nl.header__top__partners$
arenalokaal.nl.header_banner!
zeelandnet.nl.hero-banner"
psvinside.nl.hide-ad-small0
basketbal.vlaanderen.holder--divider-top

oogtv.nl.home-banner

funda.nl.home-billboard1
eurogamer.nl.homepage-billboard-container0
racingnews365.nl.homepage-casino-wrapper(
jan-magazine.nl.homepage-marquee
autosport.nl.horizontal$
autosport.nl.horizontal-logo 
retailtrends.nl	.href-a-b&
racesport.nl.hthb-notification�
vrouwenvoetbalkrant.be
autosportkrant.be
basketbalkrant.be
volleybalkrant.be
atletiekkrant.be
voetbalkrant.com
handbalkrant.be
sport-planet.eu
hockeykrant.be
tenniskrant.be
wielerkrant.be.imu
rd.nl.infotainment/
dansendeberen.be.inhype-bb-block-header�(
radiopros.be.inside-left-sidebarA
dolcevia.com-.ira-container.ira-format-block > .bookingaff,
reformatorischeomroep.nl.item-banner$
defeijenoorder.nl.jet-banner%
beursgorilla.nl.js--billboard 
beursgorilla.nl	.js--rect
iex.nl
.js-banner&
eurocampings.nl.js-mock-banner!
eoswetenschap.eu	.l-banner*
webwoordenboek.nl.layout__main-ads
gic.nl.lead(
speeleiland.nl.leader-below-game"
rendez-vous.be.leaderBoard�
vrouwenvoetbalkrant.be
autosportkrant.be
basketbalkrant.be
volleybalkrant.be
atletiekkrant.be
voetbalkrant.com
handbalkrant.be
sneeuwhoogte.nl
sport-planet.eu
hockeykrant.be
tenniskrant.be
wielerkrant.be
tradeidee.nl
pcactive.nl

sportid.be
psv.nl.leaderboard%
moviemeter.nl.leaderboard-bar'
monitor.iex.nl.leaderboard-downA
	tvoost.be

robtv.be
atv.be
tvl.be.leaderboardWrap-
blikopnieuws.nl.ligatus-sidebar-blockL
escortgirls.be
topescort.nl
sexguide.nl.link-buttons-container:
rtvstichtsevecht.nl
roulettefm.nl.list-sponsors+
businessinsider.nl.ll_partnerexpert
motorboot.com.logo3
sparta-rotterdam.nl.logo_main_sponsor_image-
sparta-rotterdam.nl.logo_slider_logos
greenkeeper.nl	.logoblok(
nieuweoogst.nl.logolinks-wrapper+
techpulse.be.magazine-sidebar-block 	
humo.be.marketing-banner"
live-voetbal.com
.match-bet"
ga-eagles.nl.match-sponsor
mediacourant.nl.mc-adv
gaykrant.nl.metaslider�
metronieuws.nl
autovisie.nl
beautify.nl
jmouders.nl

bedrock.nl

manners.nl

famme.nl

nsmbl.nl	
culy.nl	
want.nl.mha_container�
volkskrant.nl
demorgen.be
margriet.nl

libelle.nl
	parool.nl

flair.nl

trouw.nl	
humo.be.mid1-container
mijn-tv-gids.be.midzone*
autobahn.eu.min-h-280.min-h-md-250
scholieren.com	.min-h-90<
aalsmeervandaag.nl
wegdamnieuws.nl.mk-sponsorlink"
wordfeudwoorden.nl.mobblue)
radioeenhoorn.nl.module_round_box&
marktplaats.nl.mp-Listing--cas0
marktplaats.nl.mp-Listings__admarktTitle(
marktplaats.nl.mp-adsense-header$
financialinvestigator.nl.mpu 
wintersport.nl
.mq-banner9

edestad.nl'.mtb-0.ptb-15.mb-30.text-center.bg-grey

qassa.nl.muurpapier`
autoreview.nlK.my-12.py-6.relative.border-y.border-slate-300.sm\:flex.sm\:justify-between

schie.nu.my-5+
dmgdeurne.nl.n2-section-smartslider
iex.nl.nativeblock%
scientias.nl.ndm-desktop-only+
scientias.nl.ndm-mobile-header-only%
iex.nl.network:nth-of-type(2)H
escortgirls.be
topescort.nl
sexguide.nl.newbottom-fbanners 
partyflock.nl.nice-thing
	nieuws.nl.nieuws-banner,	
tijd.be.o-hpgrid__row-sponsoredcombo)	
tijd.be.o-hpgrid__row-tijdconnect!
twentefans.nl.odd-wrapper#
flashscore.nl.oddsPlacement"
vlaamskijken.nl.order-book=
autoscout24.be
autoscout24.nl.osa-as24-placeholder,
hardware.info.overview-item--success�$
classicstogo.nl.owl-carousel2
lekkercryptisch.nl.p-footer__randomPartner+	
ajax.nl.page-footer__partners-block
nd.nl.page-header__ad$
nd.nl.page-header__inner__ad$
123video.nl.page-load-switch/
klokradio.nl.panel-grid.rslides-content>
	tvoost.be

robtv.be
atv.be
tvl.be.parallaxBnnr*
ewmagazine.nl
	qmusic.nl.partner%
sc-heerenveen.nl.partner-grid$
sc-heerenveen.nl.partnerlink}
voetbalindebollenstreek.nl
royalantwerpfc.be
schuttevaer.nl
clubbrugge.be
feyenoord.nl
ftm.nl	.partners#
	agraaf.nl.partners-carousel	
golf.be.partners-holder
weespernieuws.nl.pbph-
denachtvlinders.nl.plek-boven-artikel
watersport-tv.nl.pos16'
twentefans.nl.powered-by-footer!
	fhm500.nl.powered_by_page$
	fhm500.nl.powered_by_profile&
marktplaats.nl.premium-content/

blokker.nl.product-tile__column--criteo 
	fhm500.nl.profileh_tabacx
omroephorstaandemaas.nl
rtvstichtsevecht.nl
omroepvenlo.nl
roulettefm.nl
dtvnieuws.nl
wos.nl.prom"
openingsurengids.be.promSB&
voetbalnieuws.nl.promo-element$
fondsnieuws.nl.promo-wrapper 
synoniemen.net
.promoblok
skoften.net	.promoted-
skoften.net.promoted-entry-in-content#
oneworld.nl.promotion-block!

guidinc.nl.promotion_link6
girlpowerradio.nl.proradio-owl-sponsorcarouselP
europa-landbouwmachines.nl
hetnieuwsvandaag.be
mijn-tv-gids.be.pub$

gocar.be.pub-leaderboard-top#
nedporno.com.publ11s-b0ttom/
tostrams.nl
iex.nl.publisher-sh-spot'
guruwatch.nl.publisher-sh-spot1&
	simone.nl
wfm.be.qt-sponsor
rbsradio.be.qt-sponsors&
nedporno.com.r11ght-pl4yer-169u
dagelijksestandaard.nl
wielrennenuptodate.nl
sportbookies.nl
	viraal.nl	
puna.nl.raw-html-component'
hoekschnieuws.nl.rbct > a > imgB
eurobench.com
belegger.nl

debeurs.nl.recommendbanner 
wasmachines.nl
.rectangle
iex.nl.rectanglemid
iex.nl.rectanglewrap(

nnieuws.be.region-banner-diamond&
halstadcentraal.nl.respbanners*
id.nl.richtext_richtext-cta__ldQ3jA
marktplaats.nl
2dehands.be.right-banner-root-container&
zeelandnet.nl.row--bnr-between-
racesport.nl.rs_sponsorbanners_widget
motorblog.nl.sale)
oisterwijknieuws.nl.sam-container�
dagelijksestandaard.nl
indeleiderstrui.nl
vechtsportinfo.nl
ajaxshowtime.com
androidworld.be
androidworld.nl
dartsnieuws.com
twenteinsite.nl
dartfreakz.nl
f1maximaal.nl
	loesoe.nl
	vkmag.com	
fr12.nl.sda&
scholieren.com.searchvertorial*
dutchcowboys.nl.section-a-dvertise 
	tvgids.nl.section-banner'
deondernemer.nl.section-branded7
ewmagazine.nl
fotografie.nl.section-partners-
uitzendinggemist.net.serie_info_adbox-
baanwacht.nl.shailanOFF_banner_widget*
baanwacht.nl.shailan_banner_widget�+
indeleiderstrui.nl.shopsuite-widget&
wijlimburg.nl.sidebar-partners,
fcgroningen.nl.sidebar__item--banner'
hardware.info.sidebar_right_top%
radiobingo.be.single-partners)

proshop.nl.site-background-banner#

proshop.nl.site-home-banner"

proshop.nl.site-top-banner
geenstijl.nl
.slajeslag"
infinance.nl.slickcarousel&
unitednews.sr.slider-container$
omroepwest.nl.slider-wrapper#
volleyvlaanderen.be.slider5)
maaslandradio.nl
hyc.be.slides'
veluwefm.nl.slideshow_containerM
funnygames.be
funnygames.nl

spele.be

spele.nl.slot-container
solarmagazine.nl.sols&
live-voetbal.com.special-offer(
spidersolitairespelen.nl.spel_b1(
spidersolitairespelen.nl.spel_b2
	niburu.co	.sponsers2
sc-heerenveen.nl
bekijkporno.nl.sponsor(
omroephouten.nl.sponsor-carousel%
sc-heerenveen.nl.sponsor-grid 
radio0511.com.sponsorImg&
computable.be.sponsorartikelen)
amsterdamtigers.com.sponsorbanner
	nevobo.nl.sponsorbarB
businessinsider.nl
computable.nl
	24cars.nl
.sponsored
hoimedia.com
.sponsoren�
volleybelgium.be
nec-nijmegen.nl
fcgroningen.nl
ga-eagles.nl
mijnserie.nl
trappers.nl

cambuur.nl
az.nl	.sponsors#
fleet-mobility.nl
.spotlight<
	tvoost.be

robtv.be
atv.be
tvl.be.squareWrap
nos.nl.ster-banner$
autobahn.eu.sticky-incontent"
autobahn.eu.sticky-sidebar"
ninefornews.nl.stream-item0
despirituelewereld.be.stream-item-widget
iex.nl.strossle-widget
123video.nl.stunt-wide>
aalsmeervandaag.nl
dagbladdewest.com.swiper-wrapper
bekijkporno.nl.table
iexprofs.nl.tagwrapper.
koken.vtm.be.taxonomy-dedicated-header(
techpulse.be.td-banner-wrap-full
sportamerika.nl.tdi_133 
rtvpapendrecht.nl.tdi_149
bollenstreekomroep.nl
rtvpapendrecht.nl.tdi_36"
omroepspakenburg.nl.tdi_48
elegance.nl.tdi_58
waterkant.net.tdi_68
nu.nl.tealium3
volkskrant.nl
demorgen.be.teaser-branded
taaloefenen.nl	.tekstads 
nos.nl.teletekst__bannerK
startpagina.nl5.template-redesign-5-column-top-3-center-banner-outer�
deondernemer.nll.text-center > .mt-2.box-content.flex.min-h-25.max-w-full.overflow-x-hidden.bg-background-1.p-4.md\:min-h-10&
wanttoknow.nl.text-center.mb-3&
netonline.be.text_12_jobs_only2
meerdangewenst.nl.tg-site-footer-section-1$

topgear.nl.theme-advertorial

fantv.nl	.tm-top-a

fantv.nl	.tm-top-c!
startpagina.nl.top-banner�"
willem-ii.nl.top-bar-logos*
wijwedden.net.top-bookmaker-widget"
live-voetbal.com
.top-match�
volkskrant.nl
demorgen.be
margriet.nl

libelle.nl
	parool.nl

flair.nl

trouw.nl	
humo.be.top1-container@
escortgirls.be
topescort.nl
sexguide.nl.topBanners

negerin.nl.topban

waldnet.nl.topdesk

waldnet.nl.topmob
feyenoord.nl	.totoOdds=
chatmetvreemden.be
chatmetvreemden.nl.trackerclick0
computable.be
computable.nl
.true-logo
fok.nl.trueTop7
uecl-voetbal.nl
uel-voetbal.nl.uitgelichtboxA
nieuwnieuws.nl+.uk-text-center[style="min-height: 250px;"]A
nieuwnieuws.nl+.uk-text-center[style="min-height: 265px;"]0
nieuwsfiets.nu.ult-content-box-container)
nieuwsfiets.nu.us_custom_7370a357%
beursgorilla.nl.ut--rectangle

gaynews.nl.va500
dartfreakz.nl.vc_btn3+
linuxmag.nl.vc_custom_1589883706945+
linuxmag.nl.vc_custom_1590576060705)
	jammfm.nl.vc_custom_15973924761353
voetbalrotterdam.nl.vc_custom_1620132793304
kieskeurig.nl.vda!
	vagina.nl.video-fish-hook!
mo.be.view-id-banners_top"

nnieuws.be.view-vw-banners.
rubenweytjens.be.view-weather-ads-view
vi.nl.vinl-promotionBarE
marktplaats.nl
2dehands.be .vip-banner-top-sticky-container*
moviemeter.nl.vod-widget-container4
wordfeudhelp.nl.w-full.my-6.text-center.hoogB
dingenvoorvrouwen.nl
autobahn.eu

playboy.nl	.wb-label
osuradio.nl	.wdslider 
isgeschiedenis.nl.webads6
baarsclassicrock.nl
tweakers.net.widebanner
tweakers.net.widebnr4
basketballbelgium.be.widget-aoclubs-sponsors)
handbalstartpunt.nl.widget-banner)
onderwijsland.com.widget-partners)
indebuurt.nl.widget-tabs--partner*
indebuurt.nl.widget-tabs--partners}
wos.nlo.widget.rounded-lg.lg\:rounded-2xl.p-1.lg\:p-4.border.overflow-visible.lg\:w-full.lg\:max-w-\[754px\].\!mx-auto%
autoblog.nl.widget_ab_sidebar#
	nieuws.nl.widget_add_widget�
tiener-sexverhalen.nl
christelijknieuws.nl
wieheeftmijgebeld.nl
transport-online.nl
groningerkrant.nl
ecobioliving.eu
pokemonkaart.nl
ajaxfanzone.nl
jazzradar.com
visionair.nl
vmlnieuws.nl
iculture.nl

jazznu.com

klapjes.nl
	nljug.org.widget_custom_html%
mannenstyle.nl.widget_execphp0
riskcompliance.nl.widget_itarget_banners�
onlinekraslotenrss.nl
livestreamvandaag.be
feyenoordreport.nl
voetbalsnafu.nl
ajaxreport.nl
voetbal4u.com
psvreport.nl.widget_links(
infinance.nl.widget_links_widget�
tiener-sexverhalen.nl
rtvalbrandswaard.com
noordkopcentraal.nl
daemesenheeren.nl
eindtijdklok.org
omroeptholen.nl
sliedrecht24.nl
radionova.be
	nljug.org
	rtveen.nl.widget_media_image4
noordkopcentraal.nl.widget_metaslider_widget'
schuttevaer.nl.widget_minisites8
vlootschouw.nl".widget_miw_widget_multiple_images�
automobielmanagement.nl
rijschoolpro.nl
verkeersnet.nl
carwashpro.nl
mobiliteit.nl
infrasite.nl
spoorpro.nl

tankpro.nl

taxipro.nl

ovpro.nl.widget_nlpartners0
rtvideaal.nl.widget_random_banner_widget/
tubelight.nl.widget_sp_image-image-link&
123geldzaken.nl.widget_sponsor-
radioreflex.be.widget_sponsors_widget0
spreekbuis.nl.widget_spreekbuis_partnersQ
wielerflits.be
wielerflits.nl).wielerflits_ros_bravo_rectangle-halfpage 
telegraaf.nl.withBanners 
indebuurt.nl.woty-banner�(
streamwijzer.nl.wp-block-buttons#
debestevpn.nl.wpsm_promobox,

iphoned.nl.wrap.hidden.lg\:flex.mt-8W
androidworld.nl@.wrap.overflow-hidden.relative.pt-5.z-30.sm\:h-\[90px\].sm\:pt-0#

beurs.nl.wrapper--topbanner'
voetbalprimeur.nl[class^="Ad_"]"
	bright.nl[class^="Ad_ad_"]'
at5.nl[class^="Advertisement_"]'

gamer.nl[component-export="Ad"]5
androidplanet.nl[data-name="featured-header"]&	
9292.nl[data-testid^="gpt-ad"],
indeleiderstrui.nl[data-ub-carousel]-
delhaize.be[id*="sponsored_products"]&
regionoordkop.nl[id^="regio-"]0
geenstijl.nla[data-ga-event^="link-tip"]9
nbs-bouwmaterialen.nla[data-testid="linkElement"]'
nu.nla[data-type="advertorial"]#
cip.nla[href*="/ad/click/"]%
nu.nla[href*="/advertorial-"]8

seks.com(a[href*="https://sexlijnen.anoniem.nl/"].

gaynews.nla[href^="/_global/_cp.php?"].

gaynews.nla[href^="/_global/_fp.php?"]*

biernet.nla[href^="/bja/ga-naar/"](
nummerzoeker.coma[href^="/out/"]@
zeelandnet.nl+a[href^="http://partnerprogramma.bol.com/"]5
voetbalvandaag.bea[href^="http://unibet.me/"]@
racexpress.nl+a[href^="http://www.onderdelenstore24.nl/"]N
sexervaringendelen.nl1a[href^="http://www.rushcommerce.com/click.php?"]8
focus-wtv.be$a[href^="https://ads.focus-wtv.be/"]:
voetbal4u.com%a[href^="https://b1.trickyrock.com/"]+
	emerce.nla[href^="https://bit.ly/"]C
autobahn.eu

playboy.nl"a[href^="https://casinoscout.nl/"]0
tennisplaza.bea[href^="https://ds1.nl/"]�
wereldstopcontacten.nl
nieuwsuitnijmegen.nl
wijchensnieuws.nl
ecobioliving.eu
radiozenders.fm
bestetop5.nl
nailtalk.nl#a[href^="https://partner.bol.com/"]?
nailtalk.nl,a[href^="https://partnerprogramma.bol.com/"]/
zeelandnet.nla[href^="https://prf.hn/"]>
opwindend.net)a[href^="https://spannendsexcontact.nl/"]<
sexervaringendelen.nla[href^="https://tinyurl.com/"]K
doorbraak.be7a[href^="https://vnz.be"] > .w-full.object-contain.mb-21	
gids.tv"a[href^="https://www.autodoc.be/"];

ajax1.nl+a[href^="https://www.awin1.com/cread.php?"]@
bollywood.nl,a[href^="https://www.onderdelenshop24.com/"]@
omrekenen.org+a[href^="https://www.onlinebingokaart.nl/"]C
ijshockeynederland.nl&a[href^="https://www.trexrubber.com/"]8
tweakers.net$a[href^="https://www.true.nl/?utm_"]<
tweakers.net(a[href^="https://www.truefullstaq.com/"]M
edelmetaal-info.nl3a[onclick^="javascript:pageTracker._trackPageview"];
gostreaming.nl
tennisplaza.bea[rel*="sponsored"]3
oisterwijknieuws.nla[target="_blank"] > img(
hoekschnieuws.nlcenter > a > img)
	pcmweb.nldiv.block:nth-of-type(1))
	pcmweb.nldiv.block:nth-of-type(2)A
oisterwijknieuws.nl&div[align="center"] a[target="_blank"]`
hartvannederland.nl
vandaaginside.nl
shownieuws.nl div[class*="-bannerTopWrapper-"]]
hartvannederland.nl
vandaaginside.nl
shownieuws.nldiv[class*="-bannerWrapper-"],
meteovista.bediv[class*="AdWrapper"])
agconnect.nldiv[class*="ad-slot"]�
ditjesendatjes.nl
webwoordenboek.nl
whiskymonkeys.com
voetbalnieuws.be
kidsenkurken.nl
meemetoranje.nl
wielernieuws.be
lovereality.nl
mannenzaken.nl
gloednieuw.nl
showupdate.nl
crimesite.nl
headliner.nl
looopings.nl
nieuws365.be
voetbal14.nl
klusidee.nl
nextplay.nl
showblad.nl
skoften.net

fem-fem.nl

gpinfo.com

reality.nl
	tvblik.nl	
puna.nl
fok.nldiv[class*="r89-"])
omroepbrabant.nldiv[class^="ad-"];
deondernemer.nl

vtwonen.nldiv[class^="adBlock_"]=
omroepbrabant.nl
reclamefolder.nldiv[class^="ad_"]1	
zoom.nl"div[class^="display-ad_container"]*
klimaatinfo.nldiv[class^="space_"]5
weeronline.nl div[class^="styled__AdWrapper-"]�;
weeronline.nl&div[class^="styled__FooterAdWrapper-"]!
autobahn.eudiv[data-aaad]&
rtl.nldiv[data-adslot-variant]2
basketball.nldiv[data-component="partner"].
telefoonboek.nldiv[data-role="csaads"]/
meerradio.nldiv[id="pristineslider.12"]$

drimble.nldiv[id^="ASTAGQ_"])
motokicx.comdiv[id^="adtemplate"]/
alblasserdamsnieuws.nldiv[id^="albla-"]$

sexjobs.nldiv[id^="banner-"];
motorrijder.be
motokicx.comdiv[id^="bannerhome"] 	
nuus.bediv[id^="beiaa-"]1
gewoonvoorhem.nldiv[id^="below-article-"]"
	trosfm.bediv[id^="dries-"],
dutchcryptotalk.comdiv[id^="dutch-"]*
duurzaamnieuws.nldiv[id^="duurz-"])
handbalinside.nldiv[id^="handb-"]'
nauticlink.comdiv[id^="nauti-"]&	
jaap.nldiv[id^="property_ad_"]n
gewoonvoorhem.nl
soccernews.nl
girlscene.nl

fem-fem.nl

reality.nl
tpo.nldiv[id^="r89-"]"
	revive.nldiv[id^="reviv-"])
voetbalbelgie.bediv[id^="voetb-"]&
zeilwereld.nldiv[id^="zeilw-"].

waldnet.nldiv[style*="height: 560px;"]<

apintie.sr*div[style*="width: 300px; height: 250px;"]:

apintie.sr(div[style*="width:300px; height:250px;"]:
routenet.nl'div[style*="width:730px; height:90px;"]v

waldnet.nlddiv[style="clear: both; height: auto; text-align: center; padding-top: 50px; padding-bottom: 50px;"]-

waldnet.nldiv[style="height: 300px;"]Z
bitcoinmagazine.nl
indeleiderstrui.nl
f1maximaal.nldiv[style="height:52px;"]Z
welingelichtekringen.nl
nextplay.nl,div[style="margin-top:0px;min-height:250px"]Z
welingelichtekringen.nl
nextplay.nl,div[style="margin-top:0px;min-height:252px"]Y
welingelichtekringen.nl
nextplay.nl+div[style="margin-top:0px;min-height:90px"]T
voetbalrotterdam.nl9div[style="max-width: 728px; width: 100%; height: 90px;"]R
voetbalrotterdam.nl7div[style="max-width:300px; width:100%; height:250px;"]2
skoften.netdiv[style="min-height: 250px;"]2
skoften.netdiv[style="min-height: 265px;"]J
gamereactor.nl4div[style="min-height: 600px; margin-bottom: 20px;"]G

waldnet.nl5div[style="padding-top: 30px; padding-bottom: 30px;"]U
spellingoefenen.nl;div[style="text-align: left; height: 320px; width: 240px;"]8

gamer.nl(div[style="width: 100%; height: 280px;"]@
landbouwgrond.nu(div[style="width: 100%; height: 320px;"]�
ammoniakrechten.nl
pluimveerechten.nu
varkensrechten.nu
landbouwgrond.nu
mechanisatie.nl
koemarkt.nl

fosfaat.nu
	quotum.nu

efarm.nl3div[style="width:100%;height:320px;display:block;"].

waldnet.nldiv[style^="height: 280px;"]E
sommenoefenen.nl-div[style^="max-width: 960px; height:280px;"]1
starnieuws.comdiv[style^="width : 250px"]<

apintie.sr*div[style^="width: 300px; height: 180px;"]>
autosport.nl*div[style^="width: 300px; height: 427px;"]:

apintie.sr(div[style^="width:300px; height:180px;"]:

finance.nl(div[style^="width:300px; height:250px;"],
oisterwijknieuws.nlimg[alt="banner"]#

jazznu.comimg[alt="jazznu"]%
racesport.nlimg[height="250"]=
camping-frankrijk.nl!img[style*="234px; height: 60px"]9
rotterdambasketbal.nlimg[title^="roba_sponosor_"]2
crimesite.nlimg[width="120"][height="240"]3
dartfreakz.nlimg[width="120"][height="600"]%
partyflock.nlimg[width="140"]%
partyflock.nlimg[width="160"]/
	gratis.nlimg[width="160"][height="600"]1
prewarcar.nlimg[width="160"][height="92"]=
rtvmiddenholland.nl
climaximaal.nlimg[width="200"]#
webstick.nlimg[width="220"]"

jazzism.nlimg[width="250"]�,
>��08@R.agconnect.nl#?#.c-teaser:has(.c-pill--partner)
E��08@R5delhaize.be#?#.product-item:-abp-contains(Gesponsord)
o��08@R_krefel.be#?#div[class^="Flex-styled__StyledFlex-"]:has(h3:-abp-contains(Gesponsorde producten))
U��08@REmarktplaats.nl#?#.hz-Listing--list-item:-abp-contains(Topadvertentie)
q��08@Ra2dehands.be#?#.hz-Listing--list-item:-abp-has(.hz-Listing-priority:-abp-contains(Topadvertentie))
]��08@RMalmere-nieuws.nl#?#.wpb_wrapper:has(.section-heading:-abp-contains(partners))
���08@R�amstelveensnieuwsblad.nl,baarnschecourant.nl,barneveldsekrant.nl,bennekomsnieuwsblad.nl,biltschecourant.nl,deputtenaer.nl,derijnpost.nl,destadamersfoort.nl,destadgorinchem.nl,dewoudenberger.nl,edestad.nl,ermelosweekblad.nl,harderwijkercourant.nl,hcnieuws.nl,hetkompashardinxveld-giessendam.nl,hetkompassliedrecht.nl,houtensnieuws.nl,huisaanhuiselburg.nl,huisaanhuisoldebroek.nl,leusderkrant.nl,nieuwsbladdekaap.nl,nunspeethuisaanhuis.nl,recreatiekrantveluwe.nl,regiosportveenendaal.nl,rijnenveluwe.nl,scherpenzeelsekrant.nl,soestercourant.nl,stadnijkerk.nl,stadwageningen.nl,weekbladvoorouderamstel.nl,wijksnieuws.nl#?#.component__plugin:has(h6:-abp-contains(advertentie))
b��08@RRautobahn.eu#?#.d-none.d-md-block.mb-3:-abp-has(a[target="_blank"][rel="noopener"])
[��08@RKbuienradar.nl#?#.linklist:-abp-has(h1:-abp-contains(Lekker Dichtbij Deals))
c��08@RSbusinessinsider.nl#?#.widget_custom_html:-abp-has(h2:-abp-contains(Beter Beleggen))
{��08@Rkduurzaamnieuws.nl#?#.avia_codeblock_section:-abp-contains(Duurzaamnieuws wordt mede mogelijk gemaakt door:)
R��08@RBfonq.nl#?#[data-cy="plp-tile-container"]:-abp-contains(Gesponsord)
6��08@R&fonq.nl#?#li:-abp-contains(Gesponsord)
y��08@Rigeenstijl.nl#?#.article.row.no-image:-abp-has(.row.compost-warn:-abp-contains(- ingezonden mededeling -))
_��08@ROglutenvrij.nl#?#.Article__inner:has(.Article__title:-abp-contains(Advertentie))
V��08@RFhardware.info,tweakers.net#?#:-abp-properties(content: "Advertentie";)
m��08@R]linda.nl#?#.article-column_article:-abp-has(.category-label_label:-abp-contains(Advertorial))
��08@Rolinda.nl#?#.article-row_article:-abp-has(.article-row_category.category-label_label:-abp-contains(Advertorial))
[��08@RKmediamarkt.be,mediamarkt.nl#?#[data-index-number]:-abp-contains(Gesponsord)3
dartfreakz.nlimg[width="250"][height="250"]�
dagelijksestandaard.nl
deaandeelhouder.be
deaandeelhouder.nl
franekeractueel.nl
dagbladdewest.com
ninefornews.nl
ucl-voetbal.nl
creditexpo.nl
unitednews.sr
omroeprsh.nl
psvinside.nl

luister.nl

negerin.nl

fiets.nlimg[width="300"]6
regio-voetbal.nlimg[width="300"][height="100"]� 
goedkoopstekeukensduitsland.nl
yourlittleblackbook.me
mannennieuws.nl
streamwijzer.be
lflmagazine.nl
thatsgaming.nl
teqnation.com
advocatie.nlimg[width="300"][height="250"]&
ciaotutti.nlimg[width="300px"]*
franekeractueel.nlimg[width="310"]3
racexpress.nlimg[width="310"][height="200"]'
abcsuriname.comimg[width="320"].

vives.nlimg[width="330"][height="520"]&
nauticlink.comimg[width="336"]2
advocatie.nlimg[width="336"][height="280"]4
minimumloon.nlimg[width="350"][height="350"]"

jazzism.nlimg[width="400"]'
abcsuriname.comimg[width="420"]8
dutchcryptotalk.comimg[width="468"][height="60"]<
franekeractueel.nl
climaximaal.nlimg[width="500"]5
streamwijzer.beimg[width="500"][height="500"]"

jazzism.nlimg[width="600"]0

decibel.nlimg[width="640"][height="180"]6
nieuwsopbeeld.nlimg[width="640"][height="640"]8
volleyvlaanderen.beimg[width="670"][height="80"]#
webstick.nlimg[width="680"].
	wildfm.nlimg[width="699"][height="90"]<
rtvmiddenholland.nl
waterkant.netimg[width="720"]m
rtvmiddenholland.nl
cryptobenelux.com
ucl-voetbal.nl

pokeren.nlimg[width="728"][height="90"]3
ajaxinside.nlimg[width="750"][height="400"]"

jazzism.nlimg[width="843"]*
franekeractueel.nlimg[width="960"]:
basketballbelgium.beimg[width="970"][height="250"]1	
bol.com"section.js_slot-sponsored-products~
landenweb.nljtable[style="margin-left: auto; margin-right: auto; border: 1px solid; width: 100%; margin-bottom: 10px;"]7
radiocaramba.nl table[width="120"][height="600"])
fok.nl.col-1.h4:has(.sponsorsTxt)�
androidplanet.nl�.group.relative.flex-shrink-0.lg\:flex-shrink.lg\:first\:col-span-2.lg\:first\:row-span-2.w-\[300px\].lg\:w-auto.flex:has(div[data-name="sponsor-logo"])T
investmentofficer.nl8.io-tape-card__wrap:has(.io-tape-card__label__sponsored)^	
weer.nlO.items-center.w-full.justify-center:has(div[data-advert-placeholder-collapses])H
indebuurt.nl4.list-item.list-item--aagje:has(.list-item__sponsor)E
welingelichtekringen.nl&.post:has(a[href*="/partnerposting/"])K
ah.nl>.product-card-portrait_root__ZiRpZ:has(.promotion_root__pAAlu)-
	tvgids.nl.square-item:has( > .banner)3	
plus.nl$a[data-link]:has(.sponsored-product)P
androidplanet.nl8div[data-name="post"]:has(div[data-name="sponsor-logo"])6	
bol.com'li.js_item_root:has(.dsa__list-padding)�
feijenoordnieuws.nll.cv-table-left > a:not([target="_blank"]):not([rel="nofollow"]):not(a[href^="https://feijenoordnieuws.nl/"])l
mediamarkt.be
mediamarkt.nlF[data-test="mms-product-card"]:has(div[data-test="mms-plp-sponsored"])�
g��08@RWmnm.be#?#.grid-item.grid-item-pebble:-abp-has(#pebble-label:-abp-contains(Advertentie))
Y��08@RImoviemeter.nl#?#.footer-artikelen:has(.footer-h6:-abp-contains(Partners))
h��08@RXnieuwsopbeeld.nl#?#.td_module_wrap:-abp-has(.td-post-category:-abp-contains(Gesponsord))
]��08@RMpsvinside.nl#?#.td_block_template_1:has(.block-title:-abp-contains(Partners))
c��08@RStijd.be#?#.o-hpgrid__row-tijdconnect:-abp-has(h2:-abp-contains(Gesponsorde inhoud))
~��08@Rntostrams.nl#?#section.network:-abp-has(.contentheader.contentheader--network:-abp-contains(Gesponsorde links))
I��08@R9tvvisie.be,tvvisie.nl#?#.side:-abp-contains(Aanbiedingen)
���08@R�vi.nl#?#.c-articles-list__item.c-articles-list__item--highlight:-abp-has(.c-tag.c-articles-list__label:-abp-contains(Advertorial))
O��08@R?voetbalcentraal.nl#?#.blok:-abp-has(h3:-abp-contains(Partners))
[��08@RKweer.nl#?#.shadow-lvl-2:-abp-has(a[href^="https://www.voordeeluitjes.nl/"])
`��08@RPwielerflits.nl#?#.widget-container:-abp-has(.h3.mb-4:-abp-contains(Wielerdeals))
`��08@RPwielerflits.nl#?#li.list-item.list-item-aside:-abp-has(.badge:-abp-contains(Ad))
`��08@RPwielerflits.nl#?#li.list-item.list-item-default:-abp-has(span:-abp-contains(Ad))
@��08@R0wintersport.nl#?#.mb-6:-abp-contains(gesponsord)
S��08@RCwkdarts.nl#?#.wpb_wrapper:-abp-has(div:-abp-contains(#advertentie))	
bokt.nl.ad-body$
gratisaftehalen.nl
.ads-image$
wereldklokken.nl.adsbygoogle-
mechanisatiemarkt.nl.advert-container)
mechanisatiemarkt.nl.advert-title,
paginamarkt.nl
fok.nl.advertentie'
mechanisatiemarkt.nl.advertiser
veeteelt.nl.advertorial.
modekoninginmaxima.nl.after-content-ad!
vakantieplaats.nl.feed-ad	
bokt.nl.node-ad�
casinovergelijkingen.com
vergelijkbookmakers.nl
blockchainvandaag.com
livestreamvandaag.be
cryptobelegging.com
cryptotoekomst.com
feyenoordreport.nl
formula1report.com
voetbalnotering.nl
fultimateteam.com
gamblingreport.nl
voetbalvisie.com
casinoreport.nl
voetbalsnafu.nl
ajaxreport.nl
psvreport.nl

ajaxrss.nl.top-ads-block!
directwonen.nl.top-advert 
vakantieplaats.nl.topAds
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-RU

_Skipped binary or large file. Size: 1211986 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Subresource Filter/Unindexed Rules/10.34.0.84/Part-ZH

_Skipped binary or large file. Size: 702705 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/TrustTokenKeyCommitments/2026.3.23.1/_metadata/verified_contents.json

``json
[{"description":"treehash per file","signed_content":{"payload":"eyJjb250ZW50X2hhc2hlcyI6W3siYmxvY2tfc2l6ZSI6NDA5NiwiZGlnZXN0Ijoic2hhMjU2IiwiZmlsZXMiOlt7InBhdGgiOiJMSUNFTlNFIiwicm9vdF9oYXNoIjoiUGIwc2tBVUxaUzFqWldTQnctV0hIRkltRlhVcExiZDlUcVkwR2ZHSHBWcyJ9LHsicGF0aCI6ImtleXMuanNvbiIsInJvb3RfaGFzaCI6IndrTDI5Mng5YnI2S2RDa19EclBQWFc3OHFEUWllRWN2M3NXdmZ6d0s0X2MifSx7InBhdGgiOiJtYW5pZmVzdC5qc29uIiwicm9vdF9oYXNoIjoiZnFtUEl3aXB4UjBYb2F4eHRrcjc0cVFmOEtDRG9XYWc1TXhDaV9SUEJ4VSJ9XSwiZm9ybWF0IjoidHJlZWhhc2giLCJoYXNoX2Jsb2NrX3NpemUiOjQwOTZ9XSwiaXRlbV9pZCI6ImtpYWJoYWJqZGJramRwamJwaWdmb2RiZGptYmdsY29vIiwiaXRlbV92ZXJzaW9uIjoiMjAyNi4zLjIzLjEiLCJwcm90b2NvbF92ZXJzaW9uIjoxfQ","signatures":[{"header":{"kid":"publisher"},"protected":"eyJhbGciOiJSUzI1NiJ9","signature":"n1oJ4gl6pg0qX5bsAw811AGmrsYS0Jk8o466nc1IkiD4d_D51HnmNyd0aXKRkuRNl-oLcK1In1-zzKx-UyNYdDF0C-mwHiKAfh6Mvpn2SfaGq5D-rQyohjP6Fo6iypfruQ3iAXLGcDx9g1lv0PITkaMadgVbAoWlr9EMyT34yIoz99qv989bcHt3nlZj6nEJ2anq1Vz0r8A9v3sP-c-yky3kRm9vJyuzTJTguJLUKsFIaeUv90r9_wYU6_pTzC6qSmsoRdIvADrciIVBiNaKCtXkMxiuX5KcDKRuMPXmeHTa7M9CzZFY8Dc09rQym5ktQyAGVpw_4n4JU1tlpUBttSzuHZTq62yHckd7EME6ponpPEtrQ8wCO10t-OeYrsTk5FBWh-GqKEjn8tpa26WzxAW1HBuxLv9cdkdSv9vxXIbCB7nq7J7fiaXfvTJXJHkD9GeL6yt4wo1tT2r9hV8DxJBIewKUkZ1HTfquN6bU4XvTOOJcfXl2sli_wZHlI-rvTtweZaGl1OeRQcVJKFxUgvUPmcM_2ik7SxPrsazeU88sjXUBAuiCguYSqUihYpRKMHMlGSpCyXZtAl2y-G3Va75brCbqRauBK4j4uXTuTrh086_0B86ijsu_ayn7KmIkDrYhzVfJlpikYnhF6F54HrNgwePvMwkvmEFsHdfOrNY"},{"header":{"kid":"webstore"},"protected":"eyJhbGciOiJSUzI1NiJ9","signature":"DVeoYsZMxDIPF5S8O3UwsgL2I_2bcuWI3tAPTvAb9hhnn8pXlOnQzSmg43nTDh7aWDED-toZiWpEHayJldSW2z69-P9hOyaN_2UKTJmXyzhQSR10SzhiS608kM3Pl1eVsbe1xPyfFt21stjvr1tVm1xIFaI8Jzuu-4m4Q610uuxlsw5ZdB1jMNINNtlsaj5UhBHjIAjEtzNrdZSU5JKlSXq__COrMR18V23gf0TjiOpToxZn0LOJu63hIsLHhuE4cSmdjM-pu4xrwmCSSG61_vI7FQhwmxr1rdJLmieD3r795mKLJlY50LYtOs2RYQEfLjU11DbP-527Z_bO4iS3Tg"}]}}]
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/TrustTokenKeyCommitments/2026.3.23.1/keys.json

``json
{"https://issuer.captchafox.com":{"PrivateStateTokenV1VOPRF":{"batchsize":1,"id":1,"keys":{"0":{"Y":"AAAAAQQiyE+SESbq7GU5rTx6tZO4tBOxljp+Oya2mU28O+YoALIyXlLLqnl/h5h95ExYSsOlmMIb8EdsJBTrCaDl/KIZSskrfMbZpjhShG0jwnbXojEHI9WaAxKLkX/A/DkyMEg=","expiry":"1734807628115000"},"1":{"Y":"AAAAAQRNtld+5LLBquS4bEJKJwlLw61tzIyqTNkvMVnUTu+YiphbdGrRCjeDTN9D3p1Tgpfmq0N/OKMBYWzDMEN8Km9p9s49c6N2ph4B1MV1m7Ogdj969MOsTw54Kc849oqDl8s=","expiry":"1734807628115000"},"2":{"Y":"AAAAAQSBWW003A3ORFURCZrWNnbEIH15yzk184DaLSebbGzRdyCYtAM1qhhVmXZyBtWTzh6Bfkk5rLPyE1xdQilofPBizF/QJsdaMU0GYhPW1sOU4xoKbmgd/XrnOoFqA2ETOuc=","expiry":"1734807628115000"},"3":{"Y":"AAAAAQSG/ftGdm5B6iwAmVsHt6s43xx3nRf/Vpx9GdeEt3jSTM8hHvyLE9FAEkinGjt4Fp5EjnkCdE96Cxz10nZJRrMApIrGhG5kAoDu4T8PjJPiFQFyHAOdTG7OJWi2NS/rl1A=","expiry":"1734807628115000"},"4":{"Y":"AAAAAQT36tqe550UP5A+4Eokt8iuPZEuWQc9cGJXd7zUCZzrsqtGu3PMcVbOj5DjC4W+yoyF3HqKOqdtiBWgcMsZOcyln/6jUKqf5tS9AoIHa9CC3kQB8ISQd3lhR5j+qWVY8ms=","expiry":"1734807628115000"},"5":{"Y":"AAAAAQQMjaLNCR8+YpP7wuJc8LswYI6Lofx+FIzgc3YRXAZg1xPVUR0PanCmne8q9vAPJHXrHwpytYAO/p+7wy+7pV9OGY8S3atKypUVBKa/1+jo7pokpuI0OQKFWtEOZBaM0Hw=","expiry":"1734807628115000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}},"https://my.contentpass.net":{"PrivateStateTokenV1VOPRF":{"batchsize":1,"id":1,"keys":{"1":{"Y":"AAAAAQSf54hDCPXvAfUGtHrxk8Wh3Xz5ojzIZL92OEMw8+1kZ9mXgHPTsInoWDEYroazoszJ8uJxsRUFA5+7V6ZzFOS7eISbYKQsjWZ0Ke2y4QpJqJkIqyI4VL7t2pg1ecaGC5M=","expiry":"1787615999000000"},"2":{"Y":"AAAAAQSE5dWqi59F+gqKzkvHifdLTNOquNCUdxEYQCOiqe575r6uF0DW9kOVO+jIgpu86Dg7xdUrzeoO8C6i3EGUtVY4wijUeEY/0hh1jLOMHcYlloPcEBo+Od+iPyynq6Cb11o=","expiry":"1787615999000000"},"3":{"Y":"AAAAAQQvUG/hrBtboBLDQTRvc2ZRo/Y+HceHJ+wP3U8irklIAi8tIwhJ6blzq2CI4oLCZrn/paxKTIJQfayrSBbH4euvixhvTg+p7gpWzi5RH+bo7BBb+c84T8+Wv/oofIWZNrI=","expiry":"1787615999000000"},"4":{"Y":"AAAAAQQEmTum5iqRCTnHSWmAlUQ2J5ozHTrZ3nU07O9Dg4/a2mkj64ykL4ClkWrerN0zUNQy6wqiGmhReXfsjpfV1NGcULJAZD+i+3W6kkzhJqdDzhdn0lrZmSZrxGTivYE0bR4=","expiry":"1787615999000000"},"5":{"Y":"AAAAAQRmL3mJryWwT1DLuxN5cA0Mt6yk2FHkh9XOiZ9m9jujvjikAStmwDo4YYatqyV0qGBx7xRPfqOpnRm61JEfpjWVDSuVYMOYK4Cavz+NmSf5bnkN/uFlThzzw4WSyn0i3aY=","expiry":"1787615999000000"},"6":{"Y":"AAAAAQSu1AVEWGbA17aWGZ9hp9wKOoIg59lB39ssOspo/AiCnmkfBWU8kKT3fuLHrKLfAc2djgGPx7BfAHvR6JHalxMfrfug750OGdEbQPcjgZVF1MFeiC4xV22QWdLbCOi5rLk=","expiry":"1787615999000000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}},"https://privatetokens.dev":{"PrivateStateTokenV1VOPRF":{"batchsize":1,"id":1,"keys":{"0":{"Y":"AAAAAARfsssbDuePtDrNZ3lM/UURh5OQuxpiyHSHc1pdoKOlfZ1EEPEWMyjMs4RUBi04PGIH/2Ydu9DkhJBPOB8L3KvWrGzHY19bBVuYgypnPi1bFWV8FiVS7LTk4bQ6bUELZS8=","expiry":"1767139200000000"},"1":{"Y":"AAAAAQQf7weUF/kePEPj0OSOYXJFl5MtMxr8g0svnv/prKQJK/hXrKqyQCrfxWJaQcKvj0MqtJcAA0CMZUGO2+cEXXgVNsa9Rw3ozo5a69bRrcvwnu+DFfB/qrA+8vqB7HxSRyc=","expiry":"1767139200000000"},"2":{"Y":"AAAAAgQLbdTSLHbxKCt47+OFNTVxvvVenvsWvmB0GQrm0B7+fb+4Cr8DgkZ7O6cJ1XtJBN6pBocANfPtUMINbsFsrUrJILKj9zGuFbtlVUCnNTMxjgk6jhDGtvIrzoT2Tgj/Mqo=","expiry":"1767139200000000"},"3":{"Y":"AAAAAwSTuOrMb7Azhj0tzR0SBazJADihIRGWM3JMfCzAv38M7dAt3PrLa+yKQ2yJiyH43gbZo61I/AThxsw/55Bpo2mOZRfiRgYLiuuUceb5JJ69OLrkOuwAUyDJFsNGNXBy2m4=","expiry":"1767139200000000"},"4":{"Y":"AAAABASWQfNzun5KImUlkOvsg4iud4R4U+sOa2VjlUDMkrWB1S+q1qL/GuD3k687DQF/RfvbIbIeVkJZNyjobNqW7X4TsXU+lako/gxOBRqzl9aHaoMV9gk6EbvibY/XMD5AFDQ=","expiry":"1767139200000000"},"5":{"Y":"AAAABQR38by110bTSikIvk/oYI8eav69TFj3VrUNyc/Cj4dElEUIPqdpGUr2x+zH0vAs8+HD3lagql2JkzqncOEC5o6NX8bzWTTBxyNy7+uj9dYxy23jG0CFRxvJzLCRRTjuFZA=","expiry":"1767139200000000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}},"https://pst-issuer.hcaptcha.com":{"PrivateStateTokenV1VOPRF":{"batchsize":1,"id":1,"keys":{"0":{"Y":"AAAAAAQn0iKkl4Xm6zKsIwQxrjdWuG5y1Dx/HhjZEzg5gzHs/bMzXRC4YqKI8JtrTOg1kzZLcQT4hDYmeuEnGZRSS4ZBtEVwnbk72AH9CB3041g+A2Y8AvXdrBZyBJaswydxU70=","expiry":"1691836104000000"},"102":{"Y":"AAAAZgStKBZhkdiDfCd2M72lOVQEm/8Gs8OokCr6q689DfraBUy2OAqS3fT3CRtHcIFsHHWTmFKfYNYbhDV9lOTeJiwGh/o2c5kSPczpgca9LEoJoNvCttwUfhzApxRQipTktSs=","expiry":"1699612104000000"},"118":{"Y":"AAAAdgTPJ4DSXNbDsSzd0lau1l+PDvS7j7rvWaXeb8Dq+bVbsHi49gWgtAmOvEhrx7qqlsMbowW9oFp+8hpMz0iPetfzNlpZ/rgchHMVGA2mAcUUD6hZpLFwi/WzzjPNzNjghiU=","expiry":"1694428104000000"},"134":{"Y":"AAAAhgQdOOxzj3+ff1GYbZKKas301vAlY5T1+HuRLecI7+aSpZHiJDLBId96+sYqFQ9Lw2v5ZL2XrdNsIjcJQeZjMNeoKzRIU2+twrJx15zOsAS7UYrnwmwcKUNaIvK5z+ofVao=","expiry":"1697020104000000"},"135":{"Y":"AAAAhwQ7lqyWJhRd1vwnfh9CTyEwAfvtHx8aM3kUzK4t1yjAde2H6ncqmaeSt0wCDHWQXRf+1t4qDjHDaVA6SsKUEmWNZrJ++q07cVNyg586fFJhklASuCAVD8MLgiI0joPbSmQ=","expiry":"1697020104000000"},"165":{"Y":"AAAApQT5FOfKepPac+BaNNEDET5ISLG0gRu76JnhDZgdCE4YGlZslfaxQxo2AB6dqWXUzCxgnidfjlVjDdCOQSYJDPFmE2rRGNMVpvHfZD4dKwwErc+oqvxsf+LIftX3DO1B+zg=","expiry":"1697020104000000"},"171":{"Y":"AAAAqwQ3VONsOHn8vztPDJugYiBknSk2h76L4m9v89gLbfK33SvUKB/D/oj7uIO3WHnOidaxdJ9tqhd4ee+EZ/cj7iV3b3cuBFqFEJPPUcHkNJ+FnU3fQmePRn0ZJGasPUCZNA8=","expiry":"1694428104000000"},"226":{"Y":"AAAA4gSl5pqFtr6FxLm5p9Pn7OjO7fH/rp25nZ/1qX6643BJcuWIC/Q1fc2v19bHZE6PNdLyMeO8ZMkRH5rRi3CX1xg54UWtX0b0/rFOy1ErX2nLDTDXJvSAMrbZZwuCDf/QkfA=","expiry":"1699612104000000"},"253":{"Y":"AAAA/QTFOMQlDqoIjS5e99cmi1xLcbcIyqfvzulldtB0PfoZAza6czULN9fKDfVXud74aOkzIDpDA7Ejx1Zw/2nr477EGpCeMmP9MXAxiaOroKI0kBd38uWTaqCxKmFcd/l16Ic=","expiry":"1699612104000000"},"29":{"Y":"AAAAHQSYqY3WA/Kuzh1J0w+YBfvx8tNECkbuRvKNvTCV/EYQh/O+tZQuROyFVk4M/vr2mw7yPK/dJhyl8FRMUSVvuQ7r/Y59fnNxyvPAdiKNeRlZb8TKs/Ymf0H9RLneFz3rOfM=","expiry":"1691836104000000"},"70":{"Y":"AAAARgT+F/qLdVCJZazqkgDgmbBY7DhDF78vsw6pfT6cGVAMfg4WhdkbQlLQkzKlPMVy0XsqyN2S2tSLa+0hFA4R8+YJpCYf9QJzg/XAw43fZkbu/TX7+q623KsQeWPMiuj9qAs=","expiry":"1694428104000000"},"87":{"Y":"AAAAVwSR0P31+cA6fOgTBHGN545mu5vLETOCgN2+6R8Wa8mmOl8QqvG5QJ8JRp6IiTXzJE8piCaKV9LKWw824abZzkxth/nsBD1zpBngEXq+pV9313owOkkyhfFYop9QBipxj9s=","expiry":"1691836104000000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}},"https://pst.authfy.tech":{"PrivateStateTokenV1VOPRF":{"batchsize":1,"id":1,"keys":{"1":{"Y":"AAAAAQTGB+DcBu0tOGjsNGcx78cyXYSY00PwlVWb9KYMhKjtTNh4hOV38sFKGPJM3q2R4PWREwaVv0GhfH/ewJzx8AQnrXtXHM9q/gJS2NlhVHJ/v8lE9T31lA8IYA5qrNCdFAM=","expiry":"1722383999000000"},"2":{"Y":"AAAAAgSk04R1uzv+XeK/oSpt4dRquVrJxHSUv35gm6lNWKUlxoPBAOhYdtArOhpvFx7xCBRKhUy5m6bR/2APVwkM9bmaLbItpWqypvxILwqBJUmH4/6QLBZWWVB9vQSgxRWVaQw=","expiry":"1722383999000000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}},"https://trusttoken.dev":{"PrivateStateTokenV1VOPRF":{"batchsize":1,"id":1,"keys":{"0":{"Y":"AAAAAARfsssbDuePtDrNZ3lM/UURh5OQuxpiyHSHc1pdoKOlfZ1EEPEWMyjMs4RUBi04PGIH/2Ydu9DkhJBPOB8L3KvWrGzHY19bBVuYgypnPi1bFWV8FiVS7LTk4bQ6bUELZS8=","expiry":"1767139200000000"},"1":{"Y":"AAAAAQQf7weUF/kePEPj0OSOYXJFl5MtMxr8g0svnv/prKQJK/hXrKqyQCrfxWJaQcKvj0MqtJcAA0CMZUGO2+cEXXgVNsa9Rw3ozo5a69bRrcvwnu+DFfB/qrA+8vqB7HxSRyc=","expiry":"1767139200000000"},"2":{"Y":"AAAAAgQLbdTSLHbxKCt47+OFNTVxvvVenvsWvmB0GQrm0B7+fb+4Cr8DgkZ7O6cJ1XtJBN6pBocANfPtUMINbsFsrUrJILKj9zGuFbtlVUCnNTMxjgk6jhDGtvIrzoT2Tgj/Mqo=","expiry":"1767139200000000"},"3":{"Y":"AAAAAwSTuOrMb7Azhj0tzR0SBazJADihIRGWM3JMfCzAv38M7dAt3PrLa+yKQ2yJiyH43gbZo61I/AThxsw/55Bpo2mOZRfiRgYLiuuUceb5JJ69OLrkOuwAUyDJFsNGNXBy2m4=","expiry":"1767139200000000"},"4":{"Y":"AAAABASWQfNzun5KImUlkOvsg4iud4R4U+sOa2VjlUDMkrWB1S+q1qL/GuD3k687DQF/RfvbIbIeVkJZNyjobNqW7X4TsXU+lako/gxOBRqzl9aHaoMV9gk6EbvibY/XMD5AFDQ=","expiry":"1767139200000000"},"5":{"Y":"AAAABQR38by110bTSikIvk/oYI8eav69TFj3VrUNyc/Cj4dElEUIPqdpGUr2x+zH0vAs8+HD3lagql2JkzqncOEC5o6NX8bzWTTBxyNy7+uj9dYxy23jG0CFRxvJzLCRRTjuFZA=","expiry":"1767139200000000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}},"https://www.amazon.com":{"PrivateStateTokenV1VOPRF":{"batchsize":3,"id":2,"keys":{"0":{"Y":"AAAAAASYS4xoUXNZkFG9qw9D6tG414iVgVjLm8moh5c53vfSeUKnOEXtO+CL+FGCEYNh5xGEdkk6yfC9t5/MUkgJA6MwJ3Po7XwMkicnpGwR4mMiXTGCWiYK1FmU27ngETDxEfg=","expiry":"1811808000000000"},"1":{"Y":"AAAAAQTRulHfTLpd74bYeMAWlge1BTO+17QM7eBXsTAn4NAminHFWyw3mTrQCN1Hc+EZ17KJCi8gIQdk3JXHLD81PlsY8UBpAbjB0FyzLm7bWSpK3OnUnTiMNtN0698zLo4WD6s=","expiry":"1811808000000000"},"2":{"Y":"AAAAAgS7336yghS1ZxrDPkwQn3ozIpuKsPlC60mRnQnrL5Dek2drBidkLPTCT3X7wsqjVftFeAObr53x1m82m4D/BGctDLfgb74GOrlJjXPhFVLytRRn1SNfE9597e4zb16bens=","expiry":"1811808000000000"},"3":{"Y":"AAAAAwQSaa2zGmBBgZbHvtqe3YzSkWVErfvv7HCdtFGCJbW3+DZzgv8gi4S2Q/TL6cYlbNO6UILHl2GXJ0FzA6EcLQ1gmrjH6bEXH3NhDK/pu4Ryd5I/vZunHm8Z2Y4erRtzaWo=","expiry":"1811808000000000"},"4":{"Y":"AAAABASwJy8Xv9N6WehR8w/kFAWkNIAbaBydE9aCBrygVPgc9Z0J+WHj8on1YUkf0FFahc0Xjhrea50SLA66gibRx54d3/aUPx6f8Mc+uBwgTajtoBH4Kfb0rGXI7sRPokRBajs=","expiry":"1811808000000000"},"5":{"Y":"AAAABQTg74+7/u2f4azPVbI/3EB+u4w4EEI+Hdc7mkS4YYWR5PdU4osCQCevUpwAj4S0BG6sxVbABxw4nkkkBoTxUtGLVUWRXJ1Jdt051cfgrDHKs75odufr49rVjuJux4EjRfk=","expiry":"1811808000000000"}},"protocol_version":"PrivateStateTokenV1VOPRF"}}}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/TrustTokenKeyCommitments/2026.3.23.1/LICENSE

``text
// Copyright 2015 The Chromium Authors. All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//    * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//    * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/TrustTokenKeyCommitments/2026.3.23.1/manifest.json

``json
{
  "manifest_version": 2,
  "name": "trustToken",
  "version": "2026.3.23.1"
}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.exe.WebView2/EBWebView/Variations

``text
{"user_experience_metrics.stability.exited_cleanly":true,"variations_crash_streak":0}
````

## MiniZotero/bin/Debug/net8.0/MiniZotero.pdb

_Skipped binary or large file. Size: 71860 bytes._

## MiniZotero/bin/Debug/net8.0/MiniZotero.runtimeconfig.json

``json
{
  "runtimeOptions": {
    "tfm": "net8.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "8.0.0"
    },
    "configProperties": {
      "MVVMTOOLKIT_ENABLE_INOTIFYPROPERTYCHANGING_SUPPORT": true,
      "System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization": false
    }
  }
}
````

## MiniZotero/bin/Debug/net8.0/runtimes/linux-arm/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 1988676 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-arm/native/libSkiaSharp.so

_Skipped binary or large file. Size: 8008928 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-arm64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 2657280 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-arm64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 10848184 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-bionic-arm64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 11319008 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-bionic-x64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 11067616 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-loongarch64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 2721088 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-loongarch64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 10483856 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-arm/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 3017916 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-arm/native/libSkiaSharp.so

_Skipped binary or large file. Size: 14668264 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-arm64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 3880784 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-arm64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 18546040 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-loongarch64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 3577960 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-loongarch64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 11909384 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-riscv64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 2586112 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-riscv64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 9977480 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-x64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 3908472 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-musl-x64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 18452856 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-riscv64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 2318920 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-riscv64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 8627760 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-x64/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 2808040 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-x64/native/libSkiaSharp.so

_Skipped binary or large file. Size: 11170296 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-x86/native/libHarfBuzzSharp.so

_Skipped binary or large file. Size: 2735488 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/linux-x86/native/libSkiaSharp.so

_Skipped binary or large file. Size: 10358832 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/osx/native/libAvaloniaNative.dylib

_Skipped binary or large file. Size: 1529184 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/osx/native/libHarfBuzzSharp.dylib

_Skipped binary or large file. Size: 2922800 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/osx/native/libSkiaSharp.dylib

_Skipped binary or large file. Size: 15201456 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-arm64/native/av_libglesv2.dll

_Skipped binary or large file. Size: 5145088 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-arm64/native/libHarfBuzzSharp.dll

_Skipped binary or large file. Size: 1924640 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-arm64/native/libHarfBuzzSharp.pdb

_Skipped binary or large file. Size: 20967424 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-arm64/native/libSkiaSharp.dll

_Skipped binary or large file. Size: 10411080 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-arm64/native/libSkiaSharp.pdb

_Skipped binary or large file. Size: 84934656 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x64/native/av_libglesv2.dll

_Skipped binary or large file. Size: 5426176 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x64/native/libHarfBuzzSharp.dll

_Skipped binary or large file. Size: 1816088 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x64/native/libHarfBuzzSharp.pdb

_Skipped binary or large file. Size: 20918272 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x64/native/libSkiaSharp.dll

_Skipped binary or large file. Size: 11628576 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x64/native/libSkiaSharp.pdb

_Skipped binary or large file. Size: 84033536 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x86/native/av_libglesv2.dll

_Skipped binary or large file. Size: 4784128 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x86/native/libHarfBuzzSharp.dll

_Skipped binary or large file. Size: 1518624 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x86/native/libHarfBuzzSharp.pdb

_Skipped binary or large file. Size: 20705280 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x86/native/libSkiaSharp.dll

_Skipped binary or large file. Size: 10123288 bytes._

## MiniZotero/bin/Debug/net8.0/runtimes/win-x86/native/libSkiaSharp.pdb

_Skipped binary or large file. Size: 86761472 bytes._

## MiniZotero/bin/Debug/net8.0/SkiaSharp.dll

_Skipped binary or large file. Size: 462880 bytes._

## MiniZotero/bin/Debug/net8.0/System.IO.Pipelines.dll

_Skipped binary or large file. Size: 77984 bytes._

## MiniZotero/bin/Debug/net8.0/Tmds.DBus.Protocol.dll

_Skipped binary or large file. Size: 219136 bytes._

## MiniZotero/Converters/StarredBrushConverter.cs

``csharp
using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace MiniZotero.Converters
{
    public sealed class StarredBrushConverter : IValueConverter
    {
        private static readonly IBrush StarredBrush = new SolidColorBrush(Color.Parse("#FACC15"));
        private static readonly IBrush DefaultBrush = new SolidColorBrush(Color.Parse("#AAB6C6"));

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is true ? StarredBrush : DefaultBrush;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}

````

## MiniZotero/MiniZotero.csproj

``xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ApplicationManifest>app.manifest</ApplicationManifest>
    <AvaloniaUseCompiledBindingsByDefault>true</AvaloniaUseCompiledBindingsByDefault>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include="Models\" />
    <AvaloniaResource Include="Assets\**" />
  </ItemGroup>

  <ItemGroup>
    <Content Include="Assets\PdfJs\**\*.*" CopyToOutputDirectory="PreserveNewest" />
    <Content Include="Assets\PdfViewer\**\*.*" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Avalonia" Version="12.0.3" />
    <PackageReference Include="Avalonia.Controls.WebView" Version="12.0.1" />
    <PackageReference Include="Avalonia.Desktop" Version="12.0.3" />
    <PackageReference Include="Avalonia.Themes.Fluent" Version="12.0.3" />
    <PackageReference Include="Avalonia.Fonts.Inter" Version="12.0.3" />
    <PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.1" />
  </ItemGroup>
</Project>

````

## MiniZotero/Models/AppSettings.cs

``csharp
namespace MiniZotero.Models
{
    public sealed class AppSettings
    {
        public string? WatchFolderPath { get; set; }
    }
}

````

## MiniZotero/Models/DocumentItem.cs

``csharp
using System;
using System.Collections.Generic;

namespace MiniZotero.Models
{
    public sealed class DocumentItem
    {
        public DocumentItem()
        {
        }

        public DocumentItem(
            string id,
            string title,
            string filePath,
            string originalFilePath,
            DateTimeOffset addedAt,
            DateTimeOffset? lastOpenedAt,
            int lastReadPage,
            int lastZoomPercent = 120,
            bool isStarred = false)
        {
            Id = id;
            Title = title;
            FilePath = filePath;
            OriginalFilePath = originalFilePath;
            AddedAt = addedAt;
            LastOpenedAt = lastOpenedAt;
            LastReadPage = lastReadPage;
            LastZoomPercent = lastZoomPercent;
            IsStarred = isStarred;
        }

        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string OriginalFilePath { get; set; } = string.Empty;

        public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? LastOpenedAt { get; set; }

        public int LastReadPage { get; set; } = 1;

        public int LastZoomPercent { get; set; } = 120;

        public bool IsStarred { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }

        public List<string> Tags { get; set; } = [];
    }
}

````

## MiniZotero/Models/HighlightItem.cs

``csharp
using System;
using System.Collections.Generic;

namespace MiniZotero.Models
{
    public sealed class HighlightItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        public string DocumentId { get; set; } = string.Empty;

        public int PageNumber { get; set; } = 1;

        public string Text { get; set; } = string.Empty;

        public string Color { get; set; } = "yellow";

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public List<HighlightRect> Rects { get; set; } = [];
    }
}

````

## MiniZotero/Models/HighlightRect.cs

``csharp
namespace MiniZotero.Models
{
    public sealed class HighlightRect
    {
        public int PageNumber { get; set; }

        public double Left { get; set; }

        public double Top { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}

````

## MiniZotero/obj/Debug/net8.0/.NETCoreApp,Version=v8.0.AssemblyAttributes.cs

``csharp
// <autogenerated />
using System;
using System.Reflection;
[assembly: global::System.Runtime.Versioning.TargetFrameworkAttribute(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]

````

## MiniZotero/obj/Debug/net8.0/apphost.exe

_Skipped binary or large file. Size: 152064 bytes._

## MiniZotero/obj/Debug/net8.0/Avalonia/references

``text
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Base.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Controls.dll
C:\Users\huyho\.nuget\packages\avalonia.controls.webview\12.0.1\lib\net8.0\Avalonia.Controls.WebView.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.DesignerSupport.dll
C:\Users\huyho\.nuget\packages\avalonia.desktop\12.0.3\lib\net8.0\Avalonia.Desktop.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Dialogs.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.dll
C:\Users\huyho\.nuget\packages\avalonia.fonts.inter\12.0.3\lib\net8.0\Avalonia.Fonts.Inter.dll
C:\Users\huyho\.nuget\packages\avalonia.freedesktop.atspi\12.0.3\lib\net8.0\Avalonia.FreeDesktop.AtSpi.dll
C:\Users\huyho\.nuget\packages\avalonia.freedesktop\12.0.3\lib\net8.0\Avalonia.FreeDesktop.dll
C:\Users\huyho\.nuget\packages\avalonia.harfbuzz\12.0.3\lib\net8.0\Avalonia.HarfBuzz.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Markup.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Markup.Xaml.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Metal.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.MicroCom.dll
C:\Users\huyho\.nuget\packages\avalonia.native\12.0.3\lib\net8.0\Avalonia.Native.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.OpenGL.dll
C:\Users\huyho\.nuget\packages\avalonia.remote.protocol\12.0.3\lib\net8.0\Avalonia.Remote.Protocol.dll
C:\Users\huyho\.nuget\packages\avalonia.skia\12.0.3\lib\net8.0\Avalonia.Skia.dll
C:\Users\huyho\.nuget\packages\avalonia.themes.fluent\12.0.3\lib\net8.0\Avalonia.Themes.Fluent.dll
C:\Users\huyho\.nuget\packages\avalonia\12.0.3\ref\net8.0\Avalonia.Vulkan.dll
C:\Users\huyho\.nuget\packages\avalonia.win32\12.0.3\lib\net8.0\Avalonia.Win32.Automation.dll
C:\Users\huyho\.nuget\packages\avalonia.win32\12.0.3\lib\net8.0\Avalonia.Win32.dll
C:\Users\huyho\.nuget\packages\avalonia.x11\12.0.3\lib\net8.0\Avalonia.X11.dll
C:\Users\huyho\.nuget\packages\communitytoolkit.mvvm\8.4.1\lib\net8.0\CommunityToolkit.Mvvm.dll
C:\Users\huyho\.nuget\packages\harfbuzzsharp\8.3.1.3\lib\net8.0\HarfBuzzSharp.dll
C:\Users\huyho\.nuget\packages\microcom.runtime\0.11.4\lib\net5.0\MicroCom.Runtime.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\Microsoft.CSharp.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\Microsoft.VisualBasic.Core.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\Microsoft.VisualBasic.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\Microsoft.Win32.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\Microsoft.Win32.Registry.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\mscorlib.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\netstandard.dll
C:\Users\huyho\.nuget\packages\skiasharp\3.119.4-preview.1.1\ref\net6.0\SkiaSharp.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.AppContext.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Buffers.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Collections.Concurrent.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Collections.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Collections.Immutable.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Collections.NonGeneric.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Collections.Specialized.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ComponentModel.Annotations.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ComponentModel.DataAnnotations.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ComponentModel.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ComponentModel.EventBasedAsync.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ComponentModel.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ComponentModel.TypeConverter.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Configuration.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Console.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Core.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Data.Common.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Data.DataSetExtensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Data.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.Contracts.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.Debug.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.DiagnosticSource.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.FileVersionInfo.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.Process.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.StackTrace.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.TextWriterTraceListener.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.Tools.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.TraceSource.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Diagnostics.Tracing.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Drawing.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Drawing.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Dynamic.Runtime.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Formats.Asn1.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Formats.Tar.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Globalization.Calendars.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Globalization.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Globalization.Extensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.Compression.Brotli.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.Compression.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.Compression.FileSystem.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.Compression.ZipFile.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.FileSystem.AccessControl.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.FileSystem.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.FileSystem.DriveInfo.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.FileSystem.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.FileSystem.Watcher.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.IsolatedStorage.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.MemoryMappedFiles.dll
C:\Users\huyho\.nuget\packages\system.io.pipelines\8.0.0\lib\net8.0\System.IO.Pipelines.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.Pipes.AccessControl.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.Pipes.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.IO.UnmanagedMemoryStream.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Linq.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Linq.Expressions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Linq.Parallel.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Linq.Queryable.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Memory.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Http.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Http.Json.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.HttpListener.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Mail.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.NameResolution.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.NetworkInformation.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Ping.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Quic.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Requests.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Security.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.ServicePoint.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.Sockets.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.WebClient.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.WebHeaderCollection.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.WebProxy.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.WebSockets.Client.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Net.WebSockets.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Numerics.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Numerics.Vectors.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ObjectModel.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.DispatchProxy.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.Emit.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.Emit.ILGeneration.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.Emit.Lightweight.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.Extensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.Metadata.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Reflection.TypeExtensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Resources.Reader.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Resources.ResourceManager.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Resources.Writer.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.CompilerServices.Unsafe.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.CompilerServices.VisualC.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Extensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Handles.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.InteropServices.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.InteropServices.JavaScript.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.InteropServices.RuntimeInformation.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Intrinsics.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Loader.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Numerics.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Serialization.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Serialization.Formatters.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Serialization.Json.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Serialization.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Runtime.Serialization.Xml.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.AccessControl.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Claims.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.Algorithms.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.Cng.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.Csp.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.Encoding.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.OpenSsl.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.Primitives.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Cryptography.X509Certificates.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Principal.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.Principal.Windows.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Security.SecureString.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ServiceModel.Web.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ServiceProcess.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Text.Encoding.CodePages.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Text.Encoding.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Text.Encoding.Extensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Text.Encodings.Web.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Text.Json.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Text.RegularExpressions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Channels.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Overlapped.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Tasks.Dataflow.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Tasks.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Tasks.Extensions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Tasks.Parallel.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Thread.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.ThreadPool.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Threading.Timer.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Transactions.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Transactions.Local.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.ValueTuple.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Web.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Web.HttpUtility.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Windows.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.Linq.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.ReaderWriter.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.Serialization.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.XDocument.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.XmlDocument.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.XmlSerializer.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.XPath.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\System.Xml.XPath.XDocument.dll
C:\Users\huyho\.nuget\packages\tmds.dbus.protocol\0.92.0\lib\net8.0\Tmds.DBus.Protocol.dll
C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Ref\8.0.20\ref\net8.0\WindowsBase.dll

````

## MiniZotero/obj/Debug/net8.0/Avalonia/resources

_Skipped binary or large file. Size: 5234095 bytes._

## MiniZotero/obj/Debug/net8.0/Avalonia/Resources.Inputs.cache

``text
172619448fe6b37245909a1c01e6b03263b7d90294a95fe5e3dfaa47488c0998

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.AssemblyInfo.cs

``csharp
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Reflection;

[assembly: System.Reflection.AssemblyCompanyAttribute("MiniZotero")]
[assembly: System.Reflection.AssemblyConfigurationAttribute("Debug")]
[assembly: System.Reflection.AssemblyFileVersionAttribute("1.0.0.0")]
[assembly: System.Reflection.AssemblyInformationalVersionAttribute("1.0.0+97f9fd62092040ef16e5b48e2a5fc4ddfcb10e18")]
[assembly: System.Reflection.AssemblyProductAttribute("MiniZotero")]
[assembly: System.Reflection.AssemblyTitleAttribute("MiniZotero")]
[assembly: System.Reflection.AssemblyVersionAttribute("1.0.0.0")]

// Generated by the MSBuild WriteCodeFragment class.


````

## MiniZotero/obj/Debug/net8.0/MiniZotero.AssemblyInfoInputs.cache

``text
88875fddf6e21806cedbf4bbad7c9ee562854772288778cd8e8e2161156b32de

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.assets.cache

_Skipped binary or large file. Size: 28604 bytes._

## MiniZotero/obj/Debug/net8.0/MiniZotero.csproj.AssemblyReference.cache

_Skipped binary or large file. Size: 13364 bytes._

## MiniZotero/obj/Debug/net8.0/MiniZotero.csproj.BuildWithSkipAnalyzers

``text

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.csproj.CoreCompileInputs.cache

``text
2c702e432ae005d7b0adf1798ddd431bb977384b87d2dae0b9ab5a2d84db644e

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.csproj.FileListAbsolute.txt

``text
C:\tmp\MiniZoteroBuild\Assets\PdfJs\build\pdf.mjs
C:\tmp\MiniZoteroBuild\Assets\PdfJs\build\pdf.worker.mjs
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78ms-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\78ms-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\83pv-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\90ms-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\90ms-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\90msp-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\90msp-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\90pv-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\90pv-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Add-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Add-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Add-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Add-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-0.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-1.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-3.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-4.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-5.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-6.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-CNS1-UCS2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-0.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-1.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-3.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-4.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-5.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-GB1-UCS2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-0.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-1.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-3.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-4.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-5.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-6.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Japan1-UCS2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Korea1-0.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Korea1-1.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Korea1-2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Adobe-Korea1-UCS2.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\B5pc-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\B5pc-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\CNS-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\CNS-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\CNS1-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\CNS1-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\CNS2-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\CNS2-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\ETen-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\ETen-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\ETenms-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\ETenms-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\ETHK-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\ETHK-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Ext-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Ext-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Ext-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Ext-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GB-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GB-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GB-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GB-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBK-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBK-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBK2K-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBK2K-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBKp-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBKp-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBpc-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBpc-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBT-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBT-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBT-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBT-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBTpc-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\GBTpc-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Hankaku.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Hiragana.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKdla-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKdla-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKdlb-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKdlb-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKgccs-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKgccs-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKm314-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKm314-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKm471-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKm471-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKscs-B5-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\HKscs-B5-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Katakana.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSC-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSC-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSC-Johab-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSC-Johab-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSCms-UHC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSCms-UHC-HW-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSCms-UHC-HW-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSCms-UHC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSCpc-EUC-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\KSCpc-EUC-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\LICENSE
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\NWP-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\NWP-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\RKSJ-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\RKSJ-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\Roman.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UCS2-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UCS2-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UTF16-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UTF16-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UTF8-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniCNS-UTF8-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UCS2-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UCS2-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UTF16-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UTF16-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UTF8-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniGB-UTF8-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UCS2-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UCS2-HW-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UCS2-HW-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UCS2-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UTF16-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UTF16-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UTF8-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS-UTF8-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS2004-UTF16-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS2004-UTF16-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS2004-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS2004-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS2004-UTF8-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJIS2004-UTF8-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISPro-UCS2-HW-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISPro-UCS2-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISPro-UTF8-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISX0213-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISX0213-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISX02132004-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniJISX02132004-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UCS2-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UCS2-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UTF16-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UTF16-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UTF32-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UTF32-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UTF8-H.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\UniKS-UTF8-V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\V.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\cmaps\WP-Symbol.bcmap
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitDingbats.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitFixed.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitFixedBold.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitFixedBoldItalic.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitFixedItalic.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitSerif.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitSerifBold.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitSerifBoldItalic.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitSerifItalic.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\FoxitSymbol.pfb
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\LiberationSans-Bold.ttf
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\LiberationSans-BoldItalic.ttf
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\LiberationSans-Italic.ttf
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\LiberationSans-Regular.ttf
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\LICENSE_FOXIT
C:\tmp\MiniZoteroBuild\Assets\PdfJs\standard_fonts\LICENSE_LIBERATION
C:\tmp\MiniZoteroBuild\Assets\PdfViewer\index.html
C:\tmp\MiniZoteroBuild\Assets\PdfViewer\style.css
C:\tmp\MiniZoteroBuild\Assets\PdfViewer\viewer.js
C:\tmp\MiniZoteroBuild\MiniZotero.deps.json
C:\tmp\MiniZoteroBuild\MiniZotero.runtimeconfig.json
C:\tmp\MiniZoteroBuild\MiniZotero.dll
C:\tmp\MiniZoteroBuild\MiniZotero.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.csproj.AssemblyReference.cache
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\Avalonia\Resources.Inputs.cache
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\Avalonia\resources
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.GeneratedMSBuildEditorConfig.editorconfig
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.AssemblyInfoInputs.cache
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.AssemblyInfo.cs
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.csproj.CoreCompileInputs.cache
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.sourcelink.json
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.csproj.Up2Date
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\refint\MiniZotero.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\MiniZotero.genruntimeconfig.cache
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\obj\Debug\net8.0\ref\MiniZotero.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\build\pdf.mjs
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\build\pdf.worker.mjs
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78ms-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\78ms-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\83pv-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\90ms-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\90ms-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\90msp-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\90msp-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\90pv-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\90pv-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Add-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Add-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Add-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Add-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-0.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-1.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-3.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-4.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-5.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-6.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-CNS1-UCS2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-0.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-1.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-3.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-4.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-5.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-GB1-UCS2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-0.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-1.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-3.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-4.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-5.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-6.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Japan1-UCS2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Korea1-0.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Korea1-1.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Korea1-2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Adobe-Korea1-UCS2.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\B5pc-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\B5pc-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\CNS-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\CNS-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\CNS1-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\CNS1-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\CNS2-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\CNS2-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\ETen-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\ETen-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\ETenms-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\ETenms-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\ETHK-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\ETHK-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Ext-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Ext-RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Ext-RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Ext-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GB-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GB-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GB-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GB-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBK-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBK-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBK2K-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBK2K-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBKp-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBKp-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBpc-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBpc-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBT-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBT-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBT-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBT-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBTpc-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\GBTpc-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Hankaku.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Hiragana.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKdla-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKdla-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKdlb-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKdlb-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKgccs-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKgccs-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKm314-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKm314-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKm471-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKm471-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKscs-B5-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\HKscs-B5-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Katakana.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSC-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSC-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSC-Johab-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSC-Johab-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSCms-UHC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSCms-UHC-HW-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSCms-UHC-HW-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSCms-UHC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSCpc-EUC-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\KSCpc-EUC-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\LICENSE
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\NWP-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\NWP-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\RKSJ-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\RKSJ-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\Roman.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UCS2-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UCS2-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UTF16-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UTF16-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UTF8-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniCNS-UTF8-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UCS2-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UCS2-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UTF16-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UTF16-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UTF8-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniGB-UTF8-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UCS2-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UCS2-HW-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UCS2-HW-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UCS2-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UTF16-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UTF16-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UTF8-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS-UTF8-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS2004-UTF16-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS2004-UTF16-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS2004-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS2004-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS2004-UTF8-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJIS2004-UTF8-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISPro-UCS2-HW-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISPro-UCS2-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISPro-UTF8-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISX0213-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISX0213-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISX02132004-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniJISX02132004-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UCS2-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UCS2-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UTF16-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UTF16-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UTF32-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UTF32-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UTF8-H.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\UniKS-UTF8-V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\V.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\cmaps\WP-Symbol.bcmap
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitDingbats.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitFixed.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitFixedBold.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitFixedBoldItalic.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitFixedItalic.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitSerif.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitSerifBold.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitSerifBoldItalic.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitSerifItalic.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\FoxitSymbol.pfb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\LiberationSans-Bold.ttf
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\LiberationSans-BoldItalic.ttf
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\LiberationSans-Italic.ttf
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\LiberationSans-Regular.ttf
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\LICENSE_FOXIT
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfJs\standard_fonts\LICENSE_LIBERATION
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfViewer\index.html
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfViewer\style.css
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Assets\PdfViewer\viewer.js
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.exe
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.deps.json
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.runtimeconfig.json
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MiniZotero.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Base.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Controls.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.DesignerSupport.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Dialogs.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Markup.Xaml.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Markup.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Metal.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.MicroCom.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.OpenGL.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Vulkan.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Controls.WebView.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Desktop.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Fonts.Inter.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.FreeDesktop.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.FreeDesktop.AtSpi.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.HarfBuzz.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Native.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Remote.Protocol.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Skia.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Themes.Fluent.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Win32.Automation.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.Win32.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Avalonia.X11.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\CommunityToolkit.Mvvm.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\HarfBuzzSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\MicroCom.Runtime.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\SkiaSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\System.IO.Pipelines.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\Tmds.DBus.Protocol.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-arm64\native\av_libglesv2.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x64\native\av_libglesv2.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x86\native\av_libglesv2.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\osx\native\libAvaloniaNative.dylib
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-arm\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-arm64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-loongarch64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-arm\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-arm64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-loongarch64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-riscv64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-x64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-riscv64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-x64\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-x86\native\libHarfBuzzSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\osx\native\libHarfBuzzSharp.dylib
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-arm64\native\libHarfBuzzSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-arm64\native\libHarfBuzzSharp.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x64\native\libHarfBuzzSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x64\native\libHarfBuzzSharp.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x86\native\libHarfBuzzSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x86\native\libHarfBuzzSharp.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-arm\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-arm64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-bionic-arm64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-bionic-x64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-loongarch64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-arm\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-arm64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-loongarch64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-riscv64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-musl-x64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-riscv64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-x64\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\linux-x86\native\libSkiaSharp.so
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\osx\native\libSkiaSharp.dylib
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-arm64\native\libSkiaSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-arm64\native\libSkiaSharp.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x64\native\libSkiaSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x64\native\libSkiaSharp.pdb
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x86\native\libSkiaSharp.dll
C:\Users\huyho\source\repos\MiniZotero\MiniZotero\bin\Debug\net8.0\runtimes\win-x86\native\libSkiaSharp.pdb
C:\tmp\MiniZoteroBuild\MiniZotero.exe
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\build\pdf.mjs
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\build\pdf.worker.mjs
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78ms-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\78ms-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\83pv-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\90ms-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\90ms-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\90msp-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\90msp-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\90pv-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\90pv-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Add-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Add-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Add-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Add-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-0.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-1.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-3.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-4.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-5.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-6.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-CNS1-UCS2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-0.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-1.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-3.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-4.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-5.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-GB1-UCS2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-0.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-1.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-3.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-4.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-5.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-6.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Japan1-UCS2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Korea1-0.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Korea1-1.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Korea1-2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Adobe-Korea1-UCS2.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\B5pc-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\B5pc-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\CNS-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\CNS-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\CNS1-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\CNS1-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\CNS2-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\CNS2-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\ETen-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\ETen-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\ETenms-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\ETenms-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\ETHK-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\ETHK-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Ext-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Ext-RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Ext-RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Ext-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GB-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GB-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GB-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GB-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBK-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBK-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBK2K-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBK2K-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBKp-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBKp-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBpc-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBpc-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBT-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBT-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBT-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBT-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBTpc-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\GBTpc-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Hankaku.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Hiragana.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKdla-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKdla-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKdlb-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKdlb-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKgccs-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKgccs-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKm314-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKm314-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKm471-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKm471-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKscs-B5-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\HKscs-B5-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Katakana.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSC-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSC-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSC-Johab-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSC-Johab-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSCms-UHC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSCms-UHC-HW-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSCms-UHC-HW-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSCms-UHC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSCpc-EUC-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\KSCpc-EUC-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\LICENSE
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\NWP-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\NWP-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\RKSJ-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\RKSJ-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\Roman.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UCS2-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UCS2-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UTF16-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UTF16-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UTF8-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniCNS-UTF8-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UCS2-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UCS2-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UTF16-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UTF16-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UTF8-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniGB-UTF8-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UCS2-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UCS2-HW-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UCS2-HW-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UCS2-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UTF16-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UTF16-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UTF8-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS-UTF8-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS2004-UTF16-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS2004-UTF16-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS2004-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS2004-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS2004-UTF8-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJIS2004-UTF8-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISPro-UCS2-HW-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISPro-UCS2-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISPro-UTF8-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISX0213-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISX0213-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISX02132004-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniJISX02132004-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UCS2-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UCS2-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UTF16-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UTF16-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UTF32-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UTF32-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UTF8-H.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\UniKS-UTF8-V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\V.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\cmaps\WP-Symbol.bcmap
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitDingbats.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitFixed.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitFixedBold.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitFixedBoldItalic.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitFixedItalic.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitSerif.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitSerifBold.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitSerifBoldItalic.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitSerifItalic.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\FoxitSymbol.pfb
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\LiberationSans-Bold.ttf
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\LiberationSans-BoldItalic.ttf
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\LiberationSans-Italic.ttf
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\LiberationSans-Regular.ttf
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\LICENSE_FOXIT
C:\tmp\MiniZoteroBuildProject\Assets\PdfJs\standard_fonts\LICENSE_LIBERATION
C:\tmp\MiniZoteroBuildProject\Assets\PdfViewer\index.html
C:\tmp\MiniZoteroBuildProject\Assets\PdfViewer\style.css
C:\tmp\MiniZoteroBuildProject\Assets\PdfViewer\viewer.js
C:\tmp\MiniZoteroBuildProject\MiniZotero.exe
C:\tmp\MiniZoteroBuildProject\MiniZotero.deps.json
C:\tmp\MiniZoteroBuildProject\MiniZotero.runtimeconfig.json
C:\tmp\MiniZoteroBuildProject\MiniZotero.dll
C:\tmp\MiniZoteroBuildProject\MiniZotero.pdb

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.csproj.Up2Date

``text

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.dll

_Skipped binary or large file. Size: 5384192 bytes._

## MiniZotero/obj/Debug/net8.0/MiniZotero.GeneratedMSBuildEditorConfig.editorconfig

``text
is_global = true
build_property.AvaloniaNameGeneratorIsEnabled = true
build_property.AvaloniaNameGeneratorBehavior = InitializeComponent
build_property.AvaloniaNameGeneratorDefaultFieldModifier = internal
build_property.AvaloniaNameGeneratorFilterByPath = *
build_property.AvaloniaNameGeneratorFilterByNamespace = *
build_property.AvaloniaNameGeneratorViewFileNamingStrategy = NamespaceAndClassName
build_property.AvaloniaNameGeneratorAttachDevTools = true
build_property.MvvmToolkitEnableINotifyPropertyChangingSupport = true
build_property._MvvmToolkitIsUsingWindowsRuntimePack = false
build_property.CsWinRTComponent = 
build_property.CsWinRTAotOptimizerEnabled = 
build_property.CsWinRTAotWarningLevel = 
build_property.TargetFramework = net8.0
build_property.TargetPlatformMinVersion = 
build_property.UsingMicrosoftNETSdkWeb = 
build_property.ProjectTypeGuids = 
build_property.InvariantGlobalization = 
build_property.PlatformNeutralAssembly = 
build_property.EnforceExtendedAnalyzerRules = 
build_property._SupportedPlatformList = Linux,macOS,Windows
build_property.RootNamespace = MiniZotero
build_property.ProjectDir = C:\Users\huyho\source\repos\MiniZotero\MiniZotero\
build_property.EnableComHosting = 
build_property.EnableGeneratedComInterfaceComImportInterop = 
build_property.EffectiveAnalysisLevelStyle = 8.0
build_property.EnableCodeStyleSeverity = 

[C:/Users/huyho/source/repos/MiniZotero/MiniZotero/App.axaml]
build_metadata.AdditionalFiles.SourceItemGroup = AvaloniaXaml

[C:/Users/huyho/source/repos/MiniZotero/MiniZotero/Views/MainWindow.axaml]
build_metadata.AdditionalFiles.SourceItemGroup = AvaloniaXaml

[C:/Users/huyho/source/repos/MiniZotero/MiniZotero/Views/NotePreviewPanelView.axaml]
build_metadata.AdditionalFiles.SourceItemGroup = AvaloniaXaml

[C:/Users/huyho/source/repos/MiniZotero/MiniZotero/Views/PdfViewerView.axaml]
build_metadata.AdditionalFiles.SourceItemGroup = AvaloniaXaml

[C:/Users/huyho/source/repos/MiniZotero/MiniZotero/Views/SidebarView.axaml]
build_metadata.AdditionalFiles.SourceItemGroup = AvaloniaXaml

[C:/Users/huyho/source/repos/MiniZotero/MiniZotero/Views/TabWorkspaceView.axaml]
build_metadata.AdditionalFiles.SourceItemGroup = AvaloniaXaml

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.genruntimeconfig.cache

``text
46252278de0ea98fdd3102c58e28613f0f2e9bfb6a7900df708c8cf4a72a43e7

````

## MiniZotero/obj/Debug/net8.0/MiniZotero.pdb

_Skipped binary or large file. Size: 71860 bytes._

## MiniZotero/obj/Debug/net8.0/MiniZotero.sourcelink.json

``json
{"documents":{"C:\\Users\\huyho\\source\\repos\\MiniZotero\\*":"https://raw.githubusercontent.com/huyho255/mini-zotero/97f9fd62092040ef16e5b48e2a5fc4ddfcb10e18/*"}}
````

## MiniZotero/obj/Debug/net8.0/ref/MiniZotero.dll

_Skipped binary or large file. Size: 33280 bytes._

## MiniZotero/obj/Debug/net8.0/refint/MiniZotero.dll

_Skipped binary or large file. Size: 33280 bytes._

## MiniZotero/obj/MiniZotero.csproj.nuget.dgspec.json

``json
{
  "format": 1,
  "restore": {
    "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj": {}
  },
  "projects": {
    "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj": {
      "version": "1.0.0",
      "restore": {
        "projectUniqueName": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj",
        "projectName": "MiniZotero",
        "projectPath": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj",
        "packagesPath": "C:\\Users\\huyho\\.nuget\\packages\\",
        "outputPath": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\obj\\",
        "projectStyle": "PackageReference",
        "configFilePaths": [
          "C:\\Users\\huyho\\AppData\\Roaming\\NuGet\\NuGet.Config",
          "C:\\Program Files (x86)\\NuGet\\Config\\Microsoft.VisualStudio.Offline.config"
        ],
        "originalTargetFrameworks": [
          "net8.0"
        ],
        "sources": {
          "C:\\Program Files (x86)\\Microsoft SDKs\\NuGetPackages\\": {},
          "https://api.nuget.org/v3/index.json": {}
        },
        "frameworks": {
          "net8.0": {
            "targetAlias": "net8.0",
            "projectReferences": {}
          }
        },
        "warningProperties": {
          "warnAsError": [
            "NU1605"
          ]
        },
        "restoreAuditProperties": {
          "enableAudit": "true",
          "auditLevel": "low",
          "auditMode": "direct"
        },
        "SdkAnalysisLevel": "9.0.300"
      },
      "frameworks": {
        "net8.0": {
          "targetAlias": "net8.0",
          "dependencies": {
            "Avalonia": {
              "target": "Package",
              "version": "[12.0.3, )"
            },
            "Avalonia.Controls.WebView": {
              "target": "Package",
              "version": "[12.0.1, )"
            },
            "Avalonia.Desktop": {
              "target": "Package",
              "version": "[12.0.3, )"
            },
            "Avalonia.Fonts.Inter": {
              "target": "Package",
              "version": "[12.0.3, )"
            },
            "Avalonia.Themes.Fluent": {
              "target": "Package",
              "version": "[12.0.3, )"
            },
            "CommunityToolkit.Mvvm": {
              "target": "Package",
              "version": "[8.4.1, )"
            }
          },
          "imports": [
            "net461",
            "net462",
            "net47",
            "net471",
            "net472",
            "net48",
            "net481"
          ],
          "assetTargetFallback": true,
          "warn": true,
          "frameworkReferences": {
            "Microsoft.NETCore.App": {
              "privateAssets": "all"
            }
          },
          "runtimeIdentifierGraphPath": "C:\\Program Files\\dotnet\\sdk\\9.0.305/PortableRuntimeIdentifierGraph.json"
        }
      }
    }
  }
}
````

## MiniZotero/obj/MiniZotero.csproj.nuget.g.props

``text
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup Condition=" '$(ExcludeRestorePackageImports)' != 'true' ">
    <RestoreSuccess Condition=" '$(RestoreSuccess)' == '' ">True</RestoreSuccess>
    <RestoreTool Condition=" '$(RestoreTool)' == '' ">NuGet</RestoreTool>
    <ProjectAssetsFile Condition=" '$(ProjectAssetsFile)' == '' ">$(MSBuildThisFileDirectory)project.assets.json</ProjectAssetsFile>
    <NuGetPackageRoot Condition=" '$(NuGetPackageRoot)' == '' ">$(UserProfile)\.nuget\packages\</NuGetPackageRoot>
    <NuGetPackageFolders Condition=" '$(NuGetPackageFolders)' == '' ">C:\Users\huyho\.nuget\packages\</NuGetPackageFolders>
    <NuGetProjectStyle Condition=" '$(NuGetProjectStyle)' == '' ">PackageReference</NuGetProjectStyle>
    <NuGetToolVersion Condition=" '$(NuGetToolVersion)' == '' ">6.14.0</NuGetToolVersion>
  </PropertyGroup>
  <ItemGroup Condition=" '$(ExcludeRestorePackageImports)' != 'true' ">
    <SourceRoot Include="C:\Users\huyho\.nuget\packages\" />
  </ItemGroup>
  <ImportGroup Condition=" '$(ExcludeRestorePackageImports)' != 'true' ">
    <Import Project="$(NuGetPackageRoot)skiasharp.nativeassets.webassembly\3.119.4-preview.1.1\buildTransitive\netstandard1.0\SkiaSharp.NativeAssets.WebAssembly.props" Condition="Exists('$(NuGetPackageRoot)skiasharp.nativeassets.webassembly\3.119.4-preview.1.1\buildTransitive\netstandard1.0\SkiaSharp.NativeAssets.WebAssembly.props')" />
    <Import Project="$(NuGetPackageRoot)harfbuzzsharp.nativeassets.webassembly\8.3.1.3\buildTransitive\netstandard1.0\HarfBuzzSharp.NativeAssets.WebAssembly.props" Condition="Exists('$(NuGetPackageRoot)harfbuzzsharp.nativeassets.webassembly\8.3.1.3\buildTransitive\netstandard1.0\HarfBuzzSharp.NativeAssets.WebAssembly.props')" />
    <Import Project="$(NuGetPackageRoot)avalonia\12.0.3\buildTransitive\Avalonia.props" Condition="Exists('$(NuGetPackageRoot)avalonia\12.0.3\buildTransitive\Avalonia.props')" />
    <Import Project="$(NuGetPackageRoot)avalonia.controls.webview\12.0.1\buildTransitive\Avalonia.Controls.WebView.props" Condition="Exists('$(NuGetPackageRoot)avalonia.controls.webview\12.0.1\buildTransitive\Avalonia.Controls.WebView.props')" />
  </ImportGroup>
  <PropertyGroup Condition=" '$(ExcludeRestorePackageImports)' != 'true' ">
    <PkgAvalonia_BuildServices Condition=" '$(PkgAvalonia_BuildServices)' == '' ">C:\Users\huyho\.nuget\packages\avalonia.buildservices\11.3.2</PkgAvalonia_BuildServices>
    <PkgAvalonia Condition=" '$(PkgAvalonia)' == '' ">C:\Users\huyho\.nuget\packages\avalonia\12.0.3</PkgAvalonia>
  </PropertyGroup>
</Project>
````

## MiniZotero/obj/MiniZotero.csproj.nuget.g.targets

``text
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<Project ToolsVersion="14.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <ImportGroup Condition=" '$(ExcludeRestorePackageImports)' != 'true' ">
    <Import Project="$(NuGetPackageRoot)skiasharp.nativeassets.webassembly\3.119.4-preview.1.1\buildTransitive\netstandard1.0\SkiaSharp.NativeAssets.WebAssembly.targets" Condition="Exists('$(NuGetPackageRoot)skiasharp.nativeassets.webassembly\3.119.4-preview.1.1\buildTransitive\netstandard1.0\SkiaSharp.NativeAssets.WebAssembly.targets')" />
    <Import Project="$(NuGetPackageRoot)harfbuzzsharp.nativeassets.webassembly\8.3.1.3\buildTransitive\netstandard1.0\HarfBuzzSharp.NativeAssets.WebAssembly.targets" Condition="Exists('$(NuGetPackageRoot)harfbuzzsharp.nativeassets.webassembly\8.3.1.3\buildTransitive\netstandard1.0\HarfBuzzSharp.NativeAssets.WebAssembly.targets')" />
    <Import Project="$(NuGetPackageRoot)communitytoolkit.mvvm\8.4.1\buildTransitive\CommunityToolkit.Mvvm.targets" Condition="Exists('$(NuGetPackageRoot)communitytoolkit.mvvm\8.4.1\buildTransitive\CommunityToolkit.Mvvm.targets')" />
    <Import Project="$(NuGetPackageRoot)avalonia.buildservices\11.3.2\buildTransitive\Avalonia.BuildServices.targets" Condition="Exists('$(NuGetPackageRoot)avalonia.buildservices\11.3.2\buildTransitive\Avalonia.BuildServices.targets')" />
    <Import Project="$(NuGetPackageRoot)avalonia\12.0.3\buildTransitive\Avalonia.targets" Condition="Exists('$(NuGetPackageRoot)avalonia\12.0.3\buildTransitive\Avalonia.targets')" />
    <Import Project="$(NuGetPackageRoot)avalonia.controls.webview\12.0.1\buildTransitive\Avalonia.Controls.WebView.targets" Condition="Exists('$(NuGetPackageRoot)avalonia.controls.webview\12.0.1\buildTransitive\Avalonia.Controls.WebView.targets')" />
  </ImportGroup>
</Project>
````

## MiniZotero/obj/project.assets.json

``json
{
  "version": 3,
  "targets": {
    "net8.0": {
      "Avalonia/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia.BuildServices": "11.3.2",
          "Avalonia.Remote.Protocol": "12.0.3",
          "MicroCom.Runtime": "0.11.4"
        },
        "compile": {
          "ref/net8.0/Avalonia.Base.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.Controls.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.DesignerSupport.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.Dialogs.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.Markup.Xaml.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.Markup.dll": {
            "related": ".Xaml.xml;.xml"
          },
          "ref/net8.0/Avalonia.Metal.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.MicroCom.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.OpenGL.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.Vulkan.dll": {
            "related": ".xml"
          },
          "ref/net8.0/Avalonia.dll": {
            "related": ".Base.xml;.Controls.xml;.DesignerSupport.xml;.Dialogs.xml;.Markup.Xaml.xml;.Markup.xml;.Metal.xml;.MicroCom.xml;.OpenGL.xml;.Vulkan.xml;.xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Base.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Controls.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.DesignerSupport.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Dialogs.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Markup.Xaml.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Markup.dll": {
            "related": ".Xaml.xml;.xml"
          },
          "lib/net8.0/Avalonia.Metal.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.MicroCom.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.OpenGL.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Vulkan.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.dll": {
            "related": ".Base.xml;.Controls.xml;.DesignerSupport.xml;.Dialogs.xml;.Markup.Xaml.xml;.Markup.xml;.Metal.xml;.MicroCom.xml;.OpenGL.xml;.Vulkan.xml;.xml"
          }
        },
        "build": {
          "buildTransitive/Avalonia.props": {},
          "buildTransitive/Avalonia.targets": {}
        }
      },
      "Avalonia.Angle.Windows.Natives/2.1.25547.20250602": {
        "type": "package",
        "runtimeTargets": {
          "runtimes/win-arm64/native/av_libglesv2.dll": {
            "assetType": "native",
            "rid": "win-arm64"
          },
          "runtimes/win-x64/native/av_libglesv2.dll": {
            "assetType": "native",
            "rid": "win-x64"
          },
          "runtimes/win-x86/native/av_libglesv2.dll": {
            "assetType": "native",
            "rid": "win-x86"
          }
        }
      },
      "Avalonia.BuildServices/11.3.2": {
        "type": "package",
        "build": {
          "buildTransitive/Avalonia.BuildServices.targets": {}
        }
      },
      "Avalonia.Controls.WebView/12.0.1": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.0"
        },
        "compile": {
          "lib/net8.0/Avalonia.Controls.WebView.dll": {}
        },
        "runtime": {
          "lib/net8.0/Avalonia.Controls.WebView.dll": {}
        },
        "build": {
          "buildTransitive/Avalonia.Controls.WebView.props": {},
          "buildTransitive/Avalonia.Controls.WebView.targets": {}
        }
      },
      "Avalonia.Desktop/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.HarfBuzz": "12.0.3",
          "Avalonia.Native": "12.0.3",
          "Avalonia.Skia": "12.0.3",
          "Avalonia.Win32": "12.0.3",
          "Avalonia.X11": "12.0.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.Desktop.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Desktop.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.Fonts.Inter/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.Fonts.Inter.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Fonts.Inter.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.FreeDesktop/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3",
          "Tmds.DBus.Protocol": "0.92.0"
        },
        "compile": {
          "lib/net8.0/Avalonia.FreeDesktop.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.FreeDesktop.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.FreeDesktop.AtSpi/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.FreeDesktop.AtSpi.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.FreeDesktop.AtSpi.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.HarfBuzz/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3",
          "HarfBuzzSharp": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.Linux": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.WebAssembly": "8.3.1.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.HarfBuzz.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.HarfBuzz.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.Native/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.Native.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Native.dll": {
            "related": ".xml"
          }
        },
        "runtimeTargets": {
          "runtimes/osx/native/libAvaloniaNative.dylib": {
            "assetType": "native",
            "rid": "osx"
          }
        }
      },
      "Avalonia.Remote.Protocol/12.0.3": {
        "type": "package",
        "compile": {
          "lib/net8.0/Avalonia.Remote.Protocol.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Remote.Protocol.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.Skia/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3",
          "HarfBuzzSharp": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.Linux": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.WebAssembly": "8.3.1.3",
          "SkiaSharp": "3.119.4-preview.1.1",
          "SkiaSharp.NativeAssets.Linux": "3.119.4-preview.1.1",
          "SkiaSharp.NativeAssets.WebAssembly": "3.119.4-preview.1.1"
        },
        "compile": {
          "lib/net8.0/Avalonia.Skia.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Skia.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.Themes.Fluent/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.Themes.Fluent.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Themes.Fluent.dll": {
            "related": ".xml"
          }
        }
      },
      "Avalonia.Win32/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.Angle.Windows.Natives": "2.1.25547.20250602"
        },
        "compile": {
          "lib/net8.0/Avalonia.Win32.Automation.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Win32.dll": {
            "related": ".Automation.xml;.xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.Win32.Automation.dll": {
            "related": ".xml"
          },
          "lib/net8.0/Avalonia.Win32.dll": {
            "related": ".Automation.xml;.xml"
          }
        }
      },
      "Avalonia.X11/12.0.3": {
        "type": "package",
        "dependencies": {
          "Avalonia": "12.0.3",
          "Avalonia.FreeDesktop": "12.0.3",
          "Avalonia.FreeDesktop.AtSpi": "12.0.3",
          "Avalonia.Skia": "12.0.3"
        },
        "compile": {
          "lib/net8.0/Avalonia.X11.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Avalonia.X11.dll": {
            "related": ".xml"
          }
        }
      },
      "CommunityToolkit.Mvvm/8.4.1": {
        "type": "package",
        "compile": {
          "lib/net8.0/CommunityToolkit.Mvvm.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/CommunityToolkit.Mvvm.dll": {
            "related": ".xml"
          }
        },
        "build": {
          "buildTransitive/CommunityToolkit.Mvvm.targets": {}
        }
      },
      "HarfBuzzSharp/8.3.1.3": {
        "type": "package",
        "dependencies": {
          "HarfBuzzSharp.NativeAssets.Win32": "8.3.1.3",
          "HarfBuzzSharp.NativeAssets.macOS": "8.3.1.3"
        },
        "compile": {
          "lib/net8.0/HarfBuzzSharp.dll": {
            "related": ".pdb"
          }
        },
        "runtime": {
          "lib/net8.0/HarfBuzzSharp.dll": {
            "related": ".pdb"
          }
        }
      },
      "HarfBuzzSharp.NativeAssets.Linux/8.3.1.3": {
        "type": "package",
        "compile": {
          "lib/net8.0/_._": {}
        },
        "runtime": {
          "lib/net8.0/_._": {}
        },
        "runtimeTargets": {
          "runtimes/linux-arm/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-arm"
          },
          "runtimes/linux-arm64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-arm64"
          },
          "runtimes/linux-loongarch64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-loongarch64"
          },
          "runtimes/linux-musl-arm/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-arm"
          },
          "runtimes/linux-musl-arm64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-arm64"
          },
          "runtimes/linux-musl-loongarch64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-loongarch64"
          },
          "runtimes/linux-musl-riscv64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-riscv64"
          },
          "runtimes/linux-musl-x64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-x64"
          },
          "runtimes/linux-riscv64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-riscv64"
          },
          "runtimes/linux-x64/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-x64"
          },
          "runtimes/linux-x86/native/libHarfBuzzSharp.so": {
            "assetType": "native",
            "rid": "linux-x86"
          }
        }
      },
      "HarfBuzzSharp.NativeAssets.macOS/8.3.1.3": {
        "type": "package",
        "compile": {
          "lib/net8.0/_._": {}
        },
        "runtime": {
          "lib/net8.0/_._": {}
        },
        "runtimeTargets": {
          "runtimes/osx/native/libHarfBuzzSharp.dylib": {
            "assetType": "native",
            "rid": "osx"
          }
        }
      },
      "HarfBuzzSharp.NativeAssets.WebAssembly/8.3.1.3": {
        "type": "package",
        "compile": {
          "lib/net8.0/_._": {}
        },
        "runtime": {
          "lib/net8.0/_._": {}
        },
        "build": {
          "buildTransitive/netstandard1.0/HarfBuzzSharp.NativeAssets.WebAssembly.props": {},
          "buildTransitive/netstandard1.0/HarfBuzzSharp.NativeAssets.WebAssembly.targets": {}
        }
      },
      "HarfBuzzSharp.NativeAssets.Win32/8.3.1.3": {
        "type": "package",
        "compile": {
          "lib/net8.0/_._": {}
        },
        "runtime": {
          "lib/net8.0/_._": {}
        },
        "runtimeTargets": {
          "runtimes/win-arm64/native/libHarfBuzzSharp.dll": {
            "assetType": "native",
            "rid": "win-arm64"
          },
          "runtimes/win-arm64/native/libHarfBuzzSharp.pdb": {
            "assetType": "native",
            "rid": "win-arm64"
          },
          "runtimes/win-x64/native/libHarfBuzzSharp.dll": {
            "assetType": "native",
            "rid": "win-x64"
          },
          "runtimes/win-x64/native/libHarfBuzzSharp.pdb": {
            "assetType": "native",
            "rid": "win-x64"
          },
          "runtimes/win-x86/native/libHarfBuzzSharp.dll": {
            "assetType": "native",
            "rid": "win-x86"
          },
          "runtimes/win-x86/native/libHarfBuzzSharp.pdb": {
            "assetType": "native",
            "rid": "win-x86"
          }
        }
      },
      "MicroCom.Runtime/0.11.4": {
        "type": "package",
        "compile": {
          "lib/net5.0/MicroCom.Runtime.dll": {}
        },
        "runtime": {
          "lib/net5.0/MicroCom.Runtime.dll": {}
        }
      },
      "SkiaSharp/3.119.4-preview.1.1": {
        "type": "package",
        "dependencies": {
          "SkiaSharp.NativeAssets.Win32": "3.119.4-preview.1.1",
          "SkiaSharp.NativeAssets.macOS": "3.119.4-preview.1.1"
        },
        "compile": {
          "ref/net6.0/SkiaSharp.dll": {}
        },
        "runtime": {
          "lib/net6.0/SkiaSharp.dll": {
            "related": ".pdb"
          }
        }
      },
      "SkiaSharp.NativeAssets.Linux/3.119.4-preview.1.1": {
        "type": "package",
        "compile": {
          "lib/net6.0/_._": {}
        },
        "runtime": {
          "lib/net6.0/_._": {}
        },
        "runtimeTargets": {
          "runtimes/linux-arm/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-arm"
          },
          "runtimes/linux-arm64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-arm64"
          },
          "runtimes/linux-bionic-arm64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-bionic-arm64"
          },
          "runtimes/linux-bionic-x64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-bionic-x64"
          },
          "runtimes/linux-loongarch64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-loongarch64"
          },
          "runtimes/linux-musl-arm/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-arm"
          },
          "runtimes/linux-musl-arm64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-arm64"
          },
          "runtimes/linux-musl-loongarch64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-loongarch64"
          },
          "runtimes/linux-musl-riscv64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-riscv64"
          },
          "runtimes/linux-musl-x64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-musl-x64"
          },
          "runtimes/linux-riscv64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-riscv64"
          },
          "runtimes/linux-x64/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-x64"
          },
          "runtimes/linux-x86/native/libSkiaSharp.so": {
            "assetType": "native",
            "rid": "linux-x86"
          }
        }
      },
      "SkiaSharp.NativeAssets.macOS/3.119.4-preview.1.1": {
        "type": "package",
        "compile": {
          "lib/net6.0/_._": {}
        },
        "runtime": {
          "lib/net6.0/_._": {}
        },
        "runtimeTargets": {
          "runtimes/osx/native/libSkiaSharp.dylib": {
            "assetType": "native",
            "rid": "osx"
          }
        }
      },
      "SkiaSharp.NativeAssets.WebAssembly/3.119.4-preview.1.1": {
        "type": "package",
        "compile": {
          "lib/net6.0/_._": {}
        },
        "runtime": {
          "lib/net6.0/_._": {}
        },
        "build": {
          "buildTransitive/netstandard1.0/SkiaSharp.NativeAssets.WebAssembly.props": {},
          "buildTransitive/netstandard1.0/SkiaSharp.NativeAssets.WebAssembly.targets": {}
        }
      },
      "SkiaSharp.NativeAssets.Win32/3.119.4-preview.1.1": {
        "type": "package",
        "compile": {
          "lib/net6.0/_._": {}
        },
        "runtime": {
          "lib/net6.0/_._": {}
        },
        "runtimeTargets": {
          "runtimes/win-arm64/native/libSkiaSharp.dll": {
            "assetType": "native",
            "rid": "win-arm64"
          },
          "runtimes/win-arm64/native/libSkiaSharp.pdb": {
            "assetType": "native",
            "rid": "win-arm64"
          },
          "runtimes/win-x64/native/libSkiaSharp.dll": {
            "assetType": "native",
            "rid": "win-x64"
          },
          "runtimes/win-x64/native/libSkiaSharp.pdb": {
            "assetType": "native",
            "rid": "win-x64"
          },
          "runtimes/win-x86/native/libSkiaSharp.dll": {
            "assetType": "native",
            "rid": "win-x86"
          },
          "runtimes/win-x86/native/libSkiaSharp.pdb": {
            "assetType": "native",
            "rid": "win-x86"
          }
        }
      },
      "System.IO.Pipelines/8.0.0": {
        "type": "package",
        "compile": {
          "lib/net8.0/System.IO.Pipelines.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/System.IO.Pipelines.dll": {
            "related": ".xml"
          }
        },
        "build": {
          "buildTransitive/net6.0/_._": {}
        }
      },
      "Tmds.DBus.Protocol/0.92.0": {
        "type": "package",
        "dependencies": {
          "System.IO.Pipelines": "8.0.0"
        },
        "compile": {
          "lib/net8.0/Tmds.DBus.Protocol.dll": {
            "related": ".xml"
          }
        },
        "runtime": {
          "lib/net8.0/Tmds.DBus.Protocol.dll": {
            "related": ".xml"
          }
        }
      }
    }
  },
  "libraries": {
    "Avalonia/12.0.3": {
      "sha512": "OVAzdZB5T/QIOEpw/WmQ0ZJM13BMmLO7RqR5z+lZtBMuStK63W68SV/Q+PNn/GdFEC3Ab8eQhH2FMb8FhNLK+w==",
      "type": "package",
      "path": "avalonia/12.0.3",
      "hasTools": true,
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "analyzers/dotnet/cs/Avalonia.Analyzers.CSharp.dll",
        "analyzers/dotnet/cs/Avalonia.Analyzers.CodeFixes.CSharp.dll",
        "analyzers/dotnet/cs/Avalonia.Analyzers.VisualBasic.dll",
        "analyzers/dotnet/cs/Avalonia.Generators.dll",
        "avalonia.12.0.3.nupkg.sha512",
        "avalonia.nuspec",
        "build/Avalonia.Generators.props",
        "build/Avalonia.props",
        "build/Avalonia.targets",
        "build/AvaloniaBuildTasks.props",
        "build/AvaloniaBuildTasks.targets",
        "build/AvaloniaItemSchema.xaml",
        "build/AvaloniaPrivateApis.targets",
        "build/AvaloniaRules.Project.xml",
        "build/AvaloniaSingleProject.targets",
        "build/AvaloniaVersion.props",
        "buildTransitive/Avalonia.Generators.props",
        "buildTransitive/Avalonia.props",
        "buildTransitive/Avalonia.targets",
        "buildTransitive/AvaloniaBuildTasks.props",
        "buildTransitive/AvaloniaBuildTasks.targets",
        "buildTransitive/AvaloniaItemSchema.xaml",
        "buildTransitive/AvaloniaPrivateApis.targets",
        "buildTransitive/AvaloniaRules.Project.xml",
        "buildTransitive/AvaloniaSingleProject.targets",
        "lib/net10.0/Avalonia.Base.dll",
        "lib/net10.0/Avalonia.Base.xml",
        "lib/net10.0/Avalonia.Controls.dll",
        "lib/net10.0/Avalonia.Controls.xml",
        "lib/net10.0/Avalonia.DesignerSupport.dll",
        "lib/net10.0/Avalonia.DesignerSupport.xml",
        "lib/net10.0/Avalonia.Dialogs.dll",
        "lib/net10.0/Avalonia.Dialogs.xml",
        "lib/net10.0/Avalonia.Markup.Xaml.dll",
        "lib/net10.0/Avalonia.Markup.Xaml.xml",
        "lib/net10.0/Avalonia.Markup.dll",
        "lib/net10.0/Avalonia.Markup.xml",
        "lib/net10.0/Avalonia.Metal.dll",
        "lib/net10.0/Avalonia.Metal.xml",
        "lib/net10.0/Avalonia.MicroCom.dll",
        "lib/net10.0/Avalonia.MicroCom.xml",
        "lib/net10.0/Avalonia.OpenGL.dll",
        "lib/net10.0/Avalonia.OpenGL.xml",
        "lib/net10.0/Avalonia.Vulkan.dll",
        "lib/net10.0/Avalonia.Vulkan.xml",
        "lib/net10.0/Avalonia.dll",
        "lib/net10.0/Avalonia.xml",
        "lib/net8.0/Avalonia.Base.dll",
        "lib/net8.0/Avalonia.Base.xml",
        "lib/net8.0/Avalonia.Controls.dll",
        "lib/net8.0/Avalonia.Controls.xml",
        "lib/net8.0/Avalonia.DesignerSupport.dll",
        "lib/net8.0/Avalonia.DesignerSupport.xml",
        "lib/net8.0/Avalonia.Dialogs.dll",
        "lib/net8.0/Avalonia.Dialogs.xml",
        "lib/net8.0/Avalonia.Markup.Xaml.dll",
        "lib/net8.0/Avalonia.Markup.Xaml.xml",
        "lib/net8.0/Avalonia.Markup.dll",
        "lib/net8.0/Avalonia.Markup.xml",
        "lib/net8.0/Avalonia.Metal.dll",
        "lib/net8.0/Avalonia.Metal.xml",
        "lib/net8.0/Avalonia.MicroCom.dll",
        "lib/net8.0/Avalonia.MicroCom.xml",
        "lib/net8.0/Avalonia.OpenGL.dll",
        "lib/net8.0/Avalonia.OpenGL.xml",
        "lib/net8.0/Avalonia.Vulkan.dll",
        "lib/net8.0/Avalonia.Vulkan.xml",
        "lib/net8.0/Avalonia.dll",
        "lib/net8.0/Avalonia.xml",
        "ref/net10.0/Avalonia.Base.dll",
        "ref/net10.0/Avalonia.Base.xml",
        "ref/net10.0/Avalonia.Controls.dll",
        "ref/net10.0/Avalonia.Controls.xml",
        "ref/net10.0/Avalonia.DesignerSupport.dll",
        "ref/net10.0/Avalonia.DesignerSupport.xml",
        "ref/net10.0/Avalonia.Dialogs.dll",
        "ref/net10.0/Avalonia.Dialogs.xml",
        "ref/net10.0/Avalonia.Markup.Xaml.dll",
        "ref/net10.0/Avalonia.Markup.Xaml.xml",
        "ref/net10.0/Avalonia.Markup.dll",
        "ref/net10.0/Avalonia.Markup.xml",
        "ref/net10.0/Avalonia.Metal.dll",
        "ref/net10.0/Avalonia.Metal.xml",
        "ref/net10.0/Avalonia.MicroCom.dll",
        "ref/net10.0/Avalonia.MicroCom.xml",
        "ref/net10.0/Avalonia.OpenGL.dll",
        "ref/net10.0/Avalonia.OpenGL.xml",
        "ref/net10.0/Avalonia.Vulkan.dll",
        "ref/net10.0/Avalonia.Vulkan.xml",
        "ref/net10.0/Avalonia.dll",
        "ref/net10.0/Avalonia.xml",
        "ref/net8.0/Avalonia.Base.dll",
        "ref/net8.0/Avalonia.Base.xml",
        "ref/net8.0/Avalonia.Controls.dll",
        "ref/net8.0/Avalonia.Controls.xml",
        "ref/net8.0/Avalonia.DesignerSupport.dll",
        "ref/net8.0/Avalonia.DesignerSupport.xml",
        "ref/net8.0/Avalonia.Dialogs.dll",
        "ref/net8.0/Avalonia.Dialogs.xml",
        "ref/net8.0/Avalonia.Markup.Xaml.dll",
        "ref/net8.0/Avalonia.Markup.Xaml.xml",
        "ref/net8.0/Avalonia.Markup.dll",
        "ref/net8.0/Avalonia.Markup.xml",
        "ref/net8.0/Avalonia.Metal.dll",
        "ref/net8.0/Avalonia.Metal.xml",
        "ref/net8.0/Avalonia.MicroCom.dll",
        "ref/net8.0/Avalonia.MicroCom.xml",
        "ref/net8.0/Avalonia.OpenGL.dll",
        "ref/net8.0/Avalonia.OpenGL.xml",
        "ref/net8.0/Avalonia.Vulkan.dll",
        "ref/net8.0/Avalonia.Vulkan.xml",
        "ref/net8.0/Avalonia.dll",
        "ref/net8.0/Avalonia.xml",
        "tools/net10.0/designer/Avalonia.Designer.HostApp.dll",
        "tools/net8.0/designer/Avalonia.Designer.HostApp.dll",
        "tools/netstandard2.0/Avalonia.Build.Tasks.dll"
      ]
    },
    "Avalonia.Angle.Windows.Natives/2.1.25547.20250602": {
      "sha512": "ZL0VLc4s9rvNNFt19Pxm5UNAkmKNylugAwJPX9ulXZ6JWs/l6XZihPWWTyezaoNOVyEPU8YbURtW7XMAtqXH5A==",
      "type": "package",
      "path": "avalonia.angle.windows.natives/2.1.25547.20250602",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "LICENSE",
        "avalonia.angle.windows.natives.2.1.25547.20250602.nupkg.sha512",
        "avalonia.angle.windows.natives.nuspec",
        "runtimes/win-arm64/native/av_libglesv2.dll",
        "runtimes/win-x64/native/av_libglesv2.dll",
        "runtimes/win-x86/native/av_libglesv2.dll"
      ]
    },
    "Avalonia.BuildServices/11.3.2": {
      "sha512": "qHDToxto1e3hci5YqbG9n0Ty8mlp3zBUN5wT66wKqaDVzXyQ0do3EnRILd4Ke9jpvsktaPpgE0YjEk7hornryQ==",
      "type": "package",
      "path": "avalonia.buildservices/11.3.2",
      "hasTools": true,
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "README.md",
        "avalonia.buildservices.11.3.2.nupkg.sha512",
        "avalonia.buildservices.nuspec",
        "build/Avalonia.BuildServices.targets",
        "buildTransitive/Avalonia.BuildServices.targets",
        "tools/netstandard2.0/Avalonia.BuildServices.Collector.dll",
        "tools/netstandard2.0/Avalonia.BuildServices.dll",
        "tools/netstandard2.0/runtimeconfig.json"
      ]
    },
    "Avalonia.Controls.WebView/12.0.1": {
      "sha512": "GrCIpIIBL7ueFDsNu3lyYc1mgO3QGGl1c1MCK8YAgjaNZwF9PV5PF2UB3lm1uuqj/MWOKNhemLwcSDLyYv0JjQ==",
      "type": "package",
      "path": "avalonia.controls.webview/12.0.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "README.md",
        "avalonia.controls.webview.12.0.1.nupkg.sha512",
        "avalonia.controls.webview.nuspec",
        "build/Avalonia.Controls.WebView.props",
        "build/Avalonia.Controls.WebView.targets",
        "build/Microsoft.AspNetCore.StaticWebAssets.props",
        "buildTransitive/Avalonia.Controls.WebView.props",
        "buildTransitive/Avalonia.Controls.WebView.targets",
        "icon.png",
        "lib/net10.0-android36.0/Avalonia.Controls.WebView.dll",
        "lib/net10.0-android36.0/Avalonia.Controls.WebView.xml",
        "lib/net10.0-browser1.0/Avalonia.Controls.WebView.dll",
        "lib/net10.0/Avalonia.Controls.WebView.dll",
        "lib/net8.0/Avalonia.Controls.WebView.dll",
        "staticwebassets/av-webview.mjs"
      ]
    },
    "Avalonia.Desktop/12.0.3": {
      "sha512": "1WT6o5+HFQivTSBqqeyKWUQC2SbesgtlI6+ZT8JN+Rg9YarwWOw3DuPdHIYb2jkLzU+wjSkmBXRi7Nox7hfBOw==",
      "type": "package",
      "path": "avalonia.desktop/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.desktop.12.0.3.nupkg.sha512",
        "avalonia.desktop.nuspec",
        "lib/net10.0/Avalonia.Desktop.dll",
        "lib/net10.0/Avalonia.Desktop.xml",
        "lib/net8.0/Avalonia.Desktop.dll",
        "lib/net8.0/Avalonia.Desktop.xml"
      ]
    },
    "Avalonia.Fonts.Inter/12.0.3": {
      "sha512": "UWB0YZ15H0RKkkNgywtsO0aee3fcd6C0KQlG72QuDjoc7UIiwAgIrwu/LXkxCmXJcoh/xK/EWeclkwXEr7E50Q==",
      "type": "package",
      "path": "avalonia.fonts.inter/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.fonts.inter.12.0.3.nupkg.sha512",
        "avalonia.fonts.inter.nuspec",
        "lib/net10.0/Avalonia.Fonts.Inter.dll",
        "lib/net10.0/Avalonia.Fonts.Inter.xml",
        "lib/net8.0/Avalonia.Fonts.Inter.dll",
        "lib/net8.0/Avalonia.Fonts.Inter.xml"
      ]
    },
    "Avalonia.FreeDesktop/12.0.3": {
      "sha512": "t6qSD9slmHDlkBScuOecf5LZHGEhl57d8DQ0raXWXgm3mXkSZc2DTfkGBJajovrQdeuaISlu6sDHzYAs8Zv/iQ==",
      "type": "package",
      "path": "avalonia.freedesktop/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.freedesktop.12.0.3.nupkg.sha512",
        "avalonia.freedesktop.nuspec",
        "lib/net10.0/Avalonia.FreeDesktop.dll",
        "lib/net10.0/Avalonia.FreeDesktop.xml",
        "lib/net8.0/Avalonia.FreeDesktop.dll",
        "lib/net8.0/Avalonia.FreeDesktop.xml"
      ]
    },
    "Avalonia.FreeDesktop.AtSpi/12.0.3": {
      "sha512": "+i58/6jM/YrjfPA3vXfHbEeLNPC2BY1lXGZ4HtZU4IHZ1XkP6xGBGEqwABuruAlSpLoyrE9LVMZ0Uqg3pYOtiQ==",
      "type": "package",
      "path": "avalonia.freedesktop.atspi/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.freedesktop.atspi.12.0.3.nupkg.sha512",
        "avalonia.freedesktop.atspi.nuspec",
        "lib/net10.0/Avalonia.FreeDesktop.AtSpi.dll",
        "lib/net10.0/Avalonia.FreeDesktop.AtSpi.xml",
        "lib/net8.0/Avalonia.FreeDesktop.AtSpi.dll",
        "lib/net8.0/Avalonia.FreeDesktop.AtSpi.xml"
      ]
    },
    "Avalonia.HarfBuzz/12.0.3": {
      "sha512": "6R8pHRC9iDrAgT7AD/A3mE6hAPYXf66Ql5kWV046msSWF9ntYwuhNmJwlWeFwUVhb7nXThyTOIfUd3WV0GFXXA==",
      "type": "package",
      "path": "avalonia.harfbuzz/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.harfbuzz.12.0.3.nupkg.sha512",
        "avalonia.harfbuzz.nuspec",
        "lib/net10.0/Avalonia.HarfBuzz.dll",
        "lib/net10.0/Avalonia.HarfBuzz.xml",
        "lib/net8.0/Avalonia.HarfBuzz.dll",
        "lib/net8.0/Avalonia.HarfBuzz.xml"
      ]
    },
    "Avalonia.Native/12.0.3": {
      "sha512": "o+36bdY62STT9SjoEIlp/lSHVrQH8uC15gMUA4JMszz4Q4r5rgVMVTsorsIAurdawJ1LaBKIzvbDHyyiRjXROg==",
      "type": "package",
      "path": "avalonia.native/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.native.12.0.3.nupkg.sha512",
        "avalonia.native.nuspec",
        "lib/net10.0/Avalonia.Native.dll",
        "lib/net10.0/Avalonia.Native.xml",
        "lib/net8.0/Avalonia.Native.dll",
        "lib/net8.0/Avalonia.Native.xml",
        "runtimes/osx/native/libAvaloniaNative.dylib"
      ]
    },
    "Avalonia.Remote.Protocol/12.0.3": {
      "sha512": "NHvbiGC461oB3DXt8qgLNN+QfcYARcSxY7diyic9R7u6jQA4bc+ZbjEQKX8y8WyF1vOssedRmuOeTvRXlXbF9Q==",
      "type": "package",
      "path": "avalonia.remote.protocol/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.remote.protocol.12.0.3.nupkg.sha512",
        "avalonia.remote.protocol.nuspec",
        "lib/net10.0/Avalonia.Remote.Protocol.dll",
        "lib/net10.0/Avalonia.Remote.Protocol.xml",
        "lib/net8.0/Avalonia.Remote.Protocol.dll",
        "lib/net8.0/Avalonia.Remote.Protocol.xml",
        "lib/netstandard2.0/Avalonia.Remote.Protocol.dll",
        "lib/netstandard2.0/Avalonia.Remote.Protocol.xml"
      ]
    },
    "Avalonia.Skia/12.0.3": {
      "sha512": "Q0PYiN/B5dZumh89RcDOgbsceh7aUvTGVCKjiq+kcBmVZcvcygHpSRsDJKKUfFHBQLJLtQp7ErLRQUkN4LuIRA==",
      "type": "package",
      "path": "avalonia.skia/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.skia.12.0.3.nupkg.sha512",
        "avalonia.skia.nuspec",
        "lib/net10.0/Avalonia.Skia.dll",
        "lib/net10.0/Avalonia.Skia.xml",
        "lib/net8.0/Avalonia.Skia.dll",
        "lib/net8.0/Avalonia.Skia.xml"
      ]
    },
    "Avalonia.Themes.Fluent/12.0.3": {
      "sha512": "Acj+gmRm52U8sQIVHk5sCCU65RWjYcurDtxo8zyZSYmM4Vl1z2N9ZLnbK9+wp3N56Z0z/1ddsKYXRq3XfGSP3Q==",
      "type": "package",
      "path": "avalonia.themes.fluent/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.themes.fluent.12.0.3.nupkg.sha512",
        "avalonia.themes.fluent.nuspec",
        "lib/net10.0/Avalonia.Themes.Fluent.dll",
        "lib/net10.0/Avalonia.Themes.Fluent.xml",
        "lib/net8.0/Avalonia.Themes.Fluent.dll",
        "lib/net8.0/Avalonia.Themes.Fluent.xml"
      ]
    },
    "Avalonia.Win32/12.0.3": {
      "sha512": "shPBe7puXXjEWr9gq4DKZZBpfv2tGxdghK1nsRnVC7J3tx3Hm2/+Ik7vYoIYSdUv7MkAZZ4ham9Inqn8CcODBw==",
      "type": "package",
      "path": "avalonia.win32/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.win32.12.0.3.nupkg.sha512",
        "avalonia.win32.nuspec",
        "lib/net10.0/Avalonia.Win32.Automation.dll",
        "lib/net10.0/Avalonia.Win32.Automation.xml",
        "lib/net10.0/Avalonia.Win32.dll",
        "lib/net10.0/Avalonia.Win32.xml",
        "lib/net8.0/Avalonia.Win32.Automation.dll",
        "lib/net8.0/Avalonia.Win32.Automation.xml",
        "lib/net8.0/Avalonia.Win32.dll",
        "lib/net8.0/Avalonia.Win32.xml"
      ]
    },
    "Avalonia.X11/12.0.3": {
      "sha512": "rQ0gbEcKcWXN2Pc0PS5gtLUEsi/yW1JvEbxGWi9D6ip/hdmczLtEG1n3Irtn7MJFjLJq5N6cLM2Prh4Euxwg9Q==",
      "type": "package",
      "path": "avalonia.x11/12.0.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "avalonia.x11.12.0.3.nupkg.sha512",
        "avalonia.x11.nuspec",
        "lib/net10.0/Avalonia.X11.dll",
        "lib/net10.0/Avalonia.X11.xml",
        "lib/net8.0/Avalonia.X11.dll",
        "lib/net8.0/Avalonia.X11.xml"
      ]
    },
    "CommunityToolkit.Mvvm/8.4.1": {
      "sha512": "BTRteP8SvFyd/4KAreIFJBcxD2O9trLxLDD/p8YkSDDrfFOzy2U8cHyz6r+5Eh4kDhJdzAVglei6a+Bh4jCpUA==",
      "type": "package",
      "path": "communitytoolkit.mvvm/8.4.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "License.md",
        "ThirdPartyNotices.txt",
        "analyzers/dotnet/roslyn4.0/cs/CommunityToolkit.Mvvm.CodeFixers.dll",
        "analyzers/dotnet/roslyn4.0/cs/CommunityToolkit.Mvvm.SourceGenerators.dll",
        "analyzers/dotnet/roslyn4.12/cs/CommunityToolkit.Mvvm.CodeFixers.dll",
        "analyzers/dotnet/roslyn4.12/cs/CommunityToolkit.Mvvm.SourceGenerators.dll",
        "analyzers/dotnet/roslyn4.3/cs/CommunityToolkit.Mvvm.CodeFixers.dll",
        "analyzers/dotnet/roslyn4.3/cs/CommunityToolkit.Mvvm.SourceGenerators.dll",
        "analyzers/dotnet/roslyn5.0/cs/CommunityToolkit.Mvvm.CodeFixers.dll",
        "analyzers/dotnet/roslyn5.0/cs/CommunityToolkit.Mvvm.SourceGenerators.dll",
        "build/CommunityToolkit.Mvvm.FeatureSwitches.targets",
        "build/CommunityToolkit.Mvvm.SourceGenerators.targets",
        "build/CommunityToolkit.Mvvm.Windows.targets",
        "build/CommunityToolkit.Mvvm.WindowsSdk.targets",
        "build/CommunityToolkit.Mvvm.targets",
        "buildTransitive/CommunityToolkit.Mvvm.FeatureSwitches.targets",
        "buildTransitive/CommunityToolkit.Mvvm.SourceGenerators.targets",
        "buildTransitive/CommunityToolkit.Mvvm.Windows.targets",
        "buildTransitive/CommunityToolkit.Mvvm.WindowsSdk.targets",
        "buildTransitive/CommunityToolkit.Mvvm.targets",
        "communitytoolkit.mvvm.8.4.1.nupkg.sha512",
        "communitytoolkit.mvvm.nuspec",
        "lib/net8.0-windows10.0.17763/CommunityToolkit.Mvvm.dll",
        "lib/net8.0-windows10.0.17763/CommunityToolkit.Mvvm.xml",
        "lib/net8.0/CommunityToolkit.Mvvm.dll",
        "lib/net8.0/CommunityToolkit.Mvvm.xml",
        "lib/netstandard2.0/CommunityToolkit.Mvvm.dll",
        "lib/netstandard2.0/CommunityToolkit.Mvvm.xml",
        "lib/netstandard2.1/CommunityToolkit.Mvvm.dll",
        "lib/netstandard2.1/CommunityToolkit.Mvvm.xml"
      ]
    },
    "HarfBuzzSharp/8.3.1.3": {
      "sha512": "NGZ2+ZVNPM+NdHB/asW0/ykWngyHWwcqjrbN2nDeH1B/aptPGlCUl8wkQ2cSJxw5fdWgdmIPmNuTPWpLwNVXWg==",
      "type": "package",
      "path": "harfbuzzsharp/8.3.1.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "harfbuzzsharp.8.3.1.3.nupkg.sha512",
        "harfbuzzsharp.nuspec",
        "icon.png",
        "lib/net462/HarfBuzzSharp.dll",
        "lib/net462/HarfBuzzSharp.pdb",
        "lib/net6.0/HarfBuzzSharp.dll",
        "lib/net6.0/HarfBuzzSharp.pdb",
        "lib/net8.0-android34.0/HarfBuzzSharp.dll",
        "lib/net8.0-android34.0/HarfBuzzSharp.pdb",
        "lib/net8.0-android34.0/HarfBuzzSharp.xml",
        "lib/net8.0-ios17.0/HarfBuzzSharp.dll",
        "lib/net8.0-ios17.0/HarfBuzzSharp.pdb",
        "lib/net8.0-maccatalyst17.0/HarfBuzzSharp.dll",
        "lib/net8.0-maccatalyst17.0/HarfBuzzSharp.pdb",
        "lib/net8.0-macos14.0/HarfBuzzSharp.dll",
        "lib/net8.0-macos14.0/HarfBuzzSharp.pdb",
        "lib/net8.0-tizen7.0/HarfBuzzSharp.dll",
        "lib/net8.0-tizen7.0/HarfBuzzSharp.pdb",
        "lib/net8.0-tvos17.0/HarfBuzzSharp.dll",
        "lib/net8.0-tvos17.0/HarfBuzzSharp.pdb",
        "lib/net8.0-windows10.0.19041/HarfBuzzSharp.dll",
        "lib/net8.0-windows10.0.19041/HarfBuzzSharp.pdb",
        "lib/net8.0/HarfBuzzSharp.dll",
        "lib/net8.0/HarfBuzzSharp.pdb",
        "lib/netstandard2.0/HarfBuzzSharp.dll",
        "lib/netstandard2.0/HarfBuzzSharp.pdb",
        "lib/netstandard2.1/HarfBuzzSharp.dll",
        "lib/netstandard2.1/HarfBuzzSharp.pdb"
      ]
    },
    "HarfBuzzSharp.NativeAssets.Linux/8.3.1.3": {
      "sha512": "RI6A1LgmooU30+4QIyFt5rmBCzP0VzTR+587IJSGvYIsHHWlahFufihYxtraLfsIhW7I8dn6+xX+DZGygOPKWQ==",
      "type": "package",
      "path": "harfbuzzsharp.nativeassets.linux/8.3.1.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "buildTransitive/net462/HarfBuzzSharp.NativeAssets.Linux.targets",
        "harfbuzzsharp.nativeassets.linux.8.3.1.3.nupkg.sha512",
        "harfbuzzsharp.nativeassets.linux.nuspec",
        "icon.png",
        "lib/net462/_._",
        "lib/net6.0/_._",
        "lib/net8.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "runtimes/linux-arm/native/libHarfBuzzSharp.so",
        "runtimes/linux-arm64/native/libHarfBuzzSharp.so",
        "runtimes/linux-loongarch64/native/libHarfBuzzSharp.so",
        "runtimes/linux-musl-arm/native/libHarfBuzzSharp.so",
        "runtimes/linux-musl-arm64/native/libHarfBuzzSharp.so",
        "runtimes/linux-musl-loongarch64/native/libHarfBuzzSharp.so",
        "runtimes/linux-musl-riscv64/native/libHarfBuzzSharp.so",
        "runtimes/linux-musl-x64/native/libHarfBuzzSharp.so",
        "runtimes/linux-riscv64/native/libHarfBuzzSharp.so",
        "runtimes/linux-x64/native/libHarfBuzzSharp.so",
        "runtimes/linux-x86/native/libHarfBuzzSharp.so"
      ]
    },
    "HarfBuzzSharp.NativeAssets.macOS/8.3.1.3": {
      "sha512": "KPTq0xnslkI6nAo0jh3ptcQPJvZZr7MWYXa2jUe4SnHc9q+JlHElmNXp0sfFoiTgoCX7WOYpYsurypuH9Gehxw==",
      "type": "package",
      "path": "harfbuzzsharp.nativeassets.macos/8.3.1.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "buildTransitive/net462/HarfBuzzSharp.NativeAssets.macOS.targets",
        "buildTransitive/net8.0-macos14.0/HarfBuzzSharp.NativeAssets.macOS.targets",
        "harfbuzzsharp.nativeassets.macos.8.3.1.3.nupkg.sha512",
        "harfbuzzsharp.nativeassets.macos.nuspec",
        "icon.png",
        "lib/net462/_._",
        "lib/net6.0/_._",
        "lib/net8.0-macos14.0/_._",
        "lib/net8.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "runtimes/osx/native/libHarfBuzzSharp.dylib"
      ]
    },
    "HarfBuzzSharp.NativeAssets.WebAssembly/8.3.1.3": {
      "sha512": "w2QfdNm9Uz/sUa0B5D+OnVQhyq3G/fBq6ibQMdWBlQqqwh0g0/5j3RFvYqZAmRZ5+RzvjVe8o8SFFnWYUSkuxA==",
      "type": "package",
      "path": "harfbuzzsharp.nativeassets.webassembly/8.3.1.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "buildTransitive/netstandard1.0/HarfBuzzSharp.NativeAssets.WebAssembly.props",
        "buildTransitive/netstandard1.0/HarfBuzzSharp.NativeAssets.WebAssembly.targets",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/2.0.23/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/2.0.6/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.12/mt,simd/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.12/mt/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.12/st,simd/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.12/st/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.34/mt,simd/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.34/mt/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.34/st,simd/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.34/st/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.56/mt,simd/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.56/mt/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.56/st,simd/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.56/st/libHarfBuzzSharp.a",
        "buildTransitive/netstandard1.0/libHarfBuzzSharp.a/3.1.7/libHarfBuzzSharp.a",
        "harfbuzzsharp.nativeassets.webassembly.8.3.1.3.nupkg.sha512",
        "harfbuzzsharp.nativeassets.webassembly.nuspec",
        "icon.png",
        "lib/net462/_._",
        "lib/net6.0/_._",
        "lib/net8.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._"
      ]
    },
    "HarfBuzzSharp.NativeAssets.Win32/8.3.1.3": {
      "sha512": "bx8CE8Js+XGX8PUxAHCBDEORt5aaBYtMN4Hr9QFs57Xithh6yjUyYqksizH6eRDhJkwsGI+SXWmPmMm8lZC9Pw==",
      "type": "package",
      "path": "harfbuzzsharp.nativeassets.win32/8.3.1.3",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "buildTransitive/net462/HarfBuzzSharp.NativeAssets.Win32.targets",
        "harfbuzzsharp.nativeassets.win32.8.3.1.3.nupkg.sha512",
        "harfbuzzsharp.nativeassets.win32.nuspec",
        "icon.png",
        "lib/net462/_._",
        "lib/net6.0-windows10.0.19041/_._",
        "lib/net6.0/_._",
        "lib/net8.0-windows10.0.19041/_._",
        "lib/net8.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "runtimes/win-arm64/native/libHarfBuzzSharp.dll",
        "runtimes/win-arm64/native/libHarfBuzzSharp.pdb",
        "runtimes/win-x64/native/libHarfBuzzSharp.dll",
        "runtimes/win-x64/native/libHarfBuzzSharp.pdb",
        "runtimes/win-x86/native/libHarfBuzzSharp.dll",
        "runtimes/win-x86/native/libHarfBuzzSharp.pdb"
      ]
    },
    "MicroCom.Runtime/0.11.4": {
      "sha512": "yZ8+Lgwo+KtRI29TB2mIOEMzV+csMJ+pKZg4YHReAP3vRewWLKKeYfrBDo5FS69rWnEbCfU3sbM+ZEQr+GDLtg==",
      "type": "package",
      "path": "microcom.runtime/0.11.4",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "lib/net5.0/MicroCom.Runtime.dll",
        "lib/netstandard2.0/MicroCom.Runtime.dll",
        "microcom.runtime.0.11.4.nupkg.sha512",
        "microcom.runtime.nuspec"
      ]
    },
    "SkiaSharp/3.119.4-preview.1.1": {
      "sha512": "cyRjWksj/SwFWo7uPfpFk0sOPyUcE+FhF6ENFc3Q100sdJWHEA2nU1PcEeT7LsLFKBvDP/67q0A8vEXc4kvXnA==",
      "type": "package",
      "path": "skiasharp/3.119.4-preview.1.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "icon.png",
        "interactive-extensions/dotnet/SkiaSharp.DotNet.Interactive.dll",
        "lib/net10.0-android36.0/SkiaSharp.dll",
        "lib/net10.0-android36.0/SkiaSharp.pdb",
        "lib/net10.0-android36.0/SkiaSharp.xml",
        "lib/net10.0-ios26.2/SkiaSharp.dll",
        "lib/net10.0-ios26.2/SkiaSharp.pdb",
        "lib/net10.0-maccatalyst26.2/SkiaSharp.dll",
        "lib/net10.0-maccatalyst26.2/SkiaSharp.pdb",
        "lib/net10.0-macos26.2/SkiaSharp.dll",
        "lib/net10.0-macos26.2/SkiaSharp.pdb",
        "lib/net10.0-tizen10.0/SkiaSharp.dll",
        "lib/net10.0-tizen10.0/SkiaSharp.pdb",
        "lib/net10.0-tvos26.2/SkiaSharp.dll",
        "lib/net10.0-tvos26.2/SkiaSharp.pdb",
        "lib/net10.0-windows10.0.19041/SkiaSharp.dll",
        "lib/net10.0-windows10.0.19041/SkiaSharp.pdb",
        "lib/net10.0/SkiaSharp.dll",
        "lib/net10.0/SkiaSharp.pdb",
        "lib/net462/SkiaSharp.dll",
        "lib/net462/SkiaSharp.pdb",
        "lib/net48/SkiaSharp.dll",
        "lib/net48/SkiaSharp.pdb",
        "lib/net6.0-tizen8.0/SkiaSharp.dll",
        "lib/net6.0-tizen8.0/SkiaSharp.pdb",
        "lib/net6.0/SkiaSharp.dll",
        "lib/net6.0/SkiaSharp.pdb",
        "lib/net9.0-android35.0/SkiaSharp.dll",
        "lib/net9.0-android35.0/SkiaSharp.pdb",
        "lib/net9.0-android35.0/SkiaSharp.xml",
        "lib/net9.0-ios18.0/SkiaSharp.dll",
        "lib/net9.0-ios18.0/SkiaSharp.pdb",
        "lib/net9.0-maccatalyst18.0/SkiaSharp.dll",
        "lib/net9.0-maccatalyst18.0/SkiaSharp.pdb",
        "lib/net9.0-macos15.0/SkiaSharp.dll",
        "lib/net9.0-macos15.0/SkiaSharp.pdb",
        "lib/net9.0-tizen8.0/SkiaSharp.dll",
        "lib/net9.0-tizen8.0/SkiaSharp.pdb",
        "lib/net9.0-tvos18.0/SkiaSharp.dll",
        "lib/net9.0-tvos18.0/SkiaSharp.pdb",
        "lib/net9.0-windows10.0.19041/SkiaSharp.dll",
        "lib/net9.0-windows10.0.19041/SkiaSharp.pdb",
        "lib/net9.0/SkiaSharp.dll",
        "lib/net9.0/SkiaSharp.pdb",
        "lib/netstandard2.0/SkiaSharp.dll",
        "lib/netstandard2.0/SkiaSharp.pdb",
        "lib/netstandard2.1/SkiaSharp.dll",
        "lib/netstandard2.1/SkiaSharp.pdb",
        "ref/net10.0-android36.0/SkiaSharp.dll",
        "ref/net10.0-ios26.2/SkiaSharp.dll",
        "ref/net10.0-maccatalyst26.2/SkiaSharp.dll",
        "ref/net10.0-macos26.2/SkiaSharp.dll",
        "ref/net10.0-tizen10.0/SkiaSharp.dll",
        "ref/net10.0-tvos26.2/SkiaSharp.dll",
        "ref/net10.0-windows10.0.19041/SkiaSharp.dll",
        "ref/net10.0/SkiaSharp.dll",
        "ref/net462/SkiaSharp.dll",
        "ref/net48/SkiaSharp.dll",
        "ref/net6.0-tizen8.0/SkiaSharp.dll",
        "ref/net6.0/SkiaSharp.dll",
        "ref/net9.0-android35.0/SkiaSharp.dll",
        "ref/net9.0-ios18.0/SkiaSharp.dll",
        "ref/net9.0-maccatalyst18.0/SkiaSharp.dll",
        "ref/net9.0-macos15.0/SkiaSharp.dll",
        "ref/net9.0-tizen8.0/SkiaSharp.dll",
        "ref/net9.0-tvos18.0/SkiaSharp.dll",
        "ref/net9.0-windows10.0.19041/SkiaSharp.dll",
        "ref/net9.0/SkiaSharp.dll",
        "ref/netstandard2.0/SkiaSharp.dll",
        "ref/netstandard2.1/SkiaSharp.dll",
        "skiasharp.3.119.4-preview.1.1.nupkg.sha512",
        "skiasharp.nuspec"
      ]
    },
    "SkiaSharp.NativeAssets.Linux/3.119.4-preview.1.1": {
      "sha512": "rZEnNkds7UWOWCCsi//v3VQ7MWbhqn83J1mCzl9069N1Zza7SXufVvsvpI4qJYUHaRx8ZhAaL0yi3zlKoXaUJw==",
      "type": "package",
      "path": "skiasharp.nativeassets.linux/3.119.4-preview.1.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "build/net462/SkiaSharp.NativeAssets.Linux.targets",
        "build/net48/SkiaSharp.NativeAssets.Linux.targets",
        "buildTransitive/net462/SkiaSharp.NativeAssets.Linux.targets",
        "buildTransitive/net48/SkiaSharp.NativeAssets.Linux.targets",
        "icon.png",
        "lib/net10.0/_._",
        "lib/net462/_._",
        "lib/net48/_._",
        "lib/net6.0/_._",
        "lib/net9.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "runtimes/linux-arm/native/libSkiaSharp.so",
        "runtimes/linux-arm64/native/libSkiaSharp.so",
        "runtimes/linux-bionic-arm64/native/libSkiaSharp.so",
        "runtimes/linux-bionic-x64/native/libSkiaSharp.so",
        "runtimes/linux-loongarch64/native/libSkiaSharp.so",
        "runtimes/linux-musl-arm/native/libSkiaSharp.so",
        "runtimes/linux-musl-arm64/native/libSkiaSharp.so",
        "runtimes/linux-musl-loongarch64/native/libSkiaSharp.so",
        "runtimes/linux-musl-riscv64/native/libSkiaSharp.so",
        "runtimes/linux-musl-x64/native/libSkiaSharp.so",
        "runtimes/linux-riscv64/native/libSkiaSharp.so",
        "runtimes/linux-x64/native/libSkiaSharp.so",
        "runtimes/linux-x86/native/libSkiaSharp.so",
        "skiasharp.nativeassets.linux.3.119.4-preview.1.1.nupkg.sha512",
        "skiasharp.nativeassets.linux.nuspec"
      ]
    },
    "SkiaSharp.NativeAssets.macOS/3.119.4-preview.1.1": {
      "sha512": "77gyFnZD0uU12ABgI6pe8Iw2GRBYGryMP4EaHFs7fniffthVT5sf4PTug4ytwNzLKkVDiLobEpIvAJAj3UXwEw==",
      "type": "package",
      "path": "skiasharp.nativeassets.macos/3.119.4-preview.1.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "build/net462/SkiaSharp.NativeAssets.macOS.targets",
        "build/net48/SkiaSharp.NativeAssets.macOS.targets",
        "buildTransitive/net10.0-macos26.2/SkiaSharp.NativeAssets.macOS.targets",
        "buildTransitive/net462/SkiaSharp.NativeAssets.macOS.targets",
        "buildTransitive/net48/SkiaSharp.NativeAssets.macOS.targets",
        "buildTransitive/net9.0-macos15.0/SkiaSharp.NativeAssets.macOS.targets",
        "icon.png",
        "lib/net10.0-macos26.2/_._",
        "lib/net10.0/_._",
        "lib/net462/_._",
        "lib/net48/_._",
        "lib/net6.0/_._",
        "lib/net9.0-macos15.0/_._",
        "lib/net9.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "runtimes/osx/native/libSkiaSharp.dylib",
        "skiasharp.nativeassets.macos.3.119.4-preview.1.1.nupkg.sha512",
        "skiasharp.nativeassets.macos.nuspec"
      ]
    },
    "SkiaSharp.NativeAssets.WebAssembly/3.119.4-preview.1.1": {
      "sha512": "IyNI0QRJGl5sT0Dz2rGHBYVmenNoXcOCaC21avrLG5LwkX8ou0PluW2Hgz7NxHxiRL9D0kPmtoYWrr3uxd1NgA==",
      "type": "package",
      "path": "skiasharp.nativeassets.webassembly/3.119.4-preview.1.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "buildTransitive/netstandard1.0/SkiaSharp.NativeAssets.WebAssembly.props",
        "buildTransitive/netstandard1.0/SkiaSharp.NativeAssets.WebAssembly.targets",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/2.0.23/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/2.0.6/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.12/mt,simd/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.12/mt/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.12/st,simd/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.12/st/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.34/mt,simd/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.34/mt/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.34/st,simd/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.34/st/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.56/mt,simd/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.56/mt/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.56/st,simd/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.56/st/libSkiaSharp.a",
        "buildTransitive/netstandard1.0/libSkiaSharp.a/3.1.7/libSkiaSharp.a",
        "icon.png",
        "lib/net10.0/_._",
        "lib/net462/_._",
        "lib/net48/_._",
        "lib/net6.0/_._",
        "lib/net9.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "skiasharp.nativeassets.webassembly.3.119.4-preview.1.1.nupkg.sha512",
        "skiasharp.nativeassets.webassembly.nuspec"
      ]
    },
    "SkiaSharp.NativeAssets.Win32/3.119.4-preview.1.1": {
      "sha512": "BYwNLG02IAYMsBPgU9lM37xJgCM3B/2X5z1FQEBR34dmn+Hxvcw8X83PInY2rzix7mlbcv7OF8UHjf7yMbsDaA==",
      "type": "package",
      "path": "skiasharp.nativeassets.win32/3.119.4-preview.1.1",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "LICENSE.txt",
        "README.md",
        "THIRD-PARTY-NOTICES.txt",
        "build/net462/SkiaSharp.NativeAssets.Win32.targets",
        "build/net48/SkiaSharp.NativeAssets.Win32.targets",
        "buildTransitive/net462/SkiaSharp.NativeAssets.Win32.targets",
        "buildTransitive/net48/SkiaSharp.NativeAssets.Win32.targets",
        "icon.png",
        "lib/net10.0-windows10.0.19041/_._",
        "lib/net10.0/_._",
        "lib/net462/_._",
        "lib/net48/_._",
        "lib/net6.0/_._",
        "lib/net9.0-windows10.0.19041/_._",
        "lib/net9.0/_._",
        "lib/netstandard2.0/_._",
        "lib/netstandard2.1/_._",
        "runtimes/win-arm64/native/libSkiaSharp.dll",
        "runtimes/win-arm64/native/libSkiaSharp.pdb",
        "runtimes/win-x64/native/libSkiaSharp.dll",
        "runtimes/win-x64/native/libSkiaSharp.pdb",
        "runtimes/win-x86/native/libSkiaSharp.dll",
        "runtimes/win-x86/native/libSkiaSharp.pdb",
        "skiasharp.nativeassets.win32.3.119.4-preview.1.1.nupkg.sha512",
        "skiasharp.nativeassets.win32.nuspec"
      ]
    },
    "System.IO.Pipelines/8.0.0": {
      "sha512": "FHNOatmUq0sqJOkTx+UF/9YK1f180cnW5FVqnQMvYUN0elp6wFzbtPSiqbo1/ru8ICp43JM1i7kKkk6GsNGHlA==",
      "type": "package",
      "path": "system.io.pipelines/8.0.0",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "Icon.png",
        "LICENSE.TXT",
        "THIRD-PARTY-NOTICES.TXT",
        "buildTransitive/net461/System.IO.Pipelines.targets",
        "buildTransitive/net462/_._",
        "buildTransitive/net6.0/_._",
        "buildTransitive/netcoreapp2.0/System.IO.Pipelines.targets",
        "lib/net462/System.IO.Pipelines.dll",
        "lib/net462/System.IO.Pipelines.xml",
        "lib/net6.0/System.IO.Pipelines.dll",
        "lib/net6.0/System.IO.Pipelines.xml",
        "lib/net7.0/System.IO.Pipelines.dll",
        "lib/net7.0/System.IO.Pipelines.xml",
        "lib/net8.0/System.IO.Pipelines.dll",
        "lib/net8.0/System.IO.Pipelines.xml",
        "lib/netstandard2.0/System.IO.Pipelines.dll",
        "lib/netstandard2.0/System.IO.Pipelines.xml",
        "system.io.pipelines.8.0.0.nupkg.sha512",
        "system.io.pipelines.nuspec",
        "useSharedDesignerContext.txt"
      ]
    },
    "Tmds.DBus.Protocol/0.92.0": {
      "sha512": "h7IMakm0PF2jxiagoysoAjrzzLQ0UBdnSXQL5kb17YW0Fvyo12Tg96A99QkzwktWRrd7H+Uw9EzjasNLUfGYlA==",
      "type": "package",
      "path": "tmds.dbus.protocol/0.92.0",
      "files": [
        ".nupkg.metadata",
        ".signature.p7s",
        "README.md",
        "icon_128.png",
        "lib/net6.0/Tmds.DBus.Protocol.dll",
        "lib/net6.0/Tmds.DBus.Protocol.xml",
        "lib/net8.0/Tmds.DBus.Protocol.dll",
        "lib/net8.0/Tmds.DBus.Protocol.xml",
        "lib/net9.0/Tmds.DBus.Protocol.dll",
        "lib/net9.0/Tmds.DBus.Protocol.xml",
        "lib/netstandard2.0/Tmds.DBus.Protocol.dll",
        "lib/netstandard2.0/Tmds.DBus.Protocol.xml",
        "lib/netstandard2.1/Tmds.DBus.Protocol.dll",
        "lib/netstandard2.1/Tmds.DBus.Protocol.xml",
        "tmds.dbus.protocol.0.92.0.nupkg.sha512",
        "tmds.dbus.protocol.nuspec"
      ]
    }
  },
  "projectFileDependencyGroups": {
    "net8.0": [
      "Avalonia >= 12.0.3",
      "Avalonia.Controls.WebView >= 12.0.1",
      "Avalonia.Desktop >= 12.0.3",
      "Avalonia.Fonts.Inter >= 12.0.3",
      "Avalonia.Themes.Fluent >= 12.0.3",
      "CommunityToolkit.Mvvm >= 8.4.1"
    ]
  },
  "packageFolders": {
    "C:\\Users\\huyho\\.nuget\\packages\\": {}
  },
  "project": {
    "version": "1.0.0",
    "restore": {
      "projectUniqueName": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj",
      "projectName": "MiniZotero",
      "projectPath": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj",
      "packagesPath": "C:\\Users\\huyho\\.nuget\\packages\\",
      "outputPath": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\obj\\",
      "projectStyle": "PackageReference",
      "configFilePaths": [
        "C:\\Users\\huyho\\AppData\\Roaming\\NuGet\\NuGet.Config",
        "C:\\Program Files (x86)\\NuGet\\Config\\Microsoft.VisualStudio.Offline.config"
      ],
      "originalTargetFrameworks": [
        "net8.0"
      ],
      "sources": {
        "C:\\Program Files (x86)\\Microsoft SDKs\\NuGetPackages\\": {},
        "https://api.nuget.org/v3/index.json": {}
      },
      "frameworks": {
        "net8.0": {
          "targetAlias": "net8.0",
          "projectReferences": {}
        }
      },
      "warningProperties": {
        "warnAsError": [
          "NU1605"
        ]
      },
      "restoreAuditProperties": {
        "enableAudit": "true",
        "auditLevel": "low",
        "auditMode": "direct"
      },
      "SdkAnalysisLevel": "9.0.300"
    },
    "frameworks": {
      "net8.0": {
        "targetAlias": "net8.0",
        "dependencies": {
          "Avalonia": {
            "target": "Package",
            "version": "[12.0.3, )"
          },
          "Avalonia.Controls.WebView": {
            "target": "Package",
            "version": "[12.0.1, )"
          },
          "Avalonia.Desktop": {
            "target": "Package",
            "version": "[12.0.3, )"
          },
          "Avalonia.Fonts.Inter": {
            "target": "Package",
            "version": "[12.0.3, )"
          },
          "Avalonia.Themes.Fluent": {
            "target": "Package",
            "version": "[12.0.3, )"
          },
          "CommunityToolkit.Mvvm": {
            "target": "Package",
            "version": "[8.4.1, )"
          }
        },
        "imports": [
          "net461",
          "net462",
          "net47",
          "net471",
          "net472",
          "net48",
          "net481"
        ],
        "assetTargetFallback": true,
        "warn": true,
        "frameworkReferences": {
          "Microsoft.NETCore.App": {
            "privateAssets": "all"
          }
        },
        "runtimeIdentifierGraphPath": "C:\\Program Files\\dotnet\\sdk\\9.0.305/PortableRuntimeIdentifierGraph.json"
      }
    }
  }
}
````

## MiniZotero/obj/project.nuget.cache

``text
{
  "version": 2,
  "dgSpecHash": "NeKV1pjrwGk=",
  "success": true,
  "projectFilePath": "C:\\Users\\huyho\\source\\repos\\MiniZotero\\MiniZotero\\MiniZotero.csproj",
  "expectedPackageFiles": [
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia\\12.0.3\\avalonia.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.angle.windows.natives\\2.1.25547.20250602\\avalonia.angle.windows.natives.2.1.25547.20250602.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.buildservices\\11.3.2\\avalonia.buildservices.11.3.2.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.controls.webview\\12.0.1\\avalonia.controls.webview.12.0.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.desktop\\12.0.3\\avalonia.desktop.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.fonts.inter\\12.0.3\\avalonia.fonts.inter.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.freedesktop\\12.0.3\\avalonia.freedesktop.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.freedesktop.atspi\\12.0.3\\avalonia.freedesktop.atspi.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.harfbuzz\\12.0.3\\avalonia.harfbuzz.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.native\\12.0.3\\avalonia.native.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.remote.protocol\\12.0.3\\avalonia.remote.protocol.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.skia\\12.0.3\\avalonia.skia.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.themes.fluent\\12.0.3\\avalonia.themes.fluent.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.win32\\12.0.3\\avalonia.win32.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\avalonia.x11\\12.0.3\\avalonia.x11.12.0.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\communitytoolkit.mvvm\\8.4.1\\communitytoolkit.mvvm.8.4.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\harfbuzzsharp\\8.3.1.3\\harfbuzzsharp.8.3.1.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\harfbuzzsharp.nativeassets.linux\\8.3.1.3\\harfbuzzsharp.nativeassets.linux.8.3.1.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\harfbuzzsharp.nativeassets.macos\\8.3.1.3\\harfbuzzsharp.nativeassets.macos.8.3.1.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\harfbuzzsharp.nativeassets.webassembly\\8.3.1.3\\harfbuzzsharp.nativeassets.webassembly.8.3.1.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\harfbuzzsharp.nativeassets.win32\\8.3.1.3\\harfbuzzsharp.nativeassets.win32.8.3.1.3.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\microcom.runtime\\0.11.4\\microcom.runtime.0.11.4.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\skiasharp\\3.119.4-preview.1.1\\skiasharp.3.119.4-preview.1.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\skiasharp.nativeassets.linux\\3.119.4-preview.1.1\\skiasharp.nativeassets.linux.3.119.4-preview.1.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\skiasharp.nativeassets.macos\\3.119.4-preview.1.1\\skiasharp.nativeassets.macos.3.119.4-preview.1.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\skiasharp.nativeassets.webassembly\\3.119.4-preview.1.1\\skiasharp.nativeassets.webassembly.3.119.4-preview.1.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\skiasharp.nativeassets.win32\\3.119.4-preview.1.1\\skiasharp.nativeassets.win32.3.119.4-preview.1.1.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\system.io.pipelines\\8.0.0\\system.io.pipelines.8.0.0.nupkg.sha512",
    "C:\\Users\\huyho\\.nuget\\packages\\tmds.dbus.protocol\\0.92.0\\tmds.dbus.protocol.0.92.0.nupkg.sha512"
  ],
  "logs": []
}
````

## MiniZotero/Program.cs

``csharp
using System;
using Avalonia;

namespace MiniZotero
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}

````

## MiniZotero/Repositories/AppSettingsRepository.cs

``csharp
using System.IO;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class AppSettingsRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;

        public AppSettingsRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public AppSettings LoadSettings()
        {
            if (!File.Exists(_storageService.SettingsFilePath))
            {
                return new AppSettings();
            }

            try
            {
                var json = File.ReadAllText(_storageService.SettingsFilePath);
                return JsonSerializer.Deserialize<AppSettings>(json, JsonOptions) ?? new AppSettings();
            }
            catch
            {
                return new AppSettings();
            }
        }

        public void SaveSettings(AppSettings settings)
        {
            var json = JsonSerializer.Serialize(settings, JsonOptions);
            File.WriteAllText(_storageService.SettingsFilePath, json);
        }
    }
}

````

## MiniZotero/Repositories/DocumentRepository.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class DocumentRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;
        private readonly AutoTagService _autoTagService;

        public DocumentRepository(AppStorageService storageService)
            : this(storageService, new AutoTagService())
        {
        }

        public DocumentRepository(
            AppStorageService storageService,
            AutoTagService autoTagService)
        {
            _storageService = storageService;
            _autoTagService = autoTagService;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            var libraryPath = _storageService.LibraryFilePath;
            if (!File.Exists(libraryPath))
            {
                return [];
            }

            try
            {
                var json = File.ReadAllText(libraryPath);
                var documents = JsonSerializer.Deserialize<List<DocumentItem>>(json, JsonOptions) ?? [];
                var changed = NormalizeDocuments(documents);
                changed |= MigrateDocumentsToStorage(documents);
                changed |= ApplyMissingAutoTags(documents);

                if (changed)
                {
                    SaveDocuments(documents);
                }

                return documents;
            }
            catch (IOException)
            {
                return [];
            }
            catch (JsonException)
            {
                return [];
            }
        }

        public DocumentItem ImportDocument(string sourceFilePath, IEnumerable<DocumentItem> existingDocuments)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("The selected PDF file does not exist.", sourceFilePath);
            }

            var normalizedSourcePath = Path.GetFullPath(sourceFilePath);
            var existingDocument = existingDocuments.FirstOrDefault(document =>
                IsSamePath(document.OriginalFilePath, normalizedSourcePath) ||
                IsSamePath(document.FilePath, normalizedSourcePath));

            if (existingDocument is not null)
            {
                ApplyAutoTags(existingDocument, normalizedSourcePath);
                return existingDocument;
            }

            var documentId = Guid.NewGuid().ToString("N");
            var destinationPath = Path.Combine(_storageService.PdfFolderPath, $"{documentId}.pdf");
            File.Copy(normalizedSourcePath, destinationPath, overwrite: false);

            var document = new DocumentItem(
                documentId,
                Path.GetFileNameWithoutExtension(normalizedSourcePath),
                destinationPath,
                normalizedSourcePath,
                DateTimeOffset.Now,
                lastOpenedAt: null,
                lastReadPage: 1);

            ApplyAutoTags(document, normalizedSourcePath);

            return document;
        }

        public DocumentItem AddDocument(string filePath)
        {
            var documents = LoadDocuments().ToList();
            var document = ImportDocument(filePath, documents);

            if (!documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                documents.Add(document);
            }

            SaveDocuments(documents);

            return document;
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            var json = JsonSerializer.Serialize(documents, JsonOptions);
            File.WriteAllText(_storageService.LibraryFilePath, json);
        }

        public void DeleteStoredPdfFile(DocumentItem document)
        {
            if (string.IsNullOrWhiteSpace(document.FilePath))
            {
                return;
            }

            try
            {
                if (File.Exists(document.FilePath) && IsStoredPdfPath(document.FilePath))
                {
                    File.Delete(document.FilePath);
                }
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        private static bool IsSamePath(string? left, string right)
        {
            if (string.IsNullOrWhiteSpace(left))
            {
                return false;
            }

            return string.Equals(Path.GetFullPath(left), right, StringComparison.OrdinalIgnoreCase);
        }

        private bool MigrateDocumentsToStorage(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                if (string.IsNullOrWhiteSpace(document.FilePath) ||
                    IsStoredPdfPath(document.FilePath) ||
                    !File.Exists(document.FilePath))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(document.OriginalFilePath))
                {
                    document.OriginalFilePath = document.FilePath;
                }

                var destinationPath = Path.Combine(_storageService.PdfFolderPath, $"{document.Id}.pdf");
                if (!File.Exists(destinationPath))
                {
                    File.Copy(document.FilePath, destinationPath, overwrite: false);
                }

                document.FilePath = destinationPath;
                changed = true;
            }

            return changed;
        }

        private bool IsStoredPdfPath(string filePath)
        {
            var normalizedFilePath = Path.GetFullPath(filePath);
            var normalizedPdfFolderPath = Path.GetFullPath(_storageService.PdfFolderPath);

            return normalizedFilePath.StartsWith(
                normalizedPdfFolderPath,
                StringComparison.OrdinalIgnoreCase);
        }

        private bool ApplyMissingAutoTags(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                var sourcePath = !string.IsNullOrWhiteSpace(document.OriginalFilePath)
                    ? document.OriginalFilePath
                    : document.FilePath;

                if (string.IsNullOrWhiteSpace(sourcePath))
                {
                    continue;
                }

                changed |= ApplyAutoTags(document, sourcePath);
            }

            return changed;
        }

        private bool ApplyAutoTags(DocumentItem document, string sourceFilePath)
        {
            document.Tags ??= [];
            var changed = false;

            foreach (var tag in _autoTagService.GenerateTags(sourceFilePath, document.Title))
            {
                var exists = document.Tags.Any(existingTag =>
                    string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    continue;
                }

                document.Tags.Add(tag);
                changed = true;
            }

            return changed;
        }

        private static bool NormalizeDocuments(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                if (string.IsNullOrWhiteSpace(document.Id))
                {
                    document.Id = Guid.NewGuid().ToString("N");
                    changed = true;
                }

                if (string.IsNullOrWhiteSpace(document.OriginalFilePath))
                {
                    document.OriginalFilePath = document.FilePath;
                    changed = true;
                }

                if (string.IsNullOrWhiteSpace(document.Title) &&
                    !string.IsNullOrWhiteSpace(document.FilePath))
                {
                    document.Title = Path.GetFileNameWithoutExtension(document.FilePath);
                    changed = true;
                }

                if (document.LastReadPage < 1)
                {
                    document.LastReadPage = 1;
                    changed = true;
                }

                if (document.LastZoomPercent < 50 || document.LastZoomPercent > 400)
                {
                    document.LastZoomPercent = 120;
                    changed = true;
                }

                if (document.Tags is null)
                {
                    document.Tags = [];
                    changed = true;
                }

                if (!document.IsDeleted && document.DeletedAt is not null)
                {
                    document.DeletedAt = null;
                    changed = true;
                }

                if (document.IsDeleted && document.DeletedAt is null)
                {
                    document.DeletedAt = DateTimeOffset.Now;
                    changed = true;
                }
            }

            return changed;
        }
    }
}

````

## MiniZotero/Repositories/HighlightRepository.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class HighlightRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;

        public HighlightRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public IReadOnlyList<HighlightItem> LoadHighlights(string documentId)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return [];
            }

            var path = GetHighlightFilePath(documentId);

            if (!File.Exists(path))
            {
                return [];
            }

            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<HighlightItem>>(json, JsonOptions) ?? [];
            }
            catch (IOException)
            {
                return [];
            }
            catch (JsonException)
            {
                return [];
            }
            catch (UnauthorizedAccessException)
            {
                return [];
            }
        }

        public HighlightItem AddHighlight(HighlightItem highlight)
        {
            if (string.IsNullOrWhiteSpace(highlight.DocumentId))
            {
                throw new InvalidOperationException("Highlight must have a document id.");
            }

            if (string.IsNullOrWhiteSpace(highlight.Id))
            {
                highlight.Id = Guid.NewGuid().ToString("N");
            }

            if (highlight.CreatedAt == default)
            {
                highlight.CreatedAt = DateTimeOffset.Now;
            }

            var highlights = LoadHighlights(highlight.DocumentId).ToList();
            highlights.Add(highlight);

            SaveHighlights(highlight.DocumentId, highlights);

            return highlight;
        }

        public void DeleteHighlight(string documentId, string highlightId)
        {
            if (string.IsNullOrWhiteSpace(documentId) ||
                string.IsNullOrWhiteSpace(highlightId))
            {
                return;
            }

            var highlights = LoadHighlights(documentId).ToList();
            highlights.RemoveAll(highlight => highlight.Id == highlightId);

            SaveHighlights(documentId, highlights);
        }

        public void SaveHighlights(string documentId, IEnumerable<HighlightItem> highlights)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return;
            }

            var path = GetHighlightFilePath(documentId);
            var json = JsonSerializer.Serialize(highlights, JsonOptions);

            File.WriteAllText(path, json);
        }

        private string GetHighlightFilePath(string documentId)
        {
            return Path.Combine(_storageService.HighlightsFolderPath, $"{documentId}.json");
        }
    }
}

````

## MiniZotero/Repositories/NoteRepository.cs

``csharp
using System.IO;
using System.Linq;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class NoteRepository
    {
        private readonly AppStorageService _storageService;

        public NoteRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public string LoadNote(string documentId)
        {
            var notePath = GetNotePath(documentId);

            return File.Exists(notePath)
                ? File.ReadAllText(notePath)
                : string.Empty;
        }

        public void SaveNote(string documentId, string text)
        {
            var notePath = GetNotePath(documentId);
            File.WriteAllText(notePath, text);
        }

        private string GetNotePath(string documentId)
        {
            var safeDocumentId = string.Concat(
                documentId.Select(character =>
                    Path.GetInvalidFileNameChars().Contains(character) ? '_' : character));

            if (string.IsNullOrWhiteSpace(safeDocumentId))
            {
                safeDocumentId = "untitled";
            }

            return Path.Combine(_storageService.NotesFolderPath, $"{safeDocumentId}.md");
        }
    }
}

````

## MiniZotero/Services/AppStorageService.cs

``csharp
using System;
using System.IO;

namespace MiniZotero.Services
{
    public sealed class AppStorageService
    {
        private const string AppFolderName = "MiniZotero";
        private const string LibraryFileName = "library.json";
        private const string SettingsFileName = "settings.json";
        private const string PdfFolderName = "pdfs";
        private const string NotesFolderName = "notes";
        private const string HighlightsFolderName = "highlights";

        public AppStorageService()
        {
            RootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                AppFolderName);

            Directory.CreateDirectory(RootPath);
            Directory.CreateDirectory(PdfFolderPath);
            Directory.CreateDirectory(NotesFolderPath);
            Directory.CreateDirectory(HighlightsFolderPath);
        }

        public string RootPath { get; }

        public string AppDataPath => RootPath;

        public string PdfFolderPath => Path.Combine(RootPath, PdfFolderName);

        public string NotesFolderPath => Path.Combine(RootPath, NotesFolderName);

        public string HighlightsFolderPath => Path.Combine(RootPath, HighlightsFolderName);

        public string LibraryFilePath => Path.Combine(RootPath, LibraryFileName);

        public string SettingsFilePath => Path.Combine(RootPath, SettingsFileName);
    }
}

````

## MiniZotero/Services/AutoTagService.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniZotero.Services
{
    public sealed class AutoTagService
    {
        private static readonly Dictionary<string, string[]> Rules = new(StringComparer.OrdinalIgnoreCase)
        {
            ["C#"] = ["csharp", "c#", ".net", "dotnet", "avalonia", "wpf", "oop", "class", "inheritance"],
            ["CMOS"] = ["cmos", "mosfet", "inverter", "spice", "cadence", "opamp"],
            ["Embedded"] = ["stm32", "esp32", "arduino", "uart", "adc", "pwm", "freertos"],
            ["Datasheet"] = ["datasheet", "specification", "max30102", "mpu6050"],
            ["Paper"] = ["abstract", "ieee", "references", "journal", "conference"],
            ["Circuit"] = ["schematic", "pcb", "altium", "ltspice", "simulation"]
        };

        public IReadOnlyList<string> GenerateTags(string filePath, string title)
        {
            var folderName = Path.GetDirectoryName(filePath) is { } folderPath
                ? Path.GetFileName(folderPath)
                : string.Empty;

            var source = $"{filePath} {folderName} {title}".ToLowerInvariant();
            var tags = new List<string>();

            foreach (var rule in Rules)
            {
                if (rule.Value.Any(keyword => source.Contains(keyword.ToLowerInvariant())))
                {
                    tags.Add(rule.Key);
                }
            }

            return tags
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
    }
}

````

## MiniZotero/Services/MarkdownExportService.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class MarkdownExportService
    {
        public void ExportDocumentNotes(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights,
            string outputPath)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return;
            }

            var markdown = BuildMarkdown(document, noteText, highlights);
            File.WriteAllText(outputPath, markdown, Encoding.UTF8);
        }

        private static string BuildMarkdown(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"# {document.Title}");
            builder.AppendLine();
            builder.AppendLine("## Document");
            builder.AppendLine();
            builder.AppendLine($"- File: `{document.FilePath}`");
            builder.AppendLine($"- Original: `{document.OriginalFilePath}`");
            builder.AppendLine($"- Added: {document.AddedAt:yyyy-MM-dd HH:mm}");
            builder.AppendLine($"- Last page: {document.LastReadPage}");
            builder.AppendLine();

            builder.AppendLine("## Notes");
            builder.AppendLine();

            if (string.IsNullOrWhiteSpace(noteText))
            {
                builder.AppendLine("_No notes yet._");
            }
            else
            {
                builder.AppendLine(noteText.Trim());
            }

            builder.AppendLine();
            builder.AppendLine("## Highlights");
            builder.AppendLine();

            var orderedHighlights = highlights
                .OrderBy(highlight => highlight.PageNumber)
                .ThenBy(highlight => highlight.CreatedAt)
                .ToList();

            if (orderedHighlights.Count == 0)
            {
                builder.AppendLine("_No highlights yet._");
                return builder.ToString();
            }

            foreach (var highlight in orderedHighlights)
            {
                builder.AppendLine($"### Page {highlight.PageNumber}");
                builder.AppendLine();
                builder.AppendLine($"> {NormalizeQuote(highlight.Text)}");
                builder.AppendLine();
                builder.AppendLine($"- Created: {highlight.CreatedAt:yyyy-MM-dd HH:mm}");
                builder.AppendLine($"- Highlight Id: `{highlight.Id}`");
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private static string NormalizeQuote(string? text)
        {
            return (text ?? string.Empty)
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Replace("\n", "\n> ")
                .Trim();
        }
    }
}

````

## MiniZotero/Services/PdfJsServerService.cs

``csharp
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public sealed class PdfJsServerService
    {
        private readonly HttpListener _listener = new();
        private readonly ConcurrentDictionary<string, string> _pdfFiles = new();

        private bool _isStarted;

        public int Port { get; } = 51234;

        public string BaseUrl => $"http://127.0.0.1:{Port}";

        public void Start()
        {
            if (_isStarted)
            {
                return;
            }

            _listener.Prefixes.Add($"{BaseUrl}/");
            _listener.Start();

            _isStarted = true;

            Task.Run(ListenLoop);
        }

        public string RegisterPdf(
            string documentKey,
            string filePath,
            int pageNumber = 1,
            int zoomPercent = 120,
            string? reloadToken = null)
        {
            _pdfFiles[documentKey] = filePath;

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            zoomPercent = Math.Clamp(zoomPercent, 50, 400);

            string pdfUrl = $"{BaseUrl}/pdf/{Uri.EscapeDataString(documentKey)}";

            string viewerUrl =
                $"{BaseUrl}/viewer/index.html" +
                $"?file={Uri.EscapeDataString(pdfUrl)}" +
                $"&documentId={Uri.EscapeDataString(documentKey)}" +
                $"&v={Uri.EscapeDataString(reloadToken ?? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString())}" +
                $"#page={pageNumber}&zoom={zoomPercent}";

            return viewerUrl;
        }

        private async Task ListenLoop()
        {
            while (_listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    _ = Task.Run(() => HandleRequest(context));
                }
                catch
                {
                    // Ignore listener errors.
                }
            }
        }

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
                string path = context.Request.Url?.AbsolutePath ?? "/";

                if (path.StartsWith("/viewer/", StringComparison.OrdinalIgnoreCase))
                {
                    ServeAssetFile(context, "PdfViewer", path.Replace("/viewer/", string.Empty));
                    return;
                }

                if (path.StartsWith("/PdfJs/", StringComparison.OrdinalIgnoreCase) ||
                    path.StartsWith("/pdfjs/", StringComparison.OrdinalIgnoreCase))
                {
                    string relativePath = path
                        .Replace("/PdfJs/", string.Empty)
                        .Replace("/pdfjs/", string.Empty);

                    ServeAssetFile(context, "PdfJs", relativePath);
                    return;
                }

                if (path.StartsWith("/pdf/", StringComparison.OrdinalIgnoreCase))
                {
                    ServePdfFile(context, path);
                    return;
                }

                WriteText(context, "MiniZotero PDF server is running.");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                WriteText(context, ex.Message);
            }
            finally
            {
                try
                {
                    context.Response.OutputStream.Close();
                }
                catch
                {
                    // Ignore.
                }
            }
        }

        private void ServeAssetFile(HttpListenerContext context, string rootFolder, string relativePath)
        {
            relativePath = Uri.UnescapeDataString(relativePath)
                .Replace('/', Path.DirectorySeparatorChar);

            string filePath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                rootFolder,
                relativePath
            ));

            string rootPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                rootFolder
            ));

            if (!filePath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 403;
                WriteText(context, "Asset path is not allowed.");
                return;
            }

            if (!File.Exists(filePath))
            {
                context.Response.StatusCode = 404;
                WriteText(context, $"Asset not found: {filePath}");
                return;
            }

            byte[] data = File.ReadAllBytes(filePath);

            context.Response.ContentType = GetContentType(filePath);
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(data, 0, data.Length);
        }

        private void ServePdfFile(HttpListenerContext context, string path)
        {
            string documentKey = Uri.UnescapeDataString(
                path.Replace("/pdf/", string.Empty)
            );

            if (!_pdfFiles.TryGetValue(documentKey, out string? pdfPath))
            {
                context.Response.StatusCode = 404;
                WriteText(context, "PDF is not registered.");
                return;
            }

            if (!File.Exists(pdfPath))
            {
                context.Response.StatusCode = 404;
                WriteText(context, $"PDF file not found: {pdfPath}");
                return;
            }

            byte[] data = File.ReadAllBytes(pdfPath);

            context.Response.ContentType = "application/pdf";
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(data, 0, data.Length);
        }

        private static string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".html" => "text/html; charset=utf-8",
                ".css" => "text/css; charset=utf-8",
                ".js" => "text/javascript; charset=utf-8",
                ".mjs" => "text/javascript; charset=utf-8",
                ".json" => "application/json; charset=utf-8",
                ".wasm" => "application/wasm",
                ".png" => "image/png",
                ".svg" => "image/svg+xml",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }

        private static void WriteText(HttpListenerContext context, string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            context.Response.ContentType = "text/plain; charset=utf-8";
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(data, 0, data.Length);
        }
    }
}

````

## MiniZotero/Services/WatchFolderService.cs

``csharp
using System;
using System.IO;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public sealed class WatchFolderService : IDisposable
    {
        private FileSystemWatcher? _watcher;

        public event Action<string>? PdfDetected;

        public string? FolderPath { get; private set; }

        public bool IsWatching => _watcher is not null;

        public void Start(string folderPath)
        {
            Stop();

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return;
            }

            FolderPath = folderPath;

            _watcher = new FileSystemWatcher(folderPath)
            {
                Filter = "*.pdf",
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size
            };

            _watcher.Created += OnPdfCreated;
            _watcher.Renamed += OnPdfRenamed;
            _watcher.EnableRaisingEvents = true;

            ImportExistingPdfs(folderPath);
        }

        public void Stop()
        {
            if (_watcher is null)
            {
                return;
            }

            _watcher.EnableRaisingEvents = false;
            _watcher.Created -= OnPdfCreated;
            _watcher.Renamed -= OnPdfRenamed;
            _watcher.Dispose();
            _watcher = null;
        }

        private void ImportExistingPdfs(string folderPath)
        {
            foreach (var filePath in Directory.EnumerateFiles(folderPath, "*.pdf"))
            {
                _ = NotifyWhenReadyAsync(filePath);
            }
        }

        private void OnPdfCreated(object sender, FileSystemEventArgs e)
        {
            _ = NotifyWhenReadyAsync(e.FullPath);
        }

        private void OnPdfRenamed(object sender, RenamedEventArgs e)
        {
            _ = NotifyWhenReadyAsync(e.FullPath);
        }

        private async Task NotifyWhenReadyAsync(string filePath)
        {
            if (!filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var isReady = await WaitUntilFileReadyAsync(filePath);

            if (isReady)
            {
                PdfDetected?.Invoke(filePath);
            }
        }

        private static async Task<bool> WaitUntilFileReadyAsync(string filePath)
        {
            for (var attempt = 0; attempt < 20; attempt++)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        return false;
                    }

                    using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    return stream.Length > 0;
                }
                catch (IOException)
                {
                    await Task.Delay(300);
                }
                catch (UnauthorizedAccessException)
                {
                    await Task.Delay(300);
                }
            }

            return false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}

````

## MiniZotero/ViewLocator.cs

``csharp
using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using MiniZotero.ViewModels;

namespace MiniZotero
{
    /// <summary>
    /// Given a view model, returns the corresponding view if possible.
    /// </summary>
    [RequiresUnreferencedCode(
        "Default implementation of ViewLocator involves reflection which may be trimmed away.",
        Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}

````

## MiniZotero/ViewModels/MainWindowViewModel.cs

``csharp
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var storageService = new AppStorageService();
            var autoTagService = new AutoTagService();
            var documentRepository = new DocumentRepository(storageService, autoTagService);
            var noteRepository = new NoteRepository(storageService);
            var highlightRepository = new HighlightRepository(storageService);
            var settingsRepository = new AppSettingsRepository(storageService);
            var watchFolderService = new WatchFolderService();
            var markdownExportService = new MarkdownExportService();

            Sidebar = new SidebarViewModel(
                documentRepository,
                settingsRepository,
                watchFolderService);
            Notes = new NotePreviewPanelViewModel(
                noteRepository,
                highlightRepository,
                markdownExportService);
            Workspace = new TabWorkspaceViewModel(document =>
                documentRepository.SaveDocuments(Sidebar.Documents));

            Workspace.PdfViewer.HighlightCreated += (text, pageNumber, rects) =>
            {
                Notes.AddHighlightFromViewer(text, pageNumber, rects);
            };

            Notes.HighlightsChanged += () =>
            {
                Workspace.PdfViewer.LoadHighlightsIntoViewer(Notes.Highlights);
            };

            Notes.HighlightSelected += highlight =>
            {
                Workspace.PdfViewer.NavigateToHighlight(highlight);
            };

            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.SelectedDocument) &&
                    Sidebar.SelectedDocument is { } document)
                {
                    Workspace.OpenDocument(document);
                    Notes.OpenDocument(document);
                    Workspace.PdfViewer.LoadHighlightsIntoViewer(Notes.Highlights);
                }
            };
        }

        public SidebarViewModel Sidebar { get; }

        public TabWorkspaceViewModel Workspace { get; }

        public NotePreviewPanelViewModel Notes { get; }
    }
}

````

## MiniZotero/ViewModels/NotePreviewPanelViewModel.cs

``csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class NotePreviewPanelViewModel : ViewModelBase
    {
        private readonly NoteRepository _noteRepository;
        private readonly HighlightRepository _highlightRepository;
        private readonly MarkdownExportService _markdownExportService;
        private bool _isLoadingNote;

        public NotePreviewPanelViewModel(
            NoteRepository noteRepository,
            HighlightRepository highlightRepository,
            MarkdownExportService markdownExportService)
        {
            _noteRepository = noteRepository;
            _highlightRepository = highlightRepository;
            _markdownExportService = markdownExportService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasDocument))]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        [NotifyPropertyChangedFor(nameof(HasHighlights))]
        [NotifyPropertyChangedFor(nameof(IsHighlightEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        [ObservableProperty]
        private string _noteText = string.Empty;

        public ObservableCollection<HighlightItem> Highlights { get; } = [];

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public bool HasHighlights => Highlights.Count > 0;

        public bool IsHighlightEmptyViewVisible => HasDocument && !HasHighlights;

        public event Action<HighlightItem>? HighlightSelected;

        public event Action? HighlightsChanged;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            _isLoadingNote = true;

            try
            {
                NoteText = _noteRepository.LoadNote(document.Id);
            }
            finally
            {
                _isLoadingNote = false;
            }

            LoadHighlights(document.Id);
        }

        public void AddHighlightFromViewer(
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (ActiveDocument is null ||
                string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            var highlight = new HighlightItem
            {
                DocumentId = ActiveDocument.Id,
                PageNumber = pageNumber < 1 ? 1 : pageNumber,
                Text = text.Trim(),
                Color = "yellow",
                Rects = rects.ToList()
            };

            _highlightRepository.AddHighlight(highlight);
            LoadHighlights(ActiveDocument.Id);
        }

        public void ExportActiveDocumentToMarkdown(string outputPath)
        {
            if (ActiveDocument is null)
            {
                return;
            }

            _markdownExportService.ExportDocumentNotes(
                ActiveDocument,
                NoteText,
                Highlights,
                outputPath);
        }

        private void LoadHighlights(string documentId)
        {
            Highlights.Clear();

            foreach (var highlight in _highlightRepository.LoadHighlights(documentId))
            {
                Highlights.Add(highlight);
            }

            OnPropertyChanged(nameof(HasHighlights));
            OnPropertyChanged(nameof(IsHighlightEmptyViewVisible));
            HighlightsChanged?.Invoke();
        }

        [RelayCommand]
        private void SelectHighlight(HighlightItem? highlight)
        {
            if (highlight is null)
            {
                return;
            }

            HighlightSelected?.Invoke(highlight);
        }

        [RelayCommand]
        private void DeleteHighlight(HighlightItem? highlight)
        {
            if (highlight is null || ActiveDocument is null)
            {
                return;
            }

            _highlightRepository.DeleteHighlight(ActiveDocument.Id, highlight.Id);
            LoadHighlights(ActiveDocument.Id);
        }

        partial void OnNoteTextChanged(string value)
        {
            if (_isLoadingNote || ActiveDocument is not { } document)
            {
                return;
            }

            _noteRepository.SaveNote(document.Id, value);
        }
    }
}

````

## MiniZotero/ViewModels/PdfViewerViewModel.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class PdfViewerViewModel : ViewModelBase
    {
        private static readonly PdfJsServerService PdfServer = new();
        private readonly Action<DocumentItem> _persistReadingState;
        private DocumentItem? _activeDocument;
        private IReadOnlyList<HighlightItem> _currentHighlights = [];

        public PdfViewerViewModel()
            : this(_ => { })
        {
        }

        public PdfViewerViewModel(Action<DocumentItem> persistReadingState)
        {
            _persistReadingState = persistReadingState;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private bool _hasDocumentLoaded;

        [ObservableProperty]
        private string _documentPath = string.Empty;

        [ObservableProperty]
        private Uri? _viewerSource;

        [ObservableProperty]
        private int _currentPage = 1;

        [ObservableProperty]
        private int _zoomPercent = 120;

        [ObservableProperty]
        private string _statusText = "Ready";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsHandToolActive))]
        [NotifyPropertyChangedFor(nameof(IsSelectToolActive))]
        [NotifyPropertyChangedFor(nameof(IsHighlightToolActive))]
        private string _toolMode = "select";

        [ObservableProperty]
        private string _emptyTitle = "Select a document to view";

        [ObservableProperty]
        private string _emptyMessage = "Import a PDF file from the sidebar.";

        public bool IsEmptyViewVisible => !HasDocumentLoaded;

        public bool IsHandToolActive => ToolMode == "hand";

        public bool IsSelectToolActive => ToolMode == "select";

        public bool IsHighlightToolActive => ToolMode == "highlight";

        public event Action<string, int, IReadOnlyList<HighlightRect>>? HighlightCreated;

        public event Action<string>? ScriptRequested;

        public void LoadDocument(DocumentItem document)
        {
            _activeDocument = document;

            if (!File.Exists(document.FilePath))
            {
                DocumentPath = document.FilePath;
                StatusText = "File not found";
                EmptyTitle = document.Title;
                EmptyMessage = "The selected PDF file does not exist.";
                HasDocumentLoaded = false;
                return;
            }

            DocumentPath = document.FilePath;
            CurrentPage = Math.Max(1, document.LastReadPage);
            ZoomPercent = ClampZoomPercent(document.LastZoomPercent);

            PdfServer.Start();

            var documentKey = string.IsNullOrWhiteSpace(document.Id)
                ? Path.GetFileNameWithoutExtension(document.FilePath)
                : document.Id;

            string viewerUrl = PdfServer.RegisterPdf(
                documentKey,
                document.FilePath,
                CurrentPage,
                ZoomPercent,
                DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            );

            ViewerSource = new Uri(viewerUrl);

            StatusText = "Document loaded";
            EmptyTitle = document.Title;
            EmptyMessage = string.Empty;
            HasDocumentLoaded = true;
        }

        public void UpdateReadingStateFromViewer(int pageNumber, int zoomPercent)
        {
            CurrentPage = Math.Max(1, pageNumber);
            ZoomPercent = ClampZoomPercent(zoomPercent);

            if (_activeDocument is not null &&
                (_activeDocument.LastReadPage != CurrentPage ||
                 _activeDocument.LastZoomPercent != ZoomPercent))
            {
                _activeDocument.LastReadPage = CurrentPage;
                _activeDocument.LastZoomPercent = ZoomPercent;
                _persistReadingState(_activeDocument);
            }

            StatusText = $"Page {CurrentPage}";
        }

        public void SetHandTool()
        {
            ToolMode = "hand";
        }

        public void SetSelectTool()
        {
            ToolMode = "select";
        }

        public void SetHighlightTool()
        {
            ToolMode = "highlight";
        }

        public void AddHighlightFromViewer(
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            HighlightCreated?.Invoke(text, pageNumber, rects);
        }

        public void LoadHighlightsIntoViewer(IReadOnlyList<HighlightItem> highlights)
        {
            _currentHighlights = highlights;
            SendHighlightsToViewer();
        }

        public void SendHighlightsToViewer()
        {
            var json = JsonSerializer.Serialize(_currentHighlights);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.setHighlights?.({json});");
        }

        public void NavigateToHighlight(HighlightItem highlight)
        {
            if (string.IsNullOrWhiteSpace(highlight.Id))
            {
                return;
            }

            var idJson = JsonSerializer.Serialize(highlight.Id);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.goToHighlight?.({idJson});");
        }

        private static int ClampZoomPercent(int zoomPercent)
        {
            return Math.Clamp(zoomPercent <= 0 ? 120 : zoomPercent, 50, 400);
        }
    }
}

````

## MiniZotero/ViewModels/SidebarViewModel.cs

``csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public sealed partial class SidebarNavigationItem : ObservableObject
    {
        public SidebarNavigationItem(
            string name,
            string icon,
            string? countText = null)
        {
            Name = name;
            Icon = icon;
            CountText = countText;
        }

        public string Name { get; }

        public string Icon { get; }

        [ObservableProperty]
        private string? _countText;
    }

    public sealed partial class SmartCollectionItem : ObservableObject
    {
        public SmartCollectionItem(
            string name,
            string kind,
            string icon,
            string iconColor,
            int count = 0)
        {
            Name = name;
            Kind = kind;
            Icon = icon;
            IconColor = iconColor;
            Count = count;
        }

        public string Name { get; }

        public string Kind { get; }

        public string Icon { get; }

        public string IconColor { get; }

        [ObservableProperty]
        private int _count;

    }

    public sealed partial class TagItem : ObservableObject
    {
        public TagItem(string name, string? countText = null)
        {
            Name = name;
            CountText = countText;
        }

        public string Name { get; }

        [ObservableProperty]
        private string? _countText;
    }

    public sealed class DocumentExplorerItem
    {
        private DocumentExplorerItem(
            string name,
            string icon,
            bool isFolder,
            DocumentItem? document,
            int count = 0,
            bool isExpanded = false)
        {
            Name = name;
            Icon = icon;
            IsFolder = isFolder;
            Document = document;
            Count = count;
            IsExpanded = isExpanded;
        }

        public string Name { get; }

        public string Icon { get; }

        public bool IsFolder { get; }

        public bool IsDocument => Document is not null;

        public DocumentItem? Document { get; }

        public int Count { get; }

        public bool IsExpanded { get; }

        public string ChevronIcon => IsFolder
            ? IsExpanded ? "\uE70D" : "\uE76C"
            : string.Empty;

        public string IconForeground => IsFolder ? "#7DD3FC" : "#52C7FF";

        public int IconFontSize => IsFolder ? 13 : 12;

        public string NameForeground => IsFolder ? "#F2F6FC" : "#E4EBF4";

        public string NameFontWeight => IsFolder ? "SemiBold" : "Normal";

        public bool IsStarred => Document?.IsStarred == true;

        public bool IsStarButtonVisible => IsDocument && Document?.IsDeleted != true;

        public static DocumentExplorerItem Folder(string name, int count, bool isExpanded)
        {
            return new DocumentExplorerItem(name, "\uE8B7", isFolder: true, document: null, count, isExpanded);
        }

        public static DocumentExplorerItem File(DocumentItem document)
        {
            return new DocumentExplorerItem(document.Title, "\uE7C3", isFolder: false, document);
        }
    }

    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly DocumentRepository _documentRepository;
        private readonly AppSettingsRepository _settingsRepository;
        private readonly WatchFolderService _watchFolderService;
        private readonly SidebarNavigationItem _libraryNavigationItem;
        private readonly SidebarNavigationItem _recentNavigationItem;
        private readonly SidebarNavigationItem _starredNavigationItem;
        private readonly SidebarNavigationItem _trashNavigationItem;
        private readonly Dictionary<string, bool> _expandedFolders = new(StringComparer.OrdinalIgnoreCase);
        private bool _isRebuildingTags;

        public SidebarViewModel()
            : this(
                new DocumentRepository(new AppStorageService(), new AutoTagService()),
                new AppSettingsRepository(new AppStorageService()),
                new WatchFolderService())
        {
        }

        public SidebarViewModel(
            DocumentRepository documentRepository,
            AppSettingsRepository settingsRepository,
            WatchFolderService watchFolderService)
        {
            _documentRepository = documentRepository;
            _settingsRepository = settingsRepository;
            _watchFolderService = watchFolderService;
            _watchFolderService.PdfDetected += OnWatchFolderPdfDetected;

            _libraryNavigationItem = new SidebarNavigationItem("Library", "\uE8B7", "0");
            _recentNavigationItem = new SidebarNavigationItem("Recent", "\uE823", "0");
            _starredNavigationItem = new SidebarNavigationItem("Starred", "\uE734", "0");
            _trashNavigationItem = new SidebarNavigationItem("Trash", "\uE74D", "0");

            NavigationItems.Add(_libraryNavigationItem);
            NavigationItems.Add(_recentNavigationItem);
            NavigationItems.Add(_starredNavigationItem);
            NavigationItems.Add(_trashNavigationItem);
            SelectedNavigationItem = _libraryNavigationItem;
            SmartCollections.Clear();
            SmartCollections.Add(new SmartCollectionItem("Đang đọc dở", "reading", "\uE7C1", "#8DD6A5"));
            SmartCollections.Add(new SmartCollectionItem("Mới thêm", "new", "\uE8A5", "#9CCBFF"));
            SmartCollections.Add(new SmartCollectionItem("Đã mở gần đây", "recent", "\uE823", "#D9C7FF"));
            SmartCollections.Add(new SmartCollectionItem("Chưa đọc", "unread", "\uE7BE", "#FBBF24"));
            SelectedSmartCollection = null;
            SelectedNavigationItem = _libraryNavigationItem;

            var settings = _settingsRepository.LoadSettings();
            WatchFolderPath = settings.WatchFolderPath;

            if (!string.IsNullOrWhiteSpace(WatchFolderPath))
            {
                _watchFolderService.Start(WatchFolderPath);
            }

            foreach (var document in _documentRepository.LoadDocuments())
            {
                Documents.Add(document);
            }

            RebuildTags();
            ApplyDocumentFilter();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasSelectedDocument))]
        [NotifyPropertyChangedFor(nameof(IsMoveToTrashVisible))]
        [NotifyPropertyChangedFor(nameof(IsTrashDocumentActionsVisible))]
        [NotifyPropertyChangedFor(nameof(IsTagEditorVisible))]
        private DocumentItem? _selectedDocument;

        [ObservableProperty]
        private DocumentExplorerItem? _selectedExplorerItem;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private string _newTagText = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsWatchFolderConfigured))]
        [NotifyPropertyChangedFor(nameof(WatchFolderStatusText))]
        private string? _watchFolderPath;

        [ObservableProperty]
        private SidebarNavigationItem? _selectedNavigationItem;

        [ObservableProperty]
        private SmartCollectionItem? _selectedSmartCollection;

        [ObservableProperty]
        private TagItem? _selectedTag;

        public ObservableCollection<SidebarNavigationItem> NavigationItems { get; } = new();

        public ObservableCollection<SmartCollectionItem> SmartCollections { get; } = new();

        public ObservableCollection<TagItem> Tags { get; } = new();

        public ObservableCollection<DocumentItem> Documents { get; } = new();

        public ObservableCollection<DocumentItem> FilteredDocuments { get; } = new();

        public ObservableCollection<DocumentItem> SearchResultDocuments { get; } = new();

        public ObservableCollection<DocumentExplorerItem> DocumentExplorerItems { get; } = new();

        public int DocumentCount => FilteredDocuments.Count;

        public bool HasDocuments => Documents.Count > 0;

        public bool HasVisibleDocuments => FilteredDocuments.Count > 0;

        public bool HasSelectedDocument => SelectedDocument is not null;

        public bool IsEmptyViewVisible => Documents.Count == 0;

        public bool IsTrashSelected => SelectedNavigationItem?.Name == "Trash";

        public bool IsMoveToTrashVisible =>
            HasSelectedDocument && !IsTrashSelected && SelectedDocument?.IsDeleted != true;

        public bool IsTrashDocumentActionsVisible =>
            HasSelectedDocument && IsTrashSelected && SelectedDocument?.IsDeleted == true;

        public bool IsTagEditorVisible =>
            HasSelectedDocument && !IsTrashSelected && SelectedDocument?.IsDeleted != true;

        public bool HasSearchText => !string.IsNullOrWhiteSpace(SearchText);

        public bool HasSearchResults => HasSearchText && SearchResultDocuments.Count > 0;

        public bool IsSearchDropdownVisible => HasSearchText;

        public bool IsNoSearchResultVisible =>
            HasSearchText && SearchResultDocuments.Count == 0;

        public string CurrentDocumentSectionTitle =>
            SelectedSmartCollection is not null
                ? SelectedSmartCollection.Name.ToUpperInvariant()
                : SelectedNavigationItem?.Name switch
                {
                    "Recent" => "RECENT DOCUMENTS",
                    "Starred" => "STARRED",
                    "Trash" => "TRASH",
                    _ => "DOCUMENTS"
                };

        public bool IsWatchFolderConfigured => !string.IsNullOrWhiteSpace(WatchFolderPath);

        public string WatchFolderStatusText =>
            IsWatchFolderConfigured
                ? $"Đang theo dõi: {Path.GetFileName(WatchFolderPath)}"
                : "Not configured";

        public void AddDocument(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            var document = _documentRepository.ImportDocument(filePath, Documents);
            if (!Documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                Documents.Add(document);
            }
            else if (document.IsDeleted)
            {
                document.IsDeleted = false;
                document.DeletedAt = null;
            }

            _documentRepository.SaveDocuments(Documents);
            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();

            SelectedDocument = document;
        }

        public void SetWatchFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return;
            }

            WatchFolderPath = folderPath;

            _settingsRepository.SaveSettings(new AppSettings
            {
                WatchFolderPath = folderPath
            });

            _watchFolderService.Start(folderPath);
        }

        partial void OnSearchTextChanged(string value)
        {
            ApplySearchFilter();
        }

        partial void OnSelectedTagChanged(TagItem? value)
        {
            if (!_isRebuildingTags)
            {
                ApplyDocumentFilter();
            }
        }

        partial void OnSelectedSmartCollectionChanged(SmartCollectionItem? value)
        {
            if (value is not null)
            {
                SelectedNavigationItem = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        partial void OnSelectedDocumentChanged(DocumentItem? value)
        {
            if (value is null)
            {
                OnPropertyChanged(nameof(IsMoveToTrashVisible));
                OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
                OnPropertyChanged(nameof(IsTagEditorVisible));
                return;
            }

            var matchingExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                item.Document?.Id == value.Id);
            if (matchingExplorerItem is not null && SelectedExplorerItem != matchingExplorerItem)
            {
                SelectedExplorerItem = matchingExplorerItem;
            }

            if (HasSearchText)
            {
                SearchText = string.Empty;
            }

            Dispatcher.UIThread.Post(() =>
            {
                if (value.IsDeleted)
                {
                    return;
                }

                value.LastOpenedAt = DateTimeOffset.Now;
                _documentRepository.SaveDocuments(Documents);
                ApplyDocumentFilter();
            });
        }

        partial void OnSelectedExplorerItemChanged(DocumentExplorerItem? value)
        {
            if (value?.Document is { } document && SelectedDocument != document)
            {
                SelectedDocument = document;
                return;
            }

            if (value?.IsFolder == true)
            {
                Dispatcher.UIThread.Post(() =>
                {
                    SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                        item.Document?.Id == SelectedDocument?.Id);
                });
            }
        }

        partial void OnSelectedNavigationItemChanged(SidebarNavigationItem? value)
        {
            if (value is not null)
            {
                SelectedSmartCollection = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        [RelayCommand]
        private void ToggleStar(DocumentItem? document)
        {
            if (document is null || document.IsDeleted)
            {
                return;
            }

            document.IsStarred = !document.IsStarred;

            _documentRepository.SaveDocuments(Documents);
            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        [RelayCommand]
        private void ToggleFolder(DocumentExplorerItem? item)
        {
            if (item?.IsFolder != true)
            {
                return;
            }

            _expandedFolders[item.Name] = !item.IsExpanded;
            ApplyDocumentFilter();
        }

        [RelayCommand]
        private void AddTagToSelectedDocument()
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted)
            {
                return;
            }

            var tag = NewTagText.Trim();
            if (string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            SelectedDocument.Tags ??= [];

            var exists = SelectedDocument.Tags.Any(existingTag =>
                string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

            if (!exists)
            {
                SelectedDocument.Tags.Add(tag);
                _documentRepository.SaveDocuments(Documents);
            }

            NewTagText = string.Empty;

            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        [RelayCommand]
        private void RemoveTagFromSelectedDocument(string? tag)
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted || string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            SelectedDocument.Tags.RemoveAll(existingTag =>
                string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

            _documentRepository.SaveDocuments(Documents);

            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        private void OnWatchFolderPdfDetected(string filePath)
        {
            Dispatcher.UIThread.Post(() =>
            {
                AddDocument(filePath);
            });
        }

        [RelayCommand]
        private void MoveSelectedDocumentToTrash()
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted)
            {
                return;
            }

            SelectedDocument.IsDeleted = true;
            SelectedDocument.DeletedAt = DateTimeOffset.Now;

            _documentRepository.SaveDocuments(Documents);

            SelectedDocument = null;
            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        [RelayCommand]
        private void RestoreSelectedDocument()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            SelectedDocument.IsDeleted = false;
            SelectedDocument.DeletedAt = null;

            _documentRepository.SaveDocuments(Documents);

            SelectedDocument = null;
            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        [RelayCommand]
        private void DeleteSelectedDocumentForever()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            var document = SelectedDocument;
            SelectedDocument = null;

            _documentRepository.DeleteStoredPdfFile(document);
            Documents.Remove(document);
            _documentRepository.SaveDocuments(Documents);

            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        private void ApplyDocumentFilter()
        {
            FilteredDocuments.Clear();
            DocumentExplorerItems.Clear();

            var documents = ApplySmartCollectionFilter(GetNavigationDocuments());

            if (SelectedTag is not null)
            {
                documents = documents.Where(document =>
                    document.Tags.Any(tag =>
                        string.Equals(tag, SelectedTag.Name, StringComparison.OrdinalIgnoreCase)));
            }

            var filteredDocuments = documents.ToList();

            if (SelectedDocument is not null &&
                filteredDocuments.All(document => document.Id != SelectedDocument.Id))
            {
                SelectedDocument = null;
            }

            foreach (var document in filteredDocuments)
            {
                FilteredDocuments.Add(document);
            }

            BuildDocumentExplorerItems(filteredDocuments);

            NotifyDocumentStateChanged();
        }

        private void RebuildTags()
        {
            var selectedTagName = SelectedTag?.Name;

            _isRebuildingTags = true;

            try
            {
                Tags.Clear();

                var tagGroups = Documents
                    .Where(document => !document.IsDeleted)
                    .SelectMany(document => document.Tags)
                    .Where(tag => !string.IsNullOrWhiteSpace(tag))
                    .GroupBy(tag => tag.Trim(), StringComparer.OrdinalIgnoreCase)
                    .OrderBy(group => group.Key);

                foreach (var group in tagGroups)
                {
                    Tags.Add(new TagItem(group.Key, group.Count().ToString()));
                }

                SelectedTag = !string.IsNullOrWhiteSpace(selectedTagName)
                    ? Tags.FirstOrDefault(tag =>
                        string.Equals(tag.Name, selectedTagName, StringComparison.OrdinalIgnoreCase))
                    : null;
            }
            finally
            {
                _isRebuildingTags = false;
            }
        }

        private void BuildDocumentExplorerItems(IReadOnlyList<DocumentItem> documents)
        {
            var groups = documents
                .GroupBy(GetDocumentFolderName)
                .OrderBy(group => group.Key);

            foreach (var group in groups)
            {
                var isExpanded = IsFolderExpanded(group.Key);
                DocumentExplorerItems.Add(DocumentExplorerItem.Folder(group.Key, group.Count(), isExpanded));

                if (!isExpanded)
                {
                    continue;
                }

                foreach (var document in group)
                {
                    DocumentExplorerItems.Add(DocumentExplorerItem.File(document));
                }
            }

            SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                item.Document?.Id == SelectedDocument?.Id);
        }

        private bool IsFolderExpanded(string folderName)
        {
            if (!_expandedFolders.TryGetValue(folderName, out var isExpanded))
            {
                _expandedFolders[folderName] = false;
                return false;
            }

            return isExpanded;
        }

        private static string GetDocumentFolderName(DocumentItem document)
        {
            var path = !string.IsNullOrWhiteSpace(document.OriginalFilePath)
                ? document.OriginalFilePath
                : document.FilePath;

            var folderPath = Path.GetDirectoryName(path);
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                return "Documents";
            }

            return Path.GetFileName(folderPath) is { Length: > 0 } folderName
                ? folderName
                : folderPath;
        }

        private void ApplySearchFilter()
        {
            SearchResultDocuments.Clear();

            var query = SearchText?.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                NotifyDocumentStateChanged();
                return;
            }

            var documents = ApplySmartCollectionFilter(GetNavigationDocuments())
                .Where(document => MatchesSearch(document, query))
                .OrderBy(document => document.Title);

            foreach (var document in documents)
            {
                SearchResultDocuments.Add(document);
            }

            NotifyDocumentStateChanged();
        }

        private static bool MatchesSearch(DocumentItem document, string keyword)
        {
            return Contains(document.Title, keyword) ||
                   Contains(document.FilePath, keyword) ||
                   Contains(document.OriginalFilePath, keyword) ||
                   document.Tags.Any(tag => Contains(tag, keyword));
        }

        private static bool Contains(string? value, string keyword)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }

        private IEnumerable<DocumentItem> GetNavigationDocuments()
        {
            var documents = Documents.AsEnumerable();

            return SelectedNavigationItem?.Name switch
            {
                "Recent" => documents
                    .Where(document => !document.IsDeleted && document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "Starred" => documents
                    .Where(document => !document.IsDeleted && document.IsStarred)
                    .OrderBy(document => document.Title),

                "Trash" => documents
                    .Where(document => document.IsDeleted)
                    .OrderByDescending(document => document.DeletedAt),

                _ => documents
                    .Where(document => !document.IsDeleted)
                    .OrderBy(document => document.Title)
            };
        }

        private IEnumerable<DocumentItem> ApplySmartCollectionFilter(IEnumerable<DocumentItem> documents)
        {
            return SelectedSmartCollection?.Kind switch
            {
                "reading" => documents.Where(document => document.LastReadPage > 1),

                "new" => documents.Where(document =>
                    document.AddedAt >= DateTimeOffset.Now.AddDays(-7)),

                "recent" => documents
                    .Where(document => document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "unread" => documents.Where(document => document.LastOpenedAt is null),

                _ => documents
            };
        }

        private void NotifyDocumentStateChanged()
        {
            RefreshSmartCollectionCounts();

            _libraryNavigationItem.CountText = Documents.Count(document => !document.IsDeleted).ToString();
            _recentNavigationItem.CountText = Documents.Count(document => !document.IsDeleted && document.LastOpenedAt is not null).ToString();
            _starredNavigationItem.CountText = Documents.Count(document => !document.IsDeleted && document.IsStarred).ToString();
            _trashNavigationItem.CountText = Documents.Count(document => document.IsDeleted).ToString();

            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(HasVisibleDocuments));
            OnPropertyChanged(nameof(HasSelectedDocument));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
            OnPropertyChanged(nameof(HasSearchText));
            OnPropertyChanged(nameof(HasSearchResults));
            OnPropertyChanged(nameof(IsSearchDropdownVisible));
            OnPropertyChanged(nameof(IsNoSearchResultVisible));
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        private void RefreshSmartCollectionCounts()
        {
            var newDocumentThreshold = DateTimeOffset.Now.AddDays(-7);

            foreach (var collection in SmartCollections)
            {
                collection.Count = collection.Kind switch
                {
                    "reading" => Documents.Count(document =>
                        !document.IsDeleted && document.LastReadPage > 1),

                    "new" => Documents.Count(document =>
                        !document.IsDeleted && document.AddedAt >= newDocumentThreshold),

                    "recent" => Documents.Count(document =>
                        !document.IsDeleted && document.LastOpenedAt is not null),

                    "unread" => Documents.Count(document =>
                        !document.IsDeleted && document.LastOpenedAt is null),

                    _ => 0
                };
            }
        }
    }
}

````

## MiniZotero/ViewModels/TabWorkspaceViewModel.cs

``csharp
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class TabWorkspaceViewModel : ViewModelBase
    {
        public TabWorkspaceViewModel()
            : this(_ => { })
        {
        }

        public TabWorkspaceViewModel(Action<DocumentItem> persistReadingState)
        {
            PdfViewer = new PdfViewerViewModel(persistReadingState);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        public PdfViewerViewModel PdfViewer { get; }

        public bool IsEmptyViewVisible => ActiveDocument is null;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            PdfViewer.LoadDocument(document);
        }
    }
}

````

## MiniZotero/ViewModels/ViewModelBase.cs

``csharp
using CommunityToolkit.Mvvm.ComponentModel;

namespace MiniZotero.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
    }
}

````

## MiniZotero/Views/MainWindow.axaml

``xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:models="using:MiniZotero.Models"
        xmlns:views="using:MiniZotero.Views"
        xmlns:vm="using:MiniZotero.ViewModels"
        mc:Ignorable="d"
        d:DesignWidth="1280"
        d:DesignHeight="820"
        Width="1280"
        Height="820"
        MinWidth="1120"
        MinHeight="720"
        x:Class="MiniZotero.Views.MainWindow"
        x:DataType="vm:MainWindowViewModel"
        Title="MiniZotero"
        Background="#0B1118"
        Foreground="#E7EDF6"
        FontFamily="Segoe UI">

    <Window.Styles>
        <Style Selector="Button">
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Padding" Value="8,4"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Foreground" Value="#D8E1EC"/>
        </Style>
        <Style Selector="Button:pointerover">
            <Setter Property="Background" Value="#243042"/>
        </Style>
        <Style Selector="Button.IconButton">
            <Setter Property="Width" Value="30"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#AAB6C6"/>
        </Style>
        <Style Selector="TextBlock.Muted">
            <Setter Property="Foreground" Value="#8D9AAB"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,0,4"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#263242"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
    </Window.Styles>

    <Grid RowDefinitions="48,*,30" ColumnDefinitions="224,*,492">
        <views:SidebarView Grid.Row="0"
                           Grid.RowSpan="3"
                           Grid.Column="0"
                           DataContext="{Binding Sidebar}"/>

        <Border Grid.Row="0"
                Grid.Column="1"
                Grid.ColumnSpan="2"
                Background="#101720"
                BorderBrush="#202B38"
                BorderThickness="0,0,0,1">
            <Grid ColumnDefinitions="Auto,*,Auto" Margin="10,0">
                <StackPanel Orientation="Horizontal" Spacing="8" VerticalAlignment="Center">
                    <Button Classes="IconButton" Content="&#xE710;" Click="OnImportPdfClicked"/>

                    <Border Background="#F7F9FC"
                            BorderBrush="#CAD3DF"
                            BorderThickness="1"
                            CornerRadius="8,8,0,0"
                            MinWidth="210"
                            Height="35"
                            Padding="10,0">
                        <Grid ColumnDefinitions="Auto,*,Auto">
                            <Border Width="16" Height="18" CornerRadius="3" Background="#EF4444" VerticalAlignment="Center">
                                <TextBlock Text="PDF"
                                           Foreground="White"
                                           FontSize="7"
                                           FontWeight="Bold"
                                           HorizontalAlignment="Center"
                                           VerticalAlignment="Center"/>
                            </Border>
                            <TextBlock Grid.Column="1"
                                       Text="{Binding Workspace.ActiveDocument.Title, FallbackValue=No document open}"
                                       Foreground="#172033"
                                       FontSize="12"
                                       FontWeight="SemiBold"
                                       Margin="8,0"
                                       VerticalAlignment="Center"
                                       TextTrimming="CharacterEllipsis"/>
                            <Button Grid.Column="2"
                                    Content="&#xE711;"
                                    FontFamily="Segoe MDL2 Assets"
                                    Foreground="#667386"
                                    Width="24"
                                    Height="24"
                                    Padding="0"/>
                        </Grid>
                    </Border>
                </StackPanel>

                <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                    <Border Background="#172230" CornerRadius="7" Height="30" Width="48">
                        <Grid ColumnDefinitions="*,Auto" Margin="8,0">
                            <TextBlock Text="&#xE7F4;" FontFamily="Segoe MDL2 Assets" Foreground="#AEB9C8" VerticalAlignment="Center"/>
                            <TextBlock Grid.Column="1" Text="&#xE70D;" FontFamily="Segoe MDL2 Assets" Foreground="#8795A8" FontSize="9" VerticalAlignment="Center"/>
                        </Grid>
                    </Border>

                    <Border Background="#172230" CornerRadius="7" Height="30" Width="260" Padding="10,0">
                        <Grid ColumnDefinitions="Auto,*">
                            <TextBlock Text="&#xE721;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13" VerticalAlignment="Center"/>
                            <TextBox Grid.Column="1"
                                     Text="{Binding Sidebar.SearchText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                     PlaceholderText="Search documents."
                                     Background="Transparent"
                                     BorderThickness="0"
                                     Foreground="#D8E1EC"
                                     FontSize="12"
                                     Margin="8,-3,0,0"
                                     Padding="0"
                                     VerticalAlignment="Center"
                                     VerticalContentAlignment="Center"/>
                        </Grid>
                    </Border>

                    <Button Classes="IconButton" Content="&#xE72D;"/>
                    <Button Classes="IconButton" Content="&#xE712;"/>
                    <Button Classes="IconButton" Content="&#xE713;"/>
                </StackPanel>
            </Grid>
        </Border>

        <views:TabWorkspaceView Grid.Row="1"
                                Grid.Column="1"
                                DataContext="{Binding Workspace}"/>

        <views:NotePreviewPanelView Grid.Row="1"
                                    Grid.Column="2"
                                    DataContext="{Binding Notes}"/>

        <Border Grid.Row="1"
                Grid.Column="2"
                Width="360"
                MaxHeight="320"
                Margin="54,8,0,0"
                HorizontalAlignment="Left"
                VerticalAlignment="Top"
                Background="#101720"
                BorderBrush="#263242"
                BorderThickness="1"
                CornerRadius="8"
                Padding="10"
                IsVisible="{Binding Sidebar.IsSearchDropdownVisible}">
            <Grid RowDefinitions="Auto,*">
                <Grid ColumnDefinitions="*,Auto" Margin="2,0,2,8">
                    <TextBlock Text="Search results"
                               Foreground="#E7EDF6"
                               FontSize="12"
                               FontWeight="SemiBold"/>
                    <TextBlock Grid.Column="1"
                               Text="{Binding Sidebar.SearchResultDocuments.Count}"
                               Foreground="#8D9AAB"
                               FontSize="11"/>
                </Grid>

                <Border Grid.Row="1"
                        Background="#1E293B"
                        CornerRadius="8"
                        Padding="12"
                        IsVisible="{Binding Sidebar.IsNoSearchResultVisible}">
                    <TextBlock Text="No matching documents."
                               Foreground="#94A3B8"
                               FontSize="12"
                               TextWrapping="Wrap"/>
                </Border>

                <ScrollViewer Grid.Row="1"
                              MaxHeight="260"
                              IsVisible="{Binding Sidebar.HasSearchResults}">
                    <ListBox Classes="SearchResultsList"
                             ItemsSource="{Binding Sidebar.SearchResultDocuments}"
                             SelectedItem="{Binding Sidebar.SelectedDocument, Mode=TwoWay}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="models:DocumentItem">
                                <Border Padding="9,7">
                                    <StackPanel Spacing="3">
                                        <TextBlock Text="{Binding Title}"
                                                   Foreground="#F2F6FC"
                                                   FontWeight="SemiBold"
                                                   FontSize="12"
                                                   TextTrimming="CharacterEllipsis"/>
                                        <TextBlock Text="{Binding FilePath}"
                                                   Foreground="#8D9AAB"
                                                   FontSize="10"
                                                   TextTrimming="CharacterEllipsis"/>
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </ScrollViewer>
            </Grid>
        </Border>

        <Border Grid.Row="2"
                Grid.Column="1"
                Grid.ColumnSpan="2"
                Background="#0B1118"
                BorderBrush="#202B38"
                BorderThickness="0,1,0,0">
            <Grid ColumnDefinitions="*,Auto,Auto,Auto" Margin="16,0">
                <TextBlock Text="Ready"
                           Classes="Muted"
                           FontSize="11"
                           VerticalAlignment="Center"/>
                <TextBlock Grid.Column="1"
                           Text="Documents open"
                           Classes="Muted"
                           FontSize="11"
                           VerticalAlignment="Center"
                           Margin="0,0,22,0"/>
                <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center" Margin="0,0,22,0">
                    <TextBlock Text="Last sync:"
                               Classes="Muted"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                    <TextBlock Text="Not configured"
                               Foreground="#AAB6C6"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                    <Ellipse Width="8" Height="8" Stroke="#22C55E" StrokeThickness="1.5"/>
                </StackPanel>
                <StackPanel Grid.Column="3" Orientation="Horizontal" Spacing="8" VerticalAlignment="Center">
                    <TextBlock Text="&#xE713;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13"/>
                    <TextBlock Text="&#xE897;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13"/>
                    <TextBlock Text="&#xE710;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13"/>
                </StackPanel>
            </Grid>
        </Border>
    </Grid>
</Window>

````

## MiniZotero/Views/MainWindow.axaml.cs

``csharp
using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnImportPdfClicked(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not MainWindowViewModel viewModel)
            {
                return;
            }

            var pdfFiles = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Import PDF",
                AllowMultiple = true,
                FileTypeFilter =
                [
                    new FilePickerFileType("PDF documents")
                    {
                        Patterns = ["*.pdf"],
                        MimeTypes = ["application/pdf"]
                    }
                ]
            });

            foreach (var file in pdfFiles.Where(file => file.Path.IsFile))
            {
                viewModel.Sidebar.AddDocument(Uri.UnescapeDataString(file.Path.LocalPath));
            }
        }
    }
}

````

## MiniZotero/Views/NotePreviewPanelView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:models="using:MiniZotero.Models"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.NotePreviewPanelView"
             x:Name="Root"
             x:DataType="vm:NotePreviewPanelViewModel">

    <UserControl.Styles>
        <Style Selector="Border.PanelCard">
            <Setter Property="Background" Value="#FFFFFF"/>
            <Setter Property="BorderBrush" Value="#D5DDE7"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="8"/>
        </Style>
        <Style Selector="Button.PanelIconButton">
            <Setter Property="Width" Value="28"/>
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#64748B"/>
        </Style>
        <Style Selector="Button.PanelIconButton:pointerover">
            <Setter Property="Background" Value="#F1F5F9"/>
        </Style>
        <Style Selector="Button.ExportButton">
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="10,0"/>
            <Setter Property="Background" Value="#F8FAFC"/>
            <Setter Property="BorderBrush" Value="#D5DDE7"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Foreground" Value="#334155"/>
            <Setter Property="FontSize" Value="12"/>
        </Style>
        <Style Selector="Button.ExportButton:pointerover">
            <Setter Property="Background" Value="#F1F5F9"/>
        </Style>
        <Style Selector="Button.FormatButton">
            <Setter Property="Width" Value="27"/>
            <Setter Property="Height" Value="27"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="5"/>
            <Setter Property="Foreground" Value="#64748B"/>
            <Setter Property="FontSize" Value="12"/>
        </Style>
        <Style Selector="Button.FormatButton:pointerover">
            <Setter Property="Background" Value="#F1F5F9"/>
        </Style>
    </UserControl.Styles>

    <Grid Background="#E6EBF2" RowDefinitions="280,6,*">
        <Border Grid.Row="0" Classes="PanelCard" Margin="8,8,8,0">
            <Grid RowDefinitions="42,34,*">
                <Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto" Margin="14,0">
                    <TextBlock Text="&#xE734;"
                               FontFamily="Segoe MDL2 Assets"
                               Foreground="#64748B"
                               FontSize="14"
                               VerticalAlignment="Center"/>
                    <TextBlock Grid.Column="1"
                               Text="Note taking"
                               Foreground="#111827"
                               FontWeight="SemiBold"
                               Margin="9,0,0,0"
                               VerticalAlignment="Center"/>
                    <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="4" VerticalAlignment="Center">
                        <Border Background="#F8FAFC"
                                BorderBrush="#D5DDE7"
                                BorderThickness="1"
                                CornerRadius="6"
                                Height="28"
                                Padding="9,0">
                            <TextBlock Text="100%" Foreground="#334155" FontSize="12" VerticalAlignment="Center"/>
                        </Border>
                        <Button Classes="PanelIconButton" Content="&#xE738;"/>
                        <Button Classes="PanelIconButton" Content="&#xE710;"/>
                        <Button Classes="PanelIconButton" Content="&#xE8A7;"/>
                        <Button Classes="ExportButton"
                                Content="Export"
                                Click="OnExportMarkdownClicked"
                                IsVisible="{Binding HasDocument}"/>
                        <Button Classes="PanelIconButton" Content="&#xE713;"/>
                    </StackPanel>
                </Grid>

                <Border Grid.Row="1"
                        BorderBrush="#E5EAF0"
                        BorderThickness="0,1,0,1"
                        Padding="12,0">
                    <StackPanel Orientation="Horizontal" Spacing="2" VerticalAlignment="Center">
                        <Button Classes="FormatButton" Content="H"/>
                        <Button Classes="FormatButton" Content="B" FontWeight="Bold"/>
                        <Button Classes="FormatButton" Content="I" FontStyle="Italic"/>
                        <Button Classes="FormatButton" Content="&#xE943;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8FD;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8FD;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE9D5;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8B0;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE7C3;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8A5;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE80A;" FontFamily="Segoe MDL2 Assets"/>
                    </StackPanel>
                </Border>

                <Grid Grid.Row="2">
                    <TextBox Text="{Binding NoteText, Mode=TwoWay}"
                             AcceptsReturn="True"
                             TextWrapping="Wrap"
                             Background="White"
                             Foreground="#111827"
                             BorderThickness="0"
                             Padding="16"
                             FontSize="13"
                             PlaceholderText="Ghi chú nhanh bằng Markdown..."
                             IsVisible="{Binding HasDocument}"/>

                    <StackPanel IsVisible="{Binding IsEmptyViewVisible}"
                                HorizontalAlignment="Center"
                                VerticalAlignment="Center"
                                Spacing="8"
                                Width="280">
                        <TextBlock Text="No note selected"
                                   Foreground="#111827"
                                   FontSize="16"
                                   FontWeight="SemiBold"
                                   HorizontalAlignment="Center"/>
                        <TextBlock Text="Select a document to create notes."
                                   Foreground="#7C8A9E"
                                   FontSize="13"
                                   TextAlignment="Center"/>
                    </StackPanel>
                </Grid>
            </Grid>
        </Border>

        <Border Grid.Row="1"
                Width="30"
                Height="14"
                CornerRadius="4"
                Background="#FFFFFF"
                BorderBrush="#D5DDE7"
                BorderThickness="1"
                HorizontalAlignment="Center"
                VerticalAlignment="Center">
            <TextBlock Text="::::"
                       Foreground="#64748B"
                       FontSize="11"
                       HorizontalAlignment="Center"
                       VerticalAlignment="Center"
                       Margin="0,-2,0,0"/>
        </Border>

        <Border Grid.Row="2" Classes="PanelCard" Margin="8,0,8,8">
            <Grid RowDefinitions="42,*">
                <Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto" Margin="14,0">
                    <TextBlock Text="&#xE8A5;"
                               FontFamily="Segoe MDL2 Assets"
                               Foreground="#64748B"
                               FontSize="14"
                               VerticalAlignment="Center"/>
                    <TextBlock Grid.Column="1"
                               Text="Preview"
                               Foreground="#111827"
                               FontWeight="SemiBold"
                               FontSize="12"
                               Margin="9,0,0,0"
                               VerticalAlignment="Center"/>
                    <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="4" VerticalAlignment="Center">
                        <Border Background="#F8FAFC"
                                BorderBrush="#D5DDE7"
                                BorderThickness="1"
                                CornerRadius="6"
                                Height="28"
                                Padding="9,0">
                            <TextBlock Text="100%" Foreground="#334155" FontSize="12" VerticalAlignment="Center"/>
                        </Border>
                        <Button Classes="PanelIconButton" Content="&#xE738;"/>
                        <Button Classes="PanelIconButton" Content="&#xE710;"/>
                        <Button Classes="PanelIconButton" Content="&#xE713;"/>
                    </StackPanel>
                </Grid>

                <Border Grid.Row="1"
                        BorderBrush="#E5EAF0"
                        BorderThickness="0,1,0,0"
                        Padding="16">
                    <Grid>
                        <StackPanel IsVisible="{Binding IsEmptyViewVisible}"
                                    HorizontalAlignment="Center"
                                    VerticalAlignment="Center"
                                    Spacing="8"
                                    Width="300">
                            <TextBlock Text="No highlights"
                                       Foreground="#111827"
                                       FontSize="16"
                                       FontWeight="SemiBold"
                                       HorizontalAlignment="Center"/>
                            <TextBlock Text="Highlights will appear here after reading a document."
                                       Foreground="#7C8A9E"
                                       FontSize="13"
                                       TextWrapping="Wrap"
                                       TextAlignment="Center"/>
                        </StackPanel>

                        <StackPanel IsVisible="{Binding IsHighlightEmptyViewVisible}"
                                    HorizontalAlignment="Center"
                                    VerticalAlignment="Center"
                                    Spacing="8"
                                    Width="300">
                            <TextBlock Text="No highlights"
                                       Foreground="#111827"
                                       FontSize="16"
                                       FontWeight="SemiBold"
                                       HorizontalAlignment="Center"/>
                            <TextBlock Text="Highlights will appear here after reading a document."
                                       Foreground="#7C8A9E"
                                       FontSize="13"
                                       TextWrapping="Wrap"
                                       TextAlignment="Center"/>
                        </StackPanel>

                        <ScrollViewer IsVisible="{Binding HasHighlights}">
                            <ItemsControl ItemsSource="{Binding Highlights}">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate x:DataType="models:HighlightItem">
                                        <Border Padding="10"
                                                Margin="0,0,0,8"
                                                CornerRadius="8"
                                                Background="#FFF7CC"
                                                BorderBrush="#EAB308"
                                                BorderThickness="1">
                                            <Grid ColumnDefinitions="*,Auto" RowDefinitions="Auto,Auto">
                                                <Button Grid.Row="0"
                                                        Grid.Column="0"
                                                        Command="{Binding #Root.DataContext.SelectHighlightCommand}"
                                                        CommandParameter="{Binding}"
                                                        Background="Transparent"
                                                        BorderThickness="0"
                                                        Padding="0"
                                                        HorizontalAlignment="Stretch"
                                                        HorizontalContentAlignment="Stretch">
                                                    <TextBlock Text="{Binding Text}"
                                                               TextWrapping="Wrap"
                                                               MaxLines="4"
                                                               FontSize="12"/>
                                                </Button>

                                                <Button Grid.Row="0"
                                                        Grid.Column="1"
                                                        Classes="PanelIconButton"
                                                        Content="&#xE74D;"
                                                        Width="24"
                                                        Height="24"
                                                        Padding="0"
                                                        Margin="8,0,0,0"
                                                        FontSize="12"
                                                        Command="{Binding #Root.DataContext.DeleteHighlightCommand}"
                                                        CommandParameter="{Binding}"/>

                                                <TextBlock Grid.Row="1"
                                                           Grid.Column="0"
                                                           Grid.ColumnSpan="2"
                                                           Text="{Binding PageNumber, StringFormat='Page {0}'}"
                                                           FontSize="11"
                                                           Opacity="0.65"
                                                           Margin="0,6,0,0"/>
                                            </Grid>
                                        </Border>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </ScrollViewer>
                    </Grid>
                </Border>
            </Grid>
        </Border>
    </Grid>
</UserControl>

````

## MiniZotero/Views/NotePreviewPanelView.axaml.cs

``csharp
using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class NotePreviewPanelView : UserControl
    {
        public NotePreviewPanelView()
        {
            InitializeComponent();
        }

        private async void OnExportMarkdownClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);

            if (topLevel is null || DataContext is not NotePreviewPanelViewModel viewModel)
            {
                return;
            }

            var documentTitle = viewModel.ActiveDocument?.Title ?? "MiniZotero Notes";
            var safeFileName = MakeSafeFileName(documentTitle);

            var file = await topLevel.StorageProvider.SaveFilePickerAsync(
                new FilePickerSaveOptions
                {
                    Title = "Export notes and highlights",
                    SuggestedFileName = $"{safeFileName}.md",
                    FileTypeChoices =
                    [
                        new FilePickerFileType("Markdown")
                        {
                            Patterns = ["*.md"],
                            MimeTypes = ["text/markdown", "text/plain"]
                        }
                    ]
                });

            if (file is null)
            {
                return;
            }

            var outputPath = Uri.UnescapeDataString(file.Path.LocalPath);

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return;
            }

            viewModel.ExportActiveDocumentToMarkdown(outputPath);
        }

        private static string MakeSafeFileName(string value)
        {
            var invalidCharacters = System.IO.Path.GetInvalidFileNameChars();

            var safe = new string(value
                .Select(character => invalidCharacters.Contains(character) ? '_' : character)
                .ToArray());

            return string.IsNullOrWhiteSpace(safe)
                ? "MiniZotero Notes"
                : safe.Trim();
        }
    }
}

````

## MiniZotero/Views/PdfViewerView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.PdfViewerView"
             x:DataType="vm:PdfViewerViewModel">

    <Grid Background="#E6EBF2">
        <Border Background="#F8FAFC"
                BorderBrush="#D5DDE7"
                BorderThickness="1"
                CornerRadius="8"
                Margin="20"
                IsVisible="{Binding IsEmptyViewVisible}">
            <StackPanel HorizontalAlignment="Center"
                        VerticalAlignment="Center"
                        Spacing="8"
                        Width="360">
                <TextBlock Text="{Binding EmptyTitle}"
                           Foreground="#172033"
                           FontSize="18"
                           FontWeight="SemiBold"
                           HorizontalAlignment="Center"/>
                <TextBlock Text="{Binding EmptyMessage}"
                           Foreground="#7C8A9E"
                           FontSize="13"
                           TextWrapping="Wrap"
                           TextAlignment="Center"/>
            </StackPanel>
        </Border>

        <Grid IsVisible="{Binding HasDocumentLoaded}" RowDefinitions="*,28">
            <Border Grid.Row="0"
                    Background="#E6EBF2">
                <NativeWebView x:Name="PdfWebView"
                               Source="{Binding ViewerSource}"
                               WebMessageReceived="OnPdfWebViewMessageReceived"/>
            </Border>

            <Border Grid.Row="1"
                    Background="#F8FAFC"
                    BorderBrush="#D5DDE7"
                    BorderThickness="0,1,0,0"
                    Padding="12,0">
                <Grid ColumnDefinitions="Auto,*,Auto">
                    <TextBlock Text="File"
                               Foreground="#94A3B8"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                    <TextBlock Grid.Column="1"
                               Text="{Binding DocumentPath}"
                               Foreground="#64748B"
                               FontSize="11"
                               Margin="8,0"
                               VerticalAlignment="Center"
                               TextTrimming="CharacterEllipsis"/>
                    <TextBlock Grid.Column="2"
                               Text="{Binding StatusText}"
                               Foreground="#64748B"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                </Grid>
            </Border>
        </Grid>
    </Grid>
</UserControl>

````

## MiniZotero/Views/PdfViewerView.axaml.cs

``csharp
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using MiniZotero.Models;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class PdfViewerView : UserControl
    {
        public PdfViewerView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private PdfViewerViewModel? BoundViewModel { get; set; }

        private void OnDataContextChanged(object? sender, System.EventArgs e)
        {
            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged -= OnViewModelPropertyChanged;
                BoundViewModel.ScriptRequested -= OnScriptRequested;
            }

            BoundViewModel = DataContext as PdfViewerViewModel;

            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged += OnViewModelPropertyChanged;
                BoundViewModel.ScriptRequested += OnScriptRequested;
                ApplyToolMode(BoundViewModel.ToolMode);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PdfViewerViewModel.ToolMode) &&
                BoundViewModel is not null)
            {
                ApplyToolMode(BoundViewModel.ToolMode);
            }
        }

        private void OnScriptRequested(string script)
        {
            try
            {
                _ = PdfWebView.InvokeScript(script);
            }
            catch
            {
            }
        }

        private void ApplyToolMode(string toolMode)
        {
            try
            {
                _ = PdfWebView.InvokeScript(
                    $"window.miniZoteroPdf?.setToolMode?.('{toolMode}');"
                );
            }
            catch
            {
            }
        }

        private void OnPdfWebViewMessageReceived(
            object? sender,
            WebMessageReceivedEventArgs e
        )
        {
            if (DataContext is not PdfViewerViewModel viewModel)
            {
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(e.Body))
                {
                    return;
                }

                PdfViewerMessage? message =
                    JsonSerializer.Deserialize<PdfViewerMessage>(
                        e.Body,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                if (message is null)
                {
                    return;
                }

                if (message.Type == "highlightCreated")
                {
                    viewModel.AddHighlightFromViewer(
                        message.Text ?? string.Empty,
                        message.PageNumber,
                        message.Rects ?? []);

                    return;
                }

                viewModel.UpdateReadingStateFromViewer(
                    message.PageNumber,
                    message.ZoomPercent
                );

                if (message.Type == "loaded")
                {
                    ApplyToolMode(viewModel.ToolMode);
                    viewModel.SendHighlightsToViewer();
                }
            }
            catch
            {
            }
        }

        private sealed class PdfViewerMessage
        {
            [JsonPropertyName("type")]
            public string? Type { get; set; }

            [JsonPropertyName("pageNumber")]
            public int PageNumber { get; set; }

            [JsonPropertyName("zoomPercent")]
            public int ZoomPercent { get; set; }

            [JsonPropertyName("text")]
            public string? Text { get; set; }

            [JsonPropertyName("rects")]
            public List<HighlightRect>? Rects { get; set; }
        }
    }
}

````

## MiniZotero/Views/SidebarView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:converters="using:MiniZotero.Converters"
             xmlns:models="using:MiniZotero.Models"
             xmlns:sys="clr-namespace:System;assembly=System.Runtime"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.SidebarView"
             x:Name="Root"
             x:DataType="vm:SidebarViewModel">

    <UserControl.Resources>
        <converters:StarredBrushConverter x:Key="StarredBrushConverter"/>
    </UserControl.Resources>

    <UserControl.Styles>
        <Style Selector="Button.SidebarIconButton">
            <Setter Property="Width" Value="28"/>
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#AAB6C6"/>
        </Style>
        <Style Selector="Button.SidebarIconButton:pointerover">
            <Setter Property="Background" Value="#273242"/>
        </Style>
        <Style Selector="Button.DocumentActionButton">
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="9,0"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="Background" Value="#182231"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="5"/>
            <Setter Property="Foreground" Value="#D7DEE8"/>
            <Setter Property="FontSize" Value="12"/>
        </Style>
        <Style Selector="Button.DocumentActionButton:pointerover">
            <Setter Property="Background" Value="#243246"/>
        </Style>
        <Style Selector="TextBlock.SectionTitle">
            <Setter Property="Foreground" Value="#8795A8"/>
            <Setter Property="FontSize" Value="10"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
        </Style>
        <Style Selector="TextBlock.Muted">
            <Setter Property="Foreground" Value="#8D9AAB"/>
        </Style>
        <Style Selector="Border.NavItem">
            <Setter Property="Height" Value="31"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Padding" Value="10,0"/>
        </Style>
        <Style Selector="Border.NavItem.Active">
            <Setter Property="Background" Value="#263242"/>
        </Style>
        <Style Selector="Border.TagChip">
            <Setter Property="Background" Value="#202B39"/>
            <Setter Property="CornerRadius" Value="5"/>
            <Setter Property="Padding" Value="9,4"/>
            <Setter Property="Margin" Value="0,0,6,6"/>
        </Style>
        <Style Selector="ListBox.NavigationList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,0,4"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#263242"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#263242"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.DocumentList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,0,4"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,6,6"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem /template/ ContentPresenter">
            <Setter Property="Background" Value="#202B39"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#2A3646"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
    </UserControl.Styles>

    <Border Background="#0E151E"
            BorderBrush="#1E2937"
            BorderThickness="0,0,1,0">
        <Grid RowDefinitions="48,*,Auto" Margin="12,0,12,10">
            <Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto">
                <Border Width="22" Height="22" CornerRadius="5" Background="#745CFF" VerticalAlignment="Center">
                    <TextBlock Text="M"
                               Foreground="White"
                               FontSize="13"
                               FontWeight="Bold"
                               HorizontalAlignment="Center"
                               VerticalAlignment="Center"/>
                </Border>
                <TextBlock Grid.Column="1"
                           Text="MiniZotero"
                           Foreground="#F2F6FC"
                           FontWeight="SemiBold"
                           Margin="8,0,0,0"
                           VerticalAlignment="Center"/>
                <Button Grid.Column="2"
                        Classes="SidebarIconButton"
                        Content="&#xE10C;"
                        Click="OnImportPdfClicked"/>
            </Grid>

            <ScrollViewer Grid.Row="1" VerticalScrollBarVisibility="Hidden">
                <StackPanel Spacing="0">
                    <ListBox Classes="NavigationList"
                             ItemsSource="{Binding NavigationItems}"
                             SelectedItem="{Binding SelectedNavigationItem, Mode=TwoWay}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="vm:SidebarNavigationItem">
                                <Grid Height="31" ColumnDefinitions="Auto,*,Auto" Margin="10,0">
                                    <TextBlock Text="{Binding Icon}"
                                               FontFamily="Segoe MDL2 Assets"
                                               Foreground="#B2BECD"
                                               FontSize="14"
                                               VerticalAlignment="Center"/>
                                    <TextBlock Grid.Column="1"
                                               Text="{Binding Name}"
                                               Foreground="#F2F6FC"
                                               FontSize="12"
                                               FontWeight="SemiBold"
                                               Margin="9,0,0,0"
                                               VerticalAlignment="Center"/>
                                    <TextBlock Grid.Column="2"
                                               Text="{Binding CountText}"
                                               Foreground="#B7C2D1"
                                               FontSize="11"
                                               VerticalAlignment="Center"/>
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <Grid ColumnDefinitions="*,Auto" Margin="4,22,4,8">
                        <TextBlock Text="SMART COLLECTIONS" Classes="SectionTitle"/>
                        <TextBlock Grid.Column="1" Text="+" Foreground="#B9C4D3" FontSize="18" Margin="0,-6,0,0"/>
                    </Grid>

                    <ListBox Classes="SmartCollectionList"
                             ItemsSource="{Binding SmartCollections}"
                             SelectedItem="{Binding SelectedSmartCollection, Mode=TwoWay}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="vm:SmartCollectionItem">
                                <Grid Height="25" ColumnDefinitions="Auto,*,Auto" Margin="8,0" VerticalAlignment="Center">
                                    <TextBlock Text="{Binding Icon}"
                                               FontFamily="Segoe MDL2 Assets"
                                               Foreground="{Binding IconColor}"
                                               FontSize="13"
                                               VerticalAlignment="Center"/>
                                    <TextBlock Grid.Column="1"
                                               Text="{Binding Name}"
                                               Foreground="#F2F6FC"
                                               FontSize="12"
                                               Margin="8,0,0,0"
                                               VerticalAlignment="Center"
                                               TextTrimming="CharacterEllipsis"/>
                                    <TextBlock Grid.Column="2"
                                               Text="{Binding Count}"
                                               Foreground="#D9DFF0"
                                               FontSize="11"
                                               VerticalAlignment="Center"/>
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <Grid Height="25" ColumnDefinitions="Auto,*" Margin="17,1,0,0">
                        <TextBlock Text="+" Foreground="#C2CAD8" FontSize="18" VerticalAlignment="Center" Margin="0,-2,0,0"/>
                        <TextBlock Grid.Column="1" Text="New Collection" Foreground="#C2CAD8" FontSize="12" Margin="9,0,0,0" VerticalAlignment="Center"/>
                    </Grid>

                    <Grid IsVisible="{Binding HasDocuments}" RowDefinitions="Auto,*" Margin="0,14,0,0">
                        <Grid ColumnDefinitions="*,Auto" Margin="4,0,4,8">
                            <TextBlock Text="{Binding CurrentDocumentSectionTitle}" Classes="SectionTitle"/>
                            <TextBlock Grid.Column="1" Text="{Binding DocumentCount}" Foreground="#9EABBB" FontSize="11"/>
                        </Grid>

                        <ListBox Grid.Row="1"
                                 Classes="DocumentList"
                                 ItemsSource="{Binding DocumentExplorerItems}"
                                 IsVisible="{Binding HasVisibleDocuments}"
                                 SelectedItem="{Binding SelectedExplorerItem, Mode=TwoWay}">
                            <ListBox.ItemTemplate>
                                <DataTemplate x:DataType="vm:DocumentExplorerItem">
                                    <Border Padding="2,0">
                                        <Grid Height="24" ColumnDefinitions="Auto,Auto,*,Auto">
                                            <Button Classes="SidebarIconButton"
                                                    Content="{Binding ChevronIcon}"
                                                    Width="24"
                                                    Height="24"
                                                    Padding="0"
                                                    Margin="0,1,0,0"
                                                    FontSize="8"
                                                    HorizontalContentAlignment="Center"
                                                    VerticalContentAlignment="Center"
                                                    Command="{Binding #Root.DataContext.ToggleFolderCommand}"
                                                    CommandParameter="{Binding}"
                                                    IsVisible="{Binding IsFolder}"/>
                                            <Border Width="24"
                                                       IsVisible="{Binding IsDocument}"/>

                                            <TextBlock Grid.Column="1"
                                                       Text="{Binding Icon}"
                                                       FontFamily="Segoe MDL2 Assets"
                                                       Foreground="{Binding IconForeground}"
                                                       FontSize="{Binding IconFontSize}"
                                                       Width="20"
                                                       Margin="0,0,5,0"
                                                       VerticalAlignment="Center"/>

                                            <TextBlock Grid.Column="2"
                                                       Text="{Binding Name}"
                                                       Foreground="{Binding NameForeground}"
                                                       FontWeight="{Binding NameFontWeight}"
                                                       FontSize="12"
                                                       VerticalAlignment="Center"
                                                       TextTrimming="CharacterEllipsis"/>

                                            <TextBlock Grid.Column="3"
                                                       Text="{Binding Count}"
                                                       Foreground="#9EABBB"
                                                       FontSize="11"
                                                       Margin="8,0,4,0"
                                                       VerticalAlignment="Center"
                                                       IsVisible="{Binding IsFolder}"/>

                                            <Button Grid.Column="3"
                                                    Classes="SidebarIconButton"
                                                    Content="&#xE734;"
                                                    Width="24"
                                                    Height="24"
                                                    Foreground="{Binding IsStarred, Converter={StaticResource StarredBrushConverter}}"
                                                    Command="{Binding #Root.DataContext.ToggleStarCommand}"
                                                    CommandParameter="{Binding Document}"
                                                    IsVisible="{Binding IsStarButtonVisible}"/>
                                        </Grid>
                                    </Border>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                    </Grid>

                    <StackPanel Spacing="6"
                                Margin="4,10,4,0"
                                IsVisible="{Binding HasSelectedDocument}">
                        <Button Classes="DocumentActionButton"
                                Command="{Binding MoveSelectedDocumentToTrashCommand}"
                                IsVisible="{Binding IsMoveToTrashVisible}">
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <TextBlock Text="&#xE74D;"
                                           FontFamily="Segoe MDL2 Assets"
                                           FontSize="12"
                                           VerticalAlignment="Center"/>
                                <TextBlock Text="Move to Trash"
                                           VerticalAlignment="Center"/>
                            </StackPanel>
                        </Button>

                        <Button Classes="DocumentActionButton"
                                Command="{Binding RestoreSelectedDocumentCommand}"
                                IsVisible="{Binding IsTrashDocumentActionsVisible}">
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <TextBlock Text="&#xE845;"
                                           FontFamily="Segoe MDL2 Assets"
                                           FontSize="12"
                                           VerticalAlignment="Center"/>
                                <TextBlock Text="Restore"
                                           VerticalAlignment="Center"/>
                            </StackPanel>
                        </Button>

                        <Button Classes="DocumentActionButton"
                                Command="{Binding DeleteSelectedDocumentForeverCommand}"
                                IsVisible="{Binding IsTrashDocumentActionsVisible}">
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <TextBlock Text="&#xE107;"
                                           FontFamily="Segoe MDL2 Assets"
                                           FontSize="12"
                                           VerticalAlignment="Center"/>
                                <TextBlock Text="Delete Forever"
                                           VerticalAlignment="Center"/>
                            </StackPanel>
                        </Button>
                    </StackPanel>

                    <Grid ColumnDefinitions="*,Auto" Margin="4,18,4,8">
                        <TextBlock Text="TAGS" Classes="SectionTitle"/>
                        <TextBlock Grid.Column="1" Text="+" Foreground="#B9C4D3" FontSize="18" Margin="0,-6,0,0"/>
                    </Grid>

                    <ListBox Classes="TagList"
                             ItemsSource="{Binding Tags}"
                             SelectedItem="{Binding SelectedTag, Mode=TwoWay}"
                             Margin="4,0,0,0">
                        <ListBox.ItemsPanel>
                            <ItemsPanelTemplate>
                                <WrapPanel/>
                            </ItemsPanelTemplate>
                        </ListBox.ItemsPanel>
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="vm:TagItem">
                                <Border Classes="TagChip">
                                    <StackPanel Orientation="Horizontal" Spacing="7">
                                        <TextBlock Text="{Binding Name}"
                                                   Foreground="#E5ECF5"
                                                   FontSize="11"/>
                                        <TextBlock Text="{Binding CountText}"
                                                   Foreground="#A9B6C7"
                                                   FontSize="11"/>
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <Border Margin="4,12,4,0"
                            Padding="8"
                            CornerRadius="8"
                            Background="#111B27"
                            IsVisible="{Binding IsTagEditorVisible}">
                        <StackPanel Spacing="6">
                            <TextBlock Text="ADD TAG TO SELECTED PDF"
                                       Classes="SectionTitle"/>

                            <Grid ColumnDefinitions="*,Auto">
                                <TextBox Grid.Column="0"
                                         Text="{Binding NewTagText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                         PlaceholderText="e.g. OOP, CMOS, Paper"
                                         Height="30"
                                         FontSize="12"
                                         VerticalContentAlignment="Center"/>

                                <Button Grid.Column="1"
                                        Content="+"
                                        Width="32"
                                        Height="30"
                                        Margin="6,0,0,0"
                                        Command="{Binding AddTagToSelectedDocumentCommand}"/>
                            </Grid>

                            <ItemsControl ItemsSource="{Binding SelectedDocument.Tags}">
                                <ItemsControl.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <WrapPanel/>
                                    </ItemsPanelTemplate>
                                </ItemsControl.ItemsPanel>
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate x:DataType="sys:String">
                                        <Border Classes="TagChip">
                                            <StackPanel Orientation="Horizontal" Spacing="6">
                                                <TextBlock Text="{Binding}"
                                                           Foreground="#E5ECF5"
                                                           FontSize="11"/>
                                                <Button Classes="SidebarIconButton"
                                                        Content="&#xE711;"
                                                        Width="18"
                                                        Height="18"
                                                        FontSize="8"
                                                        Command="{Binding #Root.DataContext.RemoveTagFromSelectedDocumentCommand}"
                                                        CommandParameter="{Binding}"/>
                                            </StackPanel>
                                        </Border>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </StackPanel>
                    </Border>
                </StackPanel>
            </ScrollViewer>

            <StackPanel Grid.Row="2" Spacing="10">
                <Border Background="#1C2633" CornerRadius="7" Padding="10">
                    <Grid RowDefinitions="Auto,Auto" ColumnDefinitions="Auto,*,Auto">
                        <TextBlock Text="&#xE8F1;" FontFamily="Segoe MDL2 Assets" Foreground="#D7DEE8" FontSize="13" VerticalAlignment="Center"/>
                        <StackPanel Grid.Column="1" Orientation="Horizontal" Spacing="4" Margin="8,0,0,0" VerticalAlignment="Center">
                            <TextBlock Text="Watch Folder" Foreground="#E8EDF4" FontSize="12" FontWeight="SemiBold"/>
                            <Ellipse Width="5" Height="5" Fill="#24E38C" VerticalAlignment="Center"/>
                        </StackPanel>
                        <Button Grid.Column="2"
                                Classes="SidebarIconButton"
                                Content="&#xE713;"
                                Click="OnConfigureWatchFolderClicked"/>
                        <TextBlock Grid.Row="1"
                                   Grid.Column="0"
                                   Grid.ColumnSpan="3"
                                   Text="{Binding WatchFolderStatusText}"
                                   Foreground="#9EABBB"
                                   FontSize="11"
                                   Margin="0,9,0,0"/>
                    </Grid>
                </Border>

                <Grid RowDefinitions="4,Auto">
                    <Border Background="#303B4A" CornerRadius="2" Height="4">
                        <Border Background="#8B5CF6" CornerRadius="2" HorizontalAlignment="Left" Width="65"/>
                    </Border>
                    <TextBlock Grid.Row="1" Text="Storage  8.7 GB / 100 GB" Foreground="#8D9AAB" FontSize="10" Margin="0,8,0,0"/>
                </Grid>
            </StackPanel>
        </Grid>
    </Border>
</UserControl>

````

## MiniZotero/Views/SidebarView.axaml.cs

``csharp
using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class SidebarView : UserControl
    {
        public SidebarView()
        {
            InitializeComponent();
        }

        private async void OnImportPdfClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null || DataContext is not SidebarViewModel viewModel)
            {
                return;
            }

            var pdfFiles = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Import PDF",
                AllowMultiple = true,
                FileTypeFilter =
                [
                    new FilePickerFileType("PDF documents")
                    {
                        Patterns = ["*.pdf"],
                        MimeTypes = ["application/pdf"]
                    }
                ]
            });

            foreach (var file in pdfFiles.Where(file => file.Path.IsFile))
            {
                viewModel.AddDocument(Uri.UnescapeDataString(file.Path.LocalPath));
            }
        }

        private async void OnConfigureWatchFolderClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null || DataContext is not SidebarViewModel viewModel)
            {
                return;
            }

            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(
                new FolderPickerOpenOptions
                {
                    Title = "Choose Watch Folder",
                    AllowMultiple = false
                });

            var folder = folders.FirstOrDefault();
            var folderPath = folder is null
                ? string.Empty
                : Uri.UnescapeDataString(folder.Path.LocalPath);

            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                viewModel.SetWatchFolder(folderPath);
            }
        }
    }
}

````

## MiniZotero/Views/TabWorkspaceView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:views="using:MiniZotero.Views"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.TabWorkspaceView"
             x:DataType="vm:TabWorkspaceViewModel">

    <UserControl.Styles>
        <Style Selector="Button.ToolButton">
            <Setter Property="Width" Value="30"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#64748B"/>
        </Style>
        <Style Selector="Button.ToolButton:pointerover">
            <Setter Property="Background" Value="#EEF2F7"/>
        </Style>
        <Style Selector="Button.RailButton">
            <Setter Property="Width" Value="34"/>
            <Setter Property="Height" Value="34"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="7"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#64748B"/>
        </Style>
        <Style Selector="Button.RailButton:pointerover">
            <Setter Property="Background" Value="#EEF2F7"/>
        </Style>
        <Style Selector="Button.RailButton.Active">
            <Setter Property="Background" Value="#FFF7CC"/>
            <Setter Property="Foreground" Value="#B68A00"/>
        </Style>
        <Style Selector="ToggleButton.RailButton">
            <Setter Property="Width" Value="34"/>
            <Setter Property="Height" Value="34"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="7"/>
            <Setter Property="Foreground" Value="#64748B"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:pointerover">
            <Setter Property="Background" Value="#EEF2F7"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:checked">
            <Setter Property="Background" Value="#E8EEF6"/>
            <Setter Property="Foreground" Value="#475569"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:checked:pointerover">
            <Setter Property="Background" Value="#E8EEF6"/>
            <Setter Property="Foreground" Value="#475569"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:checked:pressed">
            <Setter Property="Background" Value="#DDE5EF"/>
            <Setter Property="Foreground" Value="#475569"/>
        </Style>
    </UserControl.Styles>

    <Grid Background="#E6EBF2" RowDefinitions="44,*" ColumnDefinitions="42,*">
        <Border Grid.Row="0"
                Grid.Column="0"
                Grid.ColumnSpan="2"
                Background="#FAFBFD"
                BorderBrush="#D5DDE7"
                BorderThickness="0,0,1,1">
            <Grid ColumnDefinitions="Auto,*,Auto" Margin="8,0">
                <StackPanel Orientation="Horizontal" Spacing="7" VerticalAlignment="Center">
                    <Button Classes="ToolButton" Content="&#xE72B;"/>
                    <TextBlock Text="{Binding PdfViewer.CurrentPage}"
                               Foreground="#172033"
                               FontWeight="SemiBold"
                               FontSize="12"
                               VerticalAlignment="Center"
                               MinWidth="24"
                               TextAlignment="Center"/>
                    <TextBlock Text="/"
                               Foreground="#94A3B8"
                               FontSize="12"
                               VerticalAlignment="Center"/>
                    <TextBlock Text="--"
                               Foreground="#94A3B8"
                               FontSize="12"
                               VerticalAlignment="Center"/>
                    <Button Classes="ToolButton" Content="&#xE72A;"/>

                    <Border Width="1" Height="20" Background="#D5DDE7" Margin="4,0"/>

                    <Button Classes="ToolButton" Content="&#xE710;"/>
                    <Button Classes="ToolButton" Content="&#xE738;"/>
                    <Border Background="#F2F5F9"
                            BorderBrush="#D5DDE7"
                            BorderThickness="1"
                            CornerRadius="6"
                            Height="30"
                            Padding="10,0">
                        <StackPanel Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                            <TextBlock Text="{Binding PdfViewer.ZoomPercent, StringFormat='{}{0}%'}"
                                       Foreground="#334155"
                                       FontSize="12"
                                       VerticalAlignment="Center"/>
                            <TextBlock Text="&#xE70D;" FontFamily="Segoe MDL2 Assets" Foreground="#94A3B8" FontSize="9" VerticalAlignment="Center"/>
                        </StackPanel>
                    </Border>

                    <Border Width="1" Height="20" Background="#D5DDE7" Margin="4,0"/>

                    <Button Classes="ToolButton" Content="&#xE740;"/>
                    <Button Classes="ToolButton" Content="&#xE8A7;"/>
                    <Button Classes="ToolButton" Content="&#xE734;"/>
                </StackPanel>

                <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                    <Button Classes="ToolButton" Content="&#xE8A7;"/>
                    <Button Classes="ToolButton" Content="&#xE8A9;"/>
                    <Button Classes="ToolButton" Content="&#xE713;"/>
                </StackPanel>
            </Grid>
        </Border>

        <Border Grid.Row="1"
                Grid.Column="0"
                Background="#F8FAFC"
                BorderBrush="#D5DDE7"
                BorderThickness="0,0,1,0">
            <StackPanel Margin="4,10" Spacing="8">
                <Button Classes="RailButton" Content="&#xE8A5;"/>
                <ToggleButton Classes="RailButton"
                              Content="&#xE7C9;"
                              FontFamily="Segoe MDL2 Assets"
                              IsChecked="{Binding PdfViewer.IsHandToolActive, Mode=OneWay}"
                              Click="OnHandToolClicked"/>
                <ToggleButton Classes="RailButton"
                              IsChecked="{Binding PdfViewer.IsSelectToolActive, Mode=OneWay}"
                              Click="OnSelectToolClicked">
                    <Canvas Width="20" Height="24">
                        <TextBlock Text="T"
                                   FontFamily="Segoe UI"
                                   FontSize="18"
                                   FontWeight="SemiBold"
                                   Foreground="{Binding $parent[ToggleButton].Foreground}"
                                   Canvas.Left="2"
                                   Canvas.Top="1"/>
                        <Path Data="M 11,12 L 11,21 L 13.5,18.5 L 15.5,22 L 17.2,21 L 15.2,17.6 L 18.5,17.6 Z"
                              Fill="{Binding $parent[ToggleButton].Foreground}"/>
                    </Canvas>
                </ToggleButton>
                <ToggleButton Classes="RailButton"
                              Content="&#xE70F;"
                              FontFamily="Segoe MDL2 Assets"
                              IsChecked="{Binding PdfViewer.IsHighlightToolActive, Mode=OneWay}"
                              Click="OnHighlightToolClicked"/>
                <Button Classes="RailButton" Content="&#xE8A7;"/>
                <Button Classes="RailButton" Content="&#xE712;"/>
            </StackPanel>
        </Border>

        <views:PdfViewerView Grid.Row="1"
                             Grid.Column="1"
                             DataContext="{Binding PdfViewer}"/>
    </Grid>
</UserControl>

````

## MiniZotero/Views/TabWorkspaceView.axaml.cs

``csharp
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class TabWorkspaceView : UserControl
    {
        public TabWorkspaceView()
        {
            InitializeComponent();
        }

        private void OnHandToolClicked(object? sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            if (DataContext is TabWorkspaceViewModel viewModel)
            {
                viewModel.PdfViewer.SetHandTool();
            }
        }

        private void OnSelectToolClicked(object? sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            if (DataContext is TabWorkspaceViewModel viewModel)
            {
                viewModel.PdfViewer.SetSelectTool();
            }
        }

        private void OnHighlightToolClicked(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not TabWorkspaceViewModel viewModel)
            {
                return;
            }

            if (sender is ToggleButton { IsChecked: false })
            {
                viewModel.PdfViewer.SetSelectTool();
                return;
            }

            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            viewModel.PdfViewer.SetHighlightTool();
        }
    }
}

````

## Planning/OOP Diagram_5_21_2026, 3_29_00 PM.png

_Skipped binary or large file. Size: 1331217 bytes._

## Planning/OOP Diagram_5_21_2026, 3_30_17 PM.png

_Skipped binary or large file. Size: 668079 bytes._

## Planning/user flow_5_21_2026, 3_29_32 PM.png

_Skipped binary or large file. Size: 262863 bytes._

