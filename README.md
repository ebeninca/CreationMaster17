# Creation Master 17 #

Thanks to Rinaldo and Damian Wolf for the CM15 source code

https://bitbucket.org/fifa-tools/cm15/src/master/

## Project Structure

The Unity 3dRender project is incorporated in this project, so you can build at once the entire application in Visual Studio 2019.

Installation modules needed in VS2019:
- .NET desktop development
- Desktop development with C++

If you want to edit the 3dRender project in Unity 2022.3.10f1 IDE, clone this repository: <asdsfsf>

In this case you will need the extra module:
- Game development with Unity


## Pendencias

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
- 3D MODELS ON MULTIPLE SCREENS, TRY BALL FIRST, SEEMS TO BE THE EASIEST

110930

## Changelog

v006
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
- Preventing to set num_games in INTERFRIENDLY to avoid duplicate the national teams games
- Support for J-League parameters on match_stagetype=SETUP
- Support for Stage "Aggregate standings"
- Not setting match_stagetype=LEAGUE if match_situation is already LEAGUE
- Support for apertura/clausura asset_id
v002
- Support for Low Celebration level at Trophy level
- Support for Starting Month at World level (FIFA)
- Support for info_color_slot_adv_group at Stage level
- Hidding League tasks panel when Match Situation is not LEAGUE
- num_games = 0 in Group Stage (Used in Japanese League Overall Table)
v001
- Use Fan Cards
- Support to new Qualification Rules (ChampionsCup, EuroLeague)

## Current progress ##

* window is now centered and adjusted to display resolution
* enabled linear filtering for textures in 3D preview
* correct 3D render for all vertex formats

## How to download and install ##

Download binaries (cm15-2021-bin.zip) from

https://bitbucket.org/fifa-tools/cm15/downloads/

Copy&Paste to original CM15 install folder.