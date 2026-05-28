$ErrorActionPreference = "Stop"

$rootPath = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$outputPath = Join-Path $rootPath "ALL_CODE.md"
$excludedDirectoryNames = @(
    ".git",
    ".vs",
    ".idea",
    ".vscode",
    "bin",
    "obj",
    "node_modules"
)
$largeFileThresholdBytes = 100000

$languageByExtension = @{
    ".axaml" = "xml"
    ".cs" = "csharp"
    ".css" = "css"
    ".csproj" = "xml"
    ".gitattributes" = "gitattributes"
    ".gitignore" = "gitignore"
    ".html" = "html"
    ".js" = "javascript"
    ".json" = "json"
    ".manifest" = "xml"
    ".md" = "markdown"
    ".ps1" = "powershell"
    ".sln" = "text"
    ".txt" = "text"
    ".xml" = "xml"
}

function Get-RelativePath {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $normalizedRootPath = $rootPath

    if (-not $normalizedRootPath.EndsWith([System.IO.Path]::DirectorySeparatorChar)) {
        $normalizedRootPath += [System.IO.Path]::DirectorySeparatorChar
    }

    $rootUri = [Uri]$normalizedRootPath
    $pathUri = [Uri]([System.IO.Path]::GetFullPath($Path))

    return [Uri]::UnescapeDataString($rootUri.MakeRelativeUri($pathUri).ToString()).Replace("\", "/")
}

function Test-IsExcludedPath {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $relativePath = Get-RelativePath -Path $Path

    if ($relativePath -eq "ALL_CODE.md") {
        return $true
    }

    $segments = $relativePath -split "/"

    foreach ($segment in $segments) {
        if ($excludedDirectoryNames -contains $segment) {
            return $true
        }
    }

    return $false
}

function Test-IsBinaryFile {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $buffer = New-Object byte[] 8192

    try {
        $stream = [System.IO.File]::Open($Path, [System.IO.FileMode]::Open, [System.IO.FileAccess]::Read, [System.IO.FileShare]::ReadWrite)
        try {
            $bytesRead = $stream.Read($buffer, 0, $buffer.Length)

            for ($index = 0; $index -lt $bytesRead; $index++) {
                if ($buffer[$index] -eq 0) {
                    return $true
                }
            }
        }
        finally {
            $stream.Dispose()
        }
    }
    catch {
        return $true
    }

    return $false
}

function Get-CodeFenceLanguage {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $extension = [System.IO.Path]::GetExtension($Path).ToLowerInvariant()

    if ($languageByExtension.ContainsKey($extension)) {
        return $languageByExtension[$extension]
    }

    return "text"
}

$builder = [System.Text.StringBuilder]::new()
[void]$builder.AppendLine("# MiniZotero - All Code")
[void]$builder.AppendLine()
[void]$builder.AppendLine("Generated from the current workspace source files. Build output, IDE folders, node_modules, and Git internals are excluded.")

$files = Get-ChildItem -LiteralPath $rootPath -File -Recurse |
    Where-Object { -not (Test-IsExcludedPath -Path $_.FullName) } |
    Sort-Object { Get-RelativePath -Path $_.FullName }

foreach ($file in $files) {
    $relativePath = Get-RelativePath -Path $file.FullName

    [void]$builder.AppendLine()
    [void]$builder.AppendLine("## $relativePath")
    [void]$builder.AppendLine()

    if ($file.Length -gt $largeFileThresholdBytes -or (Test-IsBinaryFile -Path $file.FullName)) {
        [void]$builder.AppendLine("_Skipped binary or large file. Size: $($file.Length) bytes._")
        continue
    }

    $language = Get-CodeFenceLanguage -Path $file.FullName
    $content = [System.IO.File]::ReadAllText($file.FullName)

    [void]$builder.AppendLine("````$language")
    [void]$builder.AppendLine($content.TrimEnd())
    [void]$builder.AppendLine("````")
}

[System.IO.File]::WriteAllText($outputPath, $builder.ToString(), [System.Text.UTF8Encoding]::new($false))
Write-Host "Updated ALL_CODE.md"
