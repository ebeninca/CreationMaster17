# Creation Master 17 Compdata #

## Pendencias

- Weather Probability
- Preventing to set num_games in INTERFRIENDLY, it duplicates the national teams games
- Tasks, initteams, advancement ok, falta settings


```
-0,nation_id,-1
-0,asset_id,-1

Campeonato Chileno foi alterado asset_id de 156 e 157 para 335

-226,standings_sort,H2HPOINTS

// Match importance at stage level
-284,match_matchimportance,90

// year real at group level 
+305,schedule_year_real,2016

// year real at stage level 
-760,schedule_year_real,2016

// looks like its not needed, just being setted by CM15 when match_situation is LEAGUE
// ECONOMIA GRANDE DE LINHAS +/- 50
+769,match_stagetype,LEAGUE 

// stadium has been move from Group to Stage by CM15
-857,match_stadium,14

+1164,standings_sort,GOALDIFF
+1164,standings_sort,GOALSFOR

// year real zero for MLS Stage ???
-1412,schedule_year_real,0

//double asset_id removed on LIGA MX
//parece que a intenção é indicar que é o mesmo campeonato separado em 2 subcampeonatos (clausura/apertura), necessario ??
-1436,asset_id,85
 1436,asset_id,341
 
// advance_standingsrank é novo, verificar se precisa ser adicionado a tela de Stage (14 linhas)
 1444,advance_standingsrank,1437
+1446,standings_checkrank,1437

// advance_standingsagg é novo, verificar se precisa ser adicionado a tela de Stage (foi totalmente removido pelo CM15)
-1545,advance_standingskeep,1543
-1545,advance_standingsagg,1541

// advance_jleague novo no SETUP stage type, precisa?? (removido pelo CM15) 
 1547,match_stagetype,SETUP
-1547,advance_jleague_ignore_check,1
 1549,match_stagetype,SETUP
-1549,advance_jleague_qtr_setup,1545

// year zero ??
-1662,schedule_year_real,0

 1699,standings_sort,H2HGOALDIFF
 1699,standings_sort,H2HGOALSFOR
 

 ```

## Modifications

v2
- Support for Low Celebration level at Trophy level
- Support for Starting Month at World level (FIFA)
- Support for info_color_slot_adv_group at Stage level
- Hidding League tasks panel when Match Situation is not LEAGUE
- num_games = 0 in Group Stage (Used in Japanese League Overall Table)

v1
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