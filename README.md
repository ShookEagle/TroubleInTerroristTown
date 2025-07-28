# Trouble in Terrorist Town (TTT) for Counter-Strike 2

### Made by EdgeGamers for All to use
[![Discord](https://img.shields.io/discord/161245089774043136?style=for-the-badge&logo=discord&logoColor=%23ffffff&label=Discord&color=%235865F2)](https://discord.gg/yourserver)

A fully featured Trouble in Terrorist Town gamemode, rebuilt for Counter-Strike 2 using the CounterStrikeSharp framework.

---

## Downloads

[![Release](https://img.shields.io/badge/Release-mediumseagreen?style=for-the-badge&logo=onlyoffice)](https://github.com/your-org/TTT/releases/)
[![Stable](https://img.shields.io/badge/Stable-orangered?style=for-the-badge&logo=onlyoffice)](https://github.com/your-org/TTT/releases/)
[![Dev](https://img.shields.io/badge/Nightly-slateblue?style=for-the-badge&logo=onlyoffice)](https://nightly.link/shookeagle/TroubleInTerroristTown/workflows/nightly/dev/TTT-nightly)

**Release** builds are formal and tested versions.

**Stable** builds are what we run on our own production servers and may include early features.

**Nightly** builds are used exclusively for development and staging, and are likely to have problems.

---

## Versioning

Our versions follow [Semantic Versioning 2.0.0](https://semver.org/):

- **MAJOR** — breaking API changes.
- **MINOR** — new backwards-compatible features.
- **PATCH** — backwards-compatible bug fixes.

---

## Status

- **Core Systems**
    - [ ] Role Assignment (Innocent / Traitor / Detective)
    - [ ] Round Phases (Pre-round, Active, Post-round)
- **Gameplay Features**
    - [ ] Traitor/Detective Shop System
    - [ ] DNA Scanners, Body ID, Scoreboard Info
    - [ ] DNA Sample Tracking
    - [ ] Karma System
- **Infrastructure**
    - [x] Logging & Debugging
    - [ ] Configurable FakeConVars
    - [ ] Round Timer System
    - [ ] RDM Manager
- **Maps**
    - [ ] Role-safe Filtering
    - [ ] Dynamic Map Objectives
    - [ ] Map-Based Logic Extensions

---

## Configuration

TTT uses CS#’s [`FakeConVar`](https://docs.cssharp.dev/examples/WithFakeConvars.html?q=fakeconvar) system for configuration.

To find configurable options, search the repository for `FakeConVar`.

---

## Modding

You can fork TTT and extend it however you'd like! The plugin is structured as a modular base you can hook into via submodules or your own local plugins.

```bash
git submodule add https://github.com/link-to-repo
```
Once you have a dependency to `TTT.Public`, you can add in whatever functionality
you want from the current plugin, and choose to add in your own handlers if you wish.
Don't forget to register them with the service container!

To boot your plugin, simply iterate over all services that inherit from `IPluginBehavior`,
as demonstrated in `src/TTT/TTT.cs`:

```cs
foreach (IPluginBehavior extension in _extensions)
{
    //	Register all event handlers on the extension object
    RegisterAllAttributes(extension);

    //	Tell the extension to start it's magic
    extension.Start(this);
}
```

## Building

The TTT plugin automatically builds to `build/TTT` when
using `dotnet publish src/TTT/TTT.csproj`.
Please use [SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or higher.

Note that only the `src/TTT` project is intended to be built directly.

## Using

TTT requires Counter Strike Sharp. If you don't have that installed, [follow the
install instructions here](https://docs.cssharp.dev/docs/guides/getting-started.html).

Install the plugin like any other Counter Strike Sharp plugin: drop the `TTT` folder into
`game/csgo/addons/counterstrikesharp/plugins`.
