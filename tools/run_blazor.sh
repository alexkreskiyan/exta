#!/usr/bin/env expect -f

set timeout -1
spawn dotnet watch run
expect  "Do you want to restart your app - Yes (y) / No (n) / Always (a) / Never (v)?\r"
send -- "a"
expect eof