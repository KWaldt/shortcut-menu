# Unity: Shortcut Menu Package

This is a demo for a tutorial on how to create custom shortcuts to ease your workflow. (And how to create git packages for Unity.)  
The tutorial is still WIP.

You can, of course, use the shortcuts as they are. They should all support Undo and work fine, but feel free to tell me if something goes wrong.

## How to install
* Open the Package Manager
* Plus-Icon: Add package from git URL...
* Use the HTTPS adress found in "Clone" (https://github.com/KWaldt/shortcut-menu.git)

## How to use
* The menu bar has a new entry called "Custom". That's where the functions are.
* Settings.cs: The menu path is hardcoded as "Custom". You can change this, though you might need to reapply the change after an update.
* The shortcuts can be edited in "Edit/Shortcuts". I chose the existing ones more or less randomly. 

## Included Shortcuts
### Bake Lighting
* Allows you to manually bake the lighting via shortcut. Uses the Async version.

### Create Parent
* Parents the selected objects under an empty called "Parent".
* If multiple objects are selected, the parent pivot is in the center of them.

### Pseudo Maya Parenting
* Only one object selected: Unparents one level. (So the new parent is the previous grandparent.)
* If multiple objects are selected: Parent/unparent to the last selected parent.

### Random Y Rotation
* Rotates all selected objects randomly on the Y axis. Useful for set dressing. 
* You could do something similar to randomise the scale or introduce slight XZ position offset:

### Reset Transform Component
* Applies to all selected objects. Useful if you're annoyed by Unity trying to place the object "at the correct spot in the scene" when you just want your manager to be in the origin.
