cd C:\Users\isinc\Desktop\Labs

get-childitem -Directory -Include  packages -Recurse -force | Remove-Item -Force –Recurse