# Creation Master 17

Thanks to Rinaldo and Damian Wolf for the CM15 source code

https://bitbucket.org/fifa-tools/cm15/src/master/

## Project Structure / To Build

Installation modules needed in Visual Studio 2019 Community (https://visualstudio.microsoft.com/pt-br/vs/older-downloads/):
- .NET desktop development
- Desktop development with C++

The Unity 3dRender executable is provided in this project, so you can build at once.

If you want to edit the 3dRender project in Unity 2022.3.10f1 IDE, follow this repository: <asdsfsf>. In this case you will need the extra module installed with Visual Studio:
- Game development with Unity


## Data Changes

- South Africa stadium: Allianz Arena
- Cameroon stadium: Stadio Olimpico
- Ivory Coast stadium: Etihad Stadium
- Turkey stadium: Stadion Hanguk

## Pendencies

- Weather Probability
- Argentina num_games = 0

```
-0,nation_id,-1
-0,asset_id,-1

-226,standings_sort,H2HPOINTS

// Match importance at stage level
-284,match_matchimportance,90

// year real at group level 
+305,schedule_year_real,2016

// year real at stage level 
-760,schedule_year_real,2016

// stadium has been move from Group to Stage by CM15
-857,match_stadium,14

+1164,standings_sort,GOALDIFF
+1164,standings_sort,GOALSFOR

// year real zero for MLS Stage ???
-1412,schedule_year_real,0
// year zero ??
-1662,schedule_year_real,0

+1699,standings_sort,H2HGOALDIFF
+1699,standings_sort,H2HGOALSFOR
 
 ```
 
- FIFA DB IS SMALLER AFTER SAVING FOR THE FIRST TIME, LOSS OF DATA?

- FIX TEMPLATE/DB FILES TO BUILD AND RUN CORRECTLY: Probably need to package the original db file within cm17

- What is the purpose of shortstyle? Roda JC Kerkade (321) value = 3, maybe affects the 3d model?

## Changelog

v009
- CompData: competition dependency bug fixed (EuropaLeague/ChampionsLeague)
- Mainform: ask to save when clicking on window close(X)
- Teams: National Team automatically updating Country screen
- Teams: fixed Rival/Opponent Team link
- Country: fixed all text fields only saving after leaving field
- Country: fixed ISO Level only updating after leaving field
- Teams: fixed National Team relation
- Teams: support for ROTW Team
- Teams: Segregated National Team combo from ROTW Team
- Teams: fixed Last Year Performance League combo

v008
- Country: fixed National team target not saving
- Teams: fixed stadium change not saving
- Teams: Added links to all kits 
- Kits: Support for IsEmbargoed
- Kits: Support for new format of number colors (primary, secondary and tertiary)
- Compdata: added support to Competition Dependency (advance_teamcompdependency)
- Compdata: reload data right after saving
- Compdata: Added Data Usage at World Level (FIFA)
- Compdata: Fixed bug on "Get teams in order from league"
- Compdata: "4 Chars Name" adjusted to "5 Chars Code"
- Compdata: failsafe for new tournaments rankings table, avoiding the necessity of open the data again to add it.

v007
- 3d Render: Opengl before DirectX 12 and 11
- FbxViewer ServerPort Enum

v006
- Visual adjustements in Ball form
- Communication with 3D Render via TCP
- Basic Ball 3D Render working with Unity executable

v005
- Link between Country and National Team
- Support for Male/Female and Emotions on player creation.

v004
- Bench and Yellows at FIFA level
- Changed the link between country and team, now using Internationals.txt
- Fixed "Regional Cup Target" bug
- League/Trophy id max = 9999
- Multiple fixes related with Legacy assets in all screens
- Fixed link between Country and National Team
- Support for ISOCountryCode on Country Screen
- Using FIFA 17 Country/League/Teams assets (Extracted with FrostyEditor 1.0.6.2)
v003
- Compdata: Preventing to set num_games in INTERFRIENDLY to avoid duplicate the national teams games
- Compdata: Support for J-League parameters on match_stagetype=SETUP
- Compdata: Support for Stage "Aggregate standings"
- Compdata: Not setting match_stagetype=LEAGUE if match_situation is already LEAGUE
- Compdata: Support for apertura/clausura asset_id
v002
- Compdata: Support for Low Celebration level at Trophy level
- Compdata: Support for Starting Month at World level (FIFA)
- Compdata: Support for info_color_slot_adv_group at Stage level
- Compdata: Hidding League tasks panel when Match Situation is not LEAGUE
- Compdata: num_games = 0 in Group Stage (Used in Japanese League Overall Table)
v001
- Compdata: Use Fan Cards
- Compdata: Support to new Qualification Rules (ChampionsCup, EuroLeague)

## Current progress ##

* window is now centered and adjusted to display resolution
* enabled linear filtering for textures in 3D preview
* correct 3D render for all vertex formats

## How to download and install ##

Download binaries (cm15-2021-bin.zip) from

https://bitbucket.org/fifa-tools/cm15/downloads/

Copy&Paste to original CM15 install folder.