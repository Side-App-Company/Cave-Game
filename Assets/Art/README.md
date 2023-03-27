* About this folder...
*   - Top level folder for all Artwork.
*   - Raw working files such as ".psd", etc should be placed in the _RAW folder.
*   - Outside game assets, i.e. app icons, etc, should be placed in the General folder.
*   - All other art files should be placed in their respective folders.

* WARNING!!!
*   - Art assets do NOT roll back nicely. Commit often.
*   - Every spritesheet creates a draw call when loaded in. Be mindful of how sprites are compressed together.
*   - Fonts and different font sizes create their own respective draw calls. Be mindful of font sizing usage.
*   - Draw calls in 2D happen back to front on the Z axis. Be mindful of layering in game builds.
*   - 30 or less draw calls for mobile is mostly optimimal.