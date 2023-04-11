# Contributing

## Versioning

This project uses [GitVersion](https://gitversion.net/docs/) to automatically increment NuGet package versions without the need to update
project or `AssemblyInfo.cs` files.

We use the default "**Mainline**"  strategy for GitVersion to keep things simple.

Any feature branch merged into `main` will automatically increment the _patch_ field by one: `1.0.1` -> `1.0.2`

To increase the _minor_ version, simply add the string `+semver: minor` to any commit message on your feature branch.
When merged to `main` GitVersion will increment the _minor_ field by one: `1.0.2` -> `1.1.0`

To increase the _major_ version, add the string `+semver: major` to any commit message on your feature branch.
When merged to `main` GitVersion will increment the _major_ field by one: `1.1.0` -> `2.0.0`

Obviously you should follow the [SemVer](https://www.semver.org) principles when deciding when to increment the
minor and major fields.  Note that we version all of the packages together with the same version number, so incrementing
the version to reflect a backwards-compatible or breaking API change in one package will update the version on all the packages.

You can instruct GitVersion not to increment the version at all by including the string `+semver: skip` in a commit message.
This can be useful when updating non-code files (like this Markdown file).
