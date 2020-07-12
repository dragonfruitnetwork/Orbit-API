# Orbit (API)
![CI](https://github.com/dragonfruitnetwork/Orbit-API/workflows/Publish/badge.svg)
![Code Quality](https://github.com/dragonfruitnetwork/Orbit-API/workflows/Code%20Quality/badge.svg)
[![Codacy](https://api.codacy.com/project/badge/Grade/d4cc27241ce741a482169f3efaa018af)](https://www.codacy.com/gh/dragonfruitnetwork/Orbit-API)
[![NuGet](https://img.shields.io/nuget/v/DragonFruit.Orbit.API.svg?style=popout)](https://www.nuget.org/packages/DragonFruit.Orbit.API/)
[![DragonFruit Discord](https://img.shields.io/discord/482528405292843018?label=Discord&style=popout)](https://discord.gg/VA26u5Z)

## Overview
Orbit API is designed to gmake accessing osu! stats easy, with support for **both** versions of the API (v1 and v2)

### Getting Started
Want to give this a try? Check out the [getting started guide](https://github.com/dragonfruitnetwork/Orbit-API/blob/master/getting-started.md)

### API Contents

#### OAuth
- OAuth session requests (`autorization_code`, `refresh_token` and `client_credential`)

#### User
- Identifying user info (`/me`)
- Identifying user's friend list
- User info & mode stats (by name or id)
- User kudosu
- User recent activity (modding, kudosu, scores, failed plays)
- User highest scores
- User's beatmaps (filtered by ranked status)

#### Leaderboards
- Spotlights listing (+ leaderboards)
- Common Leaderboards (Country, Score, Performance, Spotlights)

#### Beatmaps & Beatmapsets
- Beatmapset search
- Beatmapset modding events
- Beatmap lookup (by id, filename, md5)
- Beatmap info
- Beatmap scores

#### Info
- Changelogs
- News (partially implemented)
- Comments

#### Legacy (API v1)
- User Info (by name or id)
- Beatmap(set) info
- User's highscores and recent plays (+ failed ones)
- Multiplayer lobby scores and participants

## Testing

Test project will be written once the `client_credential` grant goes live.