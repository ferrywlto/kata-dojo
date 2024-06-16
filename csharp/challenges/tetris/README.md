# Tetris in Blazor

## How to run
- debug mode `dotnet watch`
- docker compose `docker compose build && docker compose up`
- docker `docker run -p 80:80 -e MongoDbConnStr={connStr}`

## Tasks
### Optiminization

- Rendering Logic

Use canvas or svg instead of divs

### Features WIP
- [] Add square shape
- [] Shape colors

### Features wish list

- [] Game restart
- [] Counting points
- [] Control UI
- [] Rotate
- [] Unit tests
- [] Increase level
- [] Configurable game settings
- [] Configurable shape colors
- [] Keymap config
- [] Add bar shape
- [] Add left Z shape
- [] Add right Z shape
- [] Add left L shape
- [] Add right L shape
- [] Add short T shape
- [] Landing screen
- [] Replay
- [] Local high score
- [] Dockerize
- [] MongoDb score and replay storing
- [] Ngrok `docker run` Tetris server