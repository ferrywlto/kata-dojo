# Kata Dojo

My coding practice dojo.

## IDE Used

- VSCode
- JetBrains Rider

## Languages Included

- C#
(More to come)

## Content

- LeetCode
- Coding Challenge
- Pet-projects

## Configuration

The repository use developement container to ensure the code will work across machines. To support different tech stack, docker compose has been used instead of single `.devcontainer` config for typical single tech stack repository.

```text
.
├── .gitignore
├── .devcontainer
│   └── devcontainer.json
├── docker-compose.yml
├── csharp
│   ├── csharp.csproj
│   ├── csharp.sln
│   ├── Program.cs
│   └── .devcontainer
│       └── devcontainer.json
└── nodejs
    ├── main.js
    └── .devcontainer
        └── devcontainer.json
```

To switch dev container when need to work on other tech stack (e.g. switching back and forth from dotnet and nodejs), edit `.devcontainer/devcontainer.json`:

```json
// "service": "${localEnv:DEV_SERVICE}",
"service": "csharp",
```

Change the service name to those defined in `docker-compoase.yml`. (e.g. `csharp` / `nodejs`)

This could be defeating the purpose of using devcontainer as someone may accidentially commited the change of `decontainer.json` because they worked on different language / project in the same repository. However as of December 2023, due to VSCode Dev Container extension limitation, there is no easy way to pass environment variable to `.devcontainer/devcontainer.json`, see the `"userEnvProve"` section form [devcontainer.json schema reference](https://containers.dev/implementors/json_reference/) for more information:

> Indicates the type of shell to use to “probe” for user environment variables to include in devcontainer.json supporting services’ / tools’ processes: none, interactiveShell, loginShell, or loginInteractiveShell (default). The specific shell used is based on the default shell for the user (typically bash). For example, bash interactive shells will typically include variables set in /etc/bash.bashrc and ~/.bashrc while login shells usually include variables from /etc/profile and ~/.profile. Setting this property to loginInteractiveShell will get variables from all four files.

Environment variable can only be passed from the shell. Loading from files like `.env` and then reference in `devcontainer.json` in [`${localEnv:Variable_Name}`](https://containers.dev/implementors/json_reference/#variables-in-devcontainerjson) is not possible.

In-addition, editing `~/.zprofile` whenever switching tech stack is not convenient and risky of messing up machine wide settings.

As long as the repository used by myself only, it is acceptable to change the `service:` value in `devcontainer.json` whenever I switch for other language. Will keep this up to date whenever I can find a better solution.