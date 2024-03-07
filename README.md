# _ProgMan_ is reborn as [ShorterCut](https://www.getshortercut.com/), an open source, no-frills app launcher and desktop organizer.

ShorterCut is a free & lightweight program that provides a minimalist-view alternative to desktop folders.

![Screenshot 2024-03-06 131232](https://github.com/escardel/shortercut/assets/39771493/68b130b8-566b-4220-a4f5-bf3745fa025d)

Window colors and sizes are preserved, and icons for each group are programmatically assigned and added to the Desktop. 

<p align="center"><img src="https://github.com/escardel/shortercut/assets/39771493/4e6e0335-46e9-43e2-985b-e517a0579073"</p>

### How to use:

  1. Create a group name with Group Manager
  2. Add shortcuts via drag & drop or [+] button to search Start directory
  3. Hover over an icon and press "delete" on your keyboard to remove a shortcut
  4. Double click the lower panel to adjust the color
  6. Adjust the window size to your preference
  7. Replace the desktop icon (with an ICO file) if you wish via Right-Click -> Properties -> Change Icon
  8. Changes you make to the color and window size will save each time you close

> [!TIP]
> To transfer groups to a new PC, reinstall your apps (including ShorterCut) and transfer C:\ShorterCut + the desktop group launchers from the original PC. 

### Known issues:

* The default install directory C:\ShorterCut\appdata can't be changed yet without breaking functionality
* Program may crash when closing many windows at the same time
* Windows Store Apps are not yet supported (some may work, not fully tested)
* To add an app from the _**shell:appsfolder**_ Button you must drag to desktop first, then to ShorterCut
* Dragging a file out of the group is not yet working
* Can't yet launch programs that require UAC Elevation 

> [!NOTE]
> Apps launch from ShorterCut via single click and the window will auto-close (Start Menu-like behavior).
> Do not report this as a crash or bug; user preferences to adjust this are in the works.

Report bugs and make feature requests to improve ShorterCut.

Generate more custom icons to match the provided set with [Favicon](https://favicon.io/favicon-generator/ ) using the Lexend Font 

