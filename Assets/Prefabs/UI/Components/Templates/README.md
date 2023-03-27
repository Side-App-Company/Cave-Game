* About this folder...
*   - Top level folder for all template level UI component Unity prefab objects.
*     - i.e. Uncompiled Scene UI Canvas'.
*   - Atomic design setup
*   - Prefab files should be placed in their respective folders.

* WARNING!!!
*   - ALWAYS use the _TEST directory to edit and create prefabs. 
*     - Make copies of existing prefabs before editing.
*     - Prefabs do NOT roll back nicely. Commit often.
*   - For optimization text MUST be seperate from graphical elements, this includes text input.
*     - ADDITIONAL draw calls are accrued over context switching... font to spritesheet, spritesheet to spritesheet. etc.
*     - Be mindful of layering in UI builds.
*     - EVERY canvas is an addition set of draw calls.
*     - Be mindful of canvas grouping.
*     - 30 or less draw calls for mobile is mostly optimimal.