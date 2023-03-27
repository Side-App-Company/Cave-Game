* About this folder...
*   - Top level folder for all Unity shaders.
*   - Unity default shaders should be placed in the _DEFAULTS folder.
*   - All other shader files should be placed in their respective folders.

* WARNING!!!
*   - Unity makes duplicate copies of the default shader if you don't manually set a new default.
*     - This creates extra overhead in memory across addressable files.
*   - ALWAYS set a shader even if it's just our own copy of the default material.