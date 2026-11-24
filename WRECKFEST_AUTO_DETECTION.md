# Wreckfest x64 automatic version and global-base detection

## Live Data UI

The version dropdown in **Game version and configuration** offers **Automatic (Wreckfest_x64.exe)** above
all JSON-defined manual versions. Automatic is the default on a fresh set of
form settings. Older saved settings are respected: previously saved manual
versions remain manual. Select Auto explicitly if desired. Profiles remember
which mode was selected.

On **Get Process / Refresh Process**, Auto finds the attached process, opens the
real executable via `Process.MainModule.FileName`, and scans it once. Successful
detection shows the detected `V1_<build>` and computed shift under the selector
and in the window title. It never performs file scans in the sampling timer. Version/configuration changes also invalidate the cached raw-field read plans and timing span.

If detection fails (signature changed, no file access, ambiguous signature),
the connection is stopped and an error is displayed. The user can choose a
manual version profile without changing `WreckfestGameMemoryConfig.json`.

## Signatures and computation

The scanner checks **unique** code patterns in the **64-bit PE file**:

- `41 B8 ?? ?? ?? ?? 48 0F 44 C2 48`: the 4-byte immediate in `mov r8d,imm32`
  is the build, e.g. 285308 or 308438.
- `48 8B C4 53 57 48 81 EC C8 00 00 00 0F 29 70 D8 48 8D 1D`
  followed by a signed disp32 and `0F 29 78 C8 48 8B FA 44 0F 29 40 B8`:
  the RIP-relative `lea rbx,[rip+disp32]` points at the Tire global variable.

`TireRVA = InstructionRVA + 7 + signed disp32`, where `InstructionRVA`
comes from the PE section table (NOT the raw file offset). The scanner also
requires the target to lie inside `.data`.

In Auto mode, `GameMemoryConfig.SelectDetectedVersion` chooses the matching
`V1_<build>` JSON profile if one exists, preserving its custom overrides.
Otherwise it selects the `V1_285308` reference (or another shift-0 profile).
The runtime memory-reader shift is **detected TireRVA minus the selected
profile's unshifted Tire base address**. The shift is used for all configured
base-address reads without writing guessed offsets into JSON.

This assumes that other global base addresses move by the same amount. That is
verified for the supplied 1.285308 and 1.308438 builds but NOT guaranteed for
unexamined future versions. Version-specific `enumOverrides` remain useful
where individual fields move differently.

| Uploaded EXE | Build | Tire target RVA | Auto shift from 1.28 |
|---|---:|---|---|
| 1.28 | 285308 | `0x18324C8` | `0x0` |
| 1.30 | 308438 | `0x183C2C8` | `+0x9E00` |

`V1_308408` was a typo and is corrected to `V1_308438` in the embedded factory
JSON. For **existing** AppData JSON files and saved FormLiveData profiles, the
loader recognizes the old ID and presents the corrected version **without
rewriting the user's files**. Edit the JSON on disk to fix its stored spelling.

## Validation and manual testing

1. Open a project from the ZIP, build it in Visual Studio for x64 .NET 4.7.2.
2. In Live Data choose Automatic, run Wreckfest 1.28, then Get Process; check
   `V1_285308`, shift `+0x0`, and live values.
3. Repeat with 1.30; check `V1_308438`, shift `+0x9E00`.
4. Select a manual `V1_...` option; verify it uses its configured JSON
   `baseAddressShift` and any `enumOverrides`.
5. Save Auto to a form profile, restart, and verify it restores Auto.
6. Try an unsupported executable/signature and verify detection safely fails,
   without attempting telemetry reads with guessed offsets.

No automatic detection can guarantee correct field layout on an unknown build.
