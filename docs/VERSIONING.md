# Versioning
Version numbers will follow semver. Appended with the current pre-release stage (e.g. alpha, beta) and the github build number.

Example:
```
GetStanza.0.0.0-alpha0
```

To update the semver numbers, edit the VERSION env variable in [.github/workflows/release.yaml](/.github/workflows/release.yaml)

To update the pre-release stage, edit the PRE_RELEASE env variable in [.github/workflows/release.yaml](/.github/workflows/release.yaml)
