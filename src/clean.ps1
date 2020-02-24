$dirs = "bin", "obj"

foreach ($dir in $dirs) {
    $dels = Get-ChildItem -Directory -Recurse -Filter $dir

    foreach ($del in $dels) {
        Write-Output "DELETING: $($del.FullName)"

        Remove-Item $($del.FullName) -Force -Recurse
    }
}