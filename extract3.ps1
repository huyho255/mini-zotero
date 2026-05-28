$lines = Get-Content 'c:\Users\Asus\source\repos\mini-zotero\ALL_CODE.md'
$inCode = $false
$js = @()
foreach ($line in $lines) {
    if ($line -match '^## MiniZotero/Assets/PdfViewer/viewer\.js$') {
        $inCode = $true
        continue
    }
    if ($inCode -and $line -match '^```') {
        if ($line -match '^```javascript') { continue }
        else { $inCode = $false; break }
    }
    if ($inCode) {
        $js += $line
    }
}
Set-Content -Path 'c:\Users\Asus\source\repos\mini-zotero\MiniZotero\Assets\PdfViewer\viewer.js' -Value $js
