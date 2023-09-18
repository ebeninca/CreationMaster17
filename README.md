# Creation Master 17 Compdata #

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

## Modifications

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