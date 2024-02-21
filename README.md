# Lethal Company Mod Helper

[中文说明](./README.zh-CN.md)

## How to Use

After opening the Lethal Company MOD Installer:

1. Choose the MOD you want to install, the first one is selected by default.
2. Click "Install MOD" for automatic installation.
3. Then click "Start Game" to launch the game.

If you can't open it, copy the following address to download and install the .NET runtime via your browser:
https://dotnet.microsoft.com/zh-cn/download/dotnet-framework/thank-you/net48-offline-installer

## How to Make an Installation Package

1. Create your MOD package folder under the application program folder, for example, "Custom MOD Package".
2. In the newly created "Custom MOD Package" folder, create a "Base" folder and put your MOD base package in it (make sure this directory contains the BepInEx folder), which will be copied to the root directory of the game during installation.
3. (Optional) In the "Custom MOD Package" folder, create an "Optional" folder. This folder is for optional installation packages. Each subfolder is an optional installation package, and the file structure is the same as the base package folder.
4. (Optional) Create a "README.txt" file in the "Custom MOD Package" folder, edit and add the text you want to display to the user in the installation interface, and save it.
5. (Optional) Create an "ABOUT.txt" file in the "Custom MOD Package" folder, edit and enter your personal homepage URL (it needs to start with http:// or https://), and save it.
6. (Optional) Create an "UPDATE.txt" file in the "Custom MOD Package" folder, edit and enter the MOD package update URL (it needs to start with http:// or https://), and save it.
7. Add "LethalCompanyModHelper.exe", "Gameloop.Vdf.dll", "Custom MOD Package", and any other files you want to package together into a compressed package.
8. The player opens this compressed package and double-clicks "LethalCompanyModHelper.exe" for one-click installation.

## Screenshots

![image](https://github.com/tinymins/LethalCompanyModHelper/assets/1808990/2e20ff53-9c61-4b75-98df-ae9c0bad49e2)
![image](https://github.com/tinymins/LethalCompanyModHelper/assets/1808990/dac4b303-4d5f-4984-b318-e4d267e31b2c)
![image](https://github.com/tinymins/LethalCompanyModHelper/assets/1808990/7ccf3477-d6b4-4d3e-a672-2470dfb99924)
