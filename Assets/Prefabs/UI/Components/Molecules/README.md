* About this folder...
*   - Top level folder for all molecule level UI component Unity prefab objects.
*     - i.e. Search bars, etc.
*   - Atomic design setup
*   - Prefab files should be placed in their respective folders.

* WARNING!!!
*   - ALWAYS use the _TEST directory to edit and create prefabs. 
*     - Make copies of existing prefabs before editing.
*     - Prefabs do NOT roll back nicely. Commit often.
*   - For optimization text MUST be seperate from graphical elements, this includes text input.
*     - ADDITIONAL draw calls are accrued over context switching... font to spritesheet, spritesheet to spritesheet. etc.
*     - Be mindful of layering in UI builds.
*     - 30 or less draw calls for mobile is mostly optimimal.